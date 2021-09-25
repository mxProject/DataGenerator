using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using JsonSubTypes;
using System.Dynamic;
using System.IO;
using System.Drawing;
using System.Data;
using System.Linq;
using mxProject.Devs.DataGeneration;
using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Devs.DataGeneration.Configuration.Fields;
using mxProject.Devs.DataGeneration.Configuration.Json;

using UnitTestProject1.Extensions;

namespace UnitTestProject1
{

    [TestClass]
    public class TestDataGeneratorSettings
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Test()
        {

            DataGeneratorSettings generatorSetting = new DataGeneratorSettings() { };

            generatorSetting.Fields = new DataGeneratorFieldSettings[]
            {
                new EachFieldSettings<bool>()
                {
                    FieldName = "EACH_BOOLEAN",
                    NullProbability = 0.1,
                    Values = new bool?[]{ true, true, false, null }
                },
                new EachFieldSettings<byte>()
                {
                    FieldName = "EACH_BYTE",
                    NullProbability = 0.1,
                    Values = new byte?[]{ 1, 2, 3, null }
                },
                new EachFieldSettings<short>()
                {
                    FieldName = "EACH_SHORT",
                    NullProbability = 0.1,
                    Values = new short?[]{ 10, 20, 30, 40, null }
                },
                new EachFieldSettings<int>()
                {
                    FieldName = "EACH_INT",
                    NullProbability = 0.1,
                    Values = new int?[]{ 100, 200, 300, 400, 500, null }
                },
                new EachFieldSettings<long>()
                {
                    FieldName = "EACH_LONG",
                    NullProbability = 0.1,
                    Values = new long?[]{ 1000, 2000, 3000, 4000, 5000, 6000, null }
                },
                new EachFieldSettings<float>()
                {
                    FieldName = "EACH_SINGLE",
                    NullProbability = 0.1,
                    Values = new float?[]{ 1.1f, 2.2f, 3.3f, null }
                },
                new EachFieldSettings<double>()
                {
                    FieldName = "EACH_DOUBLE",
                    NullProbability = 0.1,
                    Values = new double?[]{ 1.11, 2.22, 3.33, 4.44, null }
                },
                new EachFieldSettings<decimal>()
                {
                    FieldName = "EACH_DECIMAL",
                    NullProbability = 0.1,
                    Values = new decimal?[]{ 1.111m, 2.222m, 3.333m, 4.444m, 5.555m, null }
                },
                new EachEnumFieldSettings()
                {
                    FieldName = "EACH_DAYOFWEEK",
                    EnumTypeName = "System.DayOfWeek",
                    Values = new string?[]{ "Sunday", "Monday", "Tuesday", "Wednesday", null },
                    NullProbability = 0.1,
                },


                new RandomBooleanFieldSettings()
                {
                    FieldName = "RANDOM_BOOLEAN",
                    NullProbability = 0.1,
                    TrueProbability = 0.3,
                },
                new RandomByteFieldSettings()
                {
                    FieldName = "RANDOM_BYTE",
                    NullProbability = 0.1,
                    MinimumValue = 0,
                    MaximumValue = byte.MaxValue,
                    SelectorExpression = "x => x",
                },
                new RandomInt16FieldSettings()
                {
                    FieldName = "RANDOM_SHORT",
                    NullProbability = 0.1,
                    MinimumValue = 0,
                    MaximumValue = short.MaxValue,
                    SelectorExpression = "x => (short)(x * -1)",
                },
                new RandomInt32FieldSettings()
                {
                    FieldName = "RANDOM_INT",
                    NullProbability = 0.1,
                    MinimumValue = 0,
                    MaximumValue = int.MaxValue,
                    SelectorExpression = "x => x * -1",
                },
                new RandomInt64FieldSettings()
                {
                    FieldName = "RANDOM_LONG",
                    NullProbability = 0.1,
                    MinimumValue = 0,
                    MaximumValue = long.MaxValue,
                    SelectorExpression = "x => x * -1",
                },
                new RandomSingleFieldSettings()
                {
                    FieldName = "RANDOM_SINGLE",
                    NullProbability = 0.1,
                    MinimumValue = 0,
                    MaximumValue = float.MaxValue,
                    SelectorExpression = "x => x * -1",
                },
                new RandomDoubleFieldSettings()
                {
                    FieldName = "RANDOM_DOUBLE",
                    NullProbability = 0.1,
                    MinimumValue = 0,
                    MaximumValue = double.MaxValue,
                    SelectorExpression = "x => x * -1",
                },
                new RandomDecimalFieldSettings()
                {
                    FieldName = "RANDOM_DECIMAL",
                    NullProbability = 0.1,
                    MinimumValue = 0,
                    // MaximumValue = decimal.MaxValue, // JsonSerializer throws overflow exception.
                    SelectorExpression = "x => x * -1",
                },
                new RandomDateTimeFieldSettings()
                {
                    FieldName = "RANDOM_DATETIME",
                    NullProbability = 0.1,
                    MinimumValue = DateTime.Now.AddDays(1 - DateTime.Now.Day),
                    MaximumValue = DateTime.Today,
                    SelectorExpression = "x => x.Date",
                },
                new RandomDateTimeOffsetFieldSettings()
                {
                    FieldName = "RANDOM_DATETIMEOFFSET",
                    NullProbability = 0.1,
                    MinimumValue = DateTime.Now.AddDays(1 - DateTime.Now.Day),
                    MaximumValue = DateTime.Today,
                    SelectorExpression = "x => x",
                },
                new RandomTimeSpanFieldSettings()
                {
                    FieldName = "RANDOM_TIMESPAN",
                    NullProbability = 0.1,
                    MinimumValue = TimeSpan.FromMinutes(0),
                    MaximumValue = TimeSpan.FromMinutes(120),
                    SelectorExpression = "x => new System.TimeSpan(x.Days, x.Hours, x.Minutes, x.Seconds)",
                },
                new RandomGuidFieldSettings()
                {
                    FieldName = "RANDOM_GUID",
                    NullProbability = 0.1,
                },


                new SequenceByteFieldSettings()
                {
                    FieldName = "SEQUENCE_BYTE",
                    InitialValue = 1,
                    MaximumValue = 15,
                    Increment = 3,
                },
                new SequenceInt16FieldSettings()
                {
                    FieldName = "SEQUENCE_SHORT",
                    InitialValue = 10,
                    MaximumValue = 150,
                    Increment = 30,
                },
                new SequenceInt32FieldSettings()
                {
                    FieldName = "SEQUENCE_INT",
                    InitialValue = 100,
                    MaximumValue = 1500,
                    Increment = 300,
                },
                new SequenceInt64FieldSettings()
                {
                    FieldName = "SEQUENCE_LONG",
                    InitialValue = 1000,
                    MaximumValue = 15000,
                    Increment = 3000,
                },
                new SequenceDateTimeFieldSettings()
                {
                    FieldName = "SEQUENCE_DATETIME",
                    InitialValue = DateTime.Today,
                    MaximumValue = DateTime.Today.AddDays(15),
                    Increment = TimeSpan.FromDays(2),
                },
                new SequenceDateTimeOffsetFieldSettings()
                {
                    FieldName = "SEQUENCE_DATETIMEOFFSET",
                    InitialValue = DateTime.Today.ToLocalTime(),
                    MaximumValue = DateTime.Today.AddDays(15),
                    Increment = TimeSpan.FromHours(12),
                },
                new SequenceTimeSpanFieldSettings()
                {
                    FieldName = "SEQUENCE_TIMESPAN",
                    InitialValue = TimeSpan.Zero,
                    MaximumValue = TimeSpan.FromHours(1),
                    Increment = TimeSpan.FromMinutes(5),
                },

            };

            generatorSetting.TupleFields = new DirectProductFieldSettings[]
            {
                new DirectProductFieldSettings()
                {
                    Fields = new DataGeneratorFieldSettings[]
                    {
                        new SequenceInt32FieldSettings()
                        {
                            FieldName = "TUPLE1.SEQUENCE_INT",
                            InitialValue = 1,
                            MaximumValue = 4,
                        },
                        new EachEnumFieldSettings()
                        {
                            FieldName = "TUPLE1.EACH_DAYOFWEEK",
                            EnumTypeName = "System.DayOfWeek",
                        },
                    }
                }
            };

            generatorSetting.AdditionalFields = new DataGeneratorAdditionalFieldSettings[]
            {
                new mxProject.Devs.DataGeneration.Configuration.AdditionalFields.ExpressionFieldSettings()
                {
                    FieldName = "EXPRESSION",
                    ValueType = "System.String",
                    Expression = @"rec => rec.GetInt32(""EACH_INT"").ToString(""d8"")"
                }
            };

            generatorSetting.AdditionalTupleFields = new DataGeneratorAdditionalTupleFieldSettings[]
            {
                new mxProject.Devs.DataGeneration.Configuration.AdditionalFields.JoinFieldSettings()
                {
                    KeyFields = new DataGeneratorFieldInfo[]
                    {
                        new DataGeneratorFieldInfo("SEQUENCE_BYTE", typeof(byte)),
                        new DataGeneratorFieldInfo("SEQUENCE_SHORT", typeof(short))
                    },
                    AdditionalFields = new DataGeneratorFieldInfo[]
                    {
                        new DataGeneratorFieldInfo("JOIN1", typeof(string)),
                        new DataGeneratorFieldInfo("JOIN2", typeof(bool))
                    },
                    AdditionalValues = new Dictionary<string?[], string?[]>()
                    {
                        { new[]{ "1", "10" }, new[]{ "1-10", "true" } },
                        { new[]{ "1", "11" }, new[]{ "1-11", "false" } },
                        { new[]{ "2", "20" }, new[]{ "2-20", "true" } },
                        { new[]{ "3", "30" }, new[]{ "3-30", "true" } },
                        { new[]{ "4", "40" }, new[]{ "4-40", "true" } },
                    }
                }
            };

            DataGeneratorContext context = TestUtility.CreateDataGeneratorContext();

            await GenerateAsync(context, generatorSetting, 15).ConfigureAwait(false);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="generatorSetting"></param>
        /// <returns></returns>
        private async Task GenerateAsync(DataGeneratorContext context, DataGeneratorSettings generatorSetting, int generationCount, Action<IDataGenerationRecord>? valueAssertion = null)
        {

            StringBuilder sb = new();

            TestUtility.AssertJsonSerialize(ref generatorSetting);

            using IDataGenerationReader reader = await generatorSetting.CreateBuilder(context).BuildAsDataReaderAsync(generationCount).ConfigureAwait(false);

            TestUtility.DumpHeader(reader, sb);

            object[] values = new object[reader.FieldCount];

            int generatedCount = 0;

            while (reader.Read())
            {
                TestUtility.DumpRecord(reader, sb);

                reader.GetValues(values);

                valueAssertion?.Invoke(reader);

                ++generatedCount;
            }

            System.Diagnostics.Debug.WriteLine(sb.ToString());

            Assert.AreEqual(generationCount, generatedCount);

        }


    }

}
