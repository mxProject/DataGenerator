# mxProject.Devs.DataGenerator.Dapper

[Japanese Document](Readme.ja-jp.md)

## Overview

* This library adds O/R mapping functionality to `mxProject.Devs.DataGenerator`.

## Usage

### Simply mapping

* Maps the generated data to one type specified.

* Invokes DataGenerator.Map&lt;T&gt; method.

```c#
public async Task MappingSample()
{
    // Define the data source.
    DataGeneratorFieldFactory factory = new DataGeneratorFieldFactory();

    DataGeneratorBuilder builder = new DataGeneratorBuilder(factory)
        .AddField(factory.RandomGuid("id"))
        .AddField(factory.SequenceInt32("code", 1))
        .AddField(factory.RandomDouble("value", 0, 10000, x => Math.Truncate(x * 100) / 100, nullProbability: 0.3))
        ;

    // Build a data generator.
    DataGenerator generator = await builder.BuildAsync(10).ConfigureAwait(false);

    // Map the generated values to SampleClass.
    foreach (SampleClass obj in generator.Map<SampleClass>())
    {
        Console.WriteLine(obj);
    }
}

private class SampleClass
{
    public Guid ID { get; private set; }
    public int Code { get; private set; }
    public double? Value { get; private set; }

    public override string ToString()
    {
        return $"ID={ID}, Code={Code}, Value={Value?.ToString() ?? "(null)"}";
    }
}
```

When you run the above method, you get the following result:

```console
ID=e15ca766-f4c0-40b0-bcde-f7dc127ce5f5, Code=1, Value=1996.93
ID=509415d1-10c5-4934-898c-3445ad088fab, Code=2, Value=4328.41
ID=39a7f2d6-4629-467b-8d30-210cd88b24f8, Code=3, Value=(null)
ID=9f5950fd-b230-4297-8eef-af1340d0e24b, Code=4, Value=9417.93
ID=8c0ba7a0-b6de-4f93-a7ce-91fec7b4553e, Code=5, Value=(null)
ID=ee6d631b-be27-46da-bcd4-55def195cb2c, Code=6, Value=(null)
ID=0ce566ed-6f43-43b4-a3ed-c19673baa695, Code=7, Value=4474.48
ID=a8f376c5-2fc3-444b-a583-12c675b8ec6c, Code=8, Value=9862.88
ID=0a14a0e9-9b9e-4d91-ad4e-6763a3e4b961, Code=9, Value=1610.02
ID=dcd84068-496d-4bd4-bf88-33c46321d4c3, Code=10, Value=(null)
```

## Multi Mapping

* Maps the generated data to multiple specified types.

* Invokes DataGenerator.MapByFieldIndex&lt;T1, T2, ..., TResult&gt; method or DataGenerator.MapByFieldName&lt;T1, T2, ..., TResult&gt; method.

```c#
public async Task MultiMappingSample()
{
    // Define the data source.
    DataGeneratorFieldFactory factory = new DataGeneratorFieldFactory();

    DataGeneratorBuilder builder = new DataGeneratorBuilder(factory)
        .AddField(factory.RandomGuid("id"))
        .AddField(factory.SequenceInt32("code", 1))
        .AddField(factory.RandomDouble("value", 0, 10000, x => Math.Truncate(x * 100) / 100, nullProbability: 0.3))
        .AddField(factory.RandomDateTime("date1", DateTime.Now.AddMonths(-1), DateTime.Now, x => x.Date))
        .AddField(factory.RandomDateTime("date2", DateTime.Now.AddMonths(-1), DateTime.Now, x => x.Date, nullProbability: 0.3))
        .AddAdditionalField("comment1", typeof(string), rec => $"a comment at {rec.GetDateTime("date1")}")
        .AddAdditionalField("comment2", typeof(string), rec => $"a comment at {rec.GetDateTime("date2")}")
        ;

    // Build a data generator.
    DataGenerator generator = await builder.BuildAsync(10).ConfigureAwait(false);

    // Map the generated values to SampleClass.
    var sampleClassFields = MappingFieldNameInfo.CreateArray("id", "code", "value");
    var commentClassFields1 = MappingFieldNameInfo.CreateArray(("date1", "date"), ("comment1", "comment"));
    var commentClassFields2 = MappingFieldNameInfo.CreateArray(("date2", "date"), ("comment2", "comment"));

    foreach (SampleClass obj in generator.MapByFieldName(
        sampleClassFields,
        commentClassFields1,
        commentClassFields2,
        (SampleClass sample, SampleCommentClass comment1, SampleCommentClass comment2) =>
        {
            sample.AddComment(comment1);
            if (comment2.Date.HasValue) { sample.AddComment(comment2); }
            return sample;
        }
        ))
    {
        Console.WriteLine(obj);
    }
}

private class SampleClass
{
    public Guid ID { get; private set; }
    public int Code { get; private set; }
    public double? Value { get; private set; }

    public IList<SampleCommentClass> Comments
    {
        get { return m_Comments.AsReadOnly(); }
    }
    private readonly List<SampleCommentClass> m_Comments = new List<SampleCommentClass>();

    internal void AddComment(SampleCommentClass comment)
    {
        m_Comments.Add(comment);
    }

    public override string ToString()
    {
        return $"ID={ID}, Code={Code}, Value={Value?.ToString() ?? "(null)"}, CommentCount={Comments.Count}";
    }
}

private class SampleCommentClass
{
    public DateTime? Date { get; private set; }
    public string? Comment { get; private set; }
}
```

When you run the above method, you get the following result:

```console
ID=a2c75eed-84b0-4e11-9c55-31fb5bb68173, Code=1, Value=6095.63, CommentCount=2
ID=48921aae-1891-4b9e-9a23-bdef864bc9d5, Code=2, Value=2901.49, CommentCount=1
ID=78a91df5-51a8-4e61-86ce-0b42c000ba1b, Code=3, Value=9911.98, CommentCount=1
ID=550ced72-6449-4452-80ab-cdb31cde8b55, Code=4, Value=7108.43, CommentCount=2
ID=2b6df769-deaa-4cf3-b999-e9afff1ef381, Code=5, Value=1618.82, CommentCount=1
ID=8cf041d2-f43d-43d4-9295-0cba55f87f13, Code=6, Value=(null), CommentCount=2
ID=d97b7be8-0c23-428c-8aa3-fbc4b3c03789, Code=7, Value=(null), CommentCount=2
ID=3eabf163-daef-4163-b1ab-ec3ad3f95797, Code=8, Value=6417.77, CommentCount=2
ID=dc4f8238-5db5-4eb9-a6ae-28e96158e59b, Code=9, Value=(null), CommentCount=1
ID=2db3f517-aa7d-4081-91e4-bb2b3f3c252d, Code=10, Value=484.82, CommentCount=2
```


## Requirement

### Framework

* .NET Standard 2.0

### PackageReference

* mxProject.Devs.DataGenerator (>= 0.9.2)
* Dapper (>= 2.0.213)

## Install

Please install from Nuget.

https://www.nuget.org/packages/mxProject.Devs.DataGenerator.Dapper/

## License

[MIT Licence](https://github.com/tcnksm/tool/blob/master/LICENCE)
