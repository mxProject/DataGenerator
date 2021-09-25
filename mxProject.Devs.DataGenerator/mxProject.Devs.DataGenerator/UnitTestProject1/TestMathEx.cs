using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using mxProject.Devs.DataGeneration;
using System.Runtime.InteropServices;

using UnitTestProject1.Extensions;

namespace UnitTestProject1
{

    [TestClass]
    public class TestMathEx
    {

        #region CeilingMultiple

        [TestMethod]
        public void CeilingMultipleDouble()
        {
            CeilingMultipleDouble(100, 1, 100);
            CeilingMultipleDouble(100, 2, 100);
            CeilingMultipleDouble(100, 3, 102);
            CeilingMultipleDouble(100, 4, 100);
            CeilingMultipleDouble(100, 5, 100);
            CeilingMultipleDouble(100, 6, 102);
            CeilingMultipleDouble(100, 7, 105);
            CeilingMultipleDouble(100, 8, 104);
            CeilingMultipleDouble(100, 9, 108);
            CeilingMultipleDouble(100, 10, 100);

            CeilingMultipleDouble(-10, 3, -9);
            CeilingMultipleDouble(-9, 3, -9);
            CeilingMultipleDouble(-8, 3, -6);
            CeilingMultipleDouble(-7, 3, -6);
            CeilingMultipleDouble(-6, 3, -6);
            CeilingMultipleDouble(-5, 3, -3);
            CeilingMultipleDouble(-4, 3, -3);
            CeilingMultipleDouble(-3, 3, -3);
            CeilingMultipleDouble(-2, 3, 0);
            CeilingMultipleDouble(-1, 3, 0);
            CeilingMultipleDouble(0, 3, 0);
            CeilingMultipleDouble(1, 3, 3);
            CeilingMultipleDouble(2, 3, 3);
            CeilingMultipleDouble(3, 3, 3);
            CeilingMultipleDouble(4, 3, 6);
            CeilingMultipleDouble(5, 3, 6);
            CeilingMultipleDouble(6, 3, 6);
            CeilingMultipleDouble(7, 3, 9);
            CeilingMultipleDouble(8, 3, 9);
            CeilingMultipleDouble(9, 3, 9);
            CeilingMultipleDouble(10, 3, 12);
        }

        [TestMethod]
        public void CeilingMultipleDecimal()
        {
            CeilingMultipleDecimal(100, 1, 100);
            CeilingMultipleDecimal(100, 2, 100);
            CeilingMultipleDecimal(100, 3, 102);
            CeilingMultipleDecimal(100, 4, 100);
            CeilingMultipleDecimal(100, 5, 100);
            CeilingMultipleDecimal(100, 6, 102);
            CeilingMultipleDecimal(100, 7, 105);
            CeilingMultipleDecimal(100, 8, 104);
            CeilingMultipleDecimal(100, 9, 108);
            CeilingMultipleDecimal(100, 10, 100);

            CeilingMultipleDecimal(-10, 3, -9);
            CeilingMultipleDecimal(-9, 3, -9);
            CeilingMultipleDecimal(-8, 3, -6);
            CeilingMultipleDecimal(-7, 3, -6);
            CeilingMultipleDecimal(-6, 3, -6);
            CeilingMultipleDecimal(-5, 3, -3);
            CeilingMultipleDecimal(-4, 3, -3);
            CeilingMultipleDecimal(-3, 3, -3);
            CeilingMultipleDecimal(-2, 3, 0);
            CeilingMultipleDecimal(-1, 3, 0);
            CeilingMultipleDecimal(0, 3, 0);
            CeilingMultipleDecimal(1, 3, 3);
            CeilingMultipleDecimal(2, 3, 3);
            CeilingMultipleDecimal(3, 3, 3);
            CeilingMultipleDecimal(4, 3, 6);
            CeilingMultipleDecimal(5, 3, 6);
            CeilingMultipleDecimal(6, 3, 6);
            CeilingMultipleDecimal(7, 3, 9);
            CeilingMultipleDecimal(8, 3, 9);
            CeilingMultipleDecimal(9, 3, 9);
            CeilingMultipleDecimal(10, 3, 12);
        }

        private void CeilingMultipleDouble(double value, int multiple, double expected)
        {
            Assert.AreEqual(expected, MathEx.CeilingMultiple(value, multiple));
        }

        private void CeilingMultipleDecimal(decimal value, int multiple, decimal expected)
        {
            Assert.AreEqual(expected, MathEx.CeilingMultiple(value, multiple));
        }

        #endregion

        #region FloorMultiple

        [TestMethod]
        public void FloorMultipleDouble()
        {
            FloorMultipleDouble(100, 1, 100);
            FloorMultipleDouble(100, 2, 100);
            FloorMultipleDouble(100, 3, 99);
            FloorMultipleDouble(100, 4, 100);
            FloorMultipleDouble(100, 5, 100);
            FloorMultipleDouble(100, 6, 96);
            FloorMultipleDouble(100, 7, 98);
            FloorMultipleDouble(100, 8, 96);
            FloorMultipleDouble(100, 9, 99);
            FloorMultipleDouble(100, 10, 100);

            FloorMultipleDouble(-10, 3, -12);
            FloorMultipleDouble(-9, 3, -9);
            FloorMultipleDouble(-8, 3, -9);
            FloorMultipleDouble(-7, 3, -9);
            FloorMultipleDouble(-6, 3, -6);
            FloorMultipleDouble(-5, 3, -6);
            FloorMultipleDouble(-4, 3, -6);
            FloorMultipleDouble(-3, 3, -3);
            FloorMultipleDouble(-2, 3, -3);
            FloorMultipleDouble(-1, 3, -3);
            FloorMultipleDouble(0, 3, 0);
            FloorMultipleDouble(1, 3, 0);
            FloorMultipleDouble(2, 3, 0);
            FloorMultipleDouble(3, 3, 3);
            FloorMultipleDouble(4, 3, 3);
            FloorMultipleDouble(5, 3, 3);
            FloorMultipleDouble(6, 3, 6);
            FloorMultipleDouble(7, 3, 6);
            FloorMultipleDouble(8, 3, 6);
            FloorMultipleDouble(9, 3, 9);
            FloorMultipleDouble(10, 3, 9);
        }

        [TestMethod]
        public void FloorMultipleDecimal()
        {
            FloorMultipleDecimal(100, 1, 100);
            FloorMultipleDecimal(100, 2, 100);
            FloorMultipleDecimal(100, 3, 99);
            FloorMultipleDecimal(100, 4, 100);
            FloorMultipleDecimal(100, 5, 100);
            FloorMultipleDecimal(100, 6, 96);
            FloorMultipleDecimal(100, 7, 98);
            FloorMultipleDecimal(100, 8, 96);
            FloorMultipleDecimal(100, 9, 99);
            FloorMultipleDecimal(100, 10, 100);

            FloorMultipleDecimal(-10, 3, -12);
            FloorMultipleDecimal(-9, 3, -9);
            FloorMultipleDecimal(-8, 3, -9);
            FloorMultipleDecimal(-7, 3, -9);
            FloorMultipleDecimal(-6, 3, -6);
            FloorMultipleDecimal(-5, 3, -6);
            FloorMultipleDecimal(-4, 3, -6);
            FloorMultipleDecimal(-3, 3, -3);
            FloorMultipleDecimal(-2, 3, -3);
            FloorMultipleDecimal(-1, 3, -3);
            FloorMultipleDecimal(0, 3, 0);
            FloorMultipleDecimal(1, 3, 0);
            FloorMultipleDecimal(2, 3, 0);
            FloorMultipleDecimal(3, 3, 3);
            FloorMultipleDecimal(4, 3, 3);
            FloorMultipleDecimal(5, 3, 3);
            FloorMultipleDecimal(6, 3, 6);
            FloorMultipleDecimal(7, 3, 6);
            FloorMultipleDecimal(8, 3, 6);
            FloorMultipleDecimal(9, 3, 9);
            FloorMultipleDecimal(10, 3, 9);
        }

        private void FloorMultipleDouble(double value, int multiple, double expected)
        {
            Assert.AreEqual(expected, MathEx.FloorMultiple(value, multiple));
        }

        private void FloorMultipleDecimal(decimal value, int multiple, decimal expected)
        {
            Assert.AreEqual(expected, MathEx.FloorMultiple(value, multiple));
        }

        #endregion

        #region RoundMultiple

        [TestMethod]
        public void RoundMultipleDouble()
        {
            RoundMultipleDouble(100, 1, 100);
            RoundMultipleDouble(100, 2, 100);
            RoundMultipleDouble(100, 3, 99);
            RoundMultipleDouble(100, 4, 100);
            RoundMultipleDouble(100, 5, 100);
            RoundMultipleDouble(100, 6, 102);
            RoundMultipleDouble(100, 7, 98);
            RoundMultipleDouble(100, 8, 96);
            RoundMultipleDouble(100, 9, 99);
            RoundMultipleDouble(100, 10, 100);

            RoundMultipleDouble(-10, 3, -9);
            RoundMultipleDouble(-9, 3, -9);
            RoundMultipleDouble(-8, 3, -9);
            RoundMultipleDouble(-7, 3, -6);
            RoundMultipleDouble(-6, 3, -6);
            RoundMultipleDouble(-5, 3, -6);
            RoundMultipleDouble(-4, 3, -3);
            RoundMultipleDouble(-3, 3, -3);
            RoundMultipleDouble(-2, 3, -3);
            RoundMultipleDouble(-1, 3, 0);
            RoundMultipleDouble(0, 3, 0);
            RoundMultipleDouble(1, 3, 0);
            RoundMultipleDouble(2, 3, 3);
            RoundMultipleDouble(3, 3, 3);
            RoundMultipleDouble(4, 3, 3);
            RoundMultipleDouble(5, 3, 6);
            RoundMultipleDouble(6, 3, 6);
            RoundMultipleDouble(7, 3, 6);
            RoundMultipleDouble(8, 3, 9);
            RoundMultipleDouble(9, 3, 9);
            RoundMultipleDouble(10, 3, 9);
        }

        [TestMethod]
        public void RoundMultipleDecimal()
        {
            RoundMultipleDecimal(100, 1, 100);
            RoundMultipleDecimal(100, 2, 100);
            RoundMultipleDecimal(100, 3, 99);
            RoundMultipleDecimal(100, 4, 100);
            RoundMultipleDecimal(100, 5, 100);
            RoundMultipleDecimal(100, 6, 102);
            RoundMultipleDecimal(100, 7, 98);
            RoundMultipleDecimal(100, 8, 96);
            RoundMultipleDecimal(100, 9, 99);
            RoundMultipleDecimal(100, 10, 100);

            RoundMultipleDecimal(-10, 3, -9);
            RoundMultipleDecimal(-9, 3, -9);
            RoundMultipleDecimal(-8, 3, -9);
            RoundMultipleDecimal(-7, 3, -6);
            RoundMultipleDecimal(-6, 3, -6);
            RoundMultipleDecimal(-5, 3, -6);
            RoundMultipleDecimal(-4, 3, -3);
            RoundMultipleDecimal(-3, 3, -3);
            RoundMultipleDecimal(-2, 3, -3);
            RoundMultipleDecimal(-1, 3, 0);
            RoundMultipleDecimal(0, 3, 0);
            RoundMultipleDecimal(1, 3, 0);
            RoundMultipleDecimal(2, 3, 3);
            RoundMultipleDecimal(3, 3, 3);
            RoundMultipleDecimal(4, 3, 3);
            RoundMultipleDecimal(5, 3, 6);
            RoundMultipleDecimal(6, 3, 6);
            RoundMultipleDecimal(7, 3, 6);
            RoundMultipleDecimal(8, 3, 9);
            RoundMultipleDecimal(9, 3, 9);
            RoundMultipleDecimal(10, 3, 9);
        }

        [TestMethod]
        public void RoundMultipleDouble_AwayFromZero()
        {
            RoundMultipleDouble(100, 1, MidpointRounding.AwayFromZero, 100);
            RoundMultipleDouble(100, 2, MidpointRounding.AwayFromZero, 100);
            RoundMultipleDouble(100, 3, MidpointRounding.AwayFromZero, 99);
            RoundMultipleDouble(100, 4, MidpointRounding.AwayFromZero, 100);
            RoundMultipleDouble(100, 5, MidpointRounding.AwayFromZero, 100);
            RoundMultipleDouble(100, 6, MidpointRounding.AwayFromZero, 102);
            RoundMultipleDouble(100, 7, MidpointRounding.AwayFromZero, 98);
            RoundMultipleDouble(100, 8, MidpointRounding.AwayFromZero, 104); // 100/8 => 12.5 => 13 => 13*8 => 104
            RoundMultipleDouble(100, 9, MidpointRounding.AwayFromZero, 99);
            RoundMultipleDouble(100, 10, MidpointRounding.AwayFromZero, 100);

            RoundMultipleDouble(-10, 3, MidpointRounding.AwayFromZero, -9);
            RoundMultipleDouble(-9, 3, MidpointRounding.AwayFromZero, -9);
            RoundMultipleDouble(-8, 3, MidpointRounding.AwayFromZero, -9);
            RoundMultipleDouble(-7, 3, MidpointRounding.AwayFromZero, -6);
            RoundMultipleDouble(-6, 3, MidpointRounding.AwayFromZero, -6);
            RoundMultipleDouble(-5, 3, MidpointRounding.AwayFromZero, -6);
            RoundMultipleDouble(-4, 3, MidpointRounding.AwayFromZero, -3);
            RoundMultipleDouble(-3, 3, MidpointRounding.AwayFromZero, -3);
            RoundMultipleDouble(-2, 3, MidpointRounding.AwayFromZero, -3);
            RoundMultipleDouble(-1, 3, MidpointRounding.AwayFromZero, 0);
            RoundMultipleDouble(0, 3, MidpointRounding.AwayFromZero, 0);
            RoundMultipleDouble(1, 3, MidpointRounding.AwayFromZero, 0);
            RoundMultipleDouble(2, 3, MidpointRounding.AwayFromZero, 3);
            RoundMultipleDouble(3, 3, MidpointRounding.AwayFromZero, 3);
            RoundMultipleDouble(4, 3, MidpointRounding.AwayFromZero, 3);
            RoundMultipleDouble(5, 3, MidpointRounding.AwayFromZero, 6);
            RoundMultipleDouble(6, 3, MidpointRounding.AwayFromZero, 6);
            RoundMultipleDouble(7, 3, MidpointRounding.AwayFromZero, 6);
            RoundMultipleDouble(8, 3, MidpointRounding.AwayFromZero, 9);
            RoundMultipleDouble(9, 3, MidpointRounding.AwayFromZero, 9);
            RoundMultipleDouble(10, 3, MidpointRounding.AwayFromZero, 9);
        }

        [TestMethod]
        public void RoundMultipleDecimal_AwayFromZero()
        {
            RoundMultipleDecimal(100, 1, MidpointRounding.AwayFromZero, 100);
            RoundMultipleDecimal(100, 2, MidpointRounding.AwayFromZero, 100);
            RoundMultipleDecimal(100, 3, MidpointRounding.AwayFromZero, 99);
            RoundMultipleDecimal(100, 4, MidpointRounding.AwayFromZero, 100);
            RoundMultipleDecimal(100, 5, MidpointRounding.AwayFromZero, 100);
            RoundMultipleDecimal(100, 6, MidpointRounding.AwayFromZero, 102);
            RoundMultipleDecimal(100, 7, MidpointRounding.AwayFromZero, 98);
            RoundMultipleDecimal(100, 8, MidpointRounding.AwayFromZero, 104); // 100/8 => 12.5 => 13 => 13*8 => 104
            RoundMultipleDecimal(100, 9, MidpointRounding.AwayFromZero, 99);
            RoundMultipleDecimal(100, 10, MidpointRounding.AwayFromZero, 100);

            RoundMultipleDecimal(-10, 3, MidpointRounding.AwayFromZero, -9);
            RoundMultipleDecimal(-9, 3, MidpointRounding.AwayFromZero, -9);
            RoundMultipleDecimal(-8, 3, MidpointRounding.AwayFromZero, -9);
            RoundMultipleDecimal(-7, 3, MidpointRounding.AwayFromZero, -6);
            RoundMultipleDecimal(-6, 3, MidpointRounding.AwayFromZero, -6);
            RoundMultipleDecimal(-5, 3, MidpointRounding.AwayFromZero, -6);
            RoundMultipleDecimal(-4, 3, MidpointRounding.AwayFromZero, -3);
            RoundMultipleDecimal(-3, 3, MidpointRounding.AwayFromZero, -3);
            RoundMultipleDecimal(-2, 3, MidpointRounding.AwayFromZero, -3);
            RoundMultipleDecimal(-1, 3, MidpointRounding.AwayFromZero, 0);
            RoundMultipleDecimal(0, 3, MidpointRounding.AwayFromZero, 0);
            RoundMultipleDecimal(1, 3, MidpointRounding.AwayFromZero, 0);
            RoundMultipleDecimal(2, 3, MidpointRounding.AwayFromZero, 3);
            RoundMultipleDecimal(3, 3, MidpointRounding.AwayFromZero, 3);
            RoundMultipleDecimal(4, 3, MidpointRounding.AwayFromZero, 3);
            RoundMultipleDecimal(5, 3, MidpointRounding.AwayFromZero, 6);
            RoundMultipleDecimal(6, 3, MidpointRounding.AwayFromZero, 6);
            RoundMultipleDecimal(7, 3, MidpointRounding.AwayFromZero, 6);
            RoundMultipleDecimal(8, 3, MidpointRounding.AwayFromZero, 9);
            RoundMultipleDecimal(9, 3, MidpointRounding.AwayFromZero, 9);
            RoundMultipleDecimal(10, 3, MidpointRounding.AwayFromZero, 9);
        }

        [TestMethod]
        public void RoundMultipleDouble_Digits()
        {
            RoundMultipleDouble(100, 1, 1, 100);
            RoundMultipleDouble(100, 2, 1, 100);
            RoundMultipleDouble(100, 3, 1, 99.9);
            RoundMultipleDouble(100, 4, 1, 100);
            RoundMultipleDouble(100, 5, 1, 100);
            RoundMultipleDouble(100, 6, 1, 100.2);
            RoundMultipleDouble(100, 7, 1, 100.1);
            RoundMultipleDouble(100, 8, 1, 100);
            RoundMultipleDouble(100, 9, 1, 99.9);
            RoundMultipleDouble(100, 10, 1, 100);

            RoundMultipleDouble(100, 1, 0, 100);
            RoundMultipleDouble(100, 2, 0, 100);
            RoundMultipleDouble(100, 3, 0, 99);
            RoundMultipleDouble(100, 4, 0, 100);
            RoundMultipleDouble(100, 5, 0, 100);
            RoundMultipleDouble(100, 6, 0, 102);
            RoundMultipleDouble(100, 7, 0, 98);
            RoundMultipleDouble(100, 8, 0, 96);
            RoundMultipleDouble(100, 9, 0, 99);
            RoundMultipleDouble(100, 10, 0, 100);

            RoundMultipleDouble(-10, 3, 1, -9.9);
            RoundMultipleDouble(-9, 3, 1, -9.0);
            RoundMultipleDouble(-8, 3, 1, -8.1);
            RoundMultipleDouble(-7, 3, 1, -6.9);
            RoundMultipleDouble(-6, 3, 1, -6);
            RoundMultipleDouble(-5, 3, 1, -5.1);
            RoundMultipleDouble(-4, 3, 1, -3.9);
            RoundMultipleDouble(-3, 3, 1, -3);
            RoundMultipleDouble(-2, 3, 1, -2.1);
            RoundMultipleDouble(-1, 3, 1, -0.9);
            RoundMultipleDouble(0, 3, 1, 0);
            RoundMultipleDouble(1, 3, 1, 0.9);
            RoundMultipleDouble(2, 3, 1, 2.1);
            RoundMultipleDouble(3, 3, 1, 3);
            RoundMultipleDouble(4, 3, 1, 3.9);
            RoundMultipleDouble(5, 3, 1, 5.1);
            RoundMultipleDouble(6, 3, 1, 6);
            RoundMultipleDouble(7, 3, 1, 6.9);
            RoundMultipleDouble(8, 3, 1, 8.1);
            RoundMultipleDouble(9, 3, 1, 9);
            RoundMultipleDouble(10, 3, 1, 9.9);
        }

        [TestMethod]
        public void RoundMultipleDecimal_Digits()
        {
            RoundMultipleDecimal(100, 1, 1, 100M);
            RoundMultipleDecimal(100, 2, 1, 100M);
            RoundMultipleDecimal(100, 3, 1, 99.9M);
            RoundMultipleDecimal(100, 4, 1, 100M);
            RoundMultipleDecimal(100, 5, 1, 100M);
            RoundMultipleDecimal(100, 6, 1, 100.2M);
            RoundMultipleDecimal(100, 7, 1, 100.1M);
            RoundMultipleDecimal(100, 8, 1, 100M);
            RoundMultipleDecimal(100, 9, 1, 99.9M);
            RoundMultipleDecimal(100, 10, 1, 100M);

            RoundMultipleDecimal(100, 1, 0, 100M);
            RoundMultipleDecimal(100, 2, 0, 100M);
            RoundMultipleDecimal(100, 3, 0, 99M);
            RoundMultipleDecimal(100, 4, 0, 100M);
            RoundMultipleDecimal(100, 5, 0, 100M);
            RoundMultipleDecimal(100, 6, 0, 102M);
            RoundMultipleDecimal(100, 7, 0, 98M);
            RoundMultipleDecimal(100, 8, 0, 96M);
            RoundMultipleDecimal(100, 9, 0, 99M);
            RoundMultipleDecimal(100, 10, 0, 100M);

            RoundMultipleDecimal(-10, 3, 1, -9.9M);
            RoundMultipleDecimal(-9, 3, 1, -9.0M);
            RoundMultipleDecimal(-8, 3, 1, -8.1M);
            RoundMultipleDecimal(-7, 3, 1, -6.9M);
            RoundMultipleDecimal(-6, 3, 1, -6M);
            RoundMultipleDecimal(-5, 3, 1, -5.1M);
            RoundMultipleDecimal(-4, 3, 1, -3.9M);
            RoundMultipleDecimal(-3, 3, 1, -3M);
            RoundMultipleDecimal(-2, 3, 1, -2.1M);
            RoundMultipleDecimal(-1, 3, 1, -0.9M);
            RoundMultipleDecimal(0, 3, 1, 0M);
            RoundMultipleDecimal(1, 3, 1, 0.9M);
            RoundMultipleDecimal(2, 3, 1, 2.1M);
            RoundMultipleDecimal(3, 3, 1, 3M);
            RoundMultipleDecimal(4, 3, 1, 3.9M);
            RoundMultipleDecimal(5, 3, 1, 5.1M);
            RoundMultipleDecimal(6, 3, 1, 6M);
            RoundMultipleDecimal(7, 3, 1, 6.9M);
            RoundMultipleDecimal(8, 3, 1, 8.1M);
            RoundMultipleDecimal(9, 3, 1, 9M);
            RoundMultipleDecimal(10, 3, 1, 9.9M);
        }

        [TestMethod]
        public void RoundMultipleDouble_Digits_AwayFromZero()
        {
            RoundMultipleDouble(100, 1, 1, MidpointRounding.AwayFromZero, 100);
            RoundMultipleDouble(100, 2, 1, MidpointRounding.AwayFromZero, 100);
            RoundMultipleDouble(100, 3, 1, MidpointRounding.AwayFromZero, 99.9);
            RoundMultipleDouble(100, 4, 1, MidpointRounding.AwayFromZero, 100);
            RoundMultipleDouble(100, 5, 1, MidpointRounding.AwayFromZero, 100);
            RoundMultipleDouble(100, 6, 1, MidpointRounding.AwayFromZero, 100.2);
            RoundMultipleDouble(100, 7, 1, MidpointRounding.AwayFromZero, 100.1);
            RoundMultipleDouble(100, 8, 1, MidpointRounding.AwayFromZero, 100);
            RoundMultipleDouble(100, 9, 1, MidpointRounding.AwayFromZero, 99.9);
            RoundMultipleDouble(100, 10, 1, MidpointRounding.AwayFromZero, 100);

            RoundMultipleDouble(100, 1, 0, MidpointRounding.AwayFromZero, 100);
            RoundMultipleDouble(100, 2, 0, MidpointRounding.AwayFromZero, 100);
            RoundMultipleDouble(100, 3, 0, MidpointRounding.AwayFromZero, 99);
            RoundMultipleDouble(100, 4, 0, MidpointRounding.AwayFromZero, 100);
            RoundMultipleDouble(100, 5, 0, MidpointRounding.AwayFromZero, 100);
            RoundMultipleDouble(100, 6, 0, MidpointRounding.AwayFromZero, 102);
            RoundMultipleDouble(100, 7, 0, MidpointRounding.AwayFromZero, 98);
            RoundMultipleDouble(100, 8, 0, MidpointRounding.AwayFromZero, 104); // 100/8 => 12.5 => 13 => 13*8 => 104
            RoundMultipleDouble(100, 9, 0, MidpointRounding.AwayFromZero, 99);
            RoundMultipleDouble(100, 10, 0, MidpointRounding.AwayFromZero, 100);

            RoundMultipleDouble(-10, 3, 1, MidpointRounding.AwayFromZero, -9.9);
            RoundMultipleDouble(-9, 3, 1, MidpointRounding.AwayFromZero, -9.0);
            RoundMultipleDouble(-8, 3, 1, MidpointRounding.AwayFromZero, -8.1);
            RoundMultipleDouble(-7, 3, 1, MidpointRounding.AwayFromZero, -6.9);
            RoundMultipleDouble(-6, 3, 1, MidpointRounding.AwayFromZero, -6);
            RoundMultipleDouble(-5, 3, 1, MidpointRounding.AwayFromZero, -5.1);
            RoundMultipleDouble(-4, 3, 1, MidpointRounding.AwayFromZero, -3.9);
            RoundMultipleDouble(-3, 3, 1, MidpointRounding.AwayFromZero, -3);
            RoundMultipleDouble(-2, 3, 1, MidpointRounding.AwayFromZero, -2.1);
            RoundMultipleDouble(-1, 3, 1, MidpointRounding.AwayFromZero, -0.9);
            RoundMultipleDouble(0, 3, 1, MidpointRounding.AwayFromZero, 0);
            RoundMultipleDouble(1, 3, 1, MidpointRounding.AwayFromZero, 0.9);
            RoundMultipleDouble(2, 3, 1, MidpointRounding.AwayFromZero, 2.1);
            RoundMultipleDouble(3, 3, 1, MidpointRounding.AwayFromZero, 3);
            RoundMultipleDouble(4, 3, 1, MidpointRounding.AwayFromZero, 3.9);
            RoundMultipleDouble(5, 3, 1, MidpointRounding.AwayFromZero, 5.1);
            RoundMultipleDouble(6, 3, 1, MidpointRounding.AwayFromZero, 6);
            RoundMultipleDouble(7, 3, 1, MidpointRounding.AwayFromZero, 6.9);
            RoundMultipleDouble(8, 3, 1, MidpointRounding.AwayFromZero, 8.1);
            RoundMultipleDouble(9, 3, 1, MidpointRounding.AwayFromZero, 9);
            RoundMultipleDouble(10, 3, 1, MidpointRounding.AwayFromZero, 9.9);
        }

        [TestMethod]
        public void RoundMultipleDecimal_Digits_AwayFromZero()
        {
            RoundMultipleDecimal(100, 1, 1, MidpointRounding.AwayFromZero, 100M);
            RoundMultipleDecimal(100, 2, 1, MidpointRounding.AwayFromZero, 100M);
            RoundMultipleDecimal(100, 3, 1, MidpointRounding.AwayFromZero, 99.9M);
            RoundMultipleDecimal(100, 4, 1, MidpointRounding.AwayFromZero, 100M);
            RoundMultipleDecimal(100, 5, 1, MidpointRounding.AwayFromZero, 100M);
            RoundMultipleDecimal(100, 6, 1, MidpointRounding.AwayFromZero, 100.2M);
            RoundMultipleDecimal(100, 7, 1, MidpointRounding.AwayFromZero, 100.1M);
            RoundMultipleDecimal(100, 8, 1, MidpointRounding.AwayFromZero, 100M);
            RoundMultipleDecimal(100, 9, 1, MidpointRounding.AwayFromZero, 99.9M);
            RoundMultipleDecimal(100, 10, 1, MidpointRounding.AwayFromZero, 100M);

            RoundMultipleDecimal(100, 1, 0, MidpointRounding.AwayFromZero, 100M);
            RoundMultipleDecimal(100, 2, 0, MidpointRounding.AwayFromZero, 100M);
            RoundMultipleDecimal(100, 3, 0, MidpointRounding.AwayFromZero, 99M);
            RoundMultipleDecimal(100, 4, 0, MidpointRounding.AwayFromZero, 100M);
            RoundMultipleDecimal(100, 5, 0, MidpointRounding.AwayFromZero, 100M);
            RoundMultipleDecimal(100, 6, 0, MidpointRounding.AwayFromZero, 102M);
            RoundMultipleDecimal(100, 7, 0, MidpointRounding.AwayFromZero, 98M);
            RoundMultipleDecimal(100, 8, 0, MidpointRounding.AwayFromZero, 104M); // 100/8 => 12.5 => 13 => 13*8 => 104
            RoundMultipleDecimal(100, 9, 0, MidpointRounding.AwayFromZero, 99M);
            RoundMultipleDecimal(100, 10, 0, MidpointRounding.AwayFromZero, 100M);

            RoundMultipleDecimal(-10, 3, 1, MidpointRounding.AwayFromZero, -9.9M);
            RoundMultipleDecimal(-9, 3, 1, MidpointRounding.AwayFromZero, -9.0M);
            RoundMultipleDecimal(-8, 3, 1, MidpointRounding.AwayFromZero, -8.1M);
            RoundMultipleDecimal(-7, 3, 1, MidpointRounding.AwayFromZero, -6.9M);
            RoundMultipleDecimal(-6, 3, 1, MidpointRounding.AwayFromZero, -6M);
            RoundMultipleDecimal(-5, 3, 1, MidpointRounding.AwayFromZero, -5.1M);
            RoundMultipleDecimal(-4, 3, 1, MidpointRounding.AwayFromZero, -3.9M);
            RoundMultipleDecimal(-3, 3, 1, MidpointRounding.AwayFromZero, -3M);
            RoundMultipleDecimal(-2, 3, 1, MidpointRounding.AwayFromZero, -2.1M);
            RoundMultipleDecimal(-1, 3, 1, MidpointRounding.AwayFromZero, -0.9M);
            RoundMultipleDecimal(0, 3, 1, MidpointRounding.AwayFromZero, 0M);
            RoundMultipleDecimal(1, 3, 1, MidpointRounding.AwayFromZero, 0.9M);
            RoundMultipleDecimal(2, 3, 1, MidpointRounding.AwayFromZero, 2.1M);
            RoundMultipleDecimal(3, 3, 1, MidpointRounding.AwayFromZero, 3M);
            RoundMultipleDecimal(4, 3, 1, MidpointRounding.AwayFromZero, 3.9M);
            RoundMultipleDecimal(5, 3, 1, MidpointRounding.AwayFromZero, 5.1M);
            RoundMultipleDecimal(6, 3, 1, MidpointRounding.AwayFromZero, 6M);
            RoundMultipleDecimal(7, 3, 1, MidpointRounding.AwayFromZero, 6.9M);
            RoundMultipleDecimal(8, 3, 1, MidpointRounding.AwayFromZero, 8.1M);
            RoundMultipleDecimal(9, 3, 1, MidpointRounding.AwayFromZero, 9M);
            RoundMultipleDecimal(10, 3, 1, MidpointRounding.AwayFromZero, 9.9M);
        }

        private void RoundMultipleDouble(double value, int multiple, double expected)
        {
            Assert.AreEqual(expected, MathEx.RoundMultiple(value, multiple));
        }

        private void RoundMultipleDouble(double value, int multiple, MidpointRounding mode, double expected)
        {
            Assert.AreEqual(expected, MathEx.RoundMultiple(value, multiple, mode));
        }

        private void RoundMultipleDouble(double value, int multiple, int digits, double expected)
        {
            // If the rounding results are the same, I consider them equal.
            // Assert.AreEqual(expected, MathEx.RoundMultiple(value, multiple, digits));
            Assert.AreEqual(Math.Round(expected, digits), Math.Round(MathEx.RoundMultiple(value, multiple, digits), digits));
        }

        private void RoundMultipleDouble(double value, int multiple, int digits, MidpointRounding mode, double expected)
        {
            // If the rounding results are the same, I consider them equal.
            // Assert.AreEqual(expected, MathEx.RoundMultiple(value, multiple, digits, mode));
            Assert.AreEqual(Math.Round(expected, digits), Math.Round(MathEx.RoundMultiple(value, multiple, digits, mode), digits));
        }

        private void RoundMultipleDecimal(decimal value, int multiple, decimal expected)
        {
            Assert.AreEqual(expected, MathEx.RoundMultiple(value, multiple));
        }

        private void RoundMultipleDecimal(decimal value, int multiple, MidpointRounding mode, decimal expected)
        {
            Assert.AreEqual(expected, MathEx.RoundMultiple(value, multiple, mode));
        }

        private void RoundMultipleDecimal(decimal value, int multiple, int digits, decimal expected)
        {
            Assert.AreEqual(expected, MathEx.RoundMultiple(value, multiple, digits));
        }

        private void RoundMultipleDecimal(decimal value, int multiple, int digits, MidpointRounding mode, decimal expected)
        {
            Assert.AreEqual(expected, MathEx.RoundMultiple(value, multiple, digits, mode));
        }

        #endregion

    }

}
