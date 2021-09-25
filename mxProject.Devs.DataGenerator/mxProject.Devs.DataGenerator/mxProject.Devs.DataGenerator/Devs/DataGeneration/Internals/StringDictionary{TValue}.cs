using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace mxProject.Devs.DataGeneration.Internals
{

    internal class StringDictionary<TValue> : IDictionary<StringValue, TValue>
    {

        internal StringDictionary(IDictionary<string, TValue> dictionary)
        {
            m_Dictionary = dictionary;
        }

        private readonly IDictionary<string, TValue> m_Dictionary;

        public TValue this[StringValue key] {
            get { return m_Dictionary[key.Value]; }
            set { m_Dictionary[key.Value] = value; }
        }

        public ICollection<StringValue> Keys => m_Dictionary.Keys.Select(x => new StringValue(x)).ToArray();

        public ICollection<TValue> Values => m_Dictionary.Values;

        public int Count => m_Dictionary.Count;

        public bool IsReadOnly => m_Dictionary.IsReadOnly;

        public void Add(StringValue key, TValue value)
        {
            m_Dictionary.Add(key.Value, value);
        }

        public void Add(KeyValuePair<StringValue, TValue> item)
        {
            m_Dictionary.Add(item.FromStringValue());
        }

        public void Clear()
        {
            m_Dictionary.Clear();
        }

        public bool Contains(KeyValuePair<StringValue, TValue> item)
        {
            return m_Dictionary.Contains(item.FromStringValue());
        }

        public bool ContainsKey(StringValue key)
        {
            if (key.Value == null) { return false; }
            return m_Dictionary.ContainsKey(key.Value);
        }

        public void CopyTo(KeyValuePair<StringValue, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }

            int index = arrayIndex;

            foreach (var pair in m_Dictionary)
            {
                if (array.Length<= index)
                {
                    throw new ArgumentException("The number of elements in the source dictionary exceeds the available area from the index to the end of the destination array.");
                }

                array[index] = pair.ToStringValue();
                ++index;
            }
        }

        public IEnumerator<KeyValuePair<StringValue, TValue>> GetEnumerator()
        {
            return m_Dictionary.Select(x => x.ToStringValue()).GetEnumerator();
        }

        public bool Remove(StringValue key)
        {
            if (key.Value == null) { return false; }
            return m_Dictionary.Remove(key.Value);
        }

        public bool Remove(KeyValuePair<StringValue, TValue> item)
        {
            return m_Dictionary.Remove(item.FromStringValue());
        }

        public bool TryGetValue(StringValue key, out TValue value)
        {
            if (key.Value == null) { value = default!; return false; }
            return m_Dictionary.TryGetValue(key.Value, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
