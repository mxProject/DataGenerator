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

using UnitTestProject1.Extensions;

namespace UnitTestProject1
{

    [TestClass]
    public class TestSequence
    {

        #region byte

        [TestMethod]
        public void SequenceByte()
        {

            EnumerableFactory factory = new();

            byte minValue = 50;
            byte maxValue = 100;
            byte increment = 3;

            var values = factory.SequenceByte(minValue, maxValue, increment);

            EnumerateValues(values, minValue, maxValue, x => (byte)(x + increment));

        }

        #endregion

        #region sbyte

        [TestMethod]
        public void SequenceSByte()
        {

            EnumerableFactory factory = new();

            sbyte minValue = -50;
            sbyte maxValue = 100;
            sbyte increment = 3;

            var values = factory.SequenceSByte(minValue, maxValue, increment);

            EnumerateValues(values, minValue, maxValue, x => (sbyte)(x + increment));

        }

        #endregion

        #region short

        [TestMethod]
        public void SequenceInt16()
        {

            EnumerableFactory factory = new();

            short minValue = -50;
            short maxValue = 100;
            short increment = 3;

            var values = factory.SequenceInt16(minValue, maxValue, increment);

            EnumerateValues(values, minValue, maxValue, x => (short)(x + increment));

        }

        #endregion

        #region ushort

        [TestMethod]
        public void SequenceUInt16()
        {

            EnumerableFactory factory = new();

            ushort minValue = 50;
            ushort maxValue = 100;
            ushort increment = 3;

            var values = factory.SequenceUInt16(minValue, maxValue, increment);

            EnumerateValues(values, minValue, maxValue, x => (ushort)(x + increment));

        }

        #endregion

        #region int

        [TestMethod]
        public void SequenceInt32()
        {

            EnumerableFactory factory = new();

            int minValue = -50;
            int maxValue = 100;
            int increment = 3;

            var values = factory.SequenceInt32(minValue, maxValue, increment);

            EnumerateValues(values, minValue, maxValue, x => x + increment);

        }

        #endregion

        #region uint

        [TestMethod]
        public void SequenceUInt32()
        {

            EnumerableFactory factory = new();

            uint minValue = 50;
            uint maxValue = 100;
            uint increment = 3;

            var values = factory.SequenceUInt32(minValue, maxValue, increment);

            EnumerateValues(values, minValue, maxValue, x => x + increment);

        }

        #endregion

        #region long

        [TestMethod]
        public void SequenceInt64()
        {

            EnumerableFactory factory = new();

            long minValue = -50;
            long maxValue = 100;
            long increment = 3;

            var values = factory.SequenceInt64(minValue, maxValue, increment);

            EnumerateValues(values, minValue, maxValue, x => x + increment);

        }

        #endregion

        #region ulong

        [TestMethod]
        public void SequenceUInt64()
        {

            EnumerableFactory factory = new();

            ulong minValue = 50;
            ulong maxValue = 100;
            ulong increment = 3;

            var values = factory.SequenceUInt64(minValue, maxValue, increment);

            EnumerateValues(values, minValue, maxValue, x => x + increment);

        }

        #endregion

        #region DateTime

        [TestMethod]
        public void SequenceDateTime()
        {

            EnumerableFactory factory = new();

            DateTime minValue = DateTime.Today;
            DateTime maxValue = DateTime.Today.AddMonths(1);
            TimeSpan increment = TimeSpan.FromHours(20);

            var values = factory.SequenceDateTime(minValue, maxValue, increment);

            EnumerateValues(values, minValue, maxValue, x => x + increment);

        }

        [TestMethod]
        public void SequenceDateMonth()
        {

            EnumerableFactory factory = new();

            DateTime minValue = DateTime.Today;
            DateTime maxValue = DateTime.Today.AddMonths(12);
            int increment = 3;

            var values = factory.SequenceDateMonth(minValue, maxValue, increment);

            EnumerateValues(values, minValue, maxValue, x => x.AddMonths(increment));

        }

        #endregion

        #region DateTimeOffset

        [TestMethod]
        public void SequenceDateTimeOffset()
        {

            EnumerableFactory factory = new();

            DateTimeOffset minValue = DateTime.Today;
            DateTimeOffset maxValue = DateTime.Today.AddMonths(1);
            TimeSpan increment = TimeSpan.FromHours(20);

            var values = factory.SequenceDateTimeOffset(minValue, maxValue, increment);

            EnumerateValues(values, minValue, maxValue, x => x + increment);

        }

        [TestMethod]
        public void SequenceDateMonthOffset()
        {

            EnumerableFactory factory = new();

            DateTimeOffset minValue = DateTime.Today;
            DateTimeOffset maxValue = DateTime.Today.AddMonths(12);
            int increment = 3;

            var values = factory.SequenceDateMonthOffset(minValue, maxValue, increment);

            EnumerateValues(values, minValue, maxValue, x => x.AddMonths(increment));

        }

        #endregion

        #region TimeSpan

        [TestMethod]
        public void SequenceTimeSpan()
        {

            EnumerableFactory factory = new();

            TimeSpan minValue = new TimeSpan(1, 2, 3, 4, 5);
            TimeSpan maxValue = new TimeSpan(10, 0, 0, 0, 0);
            TimeSpan increment = new TimeSpan(1, 2, 3, 4, 5);

            var values = factory.SequenceTimeSpan(minValue, maxValue, increment);

            EnumerateValues(values, minValue, maxValue, x => x + increment);

        }

        #endregion


        private static void EnumerateValues<T>(IEnumerable<T> values, T minValue, T maxValue, Func<T, T> expectedNextValue)
            where T : struct, IComparable<T>
        {
            StringBuilder sb = new();

            T expectedValue = minValue;

            foreach (var value in values)
            {
                sb.AppendLine(value.ToString());

                Assert.AreEqual(expectedValue, value);
                Assert.AreEqual(true, value.CompareTo(minValue) >= 0 && value.CompareTo(maxValue) <= 0);

                expectedValue = expectedNextValue(value);
            }

            Debug.WriteLine(sb.ToString());
        }

    }

}
