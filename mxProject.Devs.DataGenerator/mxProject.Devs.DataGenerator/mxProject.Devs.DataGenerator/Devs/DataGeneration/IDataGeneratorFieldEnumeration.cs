using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Provides the required functionality for a data generator field.
    /// </summary>
    public interface IDataGeneratorFieldEnumeration : IDisposable
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
        /// <returns></returns>
        object? GetValue();

        /// <summary>
        /// Gets the generated value.
        /// </summary>
        /// <returns></returns>
        object? GetRawValue();

        /// <summary>
        /// Gets a value that indicates whether the generated value is null.
        /// </summary>
        /// <returns></returns>
        bool IsNullValue();

    }

}
