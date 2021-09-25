using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration.Internals
{

    internal class ArrayArrayPairEnumerator<TKey, TValue> : IEnumerator<KeyValuePair<object?[], object?[]>>
    {

        internal ArrayArrayPairEnumerator(IEnumerator<KeyValuePair<TKey, TValue>> enumerator, Func<TKey, object?[]> toKeyArray, Func<TValue, object?[]> toValueArray)
        {
            m_Enumerator = enumerator;
            m_ToKeyArray = toKeyArray;
            m_ToValueArray = toValueArray;
        }

        private readonly IEnumerator<KeyValuePair<TKey, TValue>> m_Enumerator;
        private readonly Func<TKey, object?[]> m_ToKeyArray;
        private readonly Func<TValue, object?[]> m_ToValueArray;

        public KeyValuePair<object?[], object?[]> Current => new KeyValuePair<object?[], object?[]>(m_ToKeyArray(m_Enumerator.Current.Key), m_ToValueArray(m_Enumerator.Current.Value));

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            m_Enumerator.Dispose();
        }

        public bool MoveNext()
        {
            return m_Enumerator.MoveNext();
        }

        public void Reset()
        {
            m_Enumerator.Reset();
        }
    }

}
