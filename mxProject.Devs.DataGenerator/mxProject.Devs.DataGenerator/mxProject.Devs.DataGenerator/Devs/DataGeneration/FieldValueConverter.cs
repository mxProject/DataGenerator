using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Field value converter.
    /// </summary>
    public sealed class FieldValueConverter
    {
        private FieldValueConverter() { }

        /// <summary>
        /// Default instance.
        /// </summary>
        public readonly static FieldValueConverter Default = new FieldValueConverter();

        #region ToTuple

        /// <summary>
        /// Creates a tuple from the values in the specified array.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <param name="values">The array.</param>
        /// <returns></returns>
        public (T1, T2) ToTuple<T1, T2>(object?[] values)
            where T1 : struct
            where T2 : struct
        {
            return (Cast<T1>(values[0]), Cast<T2>(values[1]));
        }

        /// <summary>
        /// Creates a tuple from the values in the specified array.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <param name="values">The array.</param>
        /// <returns></returns>
        public (T1, T2, T3) ToTuple<T1, T2, T3>(object?[] values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            return (Cast<T1>(values[0]), Cast<T2>(values[1]), Cast<T3>(values[2]));
        }

        /// <summary>
        /// Creates a tuple from the values in the specified array.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <param name="values">The array.</param>
        /// <returns></returns>
        public (T1, T2, T3, T4) ToTuple<T1, T2, T3, T4>(object?[] values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            return (Cast<T1>(values[0]), Cast<T2>(values[1]), Cast<T3>(values[2]), Cast<T4>(values[3]));
        }

        /// <summary>
        /// Creates a tuple from the values in the specified array.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <typeparam name="T5">The type of the fifth value.</typeparam>
        /// <param name="values">The array.</param>
        /// <returns></returns>
        public (T1, T2, T3, T4, T5) ToTuple<T1, T2, T3, T4, T5>(object?[] values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            return (Cast<T1>(values[0]), Cast<T2>(values[1]), Cast<T3>(values[2]), Cast<T4>(values[3]), Cast<T5>(values[4]));
        }

        /// <summary>
        /// Creates a tuple from the values in the specified array.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <typeparam name="T5">The type of the fifth value.</typeparam>
        /// <typeparam name="T6">The type of the sixth value.</typeparam>
        /// <param name="values">The array.</param>
        /// <returns></returns>
        public (T1, T2, T3, T4, T5, T6) ToTuple<T1, T2, T3, T4, T5, T6>(object?[] values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            return (Cast<T1>(values[0]), Cast<T2>(values[1]), Cast<T3>(values[2]), Cast<T4>(values[3]), Cast<T5>(values[4]), Cast<T6>(values[5]));
        }

        /// <summary>
        /// Creates a tuple from the values in the specified array.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <typeparam name="T5">The type of the fifth value.</typeparam>
        /// <typeparam name="T6">The type of the sixth value.</typeparam>
        /// <typeparam name="T7">The type of the seventh value.</typeparam>
        /// <param name="values">The array.</param>
        /// <returns></returns>
        public (T1, T2, T3, T4, T5, T6, T7) ToTuple<T1, T2, T3, T4, T5, T6, T7>(object?[] values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            return (Cast<T1>(values[0]), Cast<T2>(values[1]), Cast<T3>(values[2]), Cast<T4>(values[3]), Cast<T5>(values[4]), Cast<T6>(values[5]), Cast<T7>(values[6]));
        }

        /// <summary>
        /// Creates a tuple from the values in the specified array.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <typeparam name="T5">The type of the fifth value.</typeparam>
        /// <typeparam name="T6">The type of the sixth value.</typeparam>
        /// <typeparam name="T7">The type of the seventh value.</typeparam>
        /// <typeparam name="T8">The type of the eighth value.</typeparam>
        /// <param name="values">The array.</param>
        /// <returns></returns>
        public (T1, T2, T3, T4, T5, T6, T7, T8) ToTuple<T1, T2, T3, T4, T5, T6, T7, T8>(object?[] values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            return (Cast<T1>(values[0]), Cast<T2>(values[1]), Cast<T3>(values[2]), Cast<T4>(values[3]), Cast<T5>(values[4]), Cast<T6>(values[5]), Cast<T7>(values[6]), Cast<T8>(values[7]));
        }

        /// <summary>
        /// Creates a tuple from the values in the specified array.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <typeparam name="T5">The type of the fifth value.</typeparam>
        /// <typeparam name="T6">The type of the sixth value.</typeparam>
        /// <typeparam name="T7">The type of the seventh value.</typeparam>
        /// <typeparam name="T8">The type of the eighth value.</typeparam>
        /// <typeparam name="T9">The type of the ninth value.</typeparam>
        /// <param name="values">The array.</param>
        /// <returns></returns>
        public (T1, T2, T3, T4, T5, T6, T7, T8, T9) ToTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(object?[] values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
            where T9 : struct
        {
            return (Cast<T1>(values[0]), Cast<T2>(values[1]), Cast<T3>(values[2]), Cast<T4>(values[3]), Cast<T5>(values[4]), Cast<T6>(values[5]), Cast<T7>(values[6]), Cast<T8>(values[7]), Cast<T9>(values[8]));
        }

        #endregion

        #region ToNullableTuple

        /// <summary>
        /// Creates a tuple from the values in the specified array.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <param name="values">The array.</param>
        /// <returns></returns>
        public (T1?, T2?) ToNullableTuple<T1, T2>(object?[] values)
            where T1 : struct
            where T2 : struct
        {
            return (Cast<T1?>(values[0]), Cast<T2?>(values[1]));
        }

        /// <summary>
        /// Creates a tuple from the values in the specified array.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <param name="values">The array.</param>
        /// <returns></returns>
        public (T1?, T2?, T3?) ToNullableTuple<T1, T2, T3>(object?[] values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            return (Cast<T1?>(values[0]), Cast<T2?>(values[1]), Cast<T3?>(values[2]));
        }

        /// <summary>
        /// Creates a tuple from the values in the specified array.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <param name="values">The array.</param>
        /// <returns></returns>
        public (T1?, T2?, T3?, T4?) ToNullableTuple<T1, T2, T3, T4>(object?[] values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            return (Cast<T1?>(values[0]), Cast<T2?>(values[1]), Cast<T3?>(values[2]), Cast<T4?>(values[3]));
        }

        /// <summary>
        /// Creates a tuple from the values in the specified array.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <typeparam name="T5">The type of the fifth value.</typeparam>
        /// <param name="values">The array.</param>
        /// <returns></returns>
        public (T1?, T2?, T3?, T4?, T5?) ToNullableTuple<T1, T2, T3, T4, T5>(object?[] values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            return (Cast<T1?>(values[0]), Cast<T2?>(values[1]), Cast<T3?>(values[2]), Cast<T4?>(values[3]), Cast<T5?>(values[4]));
        }

        /// <summary>
        /// Creates a tuple from the values in the specified array.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <typeparam name="T5">The type of the fifth value.</typeparam>
        /// <typeparam name="T6">The type of the sixth value.</typeparam>
        /// <param name="values">The array.</param>
        /// <returns></returns>
        public (T1?, T2?, T3?, T4?, T5?, T6?) ToNullableTuple<T1, T2, T3, T4, T5, T6>(object?[] values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            return (Cast<T1?>(values[0]), Cast<T2?>(values[1]), Cast<T3?>(values[2]), Cast<T4?>(values[3]), Cast<T5?>(values[4]), Cast<T6?>(values[5]));
        }

        /// <summary>
        /// Creates a tuple from the values in the specified array.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <typeparam name="T5">The type of the fifth value.</typeparam>
        /// <typeparam name="T6">The type of the sixth value.</typeparam>
        /// <typeparam name="T7">The type of the seventh value.</typeparam>
        /// <param name="values">The array.</param>
        /// <returns></returns>
        public (T1?, T2?, T3?, T4?, T5?, T6?, T7?) ToNullableTuple<T1, T2, T3, T4, T5, T6, T7>(object?[] values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            return (Cast<T1?>(values[0]), Cast<T2?>(values[1]), Cast<T3?>(values[2]), Cast<T4?>(values[3]), Cast<T5?>(values[4]), Cast<T6?>(values[5]), Cast<T7?>(values[6]));
        }

        /// <summary>
        /// Creates a tuple from the values in the specified array.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <typeparam name="T5">The type of the fifth value.</typeparam>
        /// <typeparam name="T6">The type of the sixth value.</typeparam>
        /// <typeparam name="T7">The type of the seventh value.</typeparam>
        /// <typeparam name="T8">The type of the eighth value.</typeparam>
        /// <param name="values">The array.</param>
        /// <returns></returns>
        public (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?) ToNullableTuple<T1, T2, T3, T4, T5, T6, T7, T8>(object?[] values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            return (Cast<T1?>(values[0]), Cast<T2?>(values[1]), Cast<T3?>(values[2]), Cast<T4?>(values[3]), Cast<T5?>(values[4]), Cast<T6?>(values[5]), Cast<T7?>(values[6]), Cast<T8?>(values[7]));
        }

        /// <summary>
        /// Creates a tuple from the values in the specified array.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <typeparam name="T5">The type of the fifth value.</typeparam>
        /// <typeparam name="T6">The type of the sixth value.</typeparam>
        /// <typeparam name="T7">The type of the seventh value.</typeparam>
        /// <typeparam name="T8">The type of the eighth value.</typeparam>
        /// <typeparam name="T9">The type of the ninth value.</typeparam>
        /// <param name="values">The array.</param>
        /// <returns></returns>
        public (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?) ToNullableTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(object?[] values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
            where T9 : struct
        {
            return (Cast<T1?>(values[0]), Cast<T2?>(values[1]), Cast<T3?>(values[2]), Cast<T4?>(values[3]), Cast<T5?>(values[4]), Cast<T6?>(values[5]), Cast<T7?>(values[6]), Cast<T8?>(values[7]), Cast<T9?>(values[8]));
        }

        #endregion

        #region cast

        /// <summary>
        /// Casts the specified value.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public T Cast<T>(object? value)
        {
            if (value == null) { return default!; }

            if (value is T t) { return t; }

            if (typeof(T) == typeof(string))
            {
                return (T)(object)value.ToString()!;
            }
            else if (typeof(T) == typeof(StringValue) || typeof(T) == typeof(StringValue?))
            {
                return (T)(object)new StringValue(value.ToString()!);
            }
            else
            {
                return (T)value;
            }
        }

        #endregion

    }

}
