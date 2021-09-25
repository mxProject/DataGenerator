using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Data;

namespace mxProject.Devs.DataGeneration
{
    partial class EnumerableFactory
    {

        #region bool

        /// <summary>
        /// Enumerates random values of type Boolean or null.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="trueProbability">probability of returning true. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IEnumerable<bool> RandomBoolean(int count, double trueProbability)
        {
            for (int i = 0; i < count; ++i)
            {
                yield return RandomGenerator.NextBoolean(trueProbability);
            }
        }

        /// <summary>
        /// Enumerates random values of type Boolean or null.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="trueProbability">probability of returning true. (between 0 and 1.0)</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IEnumerable<bool?> RandomBooleanOrNull(int count, double trueProbability, double nullProbability)
        {
            for (int i = 0; i < count; ++i)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else
                {
                    yield return RandomGenerator.NextBoolean(trueProbability);
                }
            }
        }

        #endregion

        #region byte

        /// <summary>
        /// Enumerates random values of type Byte.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<byte> RandomByte(int count, byte minValue, byte maxValue, Func<byte, byte>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                var value = RandomGenerator.NextByte(minValue, maxValue);
                yield return selector == null ? value : selector(value);
            }
        }

        /// <summary>
        /// Enumerates random values of type Byte or null.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<byte?> RandomByteOrNull(int count, byte minValue, byte maxValue, double nullProbability, Func<byte, byte>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else
                {
                    var value = RandomGenerator.NextByte(minValue, maxValue);
                    yield return selector == null ? value : selector(value);
                }
            }
        }

        #endregion

        #region short

        /// <summary>
        /// Enumerates random values of type Int16.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<short> RandomInt16(int count, short minValue, short maxValue, Func<short, short>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                var value = RandomGenerator.NextInt16(minValue, maxValue);
                yield return selector == null ? value : selector(value);
            }
        }

        /// <summary>
        /// Enumerates random values of type Int16 or null.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<short?> RandomInt16OrNull(int count, short minValue, short maxValue, double nullProbability, Func<short, short>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else
                {
                    var value = RandomGenerator.NextInt16(minValue, maxValue);
                    yield return selector == null ? value : selector(value);
                }
            }
        }

        #endregion

        #region int

        /// <summary>
        /// Enumerates random values of type Int32.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<int> RandomInt32(int count, int minValue, int maxValue, Func<int, int>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                var value = RandomGenerator.NextInt32(minValue, maxValue);
                yield return selector == null ? value : selector(value);
            }
        }

        /// <summary>
        /// Enumerates random values of type Int32 or null.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<int?> RandomInt32OrNull(int count, int minValue, int maxValue, double nullProbability, Func<int, int>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else
                {
                    var value = RandomGenerator.NextInt32(minValue, maxValue);
                    yield return selector == null ? value : selector(value);
                }
            }
        }

        #endregion

        #region long

        /// <summary>
        /// Enumerates random values of type Int64.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<long> RandomInt64(int count, long minValue, long maxValue, Func<long, long>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                var value = RandomGenerator.NextInt64(minValue, maxValue);
                yield return selector == null ? value : selector(value);
            }
        }

        /// <summary>
        /// Enumerates random values of type Int64 or null.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<long?> RandomInt64OrNull(int count, long minValue, long maxValue, double nullProbability, Func<long, long>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else
                {
                    var value = RandomGenerator.NextInt64(minValue, maxValue);
                    yield return selector == null ? value : selector(value);
                }
            }
        }

        #endregion

        #region float

        /// <summary>
        /// Enumerates random values of type Single.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<float> RandomSingle(int count, float minValue, float maxValue, Func<float, float>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                var value = RandomGenerator.NextSingle(minValue, maxValue);
                yield return selector == null ? value : selector(value);
            }
        }

        /// <summary>
        /// Enumerates random values of type Single or null.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<float?> RandomSingleOrNull(int count, float minValue, float maxValue, double nullProbability, Func<float, float>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else
                {
                    var value = RandomGenerator.NextSingle(minValue, maxValue);
                    yield return selector == null ? value : selector(value);
                }
            }
        }

        #endregion

        #region double

        /// <summary>
        /// Enumerates random values of type Double.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<double> RandomDouble(int count, double minValue, double maxValue, Func<double, double>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                var value = RandomGenerator.NextDouble(minValue, maxValue);
                yield return selector == null ? value : selector(value);
            }
        }

        /// <summary>
        /// Enumerates random values of type Double or null.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<double?> RandomDoubleOrNull(int count, double minValue, double maxValue, double nullProbability, Func<double, double>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else
                {
                    var value = RandomGenerator.NextDouble(minValue, maxValue);
                    yield return selector == null ? value : selector(value);
                }
            }
        }

        #endregion

        #region decimal

        /// <summary>
        /// Enumerates random values of type Decimal.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<decimal> RandomDecimal(int count, decimal minValue, decimal maxValue, Func<decimal, decimal>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                var value = RandomGenerator.NextDecimal(minValue, maxValue);
                yield return selector == null ? value : selector(value);
            }
        }

        /// <summary>
        /// Enumerates random values of type Decimal or null.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<decimal?> RandomDecimalOrNull(int count, decimal minValue, decimal maxValue, double nullProbability, Func<decimal, decimal>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else
                {
                    var value = RandomGenerator.NextDecimal(minValue, maxValue);
                    yield return selector == null ? value : selector(value);
                }
            }
        }

        #endregion

        #region sbyte

        /// <summary>
        /// Enumerates random values of type SByte.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<sbyte> RandomSByte(int count, sbyte minValue, sbyte maxValue, Func<sbyte, sbyte>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                var value = RandomGenerator.NextSByte(minValue, maxValue);
                yield return selector == null ? value : selector(value);
            }
        }

        /// <summary>
        /// Enumerates random values of type SByte or null.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<sbyte?> RandomSByteOrNull(int count, sbyte minValue, sbyte maxValue, double nullProbability, Func<sbyte, sbyte>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else
                {
                    var value = RandomGenerator.NextSByte(minValue, maxValue);
                    yield return selector == null ? value : selector(value);
                }
            }
        }

        #endregion

        #region ushort

        /// <summary>
        /// Enumerates random values of type UInt16.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<ushort> RandomUInt16(int count, ushort minValue, ushort maxValue, Func<ushort, ushort>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                var value = RandomGenerator.NextUInt16(minValue, maxValue);
                yield return selector == null ? value : selector(value);
            }
        }

        /// <summary>
        /// Enumerates random values of type UInt6 or null.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<ushort?> RandomUInt16OrNull(int count, ushort minValue, ushort maxValue, double nullProbability, Func<ushort, ushort>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else
                {
                    var value = RandomGenerator.NextUInt16(minValue, maxValue);
                    yield return selector == null ? value : selector(value);
                }
            }
        }

        #endregion

        #region uint

        /// <summary>
        /// Enumerates random values of type UInt32.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<uint> RandomUInt32(int count, uint minValue, uint maxValue, Func<uint, uint>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                var value = RandomGenerator.NextUInt32(minValue, maxValue);
                yield return selector == null ? value : selector(value);
            }
        }

        /// <summary>
        /// Enumerates random values of type UInt32 or null.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<uint?> RandomUInt32OrNull(int count, uint minValue, uint maxValue, double nullProbability, Func<uint, uint>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else
                {
                    var value = RandomGenerator.NextUInt32(minValue, maxValue);
                    yield return selector == null ? value : selector(value);
                }
            }
        }

        #endregion

        #region ulong

        /// <summary>
        /// Enumerates random values of type UInt64.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<ulong> RandomUInt64(int count, ulong minValue, ulong maxValue, Func<ulong, ulong>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                var value = RandomGenerator.NextUInt64(minValue, maxValue);
                yield return selector == null ? value : selector(value);
            }
        }

        /// <summary>
        /// Enumerates random values of type UInt64 or null.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<ulong?> RandomUInt64OrNull(int count, ulong minValue, ulong maxValue, double nullProbability, Func<ulong, ulong>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else
                {
                    var value = RandomGenerator.NextUInt64(minValue, maxValue);
                    yield return selector == null ? value : selector(value);
                }
            }
        }

        #endregion

        #region DateTime

        /// <summary>
        /// Enumerates random values of type DateTime.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<DateTime> RandomDateTime(int count, DateTime minValue, DateTime maxValue, Func<DateTime, DateTime>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                var value = RandomGenerator.NextDateTime(minValue, maxValue);
                yield return selector == null ? value : selector(value);
            }
        }

        /// <summary>
        /// Enumerates random values of type DateTime or null.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<DateTime?> RandomDateTimeOrNull(int count, DateTime minValue, DateTime maxValue, double nullProbability, Func<DateTime, DateTime>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else
                {
                    var value = RandomGenerator.NextDateTime(minValue, maxValue);
                    yield return selector == null ? value : selector(value);
                }
            }
        }

        #endregion

        #region DateTimeOffset

        /// <summary>
        /// Enumerates random values of type DateTimeOffset.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<DateTimeOffset> RandomDateTimeOffset(int count, DateTimeOffset minValue, DateTimeOffset maxValue, Func<DateTimeOffset, DateTimeOffset>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                var value = RandomGenerator.NextDateTimeOffset(minValue, maxValue);
                yield return selector == null ? value : selector(value);
            }
        }

        /// <summary>
        /// Enumerates random values of type DateTimeOffset or null.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<DateTimeOffset?> RandomDateTimeOffsetOrNull(int count, DateTimeOffset minValue, DateTimeOffset maxValue, double nullProbability, Func<DateTimeOffset, DateTimeOffset>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else
                {
                    var value = RandomGenerator.NextDateTimeOffset(minValue, maxValue);
                    yield return selector == null ? value : selector(value);
                }
            }
        }

        #endregion

        #region TimeSpan

        /// <summary>
        /// Enumerates random values of type TimeSpan.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<TimeSpan> RandomTimeSpan(int count, TimeSpan minValue, TimeSpan maxValue, Func<TimeSpan, TimeSpan>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                var value = RandomGenerator.NextTimeSpan(minValue, maxValue);
                yield return selector == null ? value : selector(value);
            }
        }

        /// <summary>
        /// Enumerates random values of type TimeSpan or null.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <returns></returns>
        public IEnumerable<TimeSpan?> RandomTimeSpanOrNull(int count, TimeSpan minValue, TimeSpan maxValue, double nullProbability, Func<TimeSpan, TimeSpan>? selector = null)
        {
            for (int i = 0; i < count; ++i)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else
                {
                    var value = RandomGenerator.NextTimeSpan(minValue, maxValue);
                    yield return selector == null ? value : selector(value);
                }
            }
        }

        #endregion

        #region Guid

        /// <summary>
        /// Enumerates random values of type Guid.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <returns></returns>
        public IEnumerable<Guid> RandomGuid(int count)
        {
            for (int i = 0; i < count; ++i)
            {
                yield return Guid.NewGuid();
            }
        }

        /// <summary>
        /// Enumerates random values of type TimeSpan or null.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IEnumerable<Guid?> RandomGuidOrNull(int count, double nullProbability)
        {
            for (int i = 0; i < count; ++i)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else
                {
                    yield return Guid.NewGuid();
                }
            }
        }

        #endregion

    }
}
