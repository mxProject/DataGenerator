using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Data;
using System.Threading.Tasks;
using mxProject.Devs.DataGeneration;

using UnitTestProject1.Extensions;

namespace UnitTestProject1
{

    [TestClass]
    public class TestDataGenerateDataReader
    {
        [TestMethod]
        public async Task Test()
        {
            int generatingCount = 100;

            using IDataReader reader = await TestDataGenerator.CreateDataReaderAsync(generatingCount).ConfigureAwait(false);

            var sb = new StringBuilder();

            for (int i = 0; i < reader.FieldCount; ++i)
            {
                sb.Append('\t');
                sb.Append(reader.GetName(i));
            }
            sb.AppendLine();

            for (int i = 0; i < reader.FieldCount; ++i)
            {
                sb.Append('\t');
                sb.Append(reader.GetFieldType(i)?.Name);
            }
            sb.AppendLine();

            int readedCount = 0;

            while (reader.Read())
            {
                ++readedCount;

                sb.Append(readedCount);

                for (int i = 0; i < reader.FieldCount; ++i)
                {
                    sb.Append('\t');
                    sb.Append(reader.GetValue(i));
                }
                sb.AppendLine();
            }

            Debug.WriteLine(sb.ToString());

            Assert.AreEqual(generatingCount, readedCount);

        }

    }

 }
