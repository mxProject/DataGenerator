using System;
using System.Collections.Generic;
using System.Text;
using mxProject.Devs.DataGeneration;

namespace UnitTestProject1.Extensions
{
    internal static class TupleExtensions
    {

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


    }
}
