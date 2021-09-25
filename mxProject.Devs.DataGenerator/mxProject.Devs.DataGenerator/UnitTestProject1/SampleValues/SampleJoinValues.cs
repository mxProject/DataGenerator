using System;
using System.Collections.Generic;
using System.Text;

using mxProject.Devs.DataGeneration;
using mxProject.Devs.DataGeneration.Fields;
using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Devs.DataGeneration.Configuration.Fields;
using System.ComponentModel.DataAnnotations;

namespace UnitTestProject1.SampleValues
{
    internal static class SampleJoinValues
    {
        static SampleJoinValues()
        {
            AllValues = new Dictionary<Type, object>()
                {
                    { typeof(int), Int32Values },
                    { typeof(double), DoubleValues },
                    { typeof(decimal), DecimalValues },
                    { typeof(DateTime), DateTimeValues },
                    { typeof(DateTimeOffset), DateTimeOffsetValues },
                    { typeof(TimeSpan), TimeSpanValues },
                    { typeof(StringValue), StringValueValues },
                    { typeof(char), CharValues },
                    { typeof(Guid), GuidValues },
                    { typeof(DayOfWeek), DayOfWeekValues },
                };
        }

        internal static readonly int?[] Int32Values = new int?[] { 1, 2, null };
        internal static readonly double?[] DoubleValues = new double?[] { 1.11, 2.22, null };
        internal static readonly decimal?[] DecimalValues = new decimal?[] { 1.111M, 2.222M, null };
        internal static readonly DateTime?[] DateTimeValues = new DateTime?[] { DateTime.Now, DateTime.UtcNow.AddDays(1), null };
        internal static readonly DateTimeOffset?[] DateTimeOffsetValues = new DateTimeOffset?[] { DateTimeOffset.Now, DateTimeOffset.UtcNow.AddDays(1), null };
        internal static readonly TimeSpan?[] TimeSpanValues = new TimeSpan?[] { TimeSpan.MinValue, TimeSpan.MaxValue, null };
        internal static readonly StringValue?[] StringValueValues = new StringValue?[] { "A", "B", "", null };
        internal static readonly char?[] CharValues = new char?[] { 'a', 'b', null };
        internal static readonly Guid?[] GuidValues = new Guid?[] { Guid.NewGuid(), Guid.NewGuid(), null };
        internal static readonly DayOfWeek?[] DayOfWeekValues = new DayOfWeek?[] { DayOfWeek.Monday, DayOfWeek.Tuesday, null };

        private static readonly Dictionary<Type, object> AllValues;

        private static readonly EnumerableFactory EnumerableFactory = new EnumerableFactory();

        internal static IEnumerable<T> GetValues<T>()
            where T : struct
        {
            var nullable = (T?[])AllValues[typeof(T)];

            T[] values = new T[nullable.Length];

            for (int i =0; i< nullable.Length; ++i)
            {
                values[i] = nullable[i].GetValueOrDefault();
            }

            return values;
        }


        internal static IEnumerable<T?> GetNullableValues<T>()
            where T : struct
        {
            return (T?[])AllValues[typeof(T)];
        }

        #region CreateKeyValues

        internal static IEnumerable<(TKey1, TKey2)> CreateKeyValues<TKey1, TKey2>()
            where TKey1 : struct
            where TKey2 : struct
        {
            return EnumerableFactory.DirectProduct(
                GetValues<TKey1>(),
                GetValues<TKey2>()
                );
        }

        internal static IEnumerable<(TKey1, TKey2, TKey3)> CreateKeyValues<TKey1, TKey2, TKey3>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
        {
            return EnumerableFactory.DirectProduct(
                GetValues<TKey1>(),
                GetValues<TKey2>(),
                GetValues<TKey3>()
                );
        }

        internal static IEnumerable<(TKey1, TKey2, TKey3, TKey4)> CreateKeyValues<TKey1, TKey2, TKey3, TKey4>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
        {
            return EnumerableFactory.DirectProduct(
                GetValues<TKey1>(),
                GetValues<TKey2>(),
                GetValues<TKey3>(),
                GetValues<TKey4>()
                );
        }

        internal static IEnumerable<(TKey1, TKey2, TKey3, TKey4, TKey5)> CreateKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
        {
            return EnumerableFactory.DirectProduct(
                GetValues<TKey1>(),
                GetValues<TKey2>(),
                GetValues<TKey3>(),
                GetValues<TKey4>(),
                GetValues<TKey5>()
                );
        }

        internal static IEnumerable<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6)> CreateKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
        {
            return EnumerableFactory.DirectProduct(
                GetValues<TKey1>(),
                GetValues<TKey2>(),
                GetValues<TKey3>(),
                GetValues<TKey4>(),
                GetValues<TKey5>(),
                GetValues<TKey6>()
                );
        }

        internal static IEnumerable<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7)> CreateKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
        {
            return EnumerableFactory.DirectProduct(
                GetValues<TKey1>(),
                GetValues<TKey2>(),
                GetValues<TKey3>(),
                GetValues<TKey4>(),
                GetValues<TKey5>(),
                GetValues<TKey6>(),
                GetValues<TKey7>()
                );
        }

        internal static IEnumerable<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8)> CreateKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
        {
            return EnumerableFactory.DirectProduct(
                GetValues<TKey1>(),
                GetValues<TKey2>(),
                GetValues<TKey3>(),
                GetValues<TKey4>(),
                GetValues<TKey5>(),
                GetValues<TKey6>(),
                GetValues<TKey7>(),
                GetValues<TKey8>()
                );
        }

        internal static IEnumerable<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9)> CreateKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
        {
            return EnumerableFactory.DirectProduct(
                GetValues<TKey1>(),
                GetValues<TKey2>(),
                GetValues<TKey3>(),
                GetValues<TKey4>(),
                GetValues<TKey5>(),
                GetValues<TKey6>(),
                GetValues<TKey7>(),
                GetValues<TKey8>(),
                GetValues<TKey9>()
                );
        }

        private static IEnumerable<(TKey1, TKey2)> CreateKeyValues<TKey1, TKey2, TAnyValue>(IDictionary<(TKey1, TKey2), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
        {
            return CreateKeyValues<TKey1, TKey2>();
        }

        private static IEnumerable<(TKey1, TKey2, TKey3)> CreateKeyValues<TKey1, TKey2, TKey3, TAnyValue>(IDictionary<(TKey1, TKey2, TKey3), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
        {
            return CreateKeyValues<TKey1, TKey2, TKey3>();
        }

        private static IEnumerable<(TKey1, TKey2, TKey3, TKey4)> CreateKeyValues<TKey1, TKey2, TKey3, TKey4, TAnyValue>(IDictionary<(TKey1, TKey2, TKey3, TKey4), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
        {
            return CreateKeyValues<TKey1, TKey2, TKey3, TKey4>();
        }

        private static IEnumerable<(TKey1, TKey2, TKey3, TKey4, TKey5)> CreateKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TAnyValue>(IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
        {
            return CreateKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5>();
        }

        private static IEnumerable<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6)> CreateKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TAnyValue>(IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
        {
            return CreateKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>();
        }

        private static IEnumerable<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7)> CreateKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TAnyValue>(IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
        {
            return CreateKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>();
        }

        private static IEnumerable<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8)> CreateKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TAnyValue>(IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
        {
            return CreateKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>();
        }

        private static IEnumerable<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9)> CreateKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TAnyValue>(IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
        {
            return CreateKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>();
        }

        #endregion

        #region CreateNullableKeyValues

        internal static IEnumerable<(TKey1?, TKey2?)> CreateNullableKeyValues<TKey1, TKey2>()
            where TKey1 : struct
            where TKey2 : struct
        {
            return EnumerableFactory.DirectProduct(
                GetNullableValues<TKey1>(),
                GetNullableValues<TKey2>()
                );
        }

        internal static IEnumerable<(TKey1?, TKey2?, TKey3?)> CreateNullableKeyValues<TKey1, TKey2, TKey3>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
        {
            return EnumerableFactory.DirectProduct(
                GetNullableValues<TKey1>(),
                GetNullableValues<TKey2>(),
                GetNullableValues<TKey3>()
                );
        }

        internal static IEnumerable<(TKey1?, TKey2?, TKey3?, TKey4?)> CreateNullableKeyValues<TKey1, TKey2, TKey3, TKey4>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
        {
            return EnumerableFactory.DirectProduct(
                GetNullableValues<TKey1>(),
                GetNullableValues<TKey2>(),
                GetNullableValues<TKey3>(),
                GetNullableValues<TKey4>()
                );
        }

        internal static IEnumerable<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?)> CreateNullableKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
        {
            return EnumerableFactory.DirectProduct(
                GetNullableValues<TKey1>(),
                GetNullableValues<TKey2>(),
                GetNullableValues<TKey3>(),
                GetNullableValues<TKey4>(),
                GetNullableValues<TKey5>()
                );
        }

        internal static IEnumerable<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?)> CreateNullableKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
        {
            return EnumerableFactory.DirectProduct(
                GetNullableValues<TKey1>(),
                GetNullableValues<TKey2>(),
                GetNullableValues<TKey3>(),
                GetNullableValues<TKey4>(),
                GetNullableValues<TKey5>(),
                GetNullableValues<TKey6>()
                );
        }

        internal static IEnumerable<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?)> CreateNullableKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
        {
            return EnumerableFactory.DirectProduct(
                GetNullableValues<TKey1>(),
                GetNullableValues<TKey2>(),
                GetNullableValues<TKey3>(),
                GetNullableValues<TKey4>(),
                GetNullableValues<TKey5>(),
                GetNullableValues<TKey6>(),
                GetNullableValues<TKey7>()
                );
        }

        internal static IEnumerable<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?)> CreateNullableKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
        {
            return EnumerableFactory.DirectProduct(
                GetNullableValues<TKey1>(),
                GetNullableValues<TKey2>(),
                GetNullableValues<TKey3>(),
                GetNullableValues<TKey4>(),
                GetNullableValues<TKey5>(),
                GetNullableValues<TKey6>(),
                GetNullableValues<TKey7>(),
                GetNullableValues<TKey8>()
                );
        }

        internal static IEnumerable<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?)> CreateNullableKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
        {
            return EnumerableFactory.DirectProduct(
                GetNullableValues<TKey1>(),
                GetNullableValues<TKey2>(),
                GetNullableValues<TKey3>(),
                GetNullableValues<TKey4>(),
                GetNullableValues<TKey5>(),
                GetNullableValues<TKey6>(),
                GetNullableValues<TKey7>(),
                GetNullableValues<TKey8>(),
                GetNullableValues<TKey9>()
                );
        }

        private static IEnumerable<(TKey1?, TKey2?)> CreateNullableKeyValues<TKey1, TKey2, TAnyValue>(IDictionary<(TKey1?, TKey2?), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
        {
            return CreateNullableKeyValues<TKey1, TKey2>();
        }

        private static IEnumerable<(TKey1?, TKey2?, TKey3?)> CreateNullableKeyValues<TKey1, TKey2, TKey3, TAnyValue>(IDictionary<(TKey1?, TKey2?, TKey3?), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
        {
            return CreateNullableKeyValues<TKey1, TKey2, TKey3>();
        }

        private static IEnumerable<(TKey1?, TKey2?, TKey3?, TKey4?)> CreateNullableKeyValues<TKey1, TKey2, TKey3, TKey4, TAnyValue>(IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
        {
            return CreateNullableKeyValues<TKey1, TKey2, TKey3, TKey4>();
        }

        private static IEnumerable<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?)> CreateNullableKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TAnyValue>(IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
        {
            return CreateNullableKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5>();
        }

        private static IEnumerable<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?)> CreateNullableKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TAnyValue>(IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
        {
            return CreateNullableKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>();
        }

        private static IEnumerable<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?)> CreateNullableKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TAnyValue>(IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
        {
            return CreateNullableKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>();
        }

        private static IEnumerable<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?)> CreateNullableKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TAnyValue>(IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
        {
            return CreateNullableKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>();
        }

        private static IEnumerable<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?)> CreateNullableKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TAnyValue>(IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
        {
            return CreateNullableKeyValues<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>();
        }

        #endregion

        #region CreateValues

        private static IEnumerable<TValue> CreateValues<TAnyKey, TValue>(IDictionary<TAnyKey, TValue> _)
            where TAnyKey : notnull
            where TValue : struct
        {
            return GetValues<TValue>();
        }

        private static IEnumerable<(T1, T2)> CreateValues<TAnyKey, T1, T2>(IDictionary<TAnyKey, (T1, T2)> _)
            where TAnyKey : notnull
            where T1 : struct
            where T2 : struct
        {
            return EnumerableFactory.EachParallel(
                GetValues<T1>(),
                GetValues<T2>(),
                false
                );
        }

        private static IEnumerable<(T1, T2, T3)> CreateValues<TAnyKey, T1, T2, T3>(IDictionary<TAnyKey, (T1, T2, T3)> _)
            where TAnyKey : notnull
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            return EnumerableFactory.EachParallel(
                GetValues<T1>(),
                GetValues<T2>(),
                GetValues<T3>(),
                false
                );
        }

        private static IEnumerable<(T1, T2, T3, T4)> CreateValues<TAnyKey, T1, T2, T3, T4>(IDictionary<TAnyKey, (T1, T2, T3, T4)> _)
            where TAnyKey : notnull
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            return EnumerableFactory.EachParallel(
                GetValues<T1>(),
                GetValues<T2>(),
                GetValues<T3>(),
                GetValues<T4>(),
                false
                );
        }

        private static IEnumerable<(T1, T2, T3, T4, T5)> CreateValues<TAnyKey, T1, T2, T3, T4, T5>(IDictionary<TAnyKey, (T1, T2, T3, T4, T5)> _)
            where TAnyKey : notnull
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            return EnumerableFactory.EachParallel(
                GetValues<T1>(),
                GetValues<T2>(),
                GetValues<T3>(),
                GetValues<T4>(),
                GetValues<T5>(),
                false
                );
        }

        private static IEnumerable<(T1, T2, T3, T4, T5, T6)> CreateValues<TAnyKey, T1, T2, T3, T4, T5, T6>(IDictionary<TAnyKey, (T1, T2, T3, T4, T5, T6)> _)
            where TAnyKey : notnull
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            return EnumerableFactory.EachParallel(
                GetValues<T1>(),
                GetValues<T2>(),
                GetValues<T3>(),
                GetValues<T4>(),
                GetValues<T5>(),
                GetValues<T6>(),
                false
                );
        }

        private static IEnumerable<(T1, T2, T3, T4, T5, T6, T7)> CreateValues<TAnyKey, T1, T2, T3, T4, T5, T6, T7>(IDictionary<TAnyKey, (T1, T2, T3, T4, T5, T6, T7)> _)
            where TAnyKey : notnull
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            return EnumerableFactory.EachParallel(
                GetValues<T1>(),
                GetValues<T2>(),
                GetValues<T3>(),
                GetValues<T4>(),
                GetValues<T5>(),
                GetValues<T6>(),
                GetValues<T7>(),
                false
                );
        }

        private static IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8)> CreateValues<TAnyKey, T1, T2, T3, T4, T5, T6, T7, T8>(IDictionary<TAnyKey, (T1, T2, T3, T4, T5, T6, T7, T8)> _)
            where TAnyKey : notnull
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            return EnumerableFactory.EachParallel(
                GetValues<T1>(),
                GetValues<T2>(),
                GetValues<T3>(),
                GetValues<T4>(),
                GetValues<T5>(),
                GetValues<T6>(),
                GetValues<T7>(),
                GetValues<T8>(),
                false
                );
        }

        private static IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> CreateValues<TAnyKey, T1, T2, T3, T4, T5, T6, T7, T8, T9>(IDictionary<TAnyKey, (T1, T2, T3, T4, T5, T6, T7, T8, T9)> _)
            where TAnyKey : notnull
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
            return EnumerableFactory.EachParallel(
                GetValues<T1>(),
                GetValues<T2>(),
                GetValues<T3>(),
                GetValues<T4>(),
                GetValues<T5>(),
                GetValues<T6>(),
                GetValues<T7>(),
                GetValues<T8>(),
                GetValues<T9>(),
                false
                );
        }

        #endregion

        #region CreateNullableValues

        private static IEnumerable<TValue?> CreateNullableValues<TAnyKey, TValue>(IDictionary<TAnyKey, TValue?> _)
            where TAnyKey : notnull
            where TValue : struct
        {
            return GetNullableValues<TValue>();
        }

        private static IEnumerable<(T1?, T2?)> CreateNullableValues<TAnyKey, T1, T2>(IDictionary<TAnyKey, (T1?, T2?)> _)
            where TAnyKey : notnull
            where T1 : struct
            where T2 : struct
        {
            return EnumerableFactory.EachParallel(
                GetNullableValues<T1>(),
                GetNullableValues<T2>(),
                false
                );
        }

        private static IEnumerable<(T1?, T2?, T3?)> CreateNullableValues<TAnyKey, T1, T2, T3>(IDictionary<TAnyKey, (T1?, T2?, T3?)> _)
            where TAnyKey : notnull
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            return EnumerableFactory.EachParallel(
                GetNullableValues<T1>(),
                GetNullableValues<T2>(),
                GetNullableValues<T3>(),
                false
                );
        }

        private static IEnumerable<(T1?, T2?, T3?, T4?)> CreateNullableValues<TAnyKey, T1, T2, T3, T4>(IDictionary<TAnyKey, (T1?, T2?, T3?, T4?)> _)
            where TAnyKey : notnull
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            return EnumerableFactory.EachParallel(
                GetNullableValues<T1>(),
                GetNullableValues<T2>(),
                GetNullableValues<T3>(),
                GetNullableValues<T4>(),
                false
                );
        }

        private static IEnumerable<(T1?, T2?, T3?, T4?, T5?)> CreateNullableValues<TAnyKey, T1, T2, T3, T4, T5>(IDictionary<TAnyKey, (T1?, T2?, T3?, T4?, T5?)> _)
            where TAnyKey : notnull
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            return EnumerableFactory.EachParallel(
                GetNullableValues<T1>(),
                GetNullableValues<T2>(),
                GetNullableValues<T3>(),
                GetNullableValues<T4>(),
                GetNullableValues<T5>(),
                false
                );
        }

        private static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)> CreateNullableValues<TAnyKey, T1, T2, T3, T4, T5, T6>(IDictionary<TAnyKey, (T1?, T2?, T3?, T4?, T5?, T6?)> _)
            where TAnyKey : notnull
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            return EnumerableFactory.EachParallel(
                GetNullableValues<T1>(),
                GetNullableValues<T2>(),
                GetNullableValues<T3>(),
                GetNullableValues<T4>(),
                GetNullableValues<T5>(),
                GetNullableValues<T6>(),
                false
                );
        }

        private static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)> CreateNullableValues<TAnyKey, T1, T2, T3, T4, T5, T6, T7>(IDictionary<TAnyKey, (T1?, T2?, T3?, T4?, T5?, T6?, T7?)> _)
            where TAnyKey : notnull
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            return EnumerableFactory.EachParallel(
                GetNullableValues<T1>(),
                GetNullableValues<T2>(),
                GetNullableValues<T3>(),
                GetNullableValues<T4>(),
                GetNullableValues<T5>(),
                GetNullableValues<T6>(),
                GetNullableValues<T7>(),
                false
                );
        }

        private static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)> CreateNullableValues<TAnyKey, T1, T2, T3, T4, T5, T6, T7, T8>(IDictionary<TAnyKey, (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)> _)
            where TAnyKey : notnull
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            return EnumerableFactory.EachParallel(
                GetNullableValues<T1>(),
                GetNullableValues<T2>(),
                GetNullableValues<T3>(),
                GetNullableValues<T4>(),
                GetNullableValues<T5>(),
                GetNullableValues<T6>(),
                GetNullableValues<T7>(),
                GetNullableValues<T8>(),
                false
                );
        }

        private static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)> CreateNullableValues<TAnyKey, T1, T2, T3, T4, T5, T6, T7, T8, T9>(IDictionary<TAnyKey, (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)> _)
            where TAnyKey : notnull
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
            return EnumerableFactory.EachParallel(
                GetNullableValues<T1>(),
                GetNullableValues<T2>(),
                GetNullableValues<T3>(),
                GetNullableValues<T4>(),
                GetNullableValues<T5>(),
                GetNullableValues<T6>(),
                GetNullableValues<T7>(),
                GetNullableValues<T8>(),
                GetNullableValues<T9>(),
                false
                );
        }

        #endregion


        #region dictionary whose key is a literal value

        internal static Dictionary<TKey, TValue> CreateDictionaryKey1<TKey, TValue>()
            where TKey : struct
            where TValue : struct
        {
            Dictionary<TKey, TValue> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in GetValues<TKey>())
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<TKey, (TValue1, TValue2)> CreateDictionaryKey1<TKey, TValue1, TValue2>()
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<TKey, (TValue1, TValue2)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator(); ;
                disposables.Add(values);

                foreach (var key in GetValues<TKey>())
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator(); ;
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<TKey, (TValue1, TValue2, TValue3)> CreateDictionaryKey1<TKey, TValue1, TValue2, TValue3>()
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<TKey, (TValue1, TValue2, TValue3)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in GetValues<TKey>())
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4)> CreateDictionaryKey1<TKey, TValue1, TValue2, TValue3, TValue4>()
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in GetValues<TKey>())
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5)> CreateDictionaryKey1<TKey, TValue1, TValue2, TValue3, TValue4, TValue5>()
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in GetValues<TKey>())
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> CreateDictionaryKey1<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>()
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in GetValues<TKey>())
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> CreateDictionaryKey1<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>()
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in GetValues<TKey>())
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> CreateDictionaryKey1<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>()
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in GetValues<TKey>())
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> CreateDictionaryKey1<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>()
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in GetValues<TKey>())
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        #endregion

        #region dictionary whose key is a 2-values tuple

        internal static Dictionary<(TKey1, TKey2), TValue> CreateDictionaryKey2<TKey1, TKey2, TValue>()
            where TKey1 : struct
            where TKey2 : struct
            where TValue : struct
        {
            Dictionary<(TKey1, TKey2), TValue> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2), (TValue1, TValue2)> CreateDictionaryKey2<TKey1, TKey2, TValue1, TValue2>()
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1, TKey2), (TValue1, TValue2)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3)> CreateDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3>()
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4)> CreateDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4>()
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5)> CreateDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5>()
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> CreateDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>()
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> CreateDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>()
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> CreateDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>()
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> CreateDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>()
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        #endregion

        #region dictionary whose key is a 3-values tuple

        internal static Dictionary<(TKey1, TKey2, TKey3), TValue> CreateDictionaryKey3<TKey1, TKey2, TKey3, TValue>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue : struct
        {
            Dictionary<(TKey1, TKey2, TKey3), TValue> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2)> CreateDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3)> CreateDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4)> CreateDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5)> CreateDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> CreateDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> CreateDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> CreateDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> CreateDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        #endregion

        #region dictionary whose key is a 4-values tuple

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4), TValue> CreateDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4), TValue> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2)> CreateDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3)> CreateDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4)> CreateDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5)> CreateDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> CreateDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> CreateDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> CreateDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> CreateDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        #endregion

        #region dictionary whose key is a 5-values tuple

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), TValue> CreateDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), TValue> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2)> CreateDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3)> CreateDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4)> CreateDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5)> CreateDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> CreateDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> CreateDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> CreateDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> CreateDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        #endregion

        #region dictionary whose key is a 6-values tuple

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), TValue> CreateDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), TValue> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2)> CreateDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3)> CreateDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4)> CreateDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5)> CreateDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> CreateDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> CreateDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> CreateDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> CreateDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        #endregion

        #region dictionary whose key is a 7-values tuple

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), TValue> CreateDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), TValue> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2)> CreateDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3)> CreateDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4)> CreateDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5)> CreateDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> CreateDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> CreateDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> CreateDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> CreateDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        #endregion

        #region dictionary whose key is a 8-values tuple

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), TValue> CreateDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), TValue> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2)> CreateDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3)> CreateDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4)> CreateDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5)> CreateDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> CreateDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> CreateDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> CreateDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> CreateDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        #endregion

        #region dictionary whose key is a 9-values tuple

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), TValue> CreateDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), TValue> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2)> CreateDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3)> CreateDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4)> CreateDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5)> CreateDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> CreateDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> CreateDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> CreateDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> CreateDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        #endregion


        #region dictionary whose key is a literal value

        internal static Dictionary<TKey, TValue?> CreateNullableDictionaryKey1<TKey, TValue>()
            where TKey : struct
            where TValue : struct
        {
            Dictionary<TKey, TValue?> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in GetNullableValues<TKey>())
                {
                    if (!key.HasValue) { continue; }

                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key.Value, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<TKey, (TValue1?, TValue2?)> CreateNullableDictionaryKey1<TKey, TValue1, TValue2>()
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator(); ;
                disposables.Add(values);

                foreach (var key in GetNullableValues<TKey>())
                {
                    if (!key.HasValue) { continue; }

                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator(); ;
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key.Value, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<TKey, (TValue1?, TValue2?, TValue3?)> CreateNullableDictionaryKey1<TKey, TValue1, TValue2, TValue3>()
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in GetNullableValues<TKey>())
                {
                    if (!key.HasValue) { continue; }

                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key.Value, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?)> CreateNullableDictionaryKey1<TKey, TValue1, TValue2, TValue3, TValue4>()
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in GetNullableValues<TKey>())
                {
                    if (!key.HasValue) { continue; }

                    if (!values.MoveNext())
                    {
                        values= CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key.Value, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> CreateNullableDictionaryKey1<TKey, TValue1, TValue2, TValue3, TValue4, TValue5>()
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in GetNullableValues<TKey>())
                {
                    if (!key.HasValue) { continue; }

                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key.Value, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> CreateNullableDictionaryKey1<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>()
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in GetNullableValues<TKey>())
                {
                    if (!key.HasValue) { continue; }

                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key.Value, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> CreateNullableDictionaryKey1<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>()
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in GetNullableValues<TKey>())
                {
                    if (!key.HasValue) { continue; }

                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key.Value, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> CreateNullableDictionaryKey1<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>()
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in GetNullableValues<TKey>())
                {
                    if (!key.HasValue) { continue; }

                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key.Value, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> CreateNullableDictionaryKey1<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>()
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in GetNullableValues<TKey>())
                {
                    if (!key.HasValue) { continue; }

                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key.Value, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        #endregion

        #region dictionary whose key is a 2-nullable values tuple

        internal static Dictionary<(TKey1?, TKey2?), TValue?> CreateNullableDictionaryKey2<TKey1, TKey2, TValue>()
            where TKey1 : struct
            where TKey2 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?), TValue?> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?)> CreateNullableDictionaryKey2<TKey1, TKey2, TValue1, TValue2>()
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?)> CreateNullableDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3>()
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?)> CreateNullableDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4>()
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> CreateNullableDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5>()
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> CreateNullableDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>()
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> CreateNullableDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>()
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> CreateNullableDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>()
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> CreateNullableDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>()
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        #endregion

        #region dictionary whose key is a 3-nullable values tuple

        internal static Dictionary<(TKey1?, TKey2?, TKey3?), TValue?> CreateNullableDictionaryKey3<TKey1, TKey2, TKey3, TValue>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), TValue?> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?)> CreateNullableDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?)> CreateNullableDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?)> CreateNullableDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> CreateNullableDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> CreateNullableDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> CreateNullableDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> CreateNullableDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> CreateNullableDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        #endregion

        #region dictionary whose key is a 4-nullable values tuple

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TValue?> CreateNullableDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TValue?> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?)> CreateNullableDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?)> CreateNullableDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?)> CreateNullableDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> CreateNullableDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> CreateNullableDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> CreateNullableDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> CreateNullableDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> CreateNullableDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        #endregion

        #region dictionary whose key is a 5-nullable values tuple

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TValue?> CreateNullableDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TValue?> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?)> CreateNullableDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?)> CreateNullableDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?)> CreateNullableDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> CreateNullableDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> CreateNullableDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> CreateNullableDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> CreateNullableDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> CreateNullableDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        #endregion

        #region dictionary whose key is a 6-nullable values tuple

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TValue?> CreateNullableDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TValue?> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?)> CreateNullableDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?)> CreateNullableDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?)> CreateNullableDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> CreateNullableDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> CreateNullableDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> CreateNullableDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> CreateNullableDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> CreateNullableDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        #endregion

        #region dictionary whose key is a 7-nullable values tuple

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TValue?> CreateNullableDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TValue?> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?)> CreateNullableDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?)> CreateNullableDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?)> CreateNullableDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> CreateNullableDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> CreateNullableDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> CreateNullableDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> CreateNullableDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> CreateNullableDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        #endregion

        #region dictionary whose key is a 8-nullable values tuple

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TValue?> CreateNullableDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TValue?> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?)> CreateNullableDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?)> CreateNullableDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?)> CreateNullableDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> CreateNullableDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> CreateNullableDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> CreateNullableDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> CreateNullableDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> CreateNullableDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        #endregion

        #region dictionary whose key is a 9-nullable values tuple

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TValue?> CreateNullableDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TValue?> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?)> CreateNullableDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?)> CreateNullableDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?)> CreateNullableDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> CreateNullableDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> CreateNullableDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> CreateNullableDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> CreateNullableDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        internal static Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> CreateNullableDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>()
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            List<IDisposable> disposables = new();

            try
            {
                var values = CreateNullableValues(dic).GetEnumerator();
                disposables.Add(values);

                foreach (var key in CreateNullableKeyValues(dic))
                {
                    if (!values.MoveNext())
                    {
                        values = CreateNullableValues(dic).GetEnumerator();
                        disposables.Add(values);
                        values.MoveNext();
                    }

                    dic.Add(key, values.Current);
                }

                return dic;
            }
            finally
            {
                disposables.ForEach(x => x.Dispose());
            }
        }

        #endregion

    }

}
