using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Entension methods for <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class EnumerableExtensions
    {

        #region AsNullable

        /// <summary>
        /// Converts to <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<T?> AsNullable<T>(this IEnumerable<T> values)
            where T : struct
        {
            foreach (var value in values)
            {
                yield return value;
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?)> AsNullable<T1, T2>(this IEnumerable<(T1, T2)> values)
            where T1 : struct
            where T2 : struct
        {
            foreach (var value in values)
            {
                yield return (value.Item1, value.Item2);
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?)> AsNullable<T1, T2>(this IEnumerable<(T1, T2)?> values)
            where T1 : struct
            where T2 : struct
        {
            foreach (var value in values)
            {
                if (value.HasValue)
                {
                    yield return (value.Value.Item1, value.Value.Item2);
                }
                else
                {
                    yield return (null, null);
                }
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?)> AsSimplify<T1, T2>(this IEnumerable<(T1?, T2?)?> values)
            where T1 : struct
            where T2 : struct
        {
            foreach (var value in values)
            {
                if (value.HasValue)
                {
                    yield return (value.Value.Item1, value.Value.Item2);
                }
                else
                {
                    yield return (null, null);
                }
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?)> AsNullable<T1, T2, T3>(this IEnumerable<(T1, T2, T3)> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            foreach (var value in values)
            {
                yield return (value.Item1, value.Item2, value.Item3);
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?)> AsNullable<T1, T2, T3>(this IEnumerable<(T1, T2, T3)?> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            foreach (var value in values)
            {
                if (value.HasValue)
                {
                    yield return (value.Value.Item1, value.Value.Item2, value.Value.Item3);
                }
                else
                {
                    yield return (null, null, null);
                }
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?)> AsSimplify<T1, T2, T3>(this IEnumerable<(T1?, T2?, T3?)?> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            foreach (var value in values)
            {
                if (value.HasValue)
                {
                    yield return (value.Value.Item1, value.Value.Item2, value.Value.Item3);
                }
                else
                {
                    yield return (null, null, null);
                }
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?, T4?)> AsNullable<T1, T2, T3, T4>(this IEnumerable<(T1, T2, T3, T4)> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            foreach (var value in values)
            {
                yield return (value.Item1, value.Item2, value.Item3, value.Item4);
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?, T4?)> AsNullable<T1, T2, T3, T4>(this IEnumerable<(T1, T2, T3, T4)?> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            foreach (var value in values)
            {
                if (value.HasValue)
                {
                    yield return (value.Value.Item1, value.Value.Item2, value.Value.Item3, value.Value.Item4);
                }
                else
                {
                    yield return (null, null, null, null);
                }
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?, T4?)> AsSimplify<T1, T2, T3, T4>(this IEnumerable<(T1?, T2?, T3?, T4?)?> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            foreach (var value in values)
            {
                if (value.HasValue)
                {
                    yield return (value.Value.Item1, value.Value.Item2, value.Value.Item3, value.Value.Item4);
                }
                else
                {
                    yield return (null, null, null, null);
                }
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?, T4?, T5?)> AsNullable<T1, T2, T3, T4, T5>(this IEnumerable<(T1, T2, T3, T4, T5)> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            foreach (var value in values)
            {
                yield return (value.Item1, value.Item2, value.Item3, value.Item4, value.Item5);
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?, T4?, T5?)> AsNullable<T1, T2, T3, T4, T5>(this IEnumerable<(T1, T2, T3, T4, T5)?> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            foreach (var value in values)
            {
                if (value.HasValue)
                {
                    yield return (value.Value.Item1, value.Value.Item2, value.Value.Item3, value.Value.Item4, value.Value.Item5);
                }
                else
                {
                    yield return (null, null, null, null, null);
                }
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?, T4?, T5?)> AsSimplify<T1, T2, T3, T4, T5>(this IEnumerable<(T1?, T2?, T3?, T4?, T5?)?> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            foreach (var value in values)
            {
                if (value.HasValue)
                {
                    yield return (value.Value.Item1, value.Value.Item2, value.Value.Item3, value.Value.Item4, value.Value.Item5);
                }
                else
                {
                    yield return (null, null, null, null, null);
                }
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)> AsNullable<T1, T2, T3, T4, T5, T6>(this IEnumerable<(T1, T2, T3, T4, T5, T6)> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            foreach (var value in values)
            {
                yield return (value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6);
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)> AsNullable<T1, T2, T3, T4, T5, T6>(this IEnumerable<(T1, T2, T3, T4, T5, T6)?> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            foreach (var value in values)
            {
                if (value.HasValue)
                {
                    yield return (value.Value.Item1, value.Value.Item2, value.Value.Item3, value.Value.Item4, value.Value.Item5, value.Value.Item6);
                }
                else
                {
                    yield return (null, null, null, null, null, null);
                }
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)> AsSimplify<T1, T2, T3, T4, T5, T6>(this IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)?> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            foreach (var value in values)
            {
                if (value.HasValue)
                {
                    yield return (value.Value.Item1, value.Value.Item2, value.Value.Item3, value.Value.Item4, value.Value.Item5, value.Value.Item6);
                }
                else
                {
                    yield return (null, null, null, null, null, null);
                }
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)> AsNullable<T1, T2, T3, T4, T5, T6, T7>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7)> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            foreach (var value in values)
            {
                yield return (value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7);
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)> AsNullable<T1, T2, T3, T4, T5, T6, T7>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7)?> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            foreach (var value in values)
            {
                if (value.HasValue)
                {
                    yield return (value.Value.Item1, value.Value.Item2, value.Value.Item3, value.Value.Item4, value.Value.Item5, value.Value.Item6, value.Value.Item7);
                }
                else
                {
                    yield return (null, null, null, null, null, null, null);
                }
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)> AsSimplify<T1, T2, T3, T4, T5, T6, T7>(this IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)?> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            foreach (var value in values)
            {
                if (value.HasValue)
                {
                    yield return (value.Value.Item1, value.Value.Item2, value.Value.Item3, value.Value.Item4, value.Value.Item5, value.Value.Item6, value.Value.Item7);
                }
                else
                {
                    yield return (null, null, null, null, null, null, null);
                }
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)> AsNullable<T1, T2, T3, T4, T5, T6, T7, T8>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8)> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            foreach (var value in values)
            {
                yield return (value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7, value.Item8);
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)> AsNullable<T1, T2, T3, T4, T5, T6, T7, T8>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8)?> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            foreach (var value in values)
            {
                if (value.HasValue)
                {
                    yield return (value.Value.Item1, value.Value.Item2, value.Value.Item3, value.Value.Item4, value.Value.Item5, value.Value.Item6, value.Value.Item7, value.Value.Item8);
                }
                else
                {
                    yield return (null, null, null, null, null, null, null, null);
                }
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)> AsSimplify<T1, T2, T3, T4, T5, T6, T7, T8>(this IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)?> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            foreach (var value in values)
            {
                if (value.HasValue)
                {
                    yield return (value.Value.Item1, value.Value.Item2, value.Value.Item3, value.Value.Item4, value.Value.Item5, value.Value.Item6, value.Value.Item7, value.Value.Item8);
                }
                else
                {
                    yield return (null, null, null, null, null, null, null, null);
                }
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)> AsNullable<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> values)
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
            foreach (var value in values)
            {
                yield return (value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7, value.Item8, value.Item9);
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)> AsNullable<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9)?> values)
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
            foreach (var value in values)
            {
                if (value.HasValue)
                {
                    yield return (value.Value.Item1, value.Value.Item2, value.Value.Item3, value.Value.Item4, value.Value.Item5, value.Value.Item6, value.Value.Item7, value.Value.Item8, value.Value.Item9);
                }
                else
                {
                    yield return (null, null, null, null, null, null, null, null, null);
                }
            }
        }

        /// <summary>
        /// Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)&gt;.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)> AsSimplify<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)?> values)
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
            foreach (var value in values)
            {
                if (value.HasValue)
                {
                    yield return (value.Value.Item1, value.Value.Item2, value.Value.Item3, value.Value.Item4, value.Value.Item5, value.Value.Item6, value.Value.Item7, value.Value.Item8, value.Value.Item9);
                }
                else
                {
                    yield return (null, null, null, null, null, null, null, null, null);
                }
            }
        }

        #endregion

        #region repeat

        /// <summary>
        /// Enumerates the specified enumeration repeatedly.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="repeatCount">The repeat count.</param>
        /// <returns></returns>
        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> values, int repeatCount)
        {
            static IEnumerable<T> repeat(IEnumerable<T> values, int count)
            {
                if (values is IList<T> list)
                {
                    for (int c = 0; c <= count; ++c)
                    {
                        for (int i = 0; i < list.Count; ++i)
                        {
                            yield return list[i];
                        }
                    }
                }
                else
                {
                    for (int c = 0; c <= count; ++c)
                    {
                        foreach (var value in values)
                        {
                            yield return value;
                        }
                    }
                }
            }

            if (repeatCount == 0)
            {
                return values;
            }
            else
            {
                return repeat(values, repeatCount);
            }
        }

        /// <summary>
        /// Enumerate repeatedly until the enumerated number reaches the specified number.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="enumerationCount">The enumeration count.</param>
        /// <returns></returns>
        public static IEnumerable<T> RepeatUntil<T>(this IEnumerable<T> values, int enumerationCount)
        {
            int count = 0;

            if (values is IList<T> list)
            {
                if (list.Count == 0) { yield break; }

                while (true)
                {
                    for (int i = 0; i < list.Count; ++i)
                    {
                        if (count >= enumerationCount) { yield break; }

                        yield return list[i];

                        ++count;
                    }
                }
            }
            else
            {
                while (true)
                {
                    bool exists = false;

                    foreach (var value in values)
                    {
                        if (!exists) { exists = true; }

                        if (count >= enumerationCount) { yield break; }

                        yield return value;

                        ++count;
                    }

                    if (!exists) { break; }
                }
            }
        }

        #endregion

        #region AsList

        /// <summary>
        /// Cast or convert to IList.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="values">The values to enumerate.</param>
        /// <returns></returns>
        public static IList<T> AsList<T>(this IEnumerable<T> values)
        {
            if (values is IList<T> list)
            {
                return list;
            }
            else
            {
                return values.ToArray();
            }
        }

        #endregion

        #region Convert

        /// <summary>
        /// Converts the values.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the source sequence.</typeparam>
        /// <typeparam name="TResult">The type of the elements of the result sequence.</typeparam>
        /// <param name="values">The source sequence of values to convert.</param>
        /// <param name="converter">A function to apply to each element.</param>
        /// <returns>An <see cref="IEnumerable{TResult}"/> whose elements are the result of invoking the converter on each element of the source.</returns>
        public static IEnumerable<TResult> Convert<TSource, TResult>(this IEnumerable<TSource> values, Converter<TSource, TResult> converter)
        {
            foreach (var value in values)
            {
                yield return converter(value);
            }
        }

        #endregion

    }

}
