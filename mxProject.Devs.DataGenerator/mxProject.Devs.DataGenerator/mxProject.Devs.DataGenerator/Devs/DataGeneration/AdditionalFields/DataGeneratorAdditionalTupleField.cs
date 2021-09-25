using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace mxProject.Devs.DataGeneration.AdditionalFields
{

    /// <summary>
    /// Field that returns values generated based on the value generated.
    /// </summary>
    public class DataGeneratorAdditionalTupleField : IDataGeneratorAdditionalTupleField
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="fields">The fields.</param>
        /// <param name="valueGetterCreator">The task that return a method to get the value of the field.</param>
        public DataGeneratorAdditionalTupleField(IDataGeneratorFieldInfo[] fields, ValueTask<Func<IDataGenerationRecord, object?[]>> valueGetterCreator)
        {
            m_Fields = fields;
            m_ValueGetterCreator = valueGetterCreator;
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="fields">The fields.</param>
        /// <param name="valueGetter">The method to get the value of the field.</param>
        public DataGeneratorAdditionalTupleField(IDataGeneratorFieldInfo[] fields, Func<IDataGenerationRecord, object?[]> valueGetter)
        {
            m_Fields = fields;
            m_ValueGetterCreator = new ValueTask<Func<IDataGenerationRecord, object?[]>>(valueGetter);
        }

        private readonly IDataGeneratorFieldInfo[] m_Fields;
        private readonly ValueTask<Func<IDataGenerationRecord, object?[]>> m_ValueGetterCreator;

        /// <inheritdoc/>
        public int FieldCount
        {
            get { return m_Fields.Length; }
        }

        /// <inheritdoc/>
        public string GetFieldName(int index)
        {
            return m_Fields[index].FieldName;
        }

        /// <inheritdoc/>
        public Type GetValueType(int index)
        {
            return m_Fields[index].ValueType;
        }

        /// <inheritdoc/>
        public ValueTask<Func<IDataGenerationRecord, object?[]>> CreateValueGetterAsync()
        {
            return m_ValueGetterCreator;
        }

    }

}
