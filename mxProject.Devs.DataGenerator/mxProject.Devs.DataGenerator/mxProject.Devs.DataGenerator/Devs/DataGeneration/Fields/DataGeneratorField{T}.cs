using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Devs.DataGeneration.Fields
{

    /// <summary>
    /// Basic implementation of a field.
    /// </summary>
    /// <typeparam name="T">The value type of the field.</typeparam>
    public class DataGeneratorField<T> : IDataGeneratorField<T> where T : struct
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="enumerateValueCount">Number of values that will be enumerated.</param>
        /// <param name="mayBeNull">A value that indicates whether it may return a null value.</param>
        /// <param name="enumerationCreator">The method to generate an enumeration.</param>
        public DataGeneratorField(string fieldName, int? enumerateValueCount, bool mayBeNull, EnumerationCreator<T> enumerationCreator)
        {
            FieldName = fieldName;
            MayBeNull = mayBeNull;
            m_EnumerateValueCount = enumerateValueCount;
            m_EnumerationCreator = enumerationCreator;
        }

        private readonly int? m_EnumerateValueCount;
        private readonly EnumerationCreator<T> m_EnumerationCreator;


        /// <inheritdoc/>
        public string FieldName { get; }

        /// <inheritdoc/>
        public Type ValueType { get => typeof(T); }

        /// <inheritdoc/>
        public bool IsFixedLength { get => m_EnumerateValueCount.HasValue; }

        /// <inheritdoc/>
        public bool MayBeNull { get; }

        /// <inheritdoc/>
        public int? GetEnumerateValueCount()
        {
            return m_EnumerateValueCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="generationCount"></param>
        /// <returns></returns>
        public async ValueTask<IDataGeneratorFieldEnumeration<T>> CreateEnumerationAsync(int generationCount)
        {
            return new DataGeneratorFieldEnumeration<T>(this, await m_EnumerationCreator(generationCount).ConfigureAwait(false));
        }

        /// <inheritdoc/>
        ValueTask<IDataGeneratorFieldEnumeration<T>> IDataGeneratorField<T>.CreateTypedEnumerationAsync(int generationCount)
        {
            return CreateEnumerationAsync(generationCount);
        }

        /// <inheritdoc/>
        async ValueTask<IDataGeneratorFieldEnumeration> IDataGeneratorField.CreateEnumerationAsync(int generationCount)
        {
            return await CreateEnumerationAsync(generationCount).ConfigureAwait(false);
        }

    }

}
