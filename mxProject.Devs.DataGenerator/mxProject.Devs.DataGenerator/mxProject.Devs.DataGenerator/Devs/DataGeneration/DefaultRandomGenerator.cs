using System;
using System.Collections.Generic;
using System.Text;
using System.Buffers;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Random value generation logic.
    /// </summary>
    public class DefaultRandomGenerator : IRandomGenerator
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public DefaultRandomGenerator()
        {
            m_Random = new Random();
        }

        private readonly Random m_Random;

        /// <summary>
        /// Singleton instance.
        /// </summary>
        internal static readonly DefaultRandomGenerator Instance = new DefaultRandomGenerator();


        /// <inheritdoc/>
        /// <returns></returns>
        public bool NextBoolean(double trueProbability)
        {
            return m_Random.NextDouble() <= trueProbability;
        }

        /// <inheritdoc/>
        public byte NextByte(byte minValue, byte maxValue)
        {
            return (byte)m_Random.Next(minValue, maxValue);
        }

        /// <inheritdoc/>
        public short NextInt16(short minValue, short maxValue)
        {
            return (short)m_Random.Next(minValue, maxValue);
        }

        /// <inheritdoc/>
        public int NextInt32(int minValue, int maxValue)
        {
            return m_Random.Next(minValue, maxValue);
        }

        /// <inheritdoc/>
        public long NextInt64(long minValue, long maxValue)
        {

            if (maxValue <= minValue)
            {
                throw new ArgumentOutOfRangeException(nameof(maxValue), "max must be > min!");
            }

            ulong uRange = (ulong)(maxValue - minValue);
            ulong ulongRand;

            byte[] buffer = new byte[8];

            do
            {
                m_Random.NextBytes(buffer);

                ulongRand = (ulong)BitConverter.ToInt64(buffer, 0);

            } while (ulongRand > ulong.MaxValue - ((ulong.MaxValue % uRange) + 1) % uRange);

            return (long)(ulongRand % uRange) + minValue;

        }

        /// <inheritdoc/>
        public float NextSingle(float minValue, float maxValue)
        {
            return (float)NextDouble(minValue, maxValue);
        }

        /// <inheritdoc/>
        public double NextDouble(double minValue, double maxValue)
        {
            double r = m_Random.NextDouble();
            return minValue + maxValue * r - minValue * r;
        }

        /// <inheritdoc/>
        public decimal NextDecimal(decimal minValue, decimal maxValue)
        {
            decimal r = (decimal)m_Random.NextDouble();
            return minValue + maxValue * r - minValue * r;
        }

        /// <inheritdoc/>
        public sbyte NextSByte(sbyte minValue, sbyte maxValue)
        {
            return (sbyte)NextInt32(minValue, maxValue);
        }

        /// <inheritdoc/>
        public ushort NextUInt16(ushort minValue, ushort maxValue)
        {
            return (ushort)NextInt32(minValue, maxValue);
        }

        /// <inheritdoc/>
        public uint NextUInt32(uint minValue, uint maxValue)
        {
            double r = m_Random.NextDouble();
            return minValue + (uint)((maxValue - minValue) * r);
        }

        /// <inheritdoc/>
        public ulong NextUInt64(ulong minValue, ulong maxValue)
        {
            double r = m_Random.NextDouble();
            return minValue + (ulong)((maxValue - minValue) * r);
        }

        /// <inheritdoc/>
        public DateTime NextDateTime(DateTime minValue, DateTime maxValue)
        {
            return new DateTime(NextInt64(minValue.Ticks, maxValue.Ticks));
        }

        /// <inheritdoc/>
        public DateTimeOffset NextDateTimeOffset(DateTimeOffset minValue, DateTimeOffset maxValue)
        {
            return new DateTimeOffset(NextInt64(minValue.ToLocalTime().Ticks, maxValue.ToLocalTime().Ticks), minValue.Offset);
        }

        /// <inheritdoc/>
        public TimeSpan NextTimeSpan(TimeSpan minValue, TimeSpan maxValue)
        {
            return new TimeSpan(NextInt64(minValue.Ticks, maxValue.Ticks));
        }

    }

}
