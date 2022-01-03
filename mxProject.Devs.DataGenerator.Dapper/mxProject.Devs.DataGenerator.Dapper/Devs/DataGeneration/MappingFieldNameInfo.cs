using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Information about the fields to map.
    /// </summary>
    public class MappingFieldNameInfo
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="mappingName">The field name of the mapping destination.</param>
        public MappingFieldNameInfo(string fieldName, string? mappingName = null)
        {
            FieldName = fieldName;
            MappingName = mappingName;
        }

        /// <summary>
        /// Creates a new array.
        /// </summary>
        /// <param name="fieldNames"></param>
        /// <returns></returns>
        public static MappingFieldNameInfo[] CreateArray(params string[] fieldNames)
        {
            MappingFieldNameInfo[] fields = new MappingFieldNameInfo[fieldNames.Length];

            for (int i = 0; i < fieldNames.Length; ++i)
            {
                fields[i] = new MappingFieldNameInfo(fieldNames[i]);
            }

            return fields;
        }

        /// <summary>
        /// Creates a new array.
        /// </summary>
        /// <param name="fieldNames"></param>
        /// <returns></returns>
        public static MappingFieldNameInfo[] CreateArray(params (string actual, string? mapping)[] fieldNames)
        {
            MappingFieldNameInfo[] fields = new MappingFieldNameInfo[fieldNames.Length];

            for (int i = 0; i < fieldNames.Length; ++i)
            {
                fields[i] = new MappingFieldNameInfo(fieldNames[i].actual, fieldNames[i].mapping);
            }

            return fields;
        }

        /// <summary>
        /// Gets the field name.
        /// </summary>
        public string FieldName { get; }

        /// <summary>
        /// Gets the field name of the mapping destination.
        /// </summary>
        public string? MappingName { get; }
    }
}
