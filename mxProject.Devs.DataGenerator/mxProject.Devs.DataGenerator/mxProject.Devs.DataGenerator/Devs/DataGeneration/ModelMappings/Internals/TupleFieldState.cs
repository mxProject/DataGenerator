using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using mxProject.Devs.DataGeneration.ModelMappings.Fields;

namespace mxProject.Devs.DataGeneration.ModelMappings.Internals
{

    /// <summary>
    /// State related to a tuple field generated in the process of creating DataGeneratorBuilder from type information.
    /// </summary>
    [Obsolete]
    internal class TupleFieldState
    {
        internal TupleFieldState((Type, string) key, DataGenerationTupleFieldAttribute tupleAttr)
        {
            Key = key;
            TupleAttr = tupleAttr;
        }

        internal (Type, string) Key { get; }

        internal DataGenerationTupleFieldAttribute TupleAttr { get; }

        internal IList<MemberState> Members
        {
            get { return m_Members; }
        }

        private readonly List<MemberState> m_Members = new List<MemberState>();

        internal IDataGeneratorField[] GetFields()
        {
            var members = m_Members.ToArray();

            static int CompareMember(MemberState x, MemberState y)
            {
                if (x.TupleAttr != null && y.TupleAttr != null)
                {
                    return x.TupleAttr.FieldIndex.CompareTo(y.TupleAttr.FieldIndex);
                }
                else if (x.TupleAttr != null)
                {
                    return 1;
                }
                else if (y.TupleAttr != null)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

            Array.Sort(members, CompareMember);

            IDataGeneratorField[] fields = new IDataGeneratorField[members.Length];

            for (int i = 0; i < members.Length; ++i)
            {
                fields[i] = members[i].Field!;
            }

            return fields;
        }

        //internal bool HasAdditionAttr()
        //{
        //    for (int i = 0; i < m_Members.Count; ++i)
        //    {
        //        if (m_Members[i].AdditionAttr != null) { return true; }
        //    }

        //    return false;
        //}

        //internal bool TryAdditionAttr(out AdditionFieldAttribute attr)
        //{
        //    for (int i = 0; i < m_Members.Count; ++i)
        //    {
        //        if (m_Members[i].AdditionAttr != null)
        //        {
        //            attr = m_Members[i].AdditionAttr!;
        //            return true;
        //        }
        //    }

        //    attr = null!;
        //    return false;
        //}

        internal IDataGeneratorTupleField? TupleField { get; set; }
    }

}
