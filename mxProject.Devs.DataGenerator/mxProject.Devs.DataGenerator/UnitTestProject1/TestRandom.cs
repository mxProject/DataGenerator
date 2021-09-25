using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
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
    public class TestRandom
    {

        private readonly double nullProbability = 0.1;

        #region Byte

        [TestMethod]
        public Task RandomByte_Full()
        {
            return RandomByteAsync(1000000, byte.MinValue, byte.MaxValue);
        }

        [TestMethod]
        public Task RandomByte_0_127()
        {
            return RandomByteAsync(1000000, 0, 127);
        }

        [TestMethod]
        public Task RandomByte_128_255()
        {
            return RandomByteAsync(1000000, 128, 255);
        }

        private async Task RandomByteAsync(int count, byte min, byte max)
        {

            DataGeneratorFieldFactory factory = new DataGeneratorFieldFactory();

            var field = await factory.RandomByte("randomByte", min, max, nullProbability: nullProbability).CreateTypedEnumerationAsync(count).ConfigureAwait(false);

            int i = 0;

            List<double> values = new List<double>(count);

            while (field.GenerateNext())
            {
                ++i;

                byte? result = field.GetTypedValue();

                if (!result.HasValue) { continue; }

                Assert.IsTrue(result.Value >= min && result.Value <= max);

                values.Add(result.Value);
            }

            Assert.AreEqual(count, i);

            Debug.WriteLine("null% : {0}%", (count - values.Count) / (double)count * 100);
            Debug.WriteLine("Mean : {0}", values.Mean());
            Debug.WriteLine("Median : {0}", values.Median());
            Debug.WriteLine("PopulationVariance : {0}", values.PopulationVariance());
            Debug.WriteLine("Variance : {0}", values.Variance());
            Debug.WriteLine("PopulationStandardDeviation : {0}", values.PopulationStandardDeviation());
            Debug.WriteLine("StandardDeviation : {0}", values.StandardDeviation());
        }

        #endregion

        #region Int16

        [TestMethod]
        public Task RandomInt16_FullRange()
        {
            return RandomInt16Async(1000000, short.MinValue, short.MaxValue);
        }

        [TestMethod]
        public Task RandomInt16_0_1000()
        {
            return RandomInt16Async(10000, 0, 1000);
        }

        [TestMethod]
        public Task RandomInt16_minus1000_1000()
        {
            return RandomInt16Async(10000, -1000, 1000);
        }

        private async Task RandomInt16Async(int count, short min, short max)
        {

            DataGeneratorFieldFactory factory = new DataGeneratorFieldFactory();

            var field = await factory.RandomInt16("randomInt16", min, max, nullProbability: nullProbability).CreateTypedEnumerationAsync(count).ConfigureAwait(false);

            int i = 0;

            List<double> values = new List<double>(count);

            while (field.GenerateNext())
            {
                ++i;

                short? result = field.GetTypedValue();

                if (!result.HasValue) { continue; }

                Assert.IsTrue(result.Value >= min && result.Value <= max);

                values.Add(result.Value);
            }

            Assert.AreEqual(count, i);

            Debug.WriteLine("null% : {0}%", (count - values.Count) / (double)count * 100);
            Debug.WriteLine("Mean : {0}", values.Mean());
            Debug.WriteLine("Median : {0}", values.Median());
            Debug.WriteLine("PopulationVariance : {0}", values.PopulationVariance());
            Debug.WriteLine("Variance : {0}", values.Variance());
            Debug.WriteLine("PopulationStandardDeviation : {0}", values.PopulationStandardDeviation());
            Debug.WriteLine("StandardDeviation : {0}", values.StandardDeviation());
        }

        #endregion

        #region Int32

        [TestMethod]
        public Task RandomInt32_FullRange()
        {
            return RandomInt32Async(1000000, int.MinValue, int.MaxValue);
        }

        [TestMethod]
        public Task RandomInt32_0_1000()
        {
            return RandomInt32Async(10000, 0, 1000);
        }

        [TestMethod]
        public Task RandomInt32_minus1000_1000()
        {
            return RandomInt32Async(10000, -1000, 1000);
        }

        private async Task RandomInt32Async(int count, int min, int max)
        {

            DataGeneratorFieldFactory factory = new DataGeneratorFieldFactory();

            var field = await factory.RandomInt32("randomInt32", min, max, nullProbability: nullProbability).CreateTypedEnumerationAsync(count);

            int i = 0;

            List<double> values = new List<double>(count);

            while (field.GenerateNext())
            {
                ++i;

                int? result = field.GetTypedValue();

                if (!result.HasValue) { continue; }

                Assert.IsTrue(result.Value >= min && result.Value <= max);

                values.Add(result.Value);
            }

            Assert.AreEqual(count, i);

            Debug.WriteLine("null% : {0}%", (count - values.Count) / (double)count * 100);
            Debug.WriteLine("Mean : {0}", values.Mean());
            Debug.WriteLine("Median : {0}", values.Median());
            Debug.WriteLine("PopulationVariance : {0}", values.PopulationVariance());
            Debug.WriteLine("Variance : {0}", values.Variance());
            Debug.WriteLine("PopulationStandardDeviation : {0}", values.PopulationStandardDeviation());
            Debug.WriteLine("StandardDeviation : {0}", values.StandardDeviation());
        }

        #endregion

        #region Int64

        [TestMethod]
        public Task RandomInt64_FullRange()
        {
            return RandomInt64Async(1000000, long.MinValue, long.MaxValue);
        }

        [TestMethod]
        public Task RandomInt64_0_1000()
        {
            return RandomInt64Async(10000, 0, 1000);
        }

        [TestMethod]
        public Task RandomInt64_minus1000_1000()
        {
            return RandomInt64Async(10000, -1000, 1000);
        }

        private async Task RandomInt64Async(int count, long min, long max)
        {

            DataGeneratorFieldFactory factory = new DataGeneratorFieldFactory();

            var field = await factory.RandomInt64("randomInt64", min, max, nullProbability: nullProbability).CreateTypedEnumerationAsync(count);

            int i = 0;

            List<double> values = new List<double>(count);

            while (field.GenerateNext())
            {
                ++i;

                long? result = field.GetTypedValue();

                if (!result.HasValue) { continue; }

                Assert.IsTrue(result.Value >= min && result.Value <= max);

                values.Add(result.Value);
            }

            Assert.AreEqual(count, i);

            Debug.WriteLine("null% : {0}%", (count - values.Count) / (double)count * 100);
            Debug.WriteLine("Mean : {0}", values.Mean());
            Debug.WriteLine("Median : {0}", values.Median());
            Debug.WriteLine("PopulationVariance : {0}", values.PopulationVariance());
            Debug.WriteLine("Variance : {0}", values.Variance());
            Debug.WriteLine("PopulationStandardDeviation : {0}", values.PopulationStandardDeviation());
            Debug.WriteLine("StandardDeviation : {0}", values.StandardDeviation());
        }

        #endregion

        #region Single

        [TestMethod]
        public Task RandomSingle_FullRange()
        {
            return RandomSingleAsync(10000, float.MinValue, float.MaxValue);
        }

        [TestMethod]
        public Task RandomSingle_0_1000()
        {
            return RandomSingleAsync(10000, 0, 1000);
        }

        [TestMethod]
        public Task RandomSingle_minus1000_1000()
        {
            return RandomSingleAsync(10000, -1000, 1000);
        }

        private async Task RandomSingleAsync(int count, float min, float max)
        {

            DataGeneratorFieldFactory factory = new DataGeneratorFieldFactory();

            var field = await factory.RandomSingle("randomSingle", min, max, nullProbability: nullProbability).CreateTypedEnumerationAsync(count).ConfigureAwait(false);

            int i = 0;

            List<double> values = new List<double>(count);

            while (field.GenerateNext())
            {
                ++i;

                float? result = field.GetTypedValue();

                if (!result.HasValue) { continue; }

                Assert.IsTrue(result.Value >= min && result.Value <= max);

                values.Add(result.Value);
            }

            Assert.AreEqual(count, i);

            Debug.WriteLine("null% : {0}%", (count - values.Count) / (double)count * 100);
            Debug.WriteLine("Mean : {0}", values.Mean());
            Debug.WriteLine("Median : {0}", values.Median());
            Debug.WriteLine("PopulationVariance : {0}", values.PopulationVariance());
            Debug.WriteLine("Variance : {0}", values.Variance());
            Debug.WriteLine("PopulationStandardDeviation : {0}", values.PopulationStandardDeviation());
            Debug.WriteLine("StandardDeviation : {0}", values.StandardDeviation());
        }

        #endregion

        #region Double

        [TestMethod]
        public Task RandomDouble_FullRange()
        {
            return RandomDoubleAsync(10000, double.MinValue, double.MaxValue);
        }

        [TestMethod]
        public Task RandomDouble_0_1000()
        {
            return RandomDoubleAsync(10000, 0, 1000);
        }

        [TestMethod]
        public Task RandomDouble_minus1000_1000()
        {
            return RandomDoubleAsync(10000, -1000, 1000);
        }

        private async Task RandomDoubleAsync(int count, double min, double max)
        {

            DataGeneratorFieldFactory factory = new DataGeneratorFieldFactory();

            var field = await factory.RandomDouble("randomDouble", min, max, nullProbability: nullProbability).CreateTypedEnumerationAsync(count).ConfigureAwait(false);

            int i = 0;

            List<double> values = new List<double>(count);

            while (field.GenerateNext())
            {
                ++i;

                double? result = field.GetTypedValue();

                if (!result.HasValue) { continue; }

                Assert.IsTrue(result.Value >= min && result.Value <= max);

                values.Add(result.Value);
            }

            Assert.AreEqual(count, i);

            Debug.WriteLine("null% : {0}%", (count - values.Count) / (double)count * 100);
            Debug.WriteLine("Mean : {0}", values.Mean());
            Debug.WriteLine("Median : {0}", values.Median());
            Debug.WriteLine("PopulationVariance : {0}", values.PopulationVariance());
            Debug.WriteLine("Variance : {0}", values.Variance());
            Debug.WriteLine("PopulationStandardDeviation : {0}", values.PopulationStandardDeviation());
            Debug.WriteLine("StandardDeviation : {0}", values.StandardDeviation());
        }

        #endregion

        #region Decimal

        [TestMethod]
        public Task RandomDecimal_FullRange()
        {
            return RandomDecimalAsync(10000, decimal.MinValue, decimal.MaxValue);
        }

        [TestMethod]
        public Task RandomDecimal_0_1000()
        {
            return RandomDecimalAsync(10000, 0, 1000);
        }

        [TestMethod]
        public Task RandomDecimal_minus1000_1000()
        {
            return RandomDecimalAsync(10000, -1000, 1000);
        }

        private async Task RandomDecimalAsync(int count, decimal min, decimal max)
        {

            DataGeneratorFieldFactory factory = new DataGeneratorFieldFactory();

            var field = await factory.RandomDecimal("randomDecimal", min, max, nullProbability: nullProbability).CreateTypedEnumerationAsync(count).ConfigureAwait(false);

            int i = 0;

            List<double> values = new List<double>(count);

            while (field.GenerateNext())
            {
                ++i;

                decimal? result = field.GetTypedValue();

                if (!result.HasValue) { continue; }

                Assert.IsTrue(result >= min && result <= max);

                values.Add((double)result.Value);
            }

            Assert.AreEqual(count, i);

            Debug.WriteLine("null% : {0}%", (count - values.Count) / (double)count * 100);
            Debug.WriteLine("Mean : {0}", values.Mean());
            Debug.WriteLine("Median : {0}", values.Median());
            Debug.WriteLine("PopulationVariance : {0}", values.PopulationVariance());
            Debug.WriteLine("Variance : {0}", values.Variance());
            Debug.WriteLine("PopulationStandardDeviation : {0}", values.PopulationStandardDeviation());
            Debug.WriteLine("StandardDeviation : {0}", values.StandardDeviation());
        }

        #endregion

        #region SByte

        [TestMethod]
        public Task RandomSByte_Full()
        {
            return RandomSByteAsync(1000000, sbyte.MinValue, sbyte.MaxValue);
        }

        [TestMethod]
        public Task RandomSByte_0_127()
        {
            return RandomSByteAsync(1000000, 0, 127);
        }

        [TestMethod]
        public Task RandomSByte_minus64_64()
        {
            return RandomSByteAsync(1000000, -64, 64);
        }

        private async Task RandomSByteAsync(int count, sbyte min, sbyte max)
        {

            DataGeneratorFieldFactory factory = new DataGeneratorFieldFactory();

            var field = await factory.RandomSByte("randomSByte", min, max, nullProbability: nullProbability).CreateTypedEnumerationAsync(count).ConfigureAwait(false);

            int i = 0;

            List<double> values = new List<double>(count);

            while (field.GenerateNext())
            {
                ++i;

                sbyte? result = field.GetTypedValue();

                if (!result.HasValue) { continue; }

                Assert.IsTrue(result.Value >= min && result.Value <= max);

                values.Add(result.Value);
            }

            Assert.AreEqual(count, i);

            Debug.WriteLine("null% : {0}%", (count - values.Count) / (double)count * 100);
            Debug.WriteLine("Mean : {0}", values.Mean());
            Debug.WriteLine("Median : {0}", values.Median());
            Debug.WriteLine("PopulationVariance : {0}", values.PopulationVariance());
            Debug.WriteLine("Variance : {0}", values.Variance());
            Debug.WriteLine("PopulationStandardDeviation : {0}", values.PopulationStandardDeviation());
            Debug.WriteLine("StandardDeviation : {0}", values.StandardDeviation());
        }

        #endregion

        #region UInt16

        [TestMethod]
        public Task RandomUInt16_FullRange()
        {
            return RandomUInt16Async(1000000, ushort.MinValue, ushort.MaxValue);
        }

        [TestMethod]
        public Task RandomUInt16_0_1000()
        {
            return RandomUInt16Async(10000, 0, 1000);
        }

        private async Task RandomUInt16Async(int count, ushort min, ushort max)
        {

            DataGeneratorFieldFactory factory = new DataGeneratorFieldFactory();

            var field = await factory.RandomUInt16("randomUInt16", min, max, nullProbability: nullProbability).CreateTypedEnumerationAsync(count).ConfigureAwait(false);

            int i = 0;

            List<double> values = new List<double>(count);

            while (field.GenerateNext())
            {
                ++i;

                ushort? result = field.GetTypedValue();

                if (!result.HasValue) { continue; }

                Assert.IsTrue(result.Value >= min && result.Value <= max);

                values.Add(result.Value);
            }

            Assert.AreEqual(count, i);

            Debug.WriteLine("null% : {0}%", (count - values.Count) / (double)count * 100);
            Debug.WriteLine("Mean : {0}", values.Mean());
            Debug.WriteLine("Median : {0}", values.Median());
            Debug.WriteLine("PopulationVariance : {0}", values.PopulationVariance());
            Debug.WriteLine("Variance : {0}", values.Variance());
            Debug.WriteLine("PopulationStandardDeviation : {0}", values.PopulationStandardDeviation());
            Debug.WriteLine("StandardDeviation : {0}", values.StandardDeviation());
        }

        #endregion

        #region UInt32

        [TestMethod]
        public Task RandomUInt32_FullRange()
        {
            return RandomUInt32Async(1000000, uint.MinValue, uint.MaxValue);
        }

        [TestMethod]
        public Task RandomUInt32_0_1000()
        {
            return RandomUInt32Async(10000, 0, 1000);
        }

        private async Task RandomUInt32Async(int count, uint min, uint max)
        {

            DataGeneratorFieldFactory factory = new DataGeneratorFieldFactory();

            var field = await factory.RandomUInt32("randomUInt32", min, max, nullProbability: nullProbability).CreateTypedEnumerationAsync(count).ConfigureAwait(false);

            int i = 0;

            List<double> values = new List<double>(count);

            while (field.GenerateNext())
            {
                ++i;

                uint? result = field.GetTypedValue();

                if (!result.HasValue) { continue; }

                Assert.IsTrue(result.Value >= min && result.Value <= max);

                values.Add(result.Value);
            }

            Assert.AreEqual(count, i);

            Debug.WriteLine("null% : {0}%", (count - values.Count) / (double)count * 100);
            Debug.WriteLine("Mean : {0}", values.Mean());
            Debug.WriteLine("Median : {0}", values.Median());
            Debug.WriteLine("PopulationVariance : {0}", values.PopulationVariance());
            Debug.WriteLine("Variance : {0}", values.Variance());
            Debug.WriteLine("PopulationStandardDeviation : {0}", values.PopulationStandardDeviation());
            Debug.WriteLine("StandardDeviation : {0}", values.StandardDeviation());
        }

        #endregion

        #region UInt64

        [TestMethod]
        public Task RandomUInt64_FullRange()
        {
            return RandomUInt64Async(1000000, ulong.MinValue, ulong.MaxValue);
        }

        [TestMethod]
        public Task RandomUInt64_0_1000()
        {
            return RandomUInt64Async(10000, 0, 1000);
        }

        private async Task RandomUInt64Async(int count, ulong min, ulong max)
        {

            DataGeneratorFieldFactory factory = new DataGeneratorFieldFactory();

            var field = await factory.RandomUInt64("randomUInt64", min, max, nullProbability: nullProbability).CreateTypedEnumerationAsync(count).ConfigureAwait(false);

            int i = 0;

            List<double> values = new List<double>(count);

            while (field.GenerateNext())
            {
                ++i;

                ulong? result = field.GetTypedValue();

                if (!result.HasValue) { continue; }

                Assert.IsTrue(result.Value >= min && result.Value <= max);

                values.Add(result.Value);
            }

            Assert.AreEqual(count, i);

            Debug.WriteLine("null% : {0}%", (count - values.Count) / (double)count * 100);
            Debug.WriteLine("Mean : {0}", values.Mean());
            Debug.WriteLine("Median : {0}", values.Median());
            Debug.WriteLine("PopulationVariance : {0}", values.PopulationVariance());
            Debug.WriteLine("Variance : {0}", values.Variance());
            Debug.WriteLine("PopulationStandardDeviation : {0}", values.PopulationStandardDeviation());
            Debug.WriteLine("StandardDeviation : {0}", values.StandardDeviation());
        }

        #endregion

        #region DateTime

        [TestMethod]
        public Task RandomDateTime_FullRange()
        {
            return RandomDateTimeAsync(1000000, DateTime.MinValue, DateTime.MaxValue);
        }

        [TestMethod]
        public Task RandomDateTime_ThisMonth()
        {
            DateTime today = DateTime.Today;
            return RandomDateTimeAsync(10000, today.AddDays(1 - today.Day), today.AddDays(1 - today.Day).AddMonths(1).AddDays(-1));
        }

        [TestMethod]
        public Task RandomDateTime_Date()
        {
            DateTime today = DateTime.Today;
            return RandomDateTimeAsync(10000, today.AddDays(1 - today.Day), today.AddDays(1 - today.Day).AddMonths(1).AddDays(-1), x => x.Date);
        }

        private async Task RandomDateTimeAsync(int count, DateTime min, DateTime max, Func<DateTime, DateTime>? selector = null)
        {

            DataGeneratorFieldFactory factory = new DataGeneratorFieldFactory();

            var field = await factory.RandomDateTime("randomDateTime", min, max, nullProbability: nullProbability, selector: selector).CreateTypedEnumerationAsync(count).ConfigureAwait(false);

            int i = 0;

            List<double> values = new List<double>(count);

            while (field.GenerateNext())
            {
                ++i;

                DateTime? result = field.GetTypedValue();

                if (!result.HasValue) { continue; }

                Assert.IsTrue(result.Value >= min && result.Value <= max);

                values.Add(result.Value.Ticks);
            }

            Assert.AreEqual(count, i);

            Debug.WriteLine("null% : {0}%", (count - values.Count) / (double)count * 100);
        }

        #endregion

        #region DateTime

        [TestMethod]
        public Task RandomDateTimeOffset_FullRange()
        {
            return RandomDateTimeOffsetAsync(1000000, DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
        }

        [TestMethod]
        public Task RandomDateTimeOffset_ThisMonth()
        {
            DateTimeOffset today = new DateTimeOffset(DateTime.Today);
            return RandomDateTimeOffsetAsync(10000, today.AddDays(1 - today.Day), today.AddDays(1 - today.Day).AddMonths(1).AddDays(-1));
        }

        [TestMethod]
        public Task RandomDateTimeOffset_Date()
        {
            DateTimeOffset today = new DateTimeOffset(DateTime.Today);
            return RandomDateTimeOffsetAsync(10000, today.AddDays(1 - today.Day), today.AddDays(1 - today.Day).AddMonths(1).AddDays(-1), x => x.Date);
        }

        private async Task RandomDateTimeOffsetAsync(int count, DateTimeOffset min, DateTimeOffset max, Func<DateTimeOffset, DateTimeOffset>? selector = null)
        {

            DataGeneratorFieldFactory factory = new DataGeneratorFieldFactory();

            var field = await factory.RandomDateTimeOffset("randomDateTimeOffset", min, max, nullProbability: nullProbability, selector: selector).CreateTypedEnumerationAsync(count).ConfigureAwait(false);

            int i = 0;

            List<double> values = new List<double>(count);

            while (field.GenerateNext())
            {
                ++i;

                DateTimeOffset? result = field.GetTypedValue();

                if (!result.HasValue) { continue; }

                Assert.IsTrue(result.Value >= min && result.Value <= max);

                values.Add(result.Value.Ticks);
            }

            Assert.AreEqual(count, i);

            Debug.WriteLine("null% : {0}%", (count - values.Count) / (double)count * 100);
        }

        #endregion

        #region TimeSpan

        [TestMethod]
        public Task RandomTimeSpan_FullRange()
        {
            return RandomTimeSpanAsync(1000000, TimeSpan.MinValue, TimeSpan.MaxValue);
        }

        [TestMethod]
        public Task RandomTimeSpan_2minutes_2days()
        {
            return RandomTimeSpanAsync(10000, TimeSpan.FromMinutes(2), TimeSpan.FromDays(2));
        }

        private async Task RandomTimeSpanAsync(int count, TimeSpan min, TimeSpan max)
        {

            DataGeneratorFieldFactory factory = new DataGeneratorFieldFactory();

            var field = await factory.RandomTimeSpan("randomTimeSpan", min, max, nullProbability: nullProbability).CreateTypedEnumerationAsync(count).ConfigureAwait(false);

            int i = 0;

            List<double> values = new List<double>(count);

            while (field.GenerateNext())
            {
                ++i;

                TimeSpan? result = field.GetTypedValue();

                if (!result.HasValue) { continue; }

                Assert.IsTrue(result.Value >= min && result.Value <= max);

                values.Add(result.Value.Ticks);
            }

            Assert.AreEqual(count, i);

            Debug.WriteLine("null% : {0}%", (count - values.Count) / (double)count * 100);
        }

        #endregion

    }
}
