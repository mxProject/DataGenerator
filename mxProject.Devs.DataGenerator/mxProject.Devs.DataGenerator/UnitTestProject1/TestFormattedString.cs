using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;

using mxProject.Devs.DataGeneration;
using mxProject.Devs.DataGeneration.Fields;
using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Devs.DataGeneration.Configuration.Fields;

namespace UnitTestProject1
{

    [TestClass]
    public class TestFormattedString
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task WithFactory()
        {
            DataGeneratorContext context = new();

            IDataGeneratorField[] arguments = new IDataGeneratorField[]
            {
                context.FieldFactory.AnyOne("arg1", new int[]{ 90, 80, 70 }),
                context.FieldFactory.Each("arg2", new int[]{ 1234, 5678, 9012, 3456, 7890 }),
                context.FieldFactory.RandomInt32("arg3", 0, 9999)
            };

            var field = CompositeFieldFactory.CreateFormattedStringField("TelephoneNumber", "{0:d3}-{1:d4}-{2:d4}", arguments, context, 0.1);

            var enumeration = await field.CreateEnumerationAsync(100).ConfigureAwait(false);

            while (enumeration.GenerateNext())
            {
                Console.WriteLine(enumeration.GetValue());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task WithSettings()
        {
            DataGeneratorSettings generatorSettings = new DataGeneratorSettings()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new FormattedStringFieldSettings()
                    {
                        FieldName = "TelephoneNumber",
                        ArgumentFields = new DataGeneratorFieldSettings[]
                        {
                            new AnyFieldSettings()
                            {
                                FieldName = "arg1",
                                ValueTypeName = "System.Int32",
                                Values=new string?[]
                                {
                                    "090",
                                    "080",
                                    "070"
                                }
                            },
                            new EachFieldSettings()
                            {
                                FieldName = "arg2",
                                ValueTypeName = "System.Int32",
                                Values=new string?[]
                                {
                                    "1234",
                                    "5678",
                                    "9012",
                                    "3456",
                                    "7890"
                                }
                            },
                            new RandomFieldSettings()
                            {
                                FieldName = "arg3",
                                ValueTypeName = "System.Int32",
                                MinimumValue = "0",
                                MaximumValue = "9999",
                            }
                        },
                        FormatString = "{0:d3}-{1:d4}-{2:d4}",
                        NullProbability = 0.1
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref generatorSettings);

            DataGeneratorContext context = new();

            var builder = generatorSettings.CreateBuilder(context);

            using var generator = await builder.BuildAsync(100);

            while (generator.GenerateNext())
            {
                Console.WriteLine(generator.GetFieldValue(0));
            }
        }

    }

}
