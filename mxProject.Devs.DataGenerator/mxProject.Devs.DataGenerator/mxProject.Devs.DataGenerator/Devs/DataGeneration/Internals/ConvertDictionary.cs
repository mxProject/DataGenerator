using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration.Internals
{


    internal sealed class ConvertDictionary<TSourceKey, TSourceValue, TKey, TValue> : IDictionary<TKey, TValue>
    {
        internal ConvertDictionary(
            IDictionary<TSourceKey, TSourceValue> source
            , Func<TSourceKey, TKey> fromSourceKey
            , Func<TSourceValue, TValue> fromSourceValue
            , Func<TKey, TSourceKey> toSourceKey
            , Func<TValue, TSourceValue> toSourceValue
            )
        {
            m_Source = source;
            m_FromSourceKey = fromSourceKey;
            m_FromSourceValue = fromSourceValue;
            m_ToSourceKey = toSourceKey;
            m_ToSourceValue = toSourceValue;
        }

        private readonly IDictionary<TSourceKey, TSourceValue> m_Source;

        private readonly Func<TSourceKey, TKey> m_FromSourceKey;
        private readonly Func<TSourceValue, TValue> m_FromSourceValue;
        private readonly Func<TKey, TSourceKey> m_ToSourceKey;
        private readonly Func<TValue, TSourceValue> m_ToSourceValue;

        public TValue this[TKey key]
        {
            get => m_FromSourceValue(m_Source[m_ToSourceKey(key)]);
            set => m_Source[m_ToSourceKey(key)] = m_ToSourceValue(value);
        }

        public ICollection<TKey> Keys
        {
            get
            {
                return new ConvertCollection<TSourceKey, TKey>(m_Source.Keys, m_FromSourceKey, m_ToSourceKey);
            }
        }

        public ICollection<TValue> Values 
        {
            get
            {
                return new ConvertCollection<TSourceValue, TValue>(m_Source.Values, m_FromSourceValue, m_ToSourceValue);
            }
        }

        public int Count => m_Source.Count;

        public bool IsReadOnly => m_Source.IsReadOnly;

        public void Add(TKey key, TValue value)
        {
            m_Source.Add(m_ToSourceKey(key), m_ToSourceValue(value));
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            m_Source.Add(m_ToSourceKey(item.Key), m_ToSourceValue(item.Value));
        }

        public void Clear()
        {
            m_Source.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return m_Source.Contains(new KeyValuePair<TSourceKey, TSourceValue>(m_ToSourceKey(item.Key), m_ToSourceValue(item.Value)));
        }

        public bool ContainsKey(TKey key)
        {
            return m_Source.ContainsKey(m_ToSourceKey(key));
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            int i = 0;

            foreach (var pair in m_Source)
            {
                if ((arrayIndex + i) < array.Length)
                {
                    array[arrayIndex + i] = new KeyValuePair<TKey, TValue>(m_FromSourceKey(pair.Key), m_FromSourceValue(pair.Value));
                    ++i;
                }
                else
                {
                    return;
                }
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            KeyValuePair<TKey, TValue> Convert(KeyValuePair<TSourceKey, TSourceValue> source)
            {
                return new KeyValuePair<TKey, TValue>(m_FromSourceKey(source.Key), m_FromSourceValue(source.Value));
            }

            return new ConvertEnumerator<KeyValuePair<TSourceKey, TSourceValue>, KeyValuePair<TKey, TValue>>(m_Source.GetEnumerator(), Convert);
        }

        public bool Remove(TKey key)
        {
            return m_Source.Remove(m_ToSourceKey(key));
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return m_Source.Remove(new KeyValuePair<TSourceKey, TSourceValue>(m_ToSourceKey(item.Key), m_ToSourceValue(item.Value)));
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (m_Source.TryGetValue(m_ToSourceKey(key), out TSourceValue found))
            {
                value = m_FromSourceValue(found);
                return true;
            }
            else
            {
                value = default!;
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
