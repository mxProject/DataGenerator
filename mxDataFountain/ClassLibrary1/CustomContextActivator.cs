using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using mxProject.Devs.DataGeneration;

namespace ClassLibrary1
{

    /// <summary>
    /// Implementation sample of IDataGeneratorContextActivator interface.
    /// </summary>
    /// <remarks>
    /// To customize the activation of an instance of the DataGeneratorContext class, define a class that implements the IDataGeneratorContextActivator interface.
    /// Then set the name of that type to DataGeneratorContextActivator property of ExecutorSettings class.
    /// </remarks>
    internal class CustomContextActivator : IDataGeneratorContextActivator
    {
        /// <inheritdoc/>
        public DataGeneratorContext CreateContext()
        {
            Trace.WriteLine($"{nameof(CustomContextActivator)}.{nameof(CreateContext)} method has been called.");

            return new DataGeneratorContext(
                cSharpScriptGlobalObject: CustomScriptingHelper.Instance,
                stringConverter: CustomStringConverter.Instance
                );
        }
    }

}
