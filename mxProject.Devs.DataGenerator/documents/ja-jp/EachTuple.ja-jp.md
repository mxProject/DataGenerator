# EachTuple

指定された複数のフィールドの値の組み合わせを順番に返します。

## Implementation by builder

ビルダークラスを使用してフィールドを定義する方法を説明します。

### Sample code

```c#
// ビルダーを定義します。
DataGeneratorBuilder builder = new DataGeneratorBuilder();

// フィールドを追加します。
builder.AddTupleField(factory => factory.EachTuple(
    // フィールド名を指定します。
    "Field1",
    "Field2",
    "Field3",
    // フィールドの値を指定します。
    new (bool?, int?, StringValue?)[]
    {
        (true, 1, "A"),
        (false, 2, "B"),
        (null, 3, "C"),
    },
    // nullを返す確率を指定します。
    0.1
    ));

// 10件のデータレコードを生成するジェネレーターを生成し、データリーダーとして返します。
using IDataReader reader = await builder.BuildAsDataReaderAsync(10);
```

このサンプルコードで生成される IDataReader からは、次のようなデータを取得することができます。

```console
Field1  Field2  Field3
------- ------- -------
True    1       A
False   2       B
(null)  3       C
True    1       A
False   2       B
(null)  3       C
True    1       A
False   2       B
(null)  (null)  (null)
True    1       A
```

## Implementation by configuration

前述のサンプルコードと同じフィールドを設定クラスを使用して定義する方法を説明します。

### Sample code

```c#
// ジェネレーターを定義します。
DataGeneratorSettings generatorSetting = new DataGeneratorSettings();

// フィールドを追加します。
generatorSetting.TupleFields = new DataGeneratorTupleFieldSettings[]
{
    new EachTupleFieldSettings()
    {
        // フィールド名と値の型を指定します。
        Fields = new DataGeneratorFieldInfo[]
        {
            new DataGeneratorFieldInfo("Field1", typeof(bool)),
            new DataGeneratorFieldInfo("Field2", typeof(int)),
            new DataGeneratorFieldInfo("Field3", typeof(string))
        },
        // フィールドの値を指定します。
        Values = new string?[][]
        {
            new[]{ "true", "1", "A" },
            new[]{ "false", "2", "B" },
            new[]{ null, "3", "C" }
        },
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
  "Fields": null,
  "TupleFields": [
    {
      "Fields": [
        {
          "FieldName": "Field1",
          "ValueType": "System.Boolean"
        },
        {
          "FieldName": "Field2",
          "ValueType": "System.Int32"
        },
        {
          "FieldName": "Field3",
          "ValueType": "System.String"
        }
      ],
      "Values": [
        [
          "true",
          "1",
          "A"
        ],
        [
          "false",
          "2",
          "B"
        ],
        [
          null,
          "3",
          "C"
        ]
      ],
      "NullProb": 0.1,
      "FieldType": "EachTuple"
    }
  ],
  "AdditionalFields": null,
  "AdditionalTupleFields": null
}
```

