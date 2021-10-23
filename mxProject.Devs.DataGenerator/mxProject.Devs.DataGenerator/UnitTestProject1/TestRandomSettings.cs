using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Data;

using mxProject.Devs.DataGeneration;
using mxProject.Devs.DataGeneration.Fields;
using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Devs.DataGeneration.Configuration.Fields;

using UnitTestProject1.Extensions;

namespace UnitTestProject1
{

    [TestClass]
    public class TestRandomSettings
    {

        #region bool

        [TestMethod]
        public async Task RandomBoolean()
        {

            int generateCount = 100;
            bool minValue = false;
            bool maxValue = true;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomBooleanFieldSettings(){ FieldName="field1", NullProbability=0.1, TrueProbability=0.7 }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue);

        }

        [TestMethod]
        public async Task RandomBoolean_NonGeneric()
        {

            int generateCount = 100;
            bool minValue = false;
            bool maxValue = true;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomFieldSettings()
                    {
                        ValueTypeName = "System.Boolean",
                        FieldName="field1",
                        NullProbability=0.1,
                        // TrueProbability=0.7
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue, maxValue);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue, maxValue);

        }

        #endregion

        #region byte

        [TestMethod]
        public async Task RandomByte()
        {

            int generateCount = 100;
            byte minValue = 0;
            byte maxValue = 100;
            byte offset = 100;
            string selector = $"x => System.Convert.ToByte(x + {offset})";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomByteFieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue,
                        MaximumValue = maxValue,
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues<byte>(generator, generateCount, (byte)(minValue + offset), (byte)(maxValue + offset));
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues<byte>(reader, generateCount, (byte)(minValue + offset), (byte)(maxValue + offset));

        }

        [TestMethod]
        public async Task RandomByte_NonGeneric()
        {

            int generateCount = 100;
            byte minValue = 0;
            byte maxValue = 100;
            byte offset = 100;
            string selector = $"x => System.Convert.ToByte(x + {offset})";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomFieldSettings()
                    {
                        ValueTypeName = "System.Byte",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues<byte>(generator, generateCount, (byte)(minValue + offset), (byte)(maxValue + offset));
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues<byte>(reader, generateCount, (byte)(minValue + offset), (byte)(maxValue + offset));

        }

        #endregion

        #region sbyte

        [TestMethod]
        public async Task RandomSByte()
        {

            int generateCount = 100;
            sbyte minValue = -100;
            sbyte maxValue = 50;
            sbyte offset = 50;
            string selector = $"x => System.Convert.ToSByte(x + {offset})";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomSByteFieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue,
                        MaximumValue = maxValue,
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues<sbyte>(generator, generateCount, (sbyte)(minValue + offset), (sbyte)(maxValue + offset));
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues<sbyte>(reader, generateCount, (sbyte)(minValue + offset), (sbyte)(maxValue + offset));

        }

        [TestMethod]
        public async Task RandomSByte_NonGeneric()
        {

            int generateCount = 100;
            sbyte minValue = -100;
            sbyte maxValue = 50;
            sbyte offset = 50;
            string selector = $"x => System.Convert.ToSByte(x + {offset})";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomFieldSettings()
                    {
                        ValueTypeName = "System.SByte",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues<sbyte>(generator, generateCount, (sbyte)(minValue + offset), (sbyte)(maxValue + offset));
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues<sbyte>(reader, generateCount, (sbyte)(minValue + offset), (sbyte)(maxValue + offset));

        }

        #endregion

        #region short

        [TestMethod]
        public async Task RandomInt16()
        {

            int generateCount = 100;
            short minValue = -100;
            short maxValue = 200;
            short offset = 50;
            string selector = $"x => System.Convert.ToInt16(x + {offset})";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomInt16FieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue,
                        MaximumValue = maxValue,
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues<short>(generator, generateCount, (short)(minValue + offset), (short)(maxValue + offset));
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues<short>(reader, generateCount, (short)(minValue + offset), (short)(maxValue + offset));

        }

        [TestMethod]
        public async Task RandomInt16_NonGeneric()
        {

            int generateCount = 100;
            short minValue = -100;
            short maxValue = 200;
            short offset = 50;
            string selector = $"x => System.Convert.ToInt16(x + {offset})";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomFieldSettings()
                    {
                        ValueTypeName = "System.Int16",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues<short>(generator, generateCount, (short)(minValue + offset), (short)(maxValue + offset));
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues<short>(reader, generateCount, (short)(minValue + offset), (short)(maxValue + offset));

        }

        #endregion

        #region ushort

        [TestMethod]
        public async Task RandomUInt16()
        {

            int generateCount = 100;
            ushort minValue = 0;
            ushort maxValue = 100;
            ushort offset = 100;
            string selector = $"x => System.Convert.ToUInt16(x + {offset})";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomUInt16FieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue,
                        MaximumValue = maxValue,
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues<ushort>(generator, generateCount, (ushort)(minValue + offset), (ushort)(maxValue + offset));
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues<ushort>(reader, generateCount, (ushort)(minValue + offset), (ushort)(maxValue + offset));

        }

        [TestMethod]
        public async Task RandomUInt16_NonGeneric()
        {

            int generateCount = 100;
            ushort minValue = 0;
            ushort maxValue = 100;
            ushort offset = 100;
            string selector = $"x => System.Convert.ToUInt16(x + {offset})";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomFieldSettings()
                    {
                        ValueTypeName = "System.UInt16",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues<ushort>(generator, generateCount, (ushort)(minValue + offset), (ushort)(maxValue + offset));
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues<ushort>(reader, generateCount, (ushort)(minValue + offset), (ushort)(maxValue + offset));

        }

        #endregion

        #region int

        [TestMethod]
        public async Task RandomInt32()
        {

            int generateCount = 100;
            int minValue = -100;
            int maxValue = 200;
            int offset = 50;
            string selector = $"x => x + {offset}";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomInt32FieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue,
                        MaximumValue = maxValue,
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue + offset, maxValue + offset);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue + offset, maxValue + offset);

        }

        [TestMethod]
        public async Task RandomInt32_NonGeneric()
        {

            int generateCount = 100;
            int minValue = -100;
            int maxValue = 200;
            int offset = 50;
            string selector = $"x => x + {offset}";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomFieldSettings()
                    {
                        ValueTypeName = "System.Int32",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue + offset, maxValue + offset);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue + offset, maxValue + offset);

        }

        #endregion

        #region uint

        [TestMethod]
        public async Task RandomUInt32()
        {

            int generateCount = 100;
            uint minValue = 0;
            uint maxValue = 100;
            uint offset = 100;
            string selector = $"x => System.Convert.ToUInt32(x + {offset})";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomUInt32FieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue,
                        MaximumValue = maxValue,
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues<uint>(generator, generateCount, (uint)(minValue + offset), (uint)(maxValue + offset));
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues<uint>(reader, generateCount, (uint)(minValue + offset), (uint)(maxValue + offset));

        }

        [TestMethod]
        public async Task RandomUInt32_NonGeneric()
        {

            int generateCount = 100;
            uint minValue = 0;
            uint maxValue = 100;
            uint offset = 100;
            string selector = $"x => System.Convert.ToUInt32(x + {offset})";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomFieldSettings()
                    {
                        ValueTypeName = "System.UInt32",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues<uint>(generator, generateCount, (uint)(minValue + offset), (uint)(maxValue + offset));
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues<uint>(reader, generateCount, (uint)(minValue + offset), (uint)(maxValue + offset));

        }

        #endregion

        #region long

        [TestMethod]
        public async Task RandomInt64()
        {

            int generateCount = 100;
            long minValue = -100;
            long maxValue = 200;
            long offset = 50;
            string selector = $"x => x + {offset}";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomInt64FieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue,
                        MaximumValue = maxValue,
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue + offset, maxValue + offset);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue + offset, maxValue + offset);

        }

        [TestMethod]
        public async Task RandomInt64_NonGeneric()
        {

            int generateCount = 100;
            long minValue = -100;
            long maxValue = 200;
            long offset = 50;
            string selector = $"x => x + {offset}";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomFieldSettings()
                    {
                        ValueTypeName = "System.Int64",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue + offset, maxValue + offset);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue + offset, maxValue + offset);

        }

        #endregion

        #region ulong

        [TestMethod]
        public async Task RandomUInt64()
        {

            int generateCount = 100;
            ulong minValue = 0;
            ulong maxValue = 100;
            ulong offset = 100;
            string selector = $"x => System.Convert.ToUInt64(x + {offset})";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomUInt64FieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue,
                        MaximumValue = maxValue,
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues<ulong>(generator, generateCount, (ulong)(minValue + offset), (ulong)(maxValue + offset));
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues<ulong>(reader, generateCount, (ulong)(minValue + offset), (ulong)(maxValue + offset));

        }

        [TestMethod]
        public async Task RandomUInt64_NonGeneric()
        {

            int generateCount = 100;
            ulong minValue = 0;
            ulong maxValue = 100;
            ulong offset = 100;
            string selector = $"x => System.Convert.ToUInt64(x + {offset})";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomFieldSettings()
                    {
                        ValueTypeName = "System.UInt64",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues<ulong>(generator, generateCount, (ulong)(minValue + offset), (ulong)(maxValue + offset));
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues<ulong>(reader, generateCount, (ulong)(minValue + offset), (ulong)(maxValue + offset));

        }

        #endregion

        #region float

        [TestMethod]
        public async Task RandomSingle()
        {

            int generateCount = 100;
            float minValue = -100;
            float maxValue = 200;
            int decimals = 3;
            string selector = $"x => (float)System.Math.Round(x, {decimals})";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomSingleFieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue,
                        MaximumValue = maxValue,
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue - (float)Math.Pow(0.1, decimals), maxValue + (float)Math.Pow(0.1, decimals));
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue - (float)Math.Pow(0.1, decimals), maxValue + (float)Math.Pow(0.1, decimals));

        }

        [TestMethod]
        public async Task RandomSingle_NonGeneric()
        {

            int generateCount = 100;
            float minValue = -100;
            float maxValue = 200;
            int decimals = 3;
            string selector = $"x => (float)System.Math.Round(x, {decimals})";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomFieldSettings()
                    {
                        ValueTypeName = "System.Single",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue - (float)Math.Pow(0.1, decimals), maxValue + (float)Math.Pow(0.1, decimals));
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue - (float)Math.Pow(0.1, decimals), maxValue + (float)Math.Pow(0.1, decimals));

        }

        #endregion

        #region double

        [TestMethod]
        public async Task RandomDouble()
        {

            int generateCount = 100;
            double minValue = -100;
            double maxValue = 200;
            int decimals = 3;
            string selector = $"x => System.Math.Round(x, {decimals})";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomDoubleFieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue,
                        MaximumValue = maxValue,
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue - Math.Pow(0.1, decimals), maxValue + Math.Pow(0.1, decimals));
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue - Math.Pow(0.1, decimals), maxValue + Math.Pow(0.1, decimals));

        }

        [TestMethod]
        public async Task RandomDouble_NonGeneric()
        {

            int generateCount = 100;
            double minValue = -100;
            double maxValue = 200;
            int decimals = 3;
            string selector = $"x => System.Math.Round(x, {decimals})";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomFieldSettings()
                    {
                        ValueTypeName = "System.Double",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue - Math.Pow(0.1, decimals), maxValue + Math.Pow(0.1, decimals));
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue - Math.Pow(0.1, decimals), maxValue + Math.Pow(0.1, decimals));

        }

        #endregion

        #region decimal

        [TestMethod]
        public async Task RandomDecimal()
        {

            int generateCount = 100;
            decimal minValue = -100;
            decimal maxValue = 200;
            int decimals = 3;
            string selector = $"x => System.Math.Round(x, {decimals})";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomDecimalFieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue,
                        MaximumValue = maxValue,
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue - (decimal)Math.Pow(0.1, decimals), maxValue + (decimal)Math.Pow(0.1, decimals));
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue - (decimal)Math.Pow(0.1, decimals), maxValue + (decimal)Math.Pow(0.1, decimals));

        }

        [TestMethod]
        public async Task RandomDecimal_NonGeneric()
        {

            int generateCount = 100;
            decimal minValue = -100;
            decimal maxValue = 200;
            int decimals = 3;
            string selector = $"x => System.Math.Round(x, {decimals})";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomFieldSettings()
                    {
                        ValueTypeName = "System.Decimal",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue - (decimal)Math.Pow(0.1, decimals), maxValue + (decimal)Math.Pow(0.1, decimals));
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue - (decimal)Math.Pow(0.1, decimals), maxValue + (decimal)Math.Pow(0.1, decimals));

        }

        #endregion

        #region DateTime

        [TestMethod]
        public async Task RandomDateTime()
        {

            int generateCount = 100;
            DateTime minValue = DateTime.Now;
            DateTime maxValue = DateTime.Now.AddMonths(12);
            string selector = $"x => x.Date";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomDateTimeFieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue,
                        MaximumValue = maxValue,
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue.Date, maxValue);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue.Date, maxValue);

        }

        [TestMethod]
        public async Task RandomDateTime_NonGeneric()
        {

            int generateCount = 100;
            DateTime minValue = DateTime.Now;
            DateTime maxValue = DateTime.Now.AddMonths(12);
            string selector = $"x => x.Date";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomFieldSettings()
                    {
                        ValueTypeName = "System.DateTime",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue.Date, maxValue);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue.Date, maxValue);

        }

        #endregion

        #region DateTimeOffset

        [TestMethod]
        public async Task RandomDateTimeOffset()
        {

            int generateCount = 100;
            DateTimeOffset minValue = DateTimeOffset.Now;
            DateTimeOffset maxValue = DateTimeOffset.Now.AddMonths(12);
            string selector = $"x => x.Date";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomDateTimeOffsetFieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue,
                        MaximumValue = maxValue,
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue.Date, maxValue);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue.Date, maxValue);

        }

        [TestMethod]
        public async Task RandomDateTimeOffset_NonGeneric()
        {

            int generateCount = 100;
            DateTimeOffset minValue = DateTimeOffset.Now;
            DateTimeOffset maxValue = DateTimeOffset.Now.AddMonths(12);
            string selector = $"x => x.Date";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomFieldSettings()
                    {
                        ValueTypeName = "System.DateTimeOffset",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue.Date, maxValue);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue.Date, maxValue);

        }

        #endregion

        #region TimeSpan

        [TestMethod]
        public async Task RandomTimeSpan()
        {

            int generateCount = 100;
            TimeSpan minValue = TimeSpan.Zero;
            TimeSpan maxValue = TimeSpan.FromDays(1);
            int offsetDays = 1;
            string selector = $"x => x.Add(System.TimeSpan.FromDays({offsetDays}))";
            
            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomTimeSpanFieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue,
                        MaximumValue = maxValue,
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue.Add(TimeSpan.FromDays(offsetDays)), maxValue.Add(TimeSpan.FromDays(offsetDays)));
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue.Add(TimeSpan.FromDays(offsetDays)), maxValue.Add(TimeSpan.FromDays(offsetDays)));

        }

        [TestMethod]
        public async Task RandomTimeSpan_NonGeneric()
        {

            int generateCount = 100;
            TimeSpan minValue = TimeSpan.Zero;
            TimeSpan maxValue = TimeSpan.FromDays(1);
            int offsetDays = 1;
            string selector = $"x => x.Add(System.TimeSpan.FromDays({offsetDays}))";

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomFieldSettings()
                    {
                        ValueTypeName = "System.TimeSpan",
                        FieldName = "field1",
                        NullProbability = 0.1,
                        MinimumValue = minValue.ToString(),
                        MaximumValue = maxValue.ToString(),
                        SelectorExpression = selector
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount, minValue.Add(TimeSpan.FromDays(offsetDays)), maxValue.Add(TimeSpan.FromDays(offsetDays)));
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount, minValue.Add(TimeSpan.FromDays(offsetDays)), maxValue.Add(TimeSpan.FromDays(offsetDays)));

        }

        #endregion

        #region Guid

        [TestMethod]
        public async Task RandomGuid()
        {

            int generateCount = 100;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomGuidFieldSettings()
                    {
                        FieldName = "field1",
                        NullProbability = 0.1,
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount);

        }

        [TestMethod]
        public async Task RandomGuid_NonGeneric()
        {

            int generateCount = 100;

            DataGeneratorSettings settings = new()
            {
                Fields = new DataGeneratorFieldSettings[]
                {
                    new RandomFieldSettings()
                    {
                        ValueTypeName = "System.Guid",
                        FieldName = "field1",
                        NullProbability = 0.1,
                    }
                }
            };

            TestUtility.AssertJsonSerialize(ref settings);

            DataGeneratorContext context = new DataGeneratorContext();

            var builder = settings.CreateBuilder(context);

            // dataGenerator
            using (var generator = await builder.BuildAsync(generateCount).ConfigureAwait(false))
            {
                EnumerateValues(generator, generateCount);
            }

            // dataReader
            using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

            EnumerateValues(reader, generateCount);

        }

        #endregion


        private static void EnumerateValues<T>(DataGenerator generator, int expectedCount, T minValue, T maxValue)
            where T : struct, IComparable<T>
        {
            int count = 0;

            while (generator.GenerateNext())
            {
                if (!generator.GetFieldValueIsNull(0))
                {
                    var value = (T)generator.GetFieldRawValue(0)!;
                    Assert.AreEqual(true, value.CompareTo(minValue) >= 0 && value.CompareTo(maxValue) <= 0);
                }

                ++count;
            }

            Assert.AreEqual(expectedCount, count);
        }

        private static void EnumerateValues<T>(IDataGenerationReader reader, int expectedCount, T minValue, T maxValue)
            where T : struct, IComparable<T>
        {
            int count = 0;

            StringBuilder sb = new();

            TestUtility.DumpHeader(reader, sb);

            while (reader.Read())
            {
                TestUtility.DumpRecord(reader, sb);

                if (!reader.IsDBNull(0))
                {
                    var value = reader.GetRawValue<T>(0);
                    Assert.AreEqual(true, value!.Value.CompareTo(minValue) >= 0 && value!.Value.CompareTo(maxValue) <= 0);
                }

                ++count;
            }

            Debug.WriteLine(sb.ToString());

            Assert.AreEqual(expectedCount, count);
        }

        private static void EnumerateValues(DataGenerator generator, int expectedCount)
        {
            int count = 0;

            while (generator.GenerateNext())
            {
                if (!generator.GetFieldValueIsNull(0))
                {
                    var _ = generator.GetFieldRawValue(0)!;
                }

                ++count;
            }

            Assert.AreEqual(expectedCount, count);
        }

        private static void EnumerateValues(IDataGenerationReader reader, int expectedCount)
        {
            int count = 0;

            StringBuilder sb = new();

            TestUtility.DumpHeader(reader, sb);

            while (reader.Read())
            {
                TestUtility.DumpRecord(reader, sb);

                if (!reader.IsDBNull(0))
                {
                    var _ = reader.GetValue(0);
                }

                ++count;
            }

            Debug.WriteLine(sb.ToString());

            Assert.AreEqual(expectedCount, count);
        }

    }

}
