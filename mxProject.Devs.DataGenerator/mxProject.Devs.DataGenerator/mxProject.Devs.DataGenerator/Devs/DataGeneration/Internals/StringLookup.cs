using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace mxProject.Devs.DataGeneration.Internals
{

    internal class StringLookup : ILookup<StringValue, StringValue>
    {

        internal StringLookup(ILookup<string, string> lookup)
        {
            m_Lookup = lookup;
        }

        private readonly ILookup<string, string> m_Lookup;

        public IEnumerable<StringValue> this[StringValue key] => m_Lookup[key.Value].Select(x => new StringValue(x));

        public int Count => m_Lookup.Count;

        public bool Contains(StringValue key)
        {
            return m_Lookup.Contains(key.Value);
        }

        public IEnumerator<IGrouping<StringValue, StringValue>> GetEnumerator()
        {
            static IEnumerable<IGrouping<StringValue, StringValue>> enumerate(ILookup<string, string> lookup)
            {
                foreach (var group in lookup)
                {
                    yield return new StringGrouping(group);
                }
            }

            return enumerate(m_Lookup).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class StringGrouping : IGrouping<StringValue, StringValue>
    {

        internal StringGrouping(IGrouping<string, string> grouping)
        {
            m_Grouping = grouping;
        }

        private readonly IGrouping<string, string> m_Grouping;

        public StringValue Key => m_Grouping.Key;

        public IEnumerator<StringValue> GetEnumerator()
        {
            return m_Grouping.Select(x => new StringValue(x)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
