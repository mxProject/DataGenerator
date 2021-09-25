# Expression

生成されたデータレコードを引数として受け取り、指定された式の戻り値を返します。

## Implementation by builder

ビルダークラスを使用してフィールドを定義する方法を説明します。

### Sample code

```c#
// ビルダーを定義します。
DataGeneratorBuilder builder = new DataGeneratorBuilder();

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

    // フォーマットされた数値文字列を返すフィールドを追加します。
    .AddAdditionalField(
        "FormattedNumber",
        typeof(string),
        rec => $"{rec.GetInt32("Major")}-{rec.GetInt32("Minor")}-{rec.GetInt32("Number"):d4}"
        )
    ;

// 10件のデータレコードを生成するジェネレーターを生成し、データリーダーとして返します。
using IDataReader reader = await builder.BuildAsDataReaderAsync(10);
```

このサンプルコードで生成される IDataReader からは、次のようなデータを取得することができます。

```console
Major      Minor      Number     FormattedNumber
---------- ---------- ---------- ----------
1          51         115        1-51-0115
2          52         110        2-52-0110
3          53         1328       3-53-1328
1          54         9701       1-54-9701
2          55         9021       2-55-9021
3          51         5420       3-51-5420
1          52         9921       1-52-9921
2          53         5638       2-53-5638
3          54         2162       3-54-2162
1          55         9379       1-55-9379
```


## Implementation by configuration

前述のサンプルコードと同じフィールドを設定クラスを使用して定義する方法を説明します。

### Sample code

```c#
// ジェネレーターを定義します。
DataGeneratorSettings generatorSetting = new DataGeneratorSettings();

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
  // フォーマットされた数値文字列を返すフィールドを追加します。
  new ExpressionFieldSettings()
  {
    // 付加するフィールドの名前を指定します。
    FieldName = "FormattedNumber",
    // 付加するフィールドの値の型名を指定します。
    ValueType = "System.Int32",
    // セレクターを指定します。
    Expression = "rec => $\"{rec.GetInt32(\"Major\")}-{rec.GetInt32(\"Minor\")}-{rec.GetInt32(\"Number\"):d4}\""
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
      "Name": "Major",
      "NullProb": 0.0,
      "Values": [
        1,
        2,
        3
      ],
      "FieldType": "EachInt32"
    },
    {
      "Name": "Minor",
      "NullProb": 0.0,
      "Values": [
        51,
        52,
        53,
        54,
        55
      ],
      "FieldType": "EachInt32"
    },
    {
      "Name": "Number",
      "NullProb": 0.0,
      "Min": 0,
      "Max": 9999,
      "Selector": null,
      "FieldType": "RandomInt32"
    }
  ],
  "TupleFields": null,
  "AdditionalFields": [
    {
      "FieldName": "FormattedNumber",
      "ValueType": "System.Int32",
      "Expression": "rec => $\"{rec.GetInt32(\"Major\")}-{rec.GetInt32(\"Minor\")}-{rec.GetInt32(\"Number\"):d4}\"",
      "FieldType": "Expression"
    }
  ],
  "AdditionalTupleFields": null
}
```

