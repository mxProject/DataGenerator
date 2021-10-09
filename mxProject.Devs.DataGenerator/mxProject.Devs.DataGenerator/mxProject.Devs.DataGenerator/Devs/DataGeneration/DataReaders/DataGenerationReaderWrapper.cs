using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace mxProject.Devs.DataGeneration.DataReaders
{
    internal class DataGenerationReaderWrapper : IDataGenerationReader
    {
        internal DataGenerationReaderWrapper(IDataReader dataReader)
        {
            m_DataReader = dataReader;
        }

        private readonly IDataReader m_DataReader;

        public object this[int i] => m_DataReader[i];

        public object this[string name] => m_DataReader[name];

        public int Depth => m_DataReader.Depth;

        public bool IsClosed => m_DataReader.IsClosed;

        public int RecordsAffected => m_DataReader.RecordsAffected;

        public int FieldCount => m_DataReader.FieldCount;

        public void Close()
        {
            m_DataReader.Close();
        }

        public void Dispose()
        {
            m_DataReader.Dispose();
        }

        public bool GetBoolean(string fieldName)
        {
            return m_DataReader.GetBoolean(fieldName);
        }

        public bool GetBoolean(int i)
        {
            return m_DataReader.GetBoolean(i);
        }

        public byte GetByte(string fieldName)
        {
            return m_DataReader.GetByte(fieldName);
        }

        public byte GetByte(int i)
        {
            return m_DataReader.GetByte(i);
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return m_DataReader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
        }

        public char GetChar(string fieldName)
        {
            return m_DataReader.GetChar(fieldName);
        }

        public char GetChar(int i)
        {
            return m_DataReader.GetChar(i);
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            return m_DataReader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
        }

        public IDataReader GetData(int i)
        {
            return m_DataReader.GetData(i);
        }

        public string GetDataTypeName(int i)
        {
            return m_DataReader.GetDataTypeName(i);
        }

        public DateTime GetDateTime(string fieldName)
        {
            return m_DataReader.GetDateTime(fieldName);
        }

        public DateTime GetDateTime(int i)
        {
            return m_DataReader.GetDateTime(i);
        }

        public decimal GetDecimal(string fieldName)
        {
            return m_DataReader.GetDecimal(fieldName);
        }

        public decimal GetDecimal(int i)
        {
            return m_DataReader.GetDecimal(i);
        }

        public double GetDouble(string fieldName)
        {
            return m_DataReader.GetDouble(fieldName);
        }

        public double GetDouble(int i)
        {
            return m_DataReader.GetDouble(i);
        }

        public Type GetFieldType(int i)
        {
            return m_DataReader.GetFieldType(i);
        }

        public float GetFloat(string fieldName)
        {
            return m_DataReader.GetFloat(fieldName);
        }

        public float GetFloat(int i)
        {
            return m_DataReader.GetFloat(i);
        }

        public Guid GetGuid(string fieldName)
        {
            return m_DataReader.GetGuid(fieldName);
        }

        public Guid GetGuid(int i)
        {
            return m_DataReader.GetGuid(i);
        }

        public short GetInt16(string fieldName)
        {
            return m_DataReader.GetInt16(fieldName);
        }

        public short GetInt16(int i)
        {
            return m_DataReader.GetInt16(i);
        }

        public int GetInt32(string fieldName)
        {
            return m_DataReader.GetInt32(fieldName);
        }

        public int GetInt32(int i)
        {
            return m_DataReader.GetInt32(i);
        }

        public long GetInt64(string fieldName)
        {
            return m_DataReader.GetInt64(fieldName);
        }

        public long GetInt64(int i)
        {
            return m_DataReader.GetInt64(i);
        }

        public string GetName(int i)
        {
            return m_DataReader.GetName(i);
        }

        public int GetOrdinal(string name)
        {
            return m_DataReader.GetOrdinal(name);
        }

        public T? GetRawValue<T>(int index) where T : struct
        {
            return DataGeneratorUtility.CastToRawValue<T>(m_DataReader.GetValue(index));
        }

        public T? GetRawValue<T>(string fieldName) where T : struct
        {
            return DataGeneratorUtility.CastToRawValue<T>(m_DataReader.GetValue(fieldName));
        }

        public DataTable GetSchemaTable()
        {
            return m_DataReader.GetSchemaTable();
        }

        public string GetString(string fieldName)
        {
            return m_DataReader.GetString(fieldName);
        }

        public string GetString(int i)
        {
            return m_DataReader.GetString(i);
        }

        public object? GetValue(string fieldName)
        {
            return m_DataReader.GetValue(fieldName);
        }

        public object GetValue(int i)
        {
            return m_DataReader.GetValue(i);
        }

        public int GetValues(object[] values)
        {
            return m_DataReader.GetValues(values);
        }

        public bool IsDBNull(string fieldName)
        {
            return m_DataReader.IsDBNull(fieldName);
        }

        public bool IsDBNull(int i)
        {
            return m_DataReader.IsDBNull(i);
        }

        public bool NextResult()
        {
            return m_DataReader.NextResult();
        }

        public bool Read()
        {
            return m_DataReader.Read();
        }
    }
}
