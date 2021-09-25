using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Extension methods for <see cref="String"/>.
    /// </summary>
    public static class StringExtensions
    {

        /// <summary>
        /// Converts to StringValue type.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static StringValue? ToStringValue(this string? value)
        {
            if (value== null) { return null; }
            return new StringValue(value);
        }

        /// <summary>
        /// Converts to String[].
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string[] ToStringArray(this StringValue[] values)
        {
            string[] result = new string[values.Length];

            for (int i = 0; i < values.Length; ++i)
            {
                result[i] = values[i];
            }

            return result;
        }
    }

}
