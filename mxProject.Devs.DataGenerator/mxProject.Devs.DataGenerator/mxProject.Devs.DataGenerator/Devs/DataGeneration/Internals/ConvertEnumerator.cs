using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration.Internals
{

    /// <summary>
    /// 
    /// </summary>
    internal sealed class ConvertEnumerator<TSource, T> : IEnumerator<T>
    {
        internal ConvertEnumerator(IEnumerator<TSource> source, Func<TSource, T> fromSource)
        {
            m_Source = source;
            m_FromSource = fromSource;
        }

        private readonly IEnumerator<TSource> m_Source;

        private readonly Func<TSource, T> m_FromSource;

        public T Current => m_FromSource(m_Source.Current);

        object IEnumerator.Current => Current!;

        public void Dispose()
        {
            m_Source.Dispose();
        }

        public bool MoveNext()
        {
            return m_Source.MoveNext();
        }

        public void Reset()
        {
            m_Source.Reset();
        }
    }

}
