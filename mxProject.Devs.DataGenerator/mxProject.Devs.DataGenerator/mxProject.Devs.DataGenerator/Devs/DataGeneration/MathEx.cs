using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Mathematical methods.
    /// </summary>
    public static class MathEx
    {

        #region RoundMultiple

        /// <summary>
        /// Rounds to the specified multiples.
        /// </summary>
        /// <param name="value">The number to be rounded.</param>
        /// <param name="multiple">The multiple.</param>
        /// <returns></returns>
        public static double RoundMultiple(double value, int multiple)
        {
            return Math.Round(value / multiple) * multiple;
        }

        /// <summary>
        /// Rounds to the specified multiples.
        /// </summary>
        /// <param name="value">The number to be rounded.</param>
        /// <param name="multiple">The multiple.</param>
        /// <param name="mode">Specification for how to round value if it is midway between two other numbers.</param>
        /// <returns></returns>
        public static double RoundMultiple(double value, int multiple, MidpointRounding mode)
        {
            return Math.Round(value / multiple, mode) * multiple;
        }

        /// <summary>
        /// Rounds to the specified multiples.
        /// </summary>
        /// <param name="value">The number to be rounded.</param>
        /// <param name="multiple">The multiple.</param>
        /// <param name="digits">The number of fractional digits in the return value.</param>
        /// <returns></returns>
        public static double RoundMultiple(double value, int multiple, int digits)
        {
            return Math.Round(value / multiple, digits) * multiple;
        }

        /// <summary>
        /// Rounds to the specified multiples.
        /// </summary>
        /// <param name="value">The number to be rounded.</param>
        /// <param name="multiple">The multiple.</param>
        /// <param name="digits">The number of fractional digits in the return value.</param>
        /// <param name="mode">Specification for how to round value if it is midway between two other numbers.</param>
        /// <returns></returns>
        public static double RoundMultiple(double value, int multiple, int digits, MidpointRounding mode)
        {
            return Math.Round(value / multiple, digits, mode) * multiple;
        }

        /// <summary>
        /// Rounds to the specified multiples.
        /// </summary>
        /// <param name="value">The number to be rounded.</param>
        /// <param name="multiple">The multiple.</param>
        /// <returns></returns>
        public static decimal RoundMultiple(decimal value, int multiple)
        {
            return Math.Round(value / multiple) * multiple;
        }

        /// <summary>
        /// Rounds to the specified multiples.
        /// </summary>
        /// <param name="value">The number to be rounded.</param>
        /// <param name="multiple">The multiple.</param>
        /// <param name="mode">Specification for how to round value if it is midway between two other numbers.</param>
        /// <returns></returns>
        public static decimal RoundMultiple(decimal value, int multiple, MidpointRounding mode)
        {
            return Math.Round(value / multiple, mode) * multiple;
        }

        /// <summary>
        /// Rounds to the specified multiples.
        /// </summary>
        /// <param name="value">The number to be rounded.</param>
        /// <param name="multiple">The multiple.</param>
        /// <param name="decimals">The number of decimal places in the return value.</param>
        /// <returns></returns>
        public static decimal RoundMultiple(decimal value, int multiple, int decimals)
        {
            return Math.Round(value / multiple, decimals) * multiple;
        }

        /// <summary>
        /// Rounds to the specified multiples.
        /// </summary>
        /// <param name="value">The number to be rounded.</param>
        /// <param name="multiple">The multiple.</param>
        /// <param name="decimals">The number of decimal places in the return value.</param>
        /// <param name="mode">Specification for how to round value if it is midway between two other numbers.</param>
        /// <returns></returns>
        public static decimal RoundMultiple(decimal value, int multiple, int decimals, MidpointRounding mode)
        {
            return Math.Round(value / multiple, decimals, mode) * multiple;
        }

        #endregion

        #region CeilingMultiple

        /// <summary>
        /// Returns the smallest multiple that is greater than or equal to the specified value.
        /// </summary>
        /// <param name="value">The number.</param>
        /// <param name="multiple">The multiple.</param>
        /// <returns></returns>
        public static double CeilingMultiple(double value, int multiple)
        {
            return Math.Ceiling(value / multiple) * multiple;
        }

        /// <summary>
        /// Returns the smallest multiple that is greater than or equal to the specified value.
        /// </summary>
        /// <param name="value">The number.</param>
        /// <param name="multiple">The multiple.</param>
        /// <returns></returns>
        public static decimal CeilingMultiple(decimal value, int multiple)
        {
            return Math.Ceiling(value / multiple) * multiple;
        }

        #endregion

        #region FloorMultiple

        /// <summary>
        /// Returns the largest multiple that is less than or equal to the specified number.
        /// </summary>
        /// <param name="value">The number.</param>
        /// <param name="multiple">The multiple.</param>
        /// <returns></returns>
        public static decimal FloorMultiple(decimal value, int multiple)
        {
            return Math.Floor(value / multiple) * multiple;
        }

        /// <summary>
        /// Returns the largest multiple that is less than or equal to the specified number.
        /// </summary>
        /// <param name="value">The number.</param>
        /// <param name="multiple">The multiple.</param>
        /// <returns></returns>
        public static double FloorMultiple(double value, int multiple)
        {
            return Math.Floor(value / multiple) * multiple;
        }

        #endregion

    }

}
