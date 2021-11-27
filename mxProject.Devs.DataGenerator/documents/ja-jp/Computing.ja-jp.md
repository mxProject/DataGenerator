# Computing

指定された式の実行結果を列挙します。

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
    .AddField(factory => ComplexFieldFactory.CreateComputingField(
        "Code",
        // 式を指定します。
        @"(x, y, z) => $""{x.ToUpper()}-{y:d4}-{z:d4}""",
        // 式の引数として使用するフィールドを指定します。
        new IDataGeneratorField[]
        {
            context.FieldFactory.AnyOne("arg1", new string[]{ "a", "B", "c" }),
            context.FieldFactory.Each("arg2", new int[]{ 1234, 5678, 9012, 3456, 7890 }),
            context.FieldFactory.RandomInt16("arg3", 0, 9999)
        },
        context,
        // nullを返す確率を指定します。
        0.1
        ))
    ;

// 10件のデータレコードを生成するジェネレーターを生成し、データリーダーとして返します。
using IDataReader reader = await builder.BuildAsDataReaderAsync(10);
```

このサンプルコードで生成される IDataReader からは、次のようなデータを取得することができます。

```console
Code
----------
A-1234-6361
B-5678-4543
(null)
C-3456-7914
B-7890-2017
A-1234-2504
(null)
C-9012-0348
B-3456-1221
B-7890-8993
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
    new ComputingFieldSettings()
    {
        FieldName = "Code",
        // 式を指定します。
        Expression = @"(x, y, z) => $""{x.ToUpper()}-{y:d4}-{z:d4}""",
        // 式の引数として使用するフィールドを指定します。
        ArgumentFields = new DataGeneratorFieldSettings[]
        {
            new AnyStringFieldSettings()
            {
                FieldName = "arg1",
                Values = new string?[]
                {
                    "a",
                    "B",
                    "c"
                }
            },
            new EachFieldSettings<int>()
            {
                FieldName = "arg2",
                Values=new int?[]
                {
                    1234,
                    5678,
                    9012,
                    3456,
                    7890
                }
            },
            new RandomInt16FieldSettings()
            {
                FieldName = "arg3",
                MinimumValue = 0,
                MaximumValue = 9999,
            }
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
  "Fields": [
    {
      "Name": "Code",
      "ArgumentFields": [
        {
          "Name": "arg1",
          "NullProb": 0.0,
          "Values": [
            "a",
            "B",
            "c"
          ],
          "FieldType": "AnyString"
        },
        {
          "Name": "arg2",
          "NullProb": 0.0,
          "Values": [
            1234,
            5678,
            9012,
            3456,
            7890
          ],
          "FieldType": "EachInt32"
        },
        {
          "Name": "arg3",
          "NullProb": 0.0,
          "Min": 0,
          "Max": 9999,
          "Selector": null,
          "FieldType": "RandomInt16"
        }
      ],
      "NullProb": 0.1,
      "Expression": "(x, y, z) => $\"{x.ToUpper()}-{y:d4}-{z:d4}\"",
      "FieldType": "Computing"
    }
  ],
  "TupleFields": null,
  "AdditionalFields": null,
  "AdditionalTupleFields": null
}
```

