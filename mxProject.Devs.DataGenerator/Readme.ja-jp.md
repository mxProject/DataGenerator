# mxProject.Devs.DataGenerator

[English Document](Readme.md)

## 概要

* データレコード形式のテストデータを生成するためのライブラリです。

* IDataReader インターフェースを介してデータレコードにアクセスできます。`Dapper` を用いたO/Rマッピングや `Reactive Extensions` を用いた Observable モデルの実装も容易だと思います。

* IDataReader.Read メソッドが呼び出された時点で次のデータレコードを生成します。データジェネレーター内部ではなるべくリストを保持しないように設計しています。生成するデータレコードの数が多い場合でも、データ生成に必要となるリソースはそれほど大きくなりません。

## デモ

```c#
// Creates a builder.
DataGeneratorBuilder builder = new DataGeneratorBuilder()

    // Sequence from 1 to 100
    .AddField(factory => factory.SequenceInt32(
        "ID",
        1,
        100
        ))

    // Random date from today to one month later
    .AddField(factory => factory.RandomDateTime(
        "SalesDate",
        DateTime.Today,
        DateTime.Today.AddMonths(1),
        x => x.Date
        ))

    // Returns 1, 2, 3 in order
    .AddField(factory => factory.Each(
        "ShopCode",
        new int[] { 1, 2, 3 }
        ))

    // Random numbers from 0 to 100000
    .AddField(factory => factory.RandomInt64(
        "Sales",
        minValue: 0,
        maxValue: 100000
        ))

    // DayOfWeek corresponding to the value in the "SalesDate" field
    .AddAdditionalField(
        "DayOfWeek",
        typeof(DayOfWeek),
        rec => rec.GetDateTime("SalesDate").DayOfWeek
        )

    // Additional values corresponding to the value in the "ShopCode" field
    .AddJoinField(factory => factory.WithDictionary(
        "ShopCode",
        additionalFieldNames: new[]
        {
            "ShopName",
            "OpeningTime"
        },
        additionalValues: new Dictionary<int, (StringValue, TimeSpan)>()
        {
            { 1, ("SHOP1", new TimeSpan(10, 0, 0)) },
            { 2, ("SHOP2", new TimeSpan(18, 0, 0)) }
        }
        ))
    ;

// Creates an IDataReader that wraps the generator.
using IDataReader reader = await builder.BuildAsDataReaderAsync(generateCount: 10);

for (int i = 0; i < reader.FieldCount; ++i)
{
    if (i > 0) { Debug.Write('\t'); }
    Debug.Write(reader.GetName(i));
}
Debug.WriteLine("");

while (reader.Read())
{
    for (int i = 0; i < reader.FieldCount; ++i)
    {
        if (i > 0) { Debug.Write('\t'); }
        Debug.Write(reader.GetValue(i));
    }
    Debug.WriteLine("");
}
```

次のようなデータが生成されるでしょう。

```console
Debug Trace:
ID	SalesDate	ShopCode	Sales	DayOfWeek	ShopName	OpeningTime
1	2021/10/05 0:00:00	1	15702	Tuesday	SHOP1	10:00:00
2	2021/09/20 0:00:00	2	99983	Monday	SHOP2	18:00:00
3	2021/09/27 0:00:00	3	16640	Monday		
4	2021/09/24 0:00:00	1	12485	Friday	SHOP1	10:00:00
5	2021/10/02 0:00:00	2	18911	Saturday	SHOP2	18:00:00
6	2021/10/17 0:00:00	3	79244	Sunday		
7	2021/10/17 0:00:00	1	38010	Sunday	SHOP1	10:00:00
8	2021/09/28 0:00:00	2	49279	Tuesday	SHOP2	18:00:00
9	2021/09/24 0:00:00	3	43640	Friday		
10	2021/10/15 0:00:00	1	71709	Friday	SHOP1	10:00:00
```

設定値クラスを用いてデータジェネレーターを定義することもできます。これらの設定値クラスはJsonシリアライズをサポートしています。
次のコードは前述のデモとほぼ同じ内容を実装しています。

```c#
// Creates a generator settings.
DataGeneratorSettings generatorSettings = new DataGeneratorSettings()
{
    Fields = new DataGeneratorFieldSettings[]
    {
        // Sequence from 1 to 100
        new SequenceInt32FieldSettings()
        {
            FieldName = "ID",
            InitialValue = 1,
            MaximumValue = 100
        },

        // Random date from today to one month later
        new RandomDateTimeFieldSettings()
        {
            FieldName = "SalesDate",
            MinimumValue = DateTime.Today,
            MaximumValue = DateTime.Today.AddMonths(1),
            SelectorExpression = "x => x.Date"
        },

        // Returns 1, 2, 3 in order
        new EachFieldSettings<int>()
        {
            FieldName = "ShopCode",
            Values = new int?[]{ 1, 2, 3 }
        },

        // Random numbers from 0 to 100000
        new RandomDecimalFieldSettings()
        {
            FieldName = "Sales",
            MinimumValue = 1,
            MaximumValue = 100000
        }
    },
    AdditionalFields = new DataGeneratorAdditionalFieldSettings[]
    {
        // DayOfWeek corresponding to the value in the "SalesDate" field
        new ExpressionFieldSettings()
        {
            FieldName = "DayOfWeek",
            ValueType = typeof(DayOfWeek).FullName,
            Expression = "rec => rec.GetDateTime(\"SalesDate\").DayOfWeek"
        }
    },
    AdditionalTupleFields = new DataGeneratorAdditionalTupleFieldSettings[]
    {
        // Additional values corresponding to the value in the "ShopCode" field
        new JoinFieldSettings()
        {
            KeyFields = new DataGeneratorFieldInfo[]
            {
                new DataGeneratorFieldInfo("ShopCode", typeof(int))
            },
            AdditionalFields = new DataGeneratorFieldInfo[]
            {
                new DataGeneratorFieldInfo("ShopName", typeof(string)),
                new DataGeneratorFieldInfo("OpeningTime", typeof(TimeSpan))
            },
            AdditionalValues = new Dictionary<string?[], string?[]>()
            {
                {
                    new[] { "1" },
                    new[] { "SHOP1", "10:00:00" }
                },
                {
                    new[] { "2" },
                    new[] { "SHOP2", "18:00:00" }
                }
            }
        }
    }
};

// Creates a builder.
DataGeneratorContext context = new DataGeneratorContext();

DataGeneratorBuilder builder = generatorSettings.CreateBuilder(context);

// Creates an IDataReader that wraps the generator.
using IDataReader reader = await builder.BuildAsDataReaderAsync(generateCount: 10);

for (int i = 0; i < reader.FieldCount; ++i)
{
    if (i > 0) { Debug.Write('\t'); }
    Debug.Write(reader.GetName(i));
}
Debug.WriteLine("");

while (reader.Read())
{
    for (int i = 0; i < reader.FieldCount; ++i)
    {
        if (i > 0) { Debug.Write('\t'); }
        Debug.Write(reader.GetValue(i));
    }
    Debug.WriteLine("");
}

// Serialize the settings to Json.
var converterBuilder = DataGeneratorFieldTypeConverterBuilder.CreateDefault();

var jsonSettings = new JsonSerializerSettings
{
    Formatting = Formatting.Indented
};

foreach (var converter in converterBuilder.Build())
{
    jsonSettings.Converters.Add(converter);
}

string json = JsonConvert.SerializeObject(generatorSettings, jsonSettings);
Debug.WriteLine(json);
```

次のJSON文字列は、前述の generatorSettings をシリアライズした結果です。

```json
{
  "Fields": [
    {
      "Name": "ID",
      "NullProb": 0.0,
      "Initial": 1,
      "Max": 100,
      "Increment": null,
      "FieldType": "SequenceInt32"
    },
    {
      "Name": "SalesDate",
      "NullProb": 0.0,
      "Min": "2021-09-23T00:00:00+09:00",
      "Max": "2021-10-23T00:00:00+09:00",
      "Selector": "x => x.Date",
      "FieldType": "RandomDateTime"
    },
    {
      "Name": "ShopCode",
      "NullProb": 0.0,
      "Values": [
        1,
        2,
        3
      ],
      "FieldType": "EachInt32"
    },
    {
      "Name": "Sales",
      "NullProb": 0.0,
      "Min": 1.0,
      "Max": 100000.0,
      "Selector": null,
      "FieldType": "RandomDecimal"
    }
  ],
  "TupleFields": null,
  "AdditionalFields": [
    {
      "FieldName": "DayOfWeek",
      "ValueType": "System.DayOfWeek",
      "Expression": "rec => rec.GetDateTime(\"SalesDate\").DayOfWeek",
      "FieldType": "Expression"
    }
  ],
  "AdditionalTupleFields": [
    {
      "AdditionalFields": [
        {
          "FieldName": "ShopName",
          "ValueType": "System.String"
        },
        {
          "FieldName": "OpeningTime",
          "ValueType": "System.TimeSpan"
        }
      ],
      "KeyFields": [
        {
          "FieldName": "ShopCode",
          "ValueType": "System.Int32"
        }
      ],
      "AdditionalValues": [
        {
          "Key": [
            "1"
          ],
          "Value": [
            "SHOP1",
            "10:00:00"
          ]
        },
        {
          "Key": [
            "2"
          ],
          "Value": [
            "SHOP2",
            "18:00:00"
          ]
        }
      ],
      "FieldType": "Join"
    }
  ]
}
```

## 説明

* 次の手順に従ってデータを生成します。

  1. データレコードを構成するフィールドの名前とデータ生成アルゴリズムを定義します。
  2. 生成するデータ数を指定して DataGenerator クラスのインスタンスを生成します。IDataReader インターフェースのインスタンスを生成することもできます。
  3. DataGenerator インスタンスの GenerateNext メソッドを呼び出します。データレコードはこのとき生成されます。（IDataReader インスタンスの場合は Read メソッド）
  4. GenerateNext メソッドの戻り値が false になるまで繰り返します。（IDataReader インスタンスの場合は Read メソッド）

### フィールド

* DataGenerator に定義できるフィールドは、次の四つの種類に分類することができます。

|Field Type|Summary|
|:--|:--|
|DataGeneratorField|一つのフィールドの値を生成します。|
|DataGeneratorTupleField|複数のフィールドの値の組み合わせを生成します。|
|DataGeneratorAdditionalField|生成された値をもとに追加の一つのフィールドの値を返します。|
|DataGeneratorAdditionalTupleField|生成された値をもとに追加の複数のフィールドの値を返します。|

#### DataGeneratorField

|Field Type|Summary|
|:--|:--|
|[Any](documents/ja-jp/Any.ja-jp.md)|指定された値の中から何れかの値を返します。|
|[Computing](documents/ja-jp/Computing.ja-jp.md)|指定された式の実行結果を列挙します。|
|[DbQuery](documents/ja-jp/DbQuery.ja-jp.md)|指定されたデータリーダーからフィールドの値を読み取って列挙します。|
|[Each](documents/ja-jp/Each.ja-jp.md)|指定された値を順番に返します。|
|[FormattedString](documents/ja-jp/FormattedString.ja-jp.md)|指定された書式文字列によってフォーマットされた文字列値を列挙します。|
|[Random](documents/ja-jp/Random.ja-jp.md)|指定された範囲内のランダムな値を生成します。|
|[Sequence](documents/ja-jp/Sequence.ja-jp.md)|指定された範囲内のシーケンシャルな値を生成します。|

#### DataGeneratorTupleField

|Field Type|Summary|
|:--|:--|
|[DbQuery](documents/ja-jp/DbQuery.ja-jp.md)|指定されたデータリーダーからフィールドの値を読み取って列挙します。|
|[DirectProduct](documents/ja-jp/DirectProduct.ja-jp.md)|指定された複数のフィールドの値を生成し、それらの直積を返します。|
|[EachTuple](documents/ja-jp/EachTuple.ja-jp.md)|指定された複数のフィールドの値の組み合わせを順番に返します。|

#### DataGeneratorAdditionalField

|Field Type|Summary|
|:--|:--|
|[Expression](documents/ja-jp/Expression.ja-jp.md)|生成されたデータレコードを引数として受け取り、指定された式の戻り値を返します。|

#### DataGeneratorAdditionalTupleField

|Field Type|Summary|
|:--|:--|
|[Join](documents/ja-jp/Join.ja-jp.md)|生成されたデータレコードを引数として受け取り、キーとするフィールドの値に対応する値をディクショナリまたはルックアップから取得して返します。|
|[JoinDbQuery](documents/ja-jp/JoinDbQuery.ja-jp.md)|生成されたデータレコードを引数として受け取り、キーとするフィールドの値に対応する値をディクショナリまたはルックアップから取得して返します。|


### フィールド順の設定

* フィールド順を指定するには、SetOrderedFieldNames メソッドか SetFieldNameComparison メソッドを使用します。

* SetOrderedFieldNames メソッドでは、ソートされたフィールド名を指定します。指定されなかったフィールドは後方に位置づけられ、そのフィールド順は不定になります。

```c#
// Creates a builder.
DataGeneratorBuilder builder = new DataGeneratorBuilder()

    // Sequence from 1 to 100
    .AddField(factory => factory.SequenceInt32(
        "ID",
        1,
        100
        ))

    // Random date from today to one month later
    .AddField(factory => factory.RandomDateTime(
        "SalesDate",
        DateTime.Today,
        DateTime.Today.AddMonths(1),
        x => x.Date
        ))

    // Returns 1, 2, 3 in order
    .AddField(factory => factory.Each(
        "ShopCode",
        new int[] { 1, 2, 3 }
        ))

    // Sepecify the field order.
    .SetOrderedFieldNames(new string[]{
            "ID",
            "ShopCode",
            "SalesDate"
        });
;
```

* 設定値クラスを用いる場合は SortedFieldNames プロパティにソートされたフィールド名を設定します。

```c#
// Creates a generator settings.
DataGeneratorSettings generatorSettings = new DataGeneratorSettings()
{
    Fields = new DataGeneratorFieldSettings[]
    {
        // Sequence from 1 to 100
        new SequenceInt32FieldSettings()
        {
            FieldName = "ID",
            InitialValue = 1,
            MaximumValue = 100
        },

        // Random date from today to one month later
        new RandomDateTimeFieldSettings()
        {
            FieldName = "SalesDate",
            MinimumValue = DateTime.Today,
            MaximumValue = DateTime.Today.AddMonths(1),
            SelectorExpression = "x => x.Date"
        },

        // Returns 1, 2, 3 in order
        new EachFieldSettings<int>()
        {
            FieldName = "ShopCode",
            Values = new int?[]{ 1, 2, 3 }
        },
    },

    // Sepecify the field order
    SortedFieldNames = new string[]
    {
        "ID",
        "ShopCode",
        "SalesDate"
    }
};
```

### ＪSONシリアライズ

* データジェネレーターおよびフィールドの定義を表す設定クラスは Json シリアライズをサポートしています。詳しくは [Json Serialization](documents/ja-jp/JsonSerialization.ja-jp.md) のページを参照してください。


## 要件

### フレームワーク

* .NET Standard 2.0

### 主な参照パッケージ

* Newtonsoft.Json (>= 12.0.3)
* JsonSubTypes (>= 1.7.0)
* Microsoft.CodeAnalysis.CSharp.Scripting (>= 3.7.0)

## インストール

Nuget からインストールしてください。

https://www.nuget.org/packages/mxProject.Devs.DataGenerator/

## ライセンス

[MIT Licence](https://github.com/tcnksm/tool/blob/master/LICENCE)
