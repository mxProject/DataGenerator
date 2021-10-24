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

using UnitTestProject1.Extensions;

namespace UnitTestProject1
{

    [TestClass]
    public class TestSequenceSettings
    {

        #region byte

        [TestMethod]
        public async Task SequenceByte()
        {
            int generateCount = 100;
            byte minValue = 50;
            byte maxValue = 100;
            byte increment = 3;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceByteFieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue,
                        MaximumValue = maxValue,
                        Increment = increment
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            byte GetNext(byte current)
            {
                var next = (byte)(current + increment);

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        [TestMethod]
        public async Task SequenceByte_NonGeneric()
        {
            int generateCount = 100;
            byte minValue = 50;
            byte maxValue = 100;
            byte increment = 3;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceFieldSettings()
                    {
                        ValueTypeName = "System.Byte",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        Increment = increment.ToString()
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            byte GetNext(byte current)
            {
                var next = (byte)(current + increment);

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        #endregion

        #region sbyte

        [TestMethod]
        public async Task SequenceSByte()
        {
            int generateCount = 100;
            sbyte minValue = -50;
            sbyte maxValue = 100;
            sbyte increment = 3;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceSByteFieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue,
                        MaximumValue = maxValue,
                        Increment = increment
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            sbyte GetNext(sbyte current)
            {
                var next = (sbyte)(current + increment);

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        [TestMethod]
        public async Task SequenceSByte_NonGeneric()
        {
            int generateCount = 100;
            sbyte minValue = -50;
            sbyte maxValue = 100;
            sbyte increment = 3;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceFieldSettings()
                    {
                        ValueTypeName = "System.SByte",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        Increment = increment.ToString()
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            sbyte GetNext(sbyte current)
            {
                var next = (sbyte)(current + increment);

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        #endregion

        #region short

        [TestMethod]
        public async Task SequenceInt16()
        {
            int generateCount = 100;
            short minValue = -50;
            short maxValue = 100;
            short increment = 3;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceInt16FieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue,
                        MaximumValue = maxValue,
                        Increment = increment
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            short GetNext(short current)
            {
                var next = (short)(current + increment);

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        [TestMethod]
        public async Task SequenceInt16_NonGeneric()
        {
            int generateCount = 100;
            short minValue = -50;
            short maxValue = 100;
            short increment = 3;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceFieldSettings()
                    {
                        ValueTypeName = "System.Int16",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        Increment = increment.ToString()
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            short GetNext(short current)
            {
                var next = (short)(current + increment);

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        #endregion

        #region ushort

        [TestMethod]
        public async Task SequenceUInt16()
        {
            int generateCount = 100;
            ushort minValue = 50;
            ushort maxValue = 100;
            ushort increment = 3;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceUInt16FieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue,
                        MaximumValue = maxValue,
                        Increment = increment
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            ushort GetNext(ushort current)
            {
                var next = (ushort)(current + increment);

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        [TestMethod]
        public async Task SequenceUInt16_NonGeneric()
        {
            int generateCount = 100;
            ushort minValue = 50;
            ushort maxValue = 100;
            ushort increment = 3;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceFieldSettings()
                    {
                        ValueTypeName = "System.UInt16",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        Increment = increment.ToString()
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            ushort GetNext(ushort current)
            {
                var next = (ushort)(current + increment);

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        #endregion

        #region int

        [TestMethod]
        public async Task SequenceInt32()
        {
            int generateCount = 100;
            int minValue = -50;
            int maxValue = 100;
            int increment = 3;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceInt32FieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue,
                        MaximumValue = maxValue,
                        Increment = increment
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            int GetNext(int current)
            {
                var next = current + increment;

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        [TestMethod]
        public async Task SequenceInt32_NonGeneric()
        {
            int generateCount = 100;
            int minValue = -50;
            int maxValue = 100;
            int increment = 3;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceFieldSettings()
                    {
                        ValueTypeName = "System.Int32",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        Increment = increment.ToString()
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            int GetNext(int current)
            {
                var next = current + increment;

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        #endregion

        #region uint

        [TestMethod]
        public async Task SequenceUInt32()
        {
            int generateCount = 100;
            uint minValue = 50;
            uint maxValue = 100;
            uint increment = 3;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceUInt32FieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue,
                        MaximumValue = maxValue,
                        Increment = increment
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            uint GetNext(uint current)
            {
                var next = current + increment;

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        [TestMethod]
        public async Task SequenceUInt32_NonGeneric()
        {
            int generateCount = 100;
            uint minValue = 50;
            uint maxValue = 100;
            uint increment = 3;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceFieldSettings()
                    {
                        ValueTypeName = "System.UInt32",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        Increment = increment.ToString()
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            uint GetNext(uint current)
            {
                var next = current + increment;

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        #endregion

        #region long

        [TestMethod]
        public async Task SequenceInt64()
        {
            int generateCount = 100;
            long minValue = -50;
            long maxValue = 100;
            long increment = 3;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceInt64FieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue,
                        MaximumValue = maxValue,
                        Increment = increment
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            long GetNext(long current)
            {
                var next = current + increment;

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        [TestMethod]
        public async Task SequenceInt64_NonGeneric()
        {
            int generateCount = 100;
            long minValue = -50;
            long maxValue = 100;
            long increment = 3;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceFieldSettings()
                    {
                        ValueTypeName = "System.Int64",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        Increment = increment.ToString()
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            long GetNext(long current)
            {
                var next = current + increment;

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        #endregion

        #region ulong

        [TestMethod]
        public async Task SequenceUInt64()
        {
            int generateCount = 100;
            ulong minValue = 50;
            ulong maxValue = 100;
            ulong increment = 3;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceUInt64FieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue,
                        MaximumValue = maxValue,
                        Increment = increment
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            ulong GetNext(ulong current)
            {
                var next = current + increment;

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        [TestMethod]
        public async Task SequenceUInt64_NonGenric()
        {
            int generateCount = 100;
            ulong minValue = 50;
            ulong maxValue = 100;
            ulong increment = 3;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceFieldSettings()
                    {
                        ValueTypeName = "System.UInt64",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        Increment = increment.ToString()
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            ulong GetNext(ulong current)
            {
                var next = current + increment;

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        #endregion

        #region DateTime

        [TestMethod]
        public async Task SequenceDateTime()
        {
            int generateCount = 100;
            DateTime minValue = DateTime.Today;
            DateTime maxValue = DateTime.Today.AddMonths(1);
            TimeSpan increment = TimeSpan.FromHours(20);

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceDateTimeFieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue,
                        MaximumValue = maxValue,
                        Increment = increment
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            DateTime GetNext(DateTime current)
            {
                var next = current + increment;

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        [TestMethod]
        public async Task SequenceDateMonth()
        {
            int generateCount = 100;
            DateTime minValue = DateTime.Today;
            DateTime maxValue = DateTime.Today.AddMonths(12);
            int increment = 3;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceDateMonthFieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue,
                        MaximumValue = maxValue,
                        Increment = increment
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            DateTime GetNext(DateTime current)
            {
                var next = current.AddMonths(increment);

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        [TestMethod]
        public async Task SequenceDateTime_NonGeneric()
        {
            int generateCount = 100;
            DateTime minValue = DateTime.Today;
            DateTime maxValue = DateTime.Today.AddMonths(1);
            TimeSpan increment = TimeSpan.FromHours(20);

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceFieldSettings()
                    {
                        ValueTypeName = "System.DateTime",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        Increment = increment.ToString()
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            DateTime GetNext(DateTime current)
            {
                var next = current + increment;

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        [TestMethod]
        public async Task SequenceDateMonth_NonGeneric()
        {
            int generateCount = 100;
            DateTime minValue = DateTime.Today;
            DateTime maxValue = DateTime.Today.AddMonths(12);
            int increment = 3;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceFieldSettings()
                    {
                        ValueTypeName = "System.DateTime",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        Increment = increment.ToString()
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            DateTime GetNext(DateTime current)
            {
                var next = current.AddMonths(increment);

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        #endregion

        #region DateTimeOffset

        [TestMethod]
        public async Task SequenceDateTimeOffset()
        {
            int generateCount = 100;
            DateTimeOffset minValue = DateTime.Today;
            DateTimeOffset maxValue = DateTime.Today.AddMonths(1);
            TimeSpan increment = TimeSpan.FromHours(20);

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceDateTimeOffsetFieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue,
                        MaximumValue = maxValue,
                        Increment = increment
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            DateTimeOffset GetNext(DateTimeOffset current)
            {
                var next = current + increment;

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        [TestMethod]
        public async Task SequenceDateMonthOffset()
        {
            int generateCount = 100;
            DateTimeOffset minValue = DateTime.Today;
            DateTimeOffset maxValue = DateTime.Today.AddMonths(12);
            int increment = 3;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceDateMonthOffsetFieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue,
                        MaximumValue = maxValue,
                        Increment = increment
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            DateTimeOffset GetNext(DateTimeOffset current)
            {
                var next = current.AddMonths(increment);

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        [TestMethod]
        public async Task SequenceDateTimeOffset_NonGeneric()
        {
            int generateCount = 100;
            DateTimeOffset minValue = DateTime.Today;
            DateTimeOffset maxValue = DateTime.Today.AddMonths(1);
            TimeSpan increment = TimeSpan.FromHours(20);

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceFieldSettings()
                    {
                        ValueTypeName = "System.DateTimeOffset",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        Increment = increment.ToString()
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            DateTimeOffset GetNext(DateTimeOffset current)
            {
                var next = current + increment;

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        [TestMethod]
        public async Task SequenceDateMonthOffset_NonGeneric()
        {
            int generateCount = 100;
            DateTimeOffset minValue = DateTime.Today;
            DateTimeOffset maxValue = DateTime.Today.AddMonths(12);
            int increment = 3;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceFieldSettings()
                    {
                        ValueTypeName = "System.DateTimeOffset",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        Increment = increment.ToString()
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            DateTimeOffset GetNext(DateTimeOffset current)
            {
                var next = current.AddMonths(increment);

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        #endregion

        #region TimeSpan

        [TestMethod]
        public async Task SequenceTimeSpan()
        {
            int generateCount = 100;
            TimeSpan minValue = new TimeSpan(1, 2, 3, 4, 5);
            TimeSpan maxValue = new TimeSpan(10, 0, 0, 0, 0);
            TimeSpan increment = new TimeSpan(1, 2, 3, 4, 5);

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceTimeSpanFieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue,
                        MaximumValue = maxValue,
                        Increment = increment
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            TimeSpan GetNext(TimeSpan current)
            {
                var next = current + increment;

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        [TestMethod]
        public async Task SequenceTimeSpan_NonGeneric()
        {
            int generateCount = 100;
            TimeSpan minValue = new TimeSpan(1, 2, 3, 4, 5);
            TimeSpan maxValue = new TimeSpan(10, 0, 0, 0, 0);
            TimeSpan increment = new TimeSpan(1, 2, 3, 4, 5);

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new SequenceFieldSettings()
                    {
                        ValueTypeName = "System.TimeSpan",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        InitialValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        Increment = increment.ToString()
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            TimeSpan GetNext(TimeSpan current)
            {
                var next = current + increment;

                if (next <= maxValue)
                {
                    return next;
                }
                else
                {
                    return minValue;
                }
            }

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue, GetNext);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue, GetNext);
        }

        #endregion


        private static void EnumerateValues<T>(DataGenerator generator, int expectedCount, T minValue, T maxValue, Func<T, T> expectedNextValue)
            where T : struct, IComparable<T>
        {
            int count = 0;

            T expectedValue = minValue;

            while (generator.GenerateNext())
            {
                if (!generator.GetFieldValueIsNull(0))
                {
                    var value = (T)generator.GetFieldRawValue(0)!;

                    Assert.AreEqual(expectedValue, value);
                    Assert.AreEqual(true, value.CompareTo(minValue) >= 0 && value.CompareTo(maxValue) <= 0);
                }

                expectedValue = expectedNextValue(expectedValue);

                ++count;
            }

            Assert.AreEqual(expectedCount, count);
        }

        private static void EnumerateValues<T>(IDataGenerationReader reader, int expectedCount, T minValue, T maxValue, Func<T, T> expectedNextValue)
            where T : struct, IComparable<T>
        {
            int count = 0;

            T expectedValue = minValue;

            StringBuilder sb = new();

            TestUtility.DumpHeader(reader, sb);

            while (reader.Read())
            {
                TestUtility.DumpRecord(reader, sb);

                if (!reader.IsDBNull(0))
                {
                    var value = reader.GetRawValue<T>(0);

                    Assert.AreEqual(expectedValue, value);
                    Assert.AreEqual(true, value!.Value.CompareTo(minValue) >= 0 && value!.Value.CompareTo(maxValue) <= 0);
                }

                expectedValue = expectedNextValue(expectedValue);

                ++count;
            }

            Debug.WriteLine(sb.ToString());

            Assert.AreEqual(expectedCount, count);
        }

    }

}
