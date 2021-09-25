using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration.Internals
{

    internal class ObjectEnumerator<T> : IEnumerator<object>
    {

        internal ObjectEnumerator(IEnumerator<T> enumerator)
        {
            m_Enumerator = enumerator;
        }

        private readonly IEnumerator<T> m_Enumerator;

        public object Current => m_Enumerator.Current!;

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
