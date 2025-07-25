# FormattedString

Enumerates string values formatted with the specified format string.

## Implementation by builder

Describes how to define fields using DataGeneratorBuilder.

### Sample code

```c#
// Creates a builder.
DataGeneratorBuilder builder = new DataGeneratorBuilder();

// Adds fields.
builder
    .AddField(factory => CompositeFieldFactory.CreateFormattedStringField(
        "TelephoneNumber",
        // Specifies the composite format string.
        // Argument names are not supported. Specify by argument index.
        "{0:d3}-{1:d4}-{2:d4}",
        // Specifies the argument fields.
        new IDataGeneratorField[]
        {
            context.FieldFactory.AnyOne("arg1", new int[]{ 90, 80, 70 }),
            context.FieldFactory.Each("arg2", new int[]{ 1234, 5678, 9012, 3456, 7890 }),
            context.FieldFactory.RandomInt32("arg3", 0, 9999)
        },
        context,
        // Specifies the probability of returning null.
        0.1
        ))
    ;

// Creates a generator that generates 10 records and returns it as a DataReader.
using IDataReader reader = await builder.BuildAsDataReaderAsync(10);
```

The IDataReader generated by this sample code will generate the following data:

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

Describes how to use a configuration class to define the same fields as the sample code above.

### Sample code

```c#
// Creates a generator settings.
DataGeneratorSettings generatorSetting = new DataGeneratorSettings() { };

// Adds fields.
generatorSetting.Fields = new DataGeneratorFieldSettings[]
{
    new FormattedStringFieldSettings()
    {
        FieldName = "TelephoneNumber",
        // Specifies the composite format string.
        // Argument names are not supported. Specify by argument index.
        FormatString = "{0:d3}-{1:d4}-{2:d4}",
        // Specifies the argument fields.
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
