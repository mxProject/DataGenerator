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
    /// Basic implementation of a field that generates a tuple of multiple values.
    /// </summary>
    public abstract class DataGeneratorTupleFieldEnumerationBase : IDataGeneratorTupleFieldEnumeration
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="fieldNames">The name of the fields.</param>
        protected DataGeneratorTupleFieldEnumerationBase(IEnumerable<string> fieldNames)
        {
            m_FieldNames = fieldNames.ToArray();
        }

        #region dispose

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the resources it is using.
        /// </summary>
        /// <param name="disposing">A value that indicates whether it was called from the dispose method.</param>
        protected virtual void Dispose(bool disposing)
        {
        }

        #endregion

        #region fields

        private readonly IReadOnlyList<string> m_FieldNames;

        /// <inheritdoc/>
        public int FieldCount
        {
            get { return m_FieldNames.Count; }
        }

        /// <inheritdoc/>
        public string GetFieldName(int index)
        {
            return m_FieldNames[index];
        }

        #endregion

        #region generation

        /// <inheritdoc/>
        public abstract bool GenerateNext();

        /// <inheritdoc/>
        public abstract void Reset();

        #endregion

        #region value

        /// <inheritdoc/>
        public abstract Type GetValueType(int index);

        /// <inheritdoc/>
        object? IDataGeneratorTupleFieldEnumeration.GetValue(int index)
        {
            return DataGeneratorUtility.ConvertFromRawValue(GetRawValue(index));
        }

        /// <inheritdoc/>
        object? IDataGeneratorTupleFieldEnumeration.GetRawValue(int index)
        {
            return GetRawValue(index);
        }

        /// <summary>
        /// Gets the field value. The value is converted to a well-known type.
        /// </summary>
        /// <param name="index">The field index.</param>
        /// <returns></returns>
        protected object? GetValue(int index)
        {
            return DataGeneratorUtility.ConvertFromRawValue(GetRawValue(index));
        }

        /// <summary>
        /// Gets the field value.
        /// </summary>
        /// <param name="index">The field index.</param>
        /// <returns></returns>
        protected abstract object? GetRawValue(int index);

        /// <inheritdoc/>
        bool IDataGeneratorTupleFieldEnumeration.IsNullValue(int index)
        {
            return IsNullValue(index);
        }

        /// <summary>
        /// Gets a value that indicates whether the generated value is null.
        /// </summary>
        /// <param name="index">The field index.</param>
        /// <returns></returns>
        protected abstract bool IsNullValue(int index);

        /// <inheritdoc/>
        void IDataGeneratorTupleFieldEnumeration.GetValues(object?[] values)
        {
            int count = Math.Min(values.Length, FieldCount);

            for (int i = 0; i < count; ++i)
            {
                values[i] = GetValue(i);
            }
        }

        /// <inheritdoc/>
        void IDataGeneratorTupleFieldEnumeration.GetValues(Span<object?> values)
        {
            int count = Math.Min(values.Length, FieldCount);

            for (int i = 0; i < count; ++i)
            {
                values[i] = GetValue(i);
            }
        }

        /// <inheritdoc/>
        void IDataGeneratorTupleFieldEnumeration.GetValues(Memory<object?> values)
        {
            Span<object?> span = values.Span;

            int count = Math.Min(values.Length, FieldCount);

            for (int i = 0; i < count; ++i)
            {
                span[i] = GetValue(i);
            }
        }

        #endregion

    }

}
