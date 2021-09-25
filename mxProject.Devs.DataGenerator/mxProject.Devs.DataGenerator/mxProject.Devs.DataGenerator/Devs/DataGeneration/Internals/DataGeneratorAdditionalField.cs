using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Devs.DataGeneration.Internals
{

    internal class DataGeneratorAdditionalField : IDataGeneratorFieldAccessor
    {

        internal DataGeneratorAdditionalField(IDataGenerationRecord currentRecordaccesor, int fieldIndex, IDataGeneratorFieldInfo fieldInfo, Func<IDataGenerationRecord, object?> valueGetter)
        {
            m_CurrentRecord = currentRecordaccesor;
            m_FieldInfo = fieldInfo;
            m_ValueGetter = valueGetter;
            Index = fieldIndex;
        }

        private readonly IDataGenerationRecord m_CurrentRecord;
        private readonly IDataGeneratorFieldInfo m_FieldInfo;
        private readonly Func<IDataGenerationRecord, object?> m_ValueGetter;

        /// <inheritdoc/>
        public string FieldName
        {
            get { return m_FieldInfo.FieldName; }
        }

        /// <inheritdoc/>
        public Type ValueType
        {
            get { return m_FieldInfo.ValueType; }
        }

        /// <inheritdoc/>
        public int Index { get; }

        /// <inheritdoc/>
        public ValueTask InitializeAsync(int generationCount)
        {
            return default;
        }

        /// <inheritdoc/>
        public bool GenerateNext()
        {
            return true;
        }

        /// <inheritdoc/>
        public void Reset()
        {
        }

        /// <inheritdoc/>
        public object? GetRawValue()
        {
            return m_ValueGetter(m_CurrentRecord);
        }

        /// <inheritdoc/>
        public object? GetValue()
        {
            return DataGeneratorUtility.ConvertFromRawValue(m_ValueGetter(m_CurrentRecord));
        }

        /// <inheritdoc/>
        public bool IsNullValue()
        {
            return (m_ValueGetter(m_CurrentRecord) == null);
        }

    }

}
