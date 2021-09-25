using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Provides the required functionality for a data generator field.
    /// </summary>
    public interface IDataGeneratorField
    {

        /// <summary>
        /// Gets the field name.
        /// </summary>
        string FieldName { get; }

        /// <summary>
        /// Gets the value type.
        /// </summary>
        Type ValueType { get; }

        /// <summary>
        /// Gets a value that indicates whether the number of values to generate is fixed.
        /// </summary>
        bool IsFixedLength { get; }

        /// <summary>
        /// Gets the number of values to generate.
        /// </summary>
        /// <returns>Returns null if the number of values to generate is not fixed.</returns>
        int? GetEnumerateValueCount();

        /// <summary>
        /// Gets a value that indicates whether it may return a null value.
        /// </summary>
        bool MayBeNull { get; }

        /// <summary>
        /// Creates an enumeration.
        /// </summary>
        /// <param name="generationCount">Number of values to generate.</param>
        /// <returns></returns>
        ValueTask<IDataGeneratorFieldEnumeration> CreateEnumerationAsync(int generationCount);

    }

}
