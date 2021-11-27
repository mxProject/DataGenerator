# FormattedString

指定された書式文字列によってフォーマットされた文字列値を列挙します。

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
    .AddField(factory => ComplexFieldFactory.CreateFormattedStringField(
        "TelephoneNumber",
        // 書式文字列を指定します。
        // 引数名はサポートしていません。インデックスで指定してください。
        "{0:d3}-{1:d4}-{2:d4}",
        // 書式文字列に適用する引数として使用するフィールドを指定します。
        new IDataGeneratorField[]
        {
            context.FieldFactory.AnyOne("arg1", new int[]{ 90, 80, 70 }),
            context.FieldFactory.Each("arg2", new int[]{ 1234, 5678, 9012, 3456, 7890 }),
            context.FieldFactory.RandomInt32("arg3", 0, 9999)
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
TelephoneNumber
----------
080-1234-5080
080-5678-9068
080-9012-9297
080-3456-7797
070-7890-6521
070-1234-2977
080-5678-8971
090-9012-2601
090-3456-1008
080-7890-2568
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
    new FormattedStringFieldSettings()
    {
        FieldName = "TelephoneNumber",
        // 書式文字列を指定します。
        // 引数名はサポートしていません。インデックスで指定してください。
        FormatString = "{0:d3}-{1:d4}-{2:d4}",
        // 書式文字列に適用する引数として使用するフィールドを指定します。
        ArgumentFields = new DataGeneratorFieldSettings[]
        {
            new AnyFieldSettings<int>()
            {
                FieldName = "arg1",
                Values=new int?[]
                {
                    090,
                    080,
                    070
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
            new RandomInt32FieldSettings()
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
      "Name": "TelephoneNumber",
      "ArgumentFields": [
        {
          "Name": "arg1",
          "NullProb": 0.0,
          "Values": [
            90,
            80,
            70
          ],
          "FieldType": "AnyInt32"
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
          "FieldType": "RandomInt32"
        }
      ],
      "FormatString": "{0:d3}-{1:d4}-{2:d4}",
      "NullProb": 0.3,
      "FieldType": "FormattedString"
    }
  ],
  "TupleFields": null,
  "AdditionalFields": null,
  "AdditionalTupleFields": null
}
```

