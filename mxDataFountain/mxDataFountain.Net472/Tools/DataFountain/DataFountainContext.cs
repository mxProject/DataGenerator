#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePipe;
using Microsoft.Extensions.DependencyInjection;

using mxProject.Devs.DataGeneration;
using mxProject.Tools.DataFountain.Messaging;
using mxProject.Tools.DataFountain.Models;
using mxProject.Tools.DataFountain.Executions;

namespace mxProject.Tools.DataFountain
{

    /// <summary>
    /// Context for managing the state of this application.
    /// </summary>
    internal class DataFountainContext : IDisposable
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="serviceProvider"></param>
        internal DataFountainContext(ServiceProvider serviceProvider)
        {
            m_ServiceProvider = serviceProvider;

            FieldEventPublisher = CreateMessagePublisher<DataGeneratorFieldEvent, IDataGeneratorFieldSettingsState>();
            FieldEventSubscriber = CreateMessageSubscriber<DataGeneratorFieldEvent, IDataGeneratorFieldSettingsState>();
        }

        private readonly ServiceProvider m_ServiceProvider;

        #region dispose

        public void Dispose()
        {
            m_CurrentExecutor?.Dispose();
        }

        #endregion

        #region messaging

        /// <summary>
        /// Creates a message publisher for the specified type.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TMessage"></typeparam>
        /// <returns></returns>
        internal IPublisher<TKey, TMessage> CreateMessagePublisher<TKey, TMessage>()
            where TKey : notnull
        {
            return m_ServiceProvider.GetRequiredService<IPublisher<TKey, TMessage>>();
        }

        /// <summary>
        /// Creates a message subscriber for the specified type.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TMessage"></typeparam>
        /// <returns></returns>
        internal ISubscriber<TKey, TMessage> CreateMessageSubscriber<TKey, TMessage>()
            where TKey : notnull
        {
            return m_ServiceProvider.GetRequiredService<ISubscriber<TKey, TMessage>>();
        }

        /// <summary>
        /// Gets the publisher of the event associated with the field.
        /// </summary>
        internal IPublisher<DataGeneratorFieldEvent, IDataGeneratorFieldSettingsState> FieldEventPublisher { get; }

        /// <summary>
        /// Gets the subscriber of the event associated with the field.
        /// </summary>
        internal ISubscriber<DataGeneratorFieldEvent, IDataGeneratorFieldSettingsState> FieldEventSubscriber { get; }

        #endregion

        #region value types

        /// <summary>
        /// Gets the value types supported by the specified field type.
        /// </summary>
        /// <param name="fieldType">The field type.</param>
        /// <returns></returns>
        internal Type[] GetSupportedValueTypes(DataGeneratorFieldType fieldType)
        {
            return fieldType switch
            {
                DataGeneratorFieldType.Any => GetDefaultValueTypes(),
                DataGeneratorFieldType.Each => GetDefaultValueTypes(),
                DataGeneratorFieldType.Expression => GetDefaultValueTypes(),
                DataGeneratorFieldType.Random => GetRandomValueTypes(),
                DataGeneratorFieldType.Sequence => GetSequenceValueTypes(),
                _ => Type.EmptyTypes
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal static Type[] GetDefaultValueTypes()
        {
            return new Type[]
            {
                typeof(bool),
                typeof(byte),
                typeof(short),
                typeof(int),
                typeof(long),
                typeof(float),
                typeof(double),
                typeof(decimal),
                typeof(DateTime),
                typeof(DateTimeOffset),
                typeof(TimeSpan),
                typeof(char),
                typeof(string),
                typeof(Guid),
                typeof(sbyte),
                typeof(ushort),
                typeof(uint),
                typeof(ulong),
            };
        }

        internal static Type[] GetRandomValueTypes()
        {
            return new Type[]
            {
                typeof(bool),
                typeof(byte),
                typeof(short),
                typeof(int),
                typeof(long),
                typeof(float),
                typeof(double),
                typeof(decimal),
                typeof(DateTime),
                typeof(DateTimeOffset),
                typeof(TimeSpan),
                typeof(Guid),
                typeof(sbyte),
                typeof(ushort),
                typeof(uint),
                typeof(ulong),
            };
        }

        internal static Type[] GetSequenceValueTypes()
        {
            return new Type[]
            {
                typeof(byte),
                typeof(short),
                typeof(int),
                typeof(long),
                typeof(DateTime),
                typeof(DateTimeOffset),
                typeof(TimeSpan),
                typeof(sbyte),
                typeof(ushort),
                typeof(uint),
                typeof(ulong),
            };
        }

        #endregion

        #region executor

        /// <summary>
        /// Gets the executor.
        /// </summary>
        internal IExecutor CurrentExecutor
        {
            get { return m_CurrentExecutor; }
            private set
            {
                if (m_CurrentExecutor == value) { return; }
                m_CurrentExecutor?.Dispose();
                m_CurrentExecutor = value;
            }
        }
        private IExecutor m_CurrentExecutor = Executor.Default;

        /// <summary>
        /// Setup the executor.
        /// </summary>
        /// <param name="args"></param>
        internal void SetupExecutor(ExecutorSetupArgs? args = null)
        {
            static bool UseProxy(ExecutorSetupArgs? args)
            {
                if (args == null) { return false; }
                if (!string.IsNullOrEmpty(args.ContextActivatorTypeName)) { return true; }
                if (args.Assemblies != null && args.Assemblies.Length > 0) { return true; }

                return false;
            }

            if (UseProxy(args))
            {
                CurrentExecutor = new ExecutorProxy(args!);
            }
            else
            {
                CurrentExecutor = Executor.Default;
            }
        }

        #endregion

    }

}
