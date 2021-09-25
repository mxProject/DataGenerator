using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace mxProject.Devs.DataGeneration.Internals
{

    internal class ObjectDictionary<TKey, TValue> : IDictionary<object, object?>
    {
        internal ObjectDictionary(IDictionary<TKey, TValue> dictionary)
        {
            m_Dictionary = dictionary;
        }

        private readonly IDictionary<TKey, TValue> m_Dictionary;

        public object? this[object key] {
            get => m_Dictionary[(TKey)key]!;
            set => m_Dictionary[(TKey)key] = (TValue)value!;
        }

        public ICollection<object> Keys => new ObjectCollection<TKey>(m_Dictionary.Keys)!;

        public ICollection<object?> Values => new ObjectCollection<TValue>(m_Dictionary.Values);

        public int Count => m_Dictionary.Count;

        public bool IsReadOnly => m_Dictionary.IsReadOnly;

        public void Add(object key, object? value)
        {
            m_Dictionary.Add((TKey)key, (TValue)value!);
        }

        public void Add(KeyValuePair<object, object?> item)
        {
            m_Dictionary.Add((TKey)item.Key, (TValue)item.Value!);
        }

        public void Clear()
        {
            m_Dictionary.Clear();
        }

        public bool Contains(KeyValuePair<object, object?> item)
        {
            return m_Dictionary.Contains(new KeyValuePair<TKey, TValue>((TKey)item.Key, (TValue)item.Value!));
        }

        public bool ContainsKey(object key)
        {
            return m_Dictionary.ContainsKey((TKey)key);
        }

        public void CopyTo(KeyValuePair<object, object?>[] array, int arrayIndex)
        {
            int i = arrayIndex;
            int max = array.Length - 1;

            foreach (var pair in m_Dictionary)
            {
                array[i] = new KeyValuePair<object, object?>(pair.Key!, pair.Value!);
                ++i;
                if (i > max) { break; }
            }
        }

        public IEnumerator<KeyValuePair<object, object?>> GetEnumerator()
        {
            return new ObjectPairEnumerator<TKey, TValue>(m_Dictionary.GetEnumerator());
        }

        public bool Remove(object key)
        {
            return m_Dictionary.Remove((TKey)key);
        }

        public bool Remove(KeyValuePair<object, object?> item)
        {
            return m_Dictionary.Remove(new KeyValuePair<TKey, TValue>((TKey)item.Key, (TValue)item.Value!));
        }

        public bool TryGetValue(object key, out object? value)
        {
            if (m_Dictionary.TryGetValue((TKey)key, out TValue result))
            {
                value = result;
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
