using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Provides the required functionality for an additional tuple field.
    /// </summary>
    public interface IDataGeneratorAdditionalTupleField
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
        /// Creates a method to get the value of the field.
        /// </summary>
        /// <returns></returns>
        ValueTask<Func<IDataGenerationRecord, object?[]>> CreateValueGetterAsync();

    }

}
