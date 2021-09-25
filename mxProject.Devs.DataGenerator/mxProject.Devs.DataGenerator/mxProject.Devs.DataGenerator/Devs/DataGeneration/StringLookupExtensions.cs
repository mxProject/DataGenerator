using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Linq;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Extension methods for <see cref="ILookup{String, TValue}"/>.
    /// </summary>
    public static class StringLookupExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="lookup"></param>
        /// <returns></returns>
        public static ILookup<StringValue, TValue> AsStringValue<TValue>(this ILookup<string, TValue> lookup)
        {
            return new Internals.StringLookup<TValue>(lookup);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lookup"></param>
        /// <returns></returns>
        public static ILookup<StringValue, StringValue> AsStringValue(this ILookup<string, string> lookup)
        {
            return new Internals.StringLookup(lookup);
        }

    }

}
