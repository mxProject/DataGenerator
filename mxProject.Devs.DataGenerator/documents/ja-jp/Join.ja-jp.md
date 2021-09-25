# Join

生成されたデータレコードを引数として受け取り、キーとするフィールドの値に対応する値をディクショナリまたはルックアップから取得して返します。

## Implementation by builder

ビルダークラスを使用してフィールドを定義する方法を説明します。

### Sample code

```c#
// ビルダーを定義します。
DataGeneratorBuilder builder = new DataGeneratorBuilder();

builder
    .AddField(factory => factory.Each(
      "ID",
      new int?[] { 1, 2, 3, null }
      ))
    .AddField(factory => factory.Each(
      "Area",
      new char?[] { 'A', 'B' }
      ))

    // "ID" に対応する値を付加します。
    .AddJoinField(factory => factory.WithDictionary(
        // キーとするフィールドの名前を指定します。
        "ID",
        // 付加するフィールドの名前を指定します。
        new[] { "Name", "CreateAt" },
        // 付加する値を格納しているディクショナリを指定します。
        new Dictionary<int, (StringValue, DateTime)>()
        {
            { 1, ("A", new DateTime(2021, 1, 1)) },
            { 3, ("C", new DateTime(2021, 3, 1)) },
            { 5, ("E", new DateTime(2021, 5, 1)) }
        }
        ))

    // "ID" と "Area" に対応する値を付加します。
    .AddJoinField(factory => factory.WithDictionaryKey2(
      // キーとするフィールドの名前を指定します。
      new[] { "ID", "Area" },
      // 付加するフィールドの名前を指定します。
      "Amount",
      // 付加する値を格納しているディクショナリを指定します。
      new Dictionary<(int, char), int>()
      {
        { (1, 'A'), 100 },
        { (1, 'B'), 200 },
        { (3, 'C'), 300 }
      }
      ))
    ;

// 10件のデータレコードを生成するジェネレーターを生成し、データリーダーとして返します。
using IDataReader reader = await builder.BuildAsDataReaderAsync(10);
```

このサンプルコードで生成される IDataReader からは、次のようなデータを取得することができます。

```console
ID      Area    Name	  CreateAt    Amount
------- ------- ------- ----------- -------
1       A       A       2021/01/01  100
2       B       (null)  (null)      (null)
3       A       C       2021/03/01  (null)
(null)  B       (null)  (null)      (null)
1       A       A       2021/01/01  100
2       B       (null)  (null)      (null)
3       A       C       2021/03/01  (null)
(null)  B       (null)  (null)      (null)
1       A       A       2021/01/01  100
2       B       (null)  (null)      (null)
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
    FieldName = "ID",
    Values = new int?[]{ 1, 2, 3, null },
  }
  new EachFieldSettings<char>()
  {
    FieldName = "Area",
    Values = new char?[]{ 'A', 'B' },
  }
};

generatorSetting.AdditionalTupleFields = new DataGeneratorAdditionalTupleFieldSettings[]
{
  // "ID" に対応する値を付加します。
  new JoinFieldSettings()
  {
    // キーとするフィールドを指定します。
    KeyFields = new[]
    {
      new DataGeneratorFieldInfo("ID", typeof(int))
    },
    // 付加するフィールドを指定します。
    AdditionalFields = new[]
    {
      new DataGeneratorFieldInfo("Name", typeof(string)),
      new DataGeneratorFieldInfo("CreateAt", typeof(DateTime))
    },
    // 付加する値を格納しているディクショナリを指定します。
    AdditionalValues = new Dictionary<string?[], string?[]>()
    {
      {
        new[]{ "1" },
        new[]{ "A", "2021/01/01" }
      },
      {
        new[]{ "3" },
        new[]{ "C", "2021/03/01" }
      },
      {
        new[]{ "5" },
        new[]{ "E", "2021/05/01" }
      }
    }
  },
  // "ID" と "Area" に対応する値を付加します。
  new JoinFieldSettings()
  {
    // キーとするフィールドを指定します。
    KeyFields = new[]
    {
      new DataGeneratorFieldInfo("ID", typeof(int)),
      new DataGeneratorFieldInfo("Area", typeof(char))
    },
    // 付加するフィールドを指定します。
    AdditionalFields = new[]
    {
      new DataGeneratorFieldInfo("Amount", typeof(int)),
    },
    // 付加する値を格納しているディクショナリを指定します。
    AdditionalValues = new Dictionary<string?[], string?[]>()
    {
      {
        new[]{ "1", "A" },
        new[]{ "100" }
      },
      {
        new[]{ "1", "B" },
        new[]{ "200" }
      },
      {
        new[]{ "3", "A" },
        new[]{ "300" }
      }
    }
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
      "Name": "ID",
      "NullProb": 0.0,
      "Values": [
        1,
        2,
        3,
        null
      ],
      "FieldType": "EachInt32"
    },
    {
      "Name": "Area",
      "NullProb": 0.0,
      "Values": [
        "A",
        "B"
      ],
      "FieldType": "EachChar"
    }
  ],
  "TupleFields": null,
  "AdditionalFields": null,
  "AdditionalTupleFields": [
    {
      "AdditionalFields": [
        {
          "FieldName": "Name",
          "ValueType": "System.String"
        },
        {
          "FieldName": "CreateAt",
          "ValueType": "System.DateTime"
        }
      ],
      "KeyFields": [
        {
          "FieldName": "ID",
          "ValueType": "System.Int32"
        }
      ],
      "AdditionalValues": [
        {
          "Key": [
            "1"
          ],
          "Value": [
            "A",
            "2021/01/01"
          ]
        },
        {
          "Key": [
            "3"
          ],
          "Value": [
            "C",
            "2021/03/01"
          ]
        },
        {
          "Key": [
            "5"
          ],
          "Value": [
            "E",
            "2021/05/01"
          ]
        }
      ],
      "FieldType": "Join"
    },
    {
      "AdditionalFields": [
        {
          "FieldName": "Amount",
          "ValueType": "System.Int32"
        }
      ],
      "KeyFields": [
        {
          "FieldName": "ID",
          "ValueType": "System.Int32"
        },
        {
          "FieldName": "Area",
          "ValueType": "System.Char"
        }
      ],
      "AdditionalValues": [
        {
          "Key": [
            "1",
            "A"
          ],
          "Value": [
            "100"
          ]
        },
        {
          "Key": [
            "1",
            "B"
          ],
          "Value": [
            "200"
          ]
        },
        {
          "Key": [
            "3",
            "A"
          ],
          "Value": [
            "300"
          ]
        }
      ],
      "FieldType": "Join"
    }
  ]
}
```

