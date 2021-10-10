using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Data;
using mxProject.Devs.DataGeneration;
using mxProject.Devs.DataGeneration.Fields;
using mxProject.Devs.DataGeneration.AdditionalFields;
using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Devs.DataGeneration.Configuration.Fields;
using mxProject.Devs.DataGeneration.Configuration.AdditionalFields;
using mxProject.Devs.DataGeneration.Configuration.Json;
using Newtonsoft.Json;

using UnitTestProject1.Extensions;
using UnitTestProject1.SampleValues;

namespace UnitTestProject1
{

    [TestClass]
    public class ForReadme
    {

        [ClassInitialize]
        public static void Init(TestContext _)
        {
            s_JsonSerializerSettings = TestUtility.CreateJsonSerializerSettings();
        }

        private static JsonSerializerSettings s_JsonSerializerSettings = null!;


        [TestMethod]
        public async Task Demo()
        {
            // Creates a builder.
            DataGeneratorBuilder builder = new DataGeneratorBuilder()

                // Sequence from 1 to 100
                .AddField(factory => factory.SequenceInt32(
                    "ID",
                    1,
                    100
                    ))

                // Random date from today to one month later
                .AddField(factory => factory.RandomDateTime(
                    "SalesDate",
                    DateTime.Today,
                    DateTime.Today.AddMonths(1),
                    x => x.Date
                    ))

                // Returns 1, 2, 3 in order
                .AddField(factory => factory.Each(
                    "ShopCode",
                    new int[] { 1, 2, 3 }
                    ))

                // Random numbers from 0 to 100000
                .AddField(factory => factory.RandomInt64(
                    "Sales",
                    0,
                    100000
                    ))

                // DayOfWeek corresponding to the value in the "SalesDate" field
                .AddAdditionalField(
                    "DayOfWeek",
                    typeof(DayOfWeek),
                    rec => rec.GetDateTime("SalesDate").DayOfWeek
                    )

                // Additional values corresponding to the value in the "ShopCode" field
                .AddJoinField(factory => factory.WithDictionary(
                    "ShopCode",
                    additionalFieldNames: new[]
                    {
                        "ShopName",
                        "OpeningTime"
                    },
                    additionalValues: new Dictionary<int, (StringValue, TimeSpan)>()
                    {
                        { 1, ("SHOP1", new TimeSpan(10, 0, 0)) },
                        { 2, ("SHOP2", new TimeSpan(18, 0, 0)) }
                    }
                    ))
                ;

            // Creates an IDataReader that wraps the generator.
            using IDataReader reader = await builder.BuildAsDataReaderAsync(generateCount:10);

            for (int i = 0; i < reader.FieldCount; ++i)
            {
                if (i > 0) { Debug.Write('\t'); }
                Debug.Write(reader.GetName(i));
            }
            Debug.WriteLine("");

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; ++i)
                {
                    if (i > 0) { Debug.Write('\t'); }
                    Debug.Write(reader.GetValue(i));
                }
                Debug.WriteLine("");
            }
        }

        [TestMethod]
        public async Task Demo_Configuration()
        {
            // Creates a generator settings.
            DataGeneratorSettings generatorSettings = new DataGeneratorSettings()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    // Sequence from 1 to 100
                    new SequenceInt32FieldSettings()
                    {
                        FieldName = "ID",
                        InitialValue = 1,
                        MaximumValue = 100
                    },

                    // Random date from today to one month later
                    new RandomDateTimeFieldSettings()
                    {
                        FieldName = "SalesDate",
                        MinimumValue = DateTime.Today,
                        MaximumValue = DateTime.Today.AddMonths(1),
                        SelectorExpression = "x => x.Date"
                    },

                    // Returns 1, 2, 3 in order
                    new EachFieldSettings<int>()
                    {
                        FieldName = "ShopCode",
                        Values = new int?[]{ 1, 2, 3 }
                    },

                    // Random numbers from 0 to 100000
                    new RandomDecimalFieldSettings()
                    {
                        FieldName = "Sales",
                        MinimumValue = 1,
                        MaximumValue = 100000
                    }
                },
                AdditionalFields = new DataGeneratorAdditionalFieldSettings[]
                {
                    // DayOfWeek corresponding to the value in the "SalesDate" field
                    new ExpressionFieldSettings()
                    {
                        FieldName = "DayOfWeek",
                        ValueType = typeof(DayOfWeek).FullName,
                        Expression = "rec => rec.GetDateTime(\"SalesDate\").DayOfWeek"
                    } 
                },
                AdditionalTupleFields = new DataGeneratorAdditionalTupleFieldSettings[]
                {
                    // Additional values corresponding to the value in the "ShopCode" field
                    new JoinFieldSettings()
                    {
                        KeyFields = new DataGeneratorFieldInfo[]
                        {
                            new DataGeneratorFieldInfo("ShopCode", typeof(int))
                        },
                        AdditionalFields = new DataGeneratorFieldInfo[]
                        {
                            new DataGeneratorFieldInfo("ShopName", typeof(string)),
                            new DataGeneratorFieldInfo("OpeningTime", typeof(TimeSpan))
                        },
                        AdditionalValues = new Dictionary<string?[], string?[]>()
                        {
                            {
                                new[] { "1" },
                                new[] { "SHOP1", "10:00:00" }
                            },
                            {
                                new[] { "2" },
                                new[] { "SHOP2", "18:00:00" }
                            }
                        }
                    }
                }
            };

            // Creates a builder.
            DataGeneratorContext context = new DataGeneratorContext();

            DataGeneratorBuilder builder = generatorSettings.CreateBuilder(context);

            // Creates an IDataReader that wraps the generator.
            using IDataReader reader = await builder.BuildAsDataReaderAsync(generateCount: 10).ConfigureAwait(false);

            for (int i = 0; i < reader.FieldCount; ++i)
            {
                if (i > 0) { Debug.Write('\t'); }
                Debug.Write(reader.GetName(i));
            }
            Debug.WriteLine("");

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; ++i)
                {
                    if (i > 0) { Debug.Write('\t'); }
                    Debug.Write(reader.GetValue(i));
                }
                Debug.WriteLine("");
            }

            // Serialize the settings to Json.
            var converterBuilder = DataGeneratorFieldTypeConverterBuilder.CreateDefault();

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            foreach (var converter in converterBuilder.Build())
            {
                jsonSettings.Converters.Add(converter);
            }

            string json = JsonConvert.SerializeObject(generatorSettings, jsonSettings);
            System.Diagnostics.Debug.WriteLine(json);
        }

        #region Each

        [TestMethod]
        public async Task Each()
        {
            // Creates a builder.
            DataGeneratorBuilder builder = new DataGeneratorBuilder();

            // Adds fields.
            builder
                .AddField(factory => factory.Each(
                    "EACH_BYTE",
                    // Specify the values to enumerate.
                    new byte?[] { 1, 2, 3, null },
                    // Specifies the probability of returning null.
                    0.1
                ))
                .AddField(factory => factory.Each(
                    "EACH_DAYOFWEEK",
                    // Specify the values to enumerate.
                    // If omitted, all values are enumerated.
                    new DayOfWeek?[] { DayOfWeek.Saturday, DayOfWeek.Sunday, null },
                    // Specifies the probability of returning null.
                    0.1
                ))
                ;

            // Creates a generator that generates 10 records and returns it as a DataReader.
            using IDataReader reader = await builder.BuildAsDataReaderAsync(10);

            Dump(reader);
        }

        [TestMethod]
        public async Task EachSettings()
        {
            // Creates a generator settings.
            DataGeneratorSettings generatorSetting = new DataGeneratorSettings() { };

            // Adds fields.
            generatorSetting.Fields = new DataGeneratorFieldSettings[]
            {
                new EachFieldSettings<byte>()
                {
                    FieldName = "EACH_BYTE",
                    // Specifies the candidate value to return.
                    Values = new byte?[] { 1, 2, 3, null },
                    // Specifies the probability of returning null.
                    NullProbability = 0.1
                },
                new EachEnumFieldSettings()
                {
                    FieldName = "EACH_DAYOFWEEK",
                    // Specifies the type name.
                    EnumTypeName = "System.DayOfWeek",
                    // Specify the values to enumerate.
                    // If omitted, all values are enumerated.
                    Values = new string?[] { "Saturday", "Sunday", null },
                    // Specifies the probability of returning null.
                    NullProbability = 0.1
                }
            };

            // Create a context that controls the behavior of the generator.
            // You can replace random number generation algorithms, string converters, etc. with your own implementation.
            DataGeneratorContext context = new DataGeneratorContext();

            // Creates a builder.
            DataGeneratorBuilder builder = generatorSetting.CreateBuilder(context);

            // Creates a generator that generates 10 records and returns it as a DataReader.
            using IDataReader reader = await builder.BuildAsDataReaderAsync(10);

            Dump(reader);

            string json = JsonConvert.SerializeObject(generatorSetting, s_JsonSerializerSettings);

            System.Diagnostics.Debug.WriteLine(json);
        }

        #endregion

        #region Any

        [TestMethod]
        public async Task Any()
        {
            // Creates a builder.
            DataGeneratorBuilder builder = new DataGeneratorBuilder();

            // Adds fields.
            builder
                .AddField(factory => factory.AnyOne(
                    "ANY_BYTE",
                    // Specifies the candidate value to return.
                    new byte?[] { 1, 2, 3, null },
                    // Specifies the probability of returning null.
                    0.1
                    ))
                .AddField(factory => factory.AnyOneEnum(
                    "ANY_DAYOFWEEK",
                    // Specifies the candidate value to return.
                    // If omitted, all values are candidates.
                    new DayOfWeek?[] { DayOfWeek.Saturday, DayOfWeek.Sunday, DayOfWeek.Monday, null },
                    // Specifies the probability of returning null.
                    0.1
                    ))
                ;

            // Creates a generator that generates 10 records and returns it as a DataReader.
            using IDataReader reader = await builder.BuildAsDataReaderAsync(10);

            Dump(reader);
        }

        [TestMethod]
        public async Task AnySettings()
        {
            // Creates a generator settings.
            DataGeneratorSettings generatorSetting = new DataGeneratorSettings() { };

            // Adds fields.
            generatorSetting.Fields = new DataGeneratorFieldSettings[]
            {
                new AnyFieldSettings<byte>()
                {
                    FieldName = "ANY_BYTE",
                    // Specifies the candidate value to return.
                    Values = new byte?[] { 1, 2, 3, null },
                    // Specifies the probability of returning null.
                    NullProbability = 0.1
                },
                new AnyEnumFieldSettings()
                {
                    FieldName = "ANY_DAYOFWEEK",
                    // Specifies the type name.
                    EnumTypeName = "System.DayOfWeek",
                    // Specifies the candidate value to return.
                    // If omitted, all values are candidates.
                    Values = new string?[] { "Saturday", "Sunday", "Monday", null },
                    // Specifies the probability of returning null.
                    NullProbability = 0.1
                }
            };

            // Create a context that controls the behavior of the generator.
            // You can replace random number generation algorithms, string converters, etc. with your own implementation.
            DataGeneratorContext context = new DataGeneratorContext();

            // Creates a builder.
            DataGeneratorBuilder builder = generatorSetting.CreateBuilder(context);

            // Creates a generator that generates 10 records and returns it as a DataReader.
            using IDataReader reader = await builder.BuildAsDataReaderAsync(10);

            Dump(reader);

            string json = JsonConvert.SerializeObject(generatorSetting, s_JsonSerializerSettings);

            System.Diagnostics.Debug.WriteLine(json);
        }

        #endregion

        #region Random

        [TestMethod]
        public async Task Random()
        {
            // Creates a builder.
            DataGeneratorBuilder builder = new DataGeneratorBuilder();

            builder
                .AddField(factory => factory.RandomDouble(
                    "RANDOM_DOUBLE",
                    // Specifies the minimum value.
                    1,
                    // Specifies the maximum value.
                    100,
                    // If you want to modify the value, specify the selector.
                    x => Math.Round(x, 3),
                    // Specifies the probability of returning null.
                    0.1
                    ))
                .AddField(factory => factory.RandomDateTime(
                    "RANDOM_DATE",
                    // Specifies the minimum value.
                    DateTime.Today,
                    // Specifies the maximum value.
                    DateTime.Today.AddMonths(1),
                    // If you want to modify the value, specify the selector.
                    x => x.Date,
                    // Specifies the probability of returning null.
                    0.1
                    ))
                ;

            // Creates a generator that generates 10 records and returns it as a DataReader.
            using IDataReader reader = await builder.BuildAsDataReaderAsync(10);

            Dump(reader);
        }

        [TestMethod]
        public async Task RandomSetting()
        {
            // Creates a generator settings.
            DataGeneratorSettings generatorSetting = new DataGeneratorSettings() { };

            // Adds fields.
            generatorSetting.Fields = new DataGeneratorFieldSettings[]
            {
                new RandomDoubleFieldSettings()
                {
                    FieldName = "RANDOM_DOUBLE",
                    // Specifies the minimum value.
                    MinimumValue = 1,
                    // Specifies the maximum value.
                    MaximumValue = 100,
                    // If you want to modify the value, specify the selector.
                    SelectorExpression = "x => System.Math.Round(x, 3)",
                    // Specifies the probability of returning null.
                    NullProbability = 0.1
                },
                new RandomDateTimeFieldSettings()
                {
                    FieldName = "RANDOM_DATE",
                    // Specifies the minimum value.
                    MinimumValue = DateTime.Today,
                    // Specifies the maximum value.
                    MaximumValue = DateTime.Today.AddMonths(1),
                    // If you want to modify the value, specify the selector.
                    SelectorExpression = "x => x.Date",
                    // Specifies the probability of returning null.
                    NullProbability = 0.1
                }
            };

            // Create a context that controls the behavior of the generator.
            // You can replace random number generation algorithms, string converters, etc. with your own implementation.
            DataGeneratorContext context = new DataGeneratorContext( randomGenerator: null);

            // Creates a builder.
            DataGeneratorBuilder builder = generatorSetting.CreateBuilder(context);

            // Creates a generator that generates 10 records and returns it as a DataReader.
            using IDataReader reader = await builder.BuildAsDataReaderAsync(10);

            Dump(reader);

            string json = JsonConvert.SerializeObject(generatorSetting, s_JsonSerializerSettings);

            System.Diagnostics.Debug.WriteLine(json);
        }

        #endregion

        #region Sequence

        [TestMethod]
        public async Task Sequence()
        {
            // Creates a builder.
            DataGeneratorBuilder builder = new DataGeneratorBuilder();

            // Adds fields.
            builder
                .AddField(factory => factory.SequenceInt32(
                    "SEQUENCE_INT32",
                    // Specifies the initial value.
                    1,
                    // Specifies the maximum value.
                    100,
                    // Specifies the increment.
                    2,
                    // Specifies the probability of returning null.
                    0.1
                    ))
                .AddField(factory => factory.SequenceDateTime(
                    "SEQUENCE_DATETIME",
                    // Specifies the initial value.
                    DateTime.Today,
                    // Specifies the maximum value.
                    DateTime.Today.AddDays(10),
                    // Specifies the increment.
                    TimeSpan.FromHours(12),
                    // Specifies the probability of returning null.
                    0.1
                    ))
                .AddField(factory => factory.SequenceDateMonth(
                    "SEQUENCE_DATEMONTH",
                    // Specifies the initial value.
                    new DateTime(2021, 1, 31),
                    // Specifies the maximum value.
                    new DateTime(2021, 12, 31),
                    // Specifies the increment.
                    1,
                    // Specifies the probability of returning null.
                    0.1
                    ))
                ;

            // Creates a generator that generates 10 records and returns it as a DataReader.
            using IDataReader reader = await builder.BuildAsDataReaderAsync(10);

            Dump(reader);
        }

        [TestMethod]
        public async Task SequenceSettings()
        {
            // Creates a generator settings.
            DataGeneratorSettings generatorSetting = new DataGeneratorSettings() { };

            // Adds fields.
            generatorSetting.Fields = new DataGeneratorFieldSettings[]
            {
                new SequenceInt32FieldSettings()
                {
                    FieldName = "SEQUENCE_INT32",
                    // Specifies the initial value.
                    InitialValue = 1,
                    // Specifies the maximum value.
                    MaximumValue = 100,
                    // Specifies the increment.
                    Increment = 2,
                    // Specifies the probability of returning null.
                    NullProbability = 0.1
                },
                new SequenceDateTimeFieldSettings()
                {
                    FieldName = "SEQUENCE_DATETIME",
                    // Specifies the initial value.
                    InitialValue = DateTime.Today,
                    // Specifies the maximum value.
                    MaximumValue = DateTime.Today.AddDays(10),
                    // Specifies the increment.
                    Increment = TimeSpan.FromHours(12),
                    // Specifies the probability of returning null.
                    NullProbability = 0.1
                },
                new SequenceDateMonthFieldSettings()
                {
                    FieldName = "SEQUENCE_DATEMONTH",
                    // Specifies the initial value.
                    InitialValue = new DateTime(2021, 1, 31),
                    // Specifies the maximum value.
                    MaximumValue = new DateTime(2021, 12, 31),
                    // Specifies the increment.
                    Increment = 1,
                    // Specifies the probability of returning null.
                    NullProbability = 0.1
                }
            };

            // Create a context that controls the behavior of the generator.
            // You can replace random number generation algorithms, string converters, etc. with your own implementation.
            DataGeneratorContext context = new DataGeneratorContext();

            // Creates a builder.
            DataGeneratorBuilder builder = generatorSetting.CreateBuilder(context);

            // Creates a generator that generates 10 records and returns it as a DataReader.
            using IDataReader reader = await builder.BuildAsDataReaderAsync(10);

            Dump(reader);

            string json = JsonConvert.SerializeObject(generatorSetting, s_JsonSerializerSettings);

            System.Diagnostics.Debug.WriteLine(json);
        }

        #endregion

        #region DirectProduct

        [TestMethod]
        public async Task DirectProduct()
        {
            // Creates a context.
            DataGeneratorContext context = new DataGeneratorContext();

            // Creates a builder.
            DataGeneratorBuilder builder = new DataGeneratorBuilder();

            // Adds fields.
            builder
                // A field that enumerates sequencial numbers starting with 1
                .AddField(factory => factory.SequenceInt32("ID", initialValue: 1))
                // Enumerates the direct product of three fields
                .AddTupleField(factory => DirectProductFieldFactory.CreateTupleField(
                    new IDataGeneratorField[] {
                        // A field that enumerates sequencial numbers from 1 to 4
                        factory.SequenceInt32(
                            "FIELD1",
                            1,
                            4
                            ),
                        // A field that enumerates a, b, c
                        factory.Each(
                            "FIELD2",
                            new char?[]{ 'a', 'b', 'c' }
                            ),
                        // A field that enumerates true, false
                        factory.Each(
                            "FIELD3",
                            new bool?[]{ true, false }
                            ),
                    },
                    context
                    ))
                ;

            // Creates a generator that generates 30 records and returns it as a DataReader.
            using IDataReader reader = await builder.BuildAsDataReaderAsync(30);

            Dump(reader);
        }

        [TestMethod]
        public async Task DirectProductSettings()
        {
            // Creates a generator settings.
            DataGeneratorSettings generatorSetting = new DataGeneratorSettings() { };

            // Adds fields.
            generatorSetting.Fields = new DataGeneratorFieldSettings[]
            {
                // A field that enumerates sequencial numbers starting with 1
                new SequenceInt32FieldSettings()
                {
                    FieldName = "ID",
                    InitialValue = 1,
                },
            };

            // Adds tuple fields.
            generatorSetting.TupleFields = new DataGeneratorTupleFieldSettings[]
            {
                // Enumerates the direct product of three fields
                new DirectProductFieldSettings()
                {
                    Fields = new DataGeneratorFieldSettings[]
                    {
                        // A field that enumerates sequencial numbers from 1 to 4
                        new SequenceInt32FieldSettings()
                        {
                            FieldName = "FIELD1",
                            InitialValue = 1,
                            MaximumValue = 4,
                        },
                        // A field that enumerates a, b, c
                        new EachFieldSettings<char>()
                        {
                            FieldName = "FIELD2",
                            Values = new char?[]{ 'a', 'b', 'c' }
                        },
                        // A field that enumerates true, false
                        new EachFieldSettings<bool>()
                        {
                            FieldName = "FIELD3",
                            Values = new bool?[]{ true, false }
                        }
                    }
                }
            };

            // Create a context that controls the behavior of the generator.
            // You can replace random number generation algorithms, string converters, etc. with your own implementation.
            DataGeneratorContext context = new DataGeneratorContext();

            // Creates a builder.
            DataGeneratorBuilder builder = generatorSetting.CreateBuilder(context);

            // Creates a generator that generates 30 records and returns it as a DataReader.
            using IDataReader reader = await builder.BuildAsDataReaderAsync(30);

            Dump(reader);

            string json = JsonConvert.SerializeObject(generatorSetting, s_JsonSerializerSettings);

            System.Diagnostics.Debug.WriteLine(json);
        }

        #endregion

        #region Join

        [TestMethod]
        public async Task Join()
        {
            // Creates a builder.
            DataGeneratorBuilder builder = new DataGeneratorBuilder();

            // Adds fields.
            builder
                .AddField(factory => factory.Each(
                    "ID",
                    new int?[] { 1, 2, 3, null }
                    ))
                .AddField(factory => factory.Each(
                    "Area",
                    new char?[] { 'A', 'B' }
                    ))

                // Add fields that return the value corresponding to "ID".
                .AddJoinField(factory => factory.WithDictionary(
                    // Specifies the name of the key field.
                    "ID",
                    // Specifies the names of the fields to be added.
                    new[] { "Name","CreateAt"},
                    // Specifies the dictionary that stores the value to add.
                    new Dictionary<int, (StringValue, DateTime)>() 
                    {
                        { 1, ("A", new DateTime(2021, 1, 1)) },
                        { 3, ("C", new DateTime(2021, 3, 1)) },
                        { 5, ("E", new DateTime(2021, 5, 1)) }
                    }
                    ))

                // Add fields that return the value corresponding to "ID" and "Area".
                .AddJoinField(factory => factory.WithDictionaryKey2(
                    // Specifies the name of the key field.
                    new[] { "ID", "Area" },
                    // Specifies the names of the fields to be added.
                    "Amount",
                    // Specifies the dictionary that stores the value to add.
                    new Dictionary<(int, char), int>()
                    {
                        { (1, 'A'), 100 },
                        { (1, 'B'), 200 },
                        { (3, 'A'), 300 }
                    }
                    ))
                ;

            // Creates a generator that generates 10 records and returns it as a DataReader.
            using IDataReader reader = await builder.BuildAsDataReaderAsync(10);

            Dump(reader);
        }

        [TestMethod]
        public async Task JoinSettings()
        {
            // Creates a generator settings.
            DataGeneratorSettings generatorSetting = new DataGeneratorSettings() { };

            generatorSetting.Fields = new DataGeneratorFieldSettings[]
            {
                new EachFieldSettings<int>()
                {
                    FieldName = "ID",
                    Values = new int?[]{ 1, 2, 3, null },
                },
                new EachFieldSettings<char>()
                {
                    FieldName = "Area",
                    Values = new char?[]{ 'A', 'B' },
                }
            };

            generatorSetting.AdditionalTupleFields = new DataGeneratorAdditionalTupleFieldSettings[]
            {
                // Add fields that return the value corresponding to "ID".
                new JoinFieldSettings()
                {
                    // Specifies the key field.
                    KeyFields = new[]
                    {
                        new DataGeneratorFieldInfo("ID", typeof(int))
                    },
                    // Specifies the fields to be added.
                    AdditionalFields = new[]
                    {
                        new DataGeneratorFieldInfo("Name", typeof(string)),
                        new DataGeneratorFieldInfo("CreateAt", typeof(DateTime))
                    },
                    // Specifies the dictionary that stores the value to add.
                    AdditionalValues = new Dictionary<string?[], string?[]>()
                    {
                        {
                            new[]{ "1" },
                            new[]{ "A", "2021/01/01" }
                        },
                        {
                            new[]{ "3" },
                            new[]{ "C", "2021/03/01" }
                        },
                        {
                            new[]{ "5" },
                            new[]{ "E", "2021/05/01" }
                        }
                    }
                },
                // Add fields that return the value corresponding to "ID" and "Area".
                new JoinFieldSettings()
                {
                    // Specifies the key fields.
                    KeyFields = new[]
                    {
                        new DataGeneratorFieldInfo("ID", typeof(int)),
                        new DataGeneratorFieldInfo("Area", typeof(char))
                    },
                    // Specifies the field to be added.
                    AdditionalFields = new[]
                    {
                        new DataGeneratorFieldInfo("Amount", typeof(int)),
                    },
                    // Specifies the dictionary that stores the value to add.
                    AdditionalValues = new Dictionary<string?[], string?[]>()
                    {
                        {
                            new[]{ "1", "A" },
                            new[]{ "100" }
                        },
                        {
                            new[]{ "1", "B" },
                            new[]{ "200" }
                        },
                        {
                            new[]{ "3", "A" },
                            new[]{ "300" }
                        }
                    }
                }
            };

            // Create a context that controls the behavior of the generator.
            // You can replace random number generation algorithms, string converters, etc. with your own implementation.
            DataGeneratorContext context = new DataGeneratorContext();

            // Creates a builder.
            DataGeneratorBuilder builder = generatorSetting.CreateBuilder(context);

            // Creates a generator that generates 10 records and returns it as a DataReader.
            using IDataReader reader = await builder.BuildAsDataReaderAsync(10);

            Dump(reader);

            string json = JsonConvert.SerializeObject(generatorSetting, s_JsonSerializerSettings);

            System.Diagnostics.Debug.WriteLine(json);
        }

        #endregion

        #region JoinDbQuery

        [TestMethod]
        public async Task JoinDbQuery()
        {
            var provider = SampleSQLite.CreateProvider();

            using var connection = provider.CreateConnection(":memory:");

            SampleSQLite.PrepareShopMaster(connection);

            using IDataReader shopDataReader = SampleSQLite.GetShopMaster(connection);

            // Creates a context.
            DataGeneratorContext context = new DataGeneratorContext();

            // Creates a builder.
            DataGeneratorBuilder builder = new DataGeneratorBuilder();

            // Adds fields.
            builder

                // This field returns the direct product of CompanyCode and ShopCode.
                .AddTupleField(factory => DirectProductFieldFactory.CreateTupleField(
                    new IDataGeneratorField[]
                    {
                        factory.Each<int>("CompanyCode", new int?[]{ 1, 2, 3, null }),
                        factory.Each<long>("ShopCode", new long?[]{ 1, 2, 3, null })
                    },
                    context
                    )
                )

                // Add fields that return the value corresponding to (CompanyCode, ShopCode).
                .AddJoinField(factory => factory.WithDataReader(

                    // Specifies the reference key field names.
                    new string[] { "CompanyCode", "ShopCode" },

                    // Specifies the additional key field names.
                    new string[] { "COMPANY_CODE", "SHOP_CODE" },

                    // Specifies the additional value field names.
                    new string[] { "SHOP_NAME", "TELEPHONE_NUMBER" },

                    // Specifies the data reader.
                    shopDataReader
                    )
                )
                ;

            // Creates a generator that generates 10 records and returns it as a DataReader.
            using IDataReader reader = await builder.BuildAsDataReaderAsync(10);

            Dump(reader);
        }

        [TestMethod]
        public async Task JoinDbQuerySettings()
        {
            var provider = SampleSQLite.CreateProvider();

            using var connection = provider.CreateConnection(":memory:");

            SampleSQLite.PrepareShopMaster(connection);

            // Creates a generator settings.
            DataGeneratorSettings generatorSetting = new DataGeneratorSettings()
            {
                TupleFields = new DataGeneratorTupleFieldSettings[]
                {
                    // This field returns the direct product of CompanyCode and ShopCode. 
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
                    // Adds fields that return the value corresponding to (CompanyCode, ShopCode).
                    new JoinDbQueryFieldSettings()
                    {
                        // Specifies the query data source.
                        DbQuerySettings = new DbQuerySettings()
                        {
                            CommandText = "select * from SHOP_MASTER",
                            ConnectionString = ":memory:",
                            //ConnectionString = "Provider=SQLOLEDB; Data Source=(local); Integrated Security=SSPI"
                        },

                        // Specifies the reference key field names.
                        ReferenceKeyFieldNames = new[]{ "CompanyCode", "ShopCode" },

                        // Specifies the additional key field names.
                        AdditionalKeyFieldNames = new[]{ "COMPANY_CODE", "SHOP_CODE" },

                        // Specifies the additional value field names.
                        AdditionalValueFieldNames = new[]{ "SHOP_NAME", "TELEPHONE_NUMBER" },
                    }
                }
            };

            // Create a context that controls the behavior of the generator.
            // You can replace random number generation algorithms, string converters, etc. with your own implementation.
            DataGeneratorContext context = new DataGeneratorContext(dbProvider: SampleSQLite.CreateProvider(connection));

            // Creates a builder.
            DataGeneratorBuilder builder = generatorSetting.CreateBuilder(context);

            // Creates a generator that generates 10 records and returns it as a DataReader.
            using IDataReader reader = await builder.BuildAsDataReaderAsync(10);

            Dump(reader);

            string json = JsonConvert.SerializeObject(generatorSetting, s_JsonSerializerSettings);

            System.Diagnostics.Debug.WriteLine(json);
        }

        #endregion

        #region EachTuple

        [TestMethod]
        public async Task EachTuple()
        {
            // Creates a builder.
            DataGeneratorBuilder builder = new DataGeneratorBuilder();

            // Adds fields.
            builder.AddTupleField(factory => factory.EachTuple(
                // Specifies the names of the fields.
                "Field1",
                "Field2",
                "Field3",
                // Specifies the values of the fields.
                new (bool?, int?, StringValue?)[]
                {
                    (true, 1, "A"),
                    (false, 2, "B"),
                    (null, 3, "C"),
                },
                // Specifies the probability of returning null.
                0.1
                ));

            // Creates a generator that generates 10 records and returns it as a DataReader.
            using IDataReader reader = await builder.BuildAsDataReaderAsync(10);

            Dump(reader);
        }

        [TestMethod]
        public async Task EachTupleSettings()
        {
            // Creates a generator settings.
            DataGeneratorSettings generatorSetting = new DataGeneratorSettings() { };

            // Adds fields.
            generatorSetting.TupleFields = new DataGeneratorTupleFieldSettings[]
            {
                new EachTupleFieldSettings()
                {
                    // Specifies the field names and value types.
                    Fields = new DataGeneratorFieldInfo[]
                    {
                        new DataGeneratorFieldInfo("Field1", typeof(bool)),
                        new DataGeneratorFieldInfo("Field2", typeof(int)),
                        new DataGeneratorFieldInfo("Field3", typeof(string))
                    },
                    // Specifies the values of the fields.
                    Values = new string?[][]
                    {
                        new[]{ "true", "1", "A" },
                        new[]{ "false", "2", "B" },
                        new[]{ null, "3", "C" }
                    },
                    // Specifies the probability of returning null.
                    NullProbability = 0.1
                }
            };

            // Create a context that controls the behavior of the generator.
            // You can replace random number generation algorithms, string converters, etc. with your own implementation.
            DataGeneratorContext context = new DataGeneratorContext();

            // Creates a builder.
            DataGeneratorBuilder builder = generatorSetting.CreateBuilder(context);

            // Creates a generator that generates 10 records and returns it as a DataReader.
            using IDataReader reader = await builder.BuildAsDataReaderAsync(10);

            Dump(reader);

            string json = JsonConvert.SerializeObject(generatorSetting, s_JsonSerializerSettings);

            System.Diagnostics.Debug.WriteLine(json);
        }

        #endregion

        #region Expression

        [TestMethod]
        public async Task Expression()
        {
            // Creates a builder.
            DataGeneratorBuilder builder = new DataGeneratorBuilder();

            // Adds fields.
            builder
                .AddField(factory => factory.Each(
                    "Major",
                    new int?[] { 1, 2, 3 }
                    ))
                .AddField(factory => factory.Each(
                    "Minor",
                    new int?[] { 51, 52, 53, 54, 55 }
                    ))
                .AddField(factory => factory.RandomInt32(
                    "Number",
                    0,
                    9999
                    ))

                // Adds field that return the formatted number string.
                .AddAdditionalField(
                    "FormattedNumber",
                    typeof(string),
                    rec => $"{rec.GetInt32("Major")}-{rec.GetInt32("Minor")}-{rec.GetInt32("Number"):d4}"
                    )
                ;

            // Creates a generator that generates 10 records and returns it as a DataReader.
            using IDataReader reader = await builder.BuildAsDataReaderAsync(10);

            Dump(reader);
        }

        [TestMethod]
        public async Task ExpressionSettings()
        {
            // Creates a generator settings.
            DataGeneratorSettings generatorSetting = new DataGeneratorSettings() { };

            generatorSetting.Fields = new DataGeneratorFieldSettings[]
            {
                new EachFieldSettings<int>()
                {
                    FieldName = "Major",
                    Values = new int?[]{ 1, 2, 3 },
                },
                new EachFieldSettings<int>()
                {
                    FieldName = "Minor",
                    Values = new int?[] { 51, 52, 53, 54, 55 },
                },
                new RandomInt32FieldSettings()
                {
                    FieldName = "Number",
                    MinimumValue = 0,
                    MaximumValue = 9999
                }
            };

            generatorSetting.AdditionalFields = new DataGeneratorAdditionalFieldSettings[]
            {
                // Adds field that return the formatted number string.
                new ExpressionFieldSettings()
                {
                    // Specifies the name of the field to be added.
                    FieldName = "FormattedNumber",
                    // Specifies the type of value for the field to add. 
                    ValueType = "System.Int32",
                    // Specifies the selector.
                    Expression = "rec => $\"{rec.GetInt32(\"Major\")}-{rec.GetInt32(\"Minor\")}-{rec.GetInt32(\"Number\"):d4}\""
                }
            };

            // Create a context that controls the behavior of the generator.
            // You can replace random number generation algorithms, string converters, etc. with your own implementation.
            DataGeneratorContext context = new DataGeneratorContext();

            // Creates a builder.
            DataGeneratorBuilder builder = generatorSetting.CreateBuilder(context);

            // Creates a generator that generates 10 records and returns it as a DataReader.
            using IDataReader reader = await builder.BuildAsDataReaderAsync(10);

            Dump(reader);

            string json = JsonConvert.SerializeObject(generatorSetting, s_JsonSerializerSettings);

            System.Diagnostics.Debug.WriteLine(json);
        }

        #endregion

        private void Dump(IDataReader reader)
        {
            for (int i = 0; i < reader.FieldCount; ++i)
            {
                if (i > 0) { Debug.Write('\t'); }
                Debug.Write(reader.GetName(i));
            }
            Debug.WriteLine("");

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; ++i)
                {
                    if (i > 0) { Debug.Write('\t'); }
                    Debug.Write(reader.GetValue(i) ?? "(null)");
                }
                Debug.WriteLine("");
            }
        }

    }

}
