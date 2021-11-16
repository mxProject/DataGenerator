using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Provides the functionality needed to activate the context.
    /// </summary>
    public interface IDataGeneratorContextActivator
    {
        /// <summary>
        /// Creates a new context.
        /// </summary>
        /// <returns></returns>
        DataGeneratorContext CreateContext();
    }

}
