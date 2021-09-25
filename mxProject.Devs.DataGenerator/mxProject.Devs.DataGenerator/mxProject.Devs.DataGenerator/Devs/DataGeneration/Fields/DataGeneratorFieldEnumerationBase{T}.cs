using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration.Fields
{

    /// <summary>
    /// Basic implementation of a field.
    /// </summary>
    /// <typeparam name="T">The value type of the field.</typeparam>
    public abstract class DataGeneratorFieldEnumerationBase<T> : DataGeneratorFieldEnumerationBase, IDataGeneratorFieldEnumeration<T> where T : struct
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="field">The name of the field.</param>
        protected DataGeneratorFieldEnumerationBase(IDataGeneratorField field) : base(field)
        {
        }

        /// <summary>
        /// Gets the field value.
        /// </summary>
        /// <returns></returns>
        public abstract T? GetTypedValue();

        /// <inheritdoc/>
        public override object? GetRawValue()
        {
            return GetTypedValue();
        }

        /// <inheritdoc/>
        public override bool IsNullValue()
        {
            return !GetTypedValue().HasValue;
        }

    }

}
