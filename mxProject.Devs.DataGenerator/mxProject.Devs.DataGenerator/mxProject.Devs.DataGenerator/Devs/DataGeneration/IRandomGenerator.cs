using System;
using System.Collections.Generic;
using System.Text;
using System.Buffers;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Provides the functionality needed to generate random values.
    /// </summary>
    public interface IRandomGenerator
    {

        /// <summary>
        /// Generates a Boolean value.
        /// </summary>
        /// <param name="trueProbability">probability of returning true. (between 0 and 1.0)</param>
        /// <returns></returns>
        bool NextBoolean(double trueProbability);

        /// <summary>
        /// Generates a Byte value.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns></returns>
        byte NextByte(byte minValue, byte maxValue);

        /// <summary>
        /// Generates an Int16 value.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns></returns>
        short NextInt16(short minValue, short maxValue);

        /// <summary>
        /// Generates an Int32 value.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns></returns>
        int NextInt32(int minValue, int maxValue);

        /// <summary>
        /// Generates an Int64 value.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns></returns>
        long NextInt64(long minValue, long maxValue);

        /// <summary>
        /// Generates a Single value.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns></returns>
        float NextSingle(float minValue, float maxValue);

        /// <summary>
        /// Generates a Double value.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns></returns>
        double NextDouble(double minValue, double maxValue);

        /// <summary>
        /// Generates a Decimal value.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns></returns>
        decimal NextDecimal(decimal minValue, decimal maxValue);

        /// <summary>
        /// Generates a SByte value.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns></returns>
        sbyte NextSByte(sbyte minValue, sbyte maxValue);

        /// <summary>
        /// Generates a UInt16 value.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns></returns>
        ushort NextUInt16(ushort minValue, ushort maxValue);

        /// <summary>
        /// Generates a UInt32 value.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns></returns>
        uint NextUInt32(uint minValue, uint maxValue);

        /// <summary>
        /// Generates a UInt64 value.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns></returns>
        ulong NextUInt64(ulong minValue, ulong maxValue);

        /// <summary>
        /// Generates a DateTime value.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns></returns>
        DateTime NextDateTime(DateTime minValue, DateTime maxValue);

        /// <summary>
        /// Generates a DateTimeOffset value.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns></returns>
        DateTimeOffset NextDateTimeOffset(DateTimeOffset minValue, DateTimeOffset maxValue);

        /// <summary>
        /// Generates a TimeSpan value.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns></returns>
        TimeSpan NextTimeSpan(TimeSpan minValue, TimeSpan maxValue);

    }

}
