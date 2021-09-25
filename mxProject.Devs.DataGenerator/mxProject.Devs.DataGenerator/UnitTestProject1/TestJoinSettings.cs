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
using mxProject.Devs.DataGeneration.Configuration.Json;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

using UnitTestProject1.Extensions;
using UnitTestProject1.SampleValues;

namespace UnitTestProject1
{

    [TestClass]
    public class TestJoinSettings
    {

        [ClassInitialize]
        public static void Init(TestContext _)
        {
            s_JsonSerializerSettings = TestUtility.CreateJsonSerializerSettings();
        }

        private static JsonSerializerSettings s_JsonSerializerSettings = null!;

        #region Dictionary<TKey, TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key1_Value1()
        {

            DataGeneratorFieldInfo keyField = new DataGeneratorFieldInfo("key", typeof(int));
            DataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keys = SampleJoinValues.GetNullableValues<int>().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<
                int,
                StringValue
                >().ToStringDictionary();

            EachFieldSettings<int> keySettings = new EachFieldSettings<int>()
            {
                FieldName = keyField.FieldName,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = new[] { additionalField },
                KeyFields = new[] { keyField },
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                Fields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore<string>(
                reader,
                generateCount,
                new[] { keyField },
                new[] { additionalField },
                additionalValues.ConvertKeyToString(),
                StringArrayExtensions.ConvertToString!
                );

        }

        #endregion

        #region Dictionary<TKey, (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key1_Value2()
        {

            DataGeneratorFieldInfo keyField = new DataGeneratorFieldInfo("key", typeof(int));
            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keys = SampleJoinValues.GetNullableValues<int>().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<
                int,
                StringValue, DayOfWeek
                >().ToStringDictionary();

            EachFieldSettings<int> keySettings = new EachFieldSettings<int>()
            {
                FieldName = keyField.FieldName,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = new[] { keyField },
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                Fields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore<string>(
                reader,
                generateCount,
                new[] { keyField },
                additionalFields,
                additionalValues.ConvertKeyToString(),
                StringArrayExtensions.ConvertToString!
                );

        }

        #endregion

        #region Dictionary<TKey, (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key1_Value3()
        {

            DataGeneratorFieldInfo keyField = new DataGeneratorFieldInfo("key", typeof(int));
            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double))
            };

            var keys = SampleJoinValues.GetNullableValues<int>().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<
                int,
                StringValue, DayOfWeek, double
                >().ToStringDictionary();

            EachFieldSettings<int> keySettings = new EachFieldSettings<int>()
            {
                FieldName = keyField.FieldName,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = new[] { keyField },
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                Fields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore<string>(
                reader,
                generateCount,
                new[] { keyField },
                additionalFields,
                additionalValues.ConvertKeyToString(),
                StringArrayExtensions.ConvertToString!
                );

        }

        #endregion

        #region Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key1_Value4()
        {

            DataGeneratorFieldInfo keyField = new DataGeneratorFieldInfo("key", typeof(int));
            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal))
            };

            var keys = SampleJoinValues.GetNullableValues<int>().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<
                int,
                StringValue, DayOfWeek, double, decimal
                >().ToStringDictionary();

            EachFieldSettings<int> keySettings = new EachFieldSettings<int>()
            {
                FieldName = keyField.FieldName,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = new[] { keyField },
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                Fields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore<string>(
                reader,
                generateCount,
                new[] { keyField },
                additionalFields,
                additionalValues.ConvertKeyToString(),
                StringArrayExtensions.ConvertToString!
                );

        }

        #endregion

        #region Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key1_Value5()
        {

            DataGeneratorFieldInfo keyField = new DataGeneratorFieldInfo("key", typeof(int));
            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime))
            };

            var keys = SampleJoinValues.GetNullableValues<int>().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<
                int,
                StringValue, DayOfWeek, double, decimal, DateTime
                >().ToStringDictionary();

            EachFieldSettings<int> keySettings = new EachFieldSettings<int>()
            {
                FieldName = keyField.FieldName,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = new[] { keyField },
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                Fields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore<string>(
                reader,
                generateCount,
                new[] { keyField },
                additionalFields,
                additionalValues.ConvertKeyToString(),
                StringArrayExtensions.ConvertToString!
                );

        }

        #endregion

        #region Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key1_Value6()
        {

            DataGeneratorFieldInfo keyField = new DataGeneratorFieldInfo("key", typeof(int));
            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset))
            };

            var keys = SampleJoinValues.GetNullableValues<int>().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<
                int,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset
                >().ToStringDictionary();

            EachFieldSettings<int> keySettings = new EachFieldSettings<int>()
            {
                FieldName = keyField.FieldName,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = new[] { keyField },
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                Fields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore<string>(
                reader,
                generateCount,
                new[] { keyField },
                additionalFields,
                additionalValues.ConvertKeyToString(),
                StringArrayExtensions.ConvertToString!
                );

        }

        #endregion

        #region Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key1_Value7()
        {

            DataGeneratorFieldInfo keyField = new DataGeneratorFieldInfo("key", typeof(int));
            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan))
            };

            var keys = SampleJoinValues.GetNullableValues<int>().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<
                int,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan
                >().ToStringDictionary();

            EachFieldSettings<int> keySettings = new EachFieldSettings<int>()
            {
                FieldName = keyField.FieldName,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = new[] { keyField },
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                Fields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore<string>(
                reader,
                generateCount,
                new[] { keyField },
                additionalFields,
                additionalValues.ConvertKeyToString(),
                StringArrayExtensions.ConvertToString!
                );

        }

        #endregion

        #region Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key1_Value8()
        {

            DataGeneratorFieldInfo keyField = new DataGeneratorFieldInfo("key", typeof(int));
            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value8", typeof(Guid))
            };

            var keys = SampleJoinValues.GetNullableValues<int>().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<
                int,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid
                >().ToStringDictionary();

            EachFieldSettings<int> keySettings = new EachFieldSettings<int>()
            {
                FieldName = keyField.FieldName,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = new[] { keyField },
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                Fields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore<string>(
                reader,
                generateCount,
                new[] { keyField },
                additionalFields,
                additionalValues.ConvertKeyToString(),
                StringArrayExtensions.ConvertToString!
                );

        }

        #endregion

        #region Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key1_Value9()
        {

            DataGeneratorFieldInfo keyField = new DataGeneratorFieldInfo("key", typeof(int));
            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value8", typeof(Guid)),
                new DataGeneratorFieldInfo("value9", typeof(char))
            };

            var keys = SampleJoinValues.GetNullableValues<int>().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<
                int,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid, char
                >().ToStringDictionary();

            EachFieldSettings<int> keySettings = new EachFieldSettings<int>()
            {
                FieldName = keyField.FieldName,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = new[] { keyField },
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                Fields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore<string>(
                reader,
                generateCount,
                new[] { keyField },
                additionalFields,
                additionalValues.ConvertKeyToString(),
                StringArrayExtensions.ConvertToString!
                );

        }

        #endregion

        
        #region Dictionary<(TKey1, TKey2), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key2_Value1()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value", typeof(string))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<
                int, StringValue,
                StringValue
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple2(),
                StringArrayExtensions.ConvertToTuple2
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key2_Value2()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<
                int, StringValue
                , StringValue, DayOfWeek
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple2(),
                StringArrayExtensions.ConvertToTuple2
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key2_Value3()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<
                int, StringValue,
                StringValue, DayOfWeek, double
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple2(),
                StringArrayExtensions.ConvertToTuple2
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key2_Value4()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<
                int, StringValue,
                StringValue, DayOfWeek, double, decimal
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple2(),
                StringArrayExtensions.ConvertToTuple2
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key2_Value5()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<
                int, StringValue,
                StringValue, DayOfWeek, double, decimal, DateTime
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple2(),
                StringArrayExtensions.ConvertToTuple2
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key2_Value6()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<
                int, StringValue,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple2(),
                StringArrayExtensions.ConvertToTuple2
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key2_Value7()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<
                int, StringValue,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple2(),
                StringArrayExtensions.ConvertToTuple2
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key2_Value8()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value8", typeof(Guid))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<
                int, StringValue,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple2(),
                StringArrayExtensions.ConvertToTuple2
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key2_Value9()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value8", typeof(Guid)),
                new DataGeneratorFieldInfo("value9", typeof(char))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<
                int, StringValue,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid, char
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple2(),
                StringArrayExtensions.ConvertToTuple2
                );

        }

        #endregion


        #region Dictionary<(TKey1, TKey2, TKey3), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key3_Value1()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value", typeof(string))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<
                int, StringValue, DateTime,
                StringValue
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple3(),
                StringArrayExtensions.ConvertToTuple3
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key3_Value2()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<
                int, StringValue, DateTime,
                StringValue, DayOfWeek
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple3(),
                StringArrayExtensions.ConvertToTuple3
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key3_Value3()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<
                int, StringValue, DateTime,
                StringValue, DayOfWeek, double
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple3(),
                StringArrayExtensions.ConvertToTuple3
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key3_Value4()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<
                int, StringValue, DateTime,
                StringValue, DayOfWeek, double, decimal
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple3(),
                StringArrayExtensions.ConvertToTuple3
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key3_Value5()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<
                int, StringValue, DateTime,
                StringValue, DayOfWeek, double, decimal, DateTime
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple3(),
                StringArrayExtensions.ConvertToTuple3
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key3_Value6()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<
                int, StringValue, DateTime,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple3(),
                StringArrayExtensions.ConvertToTuple3
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key3_Value7()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<
                int, StringValue, DateTime,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple3(),
                StringArrayExtensions.ConvertToTuple3
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key3_Value8()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value8", typeof(Guid))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<
                int, StringValue, DateTime,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple3(),
                StringArrayExtensions.ConvertToTuple3
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key3_Value9()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value8", typeof(Guid)),
                new DataGeneratorFieldInfo("value9", typeof(char))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<
                int, StringValue, DateTime,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid, char
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple3(),
                StringArrayExtensions.ConvertToTuple3
                );

        }

        #endregion


        #region Dictionary<(TKey1, TKey2, TKey3, TKey4), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key4_Value1()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value", typeof(string))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<
                int, StringValue, DateTime, DateTimeOffset,
                StringValue
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple4(),
                StringArrayExtensions.ConvertToTuple4
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key4_Value2()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<
                int, StringValue, DateTime, DateTimeOffset,
                StringValue, DayOfWeek
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple4(),
                StringArrayExtensions.ConvertToTuple4
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key4_Value3()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<
                int, StringValue, DateTime, DateTimeOffset,
                StringValue, DayOfWeek, double
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple4(),
                StringArrayExtensions.ConvertToTuple4
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key4_Value4()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<
                int, StringValue, DateTime, DateTimeOffset,
                StringValue, DayOfWeek, double, decimal
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple4(),
                StringArrayExtensions.ConvertToTuple4
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key4_Value5()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<
                int, StringValue, DateTime, DateTimeOffset,
                StringValue, DayOfWeek, double, decimal, DateTime
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple4(),
                StringArrayExtensions.ConvertToTuple4
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key4_Value6()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<
                int, StringValue, DateTime, DateTimeOffset,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple4(),
                StringArrayExtensions.ConvertToTuple4
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key4_Value7()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<
                int, StringValue, DateTime, DateTimeOffset,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple4(),
                StringArrayExtensions.ConvertToTuple4
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key4_Value8()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value8", typeof(Guid))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<
                int, StringValue, DateTime, DateTimeOffset,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple4(),
                StringArrayExtensions.ConvertToTuple4
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key4_Value9()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value8", typeof(Guid)),
                new DataGeneratorFieldInfo("value9", typeof(char))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<
                int, StringValue, DateTime, DateTimeOffset,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid, char
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple4(),
                StringArrayExtensions.ConvertToTuple4
                );

        }

        #endregion

        
        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key5_Value1()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value", typeof(string))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek,
                StringValue
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple5(),
                StringArrayExtensions.ConvertToTuple5
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key5_Value2()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek,
                StringValue, DayOfWeek
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple5(),
                StringArrayExtensions.ConvertToTuple5
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key5_Value3()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek,
                StringValue, DayOfWeek, double
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple5(),
                StringArrayExtensions.ConvertToTuple5
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key5_Value4()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek,
                StringValue, DayOfWeek, double, decimal
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple5(),
                StringArrayExtensions.ConvertToTuple5
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key5_Value5()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek,
                StringValue, DayOfWeek, double, decimal, DateTime
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple5(),
                StringArrayExtensions.ConvertToTuple5
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key5_Value6()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple5(),
                StringArrayExtensions.ConvertToTuple5
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key5_Value7()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple5(),
                StringArrayExtensions.ConvertToTuple5
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key5_Value8()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value8", typeof(Guid))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple5(),
                StringArrayExtensions.ConvertToTuple5
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key5_Value9()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value8", typeof(Guid)),
                new DataGeneratorFieldInfo("value9", typeof(char))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid, char
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple5(),
                StringArrayExtensions.ConvertToTuple5
                );

        }

        #endregion


        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key6_Value1()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value", typeof(string))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double,
                StringValue
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple6(),
                StringArrayExtensions.ConvertToTuple6
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key6_Value2()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double,
                StringValue, DayOfWeek
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple6(),
                StringArrayExtensions.ConvertToTuple6
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key6_Value3()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double,
                StringValue, DayOfWeek, double
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple6(),
                StringArrayExtensions.ConvertToTuple6
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key6_Value4()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double,
                StringValue, DayOfWeek, double, decimal
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple6(),
                StringArrayExtensions.ConvertToTuple6
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key6_Value5()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double,
                StringValue, DayOfWeek, double, decimal, DateTime
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple6(),
                StringArrayExtensions.ConvertToTuple6
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key6_Value6()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple6(),
                StringArrayExtensions.ConvertToTuple6
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key6_Value7()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple6(),
                StringArrayExtensions.ConvertToTuple6
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key6_Value8()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value8", typeof(Guid))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple6(),
                StringArrayExtensions.ConvertToTuple6
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key6_Value9()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value8", typeof(Guid)),
                new DataGeneratorFieldInfo("value9", typeof(char))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid, char
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple6(),
                StringArrayExtensions.ConvertToTuple6
                );

        }

        #endregion


        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key7_Value1()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value", typeof(string))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal,
                StringValue
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple7(),
                StringArrayExtensions.ConvertToTuple7
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key7_Value2()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal,
                StringValue, DayOfWeek
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple7(),
                StringArrayExtensions.ConvertToTuple7
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key7_Value3()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal,
                StringValue, DayOfWeek, double
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple7(),
                StringArrayExtensions.ConvertToTuple7
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key7_Value4()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal,
                StringValue, DayOfWeek, double, decimal
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple7(),
                StringArrayExtensions.ConvertToTuple7
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key7_Value5()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal,
                StringValue, DayOfWeek, double, decimal, DateTime
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple7(),
                StringArrayExtensions.ConvertToTuple7
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key7_Value6()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple7(),
                StringArrayExtensions.ConvertToTuple7
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key7_Value7()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple7(),
                StringArrayExtensions.ConvertToTuple7
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key7_Value8()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value8", typeof(Guid))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple7(),
                StringArrayExtensions.ConvertToTuple7
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key7_Value9()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(double)),
                new DataGeneratorFieldInfo("value4", typeof(decimal)),
                new DataGeneratorFieldInfo("value5", typeof(DateTime)),
                new DataGeneratorFieldInfo("value6", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value7", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value8", typeof(Guid)),
                new DataGeneratorFieldInfo("value9", typeof(char))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal,
                StringValue, DayOfWeek, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid, char
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple7(),
                StringArrayExtensions.ConvertToTuple7
                );

        }

        #endregion


        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key8_Value1()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal)),
                new DataGeneratorFieldInfo("key8", typeof(TimeSpan))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value", typeof(string))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan,
                StringValue
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple8(),
                StringArrayExtensions.ConvertToTuple8
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key8_Value2()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal)),
                new DataGeneratorFieldInfo("key8", typeof(TimeSpan))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan,
                StringValue, DayOfWeek
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple8(),
                StringArrayExtensions.ConvertToTuple8
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key8_Value3()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal)),
                new DataGeneratorFieldInfo("key8", typeof(TimeSpan))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan,
                StringValue, DayOfWeek, DateTime
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple8(),
                StringArrayExtensions.ConvertToTuple8
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key8_Value4()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal)),
                new DataGeneratorFieldInfo("key8", typeof(TimeSpan))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan,
                StringValue, DayOfWeek, DateTime, DateTimeOffset
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple8(),
                StringArrayExtensions.ConvertToTuple8
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key8_Value5()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal)),
                new DataGeneratorFieldInfo("key8", typeof(TimeSpan))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan,
                StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple8(),
                StringArrayExtensions.ConvertToTuple8
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key8_Value6()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal)),
                new DataGeneratorFieldInfo("key8", typeof(TimeSpan))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan,
                StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple8(),
                StringArrayExtensions.ConvertToTuple8
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key8_Value7()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal)),
                new DataGeneratorFieldInfo("key8", typeof(TimeSpan))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan,
                StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple8(),
                StringArrayExtensions.ConvertToTuple8
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key8_Value8()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal)),
                new DataGeneratorFieldInfo("key8", typeof(TimeSpan))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(Guid))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan,
                StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, Guid
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple8(),
                StringArrayExtensions.ConvertToTuple8
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key8_Value9()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal)),
                new DataGeneratorFieldInfo("key8", typeof(TimeSpan))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(Guid)),
                new DataGeneratorFieldInfo("value9", typeof(char))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan,
                StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, Guid, char
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple8(),
                StringArrayExtensions.ConvertToTuple8
                );

        }

        #endregion


        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key9_Value1()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal)),
                new DataGeneratorFieldInfo("key8", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("key9", typeof(char))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value", typeof(string))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan, char>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan, char,
                StringValue
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple9(),
                StringArrayExtensions.ConvertToTuple9
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key9_Value2()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal)),
                new DataGeneratorFieldInfo("key8", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("key9", typeof(char))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan, char>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan, char,
                StringValue, DayOfWeek
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple9(),
                StringArrayExtensions.ConvertToTuple9
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key9_Value3()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal)),
                new DataGeneratorFieldInfo("key8", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("key9", typeof(char))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan, char>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan, char,
                StringValue, DayOfWeek, DateTime
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple9(),
                StringArrayExtensions.ConvertToTuple9
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key9_Value4()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal)),
                new DataGeneratorFieldInfo("key8", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("key9", typeof(char))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan, char>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan, char,
                StringValue, DayOfWeek, DateTime, DateTimeOffset
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple9(),
                StringArrayExtensions.ConvertToTuple9
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key9_Value5()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal)),
                new DataGeneratorFieldInfo("key8", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("key9", typeof(char))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan, char>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan, char,
                StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple9(),
                StringArrayExtensions.ConvertToTuple9
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key9_Value6()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal)),
                new DataGeneratorFieldInfo("key8", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("key9", typeof(char))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan, char>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan, char,
                StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple9(),
                StringArrayExtensions.ConvertToTuple9
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key9_Value7()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal)),
                new DataGeneratorFieldInfo("key8", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("key9", typeof(char))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan, char>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan, char,
                StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple9(),
                StringArrayExtensions.ConvertToTuple9
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key9_Value8()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal)),
                new DataGeneratorFieldInfo("key8", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("key9", typeof(char))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(Guid))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan, char>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan, char,
                StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, Guid
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple9(),
                StringArrayExtensions.ConvertToTuple9
                );

        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key9_Value9()
        {

            DataGeneratorFieldInfo[] keyFields = new[]
            {
                new DataGeneratorFieldInfo("key1", typeof(int)),
                new DataGeneratorFieldInfo("key2", typeof(string)),
                new DataGeneratorFieldInfo("key3", typeof(DateTime)),
                new DataGeneratorFieldInfo("key4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("key5", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("key6", typeof(double)),
                new DataGeneratorFieldInfo("key7", typeof(decimal)),
                new DataGeneratorFieldInfo("key8", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("key9", typeof(char))
            };

            DataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(Guid)),
                new DataGeneratorFieldInfo("value9", typeof(char))
            };

            var keys = SampleJoinValues.CreateNullableKeyValues<int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan, char>().ToStringArrayList().ToArray();
            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<
                int, StringValue, DateTime, DateTimeOffset, DayOfWeek, double, decimal, TimeSpan, char,
                StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, Guid, char
                >().ToStringDictionary();

            EachTupleFieldSettings keySettings = new EachTupleFieldSettings()
            {
                Fields = keyFields,
                Values = keys
            };

            JoinFieldSettings joinSettings = new JoinFieldSettings()
            {
                AdditionalFields = additionalFields,
                KeyFields = keyFields,
                AdditionalValues = additionalValues
            };

            DataGeneratorSettings settings = new DataGeneratorSettings()
            {
                TupleFields = new[]
                {
                    keySettings
                },
                AdditionalTupleFields = new[]
                {
                    joinSettings
                }
            };

            string json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;

            DataGeneratorContext context = new();

            int generateCount = keys.Length;

            using var reader = await settings.CreateBuilder(context).BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFields,
                additionalFields,
                additionalValues.ConvertKeyToTuple9(),
                StringArrayExtensions.ConvertToTuple9
                );

        }

        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TKeys"></typeparam>
        /// <typeparam name="TValues"></typeparam>
        /// <param name="reader"></param>
        /// <param name="expectedCount"></param>
        /// <param name="keyFields"></param>
        /// <param name="additionalFields"></param>
        /// <param name="additionalValues"></param>
        /// <param name="keyConverter"></param>
        internal static void AssertRecordsCore<TKey>(IDataReader reader, int expectedCount, IDataGeneratorFieldInfo[] keyFields, IDataGeneratorFieldInfo[] additionalFields, IDictionary<TKey, string?[]> additionalValues, Func<string?[], TKey> keyConverter)
            where TKey : notnull
        {
            int count = 0;

            StringBuilder sb = new();

            static string? ConvertToString(object? value)
            {
                return value?.ToString();
            }

            try
            {
                TestUtility.DumpHeader(reader, sb);

                string?[] keys = new string?[keyFields.Length];
                string?[] values = new string?[additionalFields.Length];

                while (reader.Read())
                {
                    TestUtility.DumpRecord(reader, sb);

                    for (int i = 0; i < keyFields.Length; ++i)
                    {
                        keys[i] = ConvertToString(reader.GetValue(keyFields[i].FieldName));
                    }

                    for (int i = 0; i < additionalFields.Length; ++i)
                    {
                        values[i] = ConvertToString(reader.GetValue(additionalFields[i].FieldName));
                    }

                    var key = keyConverter(keys);

                    if (key is not null && additionalValues.TryGetValue(key, out var found))
                    {
                        for (int i = 0; i < values.Length; ++i)
                        {
                            Assert.AreEqual(found[i] ?? "", values[i] ?? "");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < values.Length; ++i)
                        {
                            Assert.IsNull(values[i], $"Actual: {values[i]}");
                        }
                    }

                    ++count;
                }

                Assert.AreEqual(expectedCount, count);
            }
            finally
            {
                Console.WriteLine(sb.ToString());
            }
        }



    }

}
