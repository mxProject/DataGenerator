using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Information about the fields to map. 
    /// </summary>
    public class MappingFieldIndexInfo
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="fieldIndex">The field index.</param>
        /// <param name="mappingName">The field name of the mapping destination.</param>
        public MappingFieldIndexInfo(int fieldIndex, string? mappingName = null)
        {
            FieldIndex = fieldIndex;
            MappingName = mappingName;
        }

        /// <summary>
        /// Creates a new array.
        /// </summary>
        /// <param name="fieldIndexes"></param>
        /// <returns></returns>
        public static MappingFieldIndexInfo[] CreateArray(params int[] fieldIndexes)
        {
            MappingFieldIndexInfo[] fields = new MappingFieldIndexInfo[fieldIndexes.Length];

            for (int i = 0; i < fieldIndexes.Length; ++i)
            {
                fields[i] = new MappingFieldIndexInfo(fieldIndexes[i]);
            }

            return fields;
        }

        /// <summary>
        /// Creates a new array.
        /// </summary>
        /// <param name="fieldIndexes"></param>
        /// <returns></returns>
        public static MappingFieldIndexInfo[] CreateArray(params (int index, string? mappingName)[] fieldIndexes)
        {
            MappingFieldIndexInfo[] fields = new MappingFieldIndexInfo[fieldIndexes.Length];

            for (int i = 0; i < fieldIndexes.Length; ++i)
            {
                fields[i] = new MappingFieldIndexInfo(fieldIndexes[i].index, fieldIndexes[i].mappingName);
            }

            return fields;
        }

        /// <summary>
        /// Gets the field index.
        /// </summary>
        public int FieldIndex { get; }

        /// <summary>
        /// Gets the field name of the mapping destination.
        /// </summary>
        public string? MappingName { get; }
    }
}
