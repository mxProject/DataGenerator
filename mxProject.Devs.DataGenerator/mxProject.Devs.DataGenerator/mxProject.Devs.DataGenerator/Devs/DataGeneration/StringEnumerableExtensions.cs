using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Extension methods for <see cref="IEnumerable{String}"/>.
    /// </summary>
    public static class StringEnumerableExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<StringValue?> AsNullableStringValue(this IEnumerable<string?> values)
        {
            foreach ( var value in values)
            {
                if (value == null)
                {
                    yield return null;
                }
                else
                {
                    yield return value;
                }
            }
        }

    }

}
