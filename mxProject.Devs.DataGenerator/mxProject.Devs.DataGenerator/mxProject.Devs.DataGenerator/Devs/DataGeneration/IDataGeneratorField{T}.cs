using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Provides the required functionality for a data generator field.
    /// </summary>
    public interface IDataGeneratorField<T> : IDataGeneratorField where T : struct
    {

        /// <summary>
        /// Creates an enumeration.
        /// </summary>
        /// <param name="generationCount">Number of values to generate.</param>
        /// <returns></returns>
        ValueTask<IDataGeneratorFieldEnumeration<T>> CreateTypedEnumerationAsync(int generationCount);

    }

}
