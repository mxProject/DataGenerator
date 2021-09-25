using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace mxProject.Devs.DataGeneration.AdditionalFields
{

    /// <summary>
    /// Field that returns a value generated based on the value generated.
    /// </summary>
    public class DataGeneratorAdditionalField : IDataGeneratorAdditionalField
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="valueType">The type of the field.</param>
        /// <param name="valueGetterCreator">The task that return a method to get the value of the field.</param>
        public DataGeneratorAdditionalField(string fieldName, Type valueType, ValueTask<Func<IDataGenerationRecord, object?>> valueGetterCreator)
        {
            FieldName = fieldName;
            ValueType = valueType;
            m_ValueGetterCreator = valueGetterCreator;
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="valueType">The type of the field.</param>
        /// <param name="valueGetter">The method to get the value of the field.</param>
        public DataGeneratorAdditionalField(string fieldName, Type valueType, Func<IDataGenerationRecord, object?> valueGetter)
        {
            FieldName = fieldName;
            ValueType = valueType;
            m_ValueGetterCreator = new ValueTask<Func<IDataGenerationRecord, object?>>(valueGetter);
        }

        private readonly ValueTask<Func<IDataGenerationRecord, object?>> m_ValueGetterCreator;

        /// <inheritdoc/>
        public string FieldName { get; }

        /// <inheritdoc/>
        public Type ValueType { get; }

        /// <inheritdoc/>
        public ValueTask<Func<IDataGenerationRecord, object?>> CreateValueGetterAsync()
        {
            return m_ValueGetterCreator;
        }

    }

}
