using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace mxProject.Devs.DataGeneration.Internals
{

    internal class ArrayObjectDictionary<TKey1, TKey2, TValue> : ArrayObjectDictionaryBase<(TKey1, TKey2), TValue>
    {
        internal ArrayObjectDictionary(IDictionary<(TKey1, TKey2), TValue> dictionary) : base(dictionary)
        {
        }

        protected override object?[] ToKeyArray((TKey1, TKey2) value)
        {
            return new object?[] { value.Item1, value.Item2 };
        }

        protected override (TKey1, TKey2) FromKeyArray(object?[] values)
        {
            return ((TKey1)values[0]!, (TKey2)values[1]!);
        }
    }

    internal class ArrayObjectDictionary<TKey1, TKey2, TKey3, TValue> : ArrayObjectDictionaryBase<(TKey1, TKey2, TKey3), TValue>
    {
        internal ArrayObjectDictionary(IDictionary<(TKey1, TKey2, TKey3), TValue> dictionary) : base(dictionary)
        {
        }

        protected override object[] ToKeyArray((TKey1, TKey2, TKey3) value)
        {
            return new object[] { value.Item1!, value.Item2!, value.Item3! };
        }

        protected override (TKey1, TKey2, TKey3) FromKeyArray(object?[] values)
        {
            return ((TKey1)values[0]!, (TKey2)values[1]!, (TKey3)values[2]!);
        }
    }

    internal class ArrayObjectDictionary<TKey1, TKey2, TKey3, TKey4, TValue> : ArrayObjectDictionaryBase<(TKey1, TKey2, TKey3, TKey4), TValue>
    {
        internal ArrayObjectDictionary(IDictionary<(TKey1, TKey2, TKey3, TKey4), TValue> dictionary) : base(dictionary)
        {
        }

        protected override object[] ToKeyArray((TKey1, TKey2, TKey3, TKey4) value)
        {
            return new object[] { value.Item1!, value.Item2!, value.Item3!, value.Item4! };
        }

        protected override (TKey1, TKey2, TKey3, TKey4) FromKeyArray(object?[] values)
        {
            return ((TKey1)values[0]!, (TKey2)values[1]!, (TKey3)values[2]!, (TKey4)values[3]!);
        }
    }

    internal abstract class ArrayObjectDictionaryBase<TKey, TValue> : IDictionary<object?[], object?>
    {
        protected ArrayObjectDictionaryBase(IDictionary<TKey, TValue> dictionary)
        {
            m_Dictionary = dictionary;
        }

        private readonly IDictionary<TKey, TValue> m_Dictionary;

        protected abstract object?[] ToKeyArray(TKey value);

        protected abstract TKey FromKeyArray(object?[] values);

        public object? this[object?[] key] {
            get => m_Dictionary[FromKeyArray(key)]!;
            set => m_Dictionary[FromKeyArray(key)] = (TValue)value!;
        }

        public ICollection<object?[]> Keys => new ArrayCollection<TKey>(m_Dictionary.Keys, ToKeyArray, FromKeyArray);

        public ICollection<object?> Values => new ObjectCollection<TValue>(m_Dictionary.Values);

        public int Count => m_Dictionary.Count;

        public bool IsReadOnly => m_Dictionary.IsReadOnly;

        public void Add(object?[] key, object? value)
        {
            m_Dictionary.Add(FromKeyArray(key), (TValue)value!);
        }

        public void Add(KeyValuePair<object?[], object?> item)
        {
            m_Dictionary.Add(FromKeyArray(item.Key), (TValue)item.Value!);
        }

        public void Clear()
        {
            m_Dictionary.Clear();
        }

        public bool Contains(KeyValuePair<object?[], object?> item)
        {
            return m_Dictionary.Contains(new KeyValuePair<TKey, TValue>(FromKeyArray(item.Key), (TValue)item.Value!));
        }

        public bool ContainsKey(object?[] key)
        {
            return m_Dictionary.ContainsKey(FromKeyArray(key));
        }

        public void CopyTo(KeyValuePair<object?[], object?>[] array, int arrayIndex)
        {
            int i = arrayIndex;
            int max = array.Length - 1;

            foreach (var pair in m_Dictionary)
            {
                array[i] = new KeyValuePair<object?[], object?>(ToKeyArray(pair.Key), pair.Value!);
                ++i;
                if (i > max) { break; }
            }
        }

        public IEnumerator<KeyValuePair<object?[], object?>> GetEnumerator()
        {
            return new ArrayObjectPairEnumerator<TKey, TValue>(m_Dictionary.GetEnumerator(), ToKeyArray);
        }

        public bool Remove(object?[] key)
        {
            return m_Dictionary.Remove(FromKeyArray(key));
        }

        public bool Remove(KeyValuePair<object?[], object?> item)
        {
            return m_Dictionary.Remove(new KeyValuePair<TKey, TValue>(FromKeyArray(item.Key), (TValue)item.Value!));
        }

        public bool TryGetValue(object?[] key, out object? value)
        {
            if (m_Dictionary.TryGetValue(FromKeyArray(key), out TValue result))
            {
                value = result!;
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
