using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace mxProject.Devs.DataGeneration.Internals
{

    internal class StringLookup<TValue> : ILookup<StringValue, TValue>
    {

        internal StringLookup(ILookup<string, TValue> lookup)
        {
            m_Lookup = lookup;
        }

        private readonly ILookup<string, TValue> m_Lookup;

        public IEnumerable<TValue> this[StringValue key] => m_Lookup[key.Value];

        public int Count => m_Lookup.Count;

        public bool Contains(StringValue key)
        {
            return m_Lookup.Contains(key.Value);
        }

        public IEnumerator<IGrouping<StringValue, TValue>> GetEnumerator()
        {
            static IEnumerable<IGrouping<StringValue, TValue>> enumerate(ILookup<string, TValue> lookup)
            {
                foreach (var group in lookup)
                {
                    yield return new StringGrouping<TValue>(group);
                }
            }

            return enumerate(m_Lookup).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class StringGrouping<TValue> : IGrouping<StringValue, TValue>
    {

        internal StringGrouping(IGrouping<string, TValue> grouping)
        {
            m_Grouping = grouping;
        }

        private readonly IGrouping<string, TValue> m_Grouping;

        public StringValue Key => m_Grouping.Key;

        public IEnumerator<TValue> GetEnumerator()
        {
            return m_Grouping.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
