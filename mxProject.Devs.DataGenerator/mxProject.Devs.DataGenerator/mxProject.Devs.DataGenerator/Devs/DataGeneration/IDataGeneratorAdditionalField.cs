using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Provides the required functionality for an additional field.
    /// </summary>
    public interface IDataGeneratorAdditionalField
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
        /// Creates a method to get the value of the field.
        /// </summary>
        /// <returns></returns>
        ValueTask<Func<IDataGenerationRecord, object?>> CreateValueGetterAsync();

    }

}
