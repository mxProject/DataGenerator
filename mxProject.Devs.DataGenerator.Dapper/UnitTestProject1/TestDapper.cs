using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Text;
using Dapper;

using mxProject.Devs.DataGeneration;

namespace UnitTestProject1
{

    [TestClass]
    public class TestDapper
    {

        #region sample data

        private static ValueTask<DataGenerator> CreateDataGeneratorAsync(int dataCount)
        {
            DataGeneratorFieldFactory factory = new DataGeneratorFieldFactory();

            DataGeneratorBuilder builder = new DataGeneratorBuilder(factory)
                .AddField(factory.SequenceInt32(nameof(GeneratingFields.code), 1))
                .AddField(factory.Each(nameof(GeneratingFields.value), new char[] { 'A', 'B', 'C' }, nullProbability: 0.1))
                .AddField(factory.SequenceInt32(nameof(GeneratingFields.code1), 101))
                .AddField(factory.Each(nameof(GeneratingFields.value1), new StringValue[] { "AAA", "BBB", "CCC" }, nullProbability:0.1))
                .AddField(factory.SequenceInt32(nameof(GeneratingFields.code2), 201))
                .AddField(factory.Each(nameof(GeneratingFields.value2), new short[] { 10, 20, 30 }, nullProbability: 0.1))
                .AddField(factory.SequenceInt32(nameof(GeneratingFields.code3), 301))
                .AddField(factory.Each(nameof(GeneratingFields.value3), new int[] { 100, 200, 300 }, nullProbability: 0.1))
                .AddField(factory.SequenceInt32(nameof(GeneratingFields.code4), 401))
                .AddField(factory.Each(nameof(GeneratingFields.value4), new long[] { 1000, 2000, 3000 }, nullProbability: 0.1))
                .AddField(factory.SequenceInt32(nameof(GeneratingFields.code5), 501))
                .AddField(factory.Each(nameof(GeneratingFields.value5), new double[] { 1.1, 2.2, 3.3 }, nullProbability: 0.1))
                .AddField(factory.SequenceInt32(nameof(GeneratingFields.code6), 601))
                .AddField(factory.Each(nameof(GeneratingFields.value6), new DateTime[] { DateTime.Today, DateTime.Today.AddDays(1), DateTime.Today.AddDays(2) }, nullProbability: 0.1))
                .AddField(factory.SequenceInt32(nameof(GeneratingFields.code7), 701))
                .AddField(factory.Each(nameof(GeneratingFields.value7), new TimeSpan[] { TimeSpan.FromHours(1), TimeSpan.FromMinutes(2), TimeSpan.FromSeconds(3) }, nullProbability: 0.1))
                .AddField(factory.SequenceInt32(nameof(GeneratingFields.code8), 801))
                .AddField(factory.Each(nameof(GeneratingFields.value8), new decimal[] { 1.11m, 2.22m, 3.33m }, nullProbability: 0.1))
                .AddField(factory.SequenceInt32(nameof(GeneratingFields.code9), 901))
                .AddField(factory.Each(nameof(GeneratingFields.value9), new bool[] { true, true, false }, nullProbability: 0.1))
                ;

            return builder.BuildAsync(dataCount);
        }

        private enum GeneratingFields
        {
            code = 0,
            value,
            code1,
            value1,
            code2,
            value2,
            code3,
            value3,
            code4,
            value4,
            code5,
            value5,
            code6,
            value6,
            code7,
            value7,
            code8,
            value8,
            code9,
            value9,
        }

        private class SampleClass<T>
        {
            public int Code { get; private set; }

            public T Value { get; private set; } = default!;

            public override string ToString()
            {
                return "{" + $"Code = {Code}, Value = {Value}" + "}";
            }
        }

        private IList<MappingFieldNameInfo[]> CreateMappingFieldNames(int mappingObjectCount)
        {
            var list = new List<MappingFieldNameInfo[]>();

            if (mappingObjectCount >= 1)
            {
                list.Add(new MappingFieldNameInfo[] {
                    new MappingFieldNameInfo(nameof(GeneratingFields.code1), "code"),
                    new MappingFieldNameInfo(nameof(GeneratingFields.value1), "value"),
                });
            }

            if (mappingObjectCount >= 2)
            {
                list.Add(new MappingFieldNameInfo[] {
                    new MappingFieldNameInfo(nameof(GeneratingFields.code2), "code"),
                    new MappingFieldNameInfo(nameof(GeneratingFields.value2), "value"),
                });
            }

            if (mappingObjectCount >= 3)
            {
                list.Add(new MappingFieldNameInfo[] {
                    new MappingFieldNameInfo(nameof(GeneratingFields.code3), "code"),
                    new MappingFieldNameInfo(nameof(GeneratingFields.value3), "value"),
                });
            }

            if (mappingObjectCount >= 4)
            {
                list.Add(new MappingFieldNameInfo[] {
                    new MappingFieldNameInfo(nameof(GeneratingFields.code4), "code"),
                    new MappingFieldNameInfo(nameof(GeneratingFields.value4), "value"),
                });
            }

            if (mappingObjectCount >= 5)
            {
                list.Add(new MappingFieldNameInfo[] {
                    new MappingFieldNameInfo(nameof(GeneratingFields.code5), "code"),
                    new MappingFieldNameInfo(nameof(GeneratingFields.value5), "value"),
                });
            }

            if (mappingObjectCount >= 6)
            {
                list.Add(new MappingFieldNameInfo[] {
                    new MappingFieldNameInfo(nameof(GeneratingFields.code6), "code"),
                    new MappingFieldNameInfo(nameof(GeneratingFields.value6), "value"),
                });
            }

            if (mappingObjectCount >= 7)
            {
                list.Add(new MappingFieldNameInfo[] {
                    new MappingFieldNameInfo(nameof(GeneratingFields.code7), "code"),
                    new MappingFieldNameInfo(nameof(GeneratingFields.value7), "value"),
                });
            }

            if (mappingObjectCount >= 8)
            {
                list.Add(new MappingFieldNameInfo[] {
                    new MappingFieldNameInfo(nameof(GeneratingFields.code8), "code"),
                    new MappingFieldNameInfo(nameof(GeneratingFields.value8), "value"),
                });
            }

            if (mappingObjectCount >= 9)
            {
                list.Add(new MappingFieldNameInfo[] {
                    new MappingFieldNameInfo(nameof(GeneratingFields.code9), "code"),
                    new MappingFieldNameInfo(nameof(GeneratingFields.value9), "value"),
                });
            }

            return list;
        }

        private IList<MappingFieldIndexInfo[]> CreateMappingFieldIndexes(int mappingObjectCount)
        {
            var list = new List<MappingFieldIndexInfo[]>();

            if (mappingObjectCount >= 1)
            {
                list.Add(new MappingFieldIndexInfo[] {
                    new MappingFieldIndexInfo((int)GeneratingFields.code1, "code"),
                    new MappingFieldIndexInfo((int)GeneratingFields.value1, "value"),
                });
            }

            if (mappingObjectCount >= 2)
            {
                list.Add(new MappingFieldIndexInfo[] {
                    new MappingFieldIndexInfo((int)GeneratingFields.code2, "code"),
                    new MappingFieldIndexInfo((int)GeneratingFields.value2, "value"),
                });
            }

            if (mappingObjectCount >= 3)
            {
                list.Add(new MappingFieldIndexInfo[] {
                    new MappingFieldIndexInfo((int)GeneratingFields.code3, "code"),
                    new MappingFieldIndexInfo((int)GeneratingFields.value3, "value"),
                });
            }

            if (mappingObjectCount >= 4)
            {
                list.Add(new MappingFieldIndexInfo[] {
                    new MappingFieldIndexInfo((int)GeneratingFields.code4, "code"),
                    new MappingFieldIndexInfo((int)GeneratingFields.value4, "value"),
                });
            }

            if (mappingObjectCount >= 5)
            {
                list.Add(new MappingFieldIndexInfo[] {
                    new MappingFieldIndexInfo((int)GeneratingFields.code5, "code"),
                    new MappingFieldIndexInfo((int)GeneratingFields.value5, "value"),
                });
            }

            if (mappingObjectCount >= 6)
            {
                list.Add(new MappingFieldIndexInfo[] {
                    new MappingFieldIndexInfo((int)GeneratingFields.code6, "code"),
                    new MappingFieldIndexInfo((int)GeneratingFields.value6, "value"),
                });
            }

            if (mappingObjectCount >= 7)
            {
                list.Add(new MappingFieldIndexInfo[] {
                    new MappingFieldIndexInfo((int)GeneratingFields.code7, "code"),
                    new MappingFieldIndexInfo((int)GeneratingFields.value7, "value"),
                });
            }

            if (mappingObjectCount >= 8)
            {
                list.Add(new MappingFieldIndexInfo[] {
                    new MappingFieldIndexInfo((int)GeneratingFields.code8, "code"),
                    new MappingFieldIndexInfo((int)GeneratingFields.value8, "value"),
                });
            }

            if (mappingObjectCount >= 9)
            {
                list.Add(new MappingFieldIndexInfo[] {
                    new MappingFieldIndexInfo((int)GeneratingFields.code9, "code"),
                    new MappingFieldIndexInfo((int)GeneratingFields.value9, "value"),
                });
            }

            return list;
        }

        #endregion


        #region simple

        [TestMethod]
        public async Task Simple()
        {
            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.Map<SampleClass<char?>>())
            {
                expectedReader.Read();

                Debug.WriteLine(obj);

                AssertAreEqualOrNull(expectedReader[nameof(GeneratingFields.value)], obj.Value);
            }
        }

        [TestMethod]
        public async Task Simple_NonGeneric()
        {
            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.Map(typeof(SampleClass<char?>)))
            {
                expectedReader.Read();

                Debug.WriteLine(obj);

                SampleClass<char?> sample = (SampleClass<char?>)obj;
                AssertAreEqualOrNull(expectedReader[nameof(GeneratingFields.value)], sample.Value);
            }
        }

        #endregion

        #region multi (2 objects)

        [TestMethod]
        public async Task MultiByName2()
        {
            IList<MappingFieldNameInfo[]> mappings = CreateMappingFieldNames(2);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldName(
                mappings[0],
                mappings[1],
                (SampleClass<string> obj1, SampleClass<short?> obj2) => (obj1, obj2)
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByName2_NonGeneric()
        {
            IList<MappingFieldNameInfo[]> mappings = CreateMappingFieldNames(2);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldName(
                typeof(SampleClass<string>),
                mappings[0],
                typeof(SampleClass<short?>),
                mappings[1],
                obj => (obj[0], obj[1])
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByIndex2()
        {
            IList<MappingFieldIndexInfo[]> mappings = CreateMappingFieldIndexes(2);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldIndex(
                mappings[0],
                mappings[1],
                (SampleClass<string> obj1, SampleClass<short?> obj2) => (obj1, obj2)
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByIndex2_NonGeneric()
        {
            IList<MappingFieldIndexInfo[]> mappings = CreateMappingFieldIndexes(2);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldIndex(
                typeof(SampleClass<string>),
                mappings[0],
                typeof(SampleClass<short?>),
                mappings[1],
                obj => (obj[0], obj[1])
                ))
            {
                Debug.WriteLine(obj);
            }
        }

        #endregion

        #region multi (3 objects)

        [TestMethod]
        public async Task MultiByName3()
        {
            IList<MappingFieldNameInfo[]> mappings = CreateMappingFieldNames(3);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldName(
                mappings[0],
                mappings[1],
                mappings[2],
                (SampleClass<string> obj1, SampleClass<short?> obj2, SampleClass<int?> obj3) => (obj1, obj2, obj3)
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByName3_NonGeneric()
        {
            IList<MappingFieldNameInfo[]> mappings = CreateMappingFieldNames(3);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldName(
                typeof(SampleClass<string>),
                mappings[0],
                typeof(SampleClass<short?>),
                mappings[1],
                typeof(SampleClass<int?>),
                mappings[2],
                obj => (obj[0], obj[1], obj[2])
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByIndex3()
        {
            IList<MappingFieldIndexInfo[]> mappings = CreateMappingFieldIndexes(3);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldIndex(
                mappings[0],
                mappings[1],
                mappings[2],
                (SampleClass<string> obj1, SampleClass<short?> obj2, SampleClass<int?> obj3) => (obj1, obj2, obj3)
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByIndex3_NonGeneric()
        {
            IList<MappingFieldIndexInfo[]> mappings = CreateMappingFieldIndexes(3);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldIndex(
                typeof(SampleClass<string>),
                mappings[0],
                typeof(SampleClass<short?>),
                mappings[1],
                typeof(SampleClass<int?>),
                mappings[2],
                obj => (obj[0], obj[1], obj[2])
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        #endregion

        #region multi (4 objects)

        [TestMethod]
        public async Task MultiByName4()
        {
            IList<MappingFieldNameInfo[]> mappings = CreateMappingFieldNames(4);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldName(
                mappings[0],
                mappings[1],
                mappings[2],
                mappings[3],
                (SampleClass<string> obj1, SampleClass<short?> obj2, SampleClass<int?> obj3, SampleClass<long?> obj4) => (obj1, obj2, obj3, obj4)
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByName4_NonGeneric()
        {
            IList<MappingFieldNameInfo[]> mappings = CreateMappingFieldNames(4);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldName(
                typeof(SampleClass<string>),
                mappings[0],
                typeof(SampleClass<short?>),
                mappings[1],
                typeof(SampleClass<int?>),
                mappings[2],
                typeof(SampleClass<long?>),
                mappings[3],
                obj => (obj[0], obj[1], obj[2], obj[3])
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByIndex4()
        {
            IList<MappingFieldIndexInfo[]> mappings = CreateMappingFieldIndexes(4);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldIndex(
                mappings[0],
                mappings[1],
                mappings[2],
                mappings[3],
                (SampleClass<string> obj1, SampleClass<short?> obj2, SampleClass<int?> obj3, SampleClass<long?> obj4) => (obj1, obj2, obj3, obj4)
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByIndex4_NonGeneric()
        {
            IList<MappingFieldIndexInfo[]> mappings = CreateMappingFieldIndexes(4);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldIndex(
                typeof(SampleClass<string>),
                mappings[0],
                typeof(SampleClass<short?>),
                mappings[1],
                typeof(SampleClass<int?>),
                mappings[2],
                typeof(SampleClass<long?>),
                mappings[3],
                obj => (obj[0], obj[1], obj[2], obj[3])
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        #endregion

        #region multi (5 objects)

        [TestMethod]
        public async Task MultiByName5()
        {
            IList<MappingFieldNameInfo[]> mappings = CreateMappingFieldNames(5);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldName(
                mappings[0],
                mappings[1],
                mappings[2],
                mappings[3],
                mappings[4],
                (SampleClass<string> obj1, SampleClass<short?> obj2, SampleClass<int?> obj3, SampleClass<long?> obj4, SampleClass<double?> obj5) => (obj1, obj2, obj3, obj4, obj5)
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByName5_NonGeneric()
        {
            IList<MappingFieldNameInfo[]> mappings = CreateMappingFieldNames(5);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldName(
                typeof(SampleClass<string>),
                mappings[0],
                typeof(SampleClass<short?>),
                mappings[1],
                typeof(SampleClass<int?>),
                mappings[2],
                typeof(SampleClass<long?>),
                mappings[3],
                typeof(SampleClass<double?>),
                mappings[4],
                obj => (obj[0], obj[1], obj[2], obj[3], obj[4])
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByIndex5()
        {
            IList<MappingFieldIndexInfo[]> mappings = CreateMappingFieldIndexes(5);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldIndex(
                mappings[0],
                mappings[1],
                mappings[2],
                mappings[3],
                mappings[4],
                (SampleClass<string> obj1, SampleClass<short?> obj2, SampleClass<int?> obj3, SampleClass<long?> obj4, SampleClass<double?> obj5) => (obj1, obj2, obj3, obj4, obj5)
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByIndex5_NonGeneric()
        {
            IList<MappingFieldIndexInfo[]> mappings = CreateMappingFieldIndexes(5);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldIndex(
                typeof(SampleClass<string>),
                mappings[0],
                typeof(SampleClass<short?>),
                mappings[1],
                typeof(SampleClass<int?>),
                mappings[2],
                typeof(SampleClass<long?>),
                mappings[3],
                typeof(SampleClass<double?>),
                mappings[4],
                obj => (obj[0], obj[1], obj[2], obj[3], obj[4])
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        #endregion

        #region multi (6 objects)

        [TestMethod]
        public async Task MultiByName6()
        {
            IList<MappingFieldNameInfo[]> mappings = CreateMappingFieldNames(6);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldName(
                mappings[0],
                mappings[1],
                mappings[2],
                mappings[3],
                mappings[4],
                mappings[5],
                (SampleClass<string> obj1, SampleClass<short?> obj2, SampleClass<int?> obj3, SampleClass<long?> obj4, SampleClass<double?> obj5, SampleClass<DateTime?> obj6) => (obj1, obj2, obj3, obj4, obj5, obj6)
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByName6_NonGeneric()
        {
            IList<MappingFieldNameInfo[]> mappings = CreateMappingFieldNames(6);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldName(
                typeof(SampleClass<string>),
                mappings[0],
                typeof(SampleClass<short?>),
                mappings[1],
                typeof(SampleClass<int?>),
                mappings[2],
                typeof(SampleClass<long?>),
                mappings[3],
                typeof(SampleClass<double?>),
                mappings[4],
                typeof(SampleClass<DateTime?>),
                mappings[5],
                obj => (obj[0], obj[1], obj[2], obj[3], obj[4], obj[5])
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByIndex6()
        {
            IList<MappingFieldIndexInfo[]> mappings = CreateMappingFieldIndexes(6);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldIndex(
                mappings[0],
                mappings[1],
                mappings[2],
                mappings[3],
                mappings[4],
                mappings[5],
                (SampleClass<string> obj1, SampleClass<short?> obj2, SampleClass<int?> obj3, SampleClass<long?> obj4, SampleClass<double?> obj5, SampleClass<DateTime?> obj6) => (obj1, obj2, obj3, obj4, obj5, obj6)
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByIndex6_NonGeneric()
        {
            IList<MappingFieldIndexInfo[]> mappings = CreateMappingFieldIndexes(6);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldIndex(
                typeof(SampleClass<string>),
                mappings[0],
                typeof(SampleClass<short?>),
                mappings[1],
                typeof(SampleClass<int?>),
                mappings[2],
                typeof(SampleClass<long?>),
                mappings[3],
                typeof(SampleClass<double?>),
                mappings[4],
                typeof(SampleClass<DateTime?>),
                mappings[5],
                obj => (obj[0], obj[1], obj[2], obj[3], obj[4], obj[5])
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        #endregion

        #region multi (7 objects)

        [TestMethod]
        public async Task MultiByName7()
        {
            IList<MappingFieldNameInfo[]> mappings = CreateMappingFieldNames(7);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldName(
                mappings[0],
                mappings[1],
                mappings[2],
                mappings[3],
                mappings[4],
                mappings[5],
                mappings[6],
                (SampleClass<string> obj1, SampleClass<short?> obj2, SampleClass<int?> obj3, SampleClass<long?> obj4, SampleClass<double?> obj5, SampleClass<DateTime?> obj6, SampleClass<TimeSpan?> obj7) => (obj1, obj2, obj3, obj4, obj5, obj6, obj7)
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByName7_NonGeneric()
        {
            IList<MappingFieldNameInfo[]> mappings = CreateMappingFieldNames(7);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldName(
                typeof(SampleClass<string>),
                mappings[0],
                typeof(SampleClass<short?>),
                mappings[1],
                typeof(SampleClass<int?>),
                mappings[2],
                typeof(SampleClass<long?>),
                mappings[3],
                typeof(SampleClass<double?>),
                mappings[4],
                typeof(SampleClass<DateTime?>),
                mappings[5],
                typeof(SampleClass<TimeSpan?>),
                mappings[6],
                obj => (obj[0], obj[1], obj[2], obj[3], obj[4], obj[5], obj[6])
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByIndex7()
        {
            IList<MappingFieldIndexInfo[]> mappings = CreateMappingFieldIndexes(7);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldIndex(
                mappings[0],
                mappings[1],
                mappings[2],
                mappings[3],
                mappings[4],
                mappings[5],
                mappings[6],
                (SampleClass<string> obj1, SampleClass<short?> obj2, SampleClass<int?> obj3, SampleClass<long?> obj4, SampleClass<double?> obj5, SampleClass<DateTime?> obj6, SampleClass<TimeSpan?> obj7) => (obj1, obj2, obj3, obj4, obj5, obj6, obj7)
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByIndex7_NonGeneric()
        {
            IList<MappingFieldIndexInfo[]> mappings = CreateMappingFieldIndexes(7);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldIndex(
                typeof(SampleClass<string>),
                mappings[0],
                typeof(SampleClass<short?>),
                mappings[1],
                typeof(SampleClass<int?>),
                mappings[2],
                typeof(SampleClass<long?>),
                mappings[3],
                typeof(SampleClass<double?>),
                mappings[4],
                typeof(SampleClass<DateTime?>),
                mappings[5],
                typeof(SampleClass<TimeSpan?>),
                mappings[6],
                obj => (obj[0], obj[1], obj[2], obj[3], obj[4], obj[5], obj[6])
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        #endregion

        #region multi (8 objects)

        [TestMethod]
        public async Task MultiByName8()
        {
            IList<MappingFieldNameInfo[]> mappings = CreateMappingFieldNames(8);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldName(
                mappings[0],
                mappings[1],
                mappings[2],
                mappings[3],
                mappings[4],
                mappings[5],
                mappings[6],
                mappings[7],
                (SampleClass<string> obj1, SampleClass<short?> obj2, SampleClass<int?> obj3, SampleClass<long?> obj4, SampleClass<double?> obj5, SampleClass<DateTime?> obj6, SampleClass<TimeSpan?> obj7, SampleClass<decimal?> obj8) => (obj1, obj2, obj3, obj4, obj5, obj6, obj7, obj8)
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByName8_NonGeneric()
        {
            IList<MappingFieldNameInfo[]> mappings = CreateMappingFieldNames(8);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldName(
                typeof(SampleClass<string>),
                mappings[0],
                typeof(SampleClass<short?>),
                mappings[1],
                typeof(SampleClass<int?>),
                mappings[2],
                typeof(SampleClass<long?>),
                mappings[3],
                typeof(SampleClass<double?>),
                mappings[4],
                typeof(SampleClass<DateTime?>),
                mappings[5],
                typeof(SampleClass<TimeSpan?>),
                mappings[6],
                typeof(SampleClass<decimal?>),
                mappings[7],
                obj => (obj[0], obj[1], obj[2], obj[3], obj[4], obj[5], obj[6], obj[7])
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByIndex8()
        {
            IList<MappingFieldIndexInfo[]> mappings = CreateMappingFieldIndexes(8);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldIndex(
                mappings[0],
                mappings[1],
                mappings[2],
                mappings[3],
                mappings[4],
                mappings[5],
                mappings[6],
                mappings[7],
                (SampleClass<string> obj1, SampleClass<short?> obj2, SampleClass<int?> obj3, SampleClass<long?> obj4, SampleClass<double?> obj5, SampleClass<DateTime?> obj6, SampleClass<TimeSpan?> obj7, SampleClass<decimal?> obj8) => (obj1, obj2, obj3, obj4, obj5, obj6, obj7, obj8)
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByIndex8_NonGeneric()
        {
            IList<MappingFieldIndexInfo[]> mappings = CreateMappingFieldIndexes(8);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldIndex(
                typeof(SampleClass<string>),
                mappings[0],
                typeof(SampleClass<short?>),
                mappings[1],
                typeof(SampleClass<int?>),
                mappings[2],
                typeof(SampleClass<long?>),
                mappings[3],
                typeof(SampleClass<double?>),
                mappings[4],
                typeof(SampleClass<DateTime?>),
                mappings[5],
                typeof(SampleClass<TimeSpan?>),
                mappings[6],
                typeof(SampleClass<decimal?>),
                mappings[7],
                obj => (obj[0], obj[1], obj[2], obj[3], obj[4], obj[5], obj[6], obj[7])
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        #endregion

        #region multi (9 objects)

        [TestMethod]
        public async Task MultiByName9()
        {
            IList<MappingFieldNameInfo[]> mappings = CreateMappingFieldNames(9);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldName(
                mappings[0],
                mappings[1],
                mappings[2],
                mappings[3],
                mappings[4],
                mappings[5],
                mappings[6],
                mappings[7],
                mappings[8],
                (SampleClass<string> obj1, SampleClass<short?> obj2, SampleClass<int?> obj3, SampleClass<long?> obj4, SampleClass<double?> obj5, SampleClass<DateTime?> obj6, SampleClass<TimeSpan?> obj7, SampleClass<decimal?> obj8, SampleClass<bool?> obj9) => (obj1, obj2, obj3, obj4, obj5, obj6, obj7, obj8, obj9)
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByName9_NonGeneric()
        {
            IList<MappingFieldNameInfo[]> mappings = CreateMappingFieldNames(9);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldName(
                typeof(SampleClass<string>),
                mappings[0],
                typeof(SampleClass<short?>),
                mappings[1],
                typeof(SampleClass<int?>),
                mappings[2],
                typeof(SampleClass<long?>),
                mappings[3],
                typeof(SampleClass<double?>),
                mappings[4],
                typeof(SampleClass<DateTime?>),
                mappings[5],
                typeof(SampleClass<TimeSpan?>),
                mappings[6],
                typeof(SampleClass<decimal?>),
                mappings[7],
                typeof(SampleClass<bool?>),
                mappings[8],
                obj => (obj[0], obj[1], obj[2], obj[3], obj[4], obj[5], obj[6], obj[7], obj[8])
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByIndex9()
        {
            IList<MappingFieldIndexInfo[]> mappings = CreateMappingFieldIndexes(9);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldIndex(
                mappings[0],
                mappings[1],
                mappings[2],
                mappings[3],
                mappings[4],
                mappings[5],
                mappings[6],
                mappings[7],
                mappings[8],
                (SampleClass<string> obj1, SampleClass<short?> obj2, SampleClass<int?> obj3, SampleClass<long?> obj4, SampleClass<double?> obj5, SampleClass<DateTime?> obj6, SampleClass<TimeSpan?> obj7, SampleClass<decimal?> obj8, SampleClass<bool?> obj9) => (obj1, obj2, obj3, obj4, obj5, obj6, obj7, obj8, obj9)
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        [TestMethod]
        public async Task MultiByIndex9_NonGeneric()
        {
            IList<MappingFieldIndexInfo[]> mappings = CreateMappingFieldIndexes(9);

            using var generator = await CreateDataGeneratorAsync(50).ConfigureAwait(false);
            using var expected = await CreateDataGeneratorAsync(50).ConfigureAwait(false);

            var expectedReader = expected.AsDataReader();

            foreach (var obj in generator.MapByFieldIndex(
                typeof(SampleClass<string>),
                mappings[0],
                typeof(SampleClass<short?>),
                mappings[1],
                typeof(SampleClass<int?>),
                mappings[2],
                typeof(SampleClass<long?>),
                mappings[3],
                typeof(SampleClass<double?>),
                mappings[4],
                typeof(SampleClass<DateTime?>),
                mappings[5],
                typeof(SampleClass<TimeSpan?>),
                mappings[6],
                typeof(SampleClass<decimal?>),
                mappings[7],
                typeof(SampleClass<bool?>),
                mappings[8],
                obj => (obj[0], obj[1], obj[2], obj[3], obj[4], obj[5], obj[6], obj[7], obj[8])
                ))
            {
                expectedReader.Read();
                AssertValues(expectedReader, obj);
            }
        }

        #endregion

        #region assertion

        private void AssertValues(IDataRecord expected, (SampleClass<string>, SampleClass<short?>) actual)
        {
            Debug.WriteLine(actual);

            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value1)], actual.Item1.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value2)], actual.Item2.Value);
        }

        private void AssertValues(IDataRecord expected, (SampleClass<string>, SampleClass<short?>, SampleClass<int?>) actual)
        {
            Debug.WriteLine(actual);

            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value1)], actual.Item1.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value2)], actual.Item2.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value3)], actual.Item3.Value);
        }

        private void AssertValues(IDataRecord expected, (SampleClass<string>, SampleClass<short?>, SampleClass<int?>, SampleClass<long?>) actual)
        {
            Debug.WriteLine(actual);

            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value1)], actual.Item1.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value2)], actual.Item2.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value3)], actual.Item3.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value4)], actual.Item4.Value);
        }

        private void AssertValues(IDataRecord expected, (SampleClass<string>, SampleClass<short?>, SampleClass<int?>, SampleClass<long?>, SampleClass<double?>) actual)
        {
            Debug.WriteLine(actual);

            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value1)], actual.Item1.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value2)], actual.Item2.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value3)], actual.Item3.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value4)], actual.Item4.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value5)], actual.Item5.Value);
        }

        private void AssertValues(IDataRecord expected, (SampleClass<string>, SampleClass<short?>, SampleClass<int?>, SampleClass<long?>, SampleClass<double?>, SampleClass<DateTime?>) actual)
        {
            Debug.WriteLine(actual);

            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value1)], actual.Item1.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value2)], actual.Item2.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value3)], actual.Item3.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value4)], actual.Item4.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value5)], actual.Item5.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value6)], actual.Item6.Value);
        }

        private void AssertValues(IDataRecord expected, (SampleClass<string>, SampleClass<short?>, SampleClass<int?>, SampleClass<long?>, SampleClass<double?>, SampleClass<DateTime?>, SampleClass<TimeSpan?>) actual)
        {
            Debug.WriteLine(actual);

            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value1)], actual.Item1.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value2)], actual.Item2.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value3)], actual.Item3.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value4)], actual.Item4.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value5)], actual.Item5.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value6)], actual.Item6.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value7)], actual.Item7.Value);
        }

        private void AssertValues(IDataRecord expected, (SampleClass<string>, SampleClass<short?>, SampleClass<int?>, SampleClass<long?>, SampleClass<double?>, SampleClass<DateTime?>, SampleClass<TimeSpan?>, SampleClass<decimal?>) actual)
        {
            Debug.WriteLine(actual);

            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value1)], actual.Item1.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value2)], actual.Item2.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value3)], actual.Item3.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value4)], actual.Item4.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value5)], actual.Item5.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value6)], actual.Item6.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value7)], actual.Item7.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value8)], actual.Item8.Value);
        }

        private void AssertValues(IDataRecord expected, (SampleClass<string>, SampleClass<short?>, SampleClass<int?>, SampleClass<long?>, SampleClass<double?>, SampleClass<DateTime?>, SampleClass<TimeSpan?>, SampleClass<decimal?>, SampleClass<bool?>) actual)
        {
            Debug.WriteLine(actual);

            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value1)], actual.Item1.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value2)], actual.Item2.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value3)], actual.Item3.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value4)], actual.Item4.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value5)], actual.Item5.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value6)], actual.Item6.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value7)], actual.Item7.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value8)], actual.Item8.Value);
            AssertAreEqualOrNull(expected[nameof(GeneratingFields.value9)], actual.Item9.Value);
        }

        private void AssertValues(IDataRecord expected, object? actual)
        {
            Debug.WriteLine(actual);

            if (actual is (object, object))
            {
                var tuple = ((object, object))actual;

                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value1)], ((SampleClass<string?>)tuple.Item1!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value2)], ((SampleClass<short?>)tuple.Item2!).Value);
            }
            else if (actual is (object, object, object))
            {
                var tuple = ((object, object, object))actual;

                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value1)], ((SampleClass<string?>)tuple.Item1!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value2)], ((SampleClass<short?>)tuple.Item2!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value3)], ((SampleClass<int?>)tuple.Item3!).Value);
            }
            else if (actual is (object, object, object, object))
            {
                var tuple = ((object, object, object, object))actual;

                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value1)], ((SampleClass<string?>)tuple.Item1!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value2)], ((SampleClass<short?>)tuple.Item2!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value3)], ((SampleClass<int?>)tuple.Item3!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value4)], ((SampleClass<long?>)tuple.Item4!).Value);
            }
            else if (actual is (object, object, object, object, object))
            {
                var tuple = ((object, object, object, object, object))actual;

                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value1)], ((SampleClass<string?>)tuple.Item1!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value2)], ((SampleClass<short?>)tuple.Item2!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value3)], ((SampleClass<int?>)tuple.Item3!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value4)], ((SampleClass<long?>)tuple.Item4!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value5)], ((SampleClass<double?>)tuple.Item5!).Value);
            }
            else if (actual is (object, object, object, object, object, object))
            {
                var tuple = ((object, object, object, object, object, object))actual;

                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value1)], ((SampleClass<string?>)tuple.Item1!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value2)], ((SampleClass<short?>)tuple.Item2!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value3)], ((SampleClass<int?>)tuple.Item3!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value4)], ((SampleClass<long?>)tuple.Item4!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value5)], ((SampleClass<double?>)tuple.Item5!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value6)], ((SampleClass<DateTime?>)tuple.Item6!).Value);
            }
            else if (actual is (object, object, object, object, object, object, object))
            {
                var tuple = ((object, object, object, object, object, object, object))actual;

                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value1)], ((SampleClass<string?>)tuple.Item1!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value2)], ((SampleClass<short?>)tuple.Item2!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value3)], ((SampleClass<int?>)tuple.Item3!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value4)], ((SampleClass<long?>)tuple.Item4!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value5)], ((SampleClass<double?>)tuple.Item5!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value6)], ((SampleClass<DateTime?>)tuple.Item6!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value7)], ((SampleClass<TimeSpan?>)tuple.Item7!).Value);
            }
            else if (actual is (object, object, object, object, object, object, object, object))
            {
                var tuple = ((object, object, object, object, object, object, object, object))actual;

                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value1)], ((SampleClass<string?>)tuple.Item1!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value2)], ((SampleClass<short?>)tuple.Item2!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value3)], ((SampleClass<int?>)tuple.Item3!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value4)], ((SampleClass<long?>)tuple.Item4!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value5)], ((SampleClass<double?>)tuple.Item5!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value6)], ((SampleClass<DateTime?>)tuple.Item6!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value7)], ((SampleClass<TimeSpan?>)tuple.Item7!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value8)], ((SampleClass<decimal?>)tuple.Item8!).Value);
            }
            else if (actual is (object, object, object, object, object, object, object, object, object))
            {
                var tuple = ((object, object, object, object, object, object, object, object, object))actual;

                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value1)], ((SampleClass<string?>)tuple.Item1!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value2)], ((SampleClass<short?>)tuple.Item2!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value3)], ((SampleClass<int?>)tuple.Item3!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value4)], ((SampleClass<long?>)tuple.Item4!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value5)], ((SampleClass<double?>)tuple.Item5!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value6)], ((SampleClass<DateTime?>)tuple.Item6!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value7)], ((SampleClass<TimeSpan?>)tuple.Item7!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value8)], ((SampleClass<decimal?>)tuple.Item8!).Value);
                AssertAreEqualOrNull(expected[nameof(GeneratingFields.value9)], ((SampleClass<bool?>)tuple.Item9!).Value);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private void AssertAreEqualOrNull(object? expected, object? actual)
        {
            if (expected != null && actual != null)
            {
                Assert.AreEqual(expected, actual);
            }
        }

        #endregion

    }

}
