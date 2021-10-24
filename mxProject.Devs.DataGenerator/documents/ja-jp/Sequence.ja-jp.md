# Sequence

指定された範囲内のシーケンシャルな値を生成します。

## Implementation by builder

ビルダークラスを使用してフィールドを定義する方法を説明します。

### Sample code

```c#
// ビルダーを定義します。
DataGeneratorBuilder builder = new DataGeneratorBuilder();

// フィールドを追加します。
builder
    .AddField(factory => factory.SequenceInt32(
        "SEQUENCE_INT32",
        // 初期値を指定します。
        1,
        // 最大値を指定します。
        100,
        // 増分を指定します。
        2,
        // nullを返す確率を指定します。
        0.1
        ))
    .AddField(factory => factory.SequenceDateTime(
        "SEQUENCE_DATETIME",
        // 初期値を指定します。
        DateTime.Today,
        // 最大値を指定します。
        DateTime.Today.AddDays(10),
        // 増分を指定します。
        TimeSpan.FromHours(12),
        // nullを返す確率を指定します。
        0.1
        ))
    .AddField(factory => factory.SequenceDateMonth(
        "SEQUENCE_DATEMONTH",
        // 初期値を指定します。
        new DateTime(2021, 1, 31),
        // 最大値を指定します。
        new DateTime(2021, 12, 31),
        // 増分を指定します。
        1,
        // nullを返す確率を指定します。
        0.1
        ))
    ;
 
// 10件のデータレコードを生成するジェネレーターを生成し、データリーダーとして返します。
using IDataReader reader = await builder.BuildAsDataReaderAsync(10);
```

このサンプルコードで生成される IDataReader からは、次のようなデータを取得することができます。

```console
SEQUENCE_INT32  SEQUENCE_DATETIME       SEQUENCE_DATEMONTH
----------      ----------              ----------
1               2021/06/19 0:00:00      2021/01/31 0:00:00
3               2021/06/19 12:00:00     2021/02/28 0:00:00
5               2021/06/20 0:00:00      (null)
7               2021/06/20 12:00:00     2021/04/30 0:00:00
9               2021/06/21 0:00:00      2021/05/31 0:00:00
11              (null)                  2021/06/30 0:00:00
13              2021/06/22 0:00:00      2021/07/31 0:00:00
15              2021/06/22 12:00:00     2021/08/31 0:00:00
17              2021/06/23 0:00:00      2021/09/30 0:00:00
19              2021/06/23 12:00:00     2021/10/31 0:00:00
```

## Implementation by configuration

前述のサンプルコードと同じフィールドを設定クラスを使用して定義する方法を説明します。

### Sample code

```c#
// ジェネレーターを定義します。
DataGeneratorSettings generatorSetting = new DataGeneratorSettings() { };

// フィールドを追加します。
generatorSetting.Fields = new DataGeneratorFieldSettings[]
{
    new SequenceInt32FieldSettings()
    {
        FieldName = "SEQUENCE_INT32",
        // 初期値を指定します。
        InitialValue = 1,
        // 最大値を指定します。
        MaximumValue = 100,
        // 増分を指定します。
        Increment = 2,
        // nullを返す確率を指定します。
        NullProbability = 0.1
    },
    new SequenceDateTimeFieldSettings()
    {
        FieldName = "SEQUENCE_DATETIME",
        // 初期値を指定します。
        InitialValue = DateTime.Today,
        // 最大値を指定します。
        MaximumValue = DateTime.Today.AddDays(10),
        // 増分を指定します。
        Increment = TimeSpan.FromHours(12),
        // nullを返す確率を指定します。
        NullProbability = 0.1
    },
    new SequenceDateMonthFieldSettings()
    {
        FieldName = "SEQUENCE_DATEMONTH",
        // 初期値を指定します。
        InitialValue = new DateTime(2021, 1, 31),
        // 最大値を指定します。
        MaximumValue = new DateTime(2021, 12, 31),
        // 増分（月数）を指定します。
        Increment = 1,
        // nullを返す確率を指定します。
        NullProbability = 0.1
    }
};

// ジェネレーターの動作を制御するコンテキストを生成します。
// 乱数生成アルゴリズムや文字列コンバーターなどを独自の実装に置き換えることができます。
DataGeneratorContext context = new DataGeneratorContext();

// ビルダーを生成します。
DataGeneratorBuilder builder = generatorSetting.CreateBuilder(context);

// 10件のデータレコードを生成するジェネレーターを生成し、データリーダーとして返します。
using IDataReader reader = await builder.BuildAsDataReaderAsync(10);
```


### Json serialization

前述のサンプルコードの generatorSetting インスタンスは、次のようなJSON文字列にシリアライズされます。

```json
{
  "Fields": [
    {
      "Name": "SEQUENCE_INT32",
      "NullProb": 0.1,
      "Initial": 1,
      "Max": 100,
      "Increment": 2,
      "FieldType": "SequenceInt32"
    },
    {
      "Name": "SEQUENCE_DATETIME",
      "NullProb": 0.1,
      "Initial": "2021-09-23T00:00:00+09:00",
      "Max": "2021-10-03T00:00:00+09:00",
      "Increment": "12:00:00",
      "FieldType": "SequenceDateTime"
    },
    {
      "Name": "SEQUENCE_DATEMONTH",
      "NullProb": 0.1,
      "Initial": "2021-01-31T00:00:00",
      "Max": "2021-12-31T00:00:00",
      "Increment": 1,
      "FieldType": "SequenceDateMonth"
    }
  ],
  "TupleFields": null,
  "AdditionalFields": null,
  "AdditionalTupleFields": null
}
```


## Supported value types

Sequence は次の型をサポートしています。

|Type|Configuration Type|JsonSubTypeName|
|:--|:--|:--|
|byte|SequenceByteFieldSettings|SequenceByte|
|short|SequenceInt16FieldSettings|SequenceInt16|
|int|SequenceInt32FieldSettings|SequenceInt32|
|long|SequenceInt64FieldSetting|SequenceInt64|
|sbyte|SequenceSByteFieldSettings|SequenceSByte|
|ushort|SequenceUInt16FieldSettings|SequenceUInt16|
|uint|SequenceUInt32FieldSettings|SequenceUInt32|
|ulong|SequenceUInt64FieldSetting|SequenceUInt64|
|DateTime|SequenceDateTimeFieldSettings|SequenceDateTime|
|DateTime|SequenceDateMonthFieldSettings|SequenceDateMonth|
|DateTimeOffset|SequenceDateTimeOffsetFieldSettings|SequenceDateTimeOffset|
|DateTimeOffset|SequenceDateMonthOffsetFieldSettings|SequenceDateMonthOffset|
|TimeSpan|SequenceTimeSpanFieldSettings|SequenceTimeSpan|
|(all types above)|SequenceFieldSettings|Sequence|


## 月単位のシーケンス値

* DateTime と DateTimeOffset に対しては、指定された TimeSpan 値を増分とするフィールドと、月数を増分とするフィールドをサポートしています。

* 月数を増分とするフィールドでは、増分を加算した結果の日付がその月の月末日を超える場合、その月の月末日を返します。

  * 例）2021/01/31 --> 2021/02/28 --> 2021/03/31 --> 2021/04/30