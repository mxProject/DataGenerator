using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration.Internals
{

    internal class ArrayEnumerator<T> : IEnumerator<object?[]>
    {

        internal ArrayEnumerator(IEnumerator<T> enumerator, Func<T, object?[]> toArray)
        {
            m_Enumerator = enumerator;
            m_ToArray = toArray;
        }

        private readonly IEnumerator<T> m_Enumerator;
        private readonly Func<T, object?[]> m_ToArray;

        public object?[] Current => m_ToArray(m_Enumerator.Current);

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
