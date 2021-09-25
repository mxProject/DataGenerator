using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration.Internals
{

    internal class ObjectPairEnumerator<TKey, TValue> : IEnumerator<KeyValuePair<object, object?>>
    {

        internal ObjectPairEnumerator(IEnumerator<KeyValuePair<TKey, TValue>> enumerator)
        {
            m_Enumerator = enumerator;
        }

        private readonly IEnumerator<KeyValuePair<TKey, TValue>> m_Enumerator;

        public KeyValuePair<object, object?> Current => new  KeyValuePair<object, object?>(m_Enumerator.Current.Key!, m_Enumerator.Current.Value!);

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
