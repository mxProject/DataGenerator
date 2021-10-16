# JoinDbQuery

生成されたデータレコードを引数として受け取り、キーとするフィールドの値に対応する値をデータベースクエリの結果から取得して返します。

## Implementation by builder

ビルダークラスを使用してフィールドを定義する方法を説明します。

### Sample code

```c#
// 付加する値を返すデータリーダーを取得します。
using IDataReader shopDataReader = GetShopMaster();

// ジェネレーターの動作を制御するコンテキストを生成します。
// 乱数生成アルゴリズムや文字列コンバーターなどを独自の実装に置き換えることができます。
DataGeneratorContext context = new DataGeneratorContext();

// ビルダーを定義します。
DataGeneratorBuilder builder = new DataGeneratorBuilder();

// フィールドを追加します。
builder

  // このフィールドは CompanyCode と ShopCode の値の直積を返します。
  .AddTupleField(factory => DirectProductFieldFactory.CreateTupleField(
    new IDataGeneratorField[]
    {
      factory.Each<int>("CompanyCode", new int?[]{ 1, 2, 3, null }),
      factory.Each<long>("ShopCode", new long?[]{ 1, 2, 3, null })
    },
    context
    )
  )

  // CompanyCode と ShopCode の組み合わせに対応する値を返すフィールドを追加します。
  .AddJoinField(factory => factory.WithDataReader(

    // 参照キーのフィールド名を指定します。
    new string[] { "CompanyCode", "ShopCode" },

    // 付加するデータのキーフィールド名を指定します。
    new string[] { "COMPANY_CODE", "SHOP_CODE" },

    // 付加する値のフィールド名を指定します。
    new string[] { "SHOP_NAME", "TELEPHONE_NUMBER" },

    // データリーダーを指定します。
    shopDataReader
    )
  )
;

// 10件のデータレコードを生成するジェネレーターを生成し、データリーダーとして返します。
using IDataReader reader = await builder.BuildAsDataReaderAsync(10);
```

このサンプルコードで生成される IDataReader からは、次のようなデータを取得することができます。

```console
CompanyCode ShopCode SHOP_NAME TELEPHONE_NUMBER
----------- -------- --------- ----------------
1           1        shop1-1   000-0001-0001
1           2        shop1-2   000-0001-0002
1           3        shop1-3   000-0001-0003
1           (null)   (null)    (null)
2           1        shop2-1   000-0002-0001
2           2        (null)    (null)
2           3        (null)    (null)
2           (null)   (null)    (null)
3           1        (null)    (null)
3           2        (null)    (null)
```

## Implementation by configuration

前述のサンプルコードと同じフィールドを設定クラスを使用して定義する方法を説明します。

### Sample code

```c#
// ジェネレーターを定義します。
DataGeneratorSettings generatorSetting = new DataGeneratorSettings()
{
  TupleFields = new DataGeneratorTupleFieldSettings[]
  {
    // このフィールドは CompanyCode と ShopCode の値の直積を返します。
    new DirectProductFieldSettings()
    {
      Fields = new DataGeneratorFieldSettings[]
      {
        new EachFieldSettings<int>()
        {
          FieldName = "CompanyCode",
          Values = new int?[]{ 1, 2, 3, null }
        },
        new EachFieldSettings<long>()
        {
          FieldName = "ShopCode",
          Values = new long?[]{ 1, 2, 3, null }
        }
      }
    }
  },
  AdditionalTupleFields = new DataGeneratorAdditionalTupleFieldSettings[]
  {
    // CompanyCode と ShopCode の組み合わせに対応する値を返すフィールドを追加します。
    new JoinDbQueryFieldSettings()
    {
      // クエリを指定します。
      DbQuerySettings = new DbQuerySettings()
      {
        CommandText = "select * from SHOP_MASTER",
        ConnectionString = "Provider=SQLOLEDB; Data Source=(local); Integrated Security=SSPI"
      },

      // 参照キーのフィールド名を指定します。
      ReferenceKeyFieldNames = new[]{ "CompanyCode", "ShopCode" },

      // 付加するデータのキーフィールド名を指定します。
      AdditionalKeyFieldNames = new[]{ "COMPANY_CODE", "SHOP_CODE" },

      // 付加する値のフィールド名を指定します。
      AdditionalValueFieldNames = new[]{ "SHOP_NAME", "TELEPHONE_NUMBER" },
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
  "Fields": null,
  "TupleFields": [
    {
      "Fields": [
        {
          "Name": "CompanyCode",
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
          "Name": "ShopCode",
          "NullProb": 0.0,
          "Values": [
            1,
            2,
            3,
            null
          ],
          "FieldType": "EachInt64"
        }
      ],
      "FieldType": "DirectProduct"
    }
  ],
  "AdditionalFields": null,
  "AdditionalTupleFields": [
    {
      "AdditionalFields": [],
      "ReferenceKeys": [
        "CompanyCode",
        "ShopCode"
      ],
      "AdditionalKeys": [
        "COMPANY_CODE",
        "SHOP_CODE"
      ],
      "AdditionalValues": [
        "SHOP_NAME",
        "TELEPHONE_NUMBER"
      ],
      "DbQuery": {
        "CommandText": "select * from SHOP_MASTER",
        "ConnectionString": "Provider=SQLOLEDB; Data Source=(local); Integrated Security=SSPI",
        "ConnectionType": null
      },
      "FieldType": "JoinDbQuery"
    }
  ]
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