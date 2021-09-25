# Random

指定された範囲内のランダムな値を生成します。

## Implementation by builder

ビルダークラスを使用してフィールドを定義する方法を説明します。

### Sample code

```c#
// ビルダーを定義します。
DataGeneratorBuilder builder = new DataGeneratorBuilder();

builder
    .AddField(factory => factory.RandomDouble(
        "RANDOM_DOUBLE",
        // 最小値を指定します。
        1,
        // 最大値を指定します。
        100,
        // 値を加工する場合、セレクターを指定します。
        x => Math.Round(x, 3),
        // nullを返す確率を指定します。
        0.1
        ))
    .AddField(factory => factory.RandomDateTime(
        "RANDOM_DATE",
        // 最小値を指定します。
        DateTime.Today,
        // 最大値を指定します。
        DateTime.Today.AddMonths(1),
        // 値を加工する場合、セレクターを指定します。
        x => x.Date,
        // nullを返す確率を指定します。
        0.1
        ))
    ;

// 10件のデータレコードを生成するジェネレーターを生成し、データリーダーとして返します。
using IDataReader reader = await builder.BuildAsDataReaderAsync(10);
```

このサンプルコードで生成される IDataReader からは、次のようなデータを取得することができます。

```console
RANDOM_DOUBLE	RANDOM_DATE
----------      ----------
92.738	        (null)
63.958	        2021/06/05 0:00:00
48.989	        2021/06/11 0:00:00
(null)	        (null)
47.04	        2021/06/21 0:00:00
7.301	        (null)
22.534	        2021/06/09 0:00:00
7.065	        2021/06/12 0:00:00
30.044	        (null)
83.545	        2021/06/07 0:00:00
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
    new RandomDoubleFieldSettings()
    {
        FieldName = "RANDOM_DOUBLE",
        // 最小値を指定します。
        MinimumValue = 1,
        // 最大値を指定します。
        MaximumValue = 100,
        // 値を加工する場合、セレクターを指定します。
        SelectorExpression = "x => System.Math.Round(x, 3)",
        // nullを返す確率を指定します。
        NullProbability = 0.1
    },
    new RandomDateTimeFieldSettings()
    {
        FieldName = "RANDOM_DATE",
        // 最小値を指定します。
        MinimumValue = DateTime.Today,
        // 最大値を指定します。
        MaximumValue = DateTime.Today.AddMonths(1),
        // 値を加工する場合、セレクターを指定します。
        SelectorExpression = "x => x.Date",
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
      "Name": "RANDOM_DOUBLE",
      "NullProb": 0.1,
      "Min": 1.0,
      "Max": 100.0,
      "Selector": "x => System.Math.Round(x, 3)",
      "FieldType": "RandomDouble"
    },
    {
      "Name": "RANDOM_DATE",
      "NullProb": 0.1,
      "Min": "2021-09-23T00:00:00+09:00",
      "Max": "2021-10-23T00:00:00+09:00",
      "Selector": "x => x.Date",
      "FieldType": "RandomDateTime"
    }
  ],
  "TupleFields": null,
  "AdditionalFields": null,
  "AdditionalTupleFields": null
}
```


## Supported value types

Random は次の型をサポートしています。

|Type|Configuration Type|JsonSubTypeName|
|:--|:--|:--|
|bool|RandomBooleanFieldSettings|RandomBoolean|
|byte|RandomByteFieldSettings|RandomByte|
|short|RandomInt16FieldSettings|RandomInt16|
|int|RandomInt32FieldSettings|RandomInt32|
|long|RandomInt64FieldSettings|RandomInt64|
|float|RandomSingleFieldSettings|RandomSingle|
|double|RandomDoubleFieldSettings|RandomDouble|
|decimal|RandomDecimalFieldSettings|RandomDecimal|
|sbyte|RandomSByteFieldSettings|RandomSByte|
|ushort|RandomUInt16FieldSettings|RandomUInt16|
|uint|RandomUInt32FieldSettings|RandomUInt32|
|ulong|RandomUInt64FieldSettings|RandomUInt64|
|DateTime|RandomDateTimeFieldSettings|RandomDateTime|
|DateTimeOffset|RandomDateTimeOffsetFieldSettings|RandomDateTimeOffset|
|TimeSpan|RandomTimeSpanFieldSettings|RandomTimeSpan|
|Guid|RandomGuidFieldSettings|RandomGuid|


## ランダム値の生成アルゴリズム

* このライブラリでは System.Random クラスを用いた単純な生成アルゴリズムを用いています。

* 独自のアルゴリズムを用いる場合は IRandomGenerator インターフェースを実装した型を定義し、DataGeneratorBuilder クラスや DataGeneratorContext クラスのインスタンスを生成するときにその型のインスタンスを渡してください。

```c#
// 独自のランダム値生成オブジェクトを生成します。
IRandomGenerator random = new CustomRandomizer();

// ビルダーを生成します。
EnumerableFactory enumerableFavtory = new EnumerableFactory(random);
DataGeneratorFieldFactory fieldFactory = new DataGeneratorFieldFactory();
DataGeneratorBuilder builder = new DataGeneratorBuilder(fieldFactory);

// コンテキストを生成します。
DataGeneratorContext context = new DataGeneratorContext(randomGenerator: random);
```

* ここで設定した IRandomGenerator インスタンスは、nullProbability プロパティによる null 判定などにも使用されます。




