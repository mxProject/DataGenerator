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
using mxProject.Devs.DataGeneration.Configuration.AdditionalFields;

using UnitTestProject1.SampleValues;

namespace UnitTestProject1
{

    [TestClass]
    public class TestJoinDbQuery
    {

        [TestMethod]
        public async Task UseSQLite()
        {
            var provider = SampleSQLite.CreateProvider();

            using var connection = provider.CreateConnection(":memory:");

            SampleSQLite.PrepareShopMaster(connection);

            DataGeneratorSettings generatorSettings = new DataGeneratorSettings()
            {
                TupleFields = new DataGeneratorTupleFieldSettings[]
                {
                    new DirectProductFieldSettings()
                    {
                        Fields = new DataGeneratorFieldSettings[]
                        {
                            new EachFieldSettings<int>(){ FieldName = "CompanyCode", Values = new int?[]{ 1, 2, 3, null } },
                            new EachFieldSettings<long>(){ FieldName = "ShopCode", Values = new long?[]{ 1, 2, 3, null } }
                        }
                    }
                },
                AdditionalTupleFields = new DataGeneratorAdditionalTupleFieldSettings[]
                {
                    new JoinDbQueryFieldSettings()
                    {
                        DbQuerySettings = new DbQuerySettings()
                        {
                            CommandText = "select * from SHOP_MASTER",
                            ConnectionString = ":memory:",
                        },
                        ReferenceKeyFieldNames = new[]{ "CompanyCode", "ShopCode" },
                        AdditionalKeyFieldNames = new[]{ "COMPANY_CODE", "SHOP_CODE" },
                        AdditionalValueFieldNames = new[]{ "SHOP_NAME", "TELEPHONE_NUMBER" },
                    }
                }
            };

            DataGeneratorContext context = new DataGeneratorContext(dbProvider: SampleSQLite.CreateProvider(connection));

            DataGeneratorBuilder builder = generatorSettings.CreateBuilder(context);

            using DataGenerator generator = await builder.BuildAsync(10).ConfigureAwait(false);

            Assert.AreEqual("CompanyCode", generator.GetFieldName(0));
            Assert.AreEqual("ShopCode", generator.GetFieldName(1));
            Assert.AreEqual("SHOP_NAME", generator.GetFieldName(2));
            Assert.AreEqual("TELEPHONE_NUMBER", generator.GetFieldName(3));

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
