using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Buffers;
using System.Runtime.InteropServices.ComTypes;
using System.Reflection;
using System.Data;
using System.Threading.Tasks;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// DataGenerator.
    /// </summary>
    public class DataGenerator : IDisposable
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="fields"></param>
        internal DataGenerator(List<IDataGeneratorFieldAccessor> fields)
        {
            m_Fields = fields;
            m_FieldNameAndIndexes = GetFieldNameAndIndexes(fields);
            m_CurrentRecordAccessor = new DataReaders.DataGenerationDataRecord(this);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the resources it is using.
        /// </summary>
        /// <param name="disposing">A value that indicates whether it was called from the dispose method.</param>
        protected virtual void Dispose(bool disposing)
        {
        }

        #region fields

        private readonly List<IDataGeneratorFieldAccessor> m_Fields;

        private readonly IDictionary<string, int> m_FieldNameAndIndexes;

        /// <summary>
        /// Normalizes the specified name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static string NormalizeFieldName(string name)
        {
            if (name == null) { return ""; }
            return name.ToLower();
        }

        /// <summary>
        /// Gets the combinations of field name and field index.
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        private static IDictionary<string, int> GetFieldNameAndIndexes(IList<IDataGeneratorFieldAccessor> fields)
        {
            Dictionary<string, int> dic = new();

            for (int i = 0; i < fields.Count; ++i)
            {
                string name = NormalizeFieldName(fields[i].FieldName);

                if (!dic.ContainsKey(name))
                {
                    dic.Add(name, i);
                }
            }

            return dic;
        }

        /// <summary>
        /// Gets the field count.
        /// </summary>
        public int FieldCount
        {
            get { return m_Fields.Count; }
        }

        /// <summary>
        /// Gets the name of the specified field.
        /// </summary>
        /// <param name="index">The field index.</param>
        /// <returns></returns>
        public string GetFieldName(int index)
        {
            return m_Fields[index].FieldName;
        }

        /// <summary>
        /// Gets the value type of the specified field.
        /// </summary>
        /// <param name="index">The field index.</param>
        /// <returns></returns>
        public Type GetValueType(int index)
        {
            return m_Fields[index].ValueType;
        }

        /// <summary>
        /// Gets the index of the specified field name.
        /// </summary>
        /// <param name="name">The field name.</param>
        /// <returns></returns>
        public int GetFieldIndex(string name)
        {
            if (m_FieldNameAndIndexes.TryGetValue(NormalizeFieldName(name), out int index))
            {
                return index;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Gets the index of the specified field name. Tf not found,, throw an exception.
        /// </summary>
        /// <exception cref="KeyNotFoundException">
        /// The specified field is not found.
        /// </exception>
        private int GetFieldIndexIfNotFoundThrowException(string name)
        {
            int index = GetFieldIndex(name);

            if (index < 0)
            {
                throw new KeyNotFoundException("The specified field is not found.");
            }

            return index;
        }

        #endregion

        #region additional field

        private readonly IDataGenerationRecord m_CurrentRecordAccessor;

        /// <summary>
        /// Adds the specified field.
        /// </summary>
        /// <param name="fieldInfo">The field information.</param>
        /// <param name="valueGetter">The method to get the value of the field.</param>
        internal void AddAdditionalField(IDataGeneratorFieldInfo fieldInfo, Func<IDataGenerationRecord, object?> valueGetter)
        {
            AssertFieldName(fieldInfo.FieldName);

            var field = new Internals.DataGeneratorAdditionalField(m_CurrentRecordAccessor, m_Fields.Count, fieldInfo, valueGetter);

            m_Fields.Add(field);
            m_FieldNameAndIndexes.Add(NormalizeFieldName(fieldInfo.FieldName), field.Index);
        }

        /// <summary>
        /// Asserts the specified field name.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        private void AssertFieldName(string? fieldName)
        {
            if (fieldName == null)
            {
                throw new NullReferenceException("The field name is null.");
            }

            if (m_FieldNameAndIndexes.ContainsKey(NormalizeFieldName(fieldName)))
            {
                throw new DuplicateNameException($"The field name is already registered. Name: '{fieldName}'");
            }
        }

        #endregion

        #region field order

        /// <summary>
        /// Sort the order of the fields.
        /// </summary>
        /// <param name="fieldNameComparison">The method to compare field names.</param>
        internal void SortFieldOrder(Comparison<string> fieldNameComparison)
        {
            m_Fields.Sort((x, y) =>
            {
                return fieldNameComparison(x.FieldName, y.FieldName);
            });

            for (int i = 0; i < m_Fields.Count; ++i)
            {
                m_FieldNameAndIndexes[NormalizeFieldName(m_Fields[i].FieldName)] = i;
            }
        }

        #endregion

        #region gets value

        /// <summary>
        /// Gets the value of the specified field. The value is converted to a well-known type.
        /// </summary>
        /// <param name="index">The field index.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// This generator is already EOF. 
        /// </exception>
        public object? GetFieldValue(int index)
        {
            ThrowExceptionIfEof();
            return m_Fields[index].GetValue();
        }

        /// <summary>
        /// Gets the value of the specified field.
        /// </summary>
        /// <param name="index">The field index.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// This generator is already EOF. 
        /// </exception>
        public object? GetFieldRawValue(int index)
        {
            ThrowExceptionIfEof();
            return m_Fields[index].GetRawValue();
        }

        /// <summary>
        /// Gets a value that indicates whether the value of the specified field is null.
        /// </summary>
        /// <param name="index">The field index.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// This generator is already EOF. 
        /// </exception>
        public bool GetFieldValueIsNull(int index)
        {
            ThrowExceptionIfEof();
            return m_Fields[index].IsNullValue();
        }


        /// <summary>
        /// Gets the value of the specified field. The value is converted to a well-known type.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// This generator is already EOF. 
        /// </exception>
        /// <exception cref="KeyNotFoundException">
        /// The specified field is not found.
        /// </exception>
        public object? GetFieldValue(string fieldName)
        {
            int index = GetFieldIndexIfNotFoundThrowException(fieldName);
            return GetFieldValue(index);
        }

        /// <summary>
        /// Gets the value of the specified field.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// This generator is already EOF. 
        /// </exception>
        /// <exception cref="KeyNotFoundException">
        /// The specified field is not found.
        /// </exception>
        public object? GetFieldRawValue(string fieldName)
        {
            int index = GetFieldIndexIfNotFoundThrowException(fieldName);
            return GetFieldRawValue(index);
        }

        /// <summary>
        /// Gets a value that indicates whether the value of the specified field is null.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// This generator is already EOF. 
        /// <exception cref="KeyNotFoundException">
        /// The specified field is not found.
        /// </exception>
        /// </exception>
        public bool GetFieldValueIsNull(string fieldName)
        {
            int index = GetFieldIndexIfNotFoundThrowException(fieldName);
            return GetFieldValueIsNull(index);
        }

        #endregion

        #region generates value

        private bool m_Eof = false;

        /// <summary>
        /// Generates the next new value.
        /// </summary>
        /// <returns></returns>
        public bool GenerateNext()
        {
            if (m_Eof) { return false; }

            foreach (var field in m_Fields)
            {
                if (field.Index != 0) { continue; }

                if (!field.GenerateNext())
                {
                    m_Eof = true;
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Tf this instance is EOF, throw an exception.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// This generator is already EOF. 
        /// </exception>
        private void ThrowExceptionIfEof()
        {
            if (m_Eof)
            {
                throw new InvalidOperationException("This generator is already EOF.");
            }
        }

        /// <summary>
        /// Resets the status of data generation processing.
        /// </summary>
        public void Reset()
        {
            foreach (var field in m_Fields)
            {
                if (field.Index != 0) { continue; }
                field.Reset();
            }

            m_Eof = false;
        }

        #endregion

        #region DataReader

        /// <summary>
        /// Wrap as a DataReader.
        /// </summary>
        /// <returns></returns>
        public IDataGenerationReader AsDataReader()
        {
            return new DataReaders.DataGenerationDataReader(this, true);
        }

        #endregion

    }

}
