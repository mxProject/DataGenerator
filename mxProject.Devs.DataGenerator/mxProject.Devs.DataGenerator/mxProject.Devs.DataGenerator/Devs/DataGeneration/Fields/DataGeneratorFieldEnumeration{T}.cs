using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace mxProject.Devs.DataGeneration.Fields
{

    /// <summary>
    /// Field of data generator.
    /// </summary>
    /// <typeparam name="T">The value type of the field.</typeparam>
    public class DataGeneratorFieldEnumeration<T> : DataGeneratorFieldEnumerationBase<T> where T : struct
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="values"></param>
        public DataGeneratorFieldEnumeration(IDataGeneratorField field, IEnumerable<T> values) : base(field)
        {
            m_Values = (values ?? new T[] { }).Cast<T?>();
            m_Enumerator = m_Values.GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="values"></param>
        public DataGeneratorFieldEnumeration(IDataGeneratorField field, IEnumerable<T?> values) : base(field)
        {
            m_Values = values ?? new T?[] { };
            m_Enumerator = m_Values.GetEnumerator();
        }

        private readonly IEnumerable<T?> m_Values;
        private IEnumerator<T?> m_Enumerator;

        /// <inheritdoc/>
        public override bool GenerateNext()
        {
            return m_Enumerator.MoveNext();
        }

        /// <inheritdoc/>
        public override T? GetTypedValue()
        {
            return m_Enumerator.Current;
        }

        /// <inheritdoc/>
        public override void Reset()
        {
            m_Enumerator?.Dispose();
            m_Enumerator = m_Values.GetEnumerator();
        }

    }

}
