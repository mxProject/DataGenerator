# Each

指定された値を順番に返します。

## Implementation by builder

ビルダークラスを使用してフィールドを定義する方法を説明します。

### Sample code

```c#
// ビルダーを定義します。
DataGeneratorBuilder builder = new DataGeneratorBuilder();

// フィールドを追加します。
builder
    .AddField(factory => factory.Each(
        "EACH_BYTE",
        // 列挙する値を指定します。
        new byte?[] { 1, 2, 3, null },
        // nullを返す確率を指定します。
        0.1
        ))
    .AddField(factory => factory.Each(
        "EACH_DAYOFWEEK",
        // 列挙する値を指定します。省略した場合は全ての値を列挙します。
        new DayOfWeek?[] { DayOfWeek.Saturday, DayOfWeek.Sunday, null },
        // nullを返す確率を指定します。
        0.1
        ))
    ;

// 10件のデータレコードを生成するジェネレーターを生成し、データリーダーとして返します。
using IDataReader reader = await builder.BuildAsDataReaderAsync(10);
```

このサンプルコードで生成される IDataReader からは、次のようなデータを取得することができます。

```console
EACH_BYTE   EACH_DAYOFWEEK
----------  ----------
1           Saturday
2           (null)
(null)      (null)
(null)      Saturday
1           Sunday
2           (null)
3           Saturday
(null)      Sunday
1           (null)
2           Saturday
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
    new EachFieldSettings<byte>()
    {
        FieldName = "EACH_BYTE",
        // nullを返す確率を指定します。
        NullProbability = 0.1,
        // 列挙する値を指定します。
        Values = new byte?[] { 1, 2, 3, null }
    },
    new EachEnumFieldSettings()
    {
        FieldName = "EACH_DAYOFWEEK",
        // 型名を指定します。
        EnumTypeName = "System.DayOfWeek",
        // nullを返す確率を指定します。
        NullProbability = 0.1,
        // 列挙する値を指定します。省略した場合は全ての値を列挙します。
        Values = new string?[] { "Saturday", "Sunday", null }
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
      "Name": "EACH_BYTE",
      "NullProb": 0.1,
      "Values": [
        1,
        2,
        3,
        null
      ],
      "FieldType": "EachByte"
    },
    {
      "Name": "EACH_DAYOFWEEK",
      "NullProb": 0.1,
      "Values": [
        "Saturday",
        "Sunday",
        null
      ],
      "EnumType": "System.DayOfWeek",
      "FieldType": "EachEnum"
    }
  ],
  "TupleFields": null,
  "AdditionalFields": null,
  "AdditionalTupleFields": null
}
```


## Supported value types

Enum は次の型をサポートしています。

|Type|Configuration Type|JsonSubTypeName|
|:--|:--|:--|
|bool|EachFieldSettings&lt;bool&gt;|EachBoolean|
|byte|EachFieldSettings&lt;byte&gt;|EachByte|
|short|EachFieldSettings&lt;short&gt;|EachInt16|
|int|EachFieldSettings&lt;int&gt;|EachInt32|
|long|EachFieldSettings&lt;long&gt;|EachInt64|
|float|EachFieldSettings&lt;float&gt;|EachSingle|
|double|EachFieldSettings&lt;ldouble&gt;|EachDouble|
|decimal|EachFieldSettings&lt;decimal&gt;|EachDecimal|
|sbyte|EachFieldSettings&lt;sbyte&gt;|EachSByte|
|ushort|EachFieldSettings&lt;ushort&gt;|EachUInt16|
|uint|EachFieldSettings&lt;uint&gt;|EachUInt32|
|ulong|EachFieldSettings&lt;ulong&gt;|EachUInt64|
|DateTime|EachFieldSettings&lt;DateTime&gt;|EachDateTime|
|DateTimeOffset|EachFieldSettings&lt;DateTimeOffset&gt;|EachDateTimeOffset|
|TimeSpan|EachFieldSettings&lt;TimeSpan&gt;|EachTimeSpan|
|char|EachFieldSettings&lt;char&gt;|EachChar|
|string|EachStringFieldSettings|EachString|
|StringValue|EachFieldSettings&lt;StringValue&gt;|EachStringValue|
|Guid|EachFieldSettings&lt;Guid&gt;|EachGuid|
|Enum|EachEnumFieldSettings|EachEnum|

* StringValue は文字列値を格納する構造体です。このライブラリはジェネリックを用いて任意の値型の値を生成するように実装されています。string 型のままではその制約を満たすことができないため、StringValue 構造体を定義しています。
