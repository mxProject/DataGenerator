using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// 
    /// </summary>
    internal static class TupleExtensions
    {

        #region ToNullable

        internal static (T1?, T2?) ToNullable<T1, T2>(this (T1, T2) tuple)
            where T1 : struct
            where T2 : struct
        {
            return (tuple.Item1, tuple.Item2);
        }

        internal static (T1?, T2?, T3?) ToNullable<T1, T2, T3>(this (T1, T2, T3) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            return (tuple.Item1, tuple.Item2, tuple.Item3);
        }

        internal static (T1?, T2?, T3?, T4?) ToNullable<T1, T2, T3, T4>(this (T1, T2, T3, T4) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            return (tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
        }

        internal static (T1?, T2?, T3?, T4?, T5?) ToNullable<T1, T2, T3, T4, T5>(this (T1, T2, T3, T4, T5) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            return (tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5);
        }

        internal static (T1?, T2?, T3?, T4?, T5?, T6?) ToNullable<T1, T2, T3, T4, T5, T6>(this (T1, T2, T3, T4, T5, T6) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            return (tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6);
        }

        internal static (T1?, T2?, T3?, T4?, T5?, T6?, T7?) ToNullable<T1, T2, T3, T4, T5, T6, T7>(this (T1, T2, T3, T4, T5, T6, T7) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            return (tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7);
        }

        internal static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?) ToNullable<T1, T2, T3, T4, T5, T6, T7, T8>(this (T1, T2, T3, T4, T5, T6, T7, T8) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            return (tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8);
        }

        internal static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?) ToNullable<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this (T1, T2, T3, T4, T5, T6, T7, T8, T9) tuple)
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
            return (tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9);
        }

        #endregion

        #region ToValueOrDefault

        internal static (T1, T2) ToValueOrDefault<T1, T2>(this (T1?, T2?) tuple)
            where T1 : struct
            where T2 : struct
        {
            return (
                tuple.Item1.GetValueOrDefault(),
                tuple.Item2.GetValueOrDefault()
                );
        }

        internal static (T1, T2, T3) ToValueOrDefault<T1, T2, T3>(this (T1?, T2?, T3?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            return (
                tuple.Item1.GetValueOrDefault(),
                tuple.Item2.GetValueOrDefault(),
                tuple.Item3.GetValueOrDefault()
                );
        }

        internal static (T1, T2, T3, T4) ToValueOrDefault<T1, T2, T3, T4>(this (T1?, T2?, T3?, T4?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            return (
                tuple.Item1.GetValueOrDefault(),
                tuple.Item2.GetValueOrDefault(),
                tuple.Item3.GetValueOrDefault(),
                tuple.Item4.GetValueOrDefault()
                );
        }

        internal static (T1, T2, T3, T4, T5) ToValueOrDefault<T1, T2, T3, T4, T5>(this (T1?, T2?, T3?, T4?, T5?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            return (
                tuple.Item1.GetValueOrDefault(),
                tuple.Item2.GetValueOrDefault(),
                tuple.Item3.GetValueOrDefault(),
                tuple.Item4.GetValueOrDefault(),
                tuple.Item5.GetValueOrDefault()
                );
        }

        internal static (T1, T2, T3, T4, T5, T6) ToValueOrDefault<T1, T2, T3, T4, T5, T6>(this (T1?, T2?, T3?, T4?, T5?, T6?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            return (
                tuple.Item1.GetValueOrDefault(),
                tuple.Item2.GetValueOrDefault(),
                tuple.Item3.GetValueOrDefault(),
                tuple.Item4.GetValueOrDefault(),
                tuple.Item5.GetValueOrDefault(),
                tuple.Item6.GetValueOrDefault()
                );
        }

        internal static (T1, T2, T3, T4, T5, T6, T7) ToValueOrDefault<T1, T2, T3, T4, T5, T6, T7>(this (T1?, T2?, T3?, T4?, T5?, T6?, T7?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            return (
                tuple.Item1.GetValueOrDefault(),
                tuple.Item2.GetValueOrDefault(),
                tuple.Item3.GetValueOrDefault(),
                tuple.Item4.GetValueOrDefault(),
                tuple.Item5.GetValueOrDefault(),
                tuple.Item6.GetValueOrDefault(),
                tuple.Item7.GetValueOrDefault()
                );
        }

        internal static (T1, T2, T3, T4, T5, T6, T7, T8) ToValueOrDefault<T1, T2, T3, T4, T5, T6, T7, T8>(this (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            return (
                tuple.Item1.GetValueOrDefault(),
                tuple.Item2.GetValueOrDefault(),
                tuple.Item3.GetValueOrDefault(),
                tuple.Item4.GetValueOrDefault(),
                tuple.Item5.GetValueOrDefault(),
                tuple.Item6.GetValueOrDefault(),
                tuple.Item7.GetValueOrDefault(),
                tuple.Item8.GetValueOrDefault()
                );
        }

        internal static (T1, T2, T3, T4, T5, T6, T7, T8, T9) ToValueOrDefault<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?) tuple)
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
            return (
                tuple.Item1.GetValueOrDefault(),
                tuple.Item2.GetValueOrDefault(),
                tuple.Item3.GetValueOrDefault(),
                tuple.Item4.GetValueOrDefault(),
                tuple.Item5.GetValueOrDefault(),
                tuple.Item6.GetValueOrDefault(),
                tuple.Item7.GetValueOrDefault(),
                tuple.Item8.GetValueOrDefault(),
                tuple.Item9.GetValueOrDefault()
                );
        }

        #endregion

        #region FromNullable

        internal static (T1, T2) FromNullable<T1, T2>(this (T1?, T2?) tuple)
            where T1 : struct
            where T2 : struct
        {
            return (tuple.Item1!.Value, tuple.Item2!.Value);
        }

        internal static (T1, T2, T3) FromNullable<T1, T2, T3>(this (T1?, T2?, T3?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            return (tuple.Item1!.Value, tuple.Item2!.Value, tuple.Item3!.Value);
        }

        internal static (T1, T2, T3, T4) FromNullable<T1, T2, T3, T4>(this (T1?, T2?, T3?, T4?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            return (tuple.Item1!.Value, tuple.Item2!.Value, tuple.Item3!.Value, tuple.Item4!.Value);
        }

        internal static (T1, T2, T3, T4, T5) FromNullable<T1, T2, T3, T4, T5>(this (T1?, T2?, T3?, T4?, T5?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            return (tuple.Item1!.Value, tuple.Item2!.Value, tuple.Item3!.Value, tuple.Item4!.Value, tuple.Item5!.Value);
        }

        internal static (T1, T2, T3, T4, T5, T6) FromNullable<T1, T2, T3, T4, T5, T6>(this (T1?, T2?, T3?, T4?, T5?, T6?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            return (tuple.Item1!.Value, tuple.Item2!.Value, tuple.Item3!.Value, tuple.Item4!.Value, tuple.Item5!.Value, tuple.Item6!.Value);
        }

        internal static (T1, T2, T3, T4, T5, T6, T7) FromNullable<T1, T2, T3, T4, T5, T6, T7>(this (T1?, T2?, T3?, T4?, T5?, T6?, T7?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            return (tuple.Item1!.Value, tuple.Item2!.Value, tuple.Item3!.Value, tuple.Item4!.Value, tuple.Item5!.Value, tuple.Item6!.Value, tuple.Item7!.Value);
        }

        internal static (T1, T2, T3, T4, T5, T6, T7, T8) FromNullable<T1, T2, T3, T4, T5, T6, T7, T8>(this (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            return (tuple.Item1!.Value, tuple.Item2!.Value, tuple.Item3!.Value, tuple.Item4!.Value, tuple.Item5!.Value, tuple.Item6!.Value, tuple.Item7!.Value, tuple.Item8!.Value);
        }

        internal static (T1, T2, T3, T4, T5, T6, T7, T8, T9) FromNullable<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?) tuple)
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
            return (tuple.Item1!.Value, tuple.Item2!.Value, tuple.Item3!.Value, tuple.Item4!.Value, tuple.Item5!.Value, tuple.Item6!.Value, tuple.Item7!.Value, tuple.Item8!.Value, tuple.Item9!.Value);
        }

        #endregion

        #region ToObjectArray

        internal static object?[] ToObjectArray<T1, T2>(this (T1, T2) tuple)
        {
            return new object?[] {
                tuple.Item1,
                tuple.Item2
            };
        }

        internal static object?[] ToObjectArray<T1, T2>(this (T1?, T2?) tuple)
            where T1 : struct
            where T2 : struct
        {
            return new object?[] {
                tuple.Item1,
                tuple.Item2
            };
        }

        internal static object?[] ToObjectArray<T1, T2, T3>(this (T1, T2, T3) tuple)
        {
            return new object?[] {
                tuple.Item1,
                tuple.Item2,
                tuple.Item3
            };
        }

        internal static object?[] ToObjectArray<T1, T2, T3>(this (T1?, T2?, T3?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            return new object?[] {
                tuple.Item1,
                tuple.Item2,
                tuple.Item3
            };
        }

        internal static object?[] ToObjectArray<T1, T2, T3, T4>(this (T1, T2, T3, T4) tuple)
        {
            return new object?[] {
                tuple.Item1,
                tuple.Item2,
                tuple.Item3,
                tuple.Item4
            };
        }

        internal static object?[] ToObjectArray<T1, T2, T3, T4>(this (T1?, T2?, T3?, T4?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            return new object?[] {
                tuple.Item1,
                tuple.Item2,
                tuple.Item3,
                tuple.Item4
            };
        }

        internal static object?[] ToObjectArray<T1, T2, T3, T4, T5>(this (T1, T2, T3, T4, T5) tuple)
        {
            return new object?[] {
                tuple.Item1,
                tuple.Item2,
                tuple.Item3,
                tuple.Item4,
                tuple.Item5
            };
        }

        internal static object?[] ToObjectArray<T1, T2, T3, T4, T5>(this (T1?, T2?, T3?, T4?, T5?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            return new object?[] {
                tuple.Item1,
                tuple.Item2,
                tuple.Item3,
                tuple.Item4,
                tuple.Item5
            };
        }

        internal static object?[] ToObjectArray<T1, T2, T3, T4, T5, T6>(this (T1, T2, T3, T4, T5, T6) tuple)
        {
            return new object?[] {
                tuple.Item1,
                tuple.Item2,
                tuple.Item3,
                tuple.Item4,
                tuple.Item5,
                tuple.Item6
            };
        }

        internal static object?[] ToObjectArray<T1, T2, T3, T4, T5, T6>(this (T1?, T2?, T3?, T4?, T5?, T6?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            return new object?[] {
                tuple.Item1,
                tuple.Item2,
                tuple.Item3,
                tuple.Item4,
                tuple.Item5,
                tuple.Item6
            };
        }

        internal static object?[] ToObjectArray<T1, T2, T3, T4, T5, T6, T7>(this (T1, T2, T3, T4, T5, T6, T7) tuple)
        {
            return new object?[] {
                tuple.Item1,
                tuple.Item2,
                tuple.Item3,
                tuple.Item4,
                tuple.Item5,
                tuple.Item6,
                tuple.Item7
            };
        }

        internal static object?[] ToObjectArray<T1, T2, T3, T4, T5, T6, T7>(this (T1?, T2?, T3?, T4?, T5?, T6?, T7?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            return new object?[] {
                tuple.Item1,
                tuple.Item2,
                tuple.Item3,
                tuple.Item4,
                tuple.Item5,
                tuple.Item6,
                tuple.Item7
            };
        }

        internal static object?[] ToObjectArray<T1, T2, T3, T4, T5, T6, T7, T8>(this (T1, T2, T3, T4, T5, T6, T7, T8) tuple)
        {
            return new object?[] {
                tuple.Item1,
                tuple.Item2,
                tuple.Item3,
                tuple.Item4,
                tuple.Item5,
                tuple.Item6,
                tuple.Item7,
                tuple.Item8
            };
        }

        internal static object?[] ToObjectArray<T1, T2, T3, T4, T5, T6, T7, T8>(this (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            return new object?[] {
                tuple.Item1,
                tuple.Item2,
                tuple.Item3,
                tuple.Item4,
                tuple.Item5,
                tuple.Item6,
                tuple.Item7,
                tuple.Item8
            };
        }

        internal static object?[] ToObjectArray<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this (T1, T2, T3, T4, T5, T6, T7, T8, T9) tuple)
        {
            return new object?[] {
                tuple.Item1,
                tuple.Item2,
                tuple.Item3,
                tuple.Item4,
                tuple.Item5,
                tuple.Item6,
                tuple.Item7,
                tuple.Item8,
                tuple.Item9
            };
        }

        internal static object?[] ToObjectArray<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?) tuple)
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
            return new object?[] {
                tuple.Item1,
                tuple.Item2,
                tuple.Item3,
                tuple.Item4,
                tuple.Item5,
                tuple.Item6,
                tuple.Item7,
                tuple.Item8,
                tuple.Item9
            };
        }

        #endregion

        #region ToStringArray

        internal static string?[] ToStringArray<T1, T2>(this (T1, T2) tuple)
        {
            return new string?[] {
                tuple.Item1?.ToString(),
                tuple.Item2?.ToString()
            };
        }

        internal static string?[] ToStringArray<T1, T2>(this (T1?, T2?) tuple)
            where T1 : struct
            where T2 : struct
        {
            return new string?[] {
                tuple.Item1.ToString(),
                tuple.Item2.ToString()
            };
        }

        internal static string?[] ToStringArray<T1, T2, T3>(this (T1, T2, T3) tuple)
        {
            return new string?[] {
                tuple.Item1?.ToString(),
                tuple.Item2?.ToString(),
                tuple.Item3?.ToString()
            };
        }

        internal static string?[] ToStringArray<T1, T2, T3>(this (T1?, T2?, T3?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            return new string?[] {
                tuple.Item1.ToString(),
                tuple.Item2.ToString(),
                tuple.Item3.ToString()
            };
        }

        internal static string?[] ToStringArray<T1, T2, T3, T4>(this (T1, T2, T3, T4) tuple)
        {
            return new string?[] {
                tuple.Item1?.ToString(),
                tuple.Item2?.ToString(),
                tuple.Item3?.ToString(),
                tuple.Item4?.ToString()
            };
        }

        internal static string?[] ToStringArray<T1, T2, T3, T4>(this (T1?, T2?, T3?, T4?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            return new string?[] {
                tuple.Item1.ToString(),
                tuple.Item2.ToString(),
                tuple.Item3.ToString(),
                tuple.Item4.ToString()
            };
        }

        internal static string?[] ToStringArray<T1, T2, T3, T4, T5>(this (T1, T2, T3, T4, T5) tuple)
        {
            return new string?[] {
                tuple.Item1?.ToString(),
                tuple.Item2?.ToString(),
                tuple.Item3?.ToString(),
                tuple.Item4?.ToString(),
                tuple.Item5?.ToString()
            };
        }

        internal static string?[] ToStringArray<T1, T2, T3, T4, T5>(this (T1?, T2?, T3?, T4?, T5?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            return new string?[] {
                tuple.Item1.ToString(),
                tuple.Item2.ToString(),
                tuple.Item3.ToString(),
                tuple.Item4.ToString(),
                tuple.Item5.ToString()
            };
        }

        internal static string?[] ToStringArray<T1, T2, T3, T4, T5, T6>(this (T1, T2, T3, T4, T5, T6) tuple)
        {
            return new string?[] {
                tuple.Item1?.ToString(),
                tuple.Item2?.ToString(),
                tuple.Item3?.ToString(),
                tuple.Item4?.ToString(),
                tuple.Item5?.ToString(),
                tuple.Item6?.ToString()
            };
        }

        internal static string?[] ToStringArray<T1, T2, T3, T4, T5, T6>(this (T1?, T2?, T3?, T4?, T5?, T6?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            return new string?[] {
                tuple.Item1.ToString(),
                tuple.Item2.ToString(),
                tuple.Item3.ToString(),
                tuple.Item4.ToString(),
                tuple.Item5.ToString(),
                tuple.Item6.ToString()
            };
        }

        internal static string?[] ToStringArray<T1, T2, T3, T4, T5, T6, T7>(this (T1, T2, T3, T4, T5, T6, T7) tuple)
        {
            return new string?[] {
                tuple.Item1?.ToString(),
                tuple.Item2?.ToString(),
                tuple.Item3?.ToString(),
                tuple.Item4?.ToString(),
                tuple.Item5?.ToString(),
                tuple.Item6?.ToString(),
                tuple.Item7?.ToString()
            };
        }

        internal static string?[] ToStringArray<T1, T2, T3, T4, T5, T6, T7>(this (T1?, T2?, T3?, T4?, T5?, T6?, T7?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            return new string?[] {
                tuple.Item1.ToString(),
                tuple.Item2.ToString(),
                tuple.Item3.ToString(),
                tuple.Item4.ToString(),
                tuple.Item5.ToString(),
                tuple.Item6.ToString(),
                tuple.Item7.ToString()
            };
        }

        internal static string?[] ToStringArray<T1, T2, T3, T4, T5, T6, T7, T8>(this (T1, T2, T3, T4, T5, T6, T7, T8) tuple)
        {
            return new string?[] {
                tuple.Item1?.ToString(),
                tuple.Item2?.ToString(),
                tuple.Item3?.ToString(),
                tuple.Item4?.ToString(),
                tuple.Item5?.ToString(),
                tuple.Item6?.ToString(),
                tuple.Item7?.ToString(),
                tuple.Item8?.ToString()
            };
        }

        internal static string?[] ToStringArray<T1, T2, T3, T4, T5, T6, T7, T8>(this (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            return new string?[] {
                tuple.Item1.ToString(),
                tuple.Item2.ToString(),
                tuple.Item3.ToString(),
                tuple.Item4.ToString(),
                tuple.Item5.ToString(),
                tuple.Item6.ToString(),
                tuple.Item7.ToString(),
                tuple.Item8.ToString()
            };
        }

        internal static string?[] ToStringArray<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this (T1, T2, T3, T4, T5, T6, T7, T8, T9) tuple)
        {
            return new string?[] {
                tuple.Item1?.ToString(),
                tuple.Item2?.ToString(),
                tuple.Item3?.ToString(),
                tuple.Item4?.ToString(),
                tuple.Item5?.ToString(),
                tuple.Item6?.ToString(),
                tuple.Item7?.ToString(),
                tuple.Item8?.ToString(),
                tuple.Item9?.ToString()
            };
        }

        internal static string?[] ToStringArray<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?) tuple)
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
            return new string?[] {
                tuple.Item1.ToString(),
                tuple.Item2.ToString(),
                tuple.Item3.ToString(),
                tuple.Item4.ToString(),
                tuple.Item5.ToString(),
                tuple.Item6.ToString(),
                tuple.Item7.ToString(),
                tuple.Item8.ToString(),
                tuple.Item9.ToString()
            };
        }

        #endregion

        #region ToObjectArrayList

        internal static IList<object?[]> ToObjectArrayList<T1, T2>(this IEnumerable<(T1, T2)> values)
        {
            var list = new List<object?[]>();

            foreach (var tuple in values)
            {
                list.Add(tuple.ToObjectArray());
            }

            return list;
        }

        internal static IList<object?[]> ToObjectArrayList<T1, T2, T3>(this IEnumerable<(T1, T2, T3)> values)
        {
            var list = new List<object?[]>();

            foreach (var tuple in values)
            {
                list.Add(tuple.ToObjectArray());
            }

            return list;
        }

        internal static IList<object?[]> ToObjectArrayList<T1, T2, T3, T4>(this IEnumerable<(T1, T2, T3, T4)> values)
        {
            var list = new List<object?[]>();

            foreach (var tuple in values)
            {
                list.Add(tuple.ToObjectArray());
            }

            return list;
        }

        internal static IList<object?[]> ToObjectArrayList<T1, T2, T3, T4, T5>(this IEnumerable<(T1, T2, T3, T4, T5)> values)
        {
            var list = new List<object?[]>();

            foreach (var tuple in values)
            {
                list.Add(tuple.ToObjectArray());
            }

            return list;
        }

        internal static IList<object?[]> ToObjectArrayList<T1, T2, T3, T4, T5, T6>(this IEnumerable<(T1, T2, T3, T4, T5, T6)> values)
        {
            var list = new List<object?[]>();

            foreach (var tuple in values)
            {
                list.Add(tuple.ToObjectArray());
            }

            return list;
        }

        internal static IList<object?[]> ToObjectArrayList<T1, T2, T3, T4, T5, T6, T7>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7)> values)
        {
            var list = new List<object?[]>();

            foreach (var tuple in values)
            {
                list.Add(tuple.ToObjectArray());
            }

            return list;
        }

        internal static IList<object?[]> ToObjectArrayList<T1, T2, T3, T4, T5, T6, T7, T8>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8)> values)
        {
            var list = new List<object?[]>();

            foreach (var tuple in values)
            {
                list.Add(tuple.ToObjectArray());
            }

            return list;
        }

        internal static IList<object?[]> ToObjectArrayList<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> values)
        {
            var list = new List<object?[]>();

            foreach (var tuple in values)
            {
                list.Add(tuple.ToObjectArray());
            }

            return list;
        }

        #endregion

        #region ToStringArrayList

        internal static IList<string?[]> ToStringArrayList<T1, T2>(this IEnumerable<(T1, T2)> values)
        {
            var list = new List<string?[]>();

            foreach (var tuple in values)
            {
                list.Add(tuple.ToStringArray());
            }

            return list;
        }

        internal static IList<string?[]> ToStringArrayList<T1, T2, T3>(this IEnumerable<(T1, T2, T3)> values)
        {
            var list = new List<string?[]>();

            foreach (var tuple in values)
            {
                list.Add(tuple.ToStringArray());
            }

            return list;
        }

        internal static IList<string?[]> ToStringArrayList<T1, T2, T3, T4>(this IEnumerable<(T1, T2, T3, T4)> values)
        {
            var list = new List<string?[]>();

            foreach (var tuple in values)
            {
                list.Add(tuple.ToStringArray());
            }

            return list;
        }

        internal static IList<string?[]> ToStringArrayList<T1, T2, T3, T4, T5>(this IEnumerable<(T1, T2, T3, T4, T5)> values)
        {
            var list = new List<string?[]>();

            foreach (var tuple in values)
            {
                list.Add(tuple.ToStringArray());
            }

            return list;
        }

        internal static IList<string?[]> ToStringArrayList<T1, T2, T3, T4, T5, T6>(this IEnumerable<(T1, T2, T3, T4, T5, T6)> values)
        {
            var list = new List<string?[]>();

            foreach (var tuple in values)
            {
                list.Add(tuple.ToStringArray());
            }

            return list;
        }

        internal static IList<string?[]> ToStringArrayList<T1, T2, T3, T4, T5, T6, T7>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7)> values)
        {
            var list = new List<string?[]>();

            foreach (var tuple in values)
            {
                list.Add(tuple.ToStringArray());
            }

            return list;
        }

        internal static IList<string?[]> ToStringArrayList<T1, T2, T3, T4, T5, T6, T7, T8>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8)> values)
        {
            var list = new List<string?[]>();

            foreach (var tuple in values)
            {
                list.Add(tuple.ToStringArray());
            }

            return list;
        }

        internal static IList<string?[]> ToStringArrayList<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> values)
        {
            var list = new List<string?[]>();

            foreach (var tuple in values)
            {
                list.Add(tuple.ToStringArray());
            }

            return list;
        }

        #endregion

        #region HasAllValues

        /// <summary>
        /// Gets a value that indicates whether all elements of the specified tuple have values. 
        /// </summary>
        /// <typeparam name="T1">The type of the first value of the tuple.</typeparam>
        /// <typeparam name="T2">The type of the second value of the tuple.</typeparam>
        /// <returns></returns>
        internal static bool HasAllValues<T1, T2>(this (T1?, T2?) tuple)
            where T1 : struct
            where T2 : struct
        {
            if (!tuple.Item1.HasValue) { return false; }
            if (!tuple.Item2.HasValue) { return false; }

            return true;
        }

        /// <summary>
        /// Gets a value that indicates whether all elements of the specified tuple have values. 
        /// </summary>
        /// <typeparam name="T1">The type of the first value of the tuple.</typeparam>
        /// <typeparam name="T2">The type of the second value of the tuple.</typeparam>
        /// <typeparam name="T3">The type of the third value of the tuple.</typeparam>
        /// <returns></returns>
        internal static bool HasAllValues<T1, T2, T3>(this (T1?, T2?, T3?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            if (!tuple.Item1.HasValue) { return false; }
            if (!tuple.Item2.HasValue) { return false; }
            if (!tuple.Item3.HasValue) { return false; }

            return true;
        }

        /// <summary>
        /// Gets a value that indicates whether all elements of the specified tuple have values. 
        /// </summary>
        /// <typeparam name="T1">The type of the first value of the tuple.</typeparam>
        /// <typeparam name="T2">The type of the second value of the tuple.</typeparam>
        /// <typeparam name="T3">The type of the third value of the tuple.</typeparam>
        /// <typeparam name="T4">The type of the fourth value of the tuple.</typeparam>
        /// <returns></returns>
        internal static bool HasAllValues<T1, T2, T3, T4>(this (T1?, T2?, T3?, T4?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            if (!tuple.Item1.HasValue) { return false; }
            if (!tuple.Item2.HasValue) { return false; }
            if (!tuple.Item3.HasValue) { return false; }
            if (!tuple.Item4.HasValue) { return false; }

            return true;
        }

        /// <summary>
        /// Gets a value that indicates whether all elements of the specified tuple have values. 
        /// </summary>
        /// <typeparam name="T1">The type of the first value of the tuple.</typeparam>
        /// <typeparam name="T2">The type of the second value of the tuple.</typeparam>
        /// <typeparam name="T3">The type of the third value of the tuple.</typeparam>
        /// <typeparam name="T4">The type of the fourth value of the tuple.</typeparam>
        /// <typeparam name="T5">The type of the fifth value of the tuple.</typeparam>
        /// <returns></returns>
        internal static bool HasAllValues<T1, T2, T3, T4, T5>(this (T1?, T2?, T3?, T4?, T5?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            if (!tuple.Item1.HasValue) { return false; }
            if (!tuple.Item2.HasValue) { return false; }
            if (!tuple.Item3.HasValue) { return false; }
            if (!tuple.Item4.HasValue) { return false; }
            if (!tuple.Item5.HasValue) { return false; }

            return true;
        }

        /// <summary>
        /// Gets a value that indicates whether all elements of the specified tuple have values. 
        /// </summary>
        /// <typeparam name="T1">The type of the first value of the tuple.</typeparam>
        /// <typeparam name="T2">The type of the second value of the tuple.</typeparam>
        /// <typeparam name="T3">The type of the third value of the tuple.</typeparam>
        /// <typeparam name="T4">The type of the fourth value of the tuple.</typeparam>
        /// <typeparam name="T5">The type of the fifth value of the tuple.</typeparam>
        /// <typeparam name="T6">The type of the sixth value of the tuple.</typeparam>
        /// <returns></returns>
        internal static bool HasAllValues<T1, T2, T3, T4, T5, T6>(this (T1?, T2?, T3?, T4?, T5?, T6?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            if (!tuple.Item1.HasValue) { return false; }
            if (!tuple.Item2.HasValue) { return false; }
            if (!tuple.Item3.HasValue) { return false; }
            if (!tuple.Item4.HasValue) { return false; }
            if (!tuple.Item5.HasValue) { return false; }
            if (!tuple.Item6.HasValue) { return false; }

            return true;
        }

        /// <summary>
        /// Gets a value that indicates whether all elements of the specified tuple have values. 
        /// </summary>
        /// <typeparam name="T1">The type of the first value of the tuple.</typeparam>
        /// <typeparam name="T2">The type of the second value of the tuple.</typeparam>
        /// <typeparam name="T3">The type of the third value of the tuple.</typeparam>
        /// <typeparam name="T4">The type of the fourth value of the tuple.</typeparam>
        /// <typeparam name="T5">The type of the fifth value of the tuple.</typeparam>
        /// <typeparam name="T6">The type of the sixth value of the tuple.</typeparam>
        /// <typeparam name="T7">The type of the seventh value of the tuple.</typeparam>
        /// <returns></returns>
        internal static bool HasAllValues<T1, T2, T3, T4, T5, T6, T7>(this (T1?, T2?, T3?, T4?, T5?, T6?, T7?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            if (!tuple.Item1.HasValue) { return false; }
            if (!tuple.Item2.HasValue) { return false; }
            if (!tuple.Item3.HasValue) { return false; }
            if (!tuple.Item4.HasValue) { return false; }
            if (!tuple.Item5.HasValue) { return false; }
            if (!tuple.Item6.HasValue) { return false; }
            if (!tuple.Item7.HasValue) { return false; }

            return true;
        }

        /// <summary>
        /// Gets a value that indicates whether all elements of the specified tuple have values. 
        /// </summary>
        /// <typeparam name="T1">The type of the first value of the tuple.</typeparam>
        /// <typeparam name="T2">The type of the second value of the tuple.</typeparam>
        /// <typeparam name="T3">The type of the third value of the tuple.</typeparam>
        /// <typeparam name="T4">The type of the fourth value of the tuple.</typeparam>
        /// <typeparam name="T5">The type of the fifth value of the tuple.</typeparam>
        /// <typeparam name="T6">The type of the sixth value of the tuple.</typeparam>
        /// <typeparam name="T7">The type of the seventh value of the tuple.</typeparam>
        /// <typeparam name="T8">The type of the eighth value of the tuple.</typeparam>
        /// <returns></returns>
        internal static bool HasAllValues<T1, T2, T3, T4, T5, T6, T7, T8>(this (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?) tuple)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            if (!tuple.Item1.HasValue) { return false; }
            if (!tuple.Item2.HasValue) { return false; }
            if (!tuple.Item3.HasValue) { return false; }
            if (!tuple.Item4.HasValue) { return false; }
            if (!tuple.Item5.HasValue) { return false; }
            if (!tuple.Item6.HasValue) { return false; }
            if (!tuple.Item7.HasValue) { return false; }
            if (!tuple.Item8.HasValue) { return false; }

            return true;
        }

        /// <summary>
        /// Gets a value that indicates whether all elements of the specified tuple have values. 
        /// </summary>
        /// <typeparam name="T1">The type of the first value of the tuple.</typeparam>
        /// <typeparam name="T2">The type of the second value of the tuple.</typeparam>
        /// <typeparam name="T3">The type of the third value of the tuple.</typeparam>
        /// <typeparam name="T4">The type of the fourth value of the tuple.</typeparam>
        /// <typeparam name="T5">The type of the fifth value of the tuple.</typeparam>
        /// <typeparam name="T6">The type of the sixth value of the tuple.</typeparam>
        /// <typeparam name="T7">The type of the seventh value of the tuple.</typeparam>
        /// <typeparam name="T8">The type of the eighth value of the tuple.</typeparam>
        /// <typeparam name="T9">The type of the ninth value of the tuple.</typeparam>
        /// <returns></returns>
        internal static bool HasAllValues<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?) tuple)
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
            if (!tuple.Item1.HasValue) { return false; }
            if (!tuple.Item2.HasValue) { return false; }
            if (!tuple.Item3.HasValue) { return false; }
            if (!tuple.Item4.HasValue) { return false; }
            if (!tuple.Item5.HasValue) { return false; }
            if (!tuple.Item6.HasValue) { return false; }
            if (!tuple.Item7.HasValue) { return false; }
            if (!tuple.Item8.HasValue) { return false; }
            if (!tuple.Item9.HasValue) { return false; }

            return true;
        }

        #endregion

    }

}
