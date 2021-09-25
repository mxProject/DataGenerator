using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Provides the functionality needed for fields that generate tuples of multiple values.
    /// </summary>
    public interface IDataGeneratorTupleField
    {

        /// <summary>
        /// Gets the field count.
        /// </summary>
        int FieldCount { get; }

        /// <summary>
        /// Gets the field name.
        /// </summary>
        /// <param name="index">The field index.</param>
        /// <returns></returns>
        string GetFieldName(int index);

        /// <summary>
        /// Gets the value type.
        /// </summary>
        /// <param name="index">The field index.</param>
        /// <returns></returns>
        Type GetValueType(int index);

        /// <summary>
        /// Gets a value that indicates whether it may return a null value.
        /// </summary>
        /// <param name="index">The field index.</param>
        /// <returns></returns>
        bool MayBeNull(int index);

        /// <summary>
        /// Creates an enumeration.
        /// </summary>
        /// <param name="generationCount">Number of values to generate.</param>
        /// <returns></returns>
        ValueTask<IDataGeneratorTupleFieldEnumeration> CreateEnumerationAsync(int generationCount);

    }

}
