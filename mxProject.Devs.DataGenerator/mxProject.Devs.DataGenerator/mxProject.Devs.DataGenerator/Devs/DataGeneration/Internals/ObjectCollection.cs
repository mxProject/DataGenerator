using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration.Internals
{

    internal class ObjectCollection<T> : ICollection<object?>, ICollection
    {
        internal ObjectCollection(ICollection<T> collection)
        {
            m_Collection = collection;
            m_BaseCollection = collection as ICollection;
        }

        private readonly ICollection<T> m_Collection;
        private readonly ICollection? m_BaseCollection;

        public int Count => m_Collection.Count;

        public bool IsReadOnly => m_Collection.IsReadOnly;

        public bool IsSynchronized => (m_BaseCollection == null) ? false : m_BaseCollection.IsSynchronized;

        public object SyncRoot => m_BaseCollection?.SyncRoot!;

        public void Add(object? item)
        {
            m_Collection.Add((T)item!);
        }

        public void Clear()
        {
            m_Collection.Clear();
        }

        public bool Contains(object? item)
        {
            return m_Collection.Contains((T)item!);
        }

        public void CopyTo(object?[] array, int arrayIndex)
        {
            int i = arrayIndex;
            int max = array.Length - 1;

            foreach (var obj in m_Collection)
            {
                array[i] = obj!;
                ++i;
                if (i > max) { break; }
            }
        }

        public IEnumerator<object?> GetEnumerator()
        {
            return new ObjectEnumerator<T>(m_Collection.GetEnumerator());
        }

        public bool Remove(object? item)
        {
            return m_Collection.Remove((T)item!);
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
                array.SetValue(obj!, i);
                ++i;
                if (i > max) { break; }
            }
        }
    }

}
