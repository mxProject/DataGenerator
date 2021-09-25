using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

using mxProject.Devs.DataGeneration;
using mxProject.Devs.DataGeneration.Fields;
using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Devs.DataGeneration.Configuration.Fields;
using System.ComponentModel.DataAnnotations;

using UnitTestProject1.Extensions;

namespace UnitTestProject1
{
    [TestClass]
    public class TestEachTuple
    {

        #region (T1, T2)

        private (int, StringValue)[] GetSampleValues2()
        {
            return new (int, StringValue)[]
            {
                (1, "a"),
                (2, "b"),
                (3, "c")
            };
        }

        private (int?, StringValue?)[] GetSampleNullableValues2()
        {
            return new (int?, StringValue?)[]
            {
                (1, "a"),
                (null, "b"),
                (3, null)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple2()
        {
            await GenerateAsync(30, GetSampleValues2()).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple2_Nullable()
        {
            await GenerateAsync(30, GetSampleNullableValues2()).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="enumerationCount"></param>
        /// <param name="sourceValues"></param>
        /// <returns></returns>
        private async ValueTask GenerateAsync<T1, T2>(int enumerationCount, IEnumerable<ValueTuple<T1, T2>> sourceValues)
            where T1 : struct
            where T2 : struct
        {
            var factory = new DataGeneratorFieldFactory();

            var field = factory.EachTuple("field1", "field2", sourceValues);

            using var fieldEnumeration = await field.CreateEnumerationAsync(enumerationCount).ConfigureAwait(false);

            using var sourceEnumerator = sourceValues.ToObjectArrayList().GetEnumerator();

            AssertValues(fieldEnumeration, sourceEnumerator, enumerationCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="enumerationCount"></param>
        /// <param name="sourceValues"></param>
        /// <returns></returns>
        private async ValueTask GenerateAsync<T1, T2>(int enumerationCount, IEnumerable<ValueTuple<T1?, T2?>> sourceValues)
            where T1 : struct
            where T2 : struct
        {
            var factory = new DataGeneratorFieldFactory();

            var field = factory.EachTuple("field1", "field2", sourceValues);

            using var fieldEnumeration = await field.CreateEnumerationAsync(enumerationCount).ConfigureAwait(false);

            using var sourceEnumerator = sourceValues.ToObjectArrayList().GetEnumerator();

            AssertValues(fieldEnumeration, sourceEnumerator, enumerationCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple2_FromConfigration()
        {
            var values = GetSampleNullableValues2();
            var expectedValues = values.ToObjectArrayList();

            var settings = new EachTupleFieldSettings()
            {
                Fields = new[]
                {
                     new DataGeneratorFieldInfo("field1", typeof(int)),
                     new DataGeneratorFieldInfo("field2", typeof(string))
                },
                Values = values.ToStringArrayList().ToArray()
            };

            await GenerateAsync(settings, expectedValues).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple2_UseBuilder()
        {
            var values = GetSampleValues2();
            var expectedValues = values.ToObjectArrayList();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple("field1", "field2", values))
                ;

            await GenerateAsync(builder, expectedValues).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple2_Nullable_UseBuilder()
        {
            var values = GetSampleNullableValues2();
            var expectedValues = values.ToObjectArrayList();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple("field1", "field2", values))
                ;

            await GenerateAsync(builder, expectedValues).ConfigureAwait(false);
        }

        #endregion

        #region (T1, T2, T3)

        private (int, StringValue, DayOfWeek)[] GetSampleValues3()
        {
            return new (int, StringValue, DayOfWeek)[]
            {
                (1, "a", DayOfWeek.Monday),
                (2, "b", DayOfWeek.Tuesday),
                (3, "c", DayOfWeek.Wednesday)
            };
        }

        private (int?, StringValue?, DayOfWeek?)[] GetSampleNullableValues3()
        {
            return new (int?, StringValue?, DayOfWeek?)[]
            {
                (1, "a", DayOfWeek.Monday),
                (null, "b", DayOfWeek.Tuesday),
                (3, null, DayOfWeek.Wednesday),
                (4, "d", null)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple3()
        {
            await GenerateAsync(30, GetSampleValues3()).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple3_Nullable()
        {
            await GenerateAsync(30, GetSampleNullableValues3()).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="enumerationCount"></param>
        /// <param name="sourceValues"></param>
        /// <returns></returns>
        private async ValueTask GenerateAsync<T1, T2, T3>(int enumerationCount, IEnumerable<ValueTuple<T1, T2, T3>> sourceValues)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            var factory = new DataGeneratorFieldFactory();

            var field = factory.EachTuple("field1", "field2", "field3", sourceValues);

            using var fieldEnumeration = await field.CreateEnumerationAsync(enumerationCount).ConfigureAwait(false);

            using var sourceEnumerator = sourceValues.ToObjectArrayList().GetEnumerator();

            AssertValues(fieldEnumeration, sourceEnumerator, enumerationCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="enumerationCount"></param>
        /// <param name="sourceValues"></param>
        /// <returns></returns>
        private async ValueTask GenerateAsync<T1, T2, T3>(int enumerationCount, IEnumerable<ValueTuple<T1?, T2?, T3?>> sourceValues)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            var factory = new DataGeneratorFieldFactory();

            var field = factory.EachTuple("field1", "field2", "field3", sourceValues);

            using var fieldEnumeration = await field.CreateEnumerationAsync(enumerationCount).ConfigureAwait(false);

            using var sourceEnumerator = sourceValues.ToObjectArrayList().GetEnumerator();

            AssertValues(fieldEnumeration, sourceEnumerator, enumerationCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple3_FromConfigration()
        {
            var values = GetSampleNullableValues3();
            var expectedValues = values.ToObjectArrayList();

            var settings = new EachTupleFieldSettings()
            {
                Fields = new[]
                {
                     new DataGeneratorFieldInfo("field1", typeof(int)),
                     new DataGeneratorFieldInfo("field2", typeof(string)),
                     new DataGeneratorFieldInfo("field3", typeof(DayOfWeek))
                },
                Values = values.ToStringArrayList().ToArray()
            };

            await GenerateAsync(settings, expectedValues).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple3_UseBuilder()
        {
            var values = GetSampleValues3();
            var expectedValues = values.ToObjectArrayList();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple("field1", "field2", "field3", values))
                ;

            await GenerateAsync(builder, expectedValues).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple3_Nullable_UseBuilder()
        {
            var values = GetSampleNullableValues3();
            var expectedValues = values.ToObjectArrayList();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple("field1", "field2", "field3", values))
                ;

            await GenerateAsync(builder, expectedValues).ConfigureAwait(false);
        }

        #endregion

        #region (T1, T2, T3, T4)

        private (int, StringValue, DayOfWeek, bool)[] GetSampleValues4()
        {
            return new (int, StringValue, DayOfWeek, bool)[]
            {
                (1, "a", DayOfWeek.Monday, true),
                (2, "b", DayOfWeek.Tuesday, false),
                (3, "c", DayOfWeek.Wednesday, true)
            };
        }

        private (int?, StringValue?, DayOfWeek?, bool?)[] GetSampleNullableValues4()
        {
            return new (int?, StringValue?, DayOfWeek?, bool?)[]
            {
                (1, "a", DayOfWeek.Monday, true),
                (null, "b", DayOfWeek.Tuesday, false),
                (3, null, DayOfWeek.Wednesday, true),
                (4, "d", null, false),
                (5, "e", DayOfWeek.Friday, null)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple4()
        {
            await GenerateAsync(30, GetSampleValues4()).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple4_Nullable()
        {
            await GenerateAsync(30, GetSampleNullableValues4()).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="enumerationCount"></param>
        /// <param name="sourceValues"></param>
        /// <returns></returns>
        private async ValueTask GenerateAsync<T1, T2, T3, T4>(int enumerationCount, IEnumerable<ValueTuple<T1, T2, T3, T4>> sourceValues)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            var factory = new DataGeneratorFieldFactory();

            var field = factory.EachTuple("field1", "field2", "field3", "field4", sourceValues);

            using var fieldEnumeration = await field.CreateEnumerationAsync(enumerationCount).ConfigureAwait(false);

            using var sourceEnumerator = sourceValues.ToObjectArrayList().GetEnumerator();

            AssertValues(fieldEnumeration, sourceEnumerator, enumerationCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="enumerationCount"></param>
        /// <param name="sourceValues"></param>
        /// <returns></returns>
        private async ValueTask GenerateAsync<T1, T2, T3, T4>(int enumerationCount, IEnumerable<ValueTuple<T1?, T2?, T3?, T4?>> sourceValues)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            var factory = new DataGeneratorFieldFactory();

            var field = factory.EachTuple("field1", "field2", "field3", "field4", sourceValues);

            using var fieldEnumeration = await field.CreateEnumerationAsync(enumerationCount).ConfigureAwait(false);

            using var sourceEnumerator = sourceValues.ToObjectArrayList().GetEnumerator();

            AssertValues(fieldEnumeration, sourceEnumerator, enumerationCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple4_FromConfigration()
        {
            var values = GetSampleNullableValues4();
            var expectedValues = values.ToObjectArrayList();

            var settings = new EachTupleFieldSettings()
            {
                Fields = new[]
                {
                     new DataGeneratorFieldInfo("field1", typeof(int)),
                     new DataGeneratorFieldInfo("field2", typeof(string)),
                     new DataGeneratorFieldInfo("field3", typeof(DayOfWeek)),
                     new DataGeneratorFieldInfo("field4", typeof(bool))
                },
                Values = values.ToStringArrayList().ToArray()
            };

            await GenerateAsync(settings, expectedValues).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple4_UseBuilder()
        {
            var values = GetSampleValues4();
            var expectedValues = values.ToObjectArrayList();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple("field1", "field2", "field3", "field4", values))
                ;

            await GenerateAsync(builder, expectedValues).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple4_Nullable_UseBuilder()
        {
            var values = GetSampleNullableValues4();
            var expectedValues = values.ToObjectArrayList();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple("field1", "field2", "field3", "field4", values))
                ;

            await GenerateAsync(builder, expectedValues).ConfigureAwait(false);
        }

        #endregion

        #region (T1, T2, T3, T4, T5)

        private (int, StringValue, DayOfWeek, bool, double)[] GetSampleValues5()
        {
            return new (int, StringValue, DayOfWeek, bool, double)[]
            {
                (1, "a", DayOfWeek.Monday, true, 1.1),
                (2, "b", DayOfWeek.Tuesday, false, 2.2),
                (3, "c", DayOfWeek.Wednesday, true, 3.3)
            };
        }

        private (int?, StringValue?, DayOfWeek?, bool?, double?)[] GetSampleNullableValues5()
        {
            return new (int?, StringValue?, DayOfWeek?, bool?, double?)[]
            {
                (1, "a", DayOfWeek.Monday, true, 1.1),
                (null, "b", DayOfWeek.Tuesday, false, 2.2),
                (3, null, DayOfWeek.Wednesday, true, 3.3),
                (4, "d", null, false, 4.4),
                (5, "e", DayOfWeek.Friday, null, 5.5),
                (6, "f", DayOfWeek.Saturday, false, null),
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple5()
        {
            await GenerateAsync(30, GetSampleValues5()).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple5_Nullable()
        {
            await GenerateAsync(30, GetSampleNullableValues5()).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="enumerationCount"></param>
        /// <param name="sourceValues"></param>
        /// <returns></returns>
        private async ValueTask GenerateAsync<T1, T2, T3, T4, T5>(int enumerationCount, IEnumerable<ValueTuple<T1, T2, T3, T4, T5>> sourceValues)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            var factory = new DataGeneratorFieldFactory();

            var field = factory.EachTuple("field1", "field2", "field3", "field4", "field5", sourceValues);

            using var fieldEnumeration = await field.CreateEnumerationAsync(enumerationCount).ConfigureAwait(false);

            using var sourceEnumerator = sourceValues.ToObjectArrayList().GetEnumerator();

            AssertValues(fieldEnumeration, sourceEnumerator, enumerationCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="enumerationCount"></param>
        /// <param name="sourceValues"></param>
        /// <returns></returns>
        private async ValueTask GenerateAsync<T1, T2, T3, T4, T5>(int enumerationCount, IEnumerable<ValueTuple<T1?, T2?, T3?, T4?, T5?>> sourceValues)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            var factory = new DataGeneratorFieldFactory();

            var field = factory.EachTuple("field1", "field2", "field3", "field4", "field5", sourceValues);

            using var fieldEnumeration = await field.CreateEnumerationAsync(enumerationCount).ConfigureAwait(false);

            using var sourceEnumerator = sourceValues.ToObjectArrayList().GetEnumerator();

            AssertValues(fieldEnumeration, sourceEnumerator, enumerationCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple5_FromConfigration()
        {
            var values = GetSampleNullableValues5();
            var expectedValues = values.ToObjectArrayList();

            var settings = new EachTupleFieldSettings()
            {
                Fields = new[]
                {
                     new DataGeneratorFieldInfo("field1", typeof(int)),
                     new DataGeneratorFieldInfo("field2", typeof(string)),
                     new DataGeneratorFieldInfo("field3", typeof(DayOfWeek)),
                     new DataGeneratorFieldInfo("field4", typeof(bool)),
                     new DataGeneratorFieldInfo("field5", typeof(double))
                },
                Values = values.ToStringArrayList().ToArray()
            };

            await GenerateAsync(settings, expectedValues).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple5_UseBuilder()
        {
            var values = GetSampleValues5();
            var expectedValues = values.ToObjectArrayList();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple("field1", "field2", "field3", "field4", "field5", values))
                ;

            await GenerateAsync(builder, expectedValues).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple5_Nullable_UseBuilder()
        {
            var values = GetSampleNullableValues5();
            var expectedValues = values.ToObjectArrayList();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple("field1", "field2", "field3", "field4", "field5", values))
                ;

            await GenerateAsync(builder, expectedValues).ConfigureAwait(false);
        }

        #endregion

        #region (T1, T2, T3, T4, T5, T6)

        private (int, StringValue, DayOfWeek, bool, double, decimal)[] GetSampleValues6()
        {
            return new (int, StringValue, DayOfWeek, bool, double, decimal)[]
            {
                (1, "a", DayOfWeek.Monday, true, 1.1, 1.11m),
                (2, "b", DayOfWeek.Tuesday, false, 2.2, 2.22m),
                (3, "c", DayOfWeek.Wednesday, true, 3.3, 3.33m)
            };
        }

        private (int?, StringValue?, DayOfWeek?, bool?, double?, decimal?)[] GetSampleNullableValues6()
        {
            return new (int?, StringValue?, DayOfWeek?, bool?, double?, decimal?)[]
            {
                (1, "a", DayOfWeek.Monday, true, 1.1, 1.11m),
                (null, "b", DayOfWeek.Tuesday, false, 2.2, 2.22m),
                (3, null, DayOfWeek.Wednesday, true, 3.3, 3.33m),
                (4, "d", null, false, 4.4, 4.44m),
                (5, "e", DayOfWeek.Friday, null, 5.5, 5.55m),
                (6, "f", DayOfWeek.Saturday, false, null, 6.66m),
                (7, "g", DayOfWeek.Sunday, true, 7.7, null)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple6()
        {
            await GenerateAsync(30, GetSampleValues6()).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple6_Nullable()
        {
            await GenerateAsync(30, GetSampleNullableValues6()).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <param name="enumerationCount"></param>
        /// <param name="sourceValues"></param>
        /// <returns></returns>
        private async ValueTask GenerateAsync<T1, T2, T3, T4, T5, T6>(int enumerationCount, IEnumerable<ValueTuple<T1, T2, T3, T4, T5, T6>> sourceValues)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            var factory = new DataGeneratorFieldFactory();

            var field = factory.EachTuple("field1", "field2", "field3", "field4", "field5", "field6", sourceValues);

            using var fieldEnumeration = await field.CreateEnumerationAsync(enumerationCount).ConfigureAwait(false);

            using var sourceEnumerator = sourceValues.ToObjectArrayList().GetEnumerator();

            AssertValues(fieldEnumeration, sourceEnumerator, enumerationCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <param name="enumerationCount"></param>
        /// <param name="sourceValues"></param>
        /// <returns></returns>
        private async ValueTask GenerateAsync<T1, T2, T3, T4, T5, T6>(int enumerationCount, IEnumerable<ValueTuple<T1?, T2?, T3?, T4?, T5?, T6?>> sourceValues)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            var factory = new DataGeneratorFieldFactory();

            var field = factory.EachTuple("field1", "field2", "field3", "field4", "field5", "field6", sourceValues);

            using var fieldEnumeration = await field.CreateEnumerationAsync(enumerationCount).ConfigureAwait(false);

            using var sourceEnumerator = sourceValues.ToObjectArrayList().GetEnumerator();

            AssertValues(fieldEnumeration, sourceEnumerator, enumerationCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple6_FromConfigration()
        {
            var values = GetSampleNullableValues6();
            var expectedValues = values.ToObjectArrayList();

            var settings = new EachTupleFieldSettings()
            {
                Fields = new[]
                {
                     new DataGeneratorFieldInfo("field1", typeof(int)),
                     new DataGeneratorFieldInfo("field2", typeof(string)),
                     new DataGeneratorFieldInfo("field3", typeof(DayOfWeek)),
                     new DataGeneratorFieldInfo("field4", typeof(bool)),
                     new DataGeneratorFieldInfo("field5", typeof(double)),
                     new DataGeneratorFieldInfo("field6", typeof(decimal))
                },
                Values = values.ToStringArrayList().ToArray()
            };

            await GenerateAsync(settings, expectedValues).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple6_UseBuilder()
        {
            var values = GetSampleValues6();
            var expectedValues = values.ToObjectArrayList();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple("field1", "field2", "field3", "field4", "field5", "field6", values))
                ;

            await GenerateAsync(builder, expectedValues).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple6_Nullable_UseBuilder()
        {
            var values = GetSampleNullableValues6();
            var expectedValues = values.ToObjectArrayList();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple("field1", "field2", "field3", "field4", "field5", "field6", values))
                ;

            await GenerateAsync(builder, expectedValues).ConfigureAwait(false);
        }

        #endregion

        #region (T1, T2, T3, T4, T5, T6, T7)

        private (int, StringValue, DayOfWeek, bool, double, decimal, DateTime)[] GetSampleValues7()
        {
            return new (int, StringValue, DayOfWeek, bool, double, decimal, DateTime)[]
            {
                (1, "a", DayOfWeek.Monday, true, 1.1, 1.11m, new DateTime(2021, 1, 1)),
                (2, "b", DayOfWeek.Tuesday, false, 2.2, 2.22m, new DateTime(2021, 2, 1)),
                (3, "c", DayOfWeek.Wednesday, true, 3.3, 3.33m, new DateTime(2021, 3, 1))
            };
        }

        private (int?, StringValue?, DayOfWeek?, bool?, double?, decimal?, DateTime?)[] GetSampleNullableValues7()
        {
            return new (int?, StringValue?, DayOfWeek?, bool?, double?, decimal?, DateTime?)[]
            {
                (1, "a", DayOfWeek.Monday, true, 1.1, 1.11m, new DateTime(2021, 1, 1)),
                (null, "b", DayOfWeek.Tuesday, false, 2.2, 2.22m, new DateTime(2021, 2, 1)),
                (3, null, DayOfWeek.Wednesday, true, 3.3, 3.33m, new DateTime(2021, 3, 1)),
                (4, "d", null, false, 4.4, 4.44m, new DateTime(2021, 4, 1)),
                (5, "e", DayOfWeek.Friday, null, 5.5, 5.55m, new DateTime(2021, 5, 1)),
                (6, "f", DayOfWeek.Saturday, false, null, 6.66m, new DateTime(2021, 5, 1)),
                (7, "g", DayOfWeek.Sunday, true, 7.7, null, new DateTime(2021, 7, 1)),
                (8, "h", DayOfWeek.Monday, false, 8.8, 8.88m, null),
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple7()
        {
            await GenerateAsync(30, GetSampleValues7()).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple7_Nullable()
        {
            await GenerateAsync(30, GetSampleNullableValues7()).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <param name="enumerationCount"></param>
        /// <param name="sourceValues"></param>
        /// <returns></returns>
        private async ValueTask GenerateAsync<T1, T2, T3, T4, T5, T6, T7>(int enumerationCount, IEnumerable<ValueTuple<T1, T2, T3, T4, T5, T6, T7>> sourceValues)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            var factory = new DataGeneratorFieldFactory();

            var field = factory.EachTuple("field1", "field2", "field3", "field4", "field5", "field6", "field7", sourceValues);

            using var fieldEnumeration = await field.CreateEnumerationAsync(enumerationCount).ConfigureAwait(false);

            using var sourceEnumerator = sourceValues.ToObjectArrayList().GetEnumerator();

            AssertValues(fieldEnumeration, sourceEnumerator, enumerationCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <param name="enumerationCount"></param>
        /// <param name="sourceValues"></param>
        /// <returns></returns>
        private async ValueTask GenerateAsync<T1, T2, T3, T4, T5, T6, T7>(int enumerationCount, IEnumerable<ValueTuple<T1?, T2?, T3?, T4?, T5?, T6?, T7?>> sourceValues)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            var factory = new DataGeneratorFieldFactory();

            var field = factory.EachTuple("field1", "field2", "field3", "field4", "field5", "field6", "field7", sourceValues);

            using var fieldEnumeration = await field.CreateEnumerationAsync(enumerationCount).ConfigureAwait(false);

            using var sourceEnumerator = sourceValues.ToObjectArrayList().GetEnumerator();

            AssertValues(fieldEnumeration, sourceEnumerator, enumerationCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple7_FromConfigration()
        {
            var values = GetSampleNullableValues7();
            var expectedValues = values.ToObjectArrayList();

            var settings = new EachTupleFieldSettings()
            {
                Fields = new[]
                {
                     new DataGeneratorFieldInfo("field1", typeof(int)),
                     new DataGeneratorFieldInfo("field2", typeof(string)),
                     new DataGeneratorFieldInfo("field3", typeof(DayOfWeek)),
                     new DataGeneratorFieldInfo("field4", typeof(bool)),
                     new DataGeneratorFieldInfo("field5", typeof(double)),
                     new DataGeneratorFieldInfo("field6", typeof(decimal)),
                     new DataGeneratorFieldInfo("field7", typeof(DateTime))
                },
                Values = values.ToStringArrayList().ToArray()
            };

            await GenerateAsync(settings, expectedValues).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple7_UseBuilder()
        {
            var values = GetSampleValues7();
            var expectedValues = values.ToObjectArrayList();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple("field1", "field2", "field3", "field4", "field5", "field6", "field7", values))
                ;

            await GenerateAsync(builder, expectedValues).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple7_Nullable_UseBuilder()
        {
            var values = GetSampleNullableValues7();
            var expectedValues = values.ToObjectArrayList();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple("field1", "field2", "field3", "field4", "field5", "field6", "field7", values))
                ;

            await GenerateAsync(builder, expectedValues).ConfigureAwait(false);
        }

        #endregion

        #region (T1, T2, T3, T4, T5, T6, T7, T8)

        private (int, StringValue, DayOfWeek, bool, double, decimal, DateTime, DateTimeOffset)[] GetSampleValues8()
        {
            return new (int, StringValue, DayOfWeek, bool, double, decimal, DateTime, DateTimeOffset)[]
            {
                (1, "a", DayOfWeek.Monday, true, 1.1, 1.11m, new DateTime(2021, 1, 1), new DateTimeOffset(new DateTime(2021, 1, 1))),
                (2, "b", DayOfWeek.Tuesday, false, 2.2, 2.22m, new DateTime(2021, 2, 1), new DateTimeOffset(new DateTime(2021, 2, 1))),
                (3, "c", DayOfWeek.Wednesday, true, 3.3, 3.33m, new DateTime(2021, 3, 1), new DateTimeOffset(new DateTime(2021, 3, 1)))
            };
        }

        private (int?, StringValue?, DayOfWeek?, bool?, double?, decimal?, DateTime?, DateTimeOffset?)[] GetSampleNullableValues8()
        {
            return new (int?, StringValue?, DayOfWeek?, bool?, double?, decimal?, DateTime?, DateTimeOffset?)[]
            {
                (1, "a", DayOfWeek.Monday, true, 1.1, 1.11m, new DateTime(2021, 1, 1), new DateTimeOffset(new DateTime(2021, 1, 1))),
                (null, "b", DayOfWeek.Tuesday, false, 2.2, 2.22m, new DateTime(2021, 2, 1), new DateTimeOffset(new DateTime(2021, 2, 1))),
                (3, null, DayOfWeek.Wednesday, true, 3.3, 3.33m, new DateTime(2021, 3, 1), new DateTimeOffset(new DateTime(2021, 3, 1))),
                (4, "d", null, false, 4.4, 4.44m, new DateTime(2021, 4, 1), new DateTimeOffset(new DateTime(2021, 4, 1))),
                (5, "e", DayOfWeek.Friday, null, 5.5, 5.55m, new DateTime(2021, 5, 1), new DateTimeOffset(new DateTime(2021, 5, 1))),
                (6, "f", DayOfWeek.Saturday, false, null, 6.66m, new DateTime(2021, 5, 1), new DateTimeOffset(new DateTime(2021, 6, 1))),
                (7, "g", DayOfWeek.Sunday, true, 7.7, null, new DateTime(2021, 7, 1), new DateTimeOffset(new DateTime(2021, 7, 1))),
                (8, "h", DayOfWeek.Monday, false, 8.8, 8.88m, null, new DateTimeOffset(new DateTime(2021, 8, 1))),
                (9, "i", DayOfWeek.Tuesday, true, 9.9, 9.99m, new DateTime(2021, 9, 1), null),
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple8()
        {
            await GenerateAsync(30, GetSampleValues8()).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple8_Nullable()
        {
            await GenerateAsync(30, GetSampleNullableValues8()).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <param name="enumerationCount"></param>
        /// <param name="sourceValues"></param>
        /// <returns></returns>
        private async ValueTask GenerateAsync<T1, T2, T3, T4, T5, T6, T7, T8>(int enumerationCount, IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8)> sourceValues)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            var factory = new DataGeneratorFieldFactory();

            var field = factory.EachTuple("field1", "field2", "field3", "field4", "field5", "field6", "field7", "field8", sourceValues);

            using var fieldEnumeration = await field.CreateEnumerationAsync(enumerationCount).ConfigureAwait(false);

            using var sourceEnumerator = sourceValues.ToObjectArrayList().GetEnumerator();

            AssertValues(fieldEnumeration, sourceEnumerator, enumerationCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <param name="enumerationCount"></param>
        /// <param name="sourceValues"></param>
        /// <returns></returns>
        private async ValueTask GenerateAsync<T1, T2, T3, T4, T5, T6, T7, T8>(int enumerationCount, IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)> sourceValues)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            var factory = new DataGeneratorFieldFactory();

            var field = factory.EachTuple("field1", "field2", "field3", "field4", "field5", "field6", "field7", "field8", sourceValues);

            using var fieldEnumeration = await field.CreateEnumerationAsync(enumerationCount).ConfigureAwait(false);

            using var sourceEnumerator = sourceValues.ToObjectArrayList().GetEnumerator();

            AssertValues(fieldEnumeration, sourceEnumerator, enumerationCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple8_FromConfigration()
        {
            var values = GetSampleNullableValues8();
            var expectedValues = values.ToObjectArrayList();

            var settings = new EachTupleFieldSettings()
            {
                Fields = new[]
                {
                     new DataGeneratorFieldInfo("field1", typeof(int)),
                     new DataGeneratorFieldInfo("field2", typeof(string)),
                     new DataGeneratorFieldInfo("field3", typeof(DayOfWeek)),
                     new DataGeneratorFieldInfo("field4", typeof(bool)),
                     new DataGeneratorFieldInfo("field5", typeof(double)),
                     new DataGeneratorFieldInfo("field6", typeof(decimal)),
                     new DataGeneratorFieldInfo("field7", typeof(DateTime)),
                     new DataGeneratorFieldInfo("field8", typeof(DateTimeOffset))
                },
                Values = values.ToStringArrayList().ToArray()
            };

            await GenerateAsync(settings, expectedValues).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple8_UseBuilder()
        {
            var values = GetSampleValues8();
            var expectedValues = values.ToObjectArrayList();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple("field1", "field2", "field3", "field4", "field5", "field6", "field7", "field8", values))
                ;

            await GenerateAsync(builder, expectedValues).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple8_Nullable_UseBuilder()
        {
            var values = GetSampleNullableValues8();
            var expectedValues = values.ToObjectArrayList();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple("field1", "field2", "field3", "field4", "field5", "field6", "field7", "field8", values))
                ;

            await GenerateAsync(builder, expectedValues).ConfigureAwait(false);
        }

        #endregion

        #region (T1, T2, T3, T4, T5, T6, T7, T8, T9)

        private (int, StringValue, DayOfWeek, bool, double, decimal, DateTime, DateTimeOffset, TimeSpan)[] GetSampleValues9()
        {
            return new (int, StringValue, DayOfWeek, bool, double, decimal, DateTime, DateTimeOffset, TimeSpan)[]
            {
                (1, "a", DayOfWeek.Monday, true, 1.1, 1.11m, new DateTime(2021, 1, 1), new DateTimeOffset(new DateTime(2021, 1, 1)), TimeSpan.FromMinutes(1)),
                (2, "b", DayOfWeek.Tuesday, false, 2.2, 2.22m, new DateTime(2021, 2, 1), new DateTimeOffset(new DateTime(2021, 2, 1)), TimeSpan.FromMinutes(2)),
                (3, "c", DayOfWeek.Wednesday, true, 3.3, 3.33m, new DateTime(2021, 3, 1), new DateTimeOffset(new DateTime(2021, 3, 1)), TimeSpan.FromMinutes(3))
            };
        }

        private (int?, StringValue?, DayOfWeek?, bool?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?)[] GetSampleNullableValues9()
        {
            return new (int?, StringValue?, DayOfWeek?, bool?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?)[]
            {
                (1, "a", DayOfWeek.Monday, true, 1.1, 1.11m, new DateTime(2021, 1, 1), new DateTimeOffset(new DateTime(2021, 1, 1)), TimeSpan.FromMinutes(1)),
                (null, "b", DayOfWeek.Tuesday, false, 2.2, 2.22m, new DateTime(2021, 2, 1), new DateTimeOffset(new DateTime(2021, 2, 1)), TimeSpan.FromMinutes(2)),
                (3, null, DayOfWeek.Wednesday, true, 3.3, 3.33m, new DateTime(2021, 3, 1), new DateTimeOffset(new DateTime(2021, 3, 1)), TimeSpan.FromMinutes(3)),
                (4, "d", null, false, 4.4, 4.44m, new DateTime(2021, 4, 1), new DateTimeOffset(new DateTime(2021, 4, 1)), TimeSpan.FromMinutes(4)),
                (5, "e", DayOfWeek.Friday, null, 5.5, 5.55m, new DateTime(2021, 5, 1), new DateTimeOffset(new DateTime(2021, 5, 1)), TimeSpan.FromMinutes(5)),
                (6, "f", DayOfWeek.Saturday, false, null, 6.66m, new DateTime(2021, 5, 1), new DateTimeOffset(new DateTime(2021, 6, 1)), TimeSpan.FromMinutes(6)),
                (7, "g", DayOfWeek.Sunday, true, 7.7, null, new DateTime(2021, 7, 1), new DateTimeOffset(new DateTime(2021, 7, 1)), TimeSpan.FromMinutes(7)),
                (8, "h", DayOfWeek.Monday, false, 8.8, 8.88m, null, new DateTimeOffset(new DateTime(2021, 8, 1)), TimeSpan.FromMinutes(8)),
                (9, "i", DayOfWeek.Tuesday, true, 9.9, 9.99m, new DateTime(2021, 9, 1), null, TimeSpan.FromMinutes(9)),
                (10, "j", DayOfWeek.Wednesday, false, 10.0, 10.00m, new DateTime(2021, 10, 1), new DateTimeOffset(new DateTime(2021, 10, 1)), null)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple9()
        {
            await GenerateAsync(30, GetSampleValues9()).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple9_Nullable()
        {
            await GenerateAsync(30, GetSampleNullableValues9()).ConfigureAwait(false);
        }

        /// <summary>
        /// 
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
        /// <param name="enumerationCount"></param>
        /// <param name="sourceValues"></param>
        /// <returns></returns>
        private async ValueTask GenerateAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(int enumerationCount, IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> sourceValues)
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
            var factory = new DataGeneratorFieldFactory();

            var field = factory.EachTuple("field1", "field2", "field3", "field4", "field5", "field6", "field7", "field8", "field9", sourceValues);

            using var fieldEnumeration = await field.CreateEnumerationAsync(enumerationCount).ConfigureAwait(false);

            using var sourceEnumerator = sourceValues.ToObjectArrayList().GetEnumerator();

            AssertValues(fieldEnumeration, sourceEnumerator, enumerationCount);
        }

        /// <summary>
        /// 
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
        /// <param name="enumerationCount"></param>
        /// <param name="sourceValues"></param>
        /// <returns></returns>
        private async ValueTask GenerateAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(int enumerationCount, IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)> sourceValues)
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
            var factory = new DataGeneratorFieldFactory();

            var field = factory.EachTuple("field1", "field2", "field3", "field4", "field5", "field6", "field7", "field8", "field9", sourceValues);

            using var fieldEnumeration = await field.CreateEnumerationAsync(enumerationCount).ConfigureAwait(false);

            using var sourceEnumerator = sourceValues.ToObjectArrayList().GetEnumerator();

            AssertValues(fieldEnumeration, sourceEnumerator, enumerationCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple9_FromConfigration()
        {
            var values = GetSampleNullableValues9();
            var expectedValues = values.ToObjectArrayList();

            var settings = new EachTupleFieldSettings()
            {
                Fields = new[]
                {
                     new DataGeneratorFieldInfo("field1", typeof(int)),
                     new DataGeneratorFieldInfo("field2", typeof(string)),
                     new DataGeneratorFieldInfo("field3", typeof(DayOfWeek)),
                     new DataGeneratorFieldInfo("field4", typeof(bool)),
                     new DataGeneratorFieldInfo("field5", typeof(double)),
                     new DataGeneratorFieldInfo("field6", typeof(decimal)),
                     new DataGeneratorFieldInfo("field7", typeof(DateTime)),
                     new DataGeneratorFieldInfo("field8", typeof(DateTimeOffset)),
                     new DataGeneratorFieldInfo("field9", typeof(TimeSpan))
                },
                Values = values.ToStringArrayList().ToArray()
            };

            await GenerateAsync(settings, expectedValues).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple9_UseBuilder()
        {
            var values = GetSampleValues9();
            var expectedValues = values.ToObjectArrayList();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple("field1", "field2", "field3", "field4", "field5", "field6", "field7", "field8", "field9", values))
                ;

            await GenerateAsync(builder, expectedValues).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task EachTuple9_Nullable_UseBuilder()
        {
            var values = GetSampleNullableValues9();
            var expectedValues = values.ToObjectArrayList();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple("field1", "field2", "field3", "field4", "field5", "field6", "field7", "field8", "field9", values))
                ;

            await GenerateAsync(builder, expectedValues).ConfigureAwait(false);
        }

        #endregion






        /// <summary>
        /// Generates values using the specified settings.
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="expectedValues"></param>
        /// <returns></returns>
        private static async Task GenerateAsync<TSetting>(TSetting settings, IList<object?[]> expectedValues)
            where TSetting : DataGeneratorTupleFieldSettings
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented);

            Debug.WriteLine(json);

            settings = Newtonsoft.Json.JsonConvert.DeserializeObject<TSetting>(json);

            var context = new DataGeneratorContext();

            var field = settings.CreateField(context);

            using var sourceEnumerator = expectedValues.GetEnumerator();
            using var fieldEnumeration = await field.CreateEnumerationAsync(30);

            AssertValues(fieldEnumeration, sourceEnumerator, 30);
        }


        /// <summary>
        /// Asserts the specified enumeration.
        /// </summary>
        /// <param name="fieldEnumeration"></param>
        /// <param name="sourceEnumerator"></param>
        /// <param name="expectedCount"></param>
        private static void AssertValues(IDataGeneratorTupleFieldEnumeration fieldEnumeration, IEnumerator<object?[]> sourceEnumerator, int expectedCount)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                for (int i = 0; i < fieldEnumeration.FieldCount; ++i)
                {
                    if (i > 0) { sb.Append("\t"); }
                    sb.Append(fieldEnumeration.GetFieldName(i));
                }

                sb.AppendLine();

                int count = 0;

                while (fieldEnumeration.GenerateNext())
                {
                    ++count;

                    if (!sourceEnumerator.MoveNext())
                    {
                        sourceEnumerator.Reset();
                        sourceEnumerator.MoveNext();
                    }

                    for (int i = 0; i < fieldEnumeration.FieldCount; ++i)
                    {
                        var value = fieldEnumeration.GetRawValue(i);

                        if (i > 0) { sb.Append("\t"); }
                        sb.Append(value ?? "(null)");

                        Assert.AreEqual(sourceEnumerator.Current[i], value);
                    }

                    sb.AppendLine();
                }

                Assert.AreEqual(expectedCount, count);
            }
            finally
            {
                Debug.WriteLine(sb.ToString());
            }
        }

        /// <summary>
        /// Generates values using the specified generator.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="expectedValues"></param>
        /// <returns></returns>
        private static async Task GenerateAsync(DataGeneratorBuilder builder, IList<object?[]> expectedValues)
        {
            using var generator = await builder.BuildAsync(30).ConfigureAwait(false);
            using var sourceEnumerator = expectedValues.GetEnumerator();

            AssertValues(generator, sourceEnumerator, 30);
        }

        /// <summary>
        /// Asserts the specified enumeration.
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="sourceEnumerator"></param>
        /// <param name="expectedCount"></param>
        private static void AssertValues(DataGenerator generator, IEnumerator<object?[]> sourceEnumerator, int expectedCount)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                for (int i = 0; i < generator.FieldCount; ++i)
                {
                    if (i > 0) { sb.Append("\t"); }
                    sb.Append(generator.GetFieldName(i));
                }

                sb.AppendLine();

                int count = 0;

                while (generator.GenerateNext())
                {
                    ++count;

                    if (!sourceEnumerator.MoveNext())
                    {
                        sourceEnumerator.Reset();
                        sourceEnumerator.MoveNext();
                    }

                    for (int i = 0; i < generator.FieldCount; ++i)
                    {
                        var value = generator.GetFieldRawValue(i);

                        if (i > 0) { sb.Append("\t"); }
                        sb.Append(value ?? "(null)");

                        Assert.AreEqual(sourceEnumerator.Current[i], value);
                    }

                    sb.AppendLine();
                }

                Assert.AreEqual(expectedCount, count);
            }
            finally
            {
                Debug.WriteLine(sb.ToString());
            }
        }

    }
}
