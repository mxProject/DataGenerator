#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace mxProject.Tools.DataFountain.Executions
{

    /// <summary>
    /// Executor proxy.
    /// </summary>
    internal class ExecutorProxy : IExecutor
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="args"></param>
        internal ExecutorProxy(ExecutorSetupArgs args)
        {
            m_Args = args;

            Setup();
        }

        private readonly ExecutorSetupArgs m_Args;
        private AppDomain m_ExecutionDomain = null!;
        private IExecutor m_Executor = null!;
        private bool m_IsDisposed;

        /// <inheritdoc/>
        public void Dispose()
        {
            if (m_IsDisposed) { return; }

            Unload();

            m_IsDisposed = true;
        }

        private void Unload()
        {
            try
            {
                m_Executor?.Dispose();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            if (m_ExecutionDomain != null)
            {
                try
                {
                    AppDomain.Unload(m_ExecutionDomain);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }

                m_ExecutionDomain = null!;
            }
        }

        #region setup

        private void Setup()
        {
            m_ExecutionDomain = AppDomain.CreateDomain(Guid.NewGuid().ToString());
            m_Executor = Executor.UseAnotherDomain(m_ExecutionDomain, m_Args);
        }

        private void Reset()
        {
            Unload();
            Setup();
        }

        void IExecutor.Setup(ExecutorSetupArgs args)
        {
            throw new InvalidOperationException();
        }

        #endregion

        #region validation

        /// <inheritdoc/>
        public bool ValidateAsValueTypeName(string valueTypeName, out string? invalidMessage)
        {
            var result = ExecuteFunc(e =>
            {
                var valid = e.ValidateAsValueTypeName(valueTypeName, out var message);

                return (valid, message);
            });

            invalidMessage = result.message;
            return result.valid;
        }

        /// <inheritdoc/>
        public bool IsEnumType(string valueTypeName)
        {
            return ExecuteFunc(e => e.IsEnumType(valueTypeName));
        }

        /// <inheritdoc/>
        public bool ValidateAsFieldValue(string text, string valueTypeName, out string? invalidMessage)
        {
            var result = ExecuteFunc(e =>
            {
                var valid = e.ValidateAsFieldValue(text, valueTypeName, out var message);

                return (valid, message);
            });

            invalidMessage = result.message;
            return result.valid;
        }

        #endregion

        #region generation

        /// <inheritdoc/>
        public void ShowPreview(string generatorSettingsJson, int? generatingCount)
        {
            ExecuteAction(e => e.ShowPreview(generatorSettingsJson, generatingCount));
        }

        /// <inheritdoc/>
        public void OutputCsv(string generatorSettingsJson, Configurations.CsvSettings csvSettings)
        {
            ExecuteAction(e => e.OutputCsv(generatorSettingsJson, csvSettings));
        }

        #endregion

        #region invoke

        private void ExecuteAction(Action<IExecutor> action)
        {
            ExecuteAction(action, false);
        }

        private void ExecuteAction(Action<IExecutor> action, bool needRetry)
        {
            try
            {
                action(m_Executor);
            }
            catch (System.Runtime.Remoting.RemotingException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

                if (needRetry)
                {
                    Reset();
                    ExecuteAction(action, false);
                }
                else
                {
                    throw;
                }
            }
        }

        private T ExecuteFunc<T>(Func<IExecutor, T> func)
        {
            return ExecuteFunc(func, false);
        }

        private T ExecuteFunc<T>(Func<IExecutor, T> func, bool needRetry)
        {
            try
            {
                return func(m_Executor);
            }
            catch (System.Runtime.Remoting.RemotingException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

                if (needRetry)
                {
                    Reset();
                    return ExecuteFunc(func, false);
                }
                else
                {
                    throw;
                }
            }
        }

        #endregion

    }

}
