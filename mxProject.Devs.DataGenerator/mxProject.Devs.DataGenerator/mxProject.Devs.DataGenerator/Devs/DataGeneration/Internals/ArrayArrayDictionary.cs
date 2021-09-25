using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace mxProject.Devs.DataGeneration.Internals
{

    internal class Array2Array2Dictionary<TKey1, TKey2, TValue1, TValue2> : ArrayArrayDictionaryBase<(TKey1, TKey2), (TValue1, TValue2)>
    {
        internal Array2Array2Dictionary(IDictionary<(TKey1, TKey2), (TValue1, TValue2)> dictionary) : base(dictionary)
        {
        }

        protected override object?[] ToKeyArray((TKey1, TKey2) value)
        {
            return new object?[] { value.Item1!, value.Item2! };
        }

        protected override (TKey1, TKey2) FromKeyArray(object?[] values)
        {
            return ((TKey1)values[0]!, (TKey2)values[1]!);
        }

        protected override object?[] ToValueArray((TValue1, TValue2) value)
        {
            return new object?[] { value.Item1!, value.Item2! };
        }

        protected override (TValue1, TValue2) FromValueArray(object?[] values)
        {
            return ((TValue1)values[0]!, (TValue2)values[1]!);
        }
    }

    internal class Array2Array3Dictionary<TKey1, TKey2, TValue1, TValue2, TValue3> : ArrayArrayDictionaryBase<(TKey1, TKey2), (TValue1, TValue2, TValue3)>
    {
        internal Array2Array3Dictionary(IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3)> dictionary) : base(dictionary)
        {
        }

        protected override object?[] ToKeyArray((TKey1, TKey2) value)
        {
            return new object[] { value.Item1!, value.Item2! };
        }

        protected override (TKey1, TKey2) FromKeyArray(object?[] values)
        {
            return ((TKey1)values[0]!, (TKey2)values[1]!);
        }

        protected override object?[] ToValueArray((TValue1, TValue2, TValue3) value)
        {
            return new object?[] { value.Item1!, value.Item2!, value.Item3! };
        }

        protected override (TValue1, TValue2, TValue3) FromValueArray(object?[] values)
        {
            return ((TValue1)values[0]!, (TValue2)values[1]!, (TValue3)values[2]!);
        }
    }

    internal class Array3Array2Dictionary<TKey1, TKey2, TKey3, TValue1, TValue2> : ArrayArrayDictionaryBase<(TKey1, TKey2, TKey3), (TValue1, TValue2)>
    {
        internal Array3Array2Dictionary(IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2)> dictionary) : base(dictionary)
        {
        }

        protected override object?[] ToKeyArray((TKey1, TKey2, TKey3) value)
        {
            return new object?[] { value.Item1!, value.Item2!, value.Item3! };
        }

        protected override (TKey1, TKey2, TKey3) FromKeyArray(object?[] values)
        {
            return ((TKey1)values[0]!, (TKey2)values[1]!, (TKey3)values[2]!);
        }

        protected override object[] ToValueArray((TValue1, TValue2) value)
        {
            return new object[] { value.Item1!, value.Item2! };
        }

        protected override (TValue1, TValue2) FromValueArray(object?[] values)
        {
            return ((TValue1)values[0]!, (TValue2)values[1]!);
        }
    }


    internal abstract class ArrayArrayDictionaryBase<TKey, TValue> : IDictionary<object?[], object?[]>
    {
        protected ArrayArrayDictionaryBase(IDictionary<TKey, TValue> dictionary)
        {
            m_Dictionary = dictionary;
        }

        private readonly IDictionary<TKey, TValue> m_Dictionary;

        protected abstract object?[] ToKeyArray(TKey value);

        protected abstract TKey FromKeyArray(object?[] values);

        protected abstract object?[] ToValueArray(TValue value);

        protected abstract TValue FromValueArray(object?[] values);

        public object?[] this[object?[] key] {
            get => ToValueArray(m_Dictionary[FromKeyArray(key)]);
            set => m_Dictionary[FromKeyArray(key)] = FromValueArray(value);
        }

        public ICollection<object?[]> Keys => new ArrayCollection<TKey>(m_Dictionary.Keys, ToKeyArray, FromKeyArray);

        public ICollection<object?[]> Values => new ArrayCollection<TValue>(m_Dictionary.Values, ToValueArray, FromValueArray);

        public int Count => m_Dictionary.Count;

        public bool IsReadOnly => m_Dictionary.IsReadOnly;

        public void Add(object?[] key, object?[] value)
        {
            m_Dictionary.Add(FromKeyArray(key), FromValueArray(value));
        }

        public void Add(KeyValuePair<object?[], object?[]> item)
        {
            m_Dictionary.Add(FromKeyArray(item.Key), FromValueArray(item.Value));
        }

        public void Clear()
        {
            m_Dictionary.Clear();
        }

        public bool Contains(KeyValuePair<object?[], object?[]> item)
        {
            return m_Dictionary.Contains(new KeyValuePair<TKey, TValue>(FromKeyArray(item.Key), FromValueArray(item.Value)));
        }

        public bool ContainsKey(object?[] key)
        {
            return m_Dictionary.ContainsKey(FromKeyArray(key));
        }

        public void CopyTo(KeyValuePair<object?[], object?[]>[] array, int arrayIndex)
        {
            int i = arrayIndex;
            int max = array.Length - 1;

            foreach (var pair in m_Dictionary)
            {
                array[i] = new KeyValuePair<object?[], object?[]>(ToKeyArray(pair.Key), ToValueArray(pair.Value));
                ++i;
                if (i > max) { break; }
            }
        }

        public IEnumerator<KeyValuePair<object?[], object?[]>> GetEnumerator()
        {
            return new ArrayArrayPairEnumerator<TKey, TValue>(m_Dictionary.GetEnumerator(), ToKeyArray, ToValueArray);
        }

        public bool Remove(object?[] key)
        {
            return m_Dictionary.Remove(FromKeyArray(key));
        }

        public bool Remove(KeyValuePair<object?[], object?[]> item)
        {
            return m_Dictionary.Remove(new KeyValuePair<TKey, TValue>(FromKeyArray(item.Key), FromValueArray(item.Value)));
        }

        public bool TryGetValue(object?[] key, out object?[] value)
        {
            if (m_Dictionary.TryGetValue(FromKeyArray(key), out TValue result))
            {
                value = ToValueArray(result);
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
