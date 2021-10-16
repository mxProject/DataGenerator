using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;

using mxProject.Devs.DataGeneration;
using mxProject.Devs.DataGeneration.Fields;
using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Devs.DataGeneration.Configuration.Fields;

using UnitTestProject1.SampleValues;

namespace UnitTestProject1
{

    [TestClass]
    public class TestDbQuery
    {

        [TestMethod]
        public async Task Field1()
        {
            var provider = SampleSQLite.CreateProvider();

            using var connection = provider.CreateConnection(":memory:");

            SampleSQLite.PrepareSampleTable(connection);

            DataGeneratorSettings generatorSettings = new DataGeneratorSettings()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new DbQueryFieldSettings()
                    {
                        FieldName = "Field3",
                        DbQuerySettings = new DbQuerySettings()
                        {
                            CommandText = "select * from SAMPLE_TABLE",
                            ConnectionString = ":memory:",
                        }
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref generatorSettings);

            DataGeneratorContext context = new DataGeneratorContext(dbProvider: SampleSQLite.CreateProvider(connection));

            DataGeneratorBuilder builder = generatorSettings.CreateBuilder(context);

            using DataGenerator generator = await builder.BuildAsync(10).ConfigureAwait(false);

            Assert.AreEqual("Field3", generator.GetFieldName(0));

            StringBuilder sb = new StringBuilder();

            TestUtility.DumpHeader(generator, sb);

            while (generator.GenerateNext())
            {
                TestUtility.DumpRecord(generator, sb);
            }

            Debug.WriteLine(sb.ToString());
        }

        [TestMethod]
        public async Task Field2()
        {
            string[] fieldNames = new[] {
                "FIELD4",
                "field7"
            };

            await DbQueryFieldsCore(fieldNames).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task Field3()
        {
            string[] fieldNames = new[] {
                "FIELD4",
                "field7",
                "FIELD1"
            };

            await DbQueryFieldsCore(fieldNames).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task Field4()
        {
            string[] fieldNames = new[] {
                "FIELD4",
                "field7",
                "FIELD1",
                "FIELD5"
            };

            await DbQueryFieldsCore(fieldNames).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task Field5()
        {
            string[] fieldNames = new[] {
                "FIELD4",
                "field7",
                "FIELD1",
                "FIELD5",
                "field8"
            };

            await DbQueryFieldsCore(fieldNames).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task Field6()
        {
            string[] fieldNames = new[] {
                "FIELD4",
                "field7",
                "FIELD1",
                "FIELD5",
                "field8",
                "FIELD2"
            };

            await DbQueryFieldsCore(fieldNames).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task Field7()
        {
            string[] fieldNames = new[] {
                "FIELD4",
                "field7",
                "FIELD1",
                "FIELD5",
                "field8",
                "FIELD2",
                "FIELD6"
            };

            await DbQueryFieldsCore(fieldNames).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task Field8()
        {
            string[] fieldNames = new[] {
                "FIELD4",
                "field7",
                "FIELD1",
                "FIELD5",
                "field8",
                "FIELD2",
                "FIELD6",
                "field9"
            };

            await DbQueryFieldsCore(fieldNames).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task Field9()
        {
            string[] fieldNames = new[] {
                "FIELD4",
                "field7",
                "FIELD1",
                "FIELD5",
                "field8",
                "FIELD2",
                "FIELD6",
                "field9",
                "FIELD3"
            };

            await DbQueryFieldsCore(fieldNames).ConfigureAwait(false);
        }

        private async Task DbQueryFieldsCore(string[] fieldNames)
        {
            var provider = SampleSQLite.CreateProvider();

            using var connection = provider.CreateConnection(":memory:");

            SampleSQLite.PrepareSampleTable(connection);

            DataGeneratorSettings generatorSettings = new DataGeneratorSettings()
            {
                TupleFields = new DataGeneratorTupleFieldSettings[]
                {
                    new DbQueryFieldsSettings()
                    {
                        FieldNames = fieldNames,
                        DbQuerySettings = new DbQuerySettings()
                        {
                            CommandText = "select * from SAMPLE_TABLE",
                            ConnectionString = ":memory:",
                        }
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref generatorSettings);

            DataGeneratorContext context = new DataGeneratorContext(dbProvider: SampleSQLite.CreateProvider(connection));

            DataGeneratorBuilder builder = generatorSettings.CreateBuilder(context);

            using DataGenerator generator = await builder.BuildAsync(10).ConfigureAwait(false);

            for (int i = 0; i < fieldNames.Length; ++i)
            {
                Assert.AreEqual(fieldNames[i], generator.GetFieldName(i));
            }

            StringBuilder sb = new StringBuilder();

            TestUtility.DumpHeader(generator, sb);

            while (generator.GenerateNext())
            {
                TestUtility.DumpRecord(generator, sb);
            }

            Debug.WriteLine(sb.ToString());
        }

    }

}
