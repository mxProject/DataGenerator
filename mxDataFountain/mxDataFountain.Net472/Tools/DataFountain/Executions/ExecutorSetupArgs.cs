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
    /// Setup arguments.
    /// </summary>
    [Serializable]
    internal class ExecutorSetupArgs
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="assemblies"></param>
        /// <param name="contextActivatorTypeName"></param>
        internal ExecutorSetupArgs(AssemblyName[]? assemblies = null, string? contextActivatorTypeName = null)
        {
            Assemblies = assemblies;
            ContextActivatorTypeName = contextActivatorTypeName;
        }

        /// <summary>
        /// Gets the names of the assembly to load.
        /// </summary>
        internal AssemblyName[]? Assemblies { get; }

        /// <summary>
        /// Gets the activator type name that creates the generator context.
        /// </summary>
        internal string? ContextActivatorTypeName { get; }

    }

}
