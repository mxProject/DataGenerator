using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Buffers;
using System.ComponentModel.Design.Serialization;

namespace mxProject.Devs.DataGeneration.Fields
{

    /// <summary>
    /// Field that generates a tuple of multiple values.
    /// </summary>
    /// <typeparam name="T1">The value type of the first field.</typeparam>
    /// <typeparam name="T2">The value type of the second field.</typeparam>
    public class DataGeneratorTupleFieldEnumeration<T1, T2> : DataGeneratorTupleFieldEnumerationBase<(T1?, T2?)>, IDataGeneratorTupleFieldEnumeration<T1, T2>
        where T1 : struct
        where T2 : struct
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="enumeration">Enumeration of field values.</param>
        public DataGeneratorTupleFieldEnumeration(string fieldName1, string fieldName2, IEnumerable<(T1?, T2?)> enumeration)
            : base(new[] { fieldName1, fieldName2 }, new[] { typeof(T1), typeof(T2) }, enumeration)
        {
        }

        #region value

        /// <inheritdoc/>
        protected override object? GetRawValue(int index)
        {
            var current = GetTypedValues();

            return index switch
            {
                0 => current.Item1,
                1 => current.Item2,
                _ => throw new IndexOutOfRangeException(),
            };
        }

        /// <inheritdoc/>
        protected override bool IsNullValue(int index)
        {
            var current = GetTypedValues();

            return index switch
            {
                0 => !current.Item1.HasValue,
                1 => !current.Item2.HasValue,
                _ => throw new IndexOutOfRangeException(),
            };
        }

        #endregion

    }

}
