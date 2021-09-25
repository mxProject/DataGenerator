using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace mxProject.Devs.DataGeneration.Internals
{

    internal class ObjectArrayDictionary<TKey, TValue1, TValue2> : ObjectArrayDictionaryBase<TKey, (TValue1, TValue2)>
    {
        internal ObjectArrayDictionary(IDictionary<TKey, (TValue1, TValue2)> dictionary) : base(dictionary)
        {
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

    internal class ObjectArrayDictionary<TKey, TValue1, TValue2, TValue3> : ObjectArrayDictionaryBase<TKey, (TValue1, TValue2, TValue3)>
    {
        internal ObjectArrayDictionary(IDictionary<TKey, (TValue1, TValue2, TValue3)> dictionary) : base(dictionary)
        {
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

    internal class ObjectArrayDictionary<TKey, TValue1, TValue2, TValue3, TValue4> : ObjectArrayDictionaryBase<TKey, (TValue1, TValue2, TValue3, TValue4)>
    {
        internal ObjectArrayDictionary(IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4)> dictionary) : base(dictionary)
        {
        }

        protected override object?[] ToValueArray((TValue1, TValue2, TValue3, TValue4) value)
        {
            return new object?[] { value.Item1!, value.Item2!, value.Item3!, value.Item4! };
        }

        protected override (TValue1, TValue2, TValue3, TValue4) FromValueArray(object?[] values)
        {
            return ((TValue1)values[0]!, (TValue2)values[1]!, (TValue3)values[2]!, (TValue4)values[3]!);
        }
    }

    internal class ObjectArrayDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5> : ObjectArrayDictionaryBase<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5)>
    {
        internal ObjectArrayDictionary(IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5)> dictionary) : base(dictionary)
        {
        }

        protected override object?[] ToValueArray((TValue1, TValue2, TValue3, TValue4, TValue5) value)
        {
            return new object?[] { value.Item1!, value.Item2!, value.Item3!, value.Item4!, value.Item5! };
        }

        protected override (TValue1, TValue2, TValue3, TValue4, TValue5) FromValueArray(object?[] values)
        {
            return ((TValue1)values[0]!, (TValue2)values[1]!, (TValue3)values[2]!, (TValue4)values[3]!, (TValue5)values[4]!);
        }
    }

    internal class ObjectArrayDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6> : ObjectArrayDictionaryBase<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>
    {
        internal ObjectArrayDictionary(IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> dictionary) : base(dictionary)
        {
        }

        protected override object?[] ToValueArray((TValue1, TValue2, TValue3, TValue4, TValue5, TValue6) value)
        {
            return new object?[] { value.Item1!, value.Item2!, value.Item3!, value.Item4!, value.Item5!, value.Item6! };
        }

        protected override (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6) FromValueArray(object?[] values)
        {
            return ((TValue1)values[0]!, (TValue2)values[1]!, (TValue3)values[2]!, (TValue4)values[3]!, (TValue5)values[4]!, (TValue6)values[5]!);
        }
    }

    internal class ObjectArrayDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7> : ObjectArrayDictionaryBase<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>
    {
        internal ObjectArrayDictionary(IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> dictionary) : base(dictionary)
        {
        }

        protected override object?[] ToValueArray((TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7) value)
        {
            return new object?[] { value.Item1!, value.Item2!, value.Item3!, value.Item4!, value.Item5!, value.Item6!, value.Item7! };
        }

        protected override (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7) FromValueArray(object?[] values)
        {
            return ((TValue1)values[0]!, (TValue2)values[1]!, (TValue3)values[2]!, (TValue4)values[3]!, (TValue5)values[4]!, (TValue6)values[5]!, (TValue7)values[6]!);
        }
    }

    internal class ObjectArrayDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8> : ObjectArrayDictionaryBase<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>
    {
        internal ObjectArrayDictionary(IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> dictionary) : base(dictionary)
        {
        }

        protected override object?[] ToValueArray((TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8) value)
        {
            return new object?[] { value.Item1!, value.Item2!, value.Item3!, value.Item4!, value.Item5!, value.Item6!, value.Item7!, value.Item8! };
        }

        protected override (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8) FromValueArray(object?[] values)
        {
            return ((TValue1)values[0]!, (TValue2)values[1]!, (TValue3)values[2]!, (TValue4)values[3]!, (TValue5)values[4]!, (TValue6)values[5]!, (TValue7)values[6]!, (TValue8)values[7]!);
        }
    }

    internal abstract class ObjectArrayDictionaryBase<TKey, TValue> : IDictionary<object, object?[]>, IDictionary
    {
        protected ObjectArrayDictionaryBase(IDictionary<TKey, TValue> dictionary)
        {
            m_Dictionary = dictionary;
            m_BaseDictionary = dictionary as IDictionary;
        }

        private readonly IDictionary<TKey, TValue> m_Dictionary;
        private readonly IDictionary? m_BaseDictionary;

        protected abstract object?[] ToValueArray(TValue value);

        protected abstract TValue FromValueArray(object?[] values);

        public object?[] this[object key] {
            get => ToValueArray(m_Dictionary[(TKey)key]!);
            set => m_Dictionary[(TKey)key] = FromValueArray(value);
        }

        public ICollection<object> Keys => new ObjectCollection<TKey>(m_Dictionary.Keys)!;

        public ICollection<object?[]> Values => new ArrayCollection<TValue>(m_Dictionary.Values, ToValueArray, FromValueArray);

        public int Count => m_Dictionary.Count;

        public bool IsReadOnly => m_Dictionary.IsReadOnly;

        public bool IsFixedSize => false;

        ICollection IDictionary.Keys => new ObjectCollection<TKey>(m_Dictionary.Keys)!;

        ICollection IDictionary.Values => new ArrayCollection<TValue>(m_Dictionary.Values, ToValueArray, FromValueArray);

        public bool IsSynchronized => (m_BaseDictionary == null) ? false : m_BaseDictionary.IsSynchronized;

        public object SyncRoot => m_BaseDictionary?.SyncRoot!;

        object IDictionary.this[object key]
        {
            get => this[key];
            set => this[key] = (object?[])value;
        }

        public void Add(object key, object?[] value)
        {
            m_Dictionary.Add((TKey)key, FromValueArray(value));
        }

        public void Add(KeyValuePair<object, object?[]> item)
        {
            m_Dictionary.Add((TKey)item.Key, FromValueArray(item.Value));
        }

        public void Clear()
        {
            m_Dictionary.Clear();
        }

        public bool Contains(KeyValuePair<object, object?[]> item)
        {
            return m_Dictionary.Contains(new KeyValuePair<TKey, TValue>((TKey)item.Key, FromValueArray(item.Value)));
        }

        public bool ContainsKey(object key)
        {
            return m_Dictionary.ContainsKey((TKey)key);
        }

        public void CopyTo(KeyValuePair<object, object?[]>[] array, int arrayIndex)
        {
            int i = arrayIndex;
            int max = array.Length - 1;

            foreach (var pair in m_Dictionary)
            {
                array[i] = new KeyValuePair<object, object?[]>(pair.Key!, ToValueArray(pair.Value));
                ++i;
                if (i > max) { break; }
            }
        }

        public IEnumerator<KeyValuePair<object, object?[]>> GetEnumerator()
        {
            return new ObjectArrayPairEnumerator<TKey, TValue>(m_Dictionary.GetEnumerator(), ToValueArray);
        }

        public bool Remove(object key)
        {
            return m_Dictionary.Remove((TKey)key);
        }

        public bool Remove(KeyValuePair<object, object?[]> item)
        {
            return m_Dictionary.Remove(new KeyValuePair<TKey, TValue>((TKey)item.Key, FromValueArray(item.Value)));
        }

        public bool TryGetValue(object key, out object?[] value)
        {
            if (m_Dictionary.TryGetValue((TKey)key, out TValue result))
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

        public void Add(object key, object value)
        {
            Add(key, (object?[])value);
        }

        public bool Contains(object key)
        {
            return ContainsKey(key);
        }

        IDictionaryEnumerator IDictionary.GetEnumerator()
        {
            return new ObjectArrayPairEnumerator<TKey, TValue>(m_Dictionary.GetEnumerator(), ToValueArray);
        }

        void IDictionary.Remove(object key)
        {
            Remove(key);
        }

        public void CopyTo(Array array, int index)
        {
            int i = index;
            int max = array.Length - 1;

            foreach (var pair in m_Dictionary)
            {
                array.SetValue(new KeyValuePair<object, object?[]>(pair.Key!, ToValueArray(pair.Value)), i);
                ++i;
                if (i > max) { break; }
            }
        }
    }

}
