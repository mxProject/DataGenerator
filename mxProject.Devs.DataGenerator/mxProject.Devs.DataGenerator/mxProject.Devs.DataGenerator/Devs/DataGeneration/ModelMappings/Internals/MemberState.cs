using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using mxProject.Devs.DataGeneration.ModelMappings.Fields;

namespace mxProject.Devs.DataGeneration.ModelMappings.Internals
{

    /// <summary>
    /// State related to a member generated in the process of creating DataGeneratorBuilder from type information.
    /// </summary>
    [Obsolete]
    internal sealed class MemberState
    {
#pragma warning disable CS8618
        private MemberState()
#pragma warning restore CS8618
        {
        }

        internal static MemberState FromProperty(PropertyInfo member)
        {
            var fieldAttr = member.GetCustomAttribute<DataGenerationFieldAttribute>(true);
            var tupleAttr = member.GetCustomAttribute<DataGenerationTupleFieldAttribute>(true);
            //var additionalAttr = member.GetCustomAttribute<AdditionFieldAttribute>(true);
            var fieldInfo = CreateFieldInfo(fieldAttr, member.Name, member.PropertyType);

            //return new MemberState() { Member = member, FieldAttr = fieldAttr, TupleAttr = tupleAttr, AdditionAttr = additionalAttr, FieldInfo = fieldInfo };
            return new MemberState() { Member = member, FieldAttr = fieldAttr, TupleAttr = tupleAttr, FieldInfo = fieldInfo };
        }

        internal static MemberState FromField(FieldInfo member)
        {
            var fieldAttr = member.GetCustomAttribute<DataGenerationFieldAttribute>(true);
            var tupleAttr = member.GetCustomAttribute<DataGenerationTupleFieldAttribute>(true);
            //var additionalAttr = member.GetCustomAttribute<AdditionFieldAttribute>(true);
            var fieldInfo = CreateFieldInfo(fieldAttr, member.Name, member.FieldType);

            //return new MemberState() { Member = member, FieldAttr = fieldAttr, TupleAttr = tupleAttr, AdditionAttr = additionalAttr, FieldInfo = fieldInfo };
            return new MemberState() { Member = member, FieldAttr = fieldAttr, TupleAttr = tupleAttr, FieldInfo = fieldInfo };
        }

        private static IDataGeneratorFieldInfo CreateFieldInfo(DataGenerationFieldAttribute? field, string fieldName, Type valueType)
        {
            string name;

            if (field != null && field.FieldName != null)
            {
                name = field.FieldName;
            }
            else
            {
                name = fieldName;
            }

            if (valueType == typeof(string))
            {
                valueType = typeof(StringValue);
            }
            else if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                valueType = valueType.GetGenericArguments()[0];
            }

            return new DataGeneratorFieldNameAndValueType(name, valueType);
        }

        public MemberInfo Member { get; init; }

        public DataGenerationFieldAttribute? FieldAttr { get; init; }

        public DataGenerationTupleFieldAttribute? TupleAttr { get; init; }

        //public AdditionFieldAttribute? AdditionAttr { get; init; }

        public IDataGeneratorFieldInfo FieldInfo { get; init; }


        public IDataGeneratorField? Field { get; set; }
    }

}
