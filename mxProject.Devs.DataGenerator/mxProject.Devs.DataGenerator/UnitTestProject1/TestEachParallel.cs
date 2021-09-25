using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using mxProject.Devs.DataGeneration;

using UnitTestProject1.Extensions;

namespace UnitTestProject1
{
    [TestClass]
    public class TestEachParallel
    {
        private static short[] GetValues1() => new short[] { 1 };

        private static short?[] GetValues2() => new short?[] { 1, 2 };

        private static char?[] GetValues3() => new char?[] { 'A', 'B', 'C' };

        private static int[] GetValues4() => new int[] { 1, 2, 3, 4 };

        private static int?[] GetValues5() => new int?[] { 1, 2, 3, 4, 5 };

        private static string?[] GetValues6() => new string?[] { "A", "B", "C", "D", "E", "F" };

        private static long[] GetValues7() => new long[] { 1, 2, 3, 4, 5, 6, 7 };

        private static long?[] GetValues8() => new long?[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        private static decimal[] GetValues9() => new decimal[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


        #region 2 collections

        [TestMethod]
        public void ExitWhenAnyCompleted2()
        {
            EnumerableFactory factory = new();

            var values1 = GetValues1();
            var values2 = GetValues2();

            EnumerateCore(factory.EachParallel(values1, values2, true), GetMinCount(values1, values2));
        }

        [TestMethod]
        public void ContinueWhenAnyCompleted2()
        {
            EnumerableFactory factory = new();

            var values1 = GetValues1();
            var values2 = GetValues2();

            EnumerateCore(factory.EachParallel(values1, values2, false), GetMaxCount(values1, values2));
        }

        #endregion

        #region 3 collections

        [TestMethod]
        public void ExitWhenAnyCompleted3()
        {
            EnumerableFactory factory = new();

            var values1 = GetValues1();
            var values2 = GetValues2();
            var values3 = GetValues3();

            EnumerateCore(factory.EachParallel(values1, values2, values3, true), GetMinCount(values1, values2, values3));
        }

        [TestMethod]
        public void ContinueWhenAnyCompleted3()
        {
            EnumerableFactory factory = new();

            var values1 = GetValues1();
            var values2 = GetValues2();
            var values3 = GetValues3();

            EnumerateCore(factory.EachParallel(values1, values2, values3, false), GetMaxCount(values1, values2, values3));
        }

        #endregion

        #region 4 collections

        [TestMethod]
        public void ExitWhenAnyCompleted4()
        {
            EnumerableFactory factory = new();

            var values1 = GetValues1();
            var values2 = GetValues2();
            var values3 = GetValues3();
            var values4 = GetValues4();

            EnumerateCore(factory.EachParallel(values1, values2, values3, values4, true), GetMinCount(values1, values2, values3, values4));
        }

        [TestMethod]
        public void ContinueWhenAnyCompleted4()
        {
            EnumerableFactory factory = new();

            var values1 = GetValues1();
            var values2 = GetValues2();
            var values3 = GetValues3();
            var values4 = GetValues4();

            EnumerateCore(factory.EachParallel(values1, values2, values3, values4, false), GetMaxCount(values1, values2, values3, values4));
        }

        #endregion

        #region 5 collections

        [TestMethod]
        public void ExitWhenAnyCompleted5()
        {
            EnumerableFactory factory = new();

            var values1 = GetValues1();
            var values2 = GetValues2();
            var values3 = GetValues3();
            var values4 = GetValues4();
            var values5 = GetValues5();

            EnumerateCore(factory.EachParallel(values1, values2, values3, values4, values5, true), GetMinCount(values1, values2, values3, values4, values5));
        }

        [TestMethod]
        public void ContinueWhenAnyCompleted5()
        {
            EnumerableFactory factory = new();

            var values1 = GetValues1();
            var values2 = GetValues2();
            var values3 = GetValues3();
            var values4 = GetValues4();
            var values5 = GetValues5();

            EnumerateCore(factory.EachParallel(values1, values2, values3, values4, values5, false), GetMaxCount(values1, values2, values3, values4, values5));
        }

        #endregion

        #region 6 collections

        [TestMethod]
        public void ExitWhenAnyCompleted6()
        {
            EnumerableFactory factory = new();

            var values1 = GetValues1();
            var values2 = GetValues2();
            var values3 = GetValues3();
            var values4 = GetValues4();
            var values5 = GetValues5();
            var values6 = GetValues6();

            EnumerateCore(factory.EachParallel(values1, values2, values3, values4, values5, values6, true), GetMinCount(values1, values2, values3, values4, values5, values6));
        }

        [TestMethod]
        public void ContinueWhenAnyCompleted6()
        {
            EnumerableFactory factory = new();

            var values1 = GetValues1();
            var values2 = GetValues2();
            var values3 = GetValues3();
            var values4 = GetValues4();
            var values5 = GetValues5();
            var values6 = GetValues6();

            EnumerateCore(factory.EachParallel(values1, values2, values3, values4, values5, values6, false), GetMaxCount(values1, values2, values3, values4, values5, values6));
        }

        #endregion

        #region 7 collections

        [TestMethod]
        public void ExitWhenAnyCompleted7()
        {
            EnumerableFactory factory = new();

            var values1 = GetValues1();
            var values2 = GetValues2();
            var values3 = GetValues3();
            var values4 = GetValues4();
            var values5 = GetValues5();
            var values6 = GetValues6();
            var values7 = GetValues7();

            EnumerateCore(factory.EachParallel(values1, values2, values3, values4, values5, values6, values7, true), GetMinCount(values1, values2, values3, values4, values5, values6, values7));
        }

        [TestMethod]
        public void ContinueWhenAnyCompleted7()
        {
            EnumerableFactory factory = new();

            var values1 = GetValues1();
            var values2 = GetValues2();
            var values3 = GetValues3();
            var values4 = GetValues4();
            var values5 = GetValues5();
            var values6 = GetValues6();
            var values7 = GetValues7();

            EnumerateCore(factory.EachParallel(values1, values2, values3, values4, values5, values6, values7, false), GetMaxCount(values1, values2, values3, values4, values5, values6, values7));
        }

        #endregion

        #region 8 collections

        [TestMethod]
        public void ExitWhenAnyCompleted8()
        {
            EnumerableFactory factory = new();

            var values1 = GetValues1();
            var values2 = GetValues2();
            var values3 = GetValues3();
            var values4 = GetValues4();
            var values5 = GetValues5();
            var values6 = GetValues6();
            var values7 = GetValues7();
            var values8 = GetValues8();

            EnumerateCore(factory.EachParallel(values1, values2, values3, values4, values5, values6, values7, values8, true), GetMinCount(values1, values2, values3, values4, values5, values6, values7, values8));
        }

        [TestMethod]
        public void ContinueWhenAnyCompleted8()
        {
            EnumerableFactory factory = new();

            var values1 = GetValues1();
            var values2 = GetValues2();
            var values3 = GetValues3();
            var values4 = GetValues4();
            var values5 = GetValues5();
            var values6 = GetValues6();
            var values7 = GetValues7();
            var values8 = GetValues8();

            EnumerateCore(factory.EachParallel(values1, values2, values3, values4, values5, values6, values7, values8, false), GetMaxCount(values1, values2, values3, values4, values5, values6, values7, values8));
        }

        #endregion

        #region 9 collections

        [TestMethod]
        public void ExitWhenAnyCompleted9()
        {
            EnumerableFactory factory = new();

            var values1 = GetValues1();
            var values2 = GetValues2();
            var values3 = GetValues3();
            var values4 = GetValues4();
            var values5 = GetValues5();
            var values6 = GetValues6();
            var values7 = GetValues7();
            var values8 = GetValues8();
            var values9 = GetValues9();

            EnumerateCore(factory.EachParallel(values1, values2, values3, values4, values5, values6, values7, values8, values9, true), GetMinCount(values1, values2, values3, values4, values5, values6, values7, values8, values9));
        }

        [TestMethod]
        public void ContinueWhenAnyCompleted9()
        {
            EnumerableFactory factory = new();

            var values1 = GetValues1();
            var values2 = GetValues2();
            var values3 = GetValues3();
            var values4 = GetValues4();
            var values5 = GetValues5();
            var values6 = GetValues6();
            var values7 = GetValues7();
            var values8 = GetValues8();
            var values9 = GetValues9();

            EnumerateCore(factory.EachParallel(values1, values2, values3, values4, values5, values6, values7, values8, values9, false), GetMaxCount(values1, values2, values3, values4, values5, values6, values7, values8, values9));
        }

        #endregion


        private void EnumerateCore(IEnumerable collection, int expectedCount)
        {
            int count = 0;

            foreach (var result in collection)
            {
                Debug.WriteLine(result);
                ++count;
            }

            Assert.AreEqual(expectedCount, count);
        }

        private int GetMaxCount(params IList[] lists)
        {
            int max = 0;

            for (int i = 0; i < lists.Length; ++i)
            {
                if (max < lists[i].Count)
                {
                    max = lists[i].Count;
                }
            }

            return max;
        }

        private int GetMinCount(params IList[] lists)
        {
            int min = int.MaxValue;

            for (int i = 0; i < lists.Length; ++i)
            {
                if (min > lists[i].Count)
                {
                    min = lists[i].Count;
                }
            }

            return min;
        }
    }
}
