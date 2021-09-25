# DirectProduct

指定された複数のフィールドの値を生成し、それらの直積を返します。

## Implementation by builder

ビルダークラスを使用してフィールドを定義する方法を説明します。

### Sample code

```c#
// コンテキストを生成します。
DataGeneratorContext context = new DataGeneratorContext();

// ビルダーを定義します。
DataGeneratorBuilder builder = new DataGeneratorBuilder();

// フィールドを追加します。
builder
    // 1 から始まる連番を列挙するフィールド
    .AddField(factory => factory.SequenceInt32("ID", initialValue: 1))
    // 3つのフィールドの直積を列挙します
    .AddTupleField(factory => DirectProductFieldFactory.CreateTupleField(
        new IDataGeneratorField[] {
            // 1 から 4 までの連番を列挙するフィールド
            factory.SequenceInt32(
                "FIELD1",
                1,
                4
                ),
            // a, b, c を列挙するフィールド
            factory.Each(
                "FIELD2",
                new char?[]{ 'a', 'b', 'c' }
                ),
            // true, false を列挙するフィールド
            factory.Each(
                "FIELD3",
                new bool?[]{ true, false }
                ),
        },
        context
        ))
    ;

// 30件のデータレコードを生成するジェネレーターを生成し、データリーダーとして返します。
using IDataReader reader = await builder.BuildAsDataReaderAsync(30);
```

このサンプルコードで生成される IDataReader からは、次のようなデータを取得することができます。

FIELD1, FIELD2, FIELD3 は 24 (= 4 * 3 * 2) 個のサイクルで列挙されています。

```console
ID      FIELD1  FIELD2  FIELD3
------- ------- ------- -------
1       1       a       True
2       1       a       False
3       1       b       True
4       1       b       False
5       1       c       True
6       1       c       False
7       2       a       True
8       2       a       False
9       2       b       True
10      2       b       False
11      2       c       True
12      2       c       False
13      3       a       True
14      3       a       False
15      3       b       True
16      3       b       False
17      3       c       True
18      3       c       False
19      4       a       True
20      4       a       False
21      4       b       True
22      4       b       False
23      4       c       True
24      4       c       False
25      1       a       True
26      1       a       False
27      1       b       True
28      1       b       False
29      1       c       True
30      1       c       False
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
    // 1 から始まる連番を列挙するフィールド
    new SequenceInt32FieldSettings()
    {
        FieldName = "ID",
        InitialValue = 1,
    },
};

// タプルフィールドを追加します。
generatorSetting.TupleFields = new DataGeneratorTupleFieldSettings[]
{
    // 3つのフィールドの直積を列挙します
    new DirectProductFieldSettings()
    {
        Fields = new DataGeneratorFieldSettings[]
        {
            // 1 から 4 までの連番を列挙するフィールド
            new SequenceInt32FieldSettings()
            {
                FieldName = "FIELD1",
                InitialValue = 1,
                MaximumValue = 4,
            },
            // a, b, c を列挙するフィールド
            new EachFieldSettings<char>()
            {
                FieldName = "FIELD2",
                Values = new char?[]{ 'a', 'b', 'c' }
            },
            // true, false を列挙するフィールド
            new EachFieldSettings<bool>()
            {
                FieldName = "FIELD3",
                Values = new bool?[]{ true, false }
            }
        }
    }
};

// ジェネレーターの動作を制御するコンテキストを生成します。
// 乱数生成アルゴリズムや文字列コンバーターなどを独自の実装に置き換えることができます。
DataGeneratorContext context = new DataGeneratorContext();

// ビルダーを生成します。
DataGeneratorBuilder builder = generatorSetting.CreateBuilder(context);

// 30件のデータレコードを生成するジェネレーターを生成し、データリーダーとして返します。
using IDataReader reader = await builder.BuildAsDataReaderAsync(30);
```


### Json serialization

前述のサンプルコードの generatorSetting インスタンスは、次のようなJSON文字列にシリアライズされます。

```json
{
  "Fields": [
    {
      "Name": "ID",
      "NullProb": 0.0,
      "Initial": 1,
      "Max": null,
      "Increment": null,
      "FieldType": "SequenceInt32"
    }
  ],
  "TupleFields": [
    {
      "Fields": [
        {
          "Name": "FIELD1",
          "NullProb": 0.0,
          "Initial": 1,
          "Max": 4,
          "Increment": null,
          "FieldType": "SequenceInt32"
        },
        {
          "Name": "FIELD2",
          "NullProb": 0.0,
          "Values": [
            "a",
            "b",
            "c"
          ],
          "FieldType": "EachChar"
        },
        {
          "Name": "FIELD3",
          "NullProb": 0.0,
          "Values": [
            true,
            false
          ],
          "FieldType": "EachBoolean"
        }
      ],
      "FieldType": "DirectProduct"
    }
  ],
  "AdditionalFields": null,
  "AdditionalTupleFields": null
}
```

