using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;

using mxProject.Devs.DataGeneration;
using mxProject.Devs.DataGeneration.Fields;
using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Devs.DataGeneration.Configuration.Fields;

using UnitTestProject1.Extensions;

namespace UnitTestProject1
{

    [TestClass]
    public class TestEachSettings
    {

        #region bool

        [TestMethod]
        public async Task EachBoolean()
        {
            int generateCount = 100;
            var values = new bool?[] { true, false, null };

            await EachStruct(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region byte

        [TestMethod]
        public async Task EachByte()
        {
            int generateCount = 100;
            var values = new byte?[] { 1, 2, 3, 4, null };

            await EachStruct(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region sbyte

        [TestMethod]
        public async Task EachSByte()
        {
            int generateCount = 100;
            var values = new sbyte?[] { 1, 2, 3, 4, null };

            await EachStruct(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region short

        [TestMethod]
        public async Task EachInt16()
        {
            int generateCount = 100;
            var values = new short?[] { 1, 2, 3, 4, null };

            await EachStruct(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region ushort

        [TestMethod]
        public async Task EachUInt16()
        {
            int generateCount = 100;
            var values = new ushort?[] { 1, 2, 3, 4, null };

            await EachStruct(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region int

        [TestMethod]
        public async Task EachInt32()
        {
            int generateCount = 100;
            var values = new int?[] { 1, 2, 3, 4, null };

            await EachStruct(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region uint

        [TestMethod]
        public async Task EachUInt32()
        {
            int generateCount = 100;
            var values = new uint?[] { 1, 2, 3, 4, null };

            await EachStruct(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region long

        [TestMethod]
        public async Task EachInt64()
        {
            int generateCount = 100;
            var values = new long?[] { 1, 2, 3, 4, null };

            await EachStruct(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region ulong

        [TestMethod]
        public async Task EachUInt64()
        {
            int generateCount = 100;
            var values = new ulong?[] { 1, 2, 3, 4, null };

            await EachStruct(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region float

        [TestMethod]
        public async Task EachSingle()
        {
            int generateCount = 100;
            var values = new float?[] { 1.1f, 2.2f, 3.3f, 4.4f, null };

            await EachStruct(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region double

        [TestMethod]
        public async Task EachDouble()
        {
            int generateCount = 100;
            var values = new double?[] { 1.1, 2.2, 3.3, 4.4, null };

            await EachStruct(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region decimal

        [TestMethod]
        public async Task EachDecimal()
        {
            int generateCount = 100;
            var values = new decimal?[] { 1.1m, 2.2m, 3.3m, 4.4m, null };

            await EachStruct(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region DateTime

        [TestMethod]
        public async Task EachDateTime()
        {
            int generateCount = 100;
            var values = new DateTime?[] { DateTime.Now, DateTime.UtcNow, DateTime.Today, null };

            await EachStruct(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region DateTimeOffset

        [TestMethod]
        public async Task EachDateTimeOffset()
        {
            int generateCount = 100;
            var values = new DateTimeOffset?[] { DateTime.Now, DateTime.UtcNow, DateTime.Today, null };

            await EachStruct(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region TimeSpan

        [TestMethod]
        public async Task EachTimeSpan()
        {
            int generateCount = 100;
            var values = new TimeSpan?[] { TimeSpan.FromDays(1), TimeSpan.FromHours(2), TimeSpan.FromMinutes(3), null };

            await EachStruct(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region char

        [TestMethod]
        public async Task EachChar()
        {
            int generateCount = 100;
            var values = new char?[] { 'a', 'b', 'c', 'd', null };

            await EachStruct(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region StringValue

        [TestMethod]
        public async Task EachStringValue()
        {
            int generateCount = 100;
            var values = new StringValue?[] { "a", "b", "c", "d", "", null };

            await EachStruct(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region String

        [TestMethod]
        public async Task EachString()
        {
            int generateCount = 100;
            var values = new string?[] { "a", "b", "c", "d", "", null };

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new EachStringFieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        Values = values
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, values);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, values);
        }

        #endregion

        #region Enum

        [TestMethod]
        public async Task EachEnum()
        {
            int generateCount = 100;
            var names = new string?[] {
                nameof(DayOfWeek.Monday),
                nameof(DayOfWeek.Thursday),
                nameof(DayOfWeek.Wednesday),
                nameof(DayOfWeek.Thursday),
                nameof(DayOfWeek.Friday),
                null
            };
            var values = new DayOfWeek?[] {
                DayOfWeek.Monday,
                DayOfWeek.Thursday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                null
            };

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new EachEnumFieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        Values = names,
                        EnumTypeName = typeof(DayOfWeek).FullName
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, values);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, values);
        }

        #endregion



        private async Task EachStruct<T>(int generateCount, T?[] values)
            where T : struct
        {

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new EachFieldSettings<T>()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        Values = values
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, values);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, values);

        }

        private static void EnumerateValues<T>(DataGenerator generator, int expectedCount, IList<T> sourceValues)
        {
            int count = 0;

            using var expectedValues = Enumerate(sourceValues).GetEnumerator();

            while (generator.GenerateNext())
            {
                expectedValues.MoveNext();
                var expectedValue = expectedValues.Current;

                if (!generator.GetFieldValueIsNull(0))
                {
                    var value = generator.GetFieldValue(0)!;
                    TestUtility.AssertAreEqual(expectedValue, value);
                }

                ++count;
            }

            Assert.AreEqual(expectedCount, count);
        }

        private static void EnumerateValues<T>(IDataGenerationReader reader, int expectedCount, IList<T> sourceValues)
        {
            int count = 0;

            using var expectedValues = Enumerate(sourceValues).GetEnumerator();

            StringBuilder sb = new();

            TestUtility.DumpHeader(reader, sb);

            while (reader.Read())
            {
                TestUtility.DumpRecord(reader, sb);

                expectedValues.MoveNext();
                var expectedValue = expectedValues.Current;

                if (!reader.IsDBNull(0))
                {
                    var value = reader.GetValue(0);
                    TestUtility.AssertAreEqual(expectedValue, value);
                }

                ++count;
            }

            Debug.WriteLine(sb.ToString());

            Assert.AreEqual(expectedCount, count);
        }

        private static IEnumerable<T> Enumerate<T>(IList<T> sourceValues)
        {
            while (true)
            {
                foreach (var value in sourceValues)
                {
                    yield return value;
                }
            }
        }

    }

}
