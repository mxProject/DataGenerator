using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace mxProject.Devs.DataGeneration.ModelMappings.Internals
{

    [Obsolete]
    internal sealed class DataGeneratorTypeLoader
    {

        /// <summary>
        /// Creates a DataGeneratorBuilder from the attributes defined for the specified type.
        /// </summary>
        /// <param name="modelType">The type of the data model.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        internal static DataGeneratorBuilder FromType(Type modelType, DataGeneratorContext context)
        {

            var allMemberStateList = new List<MemberState>();
            var allMembers = new Dictionary<string, MemberState>();
            var allTupleFields = new Dictionary<(Type, string), TupleFieldState>();

            //IDataGeneratorFieldInfo[] GetFieldInfo(string[] fieldName)
            //{
            //    IDataGeneratorFieldInfo[] info = new IDataGeneratorFieldInfo[fieldName.Length];

            //    for (int i = 0; i < fieldName.Length; ++i)
            //    {
            //        if (allMembers.TryGetValue(fieldName[i].ToLower(), out var member))
            //        {
            //            info[i] = member.FieldInfo;
            //        }
            //    }

            //    return info;
            //}

            // gets properties and fields.
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            foreach (var prop in modelType.GetProperties(bindingFlags))
            {
                var member = MemberState.FromProperty(prop);

                allMemberStateList.Add(member);
                allMembers.Add(member.FieldInfo.FieldName.ToLower(), member);
            }

            foreach (var field in modelType.GetFields(bindingFlags))
            {
                var member = MemberState.FromField(field);

                allMemberStateList.Add(member);
                allMembers.Add(member.FieldInfo.FieldName.ToLower(), member);
            }

            // creates fields.
            foreach (var member in allMemberStateList)
            {
                if (member.FieldAttr == null) { continue; }

                member.Field = member.FieldAttr.CreateField(member.Member, context);

                if (member.TupleAttr != null)
                {
                    var tupleKey = (member.TupleAttr.GetType(), member.TupleAttr.TupleID);

                    if (!allTupleFields.TryGetValue(tupleKey, out var tupleState))
                    {
                        tupleState = new TupleFieldState(tupleKey, member.TupleAttr);
                        allTupleFields.Add(tupleKey, tupleState);
                    }

                    tupleState.Members.Add(member);
                }
            }

            // creates tuple fields.
            foreach (var state in allTupleFields.Values)
            {
                state.TupleField = state.TupleAttr.CreateTupleField(state.GetFields(), context);
            }


            DataGeneratorFieldFactory fieldFactory = new DataGeneratorFieldFactory(context.EnumerableFactory);
            DataGeneratorBuilder builder = new DataGeneratorBuilder(fieldFactory);

            // registers fields.
            foreach (var member in allMemberStateList)
            {
                if (member.Field == null) { continue; }
                if (member.TupleAttr != null) { continue; }

                //if (member.AdditionAttr != null)
                //{
                //    builder.AddTupleField(member.AdditionAttr.CreateTupleField(member.Field, GetFieldInfo(member.AdditionAttr.AdditionalFields), context));
                //}
                //else
                //{
                //    builder.AddField(member.Field);
                //}
                builder.AddField(member.Field);
            }

            // registers tuple fields.
            foreach (var tuple in allTupleFields.Values)
            {
                if (tuple.TupleField == null) { continue; }

                //if (tuple.TryAdditionAttr(out var additionAttr) && additionAttr != null)
                //{
                //    builder.AddTupleField(additionAttr.CreateTupleField(tuple.TupleField, GetFieldInfo(additionAttr.AdditionalFields), context));
                //}
                //else
                //{
                //    builder.AddTupleField(tuple.TupleField);
                //}
                builder.AddTupleField(tuple.TupleField);
            }

            return builder;

        }

    }

}
