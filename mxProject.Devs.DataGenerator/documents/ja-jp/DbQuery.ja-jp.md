# DbQuery

指定されたデータリーダーからフィールドの値を読み取って列挙します。

## Implementation by builder

ビルダークラスを使用してフィールドを定義する方法を説明します。

### Sample code

```c#
// 値を取得するデータリーダーを取得します。
using IDataReader sampleDataReader1 = GetSampleTable();
using IDataReader sampleDataReader2 = GetSampleTable();

// ジェネレーターの動作を制御するコンテキストを生成します。
// 乱数生成アルゴリズムや文字列コンバーターなどを独自の実装に置き換えることができます。
DataGeneratorContext context = new DataGeneratorContext();

// ビルダーを定義します。
DataGeneratorBuilder builder = new DataGeneratorBuilder();

// フィールドを追加します。
builder

  // 一つのフィールド
  .AddField(factory => factory.FromDataReader(

    // フィールド名を指定します。
    "FIELD1",

    // データリーダーを指定します。
    sampleDataReader1
    )
  )

  // 複数のフィールド
  .AddTupleField(factory => factory.FromDataReader(

    // フィールド名を指定します。
    new[]
    {
      "FIELD2", "FIELD3", "FIELD4"
    },

    // データリーダーを指定します。
    sampleDataReader2
    )
  )
;

// 10件のデータレコードを生成するジェネレーターを生成し、データリーダーとして返します。
using IDataReader reader = await builder.BuildAsDataReaderAsync(10);
```

このサンプルコードで生成される IDataReader からは、次のようなデータを取得することができます。

```console
FIELD1  FIELD2  FIELD3  FIELD4
------  ------  ------  ------
1       10      100     1.1
2       20      (null)  2.2
1       10      100     1.1
2       20      (null)  2.2
1       10      100     1.1
2       20      (null)  2.2
1       10      100     1.1
2       20      (null)  2.2
1       10      100     1.1
2       20      (null)  2.2
```

## Implementation by configuration

前述のサンプルコードと同じフィールドを設定クラスを使用して定義する方法を説明します。

### Sample code

```c#
// ジェネレーターを定義します。
DataGeneratorSettings generatorSettings = new DataGeneratorSettings()
{
  Fields = new DataGeneratorFieldSettings[]
  {
    // 一つのフィールド
    new DbQueryFieldSettings()
    {
      // フィールド名を指定します。
      FieldName = "FIELD1",

      // クエリを指定します。
      DbQuerySettings = new DbQuerySettings()
      {
        CommandText = "select * from SAMPLE_TABLE",
        ConnectionString = "Provider=SQLOLEDB; Data Source=(local); Integrated Security=SSPI"
      }
    }
  },
  TupleFields = new DataGeneratorTupleFieldSettings[]
  {
    // 複数のフィールド
    new DbQueryFieldsSettings()
    {
      // フィールド名を指定します。
      FieldNames = new[]
      {
        "FIELD2",
        "FIELD3",
        "FIELD4",
      },

      // クエリを指定します。
      DbQuerySettings = new DbQuerySettings()
      {
        CommandText = "select * from SAMPLE_TABLE",
        ConnectionString = "Provider=SQLOLEDB; Data Source=(local); Integrated Security=SSPI"
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
      "Name": "FIELD1",
      "DbQuery": {
        "CommandText": "select * from SAMPLE_TABLE",
        "ConnectionString": "Provider=SQLOLEDB; Data Source=(local); Integrated Security=SSPI",
        "ConnectionType": null
      },
      "FieldType": "DbQueryField"
    }
  ],
  "TupleFields": [
    {
      "FieldNames": [
        "FIELD2",
        "FIELD3",
        "FIELD4"
      ],
      "DbQuery": {
        "CommandText": "select * from SAMPLE_TABLE",
        "ConnectionString": "Provider=SQLOLEDB; Data Source=(local); Integrated Security=SSPI",
        "ConnectionType": null
      },
      "FieldType": "DbQueryFields"
    }
  ],
  "AdditionalFields": null,
  "AdditionalTupleFields": null
}
```

### DbConnection used to execute a query

DbQuerySettings を使用してクエリを実行するときに使用される接続は、DataGeneratorContext に格納されている IDbProvider オブジェクトによって作成されます。

DataGeneratorContext に格納されている既定の IDbProvider オブジェクトは System.Data.OleDbConnection を生成します。独自の実装に切り替えるには、DataGeneratorContext のコンストラクタに IDbProvider オブジェクトを渡します。

```c#
IDbProvider provider = new CustomDbProvider();
DataGeneratorContext context = new DataGeneratorContext(dbProvider: provider);

internal class CustomDbProvider : IDbProvider
{
  internal CustomDbProvider() {}

  public IDbConnection CreateConnection(string connectionString, string? connectionTypeName = null)
  {
    // コネクションを返します。
    // connectionString と connectionTypeName には、DbQuerySettings のプロパティに設定された値が渡されます。
  }
}
```