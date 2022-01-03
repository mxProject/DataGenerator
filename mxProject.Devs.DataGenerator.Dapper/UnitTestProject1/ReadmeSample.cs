using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Text;
using Dapper;

using mxProject.Devs.DataGeneration;
using mxProject.Devs.DataGeneration.AdditionalFields;

namespace UnitTestProject1
{

    [TestClass]
    public class ReadmeSample
    {

        [TestMethod]
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

        [TestMethod]
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
    }

}
