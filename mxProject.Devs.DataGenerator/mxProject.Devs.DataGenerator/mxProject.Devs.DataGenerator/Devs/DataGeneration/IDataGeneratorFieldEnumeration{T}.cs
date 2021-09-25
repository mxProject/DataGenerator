using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Provides the required functionality for a data generator field.
    /// </summary>
    /// <typeparam name="T">The type of value to generate.</typeparam>
    public interface IDataGeneratorFieldEnumeration<T> : IDataGeneratorFieldEnumeration where T : struct
    {

        /// <summary>
        /// Get the generated value.
        /// </summary>
        /// <returns></returns>
        T? GetTypedValue();

    }

}
