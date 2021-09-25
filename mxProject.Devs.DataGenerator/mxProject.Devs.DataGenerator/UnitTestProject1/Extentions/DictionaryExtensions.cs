using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1.Extensions
{

    internal static class DictionaryExtensions
    {

        // ToStringDictionary

        #region TKey

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
            where TKey : notnull
        {
            return ToStringDictionary(dictionary, k => new string?[] { k?.ToString() }, v => new string?[] { v?.ToString() });
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey, TValue1, TValue2>(this IDictionary<TKey, (TValue1, TValue2)> dictionary)
            where TKey : notnull
        {
            return ToStringDictionary(dictionary, k => new string?[] { k?.ToString() }, v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey, TValue1, TValue2, TValue3>(this IDictionary<TKey, (TValue1, TValue2, TValue3)> dictionary)
            where TKey : notnull
        {
            return ToStringDictionary(dictionary, k => new string?[] { k?.ToString() }, v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey, TValue1, TValue2, TValue3, TValue4>(this IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4)> dictionary)
            where TKey : notnull
        {
            return ToStringDictionary(dictionary, k => new string?[] { k?.ToString() }, v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5)> dictionary)
            where TKey : notnull
        {
            return ToStringDictionary(dictionary, k => new string?[] { k?.ToString() }, v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> dictionary)
            where TKey : notnull
        {
            return ToStringDictionary(dictionary, k => new string?[] { k?.ToString() }, v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> dictionary)
            where TKey : notnull
        {
            return ToStringDictionary(dictionary, k => new string?[] { k?.ToString() }, v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> dictionary)
            where TKey : notnull
        {
            return ToStringDictionary(dictionary, k => new string?[] { k?.ToString() }, v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> dictionary)
            where TKey : notnull
        {
            return ToStringDictionary(dictionary, k => new string?[] { k?.ToString() }, v => v.ToStringArray());
        }

        #endregion

        #region (TKey1, TKey2)

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TValue>(this IDictionary<(TKey1, TKey2), TValue> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => new string?[] { v?.ToString() });
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TValue1, TValue2>(this IDictionary<(TKey1, TKey2), (TValue1, TValue2)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TValue1, TValue2, TValue3>(this IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4>(this IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        #endregion

        #region (TKey1, TKey2, TKey3)

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TValue>(this IDictionary<(TKey1, TKey2, TKey3), TValue> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => new string?[] { v?.ToString() });
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TValue1, TValue2>(this IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3>(this IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4>(this IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        #endregion

        #region (TKey1, TKey2, TKey3, TKey4)

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TValue>(this IDictionary<(TKey1, TKey2, TKey3, TKey4), TValue> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => new string?[] { v?.ToString() });
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2>(this IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3>(this IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4>(this IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        #endregion

        #region (TKey1, TKey2, TKey3, TKey4, TKey5)

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TValue>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), TValue> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => new string?[] { v?.ToString() });
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        #endregion

        #region (TKey1, TKey2, TKey3, TKey4, TKey5, TKey6)

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), TValue> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => new string?[] { v?.ToString() });
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        #endregion

        #region (TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7)

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), TValue> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => new string?[] { v?.ToString() });
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        #endregion

        #region (TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8)

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), TValue> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => new string?[] { v?.ToString() });
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        #endregion

        #region (TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9)

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), TValue> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => new string?[] { v?.ToString() });
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        internal static Dictionary<string?[], string?[]> ToStringDictionary<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> dictionary)
        {
            return ToStringDictionary(dictionary, k => k.ToStringArray(), v => v.ToStringArray());
        }

        #endregion

        private static Dictionary<string?[], string?[]> ToStringDictionary<TKey, TValue>(IDictionary<TKey, TValue> dictionary, Func<TKey, string?[]> keyConverter, Func<TValue, string?[]> valueConverter)
            where TKey : notnull
        {
            Dictionary<string?[], string?[]> dic = new Dictionary<string?[], string?[]>(dictionary.Count);

            foreach (var pair in dictionary)
            {
                dic.Add(keyConverter(pair.Key), valueConverter(pair.Value));
            }

            return dic;
        }

        #region ConvertKeyTo

        internal static Dictionary<string, string?[]> ConvertKeyToString(this IDictionary<string?[], string?[]> dictionary)
        {
            Dictionary<string, string?[]> dic = new(dictionary.Count);

            foreach (var pair in dictionary)
            {
                dic.Add(StringArrayExtensions.ConvertToString(pair.Key)!, pair.Value);
            }

            return dic;
        }

        internal static Dictionary<(string?, string?), string?[]> ConvertKeyToTuple2(this IDictionary<string?[], string?[]> dictionary)
        {
            Dictionary<(string?, string?), string?[]> dic = new(dictionary.Count);

            foreach (var pair in dictionary)
            {
                dic.Add(StringArrayExtensions.ConvertToTuple2(pair.Key), pair.Value);
            }

            return dic;
        }

        internal static Dictionary<(string?, string?, string?), string?[]> ConvertKeyToTuple3(this IDictionary<string?[], string?[]> dictionary)
        {
            Dictionary<(string?, string?, string?), string?[]> dic = new(dictionary.Count);

            foreach (var pair in dictionary)
            {
                dic.Add(pair.Key.ConvertToTuple3(), pair.Value);
            }

            return dic;
        }

        internal static Dictionary<(string?, string?, string?, string?), string?[]> ConvertKeyToTuple4(this IDictionary<string?[], string?[]> dictionary)
        {
            Dictionary<(string?, string?, string?, string?), string?[]> dic = new(dictionary.Count);

            foreach (var pair in dictionary)
            {
                dic.Add(pair.Key.ConvertToTuple4(), pair.Value);
            }

            return dic;
        }

        internal static Dictionary<(string?, string?, string?, string?, string?), string?[]> ConvertKeyToTuple5(this IDictionary<string?[], string?[]> dictionary)
        {
            Dictionary<(string?, string?, string?, string?, string?), string?[]> dic = new(dictionary.Count);

            foreach (var pair in dictionary)
            {
                dic.Add(pair.Key.ConvertToTuple5(), pair.Value);
            }

            return dic;
        }

        internal static Dictionary<(string?, string?, string?, string?, string?, string?), string?[]> ConvertKeyToTuple6(this IDictionary<string?[], string?[]> dictionary)
        {
            Dictionary<(string?, string?, string?, string?, string?, string?), string?[]> dic = new(dictionary.Count);

            foreach (var pair in dictionary)
            {
                dic.Add(pair.Key.ConvertToTuple6(), pair.Value);
            }

            return dic;
        }

        internal static Dictionary<(string?, string?, string?, string?, string?, string?, string?), string?[]> ConvertKeyToTuple7(this IDictionary<string?[], string?[]> dictionary)
        {
            Dictionary<(string?, string?, string?, string?, string?, string?, string?), string?[]> dic = new(dictionary.Count);

            foreach (var pair in dictionary)
            {
                dic.Add(pair.Key.ConvertToTuple7(), pair.Value);
            }

            return dic;
        }

        internal static Dictionary<(string?, string?, string?, string?, string?, string?, string?, string?), string?[]> ConvertKeyToTuple8(this IDictionary<string?[], string?[]> dictionary)
        {
            Dictionary<(string?, string?, string?, string?, string?, string?, string?, string?), string?[]> dic = new(dictionary.Count);

            foreach (var pair in dictionary)
            {
                dic.Add(pair.Key.ConvertToTuple8(), pair.Value);
            }

            return dic;
        }

        internal static Dictionary<(string?, string?, string?, string?, string?, string?, string?, string?, string?), string?[]> ConvertKeyToTuple9(this IDictionary<string?[], string?[]> dictionary)
        {
            Dictionary<(string?, string?, string?, string?, string?, string?, string?, string?, string?), string?[]> dic = new(dictionary.Count);

            foreach (var pair in dictionary)
            {
                dic.Add(pair.Key.ConvertToTuple9(), pair.Value);
            }

            return dic;
        }

        #endregion

    }

}
