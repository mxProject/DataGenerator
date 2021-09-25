using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Data;
using System.Linq;
using System.Reflection;
using mxProject.Devs.DataGeneration;
using mxProject.Devs.DataGeneration.ModelMappings;
using mxProject.Devs.DataGeneration.ModelMappings.Fields;

using UnitTestProject1.Extensions;

namespace UnitTestProject1
{

    [Obsolete]
    [TestClass]
    public class TestModelMappings
    {

        #region Each

        [TestMethod]
        public Task Each()
        {
            return GenerateAsync<SampleEachModel>(50);
        }

        internal class SampleEachModel : SampleModelBase
        {

            [EachField(new[] { true, true, true, false }, 0.1)]
            public bool? BooleanField { get; set; }

            [DirectProductField("tuple1", 0)]
            [EachField(new byte[] { 1, 2 }, nullProbability: 0.1)]
            public byte? ByteField { get; set; }

            [EachField(new sbyte[] { 1, 2 }, nullProbability: 0.1)]
            public sbyte? SByteField { get; set; }

            [DirectProductField("tuple1", 1)]
            [EachField(new short[] { 10, 20, 30 }, 0.1)]
            public short? Int16Field { get; set; }

            [EachField(new ushort[] { 10, 20, 30 }, 0.1)]
            public ushort? UInt16Field { get; set; }

            [EachField(new[] { 100, 200, 300, 400 })]
            public int Int32Field { get; set; }

            [EachField(new uint[] { 100, 200, 300, 400 })]
            public uint UInt32Field { get; set; }

            [EachField(new[] { "100", "200", "300", "400", null }, 0.1)]
            public int? Int32OrNullField { get; set; }

            [EachField(new long[] { 1000, 2000, 3000, 4000, 5000 }, 0.1)]
            public long? Int64Field { get; set; }

            [EachField(new ulong[] { 1000, 2000, 3000, 4000, 5000 }, 0.1)]
            public ulong? UInt64Field { get; set; }

            [DirectProductField("tuple2", 0)]
            [EachField(new[] { 1.1f, 2.2f }, 0.1)]
            public float? SingleField { get; set; }

            [DirectProductField("tuple2", 1)]
            [EachField(new[] { 1.11, 2.22, 3.33 }, 0.1)]
            public double? DoubleField { get; set; }

            [DirectProductField("tuple2", 3)]
            [EachField(new[] { 1.111, 2.222, 3.333, 4.444 }, 0.1)]
            public decimal? DecimalField { get; set; }

            [EachField(typeof(DateTime), new string?[] { "2021/01/01", "2021/01/02", "2021/01/02 03:04:05", null }, 0.1)]
            public DateTime? DateTimeField { get; set; }

            [EachField(typeof(DateTimeOffset), new string?[] { "2021/01/01", "2021/01/02 03:04:05", "2021/01/02 03:04:05+09:00", "2021/01/02 03:04:05+12:00", null }, 0.1)]
            public DateTimeOffset? DateTimeOffsetField { get; set; }

            [EachField(typeof(TimeSpan), new string?[] { "01:02:03", "1.02:03:04", null }, 0.1)]
            public TimeSpan? TimeSpanField { get; set; }

            [EachField(new char[] { 'a', 'b', 'c' }, 0.1)]
            public char? CharField { get; set; }

            [EachField(new string[] { "aaa", "bbb", "ccc", "ddd" }, 0.1)]
            public string? StringField { get; set; }

            //[AdditionField(new[] { nameof(AdditionalStringField), nameof(AdditionalDateTimeField) }, typeof(SampleEachModel), nameof(GetAdditionalValues))]
            [EachGuidField(new string?[] { "{FA2D5E66-47E6-4F64-90D3-FC4E37CF60DD}", "{6F19DC21-A4E2-4320-8B6F-B5E3D4E80497}", "{36C61468-2C08-45A0-8499-485EA4778E78}", null }, 0.1)]
            public Guid? GuidField { get; set; }

            [EachEnumField(typeof(DayOfWeek), new[] { nameof(DayOfWeek.Monday), nameof(DayOfWeek.Friday), nameof(DayOfWeek.Sunday), "" }, 0.1)]
            public DayOfWeek? DayOfWeekField { get; set; }

            [EachEnumField(typeof(DayOfWeek), 0.1)]
            public DayOfWeek? AllDayOfWeekField { get; set; }



            public string? AdditionalStringField { get; set; }

            public DateTime? AdditionalDateTimeField { get; set; }


            //private static IDictionary<object, object[]> GetAdditionalValues(DataGeneratorContext _)
            //{
            //    var dic = new Dictionary<object, object[]>
            //{
            //    { Guid.Parse("{FA2D5E66-47E6-4F64-90D3-FC4E37CF60DD}"), new object[] { "today", DateTime.Today } },
            //    { Guid.Parse("{36C61468-2C08-45A0-8499-485EA4778E78}"), new object[] { "tommorow", DateTime.Today.AddDays(1) } }
            //};

            //    return dic;
            //}

        }

        #endregion

        #region Any

        [TestMethod]
        public Task Any()
        {
            return GenerateAsync<SampleAnyModel>(50);
        }

        internal class SampleAnyModel : SampleModelBase
        {

            [AnyField(new[] { true, true, true, false }, 0.1)]
            public bool? BooleanField { get; set; }

            [DirectProductField("tuple1", 0)]
            [AnyField(new byte[] { 1, 2 }, nullProbability: 0.1)]
            public byte? ByteField { get; set; }

            [AnyField(new sbyte[] { 1, 2 }, nullProbability: 0.1)]
            public sbyte? SByteField { get; set; }

            [DirectProductField("tuple1", 1)]
            [AnyField(new short[] { 10, 20, 30 }, 0.1)]
            public short? Int16Field { get; set; }

            [AnyField(new ushort[] { 10, 20, 30 }, 0.1)]
            public ushort? UInt16Field { get; set; }

            [AnyField(new[] { 100, 200, 300, 400 })]
            public int Int32Field { get; set; }

            [AnyField(new uint[] { 100, 200, 300, 400 })]
            public uint UInt32Field { get; set; }

            [AnyField(new[] { "100", "200", "300", "400", null }, 0.1)]
            public int? Int32OrNullField { get; set; }

            [AnyField(new long[] { 1000, 2000, 3000, 4000, 5000 }, 0.1)]
            public long? Int64Field { get; set; }

            [AnyField(new ulong[] { 1000, 2000, 3000, 4000, 5000 }, 0.1)]
            public ulong? UInt64Field { get; set; }

            [DirectProductField("tuple2", 0)]
            [AnyField(new[] { 1.1f, 2.2f }, 0.1)]
            public float? SingleField { get; set; }

            [DirectProductField("tuple2", 1)]
            [AnyField(new[] { 1.11, 2.22, 3.33 }, 0.1)]
            public double? DoubleField { get; set; }

            [DirectProductField("tuple2", 3)]
            [AnyField(new[] { 1.111, 2.222, 3.333, 4.444 }, 0.1)]
            public decimal? DecimalField { get; set; }

            [AnyField(typeof(DateTime), new string?[] { "2021/01/01", "2021/01/02", "2021/01/02 03:04:05", null }, 0.1)]
            public DateTime? DateTimeField { get; set; }

            [AnyField(typeof(DateTimeOffset), new string?[] { "2021/01/01", "2021/01/02 03:04:05", "2021/01/02 03:04:05+09:00", "2021/01/02 03:04:05+12:00", null }, 0.1)]
            public DateTimeOffset? DateTimeOffsetField { get; set; }

            [AnyField(typeof(TimeSpan), new string?[] { "01:02:03", "1.02:03:04", null }, 0.1)]
            public TimeSpan? TimeSpanField { get; set; }

            [AnyField(new char[] { 'a', 'b', 'c' }, 0.1)]
            public char? CharField { get; set; }

            [AnyField(new string[] { "aaa", "bbb", "ccc", "ddd" }, 0.1)]
            public string? StringField { get; set; }

            //[AdditionField(new[] { nameof(AdditionalStringField), nameof(AdditionalDateTimeField) }, typeof(SampleAnyModel), nameof(GetAdditionalValues))]
            [AnyGuidField(new string?[] { "{FA2D5E66-47E6-4F64-90D3-FC4E37CF60DD}", "{6F19DC21-A4E2-4320-8B6F-B5E3D4E80497}", "{36C61468-2C08-45A0-8499-485EA4778E78}", null }, 0.1)]
            public Guid? GuidField { get; set; }

            [AnyEnumField(typeof(DayOfWeek), new[] { nameof(DayOfWeek.Monday), nameof(DayOfWeek.Friday), nameof(DayOfWeek.Sunday), "" }, 0.1)]
            public DayOfWeek? DayOfWeekField { get; set; }

            [AnyEnumField(typeof(DayOfWeek), 0.1)]
            public DayOfWeek? AllDayOfWeekField { get; set; }



            public string? AdditionalStringField { get; set; }

            public DateTime? AdditionalDateTimeField { get; set; }


            //private static IDictionary<object, object[]> GetAdditionalValues(DataGeneratorContext _)
            //{
            //    var dic = new Dictionary<object, object[]>
            //{
            //    { Guid.Parse("{FA2D5E66-47E6-4F64-90D3-FC4E37CF60DD}"), new object[] { "today", DateTime.Today } },
            //    { Guid.Parse("{36C61468-2C08-45A0-8499-485EA4778E78}"), new object[] { "tommorow", DateTime.Today.AddDays(1) } }
            //};

            //    return dic;
            //}

        }

        #endregion


        [TestMethod]
        public Task Random()
        {
            return GenerateAsync<SampleRandomModel>(50);
        }

        internal class SampleRandomModel : SampleModelBase
        {
            [RandomBooleanField(trueProbability: 0.5, nullProbability: 0.1)]
            public bool? BooleanField { get; set; }

            [RandomByteField(0, 100, nullProbability: 0.1)]
            public byte? ByteField { get; set; }

            [RandomSByteField(0, 100, nullProbability: 0.1)]
            public sbyte? SByteField { get; set; }

            [RandomInt16Field(-100, 100, nullProbability: 0.1)]
            public short? Int16Field { get; set; }

            [RandomUInt16Field(10, 100, nullProbability: 0.1)]
            public ushort? UInt16Field { get; set; }

            [RandomInt32Field(-100, 100, nullProbability: 0.1)]
            public int? Int32Field { get; set; }

            [RandomUInt32Field(10, 100, nullProbability: 0.1)]
            public uint? UInt32Field { get; set; }

            [RandomInt64Field(-100, 100, nullProbability: 0.1)]
            public long? Int64Field { get; set; }

            [RandomUInt64Field(10, 100, nullProbability: 0.1)]
            public ulong? UInt64Field { get; set; }

            [RandomSingleField(-100, 100, nullProbability: 0.1)]
            public float? SingleField { get; set; }

            [RandomDoubleField(-100, 100, nullProbability: 0.1)]
            public double? DoubleField { get; set; }

            [RandomDecimalField(-100, 100, nullProbability: 0.1, selectorDecralingType: typeof(SampleRandomModel), selectorMethodName: nameof(RoundDecimal))]
            public decimal? DecimalField { get; set; }

            private static decimal RoundDecimal(decimal value)
            {
                return Math.Round(value, 2);
            }

            [RandomDateTimeField("2021/06/01", "2021/06/30", nullProbability: 0.1, selectorDecralingType: typeof(SampleRandomModel), selectorMethodName: nameof(TrimDateTime))]
            public DateTime? DateTimeField { get; set; }

            private static DateTime TrimDateTime(DateTime value)
            {
                return value.Date;
            }

            [RandomDateTimeOffsetField("2021/06/01", "2021/06/30", nullProbability: 0.1)]
            public DateTimeOffset? DateTimeFieldOffset { get; set; }

            [RandomTimeSpanField("00:00:00", "2.00:00:00", nullProbability: 0.1, selectorDecralingType: typeof(SampleRandomModel), selectorMethodName: nameof(TrimTimeSpan))]
            public TimeSpan? TimeSpanField { get; set; }

            private static TimeSpan TrimTimeSpan(TimeSpan value)
            {
                return TimeSpan.FromMilliseconds(Math.Round(value.TotalSeconds));
            }

            [RandomGuidField(nullProbability: 0.1)]
            public Guid? GuidField { get; set; }

        }


        [TestMethod]
        public Task Sequence()
        {
            return GenerateAsync<SampleSequenceModel>(50);
        }

        internal class SampleSequenceModel : SampleModelBase
        {

            [SequenceByteField(1, 30, increment: 2, nullProbability: 0.1)]
            public byte? ByteField { get; set; }

            [SequenceSByteField(1, 30, increment: 2, nullProbability: 0.1)]
            public sbyte? SByteField { get; set; }

            [SequenceInt16Field(1, 30, increment: 3, nullProbability: 0.1)]
            public short? Int16Field { get; set; }

            [SequenceUInt16Field(1, 30, increment: 3, nullProbability: 0.1)]
            public ushort? UInt16Field { get; set; }

            [SequenceInt32Field(1, 30, increment: 4, nullProbability: 0.1)]
            public int? Int32Field { get; set; }

            [SequenceUInt32Field(1, 30, increment: 4, nullProbability: 0.1)]
            public uint? UInt32Field { get; set; }

            [SequenceInt64Field(1, 30, increment: 5, nullProbability: 0.1)]
            public long? Int64Field { get; set; }

            [SequenceUInt64Field(1, 30, increment: 5, nullProbability: 0.1)]
            public ulong? UInt64Field { get; set; }

            [SequenceDateTimeField("2021/06/01 12:00:00", "2021/06/03 12:00:00", increment: "01:00:00", nullProbability: 0.1)]
            public DateTime? DateTimeField { get; set; }

            [SequenceDateMonthField("2021/01/20 12:00:00", "2021/12/20 12:00:00", months: 1, nullProbability: 0.1)]
            public DateTime? DateMonthField { get; set; }

            [SequenceDateTimeField("2021/06/01 12:00:00", "2021/06/03 12:00:00", increment: "02:00:00", nullProbability: 0.1)]
            public DateTimeOffset? DateTimeOffsetField { get; set; }

            [SequenceDateMonthOffsetField("2021/01/20 12:00:00", "2021/12/20 12:00:00", months: 1, nullProbability: 0.1)]
            public DateTimeOffset? DateMonthFieldOffset { get; set; }

            [SequenceTimeSpanField("00:00:00", "2.00:00:00", increment: "01:30:00", nullProbability: 0.1)]
            public TimeSpan? TimeSpanField { get; set; }


            [DirectProductField("DirectProduct1", 0)]
            [SequenceByteField(1, 5)]
            public byte? DirectProductByteField { get; set; }

            [DirectProductField("DirectProduct1", 1)]
            [SequenceInt16Field(1, 8)]
            public short? DirectProductInt16Field { get; set; }


            [DirectProductField("DirectProduct2", 0)]
            [SequenceDateTimeField("2021/06/01 00:00:00", "2021/06/01 23:59:59", increment: "02:00:00")]
            public DateTime? DirectProductDateTimeField { get; set; }

            [DirectProductField("DirectProduct2", 1)]
            [SequenceDateTimeField("2021/06/01 00:00:00", "2021/06/01 23:59:59", increment: "04:00:00")]
            public DateTimeOffset? DirectProductDateTimeOffsetField { get; set; }

            [DirectProductField("DirectProduct2", 2)]
            [SequenceTimeSpanField("00:00:00", "00:59:59", increment: "00:15:00")]
            public TimeSpan? DirectProductTimeSpanField { get; set; }

        }

        [TestMethod]
        public Task Addition_Coverage()
        {
            return GenerateAsync<CoverageAdditionModel>(50);
        }

        [TestMethod]
        public Task Addition_Sample()
        {
            return GenerateAsync<SampleAdditionModel>(50);
        }

        internal class SampleAdditionModel
        {

            // 単一のキーに一つのフィールドを付加して列挙するフィールド
            //[AdditionField(new[] { nameof(Field1_Value) }, typeof(SampleAdditionModel), nameof(GetAdditionalValues1))]
            [SequenceInt32Field(1, 4)]
            public int Field1_Key { get; set; }

            public string? Field1_Value { get; set; }

            //private static IDictionary<object, object> GetAdditionalValues1(DataGeneratorContext _)
            //{
            //    return new Dictionary<object, object>() 
            //    {
            //        { 1, "A" },
            //        { 3, "C" },
            //        { 5, "E" }
            //    };
            //}

            // 単一のキーに一つ以上のフィールドを付加して列挙するフィールド
            //[AdditionField(new[] { nameof(Field2_Value1), nameof(Field2_Value2) }, typeof(SampleAdditionModel), nameof(GetAdditionalValues2))]
            [SequenceInt32Field(1, 4)]
            public int Field2_Key { get; set; }

            public string? Field2_Value1 { get; set; }

            public DayOfWeek? Field2_Value2 { get; set; }

            //private static IDictionary<object, object[]> GetAdditionalValues2(DataGeneratorContext _)
            //{
            //    return new Dictionary<object, object[]>()
            //    {
            //        { 1, new object[]{ "A", DayOfWeek.Monday } },
            //        { 2, new object[]{ "B", DayOfWeek.Tuesday } },
            //        { 3, new object[]{ "C", DayOfWeek.Wednesday } }
            //    };
            //}

            // 複数のキーに一つ以上のフィールドを付加して列挙するフィールド
            //[AdditionField(new[] { nameof(Field3_Value1), nameof(Field3_Value2) }, typeof(SampleAdditionModel), nameof(GetAdditionalValues3))]
            [DirectProductField("field3", 0)]
            [SequenceInt32Field(1, 3)]
            public int Field3_Key1 { get; set; }

            [DirectProductField("field3", 1)]
            [SequenceDateTimeField("2021/06/01", "2021/06/10", "1.00:00:00")]
            public int Field3_Key2 { get; set; }

            public string? Field3_Value1 { get; set; }

            public long? Field3_Value2 { get; set; }

            //private static IDictionary<object[], object[]> GetAdditionalValues3(DataGeneratorContext _)
            //{
            //    return new Dictionary<object[], object[]>()
            //    {
            //        { new object[] { 1, new DateTime(2021, 6, 1) }, new object[]{ "A", (long)10000 } },
            //        { new object[] { 2, new DateTime(2021, 6, 2) }, new object[]{ "B", (long)20000 } },
            //        { new object[] { 3, new DateTime(2021, 6, 3) }, new object[]{ "C", (long)30000 } }
            //    };
            //}
        }

        internal class CoverageAdditionModel
        {

            #region IDictionary<object, object>

            //[AdditionField(new[] { nameof(Object_Object_Value) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_Object_Object))]
            [EachField(new string[] { "a", "b", "c" })]
            public string? Object_Object_Key { get; set; }

            public bool Object_Object_Value { get; set; }

            //private static IDictionary<object, object> GetAppendValues_Object_Object(DataGeneratorContext _)
            //{
            //    Dictionary<object, object> dic = new Dictionary<object, object>
            //{
            //    { "a", true },
            //    { "b", false }
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<object, object[1]>

            //[AdditionField(new[] { nameof(Object_Object1_Value1) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_Object_Object1))]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? Object_Object1_Key { get; set; }

            public string? Object_Object1_Value1 { get; set; }

            //private static IDictionary<object, object[]> GetAppendValues_Object_Object1(DataGeneratorContext _)
            //{
            //    Dictionary<object, object[]> dic = new Dictionary<object, object[]>
            //{
            //    { 1, new object[] { "one" } },
            //    { 2, new object[] { "two" } },
            //    { 3, new object[] { "three" } }
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<object, object[2]>

            //[AdditionField(new[] { nameof(Object_Object2_Value1), nameof(Object_Object2_Value2) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_Object_Object2))]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? Object_Object2_Key { get; set; }

            public string? Object_Object2_Value1 { get; set; }

            public DateTime? Object_Object2_Value2 { get; set; }

            //private static IDictionary<object, object[]> GetAppendValues_Object_Object2(DataGeneratorContext _)
            //{
            //    Dictionary<object, object[]> dic = new Dictionary<object, object[]>
            //{
            //    { 1, new object[] { "now", DateTime.Now } },
            //    { 2, new object[] { "today", DateTime.Today } },
            //    { 3, new object[] { "yesterday", DateTime.Today.AddDays(-1) } }
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<object, object[3]>

            //[AdditionField(new[] { nameof(Object_Object3_Value1), nameof(Object_Object3_Value2), nameof(Object_Object3_Value3) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_Object_Object3))]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? Object_Object3_Key { get; set; }

            public string? Object_Object3_Value1 { get; set; }

            public DateTime? Object_Object3_Value2 { get; set; }

            public decimal? Object_Object3_Value3 { get; set; }

            //private static IDictionary<object, object[]> GetAppendValues_Object_Object3(DataGeneratorContext _)
            //{
            //    Dictionary<object, object[]> dic = new Dictionary<object, object[]>
            //{
            //    { 1, new object[] { "now", DateTime.Now, 111.1m } },
            //    { 2, new object[] { "today", DateTime.Today, 222.2m } },
            //    { 3, new object[] { "yesterday", DateTime.Today.AddDays(-1), null! } }
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<object, object[4]>

            //[AdditionField(new[] { nameof(Object_Object4_Value1), nameof(Object_Object4_Value2), nameof(Object_Object4_Value3), nameof(Object_Object4_Value4) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_Object_Object4))]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? Object_Object4_Key { get; set; }

            public string? Object_Object4_Value1 { get; set; }

            public DateTime? Object_Object4_Value2 { get; set; }

            public decimal? Object_Object4_Value3 { get; set; }

            public bool? Object_Object4_Value4 { get; set; }

            //private static IDictionary<object, object[]> GetAppendValues_Object_Object4(DataGeneratorContext _)
            //{
            //    Dictionary<object, object[]> dic = new Dictionary<object, object[]>
            //{
            //    { 1, new object[] { "now", DateTime.Now, 111.1m, true } },
            //    { 2, new object[] { "today", DateTime.Today, 222.2m, false } },
            //    { 3, new object[] { "yesterday", DateTime.Today.AddDays(-1), null!, true } }
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<string, string>

            //[AdditionField(new[] { nameof(String_String_Value) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_String_String))]
            [EachField(new string[] { "a", "b", "c" })]
            public string? String_String_Key { get; set; }

            public bool String_String_Value { get; set; }

            //private static IDictionary<string, string> GetAppendValues_String_String(DataGeneratorContext _)
            //{
            //    Dictionary<string, string> dic = new Dictionary<string, string>
            //{
            //    { "a", "true" },
            //    { "b", "false" }
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<string, string[1]>

            //[AdditionField(new[] { nameof(String_String1_Value1) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_String_String1))]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? String_String1_Key { get; set; }

            public string? String_String1_Value1 { get; set; }

            //private static IDictionary<string, string[]> GetAppendValues_String_String1(DataGeneratorContext _)
            //{
            //    Dictionary<string, string[]> dic = new Dictionary<string, string[]>
            //{
            //    { "1", new string[] { "one" } },
            //    { "2", new string[] { "two" } },
            //    { "3", new string[] { "three" } }
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<string, string[2]>

            //[AdditionField(new[] { nameof(String_String2_Value1), nameof(String_String2_Value2) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_String_String2))]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? String_String2_Key { get; set; }

            public string? String_String2_Value1 { get; set; }

            public DateTime? String_String2_Value2 { get; set; }

            //private static IDictionary<string, string[]> GetAppendValues_String_String2(DataGeneratorContext _)
            //{
            //    Dictionary<string, string[]> dic = new Dictionary<string, string[]>
            //{
            //    { "1", new string[] { "now", DateTime.Now.ToString() } },
            //    { "2", new string[] { "today", DateTime.Today.ToString() } },
            //    { "3", new string[] { "yesterday", DateTime.Today.AddDays(-1).ToString() } }
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<string, string[3]>

            //[AdditionField(new[] { nameof(String_String3_Value1), nameof(String_String3_Value2), nameof(String_String3_Value3) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_String_String3))]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? String_String3_Key { get; set; }

            public string? String_String3_Value1 { get; set; }

            public DateTime? String_String3_Value2 { get; set; }

            public decimal? String_String3_Value3 { get; set; }

            //private static IDictionary<string, string[]> GetAppendValues_String_String3(DataGeneratorContext _)
            //{
            //    Dictionary<string, string[]> dic = new Dictionary<string, string[]>
            //{
            //    { "1", new string[] { "now", DateTime.Now.ToString(), "111.1" } },
            //    { "2", new string[] { "today", DateTime.Today.ToString(), "222.2" } },
            //    { "3", new string[] { "yesterday", DateTime.Today.AddDays(-1).ToString(), null! } }
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<string, string[4]>

            //[AdditionField(new[] { nameof(String_String4_Value1), nameof(String_String4_Value2), nameof(String_String4_Value3), nameof(String_String4_Value4) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_String_String4))]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? String_String4_Key { get; set; }

            public string? String_String4_Value1 { get; set; }

            public DateTime? String_String4_Value2 { get; set; }

            public decimal? String_String4_Value3 { get; set; }

            public bool? String_String4_Value4 { get; set; }

            //private static IDictionary<string, string[]> GetAppendValues_String_String4(DataGeneratorContext _)
            //{
            //    Dictionary<string, string[]> dic = new Dictionary<string, string[]>
            //{
            //    { "1", new string[] { "now", DateTime.Now.ToString(), "111.1", "true" } },
            //    { "2", new string[] { "today", DateTime.Today.ToString(), "222.2", "false" } },
            //    { "3", new string[] { "yesterday", DateTime.Today.AddDays(-1).ToString(), null!, "true" } }
            //};

            //    return dic;
            //}

            #endregion



            #region IDictionary<object[1], object>

            //[AdditionField(new[] { nameof(Object1_Object_Value) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_Object1_Object))]
            [EachField(new string[] { "a", "b", "c" })]
            public string? Object1_Object_Key1 { get; set; }

            public bool Object1_Object_Value { get; set; }

            //private static IDictionary<object[], object> GetAppendValues_Object1_Object(DataGeneratorContext _)
            //{
            //    Dictionary<object[], object> dic = new Dictionary<object[], object>
            //{
            //    { new object[]{ "a" }, true },
            //    { new object[]{ "b" }, false }
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<object[1], object[1]>

            //[AdditionField(new[] { nameof(Object1_Object1_Value1) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_Object1_Object1))]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? Object1_Object1_Key1 { get; set; }

            public string? Object1_Object1_Value1 { get; set; }

            //private static IDictionary<object[], object[]> GetAppendValues_Object1_Object1(DataGeneratorContext _)
            //{
            //    Dictionary<object[], object[]> dic = new Dictionary<object[], object[]>
            //{
            //    { new object[] { 1 }, new object[] { "one" } },
            //    { new object[] { 2 }, new object[] { "two" } },
            //    { new object[] { 3 }, new object[] { "three" } }
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<object[1], object[2]>

            //[AdditionField(new[] { nameof(Object1_Object2_Value1), nameof(Object1_Object2_Value2) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_Object1_Object2))]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? Object1_Object2_Key1 { get; set; }

            public string? Object1_Object2_Value1 { get; set; }

            public DateTime? Object1_Object2_Value2 { get; set; }

            //private static IDictionary<object[], object[]> GetAppendValues_Object1_Object2(DataGeneratorContext _)
            //{
            //    Dictionary<object[], object[]> dic = new Dictionary<object[], object[]>
            //{
            //    { new object[] { 1 }, new object[] { "now", DateTime.Now } },
            //    { new object[] { 2 }, new object[] { "today", DateTime.Today } },
            //    { new object[] { 3 }, new object[] { "yesterday", DateTime.Today.AddDays(-1) } }
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<object[1], object[3]>

            //[AdditionField(new[] { nameof(Object1_Object3_Value1), nameof(Object1_Object3_Value2), nameof(Object1_Object3_Value3) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_Object1_Object3))]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? Object1_Object3_Key1 { get; set; }

            public string? Object1_Object3_Value1 { get; set; }

            public DateTime? Object1_Object3_Value2 { get; set; }

            public decimal? Object1_Object3_Value3 { get; set; }

            //private static IDictionary<object[], object[]> GetAppendValues_Object1_Object3(DataGeneratorContext _)
            //{
            //    Dictionary<object[], object[]> dic = new Dictionary<object[], object[]>
            //{
            //    {  new object[] { 1 }, new object[] { "now", DateTime.Now, 111.1m } },
            //    {  new object[] { 2 }, new object[] { "today", DateTime.Today, 222.2m } },
            //    {  new object[] { 3 }, new object[] { "yesterday", DateTime.Today.AddDays(-1), null! } }
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<object[1], object[4]>

            //[AdditionField(new[] { nameof(Object1_Object4_Value1), nameof(Object1_Object4_Value2), nameof(Object1_Object4_Value3), nameof(Object1_Object4_Value4) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_Object1_Object4))]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? Object1_Object4_Key1 { get; set; }

            public string? Object1_Object4_Value1 { get; set; }

            public DateTime? Object1_Object4_Value2 { get; set; }

            public decimal? Object1_Object4_Value3 { get; set; }

            public bool? Object1_Object4_Value4 { get; set; }

            //private static IDictionary<object[], object[]> GetAppendValues_Object1_Object4(DataGeneratorContext _)
            //{
            //    Dictionary<object[], object[]> dic = new Dictionary<object[], object[]>
            //{
            //    { new object[] { 1 }, new object[] { "now", DateTime.Now, 111.1m, true } },
            //    { new object[] { 2 }, new object[] { "today", DateTime.Today, 222.2m, false } },
            //    { new object[] { 3 }, new object[] { "yesterday", DateTime.Today.AddDays(-1), null!, true } }
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<string[1], string>

            //[AdditionField(new[] { nameof(String1_String_Value) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_String1_String))]
            [EachField(new string[] { "a", "b", "c" })]
            public string? String1_String_Key1 { get; set; }

            public bool String1_String_Value { get; set; }

            //private static IDictionary<string[], string> GetAppendValues_String1_String(DataGeneratorContext _)
            //{
            //    Dictionary<string[], string> dic = new Dictionary<string[], string>
            //{
            //    { new string[]{ "a" }, "true" },
            //    { new string[]{ "b" }, "false" }
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<string[1], string[1]>

            //[AdditionField(new[] { nameof(String1_String1_Value1) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_String1_String1))]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? String1_String1_Key1 { get; set; }

            public string? String1_String1_Value1 { get; set; }

            //private static IDictionary<string[], string[]> GetAppendValues_String1_String1(DataGeneratorContext _)
            //{
            //    Dictionary<string[], string[]> dic = new Dictionary<string[], string[]>
            //{
            //    { new string[] { "1" }, new string[] { "one" } },
            //    { new string[] { "2" }, new string[] { "two" } },
            //    { new string[] { "3" }, new string[] { "three" } }
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<string[1], string[2]>

            //[AdditionField(new[] { nameof(String1_String2_Value1), nameof(String1_String2_Value2) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_String1_String2))]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? String1_String2_Key1 { get; set; }

            public string? String1_String2_Value1 { get; set; }

            public DateTime? String1_String2_Value2 { get; set; }

            //private static IDictionary<string[], string[]> GetAppendValues_String1_String2(DataGeneratorContext _)
            //{
            //    Dictionary<string[], string[]> dic = new Dictionary<string[], string[]>
            //{
            //    { new string[] { "1" }, new string[] { "now", DateTime.Now.ToString() } },
            //    { new string[] { "2" }, new string[] { "today", DateTime.Today.ToString() } },
            //    { new string[] { "3" }, new string[] { "yesterday", DateTime.Today.AddDays(-1).ToString() } }
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<string[1], string[3]>

            //[AdditionField(new[] { nameof(String1_String3_Value1), nameof(String1_String3_Value2), nameof(String1_String3_Value3) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_String1_String3))]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? String1_String3_Key1 { get; set; }

            public string? String1_String3_Value1 { get; set; }

            public DateTime? String1_String3_Value2 { get; set; }

            public decimal? String1_String3_Value3 { get; set; }

            //private static IDictionary<string[], string[]> GetAppendValues_String1_String3(DataGeneratorContext _)
            //{
            //    Dictionary<string[], string[]> dic = new Dictionary<string[], string[]>
            //{
            //    { new string[] { "1" }, new string[] { "now", DateTime.Now.ToString(), "111.1" } },
            //    { new string[] { "2" }, new string[] { "today", DateTime.Today.ToString(), "222.2" } },
            //    { new string[] { "3" }, new string[] { "yesterday", DateTime.Today.AddDays(-1).ToString(), null! } }
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<string[1], string[4]>

            //[AdditionField(new[] { nameof(String1_String4_Value1), nameof(String1_String4_Value2), nameof(String1_String4_Value3), nameof(String1_String4_Value4) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_String1_String4))]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? String1_String4_Key1 { get; set; }

            public string? String1_String4_Value1 { get; set; }

            public DateTime? String1_String4_Value2 { get; set; }

            public decimal? String1_String4_Value3 { get; set; }

            public bool? String1_String4_Value4 { get; set; }

            //private static IDictionary<string[], string[]> GetAppendValues_String1_String4(DataGeneratorContext _)
            //{
            //    Dictionary<string[], string[]> dic = new Dictionary<string[], string[]>
            //{
            //    { new string[] { "1" }, new string[] { "now", DateTime.Now.ToString(), "111.1", "true" } },
            //    { new string[] { "2" }, new string[] { "today", DateTime.Today.ToString(), "222.2", "false" } },
            //    { new string[] { "3" }, new string[] { "yesterday", DateTime.Today.AddDays(-1).ToString(), null!, "true" } }
            //};

            //    return dic;
            //}

            #endregion



            #region IDictionary<object[2], object>

            //[AdditionField(new[] { nameof(Object2_Object_Value) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_Object2_Object))]
            [DirectProductField("Object2_Object", 0)]
            [EachField(new string[] { "a", "b", "c" })]
            public string? Object2_Object_Key1 { get; set; }

            [DirectProductField("Object2_Object", 1)]
            [EachField(new short[] { 1, 2 })]
            public short? Object2_Object_Key2 { get; set; }

            public bool Object2_Object_Value { get; set; }

            //private static IDictionary<object[], object> GetAppendValues_Object2_Object(DataGeneratorContext _)
            //{
            //    Dictionary<object[], object> dic = new Dictionary<object[], object>
            //{
            //    { new object[]{ "a", (short)1 }, true },
            //    { new object[]{ "b", (short)1 }, false },
            //    { new object[]{ "a", (short)2 }, true }
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<object[2], object[1]>

            //[AdditionField(new[] { nameof(Object2_Object1_Value1) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_Object2_Object1))]
            [DirectProductField("Object2_Object1", 0)]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? Object2_Object1_Key1 { get; set; }

            [DirectProductField("Object2_Object1", 1)]
            [EachField(new short[] { 1, 2 })]
            public short? Object2_Object1_Key2 { get; set; }

            public string? Object2_Object1_Value1 { get; set; }

            //private static IDictionary<object[], object[]> GetAppendValues_Object2_Object1(DataGeneratorContext _)
            //{
            //    Dictionary<object[], object[]> dic = new Dictionary<object[], object[]>
            //{
            //    { new object[] { 1, (short)1 }, new object[] { "one" } },
            //    { new object[] { 2, (short)1 }, new object[] { "two" } },
            //    { new object[] { 3, (short)1 }, new object[] { "three" } },
            //    { new object[] { 1, (short)2 }, new object[] { "ONE" } },
            //    { new object[] { 2, (short)2 }, new object[] { "TWO" } },
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<object[2], object[2]>

            //[AdditionField(new[] { nameof(Object2_Object2_Value1), nameof(Object2_Object2_Value2) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_Object2_Object2))]
            [DirectProductField("Object2_Object2", 0)]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? Object2_Object2_Key1 { get; set; }

            [DirectProductField("Object2_Object2", 1)]
            [EachField(new short[] { 1, 2 })]
            public short? Object2_Object2_Key2 { get; set; }

            public string? Object2_Object2_Value1 { get; set; }

            public DateTime? Object2_Object2_Value2 { get; set; }

            //private static IDictionary<object[], object[]> GetAppendValues_Object2_Object2(DataGeneratorContext _)
            //{
            //    Dictionary<object[], object[]> dic = new Dictionary<object[], object[]>
            //{
            //    { new object[] { 1, (short)1 }, new object[] { "now", DateTime.Now } },
            //    { new object[] { 2, (short)1 }, new object[] { "today", DateTime.Today } },
            //    { new object[] { 3, (short)1 }, new object[] { "yesterday", DateTime.Today.AddDays(-1) } },
            //    { new object[] { 1, (short)2 }, new object[] { "NOW", DateTime.Now } },
            //    { new object[] { 2, (short)2 }, new object[] { "TODAY", DateTime.Today } },
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<object[2], object[3]>

            //[AdditionField(new[] { nameof(Object2_Object3_Value1), nameof(Object2_Object3_Value2), nameof(Object2_Object3_Value3) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_Object2_Object3))]
            [DirectProductField("Object2_Object3", 0)]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? Object2_Object3_Key1 { get; set; }

            [DirectProductField("Object2_Object3", 1)]
            [EachField(new short[] { 1, 2 })]
            public short? Object2_Object3_Key2 { get; set; }

            public string? Object2_Object3_Value1 { get; set; }

            public DateTime? Object2_Object3_Value2 { get; set; }

            public decimal? Object2_Object3_Value3 { get; set; }

            //private static IDictionary<object[], object[]> GetAppendValues_Object2_Object3(DataGeneratorContext _)
            //{
            //    Dictionary<object[], object[]> dic = new Dictionary<object[], object[]>
            //{
            //    {  new object[] { 1, (short)1 }, new object[] { "now", DateTime.Now, 111.1m } },
            //    {  new object[] { 2, (short)1 }, new object[] { "today", DateTime.Today, 222.2m } },
            //    {  new object[] { 3, (short)1 }, new object[] { "yesterday", DateTime.Today.AddDays(-1), null! } },
            //    {  new object[] { 1, (short)2 }, new object[] { "NOW", DateTime.Now, 111.1m } },
            //    {  new object[] { 2, (short)2 }, new object[] { "TODAY", DateTime.Today, 222.2m } },
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<string[2], string>

            //[AdditionField(new[] { nameof(String2_String_Value) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_String2_String))]
            [DirectProductField("String2_String", 0)]
            [EachField(new string[] { "a", "b", "c" })]
            public string? String2_String_Key1 { get; set; }

            [DirectProductField("String2_String", 1)]
            [EachField(new short[] { 1, 2 })]
            public short? String2_String_Key2 { get; set; }

            public bool String2_String_Value { get; set; }

            //private static IDictionary<string[], string> GetAppendValues_String2_String(DataGeneratorContext _)
            //{
            //    Dictionary<string[], string> dic = new Dictionary<string[], string>
            //{
            //    { new string[]{ "a", "1" }, "true" },
            //    { new string[]{ "b", "1" }, "false" },
            //    { new string[]{ "a", "2" }, "true" },
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<string[2], string[1]>

            //[AdditionField(new[] { nameof(String2_String1_Value1) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_String2_String1))]
            [DirectProductField("String2_String1", 0)]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? String2_String1_Key1 { get; set; }

            [DirectProductField("String2_String1", 1)]
            [EachField(new short[] { 1, 2 })]
            public short? String2_String1_Key2 { get; set; }

            public string? String2_String1_Value1 { get; set; }

            //private static IDictionary<string[], string[]> GetAppendValues_String2_String1(DataGeneratorContext _)
            //{
            //    Dictionary<string[], string[]> dic = new Dictionary<string[], string[]>
            //{
            //    { new string[] { "1", "1" }, new string[] { "one" } },
            //    { new string[] { "2", "1" }, new string[] { "two" } },
            //    { new string[] { "3", "1" }, new string[] { "three" } },
            //    { new string[] { "1", "2" }, new string[] { "ONE" } },
            //    { new string[] { "2", "2" }, new string[] { "TWO" } },
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<string[2], string[2]>

            //[AdditionField(new[] { nameof(String2_String2_Value1), nameof(String2_String2_Value2) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_String2_String2))]
            [DirectProductField("String2_String2", 0)]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? String2_String2_Key1 { get; set; }

            [DirectProductField("String2_String2", 1)]
            [EachField(new short[] { 1, 2 })]
            public short? String2_String2_Key2 { get; set; }

            public string? String2_String2_Value1 { get; set; }

            public DateTime? String2_String2_Value2 { get; set; }

            //private static IDictionary<string[], string[]> GetAppendValues_String2_String2(DataGeneratorContext _)
            //{
            //    Dictionary<string[], string[]> dic = new Dictionary<string[], string[]>
            //{
            //    { new string[] { "1", "1" }, new string[] { "now", DateTime.Now.ToString() } },
            //    { new string[] { "2", "1" }, new string[] { "today", DateTime.Today.ToString() } },
            //    { new string[] { "3", "1" }, new string[] { "yesterday", DateTime.Today.AddDays(-1).ToString() } },
            //    { new string[] { "1", "2" }, new string[] { "NOW", DateTime.Now.ToString() } },
            //    { new string[] { "2", "2" }, new string[] { "TODAY", DateTime.Today.ToString() } },
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<string[2], string[3]>

            //[AdditionField(new[] { nameof(String2_String3_Value1), nameof(String2_String3_Value2), nameof(String2_String3_Value3) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_String2_String3))]
            [DirectProductField("String2_String3", 0)]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? String2_String3_Key1 { get; set; }

            [DirectProductField("String2_String3", 1)]
            [EachField(new short[] { 1, 2 })]
            public short? String2_String3_Key2 { get; set; }

            public string? String2_String3_Value1 { get; set; }

            public DateTime? String2_String3_Value2 { get; set; }

            public decimal? String2_String3_Value3 { get; set; }

            //private static IDictionary<string[], string[]> GetAppendValues_String2_String3(DataGeneratorContext _)
            //{
            //    Dictionary<string[], string[]> dic = new Dictionary<string[], string[]>
            //{
            //    { new string[] { "1", "1" }, new string[] { "now", DateTime.Now.ToString(), "111.1" } },
            //    { new string[] { "2", "1" }, new string[] { "today", DateTime.Today.ToString(), "222.2" } },
            //    { new string[] { "3", "1" }, new string[] { "yesterday", DateTime.Today.AddDays(-1).ToString(), null! } },
            //    { new string[] { "1", "2" }, new string[] { "NOW", DateTime.Now.ToString(), "111.1" } },
            //    { new string[] { "2", "2" }, new string[] { "TODAY", DateTime.Today.ToString(), "222.2" } },
            //};

            //    return dic;
            //}

            #endregion



            #region IDictionary<object[3], object>

            //[AdditionField(new[] { nameof(Object3_Object_Value) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_Object3_Object))]
            [DirectProductField("Object3_Object", 0)]
            [EachField(new string[] { "a", "b", "c" })]
            public string? Object3_Object_Key1 { get; set; }

            [DirectProductField("Object3_Object", 1)]
            [EachField(new short[] { 1, 2 })]
            public short? Object3_Object_Key2 { get; set; }

            [DirectProductField("Object3_Object", 2)]
            [EachEnumField(typeof(DateTimeKind))]
            public DateTimeKind Object3_Object_Key3 { get; set; }

            public bool Object3_Object_Value { get; set; }

            //private static IDictionary<object[], object> GetAppendValues_Object3_Object(DataGeneratorContext _)
            //{
            //    Dictionary<object[], object> dic = new Dictionary<object[], object>
            //{
            //    { new object[]{ "a", (short)1, DateTimeKind.Utc }, true },
            //    { new object[]{ "b", (short)1, DateTimeKind.Utc }, false },
            //    { new object[]{ "a", (short)2, DateTimeKind.Utc }, true },
            //    { new object[]{ "a", (short)1, DateTimeKind.Local }, true },
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<object[3], object[1]>

            //[AdditionField(new[] { nameof(Object3_Object1_Value1) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_Object3_Object1))]
            [DirectProductField("Object3_Object1", 0)]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? Object3_Object1_Key1 { get; set; }

            [DirectProductField("Object3_Object1", 1)]
            [EachField(new short[] { 1, 2 })]
            public short? Object3_Object1_Key2 { get; set; }

            [DirectProductField("Object3_Object1", 2)]
            [EachEnumField(typeof(DateTimeKind))]
            public DateTimeKind Object3_Object1_Key3 { get; set; }

            public string? Object3_Object1_Value1 { get; set; }

            //private static IDictionary<object[], object[]> GetAppendValues_Object3_Object1(DataGeneratorContext _)
            //{
            //    Dictionary<object[], object[]> dic = new Dictionary<object[], object[]>
            //{
            //    { new object[] { 1, (short)1, DateTimeKind.Utc }, new object[] { "one" } },
            //    { new object[] { 2, (short)1, DateTimeKind.Utc }, new object[] { "two" } },
            //    { new object[] { 3, (short)1, DateTimeKind.Utc }, new object[] { "three" } },
            //    { new object[] { 1, (short)2, DateTimeKind.Utc }, new object[] { "ONE" } },
            //    { new object[] { 2, (short)2, DateTimeKind.Utc }, new object[] { "TWO" } },
            //    { new object[] { 1, (short)1, DateTimeKind.Local }, new object[] { "one" } },
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<object[3], object[2]>

            //[AdditionField(new[] { nameof(Object3_Object2_Value1), nameof(Object3_Object2_Value2) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_Object3_Object2))]
            [DirectProductField("Object3_Object2", 0)]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? Object3_Object2_Key1 { get; set; }

            [DirectProductField("Object3_Object2", 1)]
            [EachField(new short[] { 1, 2 })]
            public short? Object3_Object2_Key2 { get; set; }

            [DirectProductField("Object3_Object2", 2)]
            [EachEnumField(typeof(DateTimeKind))]
            public DateTimeKind Object3_Object2_Key3 { get; set; }

            public string? Object3_Object2_Value1 { get; set; }

            public DateTime? Object3_Object2_Value2 { get; set; }

            //private static IDictionary<object[], object[]> GetAppendValues_Object3_Object2(DataGeneratorContext _)
            //{
            //    Dictionary<object[], object[]> dic = new Dictionary<object[], object[]>
            //{
            //    { new object[] { 1, (short)1, DateTimeKind.Utc }, new object[] { "now", DateTime.Now } },
            //    { new object[] { 2, (short)1, DateTimeKind.Utc }, new object[] { "today", DateTime.Today } },
            //    { new object[] { 3, (short)1, DateTimeKind.Utc }, new object[] { "yesterday", DateTime.Today.AddDays(-1) } },
            //    { new object[] { 1, (short)2, DateTimeKind.Utc }, new object[] { "NOW", DateTime.Now } },
            //    { new object[] { 2, (short)2, DateTimeKind.Utc }, new object[] { "TODAY", DateTime.Today } },
            //    { new object[] { 1, (short)1, DateTimeKind.Local }, new object[] { "now", DateTime.Now } },
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<string[3], string>

            //[AdditionField(new[] { nameof(String3_String_Value) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_String3_String))]
            [DirectProductField("String3_String", 0)]
            [EachField(new string[] { "a", "b", "c" })]
            public string? String3_String_Key1 { get; set; }

            [DirectProductField("String3_String", 1)]
            [EachField(new short[] { 1, 2 })]
            public short? String3_String_Key2 { get; set; }

            [DirectProductField("String3_String", 2)]
            [EachEnumField(typeof(DateTimeKind))]
            public DateTimeKind String3_String_Key3 { get; set; }

            public bool String3_String_Value { get; set; }

            //private static IDictionary<string[], string> GetAppendValues_String3_String(DataGeneratorContext _)
            //{
            //    Dictionary<string[], string> dic = new Dictionary<string[], string>
            //{
            //    { new string[]{ "a", "1", DateTimeKind.Utc.ToString() }, "true" },
            //    { new string[]{ "b", "1", DateTimeKind.Utc.ToString() }, "false" },
            //    { new string[]{ "a", "2", DateTimeKind.Utc.ToString() }, "true" },
            //    { new string[]{ "a", "1", DateTimeKind.Local.ToString() }, "true" },
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<string[3], string[1]>

            //[AdditionField(new[] { nameof(String3_String1_Value1) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_String3_String1))]
            [DirectProductField("String3_String1", 0)]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? String3_String1_Key1 { get; set; }

            [DirectProductField("String3_String1", 1)]
            [EachField(new short[] { 1, 2 })]
            public short? String3_String1_Key2 { get; set; }

            [DirectProductField("String3_String1", 2)]
            [EachEnumField(typeof(DateTimeKind))]
            public DateTimeKind String3_String1_Key3 { get; set; }

            public string? String3_String1_Value1 { get; set; }

            //private static IDictionary<string[], string[]> GetAppendValues_String3_String1(DataGeneratorContext _)
            //{
            //    Dictionary<string[], string[]> dic = new Dictionary<string[], string[]>
            //{
            //    { new string[] { "1", "1", DateTimeKind.Utc.ToString() }, new string[] { "one" } },
            //    { new string[] { "2", "1", DateTimeKind.Utc.ToString() }, new string[] { "two" } },
            //    { new string[] { "3", "1", DateTimeKind.Utc.ToString() }, new string[] { "three" } },
            //    { new string[] { "1", "2", DateTimeKind.Utc.ToString() }, new string[] { "ONE" } },
            //    { new string[] { "2", "2", DateTimeKind.Utc.ToString() }, new string[] { "TWO" } },
            //    { new string[] { "1", "1", DateTimeKind.Local.ToString() }, new string[] { "one" } },
            //};

            //    return dic;
            //}

            #endregion

            #region IDictionary<string[3], string[2]>

            //[AdditionField(new[] { nameof(String3_String2_Value1), nameof(String3_String2_Value2) }, typeof(CoverageAdditionModel), nameof(GetAppendValues_String3_String2))]
            [DirectProductField("String3_String2", 0)]
            [EachField(new int[] { 1, 2, 3, 4 })]
            public int? String3_String2_Key1 { get; set; }

            [DirectProductField("String3_String2", 1)]
            [EachField(new short[] { 1, 2 })]
            public short? String3_String2_Key2 { get; set; }

            [DirectProductField("String3_String2", 2)]
            [EachEnumField(typeof(DateTimeKind))]
            public DateTimeKind String3_String2_Key3 { get; set; }

            public string? String3_String2_Value1 { get; set; }

            public DateTime? String3_String2_Value2 { get; set; }

            //private static IDictionary<string[], string[]> GetAppendValues_String3_String2(DataGeneratorContext _)
            //{
            //    Dictionary<string[], string[]> dic = new Dictionary<string[], string[]>
            //{
            //    { new string[] { "1", "1", DateTimeKind.Utc.ToString()}, new string[] { "now", DateTime.Now.ToString() } },
            //    { new string[] { "2", "1", DateTimeKind.Utc.ToString() }, new string[] { "today", DateTime.Today.ToString() } },
            //    { new string[] { "3", "1", DateTimeKind.Utc.ToString() }, new string[] { "yesterday", DateTime.Today.AddDays(-1).ToString() } },
            //    { new string[] { "1", "2", DateTimeKind.Utc.ToString()}, new string[] { "NOW", DateTime.Now.ToString() } },
            //    { new string[] { "2", "2", DateTimeKind.Utc.ToString()}, new string[] { "TODAY", DateTime.Today.ToString() } },
            //    { new string[] { "1", "1", DateTimeKind.Local.ToString()}, new string[] { "now", DateTime.Now.ToString() } },
            //};

            //    return dic;
            //}

            #endregion

        }


        [TestMethod]
        public Task DirectProduct()
        {
            return GenerateAsync<SampleDirectProductModel>(50);
        }

        internal class SampleDirectProductModel
        {
            [SequenceInt32Field(1, 10)]
            public int ID { get; set; }

            [DirectProductField("tuple1", 0)]
            [SequenceInt32Field(1, 4)]
            public int Field1 { get; set; }

            [DirectProductField("tuple1", 1)]
            [EachField(new[] { 'a', 'b', 'c' })]
            public char Field2 { get; set; }

            [DirectProductField("tuple1", 2)]
            [EachField(new[] { true, false })]
            public bool Field3 { get; set; }
        }



        private async Task GenerateAsync<TModel>(int generationCount) where TModel : new()
        {
            DataGeneratorContext context = new DataGeneratorContext();

            DataGeneratorBuilder builder = DataGeneratorBuilder.FromType(typeof(TModel), context);

            using IDataReader reader = await builder.BuildAsDataReaderAsync(generationCount).ConfigureAwait(false);

            for (int i = 0; i < reader.FieldCount; ++i)
            {
                if (i > 0) { System.Diagnostics.Debug.Write('\t'); }
                System.Diagnostics.Debug.Write(reader.GetName(i));
            }
            System.Diagnostics.Debug.WriteLine("");

            int generatedCount = 0;

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; ++i)
                {
                    if (i > 0) { System.Diagnostics.Debug.Write('\t'); }
                    System.Diagnostics.Debug.Write(reader.GetValue(i));
                }
                System.Diagnostics.Debug.WriteLine("");

                ++generatedCount;
            }

            Assert.AreEqual(generationCount, generatedCount);
        }

    }

    [Obsolete]
    internal abstract class SampleModelBase
    {

        [RandomGuidField()]
        public Guid ID { get; protected set; }

    }

}
