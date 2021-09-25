using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration.Fields
{

    /// <summary>
    /// Basic implementation of a field.
    /// </summary>
    public abstract class DataGeneratorFieldEnumerationBase : IDataGeneratorFieldEnumeration
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="field">The field.</param>
        protected DataGeneratorFieldEnumerationBase(IDataGeneratorField field)
        {
            Field = field;
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

        #region field

        /// <summary>
        /// Gets the field.
        /// </summary>
        public IDataGeneratorField Field { get; }

        /// <inheritdoc/>
        string IDataGeneratorFieldEnumeration.FieldName
        {
            get => Field.FieldName;
        }

        /// <inheritdoc/>
        Type IDataGeneratorFieldEnumeration.ValueType
        {
            get => Field.ValueType;
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
        public object? GetValue()
        {
            return DataGeneratorUtility.ConvertFromRawValue(GetRawValue());
        }

        /// <inheritdoc/>
        public abstract object? GetRawValue();

        /// <inheritdoc/>
        public abstract bool IsNullValue();

        #endregion

    }

}
