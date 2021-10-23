# Any

指定された値の中から何れかの値を返します。

## Implementation by builder

ビルダークラスを使用してフィールドを定義する方法を説明します。

### Sample code

```c#
// ビルダーを定義します。
DataGeneratorBuilder builder = new DataGeneratorBuilder();

// フィールドを追加します。
builder
    .AddField(factory => factory.AnyOne(
        "ANY_BYTE",
        // 返す値を指定します。
        new byte?[] { 1, 2, 3, null },
        // nullを返す確率を指定します。
        0.1
        ))
    .AddField(factory => factory.AnyOneEnum(
        "ANY_DAYOFWEEK",
        // 列挙する値を指定します。省略した場合は全ての値が候補になります。
        new DayOfWeek?[] { DayOfWeek.Saturday, DayOfWeek.Sunday, DayOfWeek.Monday, null },
        // nullを返す確率を指定します。
        0.1
        ))
    ;

// 10件のデータレコードを生成するジェネレーターを生成し、データリーダーとして返します。
using IDataReader reader = await builder.BuildAsDataReaderAsync(10);
```

このサンプルコードで生成される IDataReader からは、次のようなデータを取得することができます。

```console
ANY_BYTE    ANY_DAYOFWEEK
----------  ----------
(null)      (null)
3           Sunday
3           (null)
2           Monday
(null)      Monday
3           Monday
2           Sunday
1           Sunday
3           Monday
3           (null)
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
    new AnyFieldSettings<byte>()
    {
        FieldName = "ANY_BYTE",
        // nullを返す確率を指定します。
        NullProbability = 0.1,
        // 列挙する値を指定します。
        Values = new byte?[] { 1, 2, 3, null }
    },
    new AnyEnumFieldSettings()
    {
        FieldName = "ANY_DAYOFWEEK",
        // 型名を指定します。
        EnumTypeName = "System.DayOfWeek",
        // nullを返す確率を指定します。
        NullProbability = 0.1,
        // 列挙する値を指定します。省略した場合は全ての値を列挙します。
        Values = new string?[] { "Saturday", "Sunday", "Monday", null }
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
      "Name": "ANY_BYTE",
      "NullProb": 0.1,
      "Values": [
        1,
        2,
        3,
        null
      ],
      "FieldType": "AnyByte"
    },
    {
      "Name": "ANY_DAYOFWEEK",
      "NullProb": 0.1,
      "Values": [
        "Saturday",
        "Sunday",
        "Monday",
        null
      ],
      "EnumType": "System.DayOfWeek",
      "FieldType": "AnyEnum"
    }
  ],
  "TupleFields": null,
  "AdditionalFields": null,
  "AdditionalTupleFields": null
}
```


## Supported value types

Any は次の型をサポートしています。

|Type|SettingsClass Type|JsonSubTypeName|
|:--|:--|:--|
|bool|AnyFieldSettings&lt;bool&gt;|AnyBoolean|
|byte|AnyFieldSettings&lt;byte&gt;|AnyByte|
|short|AnyFieldSettings&lt;short&gt;|AnyInt16|
|int|AnyFieldSettings&lt;int&gt;|AnyInt32|
|long|AnyFieldSettings&lt;long&gt;|AnyInt64|
|float|AnyFieldSettings&lt;float&gt;|AnySingle|
|double|AnyFieldSettings&lt;ldouble&gt;|AnyDouble|
|decimal|AnyFieldSettings&lt;decimal&gt;|AnyDecimal|
|sbyte|AnyFieldSettings&lt;sbyte&gt;|AnySByte|
|ushort|AnyFieldSettings&lt;ushort&gt;|AnyUInt16|
|uint|AnyFieldSettings&lt;uint&gt;|AnyUInt32|
|ulong|AnyFieldSettings&lt;ulong&gt;|AnyUInt64|
|DateTime|AnyFieldSettings&lt;DateTime&gt;|AnyDateTime|
|DateTimeOffset|AnyFieldSettings&lt;DateTimeOffset&gt;|AnyDateTimeOffset|
|TimeSpan|AnyFieldSettings&lt;TimeSpan&gt;|AnyTimeSpan|
|char|AnyFieldSettings&lt;char&gt;|AnyChar|
|string|AnyStringFieldSettings|AnyString|
|StringValue|AnyFieldSettings&lt;StringValue&gt;|AnyStringValue|
|Guid|AnyFieldSettings&lt;Guid&gt;|AnyGuid|
|Enum|AnyEnumFieldSettings|AnyEnum|
|(any struct)|AnyFieldSettings|Any|

* StringValue は文字列値を格納する構造体です。このライブラリは Nullable&lt;T&gt; を用いて任意の型の値を生成するように実装されています。string 型はジェネリック制約を満たすことができないため、StringValue 構造体を定義しています。

