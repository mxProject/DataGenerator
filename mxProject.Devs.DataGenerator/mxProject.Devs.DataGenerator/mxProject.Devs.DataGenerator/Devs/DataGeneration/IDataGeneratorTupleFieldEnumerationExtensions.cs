using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration
{

    internal static class IDataGeneratorTupleFieldEnumerationExtensions
    {

        /// <summary>
        /// Enumerates the values of the specified field.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="field"></param>
        /// <returns></returns>
        internal static IEnumerable<(T1?, T2?)> GenerateValues<T1, T2>(this IDataGeneratorTupleFieldEnumeration<T1, T2> field)
            where T1 : struct
            where T2 : struct
        {
            while (field.GenerateNext())
            {
                yield return field.GetTypedValues();
            }
        }

        /// <summary>
        /// Enumerates the values of the specified field.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="field"></param>
        /// <returns></returns>
        internal static IEnumerable<(T1?, T2?, T3?)> GenerateValues<T1, T2, T3>(this IDataGeneratorTupleFieldEnumeration<T1, T2, T3> field)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            while (field.GenerateNext())
            {
                yield return field.GetTypedValues();
            }
        }

        /// <summary>
        /// Enumerates the values of the specified field.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="field"></param>
        /// <returns></returns>
        internal static IEnumerable<(T1?, T2?, T3?, T4?)> GenerateValues<T1, T2, T3, T4>(this IDataGeneratorTupleFieldEnumeration<T1, T2, T3, T4> field)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            while (field.GenerateNext())
            {
                yield return field.GetTypedValues();
            }
        }

        /// <summary>
        /// Enumerates the values of the specified field.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="field"></param>
        /// <returns></returns>
        internal static IEnumerable<(T1?, T2?, T3?, T4?, T5?)> GenerateValues<T1, T2, T3, T4, T5>(this IDataGeneratorTupleFieldEnumeration<T1, T2, T3, T4, T5> field)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            while (field.GenerateNext())
            {
                yield return field.GetTypedValues();
            }
        }

        /// <summary>
        /// Enumerates the values of the specified field.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <param name="field"></param>
        /// <returns></returns>
        internal static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)> GenerateValues<T1, T2, T3, T4, T5, T6>(this IDataGeneratorTupleFieldEnumeration<T1, T2, T3, T4, T5, T6> field)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            while (field.GenerateNext())
            {
                yield return field.GetTypedValues();
            }
        }

        /// <summary>
        /// Enumerates the values of the specified field.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <param name="field"></param>
        /// <returns></returns>
        internal static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)> GenerateValues<T1, T2, T3, T4, T5, T6, T7>(this IDataGeneratorTupleFieldEnumeration<T1, T2, T3, T4, T5, T6, T7> field)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            while (field.GenerateNext())
            {
                yield return field.GetTypedValues();
            }
        }

        /// <summary>
        /// Enumerates the values of the specified field.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <param name="field"></param>
        /// <returns></returns>
        internal static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)> GenerateValues<T1, T2, T3, T4, T5, T6, T7, T8>(this IDataGeneratorTupleFieldEnumeration<T1, T2, T3, T4, T5, T6, T7, T8> field)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            while (field.GenerateNext())
            {
                yield return field.GetTypedValues();
            }
        }

        /// <summary>
        /// Enumerates the values of the specified field.
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
        /// <param name="field"></param>
        /// <returns></returns>
        internal static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)> GenerateValues<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IDataGeneratorTupleFieldEnumeration<T1, T2, T3, T4, T5, T6, T7, T8, T9> field)
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
            while (field.GenerateNext())
            {
                yield return field.GetTypedValues();
            }
        }

    }

}
