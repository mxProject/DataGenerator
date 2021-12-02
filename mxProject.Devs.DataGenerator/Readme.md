# mxProject.Devs.DataGenerator

[Japanese Document](Readme.ja-jp.md)

## Overview

* The library for generating test data in data record format.

* You can access the data records through the IDataReader interface. I think it's easy to implement O / R mapping using `Dapper` and Observable model using` Reactive Extensions`. 

* This data generator will generate a next data record when IDataReader.Read method is called. It is designed to have as few lists as possible within the data generator. Therefore, even if you generate a large number of data records, the resources required to generate the data are not very large.

## Demo

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

Running the sample code above will generate the following data:

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

You can also use a configuration class to define a data generator. The configuration classes support Json serialization. 
The following code implements a data generator similar to the demo above.

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

The DataGeneratorSettings instance in the sample code above is serialized into a JSON string like this:

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

## Description

* Follow these steps to generate the data.

  1. Adds fields for the data record. Defines the field name and data generation algorithm for each field.
  2. Creates an instance of DataGenerator class, specifying the number of data to generate. You can also instantiate an IDataReader instead of a DataGenerator.
  3. Calls GenerateNext method of the DataGenerator instance. A data record is generated at this point. (For IDataReader instances, Read method)
  4. Repeats until the return value of GenerateNext method is false. (For IDataReader instances, Read method)

### Data Fields

* The fields that can be defined by DataGenerator can be classified into the following four types.

|Field Type|Summary|
|:--|:--|
|DataGeneratorField|Generates the value of one field.|
|DataGeneratorTupleField|Generates a combination of values from multiple fields.|
|DataGeneratorAdditionalField|Returns the value of one additional field based on the generated values.|
|DataGeneratorAdditionalTupleField|Returns the values of multiple additional fields based on the generated values.|

#### DataGeneratorField

|Field Type|Summary|
|:--|:--|
|[Any](documents/Any.md)|Returns one of the specified values.|
|[Computing](documents/Computing.md)|Enumerates the result of the specified expression text.|
|[DbQuery](documents/DbQuery.md)|Reads and enumerates the values from the specified data reader. |
|[Each](documents/Each.md)|Returns the specified values in order.|
|[FormattedString](documents/FormattedString.md)|Enumerates string values formatted with the specified format string.|
|[Random](documents/Random.md)|Generates a random value within the specified range.|
|[Sequence](documents/Sequence.md)|Generates sequential values within the specified range.|

#### DataGeneratorTupleField

|Field Type|Summary|
|:--|:--|
|[DbQuery](documents/DbQuery.md)|Reads and enumerates the values from the specified data reader. |
|[DirectProduct](documents/DirectProduct.md)|Generates the values for the specified fields and returns their direct product.|
|[EachTuple](documents/EachTuple.md)|Returns a combination of the values of the specified multiple fields in order.|

#### DataGeneratorAdditionalField

|Field Type|Summary|
|:--|:--|
|[Expression](documents/Expression.md)|Takes the generated data record as an argument and returns the return value of the specified expression.|

#### DataGeneratorAdditionalTupleField

|Field Type|Summary|
|:--|:--|
|[Join](documents/Join.md)|Takes the generated data record as an argument and returns the value corresponding to the value of the key field from the dictionary or lookup.|
|[JoinDbQuery](documents/JoinDbQuery.md)|Takes the generated data record as an argument and returns the value corresponding to the value of the key field from the data reader.|


### フィールド順の設定

* Use SetOrderedFieldNames method or SetFieldNameComparison method to specify the order of the fields.

* When using SetOrderedFieldNames method, specify the sorted field names. Fields that are not specified are placed behind and the order of the fields is undefined.

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

* When using the configuration class, set the sorted field names in the SortedFieldNames property. 

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

### Serialization to Json

* The configuration classes that represent the data generator and field definitions support Json serialization. See [Json Serialization](documentation/JsonSerialization.md) page for more information.


## Requirement

### Framewrork

* .NET Standard 2.0

### PackageReference

* Newtonsoft.Json (>= 12.0.3)
* JsonSubTypes (>= 1.7.0)
* Microsoft.CodeAnalysis.CSharp.Scripting (>= 3.7.0)

## Install

Please install from Nuget.

https://www.nuget.org/packages/mxProject.Devs.DataGenerator/

## Licence

[MIT Licence](https://github.com/tcnksm/tool/blob/master/LICENCE)
