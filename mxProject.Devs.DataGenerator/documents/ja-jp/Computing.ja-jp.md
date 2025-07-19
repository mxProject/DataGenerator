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
    .AddField(factory => CompositeFieldFactory.CreateComputingField(
        "Code",
        // 型を指定します。
        typeof(String),
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

    .AddField(factory => CompositeFieldFactory.CreateComputingField(
        "Date",
        // 型を指定します。
        typeof(DateTime),
        // 式を指定します。
        @"(y, m, d) => new System.DateTime(y, m, 1).AddDays(d-1)",
        // 式の引数として使用するフィールドを指定します。
        new IDataGeneratorField[]
        {
            context.FieldFactory.AnyOne("year", new int[]{ 2021, 2022, 2023 }),
            context.FieldFactory.RandomByte("month", 1, 12),
            context.FieldFactory.RandomByte("day", 1, 31)
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
Code         Date
----------   ----------
A-1234-5298  (null)
A-5678-7240  2022/11/15 0:00:00
(null)       2022/10/21 0:00:00
C-3456-5222  2023/05/23 0:00:00
A-7890-4687  2023/01/24 0:00:00
A-1234-4941  (null)
B-5678-3354  2022/10/11 0:00:00
A-9012-0420  2022/06/28 0:00:00
A-3456-7778  2022/04/06 0:00:00
B-7890-9946  2023/08/01 0:00:00
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
        // 型を指定します。
        ValueTypeName = "System.String",
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
    },

    new ComputingFieldSettings()
    {
        FieldName = "Date",
        // 型を指定します。
        ValueTypeName = "System.DateTime",
        // 式を指定します。
        Expression = @"(y, m, d) => new System.DateTime(y, m, 1).AddDays(d-1)",
        // 式の引数として使用するフィールドを指定します。
        ArgumentFields = new DataGeneratorFieldSettings[]
        {
            new AnyFieldSettings<int>()
            {
                FieldName = "year",
                Values = new int?[]
                {
                    2021,
                    2022,
                    2023
                }
            },
            new RandomByteFieldSettings()
            {
                FieldName = "month",
                MinimumValue = 1,
                MaximumValue = 12
            },
            new RandomInt16FieldSettings()
            {
                FieldName = "day",
                MinimumValue = 1,
                MaximumValue = 31,
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
      "ValueType": "System.String",
      "Expression": "(x, y, z) => $\"{x.ToUpper()}-{y:d4}-{z:d4}\"",
      "FieldType": "Computing"
    },
    {
      "Name": "Date",
      "ArgumentFields": [
        {
          "Name": "year",
          "NullProb": 0.0,
          "Values": [
            2021,
            2022,
            2023
          ],
          "FieldType": "AnyInt32"
        },
        {
          "Name": "month",
          "NullProb": 0.0,
          "Min": 1,
          "Max": 12,
          "Selector": null,
          "FieldType": "RandomByte"
        },
        {
          "Name": "day",
          "NullProb": 0.0,
          "Min": 1,
          "Max": 31,
          "Selector": null,
          "FieldType": "RandomInt16"
        }
      ],
      "NullProb": 0.1,
      "ValueType": "System.DateTime",
      "Expression": "(y, m, d) => new System.DateTime(y, m, 1).AddDays(d-1)",
      "FieldType": "Computing"
    }
  ],
  "TupleFields": null,
  "AdditionalFields": null,
  "AdditionalTupleFields": null
}
```

