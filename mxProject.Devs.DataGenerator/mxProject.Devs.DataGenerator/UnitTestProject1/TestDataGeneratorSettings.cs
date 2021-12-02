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
using mxProject.Devs.DataGeneration.Configuration.AdditionalFields;
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

            generatorSetting.SortedFieldNames = new string[]
            {
                "TUPLE1.EACH_DAYOFWEEK",
                "EACH_BOOLEAN",
                "EACH_BYTE",
                "EACH_SHORT",
                "EACH_INT",
                "EXPRESSION",
                "EACH_LONG",
                "EACH_SINGLE",
                // "EACH_DOUBLE",
                "EACH_DECIMAL",
                "EACH_DAYOFWEEK",
                "RANDOM_BOOLEAN",
                "RANDOM_BYTE",
                "RANDOM_SHORT",
                "RANDOM_INT",
                "RANDOM_LONG",
                "RANDOM_SINGLE",
                // "RANDOM_DOUBLE",
                "RANDOM_DECIMAL",
                "RANDOM_DATETIME",
                "RANDOM_DATETIMEOFFSET",
                "RANDOM_TIMESPAN",
                "RANDOM_GUID",
                "SEQUENCE_BYTE",
                "SEQUENCE_SHORT",
                "JOIN1",
                "JOIN2",
                "SEQUENCE_INT",
                "SEQUENCE_LONG",
                "SEQUENCE_DATETIME",
                "SEQUENCE_DATETIMEOFFSET",
                "SEQUENCE_TIMESPAN",
                "TUPLE1.SEQUENCE_INT",
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

        [TestMethod]
        public void Clone()
        {
            AnyFieldSettings any = new AnyFieldSettings() { FieldName = "any", ValueTypeName = "System.Int32", NullProbability = 0.1, Values = new string?[] { "1", "2" } };
            AnyFieldSettings<int> anyInt32 = new AnyFieldSettings<int>() { FieldName = "any_int32", NullProbability = 0.1, Values = new int?[] { 1, 2 } };
            AnyEnumFieldSettings anyEnum = new AnyEnumFieldSettings() { FieldName = "any_enum", EnumTypeName = "System.DayOfWeek", NullProbability = 0.1, Values = new string?[] { nameof(DayOfWeek.Monday), nameof(DayOfWeek.Sunday) } };
            AnyStringFieldSettings anyString = new AnyStringFieldSettings() { FieldName = "any_string", NullProbability = 0.1, Values = new string?[] { "a", "b" } };

            EachFieldSettings each = new EachFieldSettings() { FieldName = "any", ValueTypeName = "System.Int32", NullProbability = 0.1, Values = new string?[] { "1", "2" } };
            EachFieldSettings<int> eachInt32 = new EachFieldSettings<int>() { FieldName = "any_int32", NullProbability = 0.1, Values = new int?[] { 1, 2 } };
            EachEnumFieldSettings eachEnum = new EachEnumFieldSettings() { FieldName = "any_enum", EnumTypeName = "System.DayOfWeek", NullProbability = 0.1, Values = new string?[] { nameof(DayOfWeek.Monday), nameof(DayOfWeek.Sunday) } };
            EachStringFieldSettings eachString = new EachStringFieldSettings() { FieldName = "any_string", NullProbability = 0.1, Values = new string?[] { "a", "b" } };

            RandomInt32FieldSettings randomInt32 = new RandomInt32FieldSettings() { FieldName = "random_int32", MinimumValue = 1, MaximumValue = 100, NullProbability = 0.1, SelectorExpression = "x => x * 100" };
            SequenceInt32FieldSettings sequenceInt32 = new SequenceInt32FieldSettings() { FieldName = "sequence_int32", InitialValue = 1, MaximumValue = 100, NullProbability = 0.1, Increment = 2 };

            EachTupleFieldSettings eachTuple = new EachTupleFieldSettings()
            {
                Fields = new DataGeneratorFieldInfo[]
                {
                    new DataGeneratorFieldInfo() { FieldName = "tuple1", ValueType = "System.Int32" },
                    new DataGeneratorFieldInfo() { FieldName = "tuple2", ValueType = "System.String" }
                },
                NullProbability = 0.1,
                Values = new string?[][]
                {
                    new string?[]{ "1", "a" },
                    new string?[]{ "2", "b" },
                }
            };

            DirectProductFieldSettings directProduct = new DirectProductFieldSettings()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new EachFieldSettings() { FieldName = "directproduct1", ValueTypeName = "System.Int32", NullProbability = 0.1, Values = new string?[] { "1", "2" } },
                    new EachFieldSettings() { FieldName = "directproduct2", ValueTypeName = "System.String", NullProbability = 0.1, Values = new string?[] { "a", "b", "c" } }
                }
            };

            DbQueryFieldSettings dbQuery = new DbQueryFieldSettings() { FieldName = "dbquery", DbQuerySettings = new DbQuerySettings() { ConnectionTypeName = "OleDb", ConnectionString = "(connectionString)", CommandText = "select * from sample" } };
            DbQueryFieldsSettings dbQuerys = new DbQueryFieldsSettings() { FieldNames = new string[] { "dbquerys1", "dbquerys2" }, DbQuerySettings = new DbQuerySettings() { ConnectionTypeName = "OleDb", ConnectionString = "(connectionString)", CommandText = "select * from sample" } };

            JoinDbQueryFieldSettings joinDbQuery = new JoinDbQueryFieldSettings()
            {
                ReferenceKeyFieldNames = new string[] { "joindb_ref1", "joindb_ref2" },
                AdditionalKeyFieldNames = new string[] { "joindb_key1", "joindb_key2" },
                AdditionalValueFieldNames = new string[] { "joindb_add1", "joindb_add2" },
                DbQuerySettings = new DbQuerySettings() { ConnectionTypeName = "OleDb", ConnectionString = "(connectionString)", CommandText = "select * from sample" }
            };

            JoinFieldSettings join = new JoinFieldSettings()
            {
                KeyFields = new DataGeneratorFieldInfo[]
                {
                    new DataGeneratorFieldInfo(){ FieldName = "join_key1", ValueType = "System.Int32" },
                    new DataGeneratorFieldInfo(){ FieldName = "join_key2", ValueType = "System.String" }
                },
                AdditionalFields = new DataGeneratorFieldInfo[]
                {
                    new DataGeneratorFieldInfo(){ FieldName = "join_add1", ValueType = "System.Boolean" },
                    new DataGeneratorFieldInfo(){ FieldName = "join_add2", ValueType = "System.DateTime" }
                },
                AdditionalValues = new Dictionary<string?[], string?[]>()
                {
                    { new string?[]{ "1", "a" }, new string?[]{ "false", "2021/01/01" } },
                    { new string?[]{ "1", "b" }, new string?[]{ "true", "2021/01/02" } },
                }
            };

            ExpressionFieldSettings expression = new ExpressionFieldSettings() { FieldName = "expression", ValueType = "System.String", Expression = "rec => rec.GetString(0)" };

            DataGeneratorSettings generatorSettings = new DataGeneratorSettings()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    any,
                    anyInt32,
                    anyEnum,
                    anyString,
                    each,
                    eachInt32,
                    eachEnum,
                    eachString,
                    randomInt32,
                    sequenceInt32,
                    dbQuery
                },
                TupleFields = new DataGeneratorTupleFieldSettings[]
                {
                    eachTuple,
                    directProduct,
                    dbQuerys
                },
                AdditionalFields = new DataGeneratorAdditionalFieldSettings[]
                {
                    expression
                },
                AdditionalTupleFields = new DataGeneratorAdditionalTupleFieldSettings[]
                {
                    join,
                    joinDbQuery
                }
            };

            DataGeneratorSettings cloneSettings = (DataGeneratorSettings)generatorSettings.Clone();

            for (int i = 0; i < generatorSettings.Fields.Length; ++i)
            {
                AssertClone($"Fields[{i}]", generatorSettings.Fields[i], cloneSettings.Fields![i]);
            }
            for (int i = 0; i < generatorSettings.TupleFields.Length; ++i)
            {
                AssertClone($"TupleFields[{i}]", generatorSettings.TupleFields[i], cloneSettings.TupleFields![i]);
            }
            for (int i = 0; i < generatorSettings.AdditionalFields.Length; ++i)
            {
                AssertClone($"AdditionalFields[{i}]", generatorSettings.AdditionalFields[i], cloneSettings.AdditionalFields![i]);
            }
            for (int i = 0; i < generatorSettings.AdditionalTupleFields.Length; ++i)
            {
                AssertClone($"AdditionalTupleFields[{i}]", generatorSettings.AdditionalTupleFields[i], cloneSettings.AdditionalTupleFields![i]);
            }


            var jsonSettings = TestUtility.CreateJsonSerializerSettings();

            var json = JsonConvert.SerializeObject(generatorSettings, jsonSettings);
            var cloneJson = JsonConvert.SerializeObject(cloneSettings, jsonSettings);

            Assert.AreEqual(json, cloneJson);
        }

        static void AssertClone(string target, object? original, object? clone)
        {
            System.Diagnostics.Debug.WriteLine($"target = {target}, type = {original?.GetType()}");

            Assert.AreEqual(original is null, clone is null);

            if (original == null && clone == null) { return; }

            Assert.AreEqual(original!.GetType(), clone!.GetType());
            Assert.AreNotSame(original, clone);

            if (original.GetType().IsArray)
            {
                Array originalArray = (Array)original;
                Array cloneArray = (Array)clone;

                for (int i = 0; i < originalArray.Length; ++i)
                {
                    Type? elementType = originalArray.GetType().GetElementType();

                    if (elementType != null && s_ShouldAssertTypes.Contains(elementType))
                    {
                        AssertClone($"{target}[{i}]", originalArray.GetValue(i), cloneArray.GetValue(i));
                    }
                }
            }

            foreach (var prop in original.GetType().GetProperties())
            {
                if (s_ShouldAssertTypes.Contains(prop.PropertyType) && prop.GetIndexParameters().Length == 0)
                {
                    AssertClone($"{target}.{prop.Name}", prop.GetValue(original), prop.GetValue(clone));
                }
            }
        }

        private readonly static HashSet<Type> s_ShouldAssertTypes = new HashSet<Type>(new Type[] 
        {
            typeof(int?[]),
            typeof(string[]),
            typeof(string[][]),
            typeof(Dictionary<string[], string[]>),
            typeof(DataGeneratorFieldInfo),
            typeof(DataGeneratorFieldInfo[]),
            typeof(DataGeneratorFieldSettings),
            typeof(DataGeneratorFieldSettings[]),
            typeof(DbQuerySettings),
            typeof(EachFieldSettings),
        }
        );

    }

}
