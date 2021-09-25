using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Extension methods for <see cref="IDictionary{String, TValue}"/>.
    /// </summary>
    public static class StringDictionaryExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static IDictionary<StringValue, TValue> AsStringValue<TValue>(this IDictionary<string, TValue> dictionary)
        {
            return new Internals.StringDictionary<TValue>(dictionary);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static IDictionary<StringValue, StringValue> AsStringValue(this IDictionary<string, string> dictionary)
        {
            return new Internals.StringDictionary(dictionary);
        }

    }

}
