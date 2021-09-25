using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration.Fields
{

    /// <summary>
    /// Field of data generator.
    /// </summary>
    public class DataGeneratorFieldEnumeration : DataGeneratorFieldEnumerationBase
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="values"></param>
        public DataGeneratorFieldEnumeration(IDataGeneratorField field, IEnumerable<object?> values) : base(field)
        {
            m_Values = values ?? new object?[] { };
            m_Enumerator = m_Values.GetEnumerator();
        }

        private readonly IEnumerable<object?> m_Values;
        private IEnumerator<object?> m_Enumerator;

        /// <inheritdoc/>
        public override bool GenerateNext()
        {
            return m_Enumerator.MoveNext();
        }

        /// <inheritdoc/>
        public override void Reset()
        {
            m_Enumerator?.Dispose();
            m_Enumerator = m_Values.GetEnumerator();
        }

        /// <inheritdoc/>
        public override object? GetRawValue()
        {
            return m_Enumerator?.Current;
        }

        /// <inheritdoc/>
        public override bool IsNullValue()
        {
            return m_Enumerator?.Current == null;
        }

    }

}
