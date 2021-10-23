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
    public class TestAnySettings
    {

        #region bool

        [TestMethod]
        public async Task AnyBoolean()
        {
            int generateCount = 100;
            var values = new bool?[] { true, false, null };

            await AnyStruct(generateCount, values).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task AnyBoolean_NonGeneric()
        {
            int generateCount = 100;
            var values = new bool?[] { true, false, null };

            await AnyStruct_NonGeneric(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region byte

        [TestMethod]
        public async Task AnyByte()
        {
            int generateCount = 100;
            var values = new byte?[] { 1, 2, 3, 4, null };

            await AnyStruct(generateCount, values).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task AnyByte_NonGeneric()
        {
            int generateCount = 100;
            var values = new byte?[] { 1, 2, 3, 4, null };

            await AnyStruct_NonGeneric(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region sbyte

        [TestMethod]
        public async Task AnySByte()
        {
            int generateCount = 100;
            var values = new sbyte?[] { 1, 2, 3, 4, null };

            await AnyStruct(generateCount, values).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task AnySByte_NonGeneric()
        {
            int generateCount = 100;
            var values = new sbyte?[] { 1, 2, 3, 4, null };

            await AnyStruct_NonGeneric(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region short

        [TestMethod]
        public async Task AnyInt16()
        {
            int generateCount = 100;
            var values = new short?[] { 1, 2, 3, 4, null };

            await AnyStruct(generateCount, values).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task AnyInt16_NonGeneric()
        {
            int generateCount = 100;
            var values = new short?[] { 1, 2, 3, 4, null };

            await AnyStruct_NonGeneric(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region ushort

        [TestMethod]
        public async Task AnyUInt16()
        {
            int generateCount = 100;
            var values = new ushort?[] { 1, 2, 3, 4, null };

            await AnyStruct(generateCount, values).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task AnyUInt16_NonGeneric()
        {
            int generateCount = 100;
            var values = new ushort?[] { 1, 2, 3, 4, null };

            await AnyStruct_NonGeneric(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region int

        [TestMethod]
        public async Task AnyInt32()
        {
            int generateCount = 100;
            var values = new int?[] { 1, 2, 3, 4, null };

            await AnyStruct(generateCount, values).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task AnyInt32_NonGeneric()
        {
            int generateCount = 100;
            var values = new int?[] { 1, 2, 3, 4, null };

            await AnyStruct_NonGeneric(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region uint

        [TestMethod]
        public async Task AnyUInt32()
        {
            int generateCount = 100;
            var values = new uint?[] { 1, 2, 3, 4, null };

            await AnyStruct(generateCount, values).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task AnyUInt32_NonGeneric()
        {
            int generateCount = 100;
            var values = new uint?[] { 1, 2, 3, 4, null };

            await AnyStruct_NonGeneric(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region long

        [TestMethod]
        public async Task AnyInt64()
        {
            int generateCount = 100;
            var values = new long?[] { 1, 2, 3, 4, null };

            await AnyStruct(generateCount, values).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task AnyInt64_NonGeneric()
        {
            int generateCount = 100;
            var values = new long?[] { 1, 2, 3, 4, null };

            await AnyStruct_NonGeneric(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region ulong

        [TestMethod]
        public async Task AnyUInt64()
        {
            int generateCount = 100;
            var values = new ulong?[] { 1, 2, 3, 4, null };

            await AnyStruct(generateCount, values).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task AnyUInt64_NonGeneric()
        {
            int generateCount = 100;
            var values = new ulong?[] { 1, 2, 3, 4, null };

            await AnyStruct_NonGeneric(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region float

        [TestMethod]
        public async Task AnySingle()
        {
            int generateCount = 100;
            var values = new float?[] { 1.1f, 2.2f, 3.3f, 4.4f, null };

            await AnyStruct(generateCount, values).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task AnySingle_NonGeneric()
        {
            int generateCount = 100;
            var values = new float?[] { 1.1f, 2.2f, 3.3f, 4.4f, null };

            await AnyStruct_NonGeneric(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region double

        [TestMethod]
        public async Task AnyDouble()
        {
            int generateCount = 100;
            var values = new double?[] { 1.1, 2.2, 3.3, 4.4, null };

            await AnyStruct(generateCount, values).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task AnyDouble_NonGeneric()
        {
            int generateCount = 100;
            var values = new double?[] { 1.1, 2.2, 3.3, 4.4, null };

            await AnyStruct_NonGeneric(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region decimal

        [TestMethod]
        public async Task AnyDecimal()
        {
            int generateCount = 100;
            var values = new decimal?[] { 1.1m, 2.2m, 3.3m, 4.4m, null };

            await AnyStruct(generateCount, values).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task AnyDecimal_NonGeneric()
        {
            int generateCount = 100;
            var values = new decimal?[] { 1.1m, 2.2m, 3.3m, 4.4m, null };

            await AnyStruct_NonGeneric(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region DateTime

        [TestMethod]
        public async Task AnyDateTime()
        {
            int generateCount = 100;
            var values = new DateTime?[] { DateTime.Now, DateTime.UtcNow, DateTime.Today, null };

            await AnyStruct(generateCount, values).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task AnyDateTime_NonGeneric()
        {
            int generateCount = 100;
            var values = new DateTime?[] 
            {
                new DateTime(2021, 1, 2, 3, 4, 5, DateTimeKind.Unspecified),
                new DateTime(2021, 1, 2, 0, 0, 0, DateTimeKind.Unspecified),
                null
            };

            await AnyStruct_NonGeneric(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region DateTimeOffset

        [TestMethod]
        public async Task AnyDateTimeOffset()
        {
            int generateCount = 100;
            var values = new DateTimeOffset?[] { DateTime.Now, DateTime.UtcNow, DateTime.Today, null };

            await AnyStruct(generateCount, values).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task AnyDateTimeOffset_NonGeneric()
        {
            int generateCount = 100;
            var values = new DateTimeOffset?[]
            {
                new DateTime(2021, 1, 2, 3, 4, 5, DateTimeKind.Unspecified),
                new DateTime(2021, 1, 2, 0, 0, 0, DateTimeKind.Unspecified),
                null
            };

            await AnyStruct_NonGeneric(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region TimeSpan

        [TestMethod]
        public async Task AnyTimeSpan()
        {
            int generateCount = 100;
            var values = new TimeSpan?[] { TimeSpan.FromDays(1), TimeSpan.FromHours(2), TimeSpan.FromMinutes(3), null };

            await AnyStruct(generateCount, values).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task AnyTimeSpan_NonGeneric()
        {
            int generateCount = 100;
            var values = new TimeSpan?[] { TimeSpan.FromDays(1), TimeSpan.FromHours(2), TimeSpan.FromMinutes(3), null };

            await AnyStruct_NonGeneric(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region char

        [TestMethod]
        public async Task AnyChar()
        {
            int generateCount = 100;
            var values = new char?[] { 'a', 'b', 'c', 'd', null };

            await AnyStruct(generateCount, values).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task AnyChar_NonGeneric()
        {
            int generateCount = 100;
            var values = new char?[] { 'a', 'b', 'c', 'd', null };

            await AnyStruct_NonGeneric(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region StringValue

        [TestMethod]
        public async Task AnyStringValue()
        {
            int generateCount = 100;
            var values = new StringValue?[] { "a", "b", "c", "d", "", null };

            await AnyStruct(generateCount, values).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task AnyStringValue_NonGeneric()
        {
            int generateCount = 100;
            var values = new StringValue?[] { "a", "b", "c", "d", "", null };

            await AnyStruct_NonGeneric(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region String

        [TestMethod]
        public async Task AnyString()
        {
            int generateCount = 100;
            var values = new string?[] { "a", "b", "c", "d", "", null };

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new AnyStringFieldSettings()
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

        [TestMethod]
        public async Task AnyString_NonGenetic()
        {
            int generateCount = 100;
            var values = new string?[] { "a", "b", "c", "d", "", null };

            await Any_NonGeneric(generateCount, values).ConfigureAwait(false);
        }

        #endregion

        #region Enum

        [TestMethod]
        public async Task AnyEnum()
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
                    new AnyEnumFieldSettings()
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

        [TestMethod]
        public async Task AnyEnum_NonGeneric()
        {
            int generateCount = 100;
            var values = new DayOfWeek?[] {
                DayOfWeek.Monday,
                DayOfWeek.Thursday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                null
            };

            await AnyStruct_NonGeneric(generateCount, values).ConfigureAwait(false);
        }

        #endregion


        private async Task AnyStruct<T>(int generateCount, T?[] values)
            where T : struct
        {

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new AnyFieldSettings<T>()
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

            var expectedValues = new HashSet<T>(sourceValues);

            while (generator.GenerateNext())
            {
                if (!generator.GetFieldValueIsNull(0))
                {
                    var value = generator.GetFieldValue(0)!;
                    Assert.IsTrue(ContainsValue(expectedValues, value));
                }

                ++count;
            }

            Assert.AreEqual(expectedCount, count);
        }

        private static void EnumerateValues<T>(IDataGenerationReader reader, int expectedCount, IList<T> sourceValues)
        {
            int count = 0;

            var expectedValues = new HashSet<T>(sourceValues);

            StringBuilder sb = new();

            TestUtility.DumpHeader(reader, sb);

            while (reader.Read())
            {
                TestUtility.DumpRecord(reader, sb);

                if (!reader.IsDBNull(0))
                {
                    var value = reader.GetValue(0);
                    Assert.IsTrue(ContainsValue(expectedValues, value));
                }

                ++count;
            }

            Debug.WriteLine(sb.ToString());

            Assert.AreEqual(expectedCount, count);
        }

        private static bool ContainsValue<T>(HashSet<T> expectedValues, object value)
        {
            if (value is T t)
            {
                return expectedValues.Contains(t);
            }

            if (typeof(T) == typeof(string))
            {
                return expectedValues.Contains((T)(object)Convert.ToString(value)!);
            }

            if (typeof(T) == typeof(StringValue) || typeof(T) == typeof(StringValue?))
            {
                return expectedValues.Contains((T)(object)new StringValue(Convert.ToString(value)!));
            }

            return false;
        }


        private async Task AnyStruct_NonGeneric<T>(int generateCount, T?[] values)
             where T : struct
        {
            static string?[] ToString(T?[] values)
            {
                string?[] converted = new string?[values.Length];

                for (int i = 0; i < values.Length; ++i)
                {
                    converted[i] = values[i]?.ToString();
                }

                return converted;
            }

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new AnyFieldSettings()
                    {
                        ValueTypeName = typeof(T).FullName,
                        FieldName = "field1",
                        NullProbability = 0.1,
                        Values = ToString(values)
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

        private async Task Any_NonGeneric<T>(int generateCount, T?[] values)
        {
            static string?[] ToString(T?[] values)
            {
                string?[] converted = new string?[values.Length];

                for (int i = 0; i < values.Length; ++i)
                {
                    converted[i] = values[i]?.ToString();
                }

                return converted;
            }

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new AnyFieldSettings()
                    {
                        ValueTypeName = typeof(T).FullName,
                        FieldName = "field1",
                        NullProbability = 0.1,
                        Values = ToString(values)
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

    }

}
