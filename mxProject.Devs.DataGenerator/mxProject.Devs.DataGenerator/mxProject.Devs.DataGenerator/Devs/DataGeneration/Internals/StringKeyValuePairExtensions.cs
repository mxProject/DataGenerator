using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration.Internals
{

    /// <summary>
    /// 
    /// </summary>
    internal static class StringKeyValuePairExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        internal static KeyValuePair<StringValue, TValue> ToStringValue<TValue>(this KeyValuePair<string, TValue> keyValue)
        {
            return new KeyValuePair<StringValue, TValue>(keyValue.Key, keyValue.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        internal static KeyValuePair<StringValue, StringValue> ToStringValue(this KeyValuePair<string, string> keyValue)
        {
            return new KeyValuePair<StringValue, StringValue>(keyValue.Key, keyValue.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        internal static KeyValuePair<string, TValue> FromStringValue<TValue>(this KeyValuePair<StringValue, TValue> keyValue)
        {
#pragma warning disable CS8604 // Null 参照引数の可能性があります。
            return new KeyValuePair<string, TValue>(keyValue.Key.Value, keyValue.Value);
#pragma warning restore CS8604 // Null 参照引数の可能性があります。
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        internal static KeyValuePair<string, string> FromStringValue(this KeyValuePair<StringValue, StringValue> keyValue)
        {
#pragma warning disable CS8604 // Null 参照引数の可能性があります。
            return new KeyValuePair<string, string>(keyValue.Key.Value, keyValue.Value.Value);
#pragma warning restore CS8604 // Null 参照引数の可能性があります。
        }

    }

}
