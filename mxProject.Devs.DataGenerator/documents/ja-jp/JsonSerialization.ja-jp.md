# JSON シリアライズ

DataGeneratorSettings クラスは `Newtonsoft.Json` によるシリアライズをサポートしています。

```c#
DataGeneratorSettings generatorSetting = CreateSettings();

// シリアライザの動作設定を生成します。
var settings = new JsonSerializerSettings
{
    Formatting = Formatting.Indented
};

// コンバーターを生成します。
var builder = DataGeneratorFieldTypeConverterBuilder.CreateDefault();
foreach (var converter in builder.Build())
{
    settings.Converters.Add(converter);
}

// Json文字列にシリアライズします。
string json = JsonConvert.SerializeObject(generatorSetting, settings);
```

次のソースコードは DataGeneratorFieldTypeConverterBuilder.CreateDefault メソッドの実装です。ライブラリに定義されている各フィールドに対する設定クラスをサブタイプに登録しています。

```c#
/// <summary>
/// Create a default instance.
/// </summary>
/// <returns></returns>
public static DataGeneratorFieldTypeConverterBuilder CreateDefault()
{
    var fieldSettingsbuilder = JsonSubtypesConverterBuilder.Of(typeof(DataGeneratorFieldSettings), "FieldType");
    var tupleFieldSettingsbuilder = JsonSubtypesConverterBuilder.Of(typeof(DataGeneratorTupleFieldSettings), "FieldType");
    var additionalFieldSettingsbuilder = JsonSubtypesConverterBuilder.Of(typeof(DataGeneratorAdditionalFieldSettings), "FieldType");
    var additionalTupleFieldSettingsbuilder = JsonSubtypesConverterBuilder.Of(typeof(DataGeneratorAdditionalTupleFieldSettings), "FieldType");

    return new DataGeneratorFieldTypeConverterBuilder(fieldSettingsbuilder, tupleFieldSettingsbuilder, additionalFieldSettingsbuilder, additionalTupleFieldSettingsbuilder)
        .RegisterField<EachFieldSettings<bool>>("EachBoolean")
        .RegisterField<EachFieldSettings<byte>>("EachByte")
        .RegisterField<EachFieldSettings<sbyte>>("EachSByte")
        .RegisterField<EachFieldSettings<short>>("EachInt16")
        .RegisterField<EachFieldSettings<ushort>>("EachUInt16")
        .RegisterField<EachFieldSettings<int>>("EachInt32")
        .RegisterField<EachFieldSettings<uint>>("EachUInt32")
        .RegisterField<EachFieldSettings<long>>("EachInt64")
        .RegisterField<EachFieldSettings<ulong>>("EachUInt64")
        .RegisterField<EachFieldSettings<float>>("EachSingle")
        .RegisterField<EachFieldSettings<double>>("EachDouble")
        .RegisterField<EachFieldSettings<decimal>>("EachDecimal")
        .RegisterField<EachFieldSettings<DateTime>>("EachDateTime")
        .RegisterField<EachFieldSettings<DateTimeOffset>>("EachDateTimeOffset")
        .RegisterField<EachFieldSettings<TimeSpan>>("EachTimeSpan")
        .RegisterField<EachFieldSettings<char>>("EachChar")
        .RegisterField<EachFieldSettings<StringValue>>("EachStringValue")
        .RegisterField<EachFieldSettings<Guid>>("EachGuid")
        .RegisterField<EachStringFieldSettings>("EachString")
        .RegisterField<EachEnumFieldSettings>("EachEnum")

        .RegisterField<AnyFieldSettings<bool>>("AnyBoolean")
        .RegisterField<AnyFieldSettings<byte>>("AnyByte")
        .RegisterField<AnyFieldSettings<sbyte>>("AnySByte")
        .RegisterField<AnyFieldSettings<short>>("AnyInt16")
        .RegisterField<AnyFieldSettings<ushort>>("AnyUInt16")
        .RegisterField<AnyFieldSettings<int>>("AnyInt32")
        .RegisterField<AnyFieldSettings<uint>>("AnyUInt32")
        .RegisterField<AnyFieldSettings<long>>("AnyInt64")
        .RegisterField<AnyFieldSettings<ulong>>("AnyUInt64")
        .RegisterField<AnyFieldSettings<float>>("AnySingle")
        .RegisterField<AnyFieldSettings<double>>("AnyDouble")
        .RegisterField<AnyFieldSettings<decimal>>("AnyDecimal")
        .RegisterField<AnyFieldSettings<DateTime>>("AnyDateTime")
        .RegisterField<AnyFieldSettings<DateTimeOffset>>("AnyDateTimeOffset")
        .RegisterField<AnyFieldSettings<TimeSpan>>("AnyTimeSpan")
        .RegisterField<AnyFieldSettings<char>>("AnyChar")
        .RegisterField<AnyFieldSettings<StringValue>>("AnyStringValue")
        .RegisterField<AnyFieldSettings<Guid>>("AnyGuid")
        .RegisterField<AnyStringFieldSettings>("AnyString")
        .RegisterField<AnyEnumFieldSettings>("AnyEnum")

        .RegisterField<RandomBooleanFieldSettings>("RandomBoolean")
        .RegisterField<RandomByteFieldSettings>("RandomByte")
        .RegisterField<RandomSByteFieldSettings>("RandomSByte")
        .RegisterField<RandomInt16FieldSettings>("RandomInt16")
        .RegisterField<RandomUInt16FieldSettings>("RandomUInt16")
        .RegisterField<RandomInt32FieldSettings>("RandomInt32")
        .RegisterField<RandomUInt32FieldSettings>("RandomUInt32")
        .RegisterField<RandomInt64FieldSettings>("RandomInt64")
        .RegisterField<RandomUInt64FieldSettings>("RandomUInt64")
        .RegisterField<RandomSingleFieldSettings>("RandomSingle")
        .RegisterField<RandomDoubleFieldSettings>("RandomDouble")
        .RegisterField<RandomDecimalFieldSettings>("RandomDecimal")
        .RegisterField<RandomDateTimeFieldSettings>("RandomDateTime")
        .RegisterField<RandomDateTimeOffsetFieldSettings>("RandomDateTimeOffset")
        .RegisterField<RandomTimeSpanFieldSettings>("RandomTimeSpan")
        .RegisterField<RandomGuidFieldSettings>("RandomGuid")

        .RegisterField<SequenceByteFieldSettings>("SequenceByte")
        .RegisterField<SequenceSByteFieldSettings>("SequenceSByte")
        .RegisterField<SequenceInt16FieldSettings>("SequenceInt16")
        .RegisterField<SequenceUInt16FieldSettings>("SequenceUInt16")
        .RegisterField<SequenceInt32FieldSettings>("SequenceInt32")
        .RegisterField<SequenceUInt32FieldSettings>("SequenceUInt32")
        .RegisterField<SequenceInt64FieldSettings>("SequenceInt64")
        .RegisterField<SequenceUInt64FieldSettings>("SequenceUInt64")
        .RegisterField<SequenceDateTimeFieldSettings>("SequenceDateTime")
        .RegisterField<SequenceDateMonthFieldSettings>("SequenceDateMonth")
        .RegisterField<SequenceDateTimeOffsetFieldSettings>("SequenceDateTimeOffset")
        .RegisterField<SequenceDateMonthOffsetFieldSettings>("SequenceDateMonthOffset")
        .RegisterField<SequenceTimeSpanFieldSettings>("SequenceTimeSpan")

        .RegisterTupleField<DirectProductFieldSettings>("DirectProduct")
        .RegisterTupleField<EachTupleFieldSettings>("EachTuple")

        .RegisterAdditionalField<ExpressionFieldSettings>("Expression")

        .RegisterAdditionalTupleField<JoinFieldSettings>("Join")
        .RegisterAdditionalTupleField<JoinDbQueryFieldSettings>("JoinDbQuery")
        ;
}
```

独自の設定クラスをシリアライズ可能にするには、次のメソッドを呼び出して設定クラスをサブタイプに登録してください。

|Method|Summary|
|:--|:--|
|RegisterField|Registers the specified subtype of DataGeneratorFieldSettings.|
|RegisterTupleField|Registers the specified subtype of DataGeneratorTupleFieldSettings.|
|RegisterAdditionalField|Registers the specified subtype of DataGeneratorAdditionalFieldSettings.|
|RegisterAdditionalTupleField|Registers the specified subtype of DataGeneratorAdditionalTupleFieldSettings.|
