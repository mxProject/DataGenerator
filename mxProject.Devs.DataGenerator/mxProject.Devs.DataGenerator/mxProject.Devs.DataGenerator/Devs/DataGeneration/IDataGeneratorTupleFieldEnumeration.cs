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
    public interface IDataGeneratorTupleFieldEnumeration : IDisposable
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
        /// Generates the next new value.
        /// </summary>
        /// <returns></returns>
        bool GenerateNext();

        /// <summary>
        /// Resets the status of data generation processing.
        /// </summary>
        void Reset();

        /// <summary>
        /// Gets the generated value. The value is converted to a well-known type.
        /// </summary>
        /// <param name="index">The field index.</param>
        /// <returns></returns>
        object? GetValue(int index);

        /// <summary>
        /// Gets the generated value.
        /// </summary>
        /// <param name="index">The field index.</param>
        /// <returns></returns>
        object? GetRawValue(int index);

        /// <summary>
        /// Gets a value that indicates whether the generated value is null.
        /// </summary>
        /// <param name="index">The field index.</param>
        /// <returns></returns>
        bool IsNullValue(int index);

        /// <summary>
        /// Populates an array of objects with the generated values.
        /// </summary>
        /// <param name="values"></param>
        void GetValues(object?[] values);

        /// <summary>
        /// Populates a span with the generated values.
        /// </summary>
        /// <param name="values"></param>
        void GetValues(Span<object?> values);

        /// <summary>
        /// Populates a memory with the generated values.
        /// </summary>
        /// <param name="values"></param>
        void GetValues(Memory<object?> values);

    }

}
