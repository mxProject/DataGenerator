#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;

using mxProject.Devs.DataGeneration;
using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Devs.DataGeneration.Configuration.Json;

using mxProject.Tools.DataFountain.Forms;

namespace mxProject.Tools.DataFountain.Executions
{

    /// <summary>
    /// Executor.
    /// </summary>
    internal class Executor : MarshalByRefObject, IExecutor
    {
        
        /// <summary>
        /// Create a new instance.
        /// </summary>
        public Executor()
        {
        }

        /// <inheritdoc/>
        void IDisposable.Dispose()
        {
        }

        #region lifetime

        /// <inheritdoc/>
        public override object InitializeLifetimeService()
        {
            ILease lease = (ILease)base.InitializeLifetimeService();

            if (lease.CurrentState == LeaseState.Initial)
            {
                lease.Register(new UnlimitedSponsor());
            }

            return lease;
        }

        private sealed class UnlimitedSponsor : MarshalByRefObject, ISponsor
        {
            internal UnlimitedSponsor()
            {
            }

            public TimeSpan Renewal(ILease lease)
            {
                System.Diagnostics.Debug.WriteLine("UnlimitedSponsor.Renewal");
                return lease.InitialLeaseTime;
            }
        }

        #endregion

        /// <summary>
        /// Singleton instance.
        /// </summary>
        internal readonly static Executor Default = CreateDefault();

        #region factory method

        private static Executor CreateDefault()
        {
            Executor executor = new();

            return executor;
        }

        /// <summary>
        /// Creates an instance in the specified application domain.
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        internal static IExecutor UseAnotherDomain(AppDomain appDomain, ExecutorSetupArgs args)
        {
            IExecutor proxy = (IExecutor)appDomain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, typeof(Executor).FullName);

            proxy.Setup(args);

            return proxy;
        }

        #endregion

        #region setup

        private readonly List<Assembly> m_Assemblies = new();
        private string? m_ContextActivatorTypeName;

        private void Setup(ExecutorSetupArgs args)
        {
            if (args.Assemblies != null)
            {
                AppDomain.CurrentDomain.TypeResolve -= CurrentDomain_TypeResolve;
                AppDomain.CurrentDomain.TypeResolve += CurrentDomain_TypeResolve;

                foreach (var asm in args.Assemblies)
                {
                    m_Assemblies.Add(AppDomain.CurrentDomain.Load(asm));
                }
            }

            m_ContextActivatorTypeName = args.ContextActivatorTypeName;
        }

        void IExecutor.Setup(ExecutorSetupArgs args)
        {
            Setup(args);
        }

        private Assembly CurrentDomain_TypeResolve(object sender, ResolveEventArgs args)
        {
            foreach (var asm in m_Assemblies)
            {
                var type = asm.GetType(args.Name);

                if (type != null)
                {
                    return asm;
                }
            }

            return null!;
        }

        #endregion

        #region validation

        /// <inheritdoc/>
        public bool ValidateAsValueTypeName(string valueTypeName, out string? invalidMessage)
        {
            return ValidationUtility.ValidateAsValueTypeName(valueTypeName, out invalidMessage);
        }

        /// <inheritdoc/>
        public bool IsEnumType(string valueTypeName)
        {
            var type = Type.GetType(valueTypeName);

            if (type == null) { return false; }

            return type.IsEnum;
        }

        /// <inheritdoc/>
        public bool ValidateAsFieldValue(string text, string valueTypeName, out string? invalidMessage)
        {
            var type = Type.GetType(valueTypeName);

            if (type == null)
            {
                invalidMessage = "The specified type cannot be recognized.";
                return false;
            }

            return ValidationUtility.ValidateAsFieldValue(text, type, CreateGeneratorContext().StringConverter, out invalidMessage);
        }

        #endregion

        #region generation

        /// <inheritdoc/>
        public void ShowPreview(string generatorSettingsJson, int? generatingCount)
        {
            try
            {
                var generatorSettings = DeserializeGeneratorSettings(generatorSettingsJson);
                var context = CreateGeneratorContext();

                using DataPreviewForm form = new();

                form.ShowDialog(null!, generatorSettings!.CreateBuilder(context), generatingCount);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <inheritdoc/>
        public void OutputCsv(string generatorSettingsJson, Configurations.CsvSettings csvSettings)
        {
            try
            {
                var generatorSettings = DeserializeGeneratorSettings(generatorSettingsJson);
                var context = CreateGeneratorContext();

                using CsvOutputForm form = new();

                form.ShowDialog(null!, generatorSettings!.CreateBuilder(context), csvSettings);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deserialize the specified json to the generator settings.
        /// </summary>
        /// <param name="generatorSettingsJson"></param>
        /// <returns></returns>
        private DataGeneratorSettings? DeserializeGeneratorSettings(string generatorSettingsJson)
        {
            var converter = DataGeneratorFieldTypeConverterBuilder.CreateDefault().Build();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<DataGeneratorSettings>(generatorSettingsJson, converter.ToArray());
        }

        /// <summary>
        /// Create a generator context.
        /// </summary>
        /// <returns></returns>
        private DataGeneratorContext CreateGeneratorContext()
        {
            if (string.IsNullOrEmpty(m_ContextActivatorTypeName))
            {
                return new DataGeneratorContext();
            }

            var activatorType = Type.GetType(m_ContextActivatorTypeName);

            if (activatorType == null)
            {
                throw new NullReferenceException($"Unable to recognize activator type of the generator context.\ntypename: {m_ContextActivatorTypeName}");
            }

            var activator = (IDataGeneratorContextActivator)Activator.CreateInstance(activatorType, true);

            return activator.CreateContext();
        }

        #endregion

    }

}
