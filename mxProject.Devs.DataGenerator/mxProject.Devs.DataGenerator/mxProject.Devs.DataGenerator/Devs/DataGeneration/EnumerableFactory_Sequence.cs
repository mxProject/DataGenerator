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

        #region byte

        /// <summary>
        /// Enumerates Byte sequencial values.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public IEnumerable<byte> SequenceByte(byte initialValue, byte maxValue, byte increment = 1)
        {
            for (byte i = initialValue; i <= maxValue; i += increment)
            {
                yield return i;
            }
        }

        /// <summary>
        /// Gets the number of values that will be enumerated from the sequence.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public int? GetSequencialValueCount(byte initialValue, byte maxValue, byte increment = 1)
        {
            return (int)Math.Ceiling((maxValue - initialValue + 1) / (decimal)increment);
        }

        #endregion

        #region sbyte

        /// <summary>
        /// Enumerates SByte sequencial values.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public IEnumerable<sbyte> SequenceSByte(sbyte initialValue, sbyte maxValue, sbyte increment = 1)
        {
            for (sbyte i = initialValue; i <= maxValue; i += increment)
            {
                yield return i;
            }
        }

        /// <summary>
        /// Gets the number of values that will be enumerated from the sequence.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public int? GetSequencialValueCount(sbyte initialValue, sbyte maxValue, sbyte increment = 1)
        {
            return (int)Math.Ceiling((maxValue - initialValue + 1) / (decimal)increment);
        }

        #endregion

        #region short

        /// <summary>
        /// Enumerates Int16 sequencial values.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public IEnumerable<short> SequenceInt16(short initialValue, short maxValue, short increment = 1)
        {
            for (short i = initialValue; i <= maxValue; i += increment)
            {
                yield return i;
            }
        }

        /// <summary>
        /// Gets the number of values that will be enumerated from the sequence.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public int? GetSequencialValueCount(short initialValue, short maxValue, short increment = 1)
        {
            return (int)Math.Ceiling((maxValue - initialValue + 1) / (decimal)increment);
        }

        #endregion

        #region ushort

        /// <summary>
        /// Enumerates UInt16 sequencial values.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public IEnumerable<ushort> SequenceUInt16(ushort initialValue, ushort maxValue, ushort increment = 1)
        {
            for (ushort i = initialValue; i <= maxValue; i += increment)
            {
                yield return i;
            }
        }

        /// <summary>
        /// Gets the number of values that will be enumerated from the sequence.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public int? GetSequencialValueCount(ushort initialValue, ushort maxValue, ushort increment = 1)
        {
            return (int)Math.Ceiling((maxValue - initialValue + 1) / (decimal)increment);
        }

        #endregion

        #region int

        /// <summary>
        /// Enumerates Int32 sequencial values.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public IEnumerable<int> SequenceInt32(int initialValue, int maxValue, int increment = 1)
        {
            for (int i = initialValue; i <= maxValue; i += increment)
            {
                yield return i;
            }
        }

        /// <summary>
        /// Gets the number of values that will be enumerated from the sequence.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public int? GetSequencialValueCount(int initialValue, int maxValue, int increment = 1)
        {
            return (int)Math.Ceiling((maxValue - initialValue + 1) / (decimal)increment);
        }

        #endregion

        #region uint

        /// <summary>
        /// Enumerates UInt32 sequencial values.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public IEnumerable<uint> SequenceUInt32(uint initialValue, uint maxValue, uint increment = 1)
        {
            for (uint i = initialValue; i <= maxValue; i += increment)
            {
                yield return i;
            }
        }

        /// <summary>
        /// Gets the number of values that will be enumerated from the sequence.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public int? GetSequencialValueCount(uint initialValue, uint maxValue, int increment = 1)
        {
            return (int)Math.Ceiling((maxValue - initialValue + 1) / (decimal)increment);
        }

        #endregion

        #region long

        /// <summary>
        /// Enumerates Int64 sequencial values.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public IEnumerable<long> SequenceInt64(long initialValue, long maxValue, long increment = 1)
        {
            for (long i = initialValue; i <= maxValue; i += increment)
            {
                yield return i;
            }
        }

        /// <summary>
        /// Gets the number of values that will be enumerated from the sequence.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public int? GetSequencialValueCount(long initialValue, long maxValue, long increment = 1)
        {
            return (int)Math.Ceiling((maxValue - initialValue + 1) / (decimal)increment);
        }

        #endregion

        #region ulong

        /// <summary>
        /// Enumerates UInt64 sequencial values.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public IEnumerable<ulong> SequenceUInt64(ulong initialValue, ulong maxValue, ulong increment = 1)
        {
            for (ulong i = initialValue; i <= maxValue; i += increment)
            {
                yield return i;
            }
        }

        /// <summary>
        /// Gets the number of values that will be enumerated from the sequence.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public int? GetSequencialValueCount(ulong initialValue, ulong maxValue, ulong increment = 1)
        {
            return (int)Math.Ceiling((maxValue - initialValue + 1) / (decimal)increment);
        }

        #endregion

        #region DateTime

        /// <summary>
        /// Enumerates DateTime sequencial values.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public IEnumerable<DateTime> SequenceDateTime(DateTime initialValue, DateTime maxValue, TimeSpan increment)
        {
            DateTime d = initialValue;

            while (d <= maxValue)
            {
                yield return d;
                d = d.Add(increment);
            }
        }

        /// <summary>
        /// Enumerates DateTime sequencial values.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="incrementMonths">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public IEnumerable<DateTime> SequenceDateMonth(DateTime initialValue, DateTime maxValue, int incrementMonths)
        {
            static DateTime AddDays(DateTime datetime, int day)
            {
                var result = datetime.AddDays(day - 1);

                if (result.Month == datetime.Month)
                {
                    return result;
                }
                else
                {
                    return result.AddDays(-result.Day);
                }
            }

            int day = initialValue.Day;
            DateTime d = initialValue.AddDays(-day + 1);

            while (d <= maxValue)
            {
                yield return AddDays(d, day);
                d = d.AddMonths(incrementMonths);
            }
        }

        /// <summary>
        /// Gets the number of values that will be enumerated from the sequence.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public int? GetSequencialValueCount(DateTime initialValue, DateTime maxValue, TimeSpan increment)
        {
            return (int)Math.Ceiling(((maxValue - initialValue).TotalMilliseconds + 1) / increment.TotalMilliseconds);
        }

        /// <summary>
        /// Gets the number of values that will be enumerated from the sequence.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="incrementMonths">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public int? GetSequencialValueCount(DateTime initialValue, DateTime maxValue, int incrementMonths)
        {
            static int GetMonths(DateTime dateTime)
            {
                return dateTime.Month + dateTime.Year * 12;
            }

            return (int)Math.Ceiling((GetMonths(maxValue) - GetMonths(initialValue) + 1) / (decimal)incrementMonths);
        }

        #endregion

        #region DateTimeOffset

        /// <summary>
        /// Enumerates DateTimeOffset sequencial values.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public IEnumerable<DateTimeOffset> SequenceDateTimeOffset(DateTimeOffset initialValue, DateTimeOffset maxValue, TimeSpan increment)
        {
            DateTimeOffset d = initialValue;

            while (d <= maxValue)
            {
                yield return d;
                d = d.Add(increment);
            }
        }

        /// <summary>
        /// Enumerates DateTimeOffset sequencial values.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="incrementMonths">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public IEnumerable<DateTimeOffset> SequenceDateMonthOffset(DateTimeOffset initialValue, DateTimeOffset maxValue, int incrementMonths)
        {
            static DateTimeOffset AddDays(DateTimeOffset datetime, int day)
            {
                var result = datetime.AddDays(day - 1);

                if (result.Month == datetime.Month)
                {
                    return result;
                }
                else
                {
                    return result.AddDays(-result.Day);
                }
            }

            int day = initialValue.Day;
            DateTimeOffset d = initialValue.AddDays(-day + 1);

            while (d <= maxValue)
            {
                yield return AddDays(d, day);
                d = d.AddMonths(incrementMonths);
            }
        }

        /// <summary>
        /// Gets the number of values that will be enumerated from the sequence.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public int? GetSequencialValueCount(DateTimeOffset initialValue, DateTimeOffset maxValue, TimeSpan increment)
        {
            return (int)Math.Ceiling(((maxValue - initialValue).TotalMilliseconds + 1) / increment.TotalMilliseconds);
        }

        /// <summary>
        /// Gets the number of values that will be enumerated from the sequence.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="incrementMonths">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public int? GetSequencialValueCount(DateTimeOffset initialValue, DateTimeOffset maxValue, int incrementMonths)
        {
            static int GetMonths(DateTimeOffset dateTime)
            {
                return dateTime.Month + dateTime.Year * 12;
            }

            return (int)Math.Ceiling((GetMonths(maxValue) - GetMonths(initialValue) + 1) / (decimal)incrementMonths);
        }

        #endregion

        #region TimeSpan

        /// <summary>
        /// Enumerates TimeSpan sequencial values.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public IEnumerable<TimeSpan> SequenceTimeSpan(TimeSpan initialValue, TimeSpan maxValue, TimeSpan increment)
        {
            TimeSpan t = initialValue;

            while (t <= maxValue)
            {
                yield return t;
                t = t.Add(increment);
            }
        }

        /// <summary>
        /// Gets the number of values that will be enumerated from the sequence.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">Amount of increase in value when creating a new sequence value.</param>
        /// <returns></returns>
        public int? GetSequencialValueCount(TimeSpan initialValue, TimeSpan maxValue, TimeSpan increment)
        {
            return (int)Math.Ceiling(((maxValue - initialValue).TotalMilliseconds + 1) / increment.TotalMilliseconds);
        }

        #endregion

    }
}
