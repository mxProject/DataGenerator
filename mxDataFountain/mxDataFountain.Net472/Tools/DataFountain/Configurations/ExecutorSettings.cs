#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace mxProject.Tools.DataFountain.Configurations
{

    /// <summary>
    /// Executor settings.
    /// </summary>
    public class ExecutorSettings : ICloneable
    {

        /// <summary>
        /// Gets the file paths of the assembly to load.
        /// </summary>
        public string?[]? AssemblyFiles { get; set; }

        /// <summary>
        /// Gets the activator type name that creates the generator context.
        /// </summary>
        public string? DataGeneratorContextActivator { get; set; }

        #region clone

        /// <inheritdoc/>
        public object Clone()
        {
            var clone = (ExecutorSettings)this.MemberwiseClone();

            if (AssemblyFiles != null)
            {
                clone.AssemblyFiles = (string?[])AssemblyFiles.Clone();
            }

            return clone;
        }

        #endregion

        /// <summary>
        /// Creates a setup artuments.
        /// </summary>
        /// <returns></returns>
        internal Executions.ExecutorSetupArgs CreateSetupArgs()
        {
            return new Executions.ExecutorSetupArgs(GetAssemblyNames(), DataGeneratorContextActivator);
        }

        /// <summary>
        /// Gets the assembly names.
        /// </summary>
        /// <returns></returns>
        private AssemblyName[] GetAssemblyNames()
        {
            if (AssemblyFiles== null) { return Array.Empty<AssemblyName>(); }

            AssemblyName[] assemblies = new AssemblyName[AssemblyFiles.Length];

            for (int i = 0; i < AssemblyFiles.Length; ++i)
            {
                assemblies[i] = AssemblyName.GetAssemblyName(AssemblyFiles[i]);
            }

            return assemblies;
        }

    }

}
