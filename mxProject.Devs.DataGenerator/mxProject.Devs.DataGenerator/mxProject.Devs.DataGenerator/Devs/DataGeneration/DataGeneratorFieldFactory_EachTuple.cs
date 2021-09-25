using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using mxProject.Devs.DataGeneration.Fields;

namespace mxProject.Devs.DataGeneration
{

    partial class DataGeneratorFieldFactory
    {

        #region EachTuple<T1, T2>

        /// <summary>
        /// Creates a field that enumerates the specified values.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorTupleField EachTuple<T1, T2>(string fieldName1, string fieldName2, IEnumerable<(T1, T2)> values, double nullProbability = 0)
            where T1 : struct
            where T2 : struct
        {
            ValueTask<IEnumerable<(T1?, T2?)>> generator(int count) => new ValueTask<IEnumerable<(T1?, T2?)>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count).AsNullable());
            return new DataGeneratorTupleField<T1, T2>(
                fieldName1, nullProbability > 0,
                fieldName2, nullProbability > 0,
                generator
                );
        }

        /// <summary>
        /// Creates a field that enumerates the specified values.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorTupleField EachTuple<T1, T2>(string fieldName1, string fieldName2, IEnumerable<(T1?, T2?)> values, double nullProbability = 0)
            where T1 : struct
            where T2 : struct
        {
            ValueTask<IEnumerable<(T1?, T2?)>> generator(int count) => new ValueTask<IEnumerable<(T1?, T2?)>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count).AsSimplify());
            return new DataGeneratorTupleField<T1, T2>(
                fieldName1, true,
                fieldName2, true,
                generator
                );
        }

        #endregion

        #region EachTuple<T1, T2, T3>

        /// <summary>
        /// Creates a field that enumerates the specified values.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorTupleField EachTuple<T1, T2, T3>(string fieldName1, string fieldName2, string fieldName3, IEnumerable<(T1, T2, T3)> values, double nullProbability = 0)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            ValueTask<IEnumerable<(T1?, T2?, T3?)>> generator(int count) => new ValueTask<IEnumerable<(T1?, T2?, T3?)>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count).AsNullable());
            return new DataGeneratorTupleField<T1, T2, T3>(
                fieldName1, nullProbability > 0,
                fieldName2, nullProbability > 0,
                fieldName3, nullProbability > 0,
                generator
                );
        }

        /// <summary>
        /// Creates a field that enumerates the specified values.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorTupleField EachTuple<T1, T2, T3>(string fieldName1, string fieldName2, string fieldName3, IEnumerable<(T1?, T2?, T3?)> values, double nullProbability = 0)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            ValueTask<IEnumerable<(T1?, T2?, T3?)>> generator(int count) => new ValueTask<IEnumerable<(T1?, T2?, T3?)>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count).AsSimplify());
            return new DataGeneratorTupleField<T1, T2, T3>(
                fieldName1, true,
                fieldName2, true,
                fieldName3, true,
                generator
                );
        }

        #endregion

        #region EachTuple<T1, T2, T3, T4>

        /// <summary>
        /// Creates a field that enumerates the specified values.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="fieldName4">The name of the fourth field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4>(string fieldName1, string fieldName2, string fieldName3, string fieldName4, IEnumerable<(T1, T2, T3, T4)> values, double nullProbability = 0)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            ValueTask<IEnumerable<(T1?, T2?, T3?, T4?)>> generator(int count) => new ValueTask<IEnumerable<(T1?, T2?, T3?, T4?)>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count).AsNullable());
            return new DataGeneratorTupleField<T1, T2, T3, T4>(
                fieldName1, nullProbability > 0,
                fieldName2, nullProbability > 0,
                fieldName3, nullProbability > 0,
                fieldName4, nullProbability > 0,
                generator
                );
        }

        /// <summary>
        /// Creates a field that enumerates the specified values.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="fieldName4">The name of the fourth field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4>(string fieldName1, string fieldName2, string fieldName3, string fieldName4, IEnumerable<(T1?, T2?, T3?, T4?)> values, double nullProbability = 0)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            ValueTask<IEnumerable<(T1?, T2?, T3?, T4?)>> generator(int count) => new ValueTask<IEnumerable<(T1?, T2?, T3?, T4?)>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count).AsSimplify());
            return new DataGeneratorTupleField<T1, T2, T3, T4>(
                fieldName1, true,
                fieldName2, true,
                fieldName3, true,
                fieldName4, true,
                generator
                );
        }

        #endregion

        #region EachTuple<T1, T2, T3, T4, T5>

        /// <summary>
        /// Creates a field that enumerates the specified values.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <typeparam name="T5">The type of the fifth value.</typeparam>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="fieldName4">The name of the fourth field.</param>
        /// <param name="fieldName5">The name of the fifth field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4, T5>(string fieldName1, string fieldName2, string fieldName3, string fieldName4, string fieldName5, IEnumerable<(T1, T2, T3, T4, T5)> values, double nullProbability = 0)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?)>> generator(int count) => new ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?)>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count).AsNullable());
            return new DataGeneratorTupleField<T1, T2, T3, T4, T5>(
                fieldName1, nullProbability > 0,
                fieldName2, nullProbability > 0,
                fieldName3, nullProbability > 0,
                fieldName4, nullProbability > 0,
                fieldName5, nullProbability > 0,
                generator
                );
        }

        /// <summary>
        /// Creates a field that enumerates the specified values.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <typeparam name="T5">The type of the fifth value.</typeparam>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="fieldName4">The name of the fourth field.</param>
        /// <param name="fieldName5">The name of the fifth field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4, T5>(string fieldName1, string fieldName2, string fieldName3, string fieldName4, string fieldName5, IEnumerable<(T1?, T2?, T3?, T4?, T5?)> values, double nullProbability = 0)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?)>> generator(int count) => new ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?)>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count).AsSimplify());
            return new DataGeneratorTupleField<T1, T2, T3, T4, T5>(
                fieldName1, true,
                fieldName2, true,
                fieldName3, true,
                fieldName4, true,
                fieldName5, true,
                generator
                );
        }

        #endregion

        #region EachTuple<T1, T2, T3, T4, T5, T6>

        /// <summary>
        /// Creates a field that enumerates the specified values.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <typeparam name="T5">The type of the fifth value.</typeparam>
        /// <typeparam name="T6">The type of the sixth value.</typeparam>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="fieldName4">The name of the fourth field.</param>
        /// <param name="fieldName5">The name of the fifth field.</param>
        /// <param name="fieldName6">The name of the sixth field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4, T5, T6>(string fieldName1, string fieldName2, string fieldName3, string fieldName4, string fieldName5, string fieldName6, IEnumerable<(T1, T2, T3, T4, T5, T6)> values, double nullProbability = 0)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)>> generator(int count) => new ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count).AsNullable());
            return new DataGeneratorTupleField<T1, T2, T3, T4, T5, T6>(
                fieldName1, nullProbability > 0,
                fieldName2, nullProbability > 0,
                fieldName3, nullProbability > 0,
                fieldName4, nullProbability > 0,
                fieldName5, nullProbability > 0,
                fieldName6, nullProbability > 0,
                generator
                );
        }

        /// <summary>
        /// Creates a field that enumerates the specified values.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <typeparam name="T5">The type of the fifth value.</typeparam>
        /// <typeparam name="T6">The type of the sixth value.</typeparam>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="fieldName4">The name of the fourth field.</param>
        /// <param name="fieldName5">The name of the fifth field.</param>
        /// <param name="fieldName6">The name of the sixth field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4, T5, T6>(string fieldName1, string fieldName2, string fieldName3, string fieldName4, string fieldName5, string fieldName6, IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)> values, double nullProbability = 0)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)>> generator(int count) => new ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count).AsSimplify());
            return new DataGeneratorTupleField<T1, T2, T3, T4, T5, T6>(
                fieldName1, true,
                fieldName2, true,
                fieldName3, true,
                fieldName4, true,
                fieldName5, true,
                fieldName6, true,
                generator
                );
        }

        #endregion

        #region EachTuple<T1, T2, T3, T4, T5, T6, T7>

        /// <summary>
        /// Creates a field that enumerates the specified values.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <typeparam name="T5">The type of the fifth value.</typeparam>
        /// <typeparam name="T6">The type of the sixth value.</typeparam>
        /// <typeparam name="T7">The type of the seventh value.</typeparam>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="fieldName4">The name of the fourth field.</param>
        /// <param name="fieldName5">The name of the fifth field.</param>
        /// <param name="fieldName6">The name of the sixth field.</param>
        /// <param name="fieldName7">The name of the seventh field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4, T5, T6, T7>(string fieldName1, string fieldName2, string fieldName3, string fieldName4, string fieldName5, string fieldName6, string fieldName7, IEnumerable<(T1, T2, T3, T4, T5, T6, T7)> values, double nullProbability = 0)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)>> generator(int count) => new ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count).AsNullable());
            return new DataGeneratorTupleField<T1, T2, T3, T4, T5, T6, T7>(
                fieldName1, nullProbability > 0,
                fieldName2, nullProbability > 0,
                fieldName3, nullProbability > 0,
                fieldName4, nullProbability > 0,
                fieldName5, nullProbability > 0,
                fieldName6, nullProbability > 0,
                fieldName7, nullProbability > 0,
                generator
                );
        }

        /// <summary>
        /// Creates a field that enumerates the specified values.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <typeparam name="T5">The type of the fifth value.</typeparam>
        /// <typeparam name="T6">The type of the sixth value.</typeparam>
        /// <typeparam name="T7">The type of the seventh value.</typeparam>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="fieldName4">The name of the fourth field.</param>
        /// <param name="fieldName5">The name of the fifth field.</param>
        /// <param name="fieldName6">The name of the sixth field.</param>
        /// <param name="fieldName7">The name of the seventh field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4, T5, T6, T7>(string fieldName1, string fieldName2, string fieldName3, string fieldName4, string fieldName5, string fieldName6, string fieldName7, IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)> values, double nullProbability = 0)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)>> generator(int count) => new ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count).AsSimplify());
            return new DataGeneratorTupleField<T1, T2, T3, T4, T5, T6, T7>(
                fieldName1, true,
                fieldName2, true,
                fieldName3, true,
                fieldName4, true,
                fieldName5, true,
                fieldName6, true,
                fieldName7, true,
                generator
                );
        }

        #endregion

        #region EachTuple<T1, T2, T3, T4, T5, T6, T7, T8>

        /// <summary>
        /// Creates a field that enumerates the specified values.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <typeparam name="T5">The type of the fifth value.</typeparam>
        /// <typeparam name="T6">The type of the sixth value.</typeparam>
        /// <typeparam name="T7">The type of the seventh value.</typeparam>
        /// <typeparam name="T8">The type of the eighth value.</typeparam>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="fieldName4">The name of the fourth field.</param>
        /// <param name="fieldName5">The name of the fifth field.</param>
        /// <param name="fieldName6">The name of the sixth field.</param>
        /// <param name="fieldName7">The name of the seventh field.</param>
        /// <param name="fieldName8">The name of the eighth field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4, T5, T6, T7, T8>(string fieldName1, string fieldName2, string fieldName3, string fieldName4, string fieldName5, string fieldName6, string fieldName7, string fieldName8, IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8)> values, double nullProbability = 0)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)>> generator(int count) => new ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count).AsNullable());
            return new DataGeneratorTupleField<T1, T2, T3, T4, T5, T6, T7, T8>(
                fieldName1, nullProbability > 0,
                fieldName2, nullProbability > 0,
                fieldName3, nullProbability > 0,
                fieldName4, nullProbability > 0,
                fieldName5, nullProbability > 0,
                fieldName6, nullProbability > 0,
                fieldName7, nullProbability > 0,
                fieldName8, nullProbability > 0,
                generator
                );
        }

        /// <summary>
        /// Creates a field that enumerates the specified values.
        /// </summary>
        /// <typeparam name="T1">The type of the first value.</typeparam>
        /// <typeparam name="T2">The type of the second value.</typeparam>
        /// <typeparam name="T3">The type of the third value.</typeparam>
        /// <typeparam name="T4">The type of the fourth value.</typeparam>
        /// <typeparam name="T5">The type of the fifth value.</typeparam>
        /// <typeparam name="T6">The type of the sixth value.</typeparam>
        /// <typeparam name="T7">The type of the seventh value.</typeparam>
        /// <typeparam name="T8">The type of the eighth value.</typeparam>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="fieldName4">The name of the fourth field.</param>
        /// <param name="fieldName5">The name of the fifth field.</param>
        /// <param name="fieldName6">The name of the sixth field.</param>
        /// <param name="fieldName7">The name of the seventh field.</param>
        /// <param name="fieldName8">The name of the eighth field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4, T5, T6, T7, T8>(string fieldName1, string fieldName2, string fieldName3, string fieldName4, string fieldName5, string fieldName6, string fieldName7, string fieldName8, IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)> values, double nullProbability = 0)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)>> generator(int count) => new ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count).AsSimplify());
            return new DataGeneratorTupleField<T1, T2, T3, T4, T5, T6, T7, T8>(
                fieldName1, true,
                fieldName2, true,
                fieldName3, true,
                fieldName4, true,
                fieldName5, true,
                fieldName6, true,
                fieldName7, true,
                fieldName8, true,
                generator
                );
        }

        #endregion

        #region EachTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>

        /// <summary>
        /// Creates a field that enumerates the specified values.
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
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="fieldName4">The name of the fourth field.</param>
        /// <param name="fieldName5">The name of the fifth field.</param>
        /// <param name="fieldName6">The name of the sixth field.</param>
        /// <param name="fieldName7">The name of the seventh field.</param>
        /// <param name="fieldName8">The name of the eighth field.</param>
        /// <param name="fieldName9">The name of the ninth field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string fieldName1, string fieldName2, string fieldName3, string fieldName4, string fieldName5, string fieldName6, string fieldName7, string fieldName8, string fieldName9, IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> values, double nullProbability = 0)
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
            ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)>> generator(int count) => new ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count).AsNullable());
            return new DataGeneratorTupleField<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
                fieldName1, nullProbability > 0,
                fieldName2, nullProbability > 0,
                fieldName3, nullProbability > 0,
                fieldName4, nullProbability > 0,
                fieldName5, nullProbability > 0,
                fieldName6, nullProbability > 0,
                fieldName7, nullProbability > 0,
                fieldName8, nullProbability > 0,
                fieldName9, nullProbability > 0,
                generator
                );
        }

        /// <summary>
        /// Creates a field that enumerates the specified values.
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
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="fieldName4">The name of the fourth field.</param>
        /// <param name="fieldName5">The name of the fifth field.</param>
        /// <param name="fieldName6">The name of the sixth field.</param>
        /// <param name="fieldName7">The name of the seventh field.</param>
        /// <param name="fieldName8">The name of the eighth field.</param>
        /// <param name="fieldName9">The name of the ninth field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string fieldName1, string fieldName2, string fieldName3, string fieldName4, string fieldName5, string fieldName6, string fieldName7, string fieldName8, string fieldName9, IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)> values, double nullProbability = 0)
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
            ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)>> generator(int count) => new ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count).AsSimplify());
            return new DataGeneratorTupleField<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
                fieldName1, true,
                fieldName2, true,
                fieldName3, true,
                fieldName4, true,
                fieldName5, true,
                fieldName6, true,
                fieldName7, true,
                fieldName8, true,
                fieldName9, true,
                generator
                );
        }

        #endregion

    }

}
