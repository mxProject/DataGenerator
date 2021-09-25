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
using System.ComponentModel.DataAnnotations;

using UnitTestProject1.Extensions;
using UnitTestProject1.SampleValues;

namespace UnitTestProject1
{
    [TestClass]
    public class TestJoin
    {

        #region Dictionary<TKey, TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key1_Value1()
        {
            string keyFieldName = "key";

            DataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.GetValues<int>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey1<int, StringValue>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithDictionary(keyFieldName, additionalField.FieldName!, additionalValues))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                new[] { additionalField },
                additionalValues,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.Cast<StringValue>(values[0])
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
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.GetValues<int>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey1<int, StringValue, DayOfWeek>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithDictionary(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek>(values)
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
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.GetValues<int>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey1<int, StringValue, DayOfWeek, DateTime>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithDictionary(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime>(values)
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
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.GetValues<int>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey1<int, StringValue, DayOfWeek, DateTime, DateTimeOffset>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithDictionary(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset>(values)
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
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.GetValues<int>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey1<int, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithDictionary(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>(values)
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
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double))
            };

            var keyValues = SampleJoinValues.GetValues<int>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey1<int, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithDictionary(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>(values)
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
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal))
            };

            var keyValues = SampleJoinValues.GetValues<int>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey1<int, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithDictionary(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>(values)
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
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char))
            };

            var keyValues = SampleJoinValues.GetValues<int>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey1<int, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithDictionary(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>(values)
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
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.GetValues<int>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey1<int, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithDictionary(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey2<int, StringValue, StringValue>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithDictionaryKey2(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.Cast<StringValue>(values[0])
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
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey2<int, StringValue, StringValue, DayOfWeek>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithDictionaryKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey2<int, StringValue, StringValue, DayOfWeek, DateTime>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithDictionaryKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey2<int, StringValue, StringValue, DayOfWeek, DateTime, DateTimeOffset>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithDictionaryKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey2<int, StringValue, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithDictionaryKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey2<int, StringValue, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithDictionaryKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey2<int, StringValue, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithDictionaryKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey2<int, StringValue, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithDictionaryKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey2<int, StringValue, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithDictionaryKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey3<int, StringValue, double, StringValue>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithDictionaryKey3(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double>(values),
                values => FieldValueConverter.Default.Cast<StringValue>(values[0])
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey3<int, StringValue, double, StringValue, DayOfWeek>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithDictionaryKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey3<int, StringValue, double, StringValue, DayOfWeek, DateTime>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithDictionaryKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey3<int, StringValue, double, StringValue, DayOfWeek, DateTime, DateTimeOffset>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithDictionaryKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey3<int, StringValue, double, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithDictionaryKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey3<int, StringValue, double, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithDictionaryKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey3<int, StringValue, double, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithDictionaryKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey3<int, StringValue, double, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithDictionaryKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey3<int, StringValue, double, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithDictionaryKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey4<int, StringValue, double, decimal, StringValue>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithDictionaryKey4(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal>(values),
                values => FieldValueConverter.Default.Cast<StringValue>(values[0])
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey4<int, StringValue, double, decimal, StringValue, DayOfWeek>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithDictionaryKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey4<int, StringValue, double, decimal, StringValue, DayOfWeek, DateTime>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithDictionaryKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey4<int, StringValue, double, decimal, StringValue, DayOfWeek, DateTime, DateTimeOffset>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithDictionaryKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey4<int, StringValue, double, decimal, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithDictionaryKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey4<int, StringValue, double, decimal, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithDictionaryKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey4<int, StringValue, double, decimal, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithDictionaryKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey4<int, StringValue, double, decimal, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithDictionaryKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey4<int, StringValue, double, decimal, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithDictionaryKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey5<int, StringValue, double, decimal, DateTime, StringValue>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithDictionaryKey5(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime>(values),
                values => FieldValueConverter.Default.Cast<StringValue>(values[0])
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey5<int, StringValue, double, decimal, DateTime, StringValue, DayOfWeek>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithDictionaryKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey5<int, StringValue, double, decimal, DateTime, StringValue, DayOfWeek, DateTime>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithDictionaryKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey5<int, StringValue, double, decimal, DateTime, StringValue, DayOfWeek, DateTime, DateTimeOffset>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithDictionaryKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey5<int, StringValue, double, decimal, DateTime, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithDictionaryKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey5<int, StringValue, double, decimal, DateTime, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithDictionaryKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey5<int, StringValue, double, decimal, DateTime, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithDictionaryKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey5<int, StringValue, double, decimal, DateTime, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithDictionaryKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey5<int, StringValue, double, decimal, DateTime, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithDictionaryKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey6<int, StringValue, double, decimal, DateTime, DateTimeOffset, StringValue>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithDictionaryKey6(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset>(values),
                values => FieldValueConverter.Default.Cast<StringValue>(values[0])
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey6<int, StringValue, double, decimal, DateTime, DateTimeOffset, StringValue, DayOfWeek>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithDictionaryKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey6<int, StringValue, double, decimal, DateTime, DateTimeOffset, StringValue, DayOfWeek, DateTime>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithDictionaryKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey6<int, StringValue, double, decimal, DateTime, DateTimeOffset, StringValue, DayOfWeek, DateTime, DateTimeOffset>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithDictionaryKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey6<int, StringValue, double, decimal, DateTime, DateTimeOffset, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithDictionaryKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey6<int, StringValue, double, decimal, DateTime, DateTimeOffset, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithDictionaryKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey6<int, StringValue, double, decimal, DateTime, DateTimeOffset, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithDictionaryKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey6<int, StringValue, double, decimal, DateTime, DateTimeOffset, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithDictionaryKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>(values)
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
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey6<int, StringValue, double, decimal, DateTime, DateTimeOffset, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithDictionaryKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>(values)
                );
        }

        #endregion


        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key7_Value1()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey7<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, StringValue>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithDictionaryKey7(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values),
                values => FieldValueConverter.Default.Cast<StringValue>(values[0])
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key7_Value2()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey7<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, StringValue, DayOfWeek>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithDictionaryKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key7_Value3()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey7<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, StringValue, DayOfWeek, DateTime>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithDictionaryKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key7_Value4()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey7<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, StringValue, DayOfWeek, DateTime, DateTimeOffset>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithDictionaryKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key7_Value5()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey7<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithDictionaryKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key7_Value6()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey7<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithDictionaryKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key7_Value7()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey7<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithDictionaryKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key7_Value8()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey7<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithDictionaryKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key7_Value9()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey7<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithDictionaryKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>(values)
                );
        }

        #endregion


        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key8_Value1()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey8<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, StringValue>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithDictionaryKey8(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>(values),
                values => FieldValueConverter.Default.Cast<StringValue>(values[0])
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key8_Value2()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey8<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, StringValue, DayOfWeek>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithDictionaryKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key8_Value3()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey8<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, StringValue, DayOfWeek, DateTime>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithDictionaryKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key8_Value4()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey8<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, StringValue, DayOfWeek, DateTime, DateTimeOffset>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithDictionaryKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key8_Value5()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey8<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithDictionaryKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key8_Value6()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey8<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithDictionaryKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key8_Value7()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey8<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithDictionaryKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key8_Value8()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey8<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithDictionaryKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key8_Value9()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey8<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithDictionaryKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>(values)
                );
        }

        #endregion


        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8, Key9), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key9_Value1()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey9<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid, StringValue>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithDictionaryKey9(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>(values),
                values => FieldValueConverter.Default.Cast<StringValue>(values[0])
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8, Key9), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key9_Value2()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey9<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid, StringValue, DayOfWeek>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithDictionaryKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8, Key9), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key9_Value3()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey9<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid, StringValue, DayOfWeek, DateTime>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithDictionaryKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8, Key9), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key9_Value4()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey9<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid, StringValue, DayOfWeek, DateTime, DateTimeOffset>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithDictionaryKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8, Key9), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key9_Value5()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey9<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithDictionaryKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8, Key9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key9_Value6()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey9<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithDictionaryKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8, Key9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key9_Value7()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey9<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithDictionaryKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8, Key9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key9_Value8()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey9<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithDictionaryKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>(values)
                );
        }

        #endregion

        #region Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8, Key9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Dictionary_Key9_Value9()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>();

            var additionalValues = SampleJoinValues.CreateDictionaryKey9<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithDictionaryKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>(values),
                values => FieldValueConverter.Default.ToTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>(values)
                );
        }

        #endregion



        #region nullable Dictionary<TKey, TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key1_Value1()
        {
            string keyFieldName = "key";

            DataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.GetNullableValues<int>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<int, StringValue>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithDictionary(keyFieldName, additionalField.FieldName!, additionalValues))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                new[] { additionalField },
                additionalValues,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.Cast<StringValue?>(values[0])
                );
        }

        #endregion

        #region nullable Dictionary<TKey, (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key1_Value2()
        {
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.GetNullableValues<int>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<int, StringValue, DayOfWeek>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithDictionary(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek>(values)
                );
        }

        #endregion

        #region nullable Dictionary<TKey, (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key1_Value3()
        {
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.GetNullableValues<int>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<int, StringValue, DayOfWeek, DateTime>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithDictionary(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime>(values)
                );
        }

        #endregion

        #region nullable Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key1_Value4()
        {
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.GetNullableValues<int>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<int, StringValue, DayOfWeek, DateTime, DateTimeOffset>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithDictionary(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset>(values)
                );
        }

        #endregion

        #region nullable Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key1_Value5()
        {
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.GetNullableValues<int>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<int, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithDictionary(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>(values)
                );
        }

        #endregion

        #region nullable Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key1_Value6()
        {
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double))
            };

            var keyValues = SampleJoinValues.GetNullableValues<int>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<int, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithDictionary(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>(values)
                );
        }

        #endregion

        #region nullable Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key1_Value7()
        {
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal))
            };

            var keyValues = SampleJoinValues.GetNullableValues<int>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<int, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithDictionary(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>(values)
                );
        }

        #endregion

        #region nullable Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key1_Value8()
        {
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char))
            };

            var keyValues = SampleJoinValues.GetNullableValues<int>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<int, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithDictionary(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>(values)
                );
        }

        #endregion

        #region nullable Dictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key1_Value9()
        {
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.GetNullableValues<int>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<int, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithDictionary(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>(values)
                );
        }

        #endregion


        #region nullable Dictionary<(TKey1, TKey2), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key2_Value1()
        {
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<int, StringValue, StringValue>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithDictionaryKey2(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.Cast<StringValue?>(values[0])
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key2_Value2()
        {
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<int, StringValue, StringValue, DayOfWeek>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithDictionaryKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key2_Value3()
        {
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<int, StringValue, StringValue, DayOfWeek, DateTime>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithDictionaryKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key2_Value4()
        {
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<int, StringValue, StringValue, DayOfWeek, DateTime, DateTimeOffset>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithDictionaryKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key2_Value5()
        {
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<int, StringValue, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithDictionaryKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key2_Value6()
        {
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<int, StringValue, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithDictionaryKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key2_Value7()
        {
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<int, StringValue, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithDictionaryKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key2_Value8()
        {
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<int, StringValue, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithDictionaryKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key2_Value9()
        {
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<int, StringValue, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithDictionaryKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>(values)
                );
        }

        #endregion


        #region nullable Dictionary<(TKey1, TKey2, TKey3), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key3_Value1()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<int, StringValue, double, StringValue>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithDictionaryKey3(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double>(values),
                values => FieldValueConverter.Default.Cast<StringValue?>(values[0])
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key3_Value2()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<int, StringValue, double, StringValue, DayOfWeek>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithDictionaryKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key3_Value3()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<int, StringValue, double, StringValue, DayOfWeek, DateTime>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithDictionaryKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key3_Value4()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<int, StringValue, double, StringValue, DayOfWeek, DateTime, DateTimeOffset>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithDictionaryKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key3_Value5()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<int, StringValue, double, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithDictionaryKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key3_Value6()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<int, StringValue, double, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithDictionaryKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key3_Value7()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<int, StringValue, double, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithDictionaryKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key3_Value8()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<int, StringValue, double, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithDictionaryKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key3_Value9()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<int, StringValue, double, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithDictionaryKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>(values)
                );
        }

        #endregion


        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key4_Value1()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<int, StringValue, double, decimal, StringValue>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithDictionaryKey4(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal>(values),
                values => FieldValueConverter.Default.Cast<StringValue?>(values[0])
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key4_Value2()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<int, StringValue, double, decimal, StringValue, DayOfWeek>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithDictionaryKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key4_Value3()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<int, StringValue, double, decimal, StringValue, DayOfWeek, DateTime>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithDictionaryKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key4_Value4()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<int, StringValue, double, decimal, StringValue, DayOfWeek, DateTime, DateTimeOffset>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithDictionaryKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key4_Value5()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<int, StringValue, double, decimal, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithDictionaryKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key4_Value6()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<int, StringValue, double, decimal, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithDictionaryKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key4_Value7()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<int, StringValue, double, decimal, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithDictionaryKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key4_Value8()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<int, StringValue, double, decimal, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithDictionaryKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key4_Value9()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<int, StringValue, double, decimal, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithDictionaryKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>(values)
                );
        }

        #endregion


        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key5_Value1()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<int, StringValue, double, decimal, DateTime, StringValue>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithDictionaryKey5(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime>(values),
                values => FieldValueConverter.Default.Cast<StringValue?>(values[0])
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key5_Value2()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<int, StringValue, double, decimal, DateTime, StringValue, DayOfWeek>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithDictionaryKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key5_Value3()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<int, StringValue, double, decimal, DateTime, StringValue, DayOfWeek, DateTime>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithDictionaryKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key5_Value4()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<int, StringValue, double, decimal, DateTime, StringValue, DayOfWeek, DateTime, DateTimeOffset>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithDictionaryKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key5_Value5()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<int, StringValue, double, decimal, DateTime, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithDictionaryKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key5_Value6()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<int, StringValue, double, decimal, DateTime, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithDictionaryKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key5_Value7()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<int, StringValue, double, decimal, DateTime, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithDictionaryKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key5_Value8()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<int, StringValue, double, decimal, DateTime, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithDictionaryKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key5_Value9()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<int, StringValue, double, decimal, DateTime, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithDictionaryKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>(values)
                );
        }

        #endregion


        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key6_Value1()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<int, StringValue, double, decimal, DateTime, DateTimeOffset, StringValue>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithDictionaryKey6(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset>(values),
                values => FieldValueConverter.Default.Cast<StringValue?>(values[0])
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key6_Value2()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<int, StringValue, double, decimal, DateTime, DateTimeOffset, StringValue, DayOfWeek>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithDictionaryKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key6_Value3()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<int, StringValue, double, decimal, DateTime, DateTimeOffset, StringValue, DayOfWeek, DateTime>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithDictionaryKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key6_Value4()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<int, StringValue, double, decimal, DateTime, DateTimeOffset, StringValue, DayOfWeek, DateTime, DateTimeOffset>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithDictionaryKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key6_Value5()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<int, StringValue, double, decimal, DateTime, DateTimeOffset, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithDictionaryKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key6_Value6()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<int, StringValue, double, decimal, DateTime, DateTimeOffset, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithDictionaryKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key6_Value7()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<int, StringValue, double, decimal, DateTime, DateTimeOffset, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithDictionaryKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key6_Value8()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<int, StringValue, double, decimal, DateTime, DateTimeOffset, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithDictionaryKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key6_Value9()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<int, StringValue, double, decimal, DateTime, DateTimeOffset, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithDictionaryKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>(values)
                );
        }

        #endregion


        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key7_Value1()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, StringValue>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithDictionaryKey7(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values),
                values => FieldValueConverter.Default.Cast<StringValue?>(values[0])
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key7_Value2()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, StringValue, DayOfWeek>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithDictionaryKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key7_Value3()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, StringValue, DayOfWeek, DateTime>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithDictionaryKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key7_Value4()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, StringValue, DayOfWeek, DateTime, DateTimeOffset>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithDictionaryKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key7_Value5()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithDictionaryKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key7_Value6()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithDictionaryKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key7_Value7()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithDictionaryKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key7_Value8()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithDictionaryKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key7_Value9()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithDictionaryKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>(values)
                );
        }

        #endregion


        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key8_Value1()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, StringValue>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithDictionaryKey8(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>(values),
                values => FieldValueConverter.Default.Cast<StringValue?>(values[0])
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key8_Value2()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, StringValue, DayOfWeek>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithDictionaryKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key8_Value3()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, StringValue, DayOfWeek, DateTime>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithDictionaryKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key8_Value4()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, StringValue, DayOfWeek, DateTime, DateTimeOffset>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithDictionaryKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key8_Value5()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithDictionaryKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key8_Value6()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithDictionaryKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key8_Value7()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithDictionaryKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key8_Value8()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithDictionaryKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key8_Value9()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithDictionaryKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>(values)
                );
        }

        #endregion


        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8, Key9), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key9_Value1()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid, StringValue>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithDictionaryKey9(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>(values),
                values => FieldValueConverter.Default.Cast<StringValue?>(values[0])
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8, Key9), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key9_Value2()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid, StringValue, DayOfWeek>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithDictionaryKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8, Key9), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key9_Value3()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid, StringValue, DayOfWeek, DateTime>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithDictionaryKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8, Key9), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key9_Value4()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid, StringValue, DayOfWeek, DateTime, DateTimeOffset>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithDictionaryKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8, Key9), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key9_Value5()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithDictionaryKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8, Key9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key9_Value6()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithDictionaryKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8, Key9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key9_Value7()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithDictionaryKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8, Key9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key9_Value8()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithDictionaryKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char>(values)
                );
        }

        #endregion

        #region nullable Dictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, Key7, Key8, Key9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task NullableDictionary_Key9_Value9()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(DateTime)),
                new DataGeneratorFieldInfo("value4", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value5", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value6", typeof(double)),
                new DataGeneratorFieldInfo("value7", typeof(decimal)),
                new DataGeneratorFieldInfo("value8", typeof(char)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid, StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>();

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithDictionaryKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, double, decimal, DateTime, DateTimeOffset, TimeSpan, char, Guid>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, DateTime, DateTimeOffset, TimeSpan, double, decimal, char, Guid>(values)
                );
        }

        #endregion



        #region Lookup<TKey, TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key1_Value1()
        {
            string keyFieldName = "key";

            DataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.GetNullableValues<int>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<int, StringValue>().ToLookup(x => x.Key);

            static StringValue? selector(KeyValuePair<int, StringValue?> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithLookup(keyFieldName, additionalField.FieldName!, additionalValues, selector))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                new[] { additionalField },
                additionalValues,
                selector,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.Cast<StringValue?>(values[0])
                );
        }

        #endregion

        #region Lookup<TKey, (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key1_Value2()
        {
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.GetNullableValues<int>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<int, StringValue, DayOfWeek>().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?) selector(KeyValuePair<int, (StringValue?, DayOfWeek?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithLookup(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek>(values)
                );

        }

        #endregion

        #region Lookup<TKey, (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key1_Value3()
        {
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char))
            };

            var keyValues = SampleJoinValues.GetNullableValues<int>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<int, StringValue, DayOfWeek, char>().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?) selector(KeyValuePair<int, (StringValue?, DayOfWeek?, char?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithLookup(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char>(values)
                );

        }

        #endregion

        #region Lookup<TKey, (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key1_Value4()
        {
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double))
            };

            var keyValues = SampleJoinValues.GetNullableValues<int>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<int, StringValue, DayOfWeek, char, double>().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?) selector(KeyValuePair<int, (StringValue?, DayOfWeek?, char?, double?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithLookup(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double>(values)
                );

        }

        #endregion

        #region Lookup<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key1_Value5()
        {
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal))
            };

            var keyValues = SampleJoinValues.GetNullableValues<int>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<int, StringValue, DayOfWeek, char, double, decimal>().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?) selector(KeyValuePair<int, (StringValue?, DayOfWeek?, char?, double?, decimal?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithLookup(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal>(values)
                );

        }

        #endregion

        #region Lookup<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key1_Value6()
        {
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.GetNullableValues<int>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<int, StringValue, DayOfWeek, char, double, decimal, DateTime>().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?) selector(KeyValuePair<int, (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithLookup(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime>(values)
                );

        }

        #endregion

        #region Lookup<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key1_Value7()
        {
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.GetNullableValues<int>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<int, StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset>().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?) selector(KeyValuePair<int, (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithLookup(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset>(values)
                );

        }

        #endregion

        #region Lookup<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key1_Value8()
        {
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value8", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.GetNullableValues<int>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<int, StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan>().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?) selector(KeyValuePair<int, (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithLookup(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values)
                );

        }

        #endregion

        #region Lookup<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key1_Value9()
        {
            string keyFieldName = "key";

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value8", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.GetNullableValues<int>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey1<int, StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid>().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?, Guid?) selector(KeyValuePair<int, (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?, Guid?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddField(f => f.Each(keyFieldName, keyValues))
                .AddJoinField(f => f.WithLookup(
                    keyFieldName,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                new[] { keyFieldName },
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.Cast<int>(values[0]),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid>(values)
                );

        }

        #endregion



        #region Lookup<(TKey1, TKey2), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key2_Value1()
        {
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<int, StringValue, StringValue>().ToLookup(x => x.Key);

            static StringValue? selector(KeyValuePair<(int?, StringValue?), StringValue?> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithLookupKey2(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.Cast<StringValue?>(values[0])
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key2_Value2()
        {
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<int, StringValue, StringValue, DayOfWeek>().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?) selector(KeyValuePair<(int?, StringValue?), (StringValue?, DayOfWeek?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithLookupKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key2_Value3()
        {
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<int, StringValue, StringValue, DayOfWeek, char>().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?) selector(KeyValuePair<(int?, StringValue?), (StringValue?, DayOfWeek?, char?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithLookupKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key2_Value4()
        {
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<int, StringValue, StringValue, DayOfWeek, char, double>().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?) selector(KeyValuePair<(int?, StringValue?), (StringValue?, DayOfWeek?, char?, double?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithLookupKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key2_Value5()
        {
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<int, StringValue, StringValue, DayOfWeek, char, double, decimal>().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?) selector(KeyValuePair<(int?, StringValue?), (StringValue?, DayOfWeek?, char?, double?, decimal?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithLookupKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key2_Value6()
        {
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<int, StringValue, StringValue, DayOfWeek, char, double, decimal, DateTime>().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?) selector(KeyValuePair<(int?, StringValue?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithLookupKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key2_Value7()
        {
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<int, StringValue, StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset>().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?) selector(KeyValuePair<(int?, StringValue?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithLookupKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key2_Value8()
        {
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value8", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<int, StringValue, StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan>().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?) selector(KeyValuePair<(int?, StringValue?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithLookupKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key2_Value9()
        {
            string[] keyFieldNames = new[] { "key1", "key2" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value8", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey2<int, StringValue, StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid>().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?, Guid?) selector(KeyValuePair<(int?, StringValue?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?, Guid?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyValues))
                .AddJoinField(f => f.WithLookupKey2(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid>(values)
                );
        }

        #endregion



        #region Lookup<(TKey1, TKey2, TKey3), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key3_Value1()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<
                int, StringValue, TimeSpan,
                StringValue
                >().ToLookup(x => x.Key);

            static StringValue? selector(KeyValuePair<(int?, StringValue?, TimeSpan?), StringValue?> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithLookupKey3(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan>(values),
                values => FieldValueConverter.Default.Cast<StringValue?>(values[0])
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key3_Value2()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<
                int, StringValue, TimeSpan,
                StringValue, DayOfWeek
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?), (StringValue?, DayOfWeek?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithLookupKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key3_Value3()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<
                int, StringValue, TimeSpan,
                StringValue, DayOfWeek, char
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?), (StringValue?, DayOfWeek?, char?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithLookupKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key3_Value4()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<
                int, StringValue, TimeSpan,
                StringValue, DayOfWeek, char, double
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?), (StringValue?, DayOfWeek?, char?, double?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithLookupKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key3_Value5()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<
                int, StringValue, TimeSpan,
                StringValue, DayOfWeek, char, double, decimal
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?), (StringValue?, DayOfWeek?, char?, double?, decimal?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithLookupKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key3_Value6()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<
                int, StringValue, TimeSpan,
                StringValue, DayOfWeek, char, double, decimal, DateTime
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithLookupKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key3_Value7()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<
                int, StringValue, TimeSpan,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithLookupKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key3_Value8()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value8", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<
                int, StringValue, TimeSpan,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithLookupKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key3_Value9()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value8", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey3<
                int, StringValue, TimeSpan,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?, Guid?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?, Guid?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyValues))
                .AddJoinField(f => f.WithLookupKey3(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid>(values)
                );
        }

        #endregion



        #region Lookup<(TKey1, TKey2, TKey3, TKey4), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key4_Value1()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<
                int, StringValue, TimeSpan, DateTimeOffset,
                StringValue
                >().ToLookup(x => x.Key);

            static StringValue? selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?), StringValue?> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithLookupKey4(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset>(values),
                values => FieldValueConverter.Default.Cast<StringValue?>(values[0])
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key4_Value2()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<
                int, StringValue, TimeSpan, DateTimeOffset,
                StringValue, DayOfWeek
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?), (StringValue?, DayOfWeek?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithLookupKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key4_Value3()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<
                int, StringValue, TimeSpan, DateTimeOffset,
                StringValue, DayOfWeek, char
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?), (StringValue?, DayOfWeek?, char?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithLookupKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key4_Value4()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<
                int, StringValue, TimeSpan, DateTimeOffset,
                StringValue, DayOfWeek, char, double
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?), (StringValue?, DayOfWeek?, char?, double?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithLookupKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key4_Value5()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<
                int, StringValue, TimeSpan, DateTimeOffset,
                StringValue, DayOfWeek, char, double, decimal
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?), (StringValue?, DayOfWeek?, char?, double?, decimal?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithLookupKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key4_Value6()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<
                int, StringValue, TimeSpan, DateTimeOffset,
                StringValue, DayOfWeek, char, double, decimal, DateTime
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithLookupKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key4_Value7()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<
                int, StringValue, TimeSpan, DateTimeOffset,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithLookupKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key4_Value8()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value8", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<
                int, StringValue, TimeSpan, DateTimeOffset,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithLookupKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key4_Value9()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value8", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey4<
                int, StringValue, TimeSpan, DateTimeOffset,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?, Guid?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?, Guid?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyValues))
                .AddJoinField(f => f.WithLookupKey4(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid>(values)
                );
        }

        #endregion



        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key5_Value1()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime,
                StringValue
                >().ToLookup(x => x.Key);

            static StringValue? selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?), StringValue?> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithLookupKey5(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime>(values),
                values => FieldValueConverter.Default.Cast<StringValue?>(values[0])
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key5_Value2()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime,
                StringValue, DayOfWeek
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?), (StringValue?, DayOfWeek?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithLookupKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key5_Value3()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime,
                StringValue, DayOfWeek, char
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?), (StringValue?, DayOfWeek?, char?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithLookupKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key5_Value4()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime,
                StringValue, DayOfWeek, char, double
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?), (StringValue?, DayOfWeek?, char?, double?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithLookupKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key5_Value5()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime,
                StringValue, DayOfWeek, char, double, decimal
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?), (StringValue?, DayOfWeek?, char?, double?, decimal?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithLookupKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key5_Value6()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime,
                StringValue, DayOfWeek, char, double, decimal, DateTime
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithLookupKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key5_Value7()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithLookupKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key5_Value8()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value8", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithLookupKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key5_Value9()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value8", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey5<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?, Guid?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?, Guid?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyValues))
                .AddJoinField(f => f.WithLookupKey5(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid>(values)
                );
        }

        #endregion



        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key6_Value1()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal,
                StringValue
                >().ToLookup(x => x.Key);

            static StringValue? selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?), StringValue?> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithLookupKey6(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal>(values),
                values => FieldValueConverter.Default.Cast<StringValue?>(values[0])
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key6_Value2()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal,
                StringValue, DayOfWeek
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?), (StringValue?, DayOfWeek?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithLookupKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key6_Value3()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal,
                StringValue, DayOfWeek, char
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?), (StringValue?, DayOfWeek?, char?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithLookupKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key6_Value4()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal,
                StringValue, DayOfWeek, char, double
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?), (StringValue?, DayOfWeek?, char?, double?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithLookupKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key6_Value5()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal,
                StringValue, DayOfWeek, char, double, decimal
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?), (StringValue?, DayOfWeek?, char?, double?, decimal?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithLookupKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key6_Value6()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal,
                StringValue, DayOfWeek, char, double, decimal, DateTime
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithLookupKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key6_Value7()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithLookupKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key6_Value8()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value8", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithLookupKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key6_Value9()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value8", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey6<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?, Guid?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?, Guid?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyValues))
                .AddJoinField(f => f.WithLookupKey6(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid>(values)
                );
        }

        #endregion



        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key7_Value1()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double,
                StringValue
                >().ToLookup(x => x.Key);

            static StringValue? selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?), StringValue?> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithLookupKey7(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double>(values),
                values => FieldValueConverter.Default.Cast<StringValue?>(values[0])
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key7_Value2()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double,
                StringValue, DayOfWeek
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?), (StringValue?, DayOfWeek?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithLookupKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key7_Value3()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double,
                StringValue, DayOfWeek, char
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?), (StringValue?, DayOfWeek?, char?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithLookupKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key7_Value4()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double,
                StringValue, DayOfWeek, char, double
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?), (StringValue?, DayOfWeek?, char?, double?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithLookupKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key7_Value5()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double,
                StringValue, DayOfWeek, char, double, decimal
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?), (StringValue?, DayOfWeek?, char?, double?, decimal?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithLookupKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key7_Value6()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double,
                StringValue, DayOfWeek, char, double, decimal, DateTime
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithLookupKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key7_Value7()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithLookupKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key7_Value8()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value8", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithLookupKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key7_Value9()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value8", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey7<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?, Guid?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?, Guid?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyValues))
                .AddJoinField(f => f.WithLookupKey7(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid>(values)
                );
        }

        #endregion



        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7. TKey8), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key8_Value1()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char,
                StringValue
                >().ToLookup(x => x.Key);

            static StringValue? selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?, char?), StringValue?> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithLookupKey8(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char>(values),
                values => FieldValueConverter.Default.Cast<StringValue?>(values[0])
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7. TKey8), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key8_Value2()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char,
                StringValue, DayOfWeek
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?, char?), (StringValue?, DayOfWeek?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithLookupKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7. TKey8), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key8_Value3()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char,
                StringValue, DayOfWeek, char
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?, char?), (StringValue?, DayOfWeek?, char?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithLookupKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7. TKey8), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key8_Value4()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char,
                StringValue, DayOfWeek, char, double
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?, char?), (StringValue?, DayOfWeek?, char?, double?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithLookupKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7. TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key8_Value5()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char,
                StringValue, DayOfWeek, char, double, decimal
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?, char?), (StringValue?, DayOfWeek?, char?, double?, decimal?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithLookupKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7. TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key8_Value6()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char,
                StringValue, DayOfWeek, char, double, decimal, DateTime
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?, char?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithLookupKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7. TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key8_Value7()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?, char?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithLookupKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7. TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key8_Value8()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value8", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?, char?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithLookupKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7. TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key8_Value9()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value8", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey8<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?, Guid?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?, char?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?, Guid?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyValues))
                .AddJoinField(f => f.WithLookupKey8(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid>(values)
                );
        }

        #endregion



        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7. TKey8, TKey9), TValue>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key9_Value1()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo additionalField = new DataGeneratorFieldInfo("value", typeof(string));

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid,
                StringValue
                >().ToLookup(x => x.Key);

            static StringValue? selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?, char?, Guid?), StringValue?> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithLookupKey9(
                    keyFieldNames,
                    additionalField.FieldName!,
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                new[] { additionalField },
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid>(values),
                values => FieldValueConverter.Default.Cast<StringValue?>(values[0])
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7. TKey8, TKey9), (TValue1, TValue2)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key9_Value2()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid,
                StringValue, DayOfWeek
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?, char?, Guid?), (StringValue?, DayOfWeek?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithLookupKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7. TKey8, TKey9), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key9_Value3()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid,
                StringValue, DayOfWeek, char
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?, char?, Guid?), (StringValue?, DayOfWeek?, char?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithLookupKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7. TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key9_Value4()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid,
                StringValue, DayOfWeek, char, double
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?, char?, Guid?), (StringValue?, DayOfWeek?, char?, double?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithLookupKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7. TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key9_Value5()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid,
                StringValue, DayOfWeek, char, double, decimal
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?, char?, Guid?), (StringValue?, DayOfWeek?, char?, double?, decimal?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithLookupKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7. TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key9_Value6()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid,
                StringValue, DayOfWeek, char, double, decimal, DateTime
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?, char?, Guid?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithLookupKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7. TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key9_Value7()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?, char?, Guid?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithLookupKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7. TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key9_Value8()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value8", typeof(TimeSpan))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?, char?, Guid?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithLookupKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan>(values)
                );
        }

        #endregion

        #region Lookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7. TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Lookup_Key9_Value9()
        {
            string[] keyFieldNames = new[] { "key1", "key2", "key3", "key4", "key5", "key6", "key7", "key8", "key9" };

            IDataGeneratorFieldInfo[] additionalFields = new[]
            {
                new DataGeneratorFieldInfo("value1", typeof(string)),
                new DataGeneratorFieldInfo("value2", typeof(DayOfWeek)),
                new DataGeneratorFieldInfo("value3", typeof(char)),
                new DataGeneratorFieldInfo("value4", typeof(double)),
                new DataGeneratorFieldInfo("value5", typeof(decimal)),
                new DataGeneratorFieldInfo("value6", typeof(DateTime)),
                new DataGeneratorFieldInfo("value7", typeof(DateTimeOffset)),
                new DataGeneratorFieldInfo("value8", typeof(TimeSpan)),
                new DataGeneratorFieldInfo("value9", typeof(Guid))
            };

            var keyValues = SampleJoinValues.CreateNullableKeyValues<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid>();

            var additionalValues = SampleJoinValues.CreateNullableDictionaryKey9<
                int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid,
                StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid
                >().ToLookup(x => x.Key);

            static (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?, Guid?) selector(KeyValuePair<(int?, StringValue?, TimeSpan?, DateTimeOffset?, DateTime?, decimal?, double?, char?, Guid?), (StringValue?, DayOfWeek?, char?, double?, decimal?, DateTime?, DateTimeOffset?, TimeSpan?, Guid?)> x) => x.Value;

            DataGeneratorBuilder builder = new DataGeneratorBuilder()
                .AddTupleField(f => f.EachTuple(keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8], keyValues))
                .AddJoinField(f => f.WithLookupKey9(
                    keyFieldNames,
                    new[]
                    {
                        additionalFields[0].FieldName,
                        additionalFields[1].FieldName,
                        additionalFields[2].FieldName,
                        additionalFields[3].FieldName,
                        additionalFields[4].FieldName,
                        additionalFields[5].FieldName,
                        additionalFields[6].FieldName,
                        additionalFields[7].FieldName,
                        additionalFields[8].FieldName
                    },
                    additionalValues,
                    selector
                    ))
                ;

            int generateCount = keyValues.Count();

            using var reader = await builder.BuildAsDataReaderAsync(generateCount);

            AssertRecordsCore(
                reader,
                generateCount,
                keyFieldNames,
                additionalFields,
                additionalValues,
                selector,
                values => FieldValueConverter.Default.ToNullableTuple<int, StringValue, TimeSpan, DateTimeOffset, DateTime, decimal, double, char, Guid>(values),
                values => FieldValueConverter.Default.ToNullableTuple<StringValue, DayOfWeek, char, double, decimal, DateTime, DateTimeOffset, TimeSpan, Guid>(values)
                );
        }

        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKeys"></typeparam>
        /// <typeparam name="TValues"></typeparam>
        /// <param name="reader"></param>
        /// <param name="expectedCount"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="additionalFields"></param>
        /// <param name="additionalValues"></param>
        /// <param name="keyConverter"></param>
        /// <param name="valueConverter"></param>
        static void AssertRecordsCore<TKeys, TValues>(IDataReader reader, int expectedCount, string[] keyFieldNames, IDataGeneratorFieldInfo[] additionalFields, IDictionary<TKeys, TValues> additionalValues, Func<object?[], TKeys> keyConverter, Func<object?[], TValues> valueConverter)
            where TKeys : notnull
        {
            int count = 0;

            StringBuilder sb = new();

            try
            {
                TestUtility.DumpHeader(reader, sb);

                object?[] keys = new object?[keyFieldNames.Length];
                object?[] values = new object?[additionalFields.Length];

                while (reader.Read())
                {
                    TestUtility.DumpRecord(reader, sb);

                    for (int i = 0; i < keyFieldNames.Length; ++i)
                    {
                        keys[i] = reader.GetValue(keyFieldNames[i]);
                    }

                    for (int i = 0; i < additionalFields.Length; ++i)
                    {
                        values[i] = reader.GetValue(additionalFields[i].FieldName);
                    }

                    if (additionalValues.TryGetValue(keyConverter(keys), out var found))
                    {
                        Assert.AreEqual(found, valueConverter(values));
                    }
                    else
                    {
                        for (int i = 0; i < values.Length; ++i)
                        {
                            Assert.IsNull(values[0]);
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

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKeys"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <typeparam name="TValues"></typeparam>
        /// <param name="reader"></param>
        /// <param name="expectedCount"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="additionalFields"></param>
        /// <param name="additionalValues"></param>
        /// <param name="selector"></param>
        /// <param name="keyConverter"></param>
        /// <param name="valueConverter"></param>
        static void AssertRecordsCore<TKeys, TElement, TValues>(IDataReader reader, int expectedCount, string[] keyFieldNames, IDataGeneratorFieldInfo[] additionalFields, ILookup<TKeys, TElement> additionalValues, Func<TElement, TValues> selector, Func<object?[], TKeys> keyConverter, Func<object?[], TValues> valueConverter)
        {
            int count = 0;

            StringBuilder sb = new();

            static bool TryFirst(ILookup<TKeys, TElement> lookup, TKeys key, out TElement found)
            {
                foreach (var element in lookup[key])
                {
                    found = element;
                    return true;
                }

                found = default!;
                return false;
            }

            try
            {
                TestUtility.DumpHeader(reader, sb);

                object?[] keys = new object?[keyFieldNames.Length];
                object?[] values = new object?[additionalFields.Length];

                while (reader.Read())
                {
                    TestUtility.DumpRecord(reader, sb);

                    for (int i = 0; i < keyFieldNames.Length; ++i)
                    {
                        keys[i] = reader.GetValue(keyFieldNames[i]);
                    }

                    for (int i = 0; i < additionalFields.Length; ++i)
                    {
                        values[i] = reader.GetValue(additionalFields[i].FieldName);
                    }

                    if (TryFirst(additionalValues, keyConverter(keys), out var found))
                    {
                        Assert.AreEqual(selector(found), valueConverter(values));
                    }
                    else
                    {
                        for (int i = 0; i < values.Length; ++i)
                        {
                            Assert.IsNull(values[0]);
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
