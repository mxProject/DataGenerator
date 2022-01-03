using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// DataReader for mapping.
    /// </summary>
    internal sealed class MappingDataReader : IDataReader
    {

        #region ctor

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="reader"></param>
        internal MappingDataReader(IDataReader reader) : this(reader, GetAllFieldIndexes(reader))
        {
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="reorderIndexes"></param>
        internal MappingDataReader(IDataReader reader, MappingFieldIndexInfo[] reorderIndexes)
        {
            static IDictionary<int, int> CreateIndexMapper(IDataReader reader, MappingFieldIndexInfo[] reorderIndexes)
            {
                var dic = new Dictionary<int, int>();

                for (int i = 0; i < reorderIndexes.Length; ++i)
                {
                    dic.Add(i, reorderIndexes[i].FieldIndex);
                }

                return dic;
            }

            static IDictionary<string, (int actual, int ordinal)> CreateNameMapper(IDataReader reader, MappingFieldIndexInfo[] reorderIndexes)
            {
                var dic = new Dictionary<string, (int actual, int index)>();

                for (int i = 0; i < reorderIndexes.Length; ++i)
                {
                    dic.Add(NormalizeName(reorderIndexes[i].MappingName ?? reader.GetName(i)), (reorderIndexes[i].FieldIndex, i));
                }

                return dic;
            }

            static string[] CreateFieldNames(IDataReader reader, MappingFieldIndexInfo[] reorderIndexes)
            {
                string[] names = new string[reorderIndexes.Length];

                for (int i = 0; i < reorderIndexes.Length; ++i)
                {
                    names[i] = reorderIndexes[i].MappingName ?? reader.GetName(i);
                }

                return names;
            }

            m_Reader = reader;
            m_IndexMapper = CreateIndexMapper(reader, reorderIndexes);
            m_NameMapper = CreateNameMapper(reader, reorderIndexes);
            m_FieldNames = CreateFieldNames(reader, reorderIndexes);
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="reorderNames"></param>
        internal MappingDataReader(IDataReader reader, MappingFieldNameInfo[] reorderNames) : this(reader, GetFieldIndexes(reader, reorderNames))
        {
        }

        /// <summary>
        /// Gets the all field indexes.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        static MappingFieldIndexInfo[] GetAllFieldIndexes(IDataReader reader)
        {
            MappingFieldIndexInfo[] indexes = new MappingFieldIndexInfo[reader.FieldCount];

            for (int i = 0; i < reader.FieldCount; ++i)
            {
                indexes[i] = new MappingFieldIndexInfo(i);
            }

            return indexes;
        }

        /// <summary>
        /// Gets the field indexes corresponding to the specified field names.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="reorderNames"></param>
        /// <returns></returns>
        static MappingFieldIndexInfo[] GetFieldIndexes(IDataReader reader, MappingFieldNameInfo[] reorderNames)
        {
            MappingFieldIndexInfo[] indexes = new MappingFieldIndexInfo[reorderNames.Length];

            for (int i = 0; i < reorderNames.Length; ++i)
            {
                indexes[i] = new MappingFieldIndexInfo(reader.GetOrdinal(reorderNames[i].FieldName), reorderNames[i].MappingName);
            }

            return indexes;
        }

        #endregion

        /// <summary>
        /// Normalizes the spesified field name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string NormalizeName(string name)
        {
            return name?.ToLower() ?? "";
        }

        private readonly IDataReader m_Reader;
        private readonly IDictionary<int, int> m_IndexMapper;
        private readonly IDictionary<string, (int actual, int ordinal)> m_NameMapper;
        private readonly string[] m_FieldNames;

        #region field mapping

        /// <summary>
        /// Gets the actual index corresponding to the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetActualIndex(int index)
        {
            if (m_IndexMapper.TryGetValue(index, out int actual)) { return actual; }
            throw new IndexOutOfRangeException();
        }

        /// <summary>
        /// Gets the actual index corresponding to the specified name. 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private int GetActualIndex(string name)
        {
            if (m_NameMapper.TryGetValue(NormalizeName(name), out var index)) { return index.actual; }
            throw new IndexOutOfRangeException();
        }

        /// <summary>
        /// Gets the ordinal index corresponding to the specified name. 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private int GetOrdinalIndex(string name)
        {
            if (m_NameMapper.TryGetValue(NormalizeName(name), out var index)) { return index.ordinal; }
            throw new IndexOutOfRangeException();
        }

        #endregion

        #region IDataReader implementation

        public object this[int i] => m_Reader[GetActualIndex(i)];

        public object this[string name] => m_Reader[GetActualIndex(name)];

        public int Depth => m_Reader.Depth;

        public bool IsClosed => m_Reader.IsClosed;

        public int RecordsAffected => m_Reader.RecordsAffected;

        public int FieldCount => m_IndexMapper.Count;

        public void Close()
        {
            m_Reader.Close();
        }

        public void Dispose()
        {
            m_Reader.Dispose();
        }

        public bool GetBoolean(int i)
        {
            return m_Reader.GetBoolean(GetActualIndex(i));
        }

        public byte GetByte(int i)
        {
            return m_Reader.GetByte(GetActualIndex(i));
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return m_Reader.GetBytes(GetActualIndex(i), fieldOffset, buffer, bufferoffset, length);
        }

        public char GetChar(int i)
        {
            return m_Reader.GetChar(GetActualIndex(i));
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            return m_Reader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
        }

        public IDataReader GetData(int i)
        {
            return m_Reader.GetData(GetActualIndex(i));
        }

        public string GetDataTypeName(int i)
        {
            return m_Reader.GetDataTypeName(GetActualIndex(i));
        }

        public DateTime GetDateTime(int i)
        {
            return m_Reader.GetDateTime(GetActualIndex(i));
        }

        public decimal GetDecimal(int i)
        {
            return m_Reader.GetDecimal(GetActualIndex(i));
        }

        public double GetDouble(int i)
        {
            return m_Reader.GetDouble(GetActualIndex(i));
        }

        public Type GetFieldType(int i)
        {
            var type = m_Reader.GetFieldType(GetActualIndex(i));

            if (type == typeof(StringValue))
            {
                return typeof(string);
            }
            else
            {
                return type;
            }
        }

        public float GetFloat(int i)
        {
            return m_Reader.GetFloat(GetActualIndex(i));
        }

        public Guid GetGuid(int i)
        {
            return m_Reader.GetGuid(GetActualIndex(i));
        }

        public short GetInt16(int i)
        {
            return m_Reader.GetInt16(GetActualIndex(i));
        }

        public int GetInt32(int i)
        {
            return m_Reader.GetInt32(GetActualIndex(i));
        }

        public long GetInt64(int i)
        {
            return m_Reader.GetInt64(GetActualIndex(i));
        }

        public string GetName(int i)
        {
            return m_FieldNames[i];
        }

        public int GetOrdinal(string name)
        {
            return GetOrdinalIndex(name);
        }

        public DataTable GetSchemaTable()
        {
            return m_Reader.GetSchemaTable();
        }

        public string GetString(int i)
        {
            return m_Reader.GetString(GetActualIndex(i));
        }

        public object GetValue(int i)
        {
            var value = m_Reader.GetValue(GetActualIndex(i));

            if (value is StringValue s)
            {
                return s.ToString()!;
            }
            else
            {
                return value;
            }
        }

        public int GetValues(object[] values)
        {
            var count = Math.Min(m_Reader.FieldCount, values.Length);

            for (int i = 0; i < count; ++i)
            {
                values[i] = GetValue(i);
            }

            return count;
        }

        public bool IsDBNull(int i)
        {
            return m_Reader.IsDBNull(GetActualIndex(i));
        }

        public bool NextResult()
        {
            return m_Reader.NextResult();
        }

        public bool Read()
        {
            return m_Reader.Read();
        }

        #endregion

    }

}
