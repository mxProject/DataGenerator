using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Threading;

namespace mxProject.Devs.DataGeneration.DataReaders
{

    internal class DataGenerationDataRecord : IDataGenerationRecord
    {
        internal DataGenerationDataRecord(DataGenerator generator)
        {
            m_Generator = generator;
        }

        private readonly DataGenerator m_Generator;

        /// <inheritdoc/>
        public object? this[int i] => GetValue(i);

        /// <inheritdoc/>
        public object? this[string name] => GetValue(GetOrdinal(name));

        /// <inheritdoc/>
        public int FieldCount => m_Generator.FieldCount;

        /// <inheritdoc/>
        public bool GetBoolean(int i)
        {
            return Convert.ToBoolean(GetValue(i));
        }

        /// <inheritdoc/>
        public bool GetBoolean(string fieldName)
        {
            return GetBoolean(GetOrdinal(fieldName));
        }

        /// <inheritdoc/>
        public byte GetByte(int i)
        {
            return Convert.ToByte(GetValue(i));
        }

        /// <inheritdoc/>
        public byte GetByte(string fieldName)
        {
            return GetByte(GetOrdinal(fieldName));
        }

        /// <summary>
        /// <inheritdoc/>. This class does not support this method.
        /// </summary>
        /// <exception cref="NotSupportedException">
        /// </exception>
        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public char GetChar(int i)
        {
            return Convert.ToChar(GetValue(i));
        }

        /// <inheritdoc/>
        public char GetChar(string fieldName)
        {
            return GetChar(GetOrdinal(fieldName));
        }

        /// <summary>
        /// <inheritdoc/>. This class does not support this method.
        /// </summary>
        /// <exception cref="NotSupportedException">
        /// </exception>
        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// <inheritdoc/>. This class does not support this method.
        /// </summary>
        /// <exception cref="NotSupportedException">
        /// </exception>
        public IDataReader GetData(int i)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public string GetDataTypeName(int i)
        {
            return m_Generator.GetValueType(i).Name;
        }

        /// <inheritdoc/>
        public DateTime GetDateTime(int i)
        {
            return Convert.ToDateTime(GetValue(i));
        }

        /// <inheritdoc/>
        public DateTime GetDateTime(string fieldName)
        {
            return GetDateTime(GetOrdinal(fieldName));
        }

        /// <inheritdoc/>
        public decimal GetDecimal(int i)
        {
            return Convert.ToDecimal(GetValue(i));
        }

        /// <inheritdoc/>
        public decimal GetDecimal(string fieldName)
        {
            return GetDecimal(GetOrdinal(fieldName));
        }

        /// <inheritdoc/>
        public double GetDouble(int i)
        {
            return Convert.ToDouble(GetValue(i));
        }

        /// <inheritdoc/>
        public double GetDouble(string fieldName)
        {
            return GetDouble(GetOrdinal(fieldName));
        }

        /// <inheritdoc/>
        public Type GetFieldType(int i)
        {
            return m_Generator.GetValueType(i);
        }

        /// <inheritdoc/>
        public float GetFloat(int i)
        {
            return Convert.ToSingle(GetValue(i));
        }

        /// <inheritdoc/>
        public float GetFloat(string fieldName)
        {
            return GetFloat(GetOrdinal(fieldName));
        }

        /// <inheritdoc/>
        public Guid GetGuid(int i)
        {
            return Guid.Parse(Convert.ToString(GetValue(i)));
        }

        /// <inheritdoc/>
        public Guid GetGuid(string fieldName)
        {
            return GetGuid(GetOrdinal(fieldName));
        }

        /// <inheritdoc/>
        public short GetInt16(int i)
        {
            return Convert.ToInt16(GetValue(i));
        }

        /// <inheritdoc/>
        public short GetInt16(string fieldName)
        {
            return GetInt16(GetOrdinal(fieldName));
        }

        /// <inheritdoc/>
        public int GetInt32(int i)
        {
            return Convert.ToInt32(GetValue(i));
        }

        /// <inheritdoc/>
        public int GetInt32(string fieldName)
        {
            return GetInt32(GetOrdinal(fieldName));
        }

        /// <inheritdoc/>
        public long GetInt64(int i)
        {
            return Convert.ToInt64(GetValue(i));
        }

        /// <inheritdoc/>
        public long GetInt64(string fieldName)
        {
            return GetInt64(GetOrdinal(fieldName));
        }

        /// <inheritdoc/>
        public string GetName(int i)
        {
            return m_Generator.GetFieldName(i);
        }

        /// <inheritdoc/>
        public int GetOrdinal(string name)
        {
            return m_Generator.GetFieldIndex(name);
        }

        /// <inheritdoc/>
        public string GetString(int i)
        {
            var value = GetValue(i);
            if (value == null) { return null!; }
            return Convert.ToString(value);
        }

        /// <inheritdoc/>
        public string GetString(string fieldName)
        {
            return GetString(GetOrdinal(fieldName));
        }

        /// <inheritdoc/>
        public object? GetValue(int i)
        {
            return m_Generator.GetFieldValue(i);
        }

        /// <inheritdoc/>
        public object? GetValue(string fieldName)
        {
            return GetValue(GetOrdinal(fieldName));
        }

        /// <inheritdoc/>
        public T? GetRawValue<T>(int index)
            where T : struct
        {
            // object? value = DataGeneratorUtility.ConvertToRawValue(GetValue(index));
            object? value = m_Generator.GetFieldRawValue(index);

            if (value == null) { return null; }

            return (T)value;
        }

        /// <inheritdoc/>
        public T? GetRawValue<T>(string fieldName)
            where T : struct
        {
            return GetRawValue<T>(GetOrdinal(fieldName));
        }

        /// <inheritdoc/>
        public int GetValues(object?[] values)
        {
            int count = Math.Min(values.Length, m_Generator.FieldCount);

            for (int i = 0; i < count; ++i)
            {
                values[i] = GetValue(i);
            }

            return count;
        }

        /// <inheritdoc/>
        public bool IsDBNull(int i)
        {
            return m_Generator.GetFieldValueIsNull(i);
        }

        /// <inheritdoc/>
        public bool IsDBNull(string fieldName)
        {
            return IsDBNull(GetOrdinal(fieldName));
        }

    }

}
