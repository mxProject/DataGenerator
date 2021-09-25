using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Devs.DataGeneration.Internals
{
 
    internal class DataGeneratorFieldAccessor : IDataGeneratorFieldAccessor
    {
        internal DataGeneratorFieldAccessor(IDataGeneratorField field)
        {
            m_Field = field;
        }

        private readonly IDataGeneratorField m_Field;
        private IDataGeneratorFieldEnumeration? m_Enumeration;

        public async ValueTask InitializeAsync(int generationCount)
        {
            m_Enumeration = await m_Field.CreateEnumerationAsync(generationCount).ConfigureAwait(false);
        }

        public string FieldName
        {
            get { return m_Field.FieldName; }
        }

        public Type ValueType
        {
            get { return m_Field.ValueType; }
        }

        public int Index { get => 0; }

        public object? GetValue()
        {
            if (m_Enumeration == null) { throw new InvalidOperationException(); }
            return m_Enumeration.GetValue();
        }

        public object? GetRawValue()
        {
            if (m_Enumeration == null) { throw new InvalidOperationException(); }
            return m_Enumeration.GetRawValue();
        }

        public bool IsNullValue()
        {
            if (m_Enumeration == null) { throw new InvalidOperationException(); }
            return m_Enumeration.IsNullValue();
        }

        public bool GenerateNext()
        {
            if (m_Enumeration == null) { throw new InvalidOperationException(); }
            return m_Enumeration.GenerateNext();
        }

        public void Reset()
        {
            if (m_Enumeration == null) { throw new InvalidOperationException(); }
            m_Enumeration.Reset();
        }
    }

}
