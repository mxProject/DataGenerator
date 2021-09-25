# Random

Generates a random value within the specified range.

## Implementation by builder

Describes how to define fields using DataGeneratorBuilder.

### Sample code

```c#
// Creates a builder.
DataGeneratorBuilder builder = new DataGeneratorBuilder();

builder
    .AddField(factory => factory.RandomDouble(
        "RANDOM_DOUBLE",
        // Specifies the minimum value.
        1,
        // Specifies the maximum value.
        100,
        // If you want to modify the value, specify the selector.
        x => Math.Round(x, 3),
        // Specifies the probability of returning null.
        0.1
        ))
    .AddField(factory => factory.RandomDateTime(
        "RANDOM_DATE",
        // Specifies the minimum value.
        DateTime.Today,
        // Specifies the maximum value.
        DateTime.Today.AddMonths(1),
        // If you want to modify the value, specify the selector.
        x => x.Date,
        // Specifies the probability of returning null.
        0.1
        ))
    ;

// Creates a generator that generates 10 records and returns it as a DataReader.
using IDataReader reader = await builder.BuildAsDataReaderAsync(10);
```

このサンプルコードで生成される IDataReader からは、次のようなデータを取得することができます。

```console
RANDOM_DOUBLE	RANDOM_DATE
----------      ----------
92.738	        (null)
63.958	        2021/06/05 0:00:00
48.989	        2021/06/11 0:00:00
(null)	        (null)
47.04	        2021/06/21 0:00:00
7.301	        (null)
22.534	        2021/06/09 0:00:00
7.065	        2021/06/12 0:00:00
30.044	        (null)
83.545	        2021/06/07 0:00:00
```

## Implementation by configuration

前述のサンプルコードと同じフィールドを設定クラスを使用して定義する方法を説明します。

### Sample code

```c#
// Creates a generator settings.
DataGeneratorSettings generatorSetting = new DataGeneratorSettings() { };

// Adds fields.
generatorSetting.Fields = new DataGeneratorFieldSettings[]
{
    new RandomDoubleFieldSettings()
    {
        FieldName = "RANDOM_DOUBLE",
        // Specifies the minimum value.
        MinimumValue = 1,
        // Specifies the maximum value.
        MaximumValue = 100,
        // If you want to modify the value, specify the selector.
        SelectorExpression = "x => System.Math.Round(x, 3)",
        // Specifies the probability of returning null.
        NullProbability = 0.1
    },
    new RandomDateTimeFieldSettings()
    {
        FieldName = "RANDOM_DATE",
        // Specifies the minimum value.
        MinimumValue = DateTime.Today,
        // Specifies the maximum value.
        MaximumValue = DateTime.Today.AddMonths(1),
        // If you want to modify the value, specify the selector.
        SelectorExpression = "x => x.Date",
        // Specifies the probability of returning null.
        NullProbability = 0.1
    }
};

// Create a context that controls the behavior of the generator.
// You can replace random number generation algorithms, string converters, etc. with your own implementation.
DataGeneratorContext context = new DataGeneratorContext();

// Creates a builder.
DataGeneratorBuilder builder = generatorSetting.CreateBuilder(context);

// Creates a generator that generates 10 records and returns it as a DataReader.
using IDataReader reader = await builder.BuildAsDataReaderAsync(10);
```


### Json serialization

The DataGeneratorSettings instance in the sample code above is serialized into a JSON string like this: 

```json
{
  "Fields": [
    {
      "Name": "RANDOM_DOUBLE",
      "NullProb": 0.1,
      "Min": 1.0,
      "Max": 100.0,
      "Selector": "x => System.Math.Round(x, 3)",
      "FieldType": "RandomDouble"
    },
    {
      "Name": "RANDOM_DATE",
      "NullProb": 0.1,
      "Min": "2021-09-23T00:00:00+09:00",
      "Max": "2021-10-23T00:00:00+09:00",
      "Selector": "x => x.Date",
      "FieldType": "RandomDateTime"
    }
  ],
  "TupleFields": null,
  "AdditionalFields": null,
  "AdditionalTupleFields": null
}
```


## Supported value types

`Random` supports the following types:

|Type|Configuration Type|JsonSubTypeName|
|:--|:--|:--|
|bool|RandomBooleanFieldSettings|RandomBoolean|
|byte|RandomByteFieldSettings|RandomByte|
|short|RandomInt16FieldSettings|RandomInt16|
|int|RandomInt32FieldSettings|RandomInt32|
|long|RandomInt64FieldSettings|RandomInt64|
|float|RandomSingleFieldSettings|RandomSingle|
|double|RandomDoubleFieldSettings|RandomDouble|
|decimal|RandomDecimalFieldSettings|RandomDecimal|
|sbyte|RandomSByteFieldSettings|RandomSByte|
|ushort|RandomUInt16FieldSettings|RandomUInt16|
|uint|RandomUInt32FieldSettings|RandomUInt32|
|ulong|RandomUInt64FieldSettings|RandomUInt64|
|DateTime|RandomDateTimeFieldSettings|RandomDateTime|
|DateTimeOffset|RandomDateTimeOffsetFieldSettings|RandomDateTimeOffset|
|TimeSpan|RandomTimeSpanFieldSettings|RandomTimeSpan|
|Guid|RandomGuidFieldSettings|RandomGuid|


## Random value generation algorithm

* This library uses a simple generation algorithm using the System.Random class.

* If you want to use your own algorithm, define a type that implements IRandomGenerator interface and pass an instance of that type when you instantiate DataGeneratorBuilder or DataGeneratorContext classes.

```c#
// Creates your own random value generation object.
IRandomGenerator random = new CustomRandomizer();

// When creating a builder...
EnumerableFactory enumerableFavtory = new EnumerableFactory(random);
DataGeneratorFieldFactory fieldFactory = new DataGeneratorFieldFactory();
DataGeneratorBuilder builder = new DataGeneratorBuilder(fieldFactory);

// When creating a context...
DataGeneratorContext context = new DataGeneratorContext(randomGenerator: random);
```

* The IRandomGenerator instance set here is also used for null determination by the nullProbability property.



