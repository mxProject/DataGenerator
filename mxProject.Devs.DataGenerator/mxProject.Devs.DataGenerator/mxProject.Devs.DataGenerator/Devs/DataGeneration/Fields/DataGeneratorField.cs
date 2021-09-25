using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Devs.DataGeneration.Fields
{

    /// <summary>
    /// Basic implementation of a field.
    /// </summary>
    public class DataGeneratorField : IDataGeneratorField
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="valueType">The value type.</param>
        /// <param name="enumerateValueCount">Number of values that will be enumerated.</param>
        /// <param name="mayBeNull">A value that indicates whether it may return a null value.</param>
        /// <param name="enumerationCreator">The method to generate an enumeration.</param>
        public DataGeneratorField(string fieldName, Type valueType, int? enumerateValueCount, bool mayBeNull, EnumerationCreator enumerationCreator)
        {
            FieldName = fieldName;
            ValueType = valueType;
            MayBeNull = mayBeNull;
            m_EnumerateValueCount = enumerateValueCount;
            m_EnumerationCreator = enumerationCreator;
        }

        private readonly int? m_EnumerateValueCount;
        private readonly EnumerationCreator m_EnumerationCreator;


        /// <inheritdoc/>
        public string FieldName { get; }

        /// <inheritdoc/>
        public Type ValueType { get; }

        /// <inheritdoc/>
        public bool IsFixedLength { get => m_EnumerateValueCount.HasValue; }

        /// <inheritdoc/>
        public bool MayBeNull { get; }

        /// <inheritdoc/>
        public int? GetEnumerateValueCount()
        {
            return m_EnumerateValueCount;
        }

        /// <inheritdoc/>
        public async ValueTask<IDataGeneratorFieldEnumeration> CreateEnumerationAsync(int generateCount)
        {
            return new DataGeneratorFieldEnumeration(this, await m_EnumerationCreator(generateCount));
        }

    }

}
