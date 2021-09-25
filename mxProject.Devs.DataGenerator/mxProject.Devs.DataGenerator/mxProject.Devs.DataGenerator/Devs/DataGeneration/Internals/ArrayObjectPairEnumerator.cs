using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration.Internals
{

    internal class ArrayObjectPairEnumerator<TKey, TValue> : IEnumerator<KeyValuePair<object?[], object?>>
    {

        internal ArrayObjectPairEnumerator(IEnumerator<KeyValuePair<TKey, TValue>> enumerator, Func<TKey, object?[]> toArray)
        {
            m_Enumerator = enumerator;
            m_ToArray = toArray;
        }

        private readonly IEnumerator<KeyValuePair<TKey, TValue>> m_Enumerator;
        private readonly Func<TKey, object?[]> m_ToArray;

        public KeyValuePair<object?[], object?> Current => new KeyValuePair<object?[], object?>(m_ToArray(m_Enumerator.Current.Key), m_Enumerator.Current.Value);

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
