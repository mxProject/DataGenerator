using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using mxProject.Devs.DataGeneration;
using mxProject.Devs.DataGeneration.Fields;

using UnitTestProject1.Extensions;

namespace UnitTestProject1
{

    [TestClass]
    public class TestDataGenerator
    {
        [TestMethod]
        public async Task Test()
        {
            int generatingCount = 100;

            using DataGenerator generator = await CreateDataGeneratorAsync(generatingCount).ConfigureAwait(false);

            var sb = new StringBuilder();

            TestUtility.DumpHeader(generator, sb);
            
            int readedCount = 0;
            
            while (generator.GenerateNext())
            {
                ++readedCount;

                TestUtility.DumpRecord(generator, sb);
            }

            Debug.WriteLine(sb.ToString());

            Assert.AreEqual(generatingCount, readedCount);
        }

        internal async static ValueTask<System.Data.IDataReader> CreateDataReaderAsync(int generatingCount)
        {
            DataGenerator generator = await CreateDataGeneratorAsync(generatingCount).ConfigureAwait(false);
            return generator.AsDataReader();
        }

        internal async static ValueTask<DataGenerator> CreateDataGeneratorAsync(int generatingCount)
        {

            DataGeneratorContext context = TestUtility.CreateDataGeneratorContext();

            DataGeneratorBuilder generator = new DataGeneratorBuilder(context.FieldFactory);

            generator.AddField(factory => factory.Each("bool", new bool[] { true, false, false }));
            generator.AddField(factory => factory.Each("byte", new byte[] { 1, 2, 3 }));
            generator.AddField(factory => factory.Each("short", new short[] { 10, 20, 30, 40 }));
            generator.AddField(factory => factory.Each("int", new int[] { 100, 200, 300, 400, 500 }));
            generator.AddField(factory => factory.Each("long", new long[] { 1000, 2000, 3000, 4000, 5000, 6000 }));
            generator.AddField(factory => factory.Each("float", new float[] { 1.1f, 2.2f, 3.3f }));
            generator.AddField(factory => factory.Each("double", new double[] { 1.11, 2.22, 3.33, 4.44 }));
            generator.AddField(factory => factory.Each("decimal", new decimal[] { 1.111m, 2.222m, 3.333m, 4.444m, 5.555m }));
            generator.AddField(factory => factory.Each("datetime", new DateTime[] { DateTime.Now, DateTime.Today }));
            generator.AddField(factory => factory.Each("datetimeOffset", new DateTimeOffset[] { DateTime.Now, DateTime.Today }));
            generator.AddField(factory => factory.Each("timespan", new TimeSpan[] { TimeSpan.FromDays(1), TimeSpan.FromHours(2), TimeSpan.FromMinutes(3) }));
            generator.AddField(factory => factory.EachEnum<DayOfWeek>("dayOfWeek"));

            generator.AddField(factory => factory.RandomBoolean("bool2", generatingCount, 0.6));
            generator.AddField(factory => factory.RandomByte("byte2", byte.MinValue, byte.MaxValue));
            generator.AddField(factory => factory.RandomInt16("short2", short.MinValue, short.MaxValue));
            generator.AddField(factory => factory.RandomInt32("int2", generatingCount, -10000, nullProbability: 10000));
            generator.AddField(factory => factory.RandomInt64("long2", generatingCount, -10000, selector: x => x * 100, nullProbability: 10000));
            generator.AddField(factory => factory.RandomSingle("float2", generatingCount, -10000, selector: x => (float)MathEx.RoundMultiple(x, 5, 1), nullProbability: 10000));
            generator.AddField(factory => factory.RandomDouble("double2", generatingCount, -10000, selector: x => MathEx.RoundMultiple(x, 5, 2), nullProbability: 10000));
            generator.AddField(factory => factory.RandomDecimal("decimal2", generatingCount, -10000, selector: x => MathEx.RoundMultiple(x, 5, 3), nullProbability: 10000));
            generator.AddField(factory => factory.RandomDateTime("datetime2", DateTime.Today, DateTime.Today.AddMonths(1), selector: x => x.Date));
            generator.AddField(factory => factory.RandomDateTimeOffset("datetimeOffset2", DateTime.Today, DateTime.Today.AddMonths(1), selector: x => x.Date));
            generator.AddField(factory => factory.RandomTimeSpan("timespan2", TimeSpan.FromMinutes(1), TimeSpan.FromDays(1), selector: x => TimeSpan.FromSeconds((int)x.TotalSeconds)));

            // tuple

            generator.AddTupleField(factory => DirectProductFieldFactory.CreateTupleField(
                new IDataGeneratorField[] 
                {
                    factory.Each("product1", new[] { 1, 2 }, 0.1),
                    factory.Each("product2", new[] { "A", "B", "C", "D", "E" }, 0.25)
                }
                , context
                ));

            // additional

            generator.AddAdditionalField("expression", typeof(string), rec => $"{rec.GetValue("byte"):d2}-{rec.GetValue("short"):d4}");

            generator.AddAdditionalTupleField(
                new[]
                {
                    ("byte * int", typeof(int)),
                    ("short * int", typeof(int))
                },
                rec => new object?[]
                {
                    rec.GetRawValue<byte>("byte").GetValueOrDefault() * rec.GetRawValue<int>("int").GetValueOrDefault(),
                    rec.GetRawValue<short>("short").GetValueOrDefault() * rec.GetRawValue<int>("int").GetValueOrDefault()
                }
            );

            // join

            Dictionary<int, (StringValue, DateTime)> additionalValues = new()
            {
                { 100, ("one", new DateTime(2021, 1, 1)) },
                { 300, ("three", new DateTime(2021, 3, 3)) },
            };

            generator.AddJoinField(factory => factory.WithDictionary("int", new string[] { "join1", "join2" }, additionalValues));

            return await generator.BuildAsync(generatingCount).ConfigureAwait(false);

        }

    }

}
