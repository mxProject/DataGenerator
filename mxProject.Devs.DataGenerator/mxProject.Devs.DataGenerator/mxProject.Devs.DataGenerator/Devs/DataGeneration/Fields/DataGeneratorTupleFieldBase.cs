using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Buffers;
using System.Threading.Tasks;

namespace mxProject.Devs.DataGeneration.Fields
{

    /// <summary>
    /// Basic implement of a field that generates a tuple of multiple values.
    /// </summary>
    public abstract class DataGeneratorTupleFieldBase : IDataGeneratorTupleField
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="fieldNames">The names of the fields.</param>
        /// <param name="valueTypes">The value types of the fields.</param>
        /// <param name="mayBeNull">A value that indicates whether the fields may return a null value.</param>
        protected DataGeneratorTupleFieldBase(string[] fieldNames, Type[] valueTypes, bool[] mayBeNull)
        {
            m_FieldNames = fieldNames;
            m_ValueTypes = valueTypes;
            m_MayBeNull = mayBeNull;
        }

        #region fields

        private readonly string[] m_FieldNames;
        private readonly Type[] m_ValueTypes;
        private readonly bool[] m_MayBeNull;

        /// <inheritdoc/>
        public int FieldCount
        {
            get { return m_FieldNames.Length; }
        }

        /// <inheritdoc/>
        public string GetFieldName(int index)
        {
            return m_FieldNames[index];
        }

        /// <inheritdoc/>
        public Type GetValueType(int index)
        {
            return m_ValueTypes[index];
        }

        #endregion

        /// <inheritdoc/>
        public bool MayBeNull(int index)
        {
            return m_MayBeNull[index];
        }

        /// <inheritdoc/>
        public abstract ValueTask<IDataGeneratorTupleFieldEnumeration> CreateEnumerationAsync(int generateCount);

    }

}
