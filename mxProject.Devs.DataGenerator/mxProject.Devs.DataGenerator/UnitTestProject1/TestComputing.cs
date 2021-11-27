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
    public class TestComputing
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task WithFactory_ReturnsDateTime()
        {
            DataGeneratorContext context = new();

            IDataGeneratorField[] arguments = new IDataGeneratorField[]
            {
                context.FieldFactory.AnyOne("year", new int[]{ 2021, 2022, 2023 }),
                context.FieldFactory.RandomByte("month", 1, 12),
                context.FieldFactory.RandomInt16("day", 1, 31)
            };

            var field = CompositeFieldFactory.CreateComputingField("Date", typeof(DateTime), @"(y, m, d) => new System.DateTime(y, m, 1).AddDays(d-1)", arguments, context, 0.1);

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
        public async Task WithSettings_ReturnsDateTime()
        {
            DataGeneratorSettings generatorSettings = new DataGeneratorSettings()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new ComputingFieldSettings()
                    {
                        FieldName = "Date",
                        ArgumentFields = new DataGeneratorFieldSettings[]
                        {
                            new AnyFieldSettings<int>()
                            {
                                FieldName = "year",
                                Values = new int?[]
                                {
                                    2021,
                                    2022,
                                    2023
                                }
                            },
                            new RandomByteFieldSettings()
                            {
                                FieldName = "month",
                                MinimumValue = 1,
                                MaximumValue = 12
                            },
                            new RandomInt16FieldSettings()
                            {
                                FieldName = "day",
                                MinimumValue = 1,
                                MaximumValue = 31,
                            }
                        },
                        ValueTypeName = "System.DateTime",
                        Expression = @"(y, m, d) => new System.DateTime(y, m, 1).AddDays(d-1)",
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task WithFactory_ReturnsString()
        {
            DataGeneratorContext context = new();

            IDataGeneratorField[] arguments = new IDataGeneratorField[]
            {
                context.FieldFactory.AnyOne("arg1", new string[]{ "A", "b", "C" }),
                context.FieldFactory.Each("arg2", new int[]{ 1234, 5678, 9012, 3456, 7890 }),
                context.FieldFactory.RandomInt16("arg3", 0, 9999)
            };
            
            var field = CompositeFieldFactory.CreateComputingField("TelephoneNumber", typeof(string), @"(x, y, z) => $""{x.ToUpper()}-{y:d4}-{z:d4}""", arguments, context, 0.1);

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
        public async Task WithSettings_ReturnsString()
        {
            DataGeneratorSettings generatorSettings = new DataGeneratorSettings()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new ComputingFieldSettings()
                    {
                        FieldName = "CompositeNumber",
                        ArgumentFields = new DataGeneratorFieldSettings[]
                        {
                            new AnyFieldSettings()
                            {
                                FieldName = "arg1",
                                ValueTypeName = "System.String",
                                Values=new string?[]
                                {
                                    "A",
                                    "b",
                                    "C"
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
                        ValueTypeName = "System.String",
                        Expression = @"(x, y, z) => $""{x.ToUpper()}-{y:d4}-{z:d4}""",
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
