using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;

using mxProject.Devs.DataGeneration;
using mxProject.Devs.DataGeneration.Fields;
using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Devs.DataGeneration.Configuration.Fields;
using mxProject.Devs.DataGeneration.Configuration.Json;

using UnitTestProject1.Extensions;
using UnitTestProject1.SampleValues;

namespace UnitTestProject1
{

    [TestClass]
    public class TestDirectProductSettings
    {

        [ClassInitialize]
        public static void Init(TestContext _)
        {
            s_JsonSerializerSettings = TestUtility.CreateJsonSerializerSettings();
        }

        private static JsonSerializerSettings s_JsonSerializerSettings = null!;

        #region 2 fields

        [TestMethod]
        public async Task Field2()
        {
            
            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();

            DataGeneratorSettings settings = new()
            {
                TupleFields = new[]
                {
                    new DirectProductFieldSettings()
                    {
                        Fields = new DataGeneratorFieldSettings[]
                        {
                            new EachFieldSettings<short>(){ FieldName="field1", NullProbability=0.1, Values = values1.AsNullable().ToArray() },
                            new EachFieldSettings<short>(){ FieldName="field2", NullProbability=0.1, Values = values2 }
                        }
                    }
                }
            };

            AssertJsonSerialize(ref settings);

            int generateCount = GetProductCount(values1, values2);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator

            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                generator.Reset();

                for (int i1 = 0; i1 < values1.Length; ++i1)
                {
                    for (int i2 = 0; i2 < values2.Length; ++i2)
                    {
                        Assert.AreEqual(true, generator.GenerateNext());
                        AssertValues(generator, values1[i1], values2[i2]);
                    }
                }

                Assert.AreEqual(false, generator.GenerateNext());
            }

            // dataReader
            StringBuilder sb = new();

            using (var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false))
            {
                TestUtility.DumpHeader(reader, sb);

                for (int i1 = 0; i1 < values1.Length; ++i1)
                {
                    for (int i2 = 0; i2 < values2.Length; ++i2)
                    {
                        Assert.AreEqual(true, reader.Read());
                        TestUtility.DumpRecord(reader, sb);
                        AssertValues(reader, values1[i1], values2[i2]);
                    }
                }

                Assert.AreEqual(false, reader.Read());
            }

            Debug.WriteLine(sb.ToString());
        }

        #endregion

        #region 3 fields

        [TestMethod]
        public async Task Field3()
        {

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();

            DataGeneratorSettings settings = new()
            {
                TupleFields = new[]
                {
                    new DirectProductFieldSettings()
                    {
                        Fields = new DataGeneratorFieldSettings[]
                        {
                            new EachFieldSettings<short>(){ FieldName="field1", NullProbability=0.1, Values = values1.AsNullable().ToArray() },
                            new EachFieldSettings<short>(){ FieldName="field2", NullProbability=0.1, Values = values2 },
                            new EachFieldSettings<char>(){ FieldName="field3", NullProbability=0.1, Values = values3 }
                        }
                    }
                }
            };

            AssertJsonSerialize(ref settings);

            int generateCount = GetProductCount(values1, values2, values3);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator

            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                generator.Reset();

                for (int i1 = 0; i1 < values1.Length; ++i1)
                {
                    for (int i2 = 0; i2 < values2.Length; ++i2)
                    {
                        for (int i3 = 0; i3 < values3.Length; ++i3)
                        {
                            Assert.AreEqual(true, generator.GenerateNext());
                            AssertValues(generator, values1[i1], values2[i2], values3[i3]);
                        }
                    }
                }

                Assert.AreEqual(false, generator.GenerateNext());
            }

            // dataReader
            StringBuilder sb = new();

            using (var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false))
            {
                TestUtility.DumpHeader(reader, sb);

                for (int i1 = 0; i1 < values1.Length; ++i1)
                {
                    for (int i2 = 0; i2 < values2.Length; ++i2)
                    {
                        for (int i3 = 0; i3 < values3.Length; ++i3)
                        {
                            Assert.AreEqual(true, reader.Read());
                            TestUtility.DumpRecord(reader, sb);
                            AssertValues(reader, values1[i1], values2[i2], values3[i3]);
                        }
                    }
                }

                Assert.AreEqual(false, reader.Read());
            }

            Debug.WriteLine(sb.ToString());
        }

        #endregion

        #region 4 fields

        [TestMethod]
        public async Task Field4()
        {

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();
            var values4 = SampleDirectProductValues.GetValues4();

            DataGeneratorSettings settings = new()
            {
                TupleFields = new[]
                {
                    new DirectProductFieldSettings()
                    {
                        Fields = new DataGeneratorFieldSettings[]
                        {
                            new EachFieldSettings<short>(){ FieldName="field1", NullProbability=0.1, Values = values1.AsNullable().ToArray() },
                            new EachFieldSettings<short>(){ FieldName="field2", NullProbability=0.1, Values = values2 },
                            new EachFieldSettings<char>(){ FieldName="field3", NullProbability=0.1, Values = values3 },
                            new EachFieldSettings<int>(){ FieldName="field4", NullProbability=0.1, Values = values4.AsNullable().ToArray() }
                        }
                    }
                }
            };

            AssertJsonSerialize(ref settings);

            int generateCount = GetProductCount(values1, values2, values3, values4);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator

            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                generator.Reset();

                for (int i1 = 0; i1 < values1.Length; ++i1)
                {
                    for (int i2 = 0; i2 < values2.Length; ++i2)
                    {
                        for (int i3 = 0; i3 < values3.Length; ++i3)
                        {
                            for (int i4 = 0; i4 < values4.Length; ++i4)
                            {
                                Assert.AreEqual(true, generator.GenerateNext());
                                AssertValues(generator, values1[i1], values2[i2], values3[i3], values4[i4]);
                            }
                        }
                    }
                }

                Assert.AreEqual(false, generator.GenerateNext());
            }

            // dataReader
            StringBuilder sb = new();

            using (var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false))
            {
                TestUtility.DumpHeader(reader, sb);

                for (int i1 = 0; i1 < values1.Length; ++i1)
                {
                    for (int i2 = 0; i2 < values2.Length; ++i2)
                    {
                        for (int i3 = 0; i3 < values3.Length; ++i3)
                        {
                            for (int i4 = 0; i4 < values4.Length; ++i4)
                            {
                                Assert.AreEqual(true, reader.Read());
                                TestUtility.DumpRecord(reader, sb);
                                AssertValues(reader, values1[i1], values2[i2], values3[i3], values4[i4]);
                            }
                        }
                    }
                }

                Assert.AreEqual(false, reader.Read());
            }

            Debug.WriteLine(sb.ToString());
        }

        #endregion

        #region 5 fields

        [TestMethod]
        public async Task Field5()
        {

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();
            var values4 = SampleDirectProductValues.GetValues4();
            var values5 = SampleDirectProductValues.GetValues5();

            DataGeneratorSettings settings = new()
            {
                TupleFields = new[]
                {
                    new DirectProductFieldSettings()
                    {
                        Fields = new DataGeneratorFieldSettings[]
                        {
                            new EachFieldSettings<short>(){ FieldName="field1", NullProbability=0.1, Values = values1.AsNullable().ToArray() },
                            new EachFieldSettings<short>(){ FieldName="field2", NullProbability=0.1, Values = values2 },
                            new EachFieldSettings<char>(){ FieldName="field3", NullProbability=0.1, Values = values3 },
                            new EachFieldSettings<int>(){ FieldName="field4", NullProbability=0.1, Values = values4.AsNullable().ToArray() },
                            new EachFieldSettings<int>(){ FieldName="field5", NullProbability=0.1, Values = values5 }
                        }
                    }
                }
            };

            AssertJsonSerialize(ref settings);

            int generateCount = GetProductCount(values1, values2, values3, values4, values5);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator

            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                generator.Reset();

                for (int i1 = 0; i1 < values1.Length; ++i1)
                {
                    for (int i2 = 0; i2 < values2.Length; ++i2)
                    {
                        for (int i3 = 0; i3 < values3.Length; ++i3)
                        {
                            for (int i4 = 0; i4 < values4.Length; ++i4)
                            {
                                for (int i5 = 0; i5 < values5.Length; ++i5)
                                {
                                    Assert.AreEqual(true, generator.GenerateNext());
                                    AssertValues(generator, values1[i1], values2[i2], values3[i3], values4[i4], values5[i5]);
                                }
                            }
                        }
                    }
                }

                Assert.AreEqual(false, generator.GenerateNext());
            }

            // dataReader
            StringBuilder sb = new();

            using (var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false))
            {
                TestUtility.DumpHeader(reader, sb);

                for (int i1 = 0; i1 < values1.Length; ++i1)
                {
                    for (int i2 = 0; i2 < values2.Length; ++i2)
                    {
                        for (int i3 = 0; i3 < values3.Length; ++i3)
                        {
                            for (int i4 = 0; i4 < values4.Length; ++i4)
                            {
                                for (int i5 = 0; i5 < values5.Length; ++i5)
                                {
                                    Assert.AreEqual(true, reader.Read());
                                    TestUtility.DumpRecord(reader, sb);
                                    AssertValues(reader, values1[i1], values2[i2], values3[i3], values4[i4], values5[i5]);
                                }
                            }
                        }
                    }
                }

                Assert.AreEqual(false, reader.Read());
            }

            Debug.WriteLine(sb.ToString());
        }

        #endregion

        #region 6 fields

        [TestMethod]
        public async Task Field6()
        {

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();
            var values4 = SampleDirectProductValues.GetValues4();
            var values5 = SampleDirectProductValues.GetValues5();
            var values6 = SampleDirectProductValues.GetValues6();

            DataGeneratorSettings settings = new()
            {
                TupleFields = new[]
                {
                    new DirectProductFieldSettings()
                    {
                        Fields = new DataGeneratorFieldSettings[]
                        {
                            new EachFieldSettings<short>(){ FieldName="field1", NullProbability=0.1, Values = values1.AsNullable().ToArray() },
                            new EachFieldSettings<short>(){ FieldName="field2", NullProbability=0.1, Values = values2 },
                            new EachFieldSettings<char>(){ FieldName="field3", NullProbability=0.1, Values = values3 },
                            new EachFieldSettings<int>(){ FieldName="field4", NullProbability=0.1, Values = values4.AsNullable().ToArray() },
                            new EachFieldSettings<int>(){ FieldName="field5", NullProbability=0.1, Values = values5 },
                            new EachStringFieldSettings(){ FieldName="field6", NullProbability=0.1, Values = values6 }
                        }
                    }
                }
            };

            AssertJsonSerialize(ref settings);

            int generateCount = GetProductCount(values1, values2, values3, values4, values5, values6);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator

            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                generator.Reset();

                for (int i1 = 0; i1 < values1.Length; ++i1)
                {
                    for (int i2 = 0; i2 < values2.Length; ++i2)
                    {
                        for (int i3 = 0; i3 < values3.Length; ++i3)
                        {
                            for (int i4 = 0; i4 < values4.Length; ++i4)
                            {
                                for (int i5 = 0; i5 < values5.Length; ++i5)
                                {
                                    for (int i6 = 0; i6 < values6.Length; ++i6)
                                    {
                                        Assert.AreEqual(true, generator.GenerateNext());
                                        AssertValues(generator, values1[i1], values2[i2], values3[i3], values4[i4], values5[i5], values6[i6]);
                                    }
                                }
                            }
                        }
                    }
                }

                Assert.AreEqual(false, generator.GenerateNext());
            }

            // dataReader
            StringBuilder sb = new();

            using (var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false))
            {
                TestUtility.DumpHeader(reader, sb);

                for (int i1 = 0; i1 < values1.Length; ++i1)
                {
                    for (int i2 = 0; i2 < values2.Length; ++i2)
                    {
                        for (int i3 = 0; i3 < values3.Length; ++i3)
                        {
                            for (int i4 = 0; i4 < values4.Length; ++i4)
                            {
                                for (int i5 = 0; i5 < values5.Length; ++i5)
                                {
                                    for (int i6 = 0; i6 < values6.Length; ++i6)
                                    {
                                        Assert.AreEqual(true, reader.Read());
                                        TestUtility.DumpRecord(reader, sb);
                                        AssertValues(reader, values1[i1], values2[i2], values3[i3], values4[i4], values5[i5], values6[i6]);
                                    }
                                }
                            }
                        }
                    }
                }

                Assert.AreEqual(false, reader.Read());
            }

            Debug.WriteLine(sb.ToString());
        }

        #endregion

        #region 7 fields

        [TestMethod]
        public async Task Field7()
        {

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();
            var values4 = SampleDirectProductValues.GetValues4();
            var values5 = SampleDirectProductValues.GetValues5();
            var values6 = SampleDirectProductValues.GetValues6();
            var values7 = SampleDirectProductValues.GetValues7();

            DataGeneratorSettings settings = new()
            {
                TupleFields = new[]
                {
                    new DirectProductFieldSettings()
                    {
                        Fields = new DataGeneratorFieldSettings[]
                        {
                            new EachFieldSettings<short>(){ FieldName="field1", NullProbability=0.1, Values = values1.AsNullable().ToArray() },
                            new EachFieldSettings<short>(){ FieldName="field2", NullProbability=0.1, Values = values2 },
                            new EachFieldSettings<char>(){ FieldName="field3", NullProbability=0.1, Values = values3 },
                            new EachFieldSettings<int>(){ FieldName="field4", NullProbability=0.1, Values = values4.AsNullable().ToArray() },
                            new EachFieldSettings<int>(){ FieldName="field5", NullProbability=0.1, Values = values5 },
                            new EachStringFieldSettings(){ FieldName="field6", NullProbability=0.1, Values = values6 },
                            new EachFieldSettings<long>(){ FieldName="field7", NullProbability=0.1, Values = values7.AsNullable().ToArray() },
                        }
                    }
                }
            };

            AssertJsonSerialize(ref settings);

            int generateCount = GetProductCount(values1, values2, values3, values4, values5, values6, values7);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator

            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                generator.Reset();

                for (int i1 = 0; i1 < values1.Length; ++i1)
                {
                    for (int i2 = 0; i2 < values2.Length; ++i2)
                    {
                        for (int i3 = 0; i3 < values3.Length; ++i3)
                        {
                            for (int i4 = 0; i4 < values4.Length; ++i4)
                            {
                                for (int i5 = 0; i5 < values5.Length; ++i5)
                                {
                                    for (int i6 = 0; i6 < values6.Length; ++i6)
                                    {
                                        for (int i7 = 0; i7 < values7.Length; ++i7)
                                        {
                                            Assert.AreEqual(true, generator.GenerateNext());
                                            AssertValues(generator, values1[i1], values2[i2], values3[i3], values4[i4], values5[i5], values6[i6], values7[i7]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Assert.AreEqual(false, generator.GenerateNext());
            }

            // dataReader
            StringBuilder sb = new();

            using (var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false))
            {
                TestUtility.DumpHeader(reader, sb);

                for (int i1 = 0; i1 < values1.Length; ++i1)
                {
                    for (int i2 = 0; i2 < values2.Length; ++i2)
                    {
                        for (int i3 = 0; i3 < values3.Length; ++i3)
                        {
                            for (int i4 = 0; i4 < values4.Length; ++i4)
                            {
                                for (int i5 = 0; i5 < values5.Length; ++i5)
                                {
                                    for (int i6 = 0; i6 < values6.Length; ++i6)
                                    {
                                        for (int i7 = 0; i7 < values7.Length; ++i7)
                                        {
                                            Assert.AreEqual(true, reader.Read());
                                            TestUtility.DumpRecord(reader, sb);
                                            AssertValues(reader, values1[i1], values2[i2], values3[i3], values4[i4], values5[i5], values6[i6], values7[i7]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Assert.AreEqual(false, reader.Read());
            }

            Debug.WriteLine(sb.ToString());
        }

        #endregion

        #region 8 fields

        [TestMethod]
        public async Task Field8()
        {

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();
            var values4 = SampleDirectProductValues.GetValues4();
            var values5 = SampleDirectProductValues.GetValues5();
            var values6 = SampleDirectProductValues.GetValues6();
            var values7 = SampleDirectProductValues.GetValues7();
            var values8 = SampleDirectProductValues.GetValues8();

            DataGeneratorSettings settings = new()
            {
                TupleFields = new[]
                {
                    new DirectProductFieldSettings()
                    {
                        Fields = new DataGeneratorFieldSettings[]
                        {
                            new EachFieldSettings<short>(){ FieldName="field1", NullProbability=0.1, Values = values1.AsNullable().ToArray() },
                            new EachFieldSettings<short>(){ FieldName="field2", NullProbability=0.1, Values = values2 },
                            new EachFieldSettings<char>(){ FieldName="field3", NullProbability=0.1, Values = values3 },
                            new EachFieldSettings<int>(){ FieldName="field4", NullProbability=0.1, Values = values4.AsNullable().ToArray() },
                            new EachFieldSettings<int>(){ FieldName="field5", NullProbability=0.1, Values = values5 },
                            new EachStringFieldSettings(){ FieldName="field6", NullProbability=0.1, Values = values6 },
                            new EachFieldSettings<long>(){ FieldName="field7", NullProbability=0.1, Values = values7.AsNullable().ToArray() },
                            new EachFieldSettings<long>(){ FieldName="field8", NullProbability=0.1, Values = values8 }
                        }
                    }
                }
            };

            AssertJsonSerialize(ref settings);

            int generateCount = GetProductCount(values1, values2, values3, values4, values5, values6, values7, values8);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator

            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                generator.Reset();

                for (int i1 = 0; i1 < values1.Length; ++i1)
                {
                    for (int i2 = 0; i2 < values2.Length; ++i2)
                    {
                        for (int i3 = 0; i3 < values3.Length; ++i3)
                        {
                            for (int i4 = 0; i4 < values4.Length; ++i4)
                            {
                                for (int i5 = 0; i5 < values5.Length; ++i5)
                                {
                                    for (int i6 = 0; i6 < values6.Length; ++i6)
                                    {
                                        for (int i7 = 0; i7 < values7.Length; ++i7)
                                        {
                                            for (int i8 = 0; i8 < values8.Length; ++i8)
                                            {
                                                Assert.AreEqual(true, generator.GenerateNext());
                                                AssertValues(generator, values1[i1], values2[i2], values3[i3], values4[i4], values5[i5], values6[i6], values7[i7], values8[i8]);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Assert.AreEqual(false, generator.GenerateNext());
            }

            // dataReader
            StringBuilder sb = new();

            using (var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false))
            {
                TestUtility.DumpHeader(reader, sb);

                for (int i1 = 0; i1 < values1.Length; ++i1)
                {
                    for (int i2 = 0; i2 < values2.Length; ++i2)
                    {
                        for (int i3 = 0; i3 < values3.Length; ++i3)
                        {
                            for (int i4 = 0; i4 < values4.Length; ++i4)
                            {
                                for (int i5 = 0; i5 < values5.Length; ++i5)
                                {
                                    for (int i6 = 0; i6 < values6.Length; ++i6)
                                    {
                                        for (int i7 = 0; i7 < values7.Length; ++i7)
                                        {
                                            for (int i8 = 0; i8 < values8.Length; ++i8)
                                            {
                                                Assert.AreEqual(true, reader.Read());
                                                TestUtility.DumpRecord(reader, sb);
                                                AssertValues(reader, values1[i1], values2[i2], values3[i3], values4[i4], values5[i5], values6[i6], values7[i7], values8[i8]);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Assert.AreEqual(false, reader.Read());
            }

            Debug.WriteLine(sb.ToString());
        }

        #endregion

        #region 9 fields

        [TestMethod]
        public async Task Field9()
        {

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();
            var values4 = SampleDirectProductValues.GetValues4();
            var values5 = SampleDirectProductValues.GetValues5();
            var values6 = SampleDirectProductValues.GetValues6();
            var values7 = SampleDirectProductValues.GetValues7();
            var values8 = SampleDirectProductValues.GetValues8();
            var values9 = SampleDirectProductValues.GetValues9();

            DataGeneratorSettings settings = new()
            {
                TupleFields = new[]
                {
                    new DirectProductFieldSettings()
                    {
                        Fields = new DataGeneratorFieldSettings[]
                        {
                            new EachFieldSettings<short>(){ FieldName="field1", NullProbability=0.1, Values = values1.AsNullable().ToArray() },
                            new EachFieldSettings<short>(){ FieldName="field2", NullProbability=0.1, Values = values2 },
                            new EachFieldSettings<char>(){ FieldName="field3", NullProbability=0.1, Values = values3 },
                            new EachFieldSettings<int>(){ FieldName="field4", NullProbability=0.1, Values = values4.AsNullable().ToArray() },
                            new EachFieldSettings<int>(){ FieldName="field5", NullProbability=0.1, Values = values5 },
                            new EachStringFieldSettings(){ FieldName="field6", NullProbability=0.1, Values = values6 },
                            new EachFieldSettings<long>(){ FieldName="field7", NullProbability=0.1, Values = values7.AsNullable().ToArray() },
                            new EachFieldSettings<long>(){ FieldName="field8", NullProbability=0.1, Values = values8 },
                            new EachFieldSettings<decimal>(){ FieldName="field9", NullProbability=0.1, Values = values9.AsNullable().ToArray() }
                        }
                    }
                }
            };

            AssertJsonSerialize(ref settings);

            int generateCount = GetProductCount(values1, values2, values3, values4, values5, values6, values7, values8, values9);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator

            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                generator.Reset();

                for (int i1 = 0; i1 < values1.Length; ++i1)
                {
                    for (int i2 = 0; i2 < values2.Length; ++i2)
                    {
                        for (int i3 = 0; i3 < values3.Length; ++i3)
                        {
                            for (int i4 = 0; i4 < values4.Length; ++i4)
                            {
                                for (int i5 = 0; i5 < values5.Length; ++i5)
                                {
                                    for (int i6 = 0; i6 < values6.Length; ++i6)
                                    {
                                        for (int i7 = 0; i7 < values7.Length; ++i7)
                                        {
                                            for (int i8 = 0; i8 < values8.Length; ++i8)
                                            {
                                                for (int i9 = 0; i9 < values9.Length; ++i9)
                                                {
                                                    Assert.AreEqual(true, generator.GenerateNext());
                                                    AssertValues(generator, values1[i1], values2[i2], values3[i3], values4[i4], values5[i5], values6[i6], values7[i7], values8[i8], values9[i9]);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Assert.AreEqual(false, generator.GenerateNext());
            }

            // dataReader
            StringBuilder sb = new();

            using (var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false)) 
            {
                TestUtility.DumpHeader(reader, sb);

                for (int i1 = 0; i1 < values1.Length; ++i1)
                {
                    for (int i2 = 0; i2 < values2.Length; ++i2)
                    {
                        for (int i3 = 0; i3 < values3.Length; ++i3)
                        {
                            for (int i4 = 0; i4 < values4.Length; ++i4)
                            {
                                for (int i5 = 0; i5 < values5.Length; ++i5)
                                {
                                    for (int i6 = 0; i6 < values6.Length; ++i6)
                                    {
                                        for (int i7 = 0; i7 < values7.Length; ++i7)
                                        {
                                            for (int i8 = 0; i8 < values8.Length; ++i8)
                                            {
                                                for (int i9 = 0; i9 < values9.Length; ++i9)
                                                {
                                                    Assert.AreEqual(true, reader.Read());
                                                    TestUtility.DumpRecord(reader, sb);
                                                    AssertValues(reader, values1[i1], values2[i2], values3[i3], values4[i4], values5[i5], values6[i6], values7[i7], values8[i8], values9[i9]);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Assert.AreEqual(false, reader.Read());
            }

            Debug.WriteLine(sb.ToString());
        }

        #endregion



        private static void AssertJsonSerialize(ref DataGeneratorSettings settings)
        {
            var json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;
        }

        private static void AssertValues(DataGenerator generator, params object?[] expectedValues)
        {
            for (int i = 0; i < generator.FieldCount; ++i)
            {
                if (generator.GetFieldValueIsNull(i))
                {
                    Assert.IsNull(generator.GetFieldValue(i));
                }
                else
                {
                    Assert.AreEqual(expectedValues[i], generator.GetFieldValue(i));
                }
            }
        }

        private static void AssertValues(IDataReader reader, params object?[] expectedValues)
        {
            object?[] values = new object?[reader.FieldCount];

            for (int i = 0; i < reader.FieldCount; ++i)
            {
                if (reader.IsDBNull(i))
                {
                    Assert.IsNull(reader.GetValue(i));
                }
                else
                {
                    Assert.AreEqual(expectedValues[i], reader.GetValue(i));
                }
            }

            reader.GetValues(values);

            for (int i = 0; i < values.Length; ++i)
            {
                if (values[i] != null)
                {
                    Assert.AreEqual(expectedValues[i], values[i]);
                }
            }
        }

        private static int GetProductCount(params IList[] lists)
        {
            int count = 1;

            for (int i = 0; i < lists.Length; ++i)
            {
                count *= lists[i].Count;
            }

            return count;
        }
    }

}
