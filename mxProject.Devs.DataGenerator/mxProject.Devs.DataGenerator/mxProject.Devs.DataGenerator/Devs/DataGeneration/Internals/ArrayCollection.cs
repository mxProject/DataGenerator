using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration.Internals
{

    internal class ArrayCollection<T> : ICollection<object?[]>, ICollection
    {
        internal ArrayCollection(ICollection<T> collection, Func<T, object?[]> toArray, Func<object?[], T> fromArray)
        {
            m_Collection = collection;
            m_BaseCollection = collection as ICollection;
            m_ToArray = toArray;
            m_FromArray = fromArray;
        }

        private readonly ICollection<T> m_Collection;
        private readonly ICollection? m_BaseCollection;
        private readonly Func<T, object?[]> m_ToArray;
        private readonly Func<object?[], T> m_FromArray;

        public int Count => m_Collection.Count;

        public bool IsReadOnly => m_Collection.IsReadOnly;

        public bool IsSynchronized => (m_BaseCollection == null) ? false : m_BaseCollection.IsSynchronized;

        public object SyncRoot => m_BaseCollection?.SyncRoot!;

        public void Add(object?[] item)
        {
            m_Collection.Add(m_FromArray(item));
        }

        public void Clear()
        {
            m_Collection.Clear();
        }

        public bool Contains(object?[] item)
        {
            return m_Collection.Contains(m_FromArray(item));
        }

        public void CopyTo(object?[][] array, int arrayIndex)
        {
            int i = arrayIndex;
            int max = array.Length - 1;

            foreach (var obj in m_Collection)
            {
                array[i] = m_ToArray(obj);
                ++i;
                if (i > max) { break; }
            }
        }

        public IEnumerator<object?[]> GetEnumerator()
        {
            return new ArrayEnumerator<T>(m_Collection.GetEnumerator(), m_ToArray);
        }

        public bool Remove(object?[] item)
        {
            return m_Collection.Remove(m_FromArray(item));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            int i = index;
            int max = array.Length - 1;

            foreach (var obj in m_Collection)
            {
                array.SetValue(m_ToArray(obj), i);
                ++i;
                if (i > max) { break; }
            }
        }
    }

}
