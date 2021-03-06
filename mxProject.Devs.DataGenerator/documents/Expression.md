# Expression

Takes the generated data record as an argument and returns the return value of the specified expression. 

## Implementation by builder

Describes how to define fields using DataGeneratorBuilder.

### Sample code

```c#
// Creates a builder.
DataGeneratorBuilder builder = new DataGeneratorBuilder();

// Adds fields.
builder
    .AddField(factory => factory.Each(
        "Major",
        new int?[] { 1, 2, 3 }
        ))
    .AddField(factory => factory.Each(
        "Minor",
        new int?[] { 51, 52, 53, 54, 55 }
        ))
    .AddField(factory => factory.RandomInt32(
        "Number",
        0,
        9999
        ))

    // Adds field that return the formatted number string.
    .AddAdditionalField(
        "FormattedNumber",
        typeof(string),
        rec => $"{rec.GetInt32("Major")}-{rec.GetInt32("Minor")}-{rec.GetInt32("Number"):d4}"
        )
    ;

// Creates a generator that generates 10 records and returns it as a DataReader.
using IDataReader reader = await builder.BuildAsDataReaderAsync(10);
```

The IDataReader generated by this sample code will generate the following data:

```console
Major      Minor      Number     FormattedNumber
---------- ---------- ---------- ----------
1          51         115        1-51-0115
2          52         110        2-52-0110
3          53         1328       3-53-1328
1          54         9701       1-54-9701
2          55         9021       2-55-9021
3          51         5420       3-51-5420
1          52         9921       1-52-9921
2          53         5638       2-53-5638
3          54         2162       3-54-2162
1          55         9379       1-55-9379
```


## Implementation by configuration

Describes how to use a configuration class to define the same fields as the sample code above.

### Sample code

```c#
// Creates a generator settings.
DataGeneratorSettings generatorSetting = new DataGeneratorSettings();

generatorSetting.Fields = new DataGeneratorFieldSettings[]
{
  new EachFieldSettings<int>()
  {
    FieldName = "Major",
    Values = new int?[]{ 1, 2, 3 },
  },
  new EachFieldSettings<int>()
  {
    FieldName = "Minor",
    Values = new int?[] { 51, 52, 53, 54, 55 },
  },
  new RandomInt32FieldSettings()
  {
    FieldName = "Number",
    MinimumValue = 0,
    MaximumValue = 9999
  }
};

generatorSetting.AdditionalFields = new DataGeneratorAdditionalFieldSettings[]
{
  // Adds field that return the formatted number string.
  new ExpressionFieldSettings()
  {
    // Specifies the name of the field to be added.
    FieldName = "FormattedNumber",
    // Specifies the type of value for the field to add. 
    ValueType = "System.Int32",
    // Specifies the selector.
    Expression = "rec => $\"{rec.GetInt32(\"Major\")}-{rec.GetInt32(\"Minor\")}-{rec.GetInt32(\"Number\"):d4}\""
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
      "Name": "Major",
      "NullProb": 0.0,
      "Values": [
        1,
        2,
        3
      ],
      "FieldType": "EachInt32"
    },
    {
      "Name": "Minor",
      "NullProb": 0.0,
      "Values": [
        51,
        52,
        53,
        54,
        55
      ],
      "FieldType": "EachInt32"
    },
    {
      "Name": "Number",
      "NullProb": 0.0,
      "Min": 0,
      "Max": 9999,
      "Selector": null,
      "FieldType": "RandomInt32"
    }
  ],
  "TupleFields": null,
  "AdditionalFields": [
    {
      "FieldName": "FormattedNumber",
      "ValueType": "System.Int32",
      "Expression": "rec => $\"{rec.GetInt32(\"Major\")}-{rec.GetInt32(\"Minor\")}-{rec.GetInt32(\"Number\"):d4}\"",
      "FieldType": "Expression"
    }
  ],
  "AdditionalTupleFields": null
}
```

