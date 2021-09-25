using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Devs.DataGeneration.Internals
{

    internal class DataGeneratorTupleFieldAccessor : IDataGeneratorFieldAccessor
    {
        internal DataGeneratorTupleFieldAccessor(DataGeneratorTupleFieldAccessorBody accessorBody, int index)
        {
            m_AccessorBody = accessorBody;
            m_Index = index;
        }

        private readonly DataGeneratorTupleFieldAccessorBody m_AccessorBody;
        private readonly int m_Index;

        public ValueTask InitializeAsync(int generationCount)
        {
            if (m_Index == 0)
            {
                return m_AccessorBody.CreateEnumeration(generationCount);
            }
            else
            {
                return default;
            }
        }

        public string FieldName
        {
            get { return m_AccessorBody.GetFieldName(m_Index); }
        }

        public Type ValueType
        {
            get { return m_AccessorBody.GetValueType(m_Index); }
        }

        public int Index
        {
            get { return m_Index; }
        }

        public object? GetValue()
        {
            return m_AccessorBody.GetValue(m_Index);
        }

        public object? GetRawValue()
        {
            return m_AccessorBody.GetRawValue(m_Index);
        }

        public bool IsNullValue()
        {
            return m_AccessorBody.IsNullValue(m_Index);
        }

        public bool GenerateNext()
        {
            return m_AccessorBody.GenerateNext();
        }

        public void Reset()
        {
            m_AccessorBody.Reset();
        }

    }

    internal class DataGeneratorTupleFieldAccessorBody
    {
        internal DataGeneratorTupleFieldAccessorBody(IDataGeneratorTupleField tuple)
        {
            m_Tuple = tuple;
        }

        private readonly IDataGeneratorTupleField m_Tuple;
        private IDataGeneratorTupleFieldEnumeration? m_Enumeration;

        public async ValueTask CreateEnumeration(int generationCount)
        {
            m_Enumeration = await m_Tuple.CreateEnumerationAsync(generationCount).ConfigureAwait(false);
        }

        internal string GetFieldName(int index)
        {
            return m_Tuple.GetFieldName(index);
        }

        internal Type GetValueType(int index)
        {
            return m_Tuple.GetValueType(index);
        }

        internal object? GetValue(int index)
        {
            if (m_Enumeration == null) { throw new InvalidOperationException(); }
            return m_Enumeration.GetValue(index);
        }

        internal object? GetRawValue(int index)
        {
            if (m_Enumeration == null) { throw new InvalidOperationException(); }
            return m_Enumeration.GetRawValue(index);
        }

        internal bool IsNullValue(int index)
        {
            if (m_Enumeration == null) { throw new InvalidOperationException(); }
            return m_Enumeration.IsNullValue(index);
        }

        internal bool GenerateNext()
        {
            if (m_Enumeration == null) { throw new InvalidOperationException(); }
            return m_Enumeration.GenerateNext();
        }

        internal void Reset()
        {
            if (m_Enumeration == null) { throw new InvalidOperationException(); }
            m_Enumeration.Reset();
        }

    }

}
