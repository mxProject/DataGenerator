using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Field information.
    /// </summary>
    public sealed class DataGeneratorFieldInfo : IDataGeneratorFieldInfo
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public DataGeneratorFieldInfo()
        {
        }

        /// <summary>
        /// Creates a new instances. 
        /// </summary>
        /// <param name="fieldNames"></param>
        /// <param name="valueTypes"></param>
        /// <returns></returns>
        internal static IDataGeneratorFieldInfo[] CreateFields(string[] fieldNames, params Type[] valueTypes)
        {
            IDataGeneratorFieldInfo[] fields = new IDataGeneratorFieldInfo[fieldNames.Length];

            for (int i = 0; i < fieldNames.Length; ++i)
            {
                fields[i] = new DataGeneratorFieldInfo(fieldNames[i], DataGeneratorUtility.GetFieldValueType(valueTypes[i]));
            }

            return fields;
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="valueType">The value type.</param>
        public DataGeneratorFieldInfo(string fieldName, string valueType)
        {
            FieldName = fieldName;
            ValueType = valueType;
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="valueType">The value type.</param>
        public DataGeneratorFieldInfo(string fieldName, Type valueType)
        {
            FieldName = fieldName;
            ValueType = valueType.FullName;
        }

        /// <summary>
        /// Gets or sets the field name.
        /// </summary>
        [JsonProperty("FieldName", Order = 1)]
        public string? FieldName { get; set; }

        /// <summary>
        /// Gets or sets the value type.
        /// </summary>
        [JsonProperty("ValueType", Order = 2)]
        public string? ValueType { get; set; }

        /// <summary>
        /// Gets the value type.
        /// </summary>
        /// <returns></returns>
        public Type? GetFieldValueType()
        {
            if (string.IsNullOrWhiteSpace(ValueType)) { return null; }

            Type type = Type.GetType(ValueType);

            if (type == typeof(string))
            {
                return typeof(StringValue);
            }
            else
            {
                return type;
            }
        }

        string IDataGeneratorFieldInfo.FieldName
        {
            get { return FieldName!; }
        }

        Type IDataGeneratorFieldInfo.ValueType
        {
            get
            {
                return GetFieldValueType()!;
            }
        }
    }

}
