using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration.Internals
{

    internal sealed class ConvertCollection<TSource, T> : ICollection<T>
    {
        internal ConvertCollection(ICollection<TSource> source, Func<TSource, T> fromSource, Func<T, TSource> toSource)
        {
            m_Source = source;
            m_FromSource = fromSource;
            m_ToSource = toSource;
        }

        private readonly ICollection<TSource> m_Source;

        private readonly Func<TSource, T> m_FromSource;
        private readonly Func<T, TSource> m_ToSource;

        public int Count => m_Source.Count;

        public bool IsReadOnly => m_Source.IsReadOnly;

        public void Add(T item)
        {
            m_Source.Add(m_ToSource(item));
        }

        public void Clear()
        {
            m_Source.Clear();
        }

        public bool Contains(T item)
        {
            return m_Source.Contains(m_ToSource(item));
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int i = 0;

            foreach (var item in m_Source)
            {
                if ((arrayIndex + i) < array.Length)
                {
                    array[arrayIndex + i] = m_FromSource(item);
                    ++i;
                }
                else
                {
                    return;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ConvertEnumerator<TSource, T>(m_Source.GetEnumerator(), m_FromSource);
        }

        public bool Remove(T item)
        {
            return m_Source.Remove(m_ToSource(item));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
