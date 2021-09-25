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
    /// <typeparam name="T3">The value type of the third field.</typeparam>
    /// <typeparam name="T4">The value type of the fourth field.</typeparam>
    /// <typeparam name="T5">The value type of the fifth field.</typeparam>
    /// <typeparam name="T6">The value type of the sixth field.</typeparam>
    /// <typeparam name="T7">The value type of the seventh field.</typeparam>
    /// <typeparam name="T8">The value type of the eighth field.</typeparam>
    public class DataGeneratorTupleFieldEnumeration<T1, T2, T3, T4, T5, T6, T7, T8> : DataGeneratorTupleFieldEnumerationBase<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)>, IDataGeneratorTupleFieldEnumeration<T1, T2, T3, T4, T5, T6, T7, T8>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
        where T7 : struct
        where T8 : struct
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="fieldName4">The name of the fourth field.</param>
        /// <param name="fieldName5">The name of the fifth field.</param>
        /// <param name="fieldName6">The name of the sixth field.</param>
        /// <param name="fieldName7">The name of the seventh field.</param>
        /// <param name="fieldName8">The name of the eighth field.</param>
        /// <param name="enumeration">Enumeration of field values.</param>
        public DataGeneratorTupleFieldEnumeration(string fieldName1, string fieldName2, string fieldName3, string fieldName4, string fieldName5, string fieldName6, string fieldName7, string fieldName8, IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)> enumeration)
            : base(new[] { fieldName1, fieldName2, fieldName3, fieldName4, fieldName5, fieldName6, fieldName7, fieldName8 }, new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) }, enumeration)
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
                2 => current.Item3,
                3 => current.Item4,
                4 => current.Item5,
                5 => current.Item6,
                6 => current.Item7,
                7 => current.Item8,
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
                2 => !current.Item3.HasValue,
                3 => !current.Item4.HasValue,
                4 => !current.Item5.HasValue,
                5 => !current.Item6.HasValue,
                6 => !current.Item7.HasValue,
                7 => !current.Item8.HasValue,
                _ => throw new IndexOutOfRangeException(),
            };
        }

        #endregion

    }

}
