# Convert

フィールドの値を変換します。

## Implementation by builder

ビルダークラスを使用してフィールドを定義する方法を説明します。

### Sample code

```c#
// ビルダーを定義します。
DataGeneratorBuilder builder = new DataGeneratorBuilder();

builder
    .AddField(factory => factory.RandomBoolean("FLAG", nullProbability: 0.1)
        // 値を数値に変換します
        .Convert(x => x.HasValue ? (x.Value ? 1 : 0) : (int?)null)
        )
    .AddField(factory => factory.RandomBoolean("FLAGTEXT", nullProbability: 0.1)
        // 値を文字列に変換します
        .ConvertToString(x => x.HasValue ? (x.Value ? "TRUE" : "FALSE") : null)
        )
    ;

// 10件のデータレコードを生成するジェネレーターを生成し、データリーダーとして返します。
using IDataReader reader = await builder.BuildAsDataReaderAsync(5);
```

このサンプルコードで生成される IDataReader からは、次のようなデータを取得することができます。

```console
FLAG     FLAGTEXT
-------- --------
0        (null)
1        TRUE
1        FALSE
(null)   TRUE
0        FALSE
```

## Implementation by configuration

設定クラスは Convert をサポートしていません。
