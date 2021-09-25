using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace mxProject.Devs.DataGeneration
{
    internal static class IDictionaryExtensions
    {
        readonly static Type s_Type = typeof(IDictionaryExtensions);

        internal static KeyValuePair<TKey, TValue>[] ToKeyValuePairs<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            KeyValuePair<TKey, TValue>[] pairs = new KeyValuePair<TKey, TValue>[dictionary.Count];

            int i = 0;

            foreach (var entry in dictionary)
            {
                pairs[i] = entry;
                ++i;
            }

            return pairs;
        }

        internal static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this KeyValuePair<TKey, TValue>[] pairs)
        {
            var dic = new Dictionary<TKey, TValue>(pairs.Length);

            for (int i = 0; i < pairs.Length; ++i)
            {
                dic.Add(pairs[i].Key, pairs[i].Value);
            }

            return dic;
        }

        #region wrap to IDictionary<object, object>

        /// <summary>
        /// Wraps to IDictionary&lt;object, object&gt;.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<object, object?> AsObjectAndObject<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null) { return null!; }
            return new Internals.ObjectDictionary<TKey, TValue>(dictionary);
        }

        #endregion

        #region wrap to IDictionary<object, object[]>

        /// <summary>
        /// Wraps to IDictionary&lt;object, object[]&gt;.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<object, object?[]> AsObjectAndArray<TKey, TValue1, TValue2>(this IDictionary<TKey, (TValue1, TValue2)> dictionary)
        {
            if (dictionary == null) { return null!; }
            return new Internals.ObjectArrayDictionary<TKey, TValue1, TValue2>(dictionary);
        }

        /// <summary>
        /// Wraps to IDictionary&lt;object, object[]&gt;.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<object, object?[]> AsObjectAndArray<TKey, TValue1, TValue2, TValue3>(this IDictionary<TKey, (TValue1, TValue2, TValue3)> dictionary)
        {
            if (dictionary == null) { return null!; }
            return new Internals.ObjectArrayDictionary<TKey, TValue1, TValue2, TValue3>(dictionary);
        }

        /// <summary>
        /// Wraps to IDictionary&lt;object, object[]&gt;.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<object, object?[]> AsObjectAndArray<TKey, TValue1, TValue2, TValue3, TValue4>(this IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4)> dictionary)
        {
            if (dictionary == null) { return null!; }
            return new Internals.ObjectArrayDictionary<TKey, TValue1, TValue2, TValue3, TValue4>(dictionary);
        }

        /// <summary>
        /// Wraps to IDictionary&lt;object, object[]&gt;.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<object, object?[]> AsObjectAndArray<TKey, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5)> dictionary)
        {
            if (dictionary == null) { return null!; }
            return new Internals.ObjectArrayDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5>(dictionary);
        }

        /// <summary>
        /// Wraps to IDictionary&lt;object, object[]&gt;.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<object, object?[]> AsObjectAndArray<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> dictionary)
        {
            if (dictionary == null) { return null!; }
            return new Internals.ObjectArrayDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(dictionary);
        }

        /// <summary>
        /// Wraps to IDictionary&lt;object, object[]&gt;.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<object, object?[]> AsObjectAndArray<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> dictionary)
        {
            if (dictionary == null) { return null!; }
            return new Internals.ObjectArrayDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(dictionary);
        }

        /// <summary>
        /// Wraps to IDictionary&lt;object, object[]&gt;.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<object, object?[]> AsObjectAndArray<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> dictionary)
        {
            if (dictionary == null) { return null!; }
            return new Internals.ObjectArrayDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(dictionary);
        }

        #endregion

        #region wrap to IDictionary<object[], object>

        /// <summary>
        /// Wraps to IDictionary&lt;object[], object&gt;.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<object?[], object?> AsArrayAndObject<TKey1, TKey2, TValue>(this IDictionary<(TKey1, TKey2), TValue> dictionary)
        {
            if (dictionary == null) { return null!; }
            return new Internals.ArrayObjectDictionary<TKey1, TKey2, TValue>(dictionary);
        }

        #endregion

        #region Cast

        #region key1 IDictionary<object, object>

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key_Value(this IDictionary<object, object?> dictionary, Type keyType, Type valueType)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key_Value), typeof(IDictionary<object, object?>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, TValue?> Cast_Key_Value<TKey, TValue>(this IDictionary<object, object?> dictionary)
            where TKey : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            Dictionary<TKey, TValue?> typed = new Dictionary<TKey, TValue?>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Cast<TKey>(entry.Key);
                    TValue? value = CastOrNull<TValue>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region key1 IDictionary<object, object[]>

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key_Value1(this IDictionary<object, object?[]> dictionary, Type keyType, Type valueType)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key_Value1), typeof(IDictionary<object, object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, TValue?> Cast_Key_Value1<TKey, TValue>(this IDictionary<object, object?[]> dictionary)
            where TKey : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            Dictionary<TKey, TValue?> typed = new Dictionary<TKey, TValue?>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Cast<TKey>(entry.Key);
                    TValue? value = CastOrNull<TValue>(entry.Value[0]);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key_Value2(this IDictionary<object, object?[]> dictionary, Type keyType, Type valueType1, Type valueType2)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key_Value2), typeof(IDictionary<object, object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?)> Cast_Key_Value2<TKey, TValue1, TValue2>(this IDictionary<object, object?[]> dictionary)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Cast<TKey>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key_Value3(this IDictionary<object, object?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key_Value3), typeof(IDictionary<object, object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?)> Cast_Key_Value3<TKey, TValue1, TValue2, TValue3>(this IDictionary<object, object?[]> dictionary)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Cast<TKey>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key_Value4(this IDictionary<object, object?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key_Value4), typeof(IDictionary<object, object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?)> Cast_Key_Value4<TKey, TValue1, TValue2, TValue3, TValue4>(this IDictionary<object, object?[]> dictionary)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Cast<TKey>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3, TValue4>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key_Value5(this IDictionary<object, object?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key_Value5), typeof(IDictionary<object, object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4, valueType5 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> Cast_Key_Value5<TKey, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<object, object?[]> dictionary)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Cast<TKey>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key_Value6(this IDictionary<object, object?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key_Value6), typeof(IDictionary<object, object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> Cast_Key_Value6<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<object, object?[]> dictionary)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Cast<TKey>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key_Value7(this IDictionary<object, object?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key_Value7), typeof(IDictionary<object, object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> Cast_Key_Value7<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<object, object?[]> dictionary)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Cast<TKey>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key_Value8(this IDictionary<object, object?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key_Value8), typeof(IDictionary<object, object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> Cast_Key_Value8<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<object, object?[]> dictionary)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Cast<TKey>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region key1 IDictionary<object[], object>

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key1_Value(this IDictionary<object?[], object?> dictionary, Type keyType, Type valueType)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key1_Value), typeof(IDictionary<object?[], object?>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, TValue?> Cast_Key1_Value<TKey, TValue>(this IDictionary<object?[], object?> dictionary)
            where TKey : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            Dictionary<TKey, TValue?> typed = new Dictionary<TKey, TValue?>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Cast<TKey>(entry.Key[0]!);
                    TValue? value = CastOrNull<TValue>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region key1 IDictionary<object[], object[]>

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key1_Value1(this IDictionary<object?[], object?[]> dictionary, Type keyType, Type valueType)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key1_Value1), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, TValue?> Cast_Key1_Value1<TKey, TValue>(this IDictionary<object?[], object?[]> dictionary)
            where TKey : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, TValue?>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = Cast<TKey>(entry.Key[0]!);
                    var value = CastOrNull<TValue>(entry.Value[0]);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key1_Value2(this IDictionary<object?[], object?[]> dictionary, Type keyType, Type valueType1, Type valueType2)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key1_Value2), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?)> Cast_Key1_Value2<TKey, TValue1, TValue2>(this IDictionary<object?[], object?[]> dictionary)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Cast<TKey>(entry.Key[0]!);
                    var value = ToNullableTuple<TValue1, TValue2>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key1_Value3(this IDictionary<object?[], object?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key1_Value3), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?)> Cast_Key1_Value3<TKey, TValue1, TValue2, TValue3>(this IDictionary<object?[], object?[]> dictionary)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Cast<TKey>(entry.Key[0]!);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key1_Value4(this IDictionary<object?[], object?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key1_Value4), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?)> Cast_Key1_Value4<TKey, TValue1, TValue2, TValue3, TValue4>(this IDictionary<object?[], object?[]> dictionary)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Cast<TKey>(entry.Key[0]!);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3, TValue4>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key1_Value5(this IDictionary<object?[], object?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key1_Value5), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4, valueType5 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> Cast_Key1_Value5<TKey, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<object?[], object?[]> dictionary)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Cast<TKey>(entry.Key[0]!);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key1_Value6(this IDictionary<object?[], object?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key1_Value6), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> Cast_Key1_Value6<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<object?[], object?[]> dictionary)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Cast<TKey>(entry.Key[0]!);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key1_Value7(this IDictionary<object?[], object?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key1_Value7), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> Cast_Key1_Value7<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<object?[], object?[]> dictionary)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Cast<TKey>(entry.Key[0]!);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key1_Value8(this IDictionary<object?[], object?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key1_Value8), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> Cast_Key1_Value8<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<object?[], object?[]> dictionary)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Cast<TKey>(entry.Key[0]!);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region key2 IDictionary<object?[], object>

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key2_Value(this IDictionary<object?[], object?> dictionary, Type keyType1, Type keyType2, Type valueType)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key2_Value), typeof(IDictionary<object?[], object?>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, valueType }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), TValue?> Cast_Key2_Value<TKey1, TKey2, TValue>(this IDictionary<object?[], object?> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?), TValue?>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2>(entry.Key);
                    var value = CastOrNull<TValue>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region key2 IDictionary<object[], object[]>

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key2_Value1(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type valueType)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key2_Value1), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, valueType }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), TValue?> Cast_Key2_Value1<TKey1, TKey2, TValue>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?), TValue?>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2>(entry.Key);
                    TValue? value = CastOrNull<TValue>(entry.Value[0]);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key2_Value2(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type valueType1, Type valueType2)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key2_Value2), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, valueType1, valueType2 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?)> Cast_Key2_Value2<TKey1, TKey2, TValue1, TValue2>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key2_Value3(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type valueType1, Type valueType2, Type valueType3)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key2_Value3), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, valueType1, valueType2, valueType3 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?)> Cast_Key2_Value3<TKey1, TKey2, TValue1, TValue2, TValue3>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key2_Value4(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type valueType1, Type valueType2, Type valueType3, Type valueType4)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key2_Value4), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, valueType1, valueType2, valueType3, valueType4 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?)> Cast_Key2_Value4<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3, TValue4>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key2_Value5(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key2_Value5), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, valueType1, valueType2, valueType3, valueType4, valueType5 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> Cast_Key2_Value5<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key2_Value6(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key2_Value6), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> Cast_Key2_Value6<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key2_Value7(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key2_Value7), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> Cast_Key2_Value7<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region key3 IDictionary<object[], object>

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key3_Value(this IDictionary<object?[], object?> dictionary, Type keyType1, Type keyType2, Type keyType3, Type valueType)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key3_Value), typeof(IDictionary<object?[], object?>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, valueType }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), TValue?> Cast_Key3_Value<TKey1, TKey2, TKey3, TValue>(this IDictionary<object?[], object?> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?), TValue?>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3>(entry.Key);
                    var value = CastOrNull<TValue>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region key3 IDictionary<object[], object[]>

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key3_Value1(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type valueType)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key3_Value1), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, valueType }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), TValue?> Cast_Key3_Value1<TKey1, TKey2, TKey3, TValue>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?), TValue?>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3>(entry.Key);
                    var value = CastOrNull<TValue>(entry.Value[0]);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key3_Value2(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type valueType1, Type valueType2)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key3_Value2), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, valueType1, valueType2 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?)> Cast_Key3_Value2<TKey1, TKey2, TKey3, TValue1, TValue2>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key3_Value3(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type valueType1, Type valueType2, Type valueType3)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key3_Value3), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, valueType1, valueType2, valueType3 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?)> Cast_Key3_Value3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key3_Value4(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type valueType1, Type valueType2, Type valueType3, Type valueType4)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key3_Value4), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, valueType1, valueType2, valueType3, valueType4 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?)> Cast_Key3_Value4<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3, TValue4>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key3_Value5(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key3_Value5), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, valueType1, valueType2, valueType3, valueType4, valueType5 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> Cast_Key3_Value5<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key3_Value6(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key3_Value6), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> Cast_Key3_Value6<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region key4 IDictionary<object[], object>

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key4_Value(this IDictionary<object?[], object?> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type valueType)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key4_Value), typeof(IDictionary<object?[], object?>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, valueType }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TValue?> Cast_Key4_Value<TKey1, TKey2, TKey3, TKey4, TValue>(this IDictionary<object?[], object?> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TValue?>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3, TKey4>(entry.Key);
                    var value = CastOrNull<TValue>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region key4 IDictionary<object[], object[]>

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key4_Value1(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type valueType)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key4_Value1), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, valueType }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TValue?> Cast_Key4_Value1<TKey1, TKey2, TKey3, TKey4, TValue>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TValue?>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3, TKey4>(entry.Key);
                    var value = CastOrNull<TValue>(entry.Value[0]);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key4_Value2(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type valueType1, Type valueType2)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key4_Value2), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, valueType1, valueType2 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?)> Cast_Key4_Value2<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3, TKey4>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key4_Value3(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type valueType1, Type valueType2, Type valueType3)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key4_Value3), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, valueType1, valueType2, valueType3 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?)> Cast_Key4_Value3<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3, TKey4>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key4_Value4(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type valueType1, Type valueType2, Type valueType3, Type valueType4)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key4_Value4), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, valueType1, valueType2, valueType3, valueType4 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?)> Cast_Key4_Value4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3, TKey4>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3, TValue4>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key4_Value5(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key4_Value5), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, valueType1, valueType2, valueType3, valueType4, valueType5 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> Cast_Key4_Value5<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3, TKey4>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region key5 IDictionary<object[], object>

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key5_Value(this IDictionary<object?[], object?> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type valueType)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key5_Value), typeof(IDictionary<object?[], object?>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, valueType }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TValue?> Cast_Key5_Value<TKey1, TKey2, TKey3, TKey4, TKey5, TValue>(this IDictionary<object?[], object?> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TValue?>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(entry.Key);
                    var value = CastOrNull<TValue>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region key5 IDictionary<object[], object[]>

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key5_Value1(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type valueType)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key5_Value1), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, valueType }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TValue?> Cast_Key5_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TValue>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TValue?>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(entry.Key);
                    var value = CastOrNull<TValue>(entry.Value[0]);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key5_Value2(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type valueType1, Type valueType2)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key5_Value2), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, valueType1, valueType2 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?)> Cast_Key5_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key5_Value3(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type valueType1, Type valueType2, Type valueType3)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key5_Value3), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, valueType1, valueType2, valueType3 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?)> Cast_Key5_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key5_Value4(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type valueType1, Type valueType2, Type valueType3, Type valueType4)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key5_Value4), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, valueType1, valueType2, valueType3, valueType4 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?)> Cast_Key5_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3, TValue4>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region key6 IDictionary<object[], object>

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key6_Value(this IDictionary<object?[], object?> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type valueType)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key6_Value), typeof(IDictionary<object?[], object?>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, valueType }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TValue?> Cast_Key6_Value<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue>(this IDictionary<object?[], object?> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TValue?>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(entry.Key);
                    var value = CastOrNull<TValue>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region key6 IDictionary<object[], object[]>

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key6_Value1(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type valueType)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key6_Value1), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, valueType }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TValue?> Cast_Key6_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TValue?>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(entry.Key);
                    TValue? value = CastOrNull<TValue>(entry.Value[0]);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key6_Value2(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type valueType1, Type valueType2)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key6_Value2), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, valueType1, valueType2 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?)> Cast_Key6_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key6_Value3(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type valueType1, Type valueType2, Type valueType3)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key6_Value3), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, valueType1, valueType2, valueType3 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?)> Cast_Key6_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2, TValue3>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region key7 IDictionary<object[], object>

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key7_Value(this IDictionary<object?[], object?> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type valueType)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key7_Value), typeof(IDictionary<object?[], object?>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, valueType }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TValue?> Cast_Key7_Value<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue>(this IDictionary<object?[], object?> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TValue?>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(entry.Key);
                    var value = CastOrNull<TValue>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region key7 IDictionary<object[], object[]>

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key7_Value1(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type valueType)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key7_Value1), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, valueType }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TValue?> Cast_Key7_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TValue?>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(entry.Key);
                    var value = CastOrNull<TValue>(entry.Value[0]);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key7_Value2(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type valueType1, Type valueType2)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key7_Value2), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, valueType1, valueType2 }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?)> Cast_Key7_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?)>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(entry.Key);
                    var value = ToNullableTuple<TValue1, TValue2>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region key8 IDictionary<object[], object>

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key8_Value(this IDictionary<object?[], object?> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type valueType)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key8_Value), typeof(IDictionary<object?[], object?>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, valueType }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TValue?> Cast_Key8_Value<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue>(this IDictionary<object?[], object?> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TValue?>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(entry.Key);
                    var value = CastOrNull<TValue>(entry.Value);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region key8 IDictionary<object[], object[]>

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        internal static IDictionary Cast_Key8_Value1(this IDictionary<object?[], object?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type valueType)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Cast_Key8_Value1), typeof(IDictionary<object?[], object?[]>));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, valueType }, dictionary);
        }

        /// <summary>
        /// Casts the key and value of the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TValue?> Cast_Key8_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue>(this IDictionary<object?[], object?[]> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TValue?>(dictionary.Count);

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToNullableTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(entry.Key);
                    var value = CastOrNull<TValue>(entry.Value[0]);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #endregion

        #region Parse

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyTypes"></param>
        /// <param name="valueTypes"></param>
        /// <param name="stringConverter"></param>
        /// <returns></returns>
        internal static System.Collections.IDictionary Parse(this IDictionary<string?[], string?[]> dictionary, Type[] keyTypes, Type[] valueTypes, IStringConverter stringConverter)
        {
            switch (keyTypes.Length)
            {
                case 1:

                    if (valueTypes.Length == 1)
                    {
                        return dictionary.Parse_Key1_Value1(keyTypes[0], valueTypes[0], stringConverter);
                    }
                    else if (valueTypes.Length == 2)
                    {
                        return dictionary.Parse_Key1_Value2(keyTypes[0], valueTypes[0], valueTypes[1], stringConverter);
                    }
                    else if (valueTypes.Length == 3)
                    {
                        return dictionary.Parse_Key1_Value3(keyTypes[0], valueTypes[0], valueTypes[1], valueTypes[2], stringConverter);
                    }
                    else if (valueTypes.Length == 4)
                    {
                        return dictionary.Parse_Key1_Value4(keyTypes[0], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], stringConverter);
                    }
                    else if (valueTypes.Length == 5)
                    {
                        return dictionary.Parse_Key1_Value5(keyTypes[0], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], stringConverter);
                    }
                    else if (valueTypes.Length == 6)
                    {
                        return dictionary.Parse_Key1_Value6(keyTypes[0], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], stringConverter);
                    }
                    else if (valueTypes.Length == 7)
                    {
                        return dictionary.Parse_Key1_Value7(keyTypes[0], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], stringConverter);
                    }
                    else if (valueTypes.Length == 8)
                    {
                        return dictionary.Parse_Key1_Value8(keyTypes[0], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], stringConverter);
                    }
                    else if (valueTypes.Length == 9)
                    {
                        return dictionary.Parse_Key1_Value9(keyTypes[0], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8], stringConverter);
                    }

                    break;

                case 2:

                    if (valueTypes.Length == 1)
                    {
                        return dictionary.Parse_Key2_Value1(keyTypes[0], keyTypes[1], valueTypes[0], stringConverter);
                    }
                    else if (valueTypes.Length == 2)
                    {
                        return dictionary.Parse_Key2_Value2(keyTypes[0], keyTypes[1], valueTypes[0], valueTypes[1], stringConverter);
                    }
                    else if (valueTypes.Length == 3)
                    {
                        return dictionary.Parse_Key2_Value3(keyTypes[0], keyTypes[1], valueTypes[0], valueTypes[1], valueTypes[2], stringConverter);
                    }
                    else if (valueTypes.Length == 4)
                    {
                        return dictionary.Parse_Key2_Value4(keyTypes[0], keyTypes[1], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], stringConverter);
                    }
                    else if (valueTypes.Length == 5)
                    {
                        return dictionary.Parse_Key2_Value5(keyTypes[0], keyTypes[1], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], stringConverter);
                    }
                    else if (valueTypes.Length == 6)
                    {
                        return dictionary.Parse_Key2_Value6(keyTypes[0], keyTypes[1], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], stringConverter);
                    }
                    else if (valueTypes.Length == 7)
                    {
                        return dictionary.Parse_Key2_Value7(keyTypes[0], keyTypes[1], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], stringConverter);
                    }
                    else if (valueTypes.Length == 8)
                    {
                        return dictionary.Parse_Key2_Value8(keyTypes[0], keyTypes[1], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], stringConverter);
                    }
                    else if (valueTypes.Length == 9)
                    {
                        return dictionary.Parse_Key2_Value9(keyTypes[0], keyTypes[1], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8], stringConverter);
                    }

                    break;

                case 3:

                    if (valueTypes.Length == 1)
                    {
                        return dictionary.Parse_Key3_Value1(keyTypes[0], keyTypes[1], keyTypes[2], valueTypes[0], stringConverter);
                    }
                    else if (valueTypes.Length == 2)
                    {
                        return dictionary.Parse_Key3_Value2(keyTypes[0], keyTypes[1], keyTypes[2], valueTypes[0], valueTypes[1], stringConverter);
                    }
                    else if (valueTypes.Length == 3)
                    {
                        return dictionary.Parse_Key3_Value3(keyTypes[0], keyTypes[1], keyTypes[2], valueTypes[0], valueTypes[1], valueTypes[2], stringConverter);
                    }
                    else if (valueTypes.Length == 4)
                    {
                        return dictionary.Parse_Key3_Value4(keyTypes[0], keyTypes[1], keyTypes[2], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], stringConverter);
                    }
                    else if (valueTypes.Length == 5)
                    {
                        return dictionary.Parse_Key3_Value5(keyTypes[0], keyTypes[1], keyTypes[2], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], stringConverter);
                    }
                    else if (valueTypes.Length == 6)
                    {
                        return dictionary.Parse_Key3_Value6(keyTypes[0], keyTypes[1], keyTypes[2], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], stringConverter);
                    }
                    else if (valueTypes.Length == 7)
                    {
                        return dictionary.Parse_Key3_Value7(keyTypes[0], keyTypes[1], keyTypes[2], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], stringConverter);
                    }
                    else if (valueTypes.Length == 8)
                    {
                        return dictionary.Parse_Key3_Value8(keyTypes[0], keyTypes[1], keyTypes[2], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], stringConverter);
                    }
                    else if (valueTypes.Length == 9)
                    {
                        return dictionary.Parse_Key3_Value9(keyTypes[0], keyTypes[1], keyTypes[2], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8], stringConverter);
                    }

                    break;

                case 4:

                    if (valueTypes.Length == 1)
                    {
                        return dictionary.Parse_Key4_Value1(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], valueTypes[0], stringConverter);
                    }
                    else if (valueTypes.Length == 2)
                    {
                        return dictionary.Parse_Key4_Value2(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], valueTypes[0], valueTypes[1], stringConverter);
                    }
                    else if (valueTypes.Length == 3)
                    {
                        return dictionary.Parse_Key4_Value3(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], valueTypes[0], valueTypes[1], valueTypes[2], stringConverter);
                    }
                    else if (valueTypes.Length == 4)
                    {
                        return dictionary.Parse_Key4_Value4(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], stringConverter);
                    }
                    else if (valueTypes.Length == 5)
                    {
                        return dictionary.Parse_Key4_Value5(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], stringConverter);
                    }
                    else if (valueTypes.Length == 6)
                    {
                        return dictionary.Parse_Key4_Value6(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], stringConverter);
                    }
                    else if (valueTypes.Length == 7)
                    {
                        return dictionary.Parse_Key4_Value7(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], stringConverter);
                    }
                    else if (valueTypes.Length == 8)
                    {
                        return dictionary.Parse_Key4_Value8(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], stringConverter);
                    }
                    else if (valueTypes.Length == 9)
                    {
                        return dictionary.Parse_Key4_Value9(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8], stringConverter);
                    }

                    break;

                case 5:

                    if (valueTypes.Length == 1)
                    {
                        return dictionary.Parse_Key5_Value1(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], valueTypes[0], stringConverter);
                    }
                    else if (valueTypes.Length == 2)
                    {
                        return dictionary.Parse_Key5_Value2(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], valueTypes[0], valueTypes[1], stringConverter);
                    }
                    else if (valueTypes.Length == 3)
                    {
                        return dictionary.Parse_Key5_Value3(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], valueTypes[0], valueTypes[1], valueTypes[2], stringConverter);
                    }
                    else if (valueTypes.Length == 4)
                    {
                        return dictionary.Parse_Key5_Value4(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], stringConverter);
                    }
                    else if (valueTypes.Length == 5)
                    {
                        return dictionary.Parse_Key5_Value5(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], stringConverter);
                    }
                    else if (valueTypes.Length == 6)
                    {
                        return dictionary.Parse_Key5_Value6(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], stringConverter);
                    }
                    else if (valueTypes.Length == 7)
                    {
                        return dictionary.Parse_Key5_Value7(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], stringConverter);
                    }
                    else if (valueTypes.Length == 8)
                    {
                        return dictionary.Parse_Key5_Value8(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], stringConverter);
                    }
                    else if (valueTypes.Length == 9)
                    {
                        return dictionary.Parse_Key5_Value9(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8], stringConverter);
                    }

                    break;

                case 6:

                    if (valueTypes.Length == 1)
                    {
                        return dictionary.Parse_Key6_Value1(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], valueTypes[0], stringConverter);
                    }
                    else if (valueTypes.Length == 2)
                    {
                        return dictionary.Parse_Key6_Value2(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], valueTypes[0], valueTypes[1], stringConverter);
                    }
                    else if (valueTypes.Length == 3)
                    {
                        return dictionary.Parse_Key6_Value3(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], valueTypes[0], valueTypes[1], valueTypes[2], stringConverter);
                    }
                    else if (valueTypes.Length == 4)
                    {
                        return dictionary.Parse_Key6_Value4(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], stringConverter);
                    }
                    else if (valueTypes.Length == 5)
                    {
                        return dictionary.Parse_Key6_Value5(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], stringConverter);
                    }
                    else if (valueTypes.Length == 6)
                    {
                        return dictionary.Parse_Key6_Value6(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], stringConverter);
                    }
                    else if (valueTypes.Length == 7)
                    {
                        return dictionary.Parse_Key6_Value7(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], stringConverter);
                    }
                    else if (valueTypes.Length == 8)
                    {
                        return dictionary.Parse_Key6_Value8(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], stringConverter);
                    }
                    else if (valueTypes.Length == 9)
                    {
                        return dictionary.Parse_Key6_Value9(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8], stringConverter);
                    }

                    break;

                case 7:

                    if (valueTypes.Length == 1)
                    {
                        return dictionary.Parse_Key7_Value1(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], valueTypes[0], stringConverter);
                    }
                    else if (valueTypes.Length == 2)
                    {
                        return dictionary.Parse_Key7_Value2(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], valueTypes[0], valueTypes[1], stringConverter);
                    }
                    else if (valueTypes.Length == 3)
                    {
                        return dictionary.Parse_Key7_Value3(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], valueTypes[0], valueTypes[1], valueTypes[2], stringConverter);
                    }
                    else if (valueTypes.Length == 4)
                    {
                        return dictionary.Parse_Key7_Value4(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], stringConverter);
                    }
                    else if (valueTypes.Length == 5)
                    {
                        return dictionary.Parse_Key7_Value5(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], stringConverter);
                    }
                    else if (valueTypes.Length == 6)
                    {
                        return dictionary.Parse_Key7_Value6(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], stringConverter);
                    }
                    else if (valueTypes.Length == 7)
                    {
                        return dictionary.Parse_Key7_Value7(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], stringConverter);
                    }
                    else if (valueTypes.Length == 8)
                    {
                        return dictionary.Parse_Key7_Value8(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], stringConverter);
                    }
                    else if (valueTypes.Length == 9)
                    {
                        return dictionary.Parse_Key7_Value9(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8], stringConverter);
                    }

                    break;

                case 8:

                    if (valueTypes.Length == 1)
                    {
                        return dictionary.Parse_Key8_Value1(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], valueTypes[0], stringConverter);
                    }
                    else if (valueTypes.Length == 2)
                    {
                        return dictionary.Parse_Key8_Value2(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], valueTypes[0], valueTypes[1], stringConverter);
                    }
                    else if (valueTypes.Length == 3)
                    {
                        return dictionary.Parse_Key8_Value3(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], valueTypes[0], valueTypes[1], valueTypes[2], stringConverter);
                    }
                    else if (valueTypes.Length == 4)
                    {
                        return dictionary.Parse_Key8_Value4(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], stringConverter);
                    }
                    else if (valueTypes.Length == 5)
                    {
                        return dictionary.Parse_Key8_Value5(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], stringConverter);
                    }
                    else if (valueTypes.Length == 6)
                    {
                        return dictionary.Parse_Key8_Value6(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], stringConverter);
                    }
                    else if (valueTypes.Length == 7)
                    {
                        return dictionary.Parse_Key8_Value7(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], stringConverter);
                    }
                    else if (valueTypes.Length == 8)
                    {
                        return dictionary.Parse_Key8_Value8(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], stringConverter);
                    }
                    else if (valueTypes.Length == 9)
                    {
                        return dictionary.Parse_Key8_Value9(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8], stringConverter);
                    }

                    break;

                case 9:

                    if (valueTypes.Length == 1)
                    {
                        return dictionary.Parse_Key9_Value1(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8], valueTypes[0], stringConverter);
                    }
                    else if (valueTypes.Length == 2)
                    {
                        return dictionary.Parse_Key9_Value2(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8], valueTypes[0], valueTypes[1], stringConverter);
                    }
                    else if (valueTypes.Length == 3)
                    {
                        return dictionary.Parse_Key9_Value3(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8], valueTypes[0], valueTypes[1], valueTypes[2], stringConverter);
                    }
                    else if (valueTypes.Length == 4)
                    {
                        return dictionary.Parse_Key9_Value4(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], stringConverter);
                    }
                    else if (valueTypes.Length == 5)
                    {
                        return dictionary.Parse_Key9_Value5(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], stringConverter);
                    }
                    else if (valueTypes.Length == 6)
                    {
                        return dictionary.Parse_Key9_Value6(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], stringConverter);
                    }
                    else if (valueTypes.Length == 7)
                    {
                        return dictionary.Parse_Key9_Value7(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], stringConverter);
                    }
                    else if (valueTypes.Length == 8)
                    {
                        return dictionary.Parse_Key9_Value8(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], stringConverter);
                    }
                    else if (valueTypes.Length == 9)
                    {
                        return dictionary.Parse_Key9_Value9(keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8], valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8], stringConverter);
                    }

                    break;

                default:
                    break;
            }

            throw new NotSupportedException("The specified number of additional fields is not supported.");
        }

        #region Parse_Key_Value

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key_Value(this IDictionary<string, string?> dictionary, Type keyType, Type valueType, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key_Value), typeof(IDictionary<string, string?>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, TValue?> Parse_Key_Value<TKey, TValue>(this IDictionary<string, string?> dictionary, IStringConverter converter)
            where TKey : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            Dictionary<TKey, TValue?> typed = new Dictionary<TKey, TValue?>();

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Convert<TKey>(entry.Key, converter);
                    var value = ConvertOrNull<TValue>(entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key_Value1

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key_Value1(this IDictionary<string, string?[]> dictionary, Type keyType, Type valueType, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key_Value1), typeof(IDictionary<string, string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, TValue?> Parse_Key_Value1<TKey, TValue>(this IDictionary<string, string?[]> dictionary, IStringConverter converter)
            where TKey : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            Dictionary<TKey, TValue?> typed = new Dictionary<TKey, TValue?>();

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Convert<TKey>(entry.Key, converter);
                    var value = ConvertOrNull<TValue>(entry.Value[0], converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key_Value2

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key_Value2(this IDictionary<string, string?[]> dictionary, Type keyType, Type valueType1, Type valueType2, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key_Value2), typeof(IDictionary<string, string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?)> Parse_Key_Value2<TKey, TValue1, TValue2>(this IDictionary<string, string?[]> dictionary, IStringConverter converter)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Convert<TKey>(entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key_Value3

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key_Value3(this IDictionary<string, string?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key_Value3), typeof(IDictionary<string, string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?)> Parse_Key_Value3<TKey, TValue1, TValue2, TValue3>(this IDictionary<string, string?[]> dictionary, IStringConverter converter)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Convert<TKey>(entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key_Value4

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key_Value4(this IDictionary<string, string?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key_Value4), typeof(IDictionary<string, string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?)> Parse_Key_Value4<TKey, TValue1, TValue2, TValue3, TValue4>(this IDictionary<string, string?[]> dictionary, IStringConverter converter)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Convert<TKey>(entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key_Value5

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key_Value5(this IDictionary<string, string?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key_Value5), typeof(IDictionary<string, string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4, valueType5 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> Parse_Key_Value5<TKey, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<string, string?[]> dictionary, IStringConverter converter)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Convert<TKey>(entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key_Value6

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key_Value6(this IDictionary<string, string?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key_Value6), typeof(IDictionary<string, string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> Parse_Key_Value6<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<string, string?[]> dictionary, IStringConverter converter)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Convert<TKey>(entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key_Value7

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key_Value7(this IDictionary<string, string?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key_Value7), typeof(IDictionary<string, string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> Parse_Key_Value7<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<string, string?[]> dictionary, IStringConverter converter)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Convert<TKey>(entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key_Value8

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key_Value8(this IDictionary<string, string?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key_Value8), typeof(IDictionary<string, string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> Parse_Key_Value8<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<string, string?[]> dictionary, IStringConverter converter)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Convert<TKey>(entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key_Value9

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <param name="valueType9"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key_Value9(this IDictionary<string, string?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8, Type valueType9, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key_Value8), typeof(IDictionary<string, string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8, valueType9 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> Parse_Key_Value8<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<string, string?[]> dictionary, IStringConverter converter)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Convert<TKey>(entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key1_Value

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key1_Value(this IDictionary<string?[], string?> dictionary, Type keyType, Type valueType, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key1_Value), typeof(IDictionary<string?[], string?>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, TValue?> Parse_Key1_Value<TKey, TValue>(this IDictionary<string?[], string?> dictionary, IStringConverter converter)
            where TKey : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            Dictionary<TKey, TValue?> typed = new Dictionary<TKey, TValue?>();

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Convert<TKey>(entry.Key[0]!, converter);
                    var value = ConvertOrNull<TValue>(entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key1_Value1

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key1_Value1(this IDictionary<string?[], string?[]> dictionary, Type keyType, Type valueType, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key1_Value1), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, TValue? > Parse_Key1_Value1<TKey, TValue>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            Dictionary<TKey, TValue?> typed = new Dictionary<TKey, TValue?>();

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Convert<TKey>(entry.Key[0]!, converter);
                    var value = ConvertOrNull<TValue>(entry.Value[0], converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key1_Value2

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key1_Value2(this IDictionary<string?[], string?[]> dictionary, Type keyType, Type valueType1, Type valueType2, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key1_Value2), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?)> Parse_Key1_Value2<TKey, TValue1, TValue2>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Convert<TKey>(entry.Key[0]!, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key1_Value3

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key1_Value3(this IDictionary<string?[], string?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key1_Value3), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?)> Parse_Key1_Value3<TKey, TValue1, TValue2, TValue3>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Convert<TKey>(entry.Key[0]!, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key1_Value4

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key1_Value4(this IDictionary<string?[], string?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key1_Value4), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?)> Parse_Key1_Value4<TKey, TValue1, TValue2, TValue3, TValue4>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Convert<TKey>(entry.Key[0]!, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key1_Value5

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key1_Value5(this IDictionary<string?[], string?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key1_Value5), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4, valueType5 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> Parse_Key1_Value5<TKey, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Convert<TKey>(entry.Key[0]!, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key1_Value6

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key1_Value6(this IDictionary<string?[], string?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key1_Value6), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> Parse_Key1_Value6<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Convert<TKey>(entry.Key[0]!, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key1_Value7

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key1_Value7(this IDictionary<string?[], string?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key1_Value7), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> Parse_Key1_Value7<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Convert<TKey>(entry.Key[0]!, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key1_Value8

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key1_Value8(this IDictionary<string?[], string?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key1_Value8), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> Parse_Key1_Value8<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Convert<TKey>(entry.Key[0]!, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key1_Value9

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <param name="valueType9"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key1_Value9(this IDictionary<string?[], string?[]> dictionary, Type keyType, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8, Type valueType9, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key1_Value9), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8, valueType9 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> Parse_Key1_Value9<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    TKey key = Convert<TKey>(entry.Key[0]!, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key2_Value

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="valueType"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key2_Value(this IDictionary<string?[], string?> dictionary, Type keyType1, Type keyType2, Type valueType, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key2_Value), typeof(IDictionary<string?[], string?>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, valueType }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), TValue?> Parse_Key2_Value<TKey1, TKey2, TValue>(this IDictionary<string?[], string?> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?), TValue?>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ConvertOrNull<TValue>(entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key2_Value1

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="valueType"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key2_Value1(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type valueType, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key2_Value1), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, valueType }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), TValue?> Parse_Key2_Value1<TKey1, TKey2, TValue>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?), TValue?>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ConvertOrNull<TValue>(entry.Value[0], converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key2_Value2

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key2_Value2(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type valueType1, Type valueType2, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key2_Value2), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, valueType1, valueType2 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?)> Parse_Key2_Value2<TKey1, TKey2, TValue1, TValue2>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key2_Value3

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key2_Value3(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type valueType1, Type valueType2, Type valueType3, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key2_Value3), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, valueType1, valueType2, valueType3 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?)> Parse_Key2_Value3<TKey1, TKey2, TValue1, TValue2, TValue3>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key2_Value4

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key2_Value4(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type valueType1, Type valueType2, Type valueType3, Type valueType4, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key2_Value4), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, valueType1, valueType2, valueType3, valueType4 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?)> Parse_Key2_Value4<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key2_Value5

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key2_Value5(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key2_Value5), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, valueType1, valueType2, valueType3, valueType4 , valueType5 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> Parse_Key2_Value5<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key2_Value6

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key2_Value6(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key2_Value6), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> Parse_Key2_Value6<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key2_Value7

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key2_Value7(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key2_Value7), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> Parse_Key2_Value7<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key2_Value8

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key2_Value8(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key2_Value8), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> Parse_Key2_Value8<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key2_Value9

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <param name="valueType9"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key2_Value9(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8, Type valueType9, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key2_Value9), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8, valueType9 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> Parse_Key2_Value9<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key3_Value

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="valueType"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key3_Value(this IDictionary<string?[], string?> dictionary, Type keyType1, Type keyType2, Type keyType3, Type valueType, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key3_Value), typeof(IDictionary<string?[], string?>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, valueType }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), TValue?> Parse_Key3_Value<TKey1, TKey2, TKey3, TValue>(this IDictionary<string?[], string?> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?), TValue?>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ConvertOrNull<TValue>(entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key3_Value1

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="valueType"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key3_Value1(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type valueType, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key3_Value1), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, valueType }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), TValue?> Parse_Key3_Value1<TKey1, TKey2, TKey3, TValue>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?), TValue?>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ConvertOrNull<TValue>(entry.Value[0], converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key3_Value2

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key3_Value2(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type valueType1, Type valueType2, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key3_Value2), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, valueType1, valueType2 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?)> Parse_Key3_Value2<TKey1, TKey2, TKey3, TValue1, TValue2>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key3_Value3

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key3_Value3(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type valueType1, Type valueType2, Type valueType3, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key3_Value3), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, valueType1, valueType2, valueType3 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?)> Parse_Key3_Value3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key3_Value4

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key3_Value4(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type valueType1, Type valueType2, Type valueType3, Type valueType4, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key3_Value4), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, valueType1, valueType2, valueType3, valueType4 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?)> Parse_Key3_Value4<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key3_Value5

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key3_Value5(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key3_Value5), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, valueType1, valueType2, valueType3, valueType4, valueType5 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> Parse_Key3_Value5<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key3_Value6

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key3_Value6(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key3_Value6), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> Parse_Key3_Value6<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key3_Value7

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key3_Value7(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key3_Value7), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> Parse_Key3_Value7<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key3_Value8

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key3_Value8(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key3_Value8), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> Parse_Key3_Value8<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key3_Value9

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <param name="valueType9"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key3_Value9(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8, Type valueType9, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key3_Value9), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8, valueType9 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> Parse_Key3_Value9<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key4_Value

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="valueType"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key4_Value(this IDictionary<string?[], string?> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type valueType, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key4_Value), typeof(IDictionary<string?[], string?>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, valueType }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TValue?> Parse_Key4_Value<TKey1, TKey2, TKey3, TKey4, TValue>(this IDictionary<string?[], string?> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TValue?>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ConvertOrNull<TValue>(entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key4_Value1

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="valueType"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key4_Value1(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type valueType, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key4_Value1), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, valueType }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TValue?> Parse_Key4_Value1<TKey1, TKey2, TKey3, TKey4, TValue>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TValue?>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ConvertOrNull<TValue>(entry.Value[0], converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key4_Value2

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key4_Value2(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type valueType1, Type valueType2, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key4_Value2), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, valueType1, valueType2 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?)> Parse_Key4_Value2<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key4_Value3

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key4_Value3(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type valueType1, Type valueType2, Type valueType3, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key4_Value3), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, valueType1, valueType2, valueType3 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?)> Parse_Key4_Value3<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key4_Value4

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key4_Value4(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type valueType1, Type valueType2, Type valueType3, Type valueType4, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key4_Value4), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, valueType1, valueType2, valueType3, valueType4 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?)> Parse_Key4_Value4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key4_Value5

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key4_Value5(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key4_Value5), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, valueType1, valueType2, valueType3, valueType4, valueType5 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> Parse_Key4_Value5<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key4_Value6

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key4_Value6(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key4_Value6), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> Parse_Key4_Value6<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key4_Value7

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key4_Value7(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key4_Value7), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> Parse_Key4_Value7<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key4_Value8

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key4_Value8(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key4_Value8), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> Parse_Key4_Value8<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key4_Value9

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <param name="valueType9"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key4_Value9(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8, Type valueType9, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key4_Value9), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8, valueType9 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> Parse_Key4_Value9<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key5_Value

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="valueType"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key5_Value(this IDictionary<string?[], string?> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type valueType, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key5_Value), typeof(IDictionary<string?[], string?>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, valueType }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TValue?> Parse_Key5_Value<TKey1, TKey2, TKey3, TKey4, TKey5, TValue>(this IDictionary<string?[], string?> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TValue?>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ConvertOrNull<TValue>(entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key5_Value1

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="valueType"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key5_Value1(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type valueType, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key5_Value1), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, valueType }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TValue?> Parse_Key5_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TValue>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TValue?>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ConvertOrNull<TValue>(entry.Value[0], converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key5_Value2

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key5_Value2(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type valueType1, Type valueType2, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key5_Value2), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, valueType1, valueType2 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?)> Parse_Key5_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key5_Value3

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key5_Value3(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type valueType1, Type valueType2, Type valueType3, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key5_Value3), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, valueType1, valueType2, valueType3 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?)> Parse_Key5_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key5_Value4

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key5_Value4(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type valueType1, Type valueType2, Type valueType3, Type valueType4, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key5_Value4), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, valueType1, valueType2, valueType3, valueType4 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?)> Parse_Key5_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key5_Value5

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key5_Value5(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key5_Value5), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, valueType1, valueType2, valueType3, valueType4, valueType5 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> Parse_Key5_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key5_Value6

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key5_Value6(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key5_Value6), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> Parse_Key5_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key5_Value7

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key5_Value7(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key5_Value7), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> Parse_Key5_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key5_Value8

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key5_Value8(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key5_Value8), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> Parse_Key5_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key5_Value9

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <param name="valueType9"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key5_Value9(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8, Type valueType9, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key5_Value9), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8, valueType9 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> Parse_Key5_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key6_Value

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="valueType"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key6_Value(this IDictionary<string?[], string?> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type valueType, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key6_Value), typeof(IDictionary<string?[], string?>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, valueType }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TValue?> Parse_Key6_Value<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue>(this IDictionary<string?[], string?> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TValue?>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ConvertOrNull<TValue>(entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key6_Value1

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="valueType"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key6_Value1(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type valueType, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key6_Value1), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, valueType }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TValue?> Parse_Key6_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TValue?>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ConvertOrNull<TValue>(entry.Value[0], converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key6_Value2

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key6_Value2(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type valueType1, Type valueType2, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key6_Value2), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, valueType1, valueType2 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?)> Parse_Key6_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key6_Value3

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key6_Value3(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type valueType1, Type valueType2, Type valueType3, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key6_Value3), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, valueType1, valueType2, valueType3 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?)> Parse_Key6_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key6_Value4

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key6_Value4(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type valueType1, Type valueType2, Type valueType3, Type valueType4, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key6_Value4), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, valueType1, valueType2, valueType3, valueType4 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?)> Parse_Key6_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key6_Value5

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key6_Value5(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key6_Value5), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, valueType1, valueType2, valueType3, valueType4, valueType5 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> Parse_Key6_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key6_Value6

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key6_Value6(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key6_Value6), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> Parse_Key6_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key6_Value7

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key6_Value7(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key6_Value7), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> Parse_Key6_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key6_Value8

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key6_Value8(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key6_Value8), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> Parse_Key6_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key6_Value9

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <param name="valueType9"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key6_Value9(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8, Type valueType9, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key6_Value9), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8, valueType9 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> Parse_Key6_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key7_Value

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="valueType"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key7_Value(this IDictionary<string?[], string?> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type valueType, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key7_Value), typeof(IDictionary<string?[], string?>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, valueType }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TValue?> Parse_Key7_Value<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue>(this IDictionary<string?[], string?> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TValue?>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ConvertOrNull<TValue>(entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key7_Value1

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="valueType"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key7_Value1(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type valueType, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key7_Value1), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, valueType }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TValue?> Parse_Key7_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TValue?>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ConvertOrNull<TValue>(entry.Value[0], converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key7_Value2

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key7_Value2(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type valueType1, Type valueType2, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key7_Value2), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, valueType1, valueType2 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?)> Parse_Key7_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key7_Value3

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key7_Value3(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type valueType1, Type valueType2, Type valueType3, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key7_Value3), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, valueType1, valueType2, valueType3 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?)> Parse_Key7_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key7_Value4

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key7_Value4(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type valueType1, Type valueType2, Type valueType3, Type valueType4, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key7_Value4), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, valueType1, valueType2, valueType3, valueType4 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?)> Parse_Key7_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key7_Value5

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key7_Value5(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key7_Value5), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, valueType1, valueType2, valueType3, valueType4, valueType5 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> Parse_Key7_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key7_Value6

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key7_Value6(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key7_Value6), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> Parse_Key7_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key7_Value7

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key7_Value7(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key7_Value7), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> Parse_Key7_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key7_Value8

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key7_Value8(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key7_Value8), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> Parse_Key7_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key7_Value9

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <param name="valueType9"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key7_Value9(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8, Type valueType9, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key7_Value9), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8, valueType9 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> Parse_Key7_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key8_Value

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="valueType"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key8_Value(this IDictionary<string?[], string?> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type valueType, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key8_Value), typeof(IDictionary<string?[], string?>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, valueType }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TValue?> Parse_Key8_Value<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue>(this IDictionary<string?[], string?> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TValue?>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ConvertOrNull<TValue>(entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key8_Value1

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="valueType"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key8_Value1(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type valueType, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key8_Value1), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, valueType }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TValue?> Parse_Key8_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TValue?>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ConvertOrNull<TValue>(entry.Value[0], converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key8_Value2

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key8_Value2(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type valueType1, Type valueType2, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key8_Value2), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, valueType1, valueType2 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?)> Parse_Key8_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key8_Value3

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key8_Value3(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type valueType1, Type valueType2, Type valueType3, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key8_Value3), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, valueType1, valueType2, valueType3 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?)> Parse_Key8_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key8_Value4

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key8_Value4(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type valueType1, Type valueType2, Type valueType3, Type valueType4, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key8_Value4), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, valueType1, valueType2, valueType3, valueType4 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?)> Parse_Key8_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key8_Value5

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key8_Value5(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key8_Value5), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, valueType1, valueType2, valueType3, valueType4, valueType5 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> Parse_Key8_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key8_Value6

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key8_Value6(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key8_Value6), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> Parse_Key8_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key8_Value7

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key8_Value7(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key8_Value7), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> Parse_Key8_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key8_Value8

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key8_Value8(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key8_Value8), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> Parse_Key8_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key8_Value9

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <param name="valueType9"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key8_Value9(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8, Type valueType9, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key8_Value9), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8, valueType9 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> Parse_Key8_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key9_Value

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="keyType9"></param>
        /// <param name="valueType"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key9_Value(this IDictionary<string?[], string?> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type keyType9, Type valueType, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key9_Value), typeof(IDictionary<string?[], string?>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, keyType9, valueType }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TValue?> Parse_Key9_Value<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue>(this IDictionary<string?[], string?> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TValue?>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ConvertOrNull<TValue>(entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key9_Value1

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="keyType9"></param>
        /// <param name="valueType"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key9_Value1(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type keyType9, Type valueType, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key9_Value1), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, keyType9, valueType }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TValue?> Parse_Key9_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TValue?>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ConvertOrNull<TValue>(entry.Value[0], converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key9_Value2

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="keyType9"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key9_Value2(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type keyType9, Type valueType1, Type valueType2, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key9_Value2), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, keyType9, valueType1, valueType2 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?)> Parse_Key9_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key9_Value3

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="keyType9"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key9_Value3(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type keyType9, Type valueType1, Type valueType2, Type valueType3, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key9_Value3), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, keyType9, valueType1, valueType2, valueType3 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?)> Parse_Key9_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key9_Value4

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="keyType9"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key9_Value4(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type keyType9, Type valueType1, Type valueType2, Type valueType3, Type valueType4, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key9_Value4), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, keyType9, valueType1, valueType2, valueType3, valueType4 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?)> Parse_Key9_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key9_Value5

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="keyType9"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key9_Value5(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type keyType9, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key9_Value5), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, keyType9, valueType1, valueType2, valueType3, valueType4, valueType5 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> Parse_Key9_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key9_Value6

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="keyType9"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key9_Value6(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type keyType9, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key9_Value6), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, keyType9, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> Parse_Key9_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key9_Value7

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="keyType9"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key9_Value7(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type keyType9, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key9_Value7), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, keyType9, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> Parse_Key9_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key9_Value8

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="keyType9"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key9_Value8(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type keyType9, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key9_Value8), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, keyType9, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> Parse_Key9_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #region Parse_Key9_Value9

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyType1"></param>
        /// <param name="keyType2"></param>
        /// <param name="keyType3"></param>
        /// <param name="keyType4"></param>
        /// <param name="keyType5"></param>
        /// <param name="keyType6"></param>
        /// <param name="keyType7"></param>
        /// <param name="keyType8"></param>
        /// <param name="keyType9"></param>
        /// <param name="valueType1"></param>
        /// <param name="valueType2"></param>
        /// <param name="valueType3"></param>
        /// <param name="valueType4"></param>
        /// <param name="valueType5"></param>
        /// <param name="valueType6"></param>
        /// <param name="valueType7"></param>
        /// <param name="valueType8"></param>
        /// <param name="valueType9"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary Parse_Key9_Value9(this IDictionary<string?[], string?[]> dictionary, Type keyType1, Type keyType2, Type keyType3, Type keyType4, Type keyType5, Type keyType6, Type keyType7, Type keyType8, Type keyType9, Type valueType1, Type valueType2, Type valueType3, Type valueType4, Type valueType5, Type valueType6, Type valueType7, Type valueType8, Type valueType9, IStringConverter converter)
        {
            MethodInfo method = s_Type.GetGenericMethod(nameof(Parse_Key9_Value9), typeof(IDictionary<string?[], string?[]>), typeof(IStringConverter));
            return s_Type.InvokeStaticGenericMethod<IDictionary>(method, new[] { keyType1, keyType2, keyType3, keyType4, keyType5, keyType6, keyType7, keyType8, keyType9, valueType1, valueType2, valueType3, valueType4, valueType5, valueType6, valueType7, valueType8, valueType9 }, dictionary, converter);
        }

        /// <summary>
        /// Parses the key and value of the specified string dictionary.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> Parse_Key9_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<string?[], string?[]> dictionary, IStringConverter converter)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            if (dictionary == null) { return null!; }

            var typed = new Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)>();

            try
            {
                foreach (var entry in dictionary)
                {
                    var key = ToKeyTuple(typed, entry.Key, converter);
                    var value = ToValueTuple(typed, entry.Value, converter);

                    typed.Add(key, value);
                }

                return typed;
            }
            catch (Exception ex)
            {
                throw CreateInvalidCastException(dictionary.GetType(), typed.GetType(), ex);
            }
        }

        #endregion

        #endregion


        #region AsNullableDictionary

        /// <summary>
        /// Wraps as a dictionary with nullable tuples.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?)> AsNullableDictionary<TKey, TValue1, TValue2, TValue3>(this IDictionary<TKey, (TValue1, TValue2, TValue3)> dictionary)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            return new Internals.ConvertDictionary<TKey, (TValue1, TValue2, TValue3), TKey, (TValue1?, TValue2?, TValue3?)>(
                dictionary
                , key => key
                , value => value
                , nullableKey => nullableKey
                , nullableValue => nullableValue.FromNullable()
                );
        }

        /// <summary>
        /// Wraps as a dictionary with nullable tuples.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), TValue?> AsNullableDictionary<TKey1, TKey2, TValue>(this IDictionary<(TKey1, TKey2), TValue> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TValue : struct
        {
            return new Internals.ConvertDictionary<(TKey1, TKey2), TValue, (TKey1?, TKey2?), TValue?>(
                dictionary
                , key => key.ToNullable()
                , value => value
                , nullableKey => nullableKey.FromNullable()
                , nullableValue => nullableValue!.Value
                );
        }

        /// <summary>
        /// Wraps as a dictionary with nullable tuples.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?)> AsNullableDictionary<TKey1, TKey2, TValue1, TValue2>(this IDictionary<(TKey1, TKey2), (TValue1, TValue2)> dictionary)
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            return new Internals.ConvertDictionary<(TKey1, TKey2), (TValue1, TValue2), (TKey1?, TKey2?), (TValue1?, TValue2?)>(
                dictionary
                , key => key.ToNullable()
                , value => value.ToNullable()
                , nullableKey => nullableKey.FromNullable()
                , nullableValue => nullableValue.FromNullable()
                );
        }

        #endregion




        #region convert value

        private static T Cast<T>(object value)
            where T : struct
        {
            return (T)DataGeneratorUtility.ConvertToRawValue(value)!;
        }

        private static T? CastOrNull<T>(object? value)
            where T : struct
        {
            return (T?)DataGeneratorUtility.ConvertToRawValue(value);
        }

        private static T Convert<T>(string value, IStringConverter converter)
            where T : struct
        {
            return (T)converter.ConvertTo(value, typeof(T))!;
        }

        private static T? ConvertOrNull<T>(string? value, IStringConverter converter)
            where T : struct
        {
            return (T?)converter.ConvertTo(value, typeof(T));
        }

        #endregion

        #region ToTuple

        private static (T1, T2) ToTuple<T1, T2>(ReadOnlySpan<object> values)
            where T1 : struct
            where T2 : struct
        {
            T1 value1 = (T1)DataGeneratorUtility.ConvertToRawValue(values[0])!;
            T2 value2 = (T2)DataGeneratorUtility.ConvertToRawValue(values[1])!;

            return (value1, value2);
        }

        private static (T1?, T2?) ToNullableTuple<T1, T2>(ReadOnlySpan<object?> values)
            where T1 : struct
            where T2 : struct
        {
            T1? value1 = (T1?)DataGeneratorUtility.ConvertToRawValue(values[0]);
            T2? value2 = (T2?)DataGeneratorUtility.ConvertToRawValue(values[1]);

            return (value1, value2);
        }

        private static (T1, T2, T3) ToTuple<T1, T2, T3>(ReadOnlySpan<object> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            T1 value1 = (T1)DataGeneratorUtility.ConvertToRawValue(values[0])!;
            T2 value2 = (T2)DataGeneratorUtility.ConvertToRawValue(values[1])!;
            T3 value3 = (T3)DataGeneratorUtility.ConvertToRawValue(values[2])!;

            return (value1, value2, value3);
        }

        private static (T1?, T2?, T3?) ToNullableTuple<T1, T2, T3>(ReadOnlySpan<object?> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            T1? value1 = (T1?)DataGeneratorUtility.ConvertToRawValue(values[0]);
            T2? value2 = (T2?)DataGeneratorUtility.ConvertToRawValue(values[1]);
            T3? value3 = (T3?)DataGeneratorUtility.ConvertToRawValue(values[2]);

            return (value1, value2, value3);
        }

        private static (T1, T2, T3, T4) ToTuple<T1, T2, T3, T4>(ReadOnlySpan<object> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            T1 value1 = (T1)DataGeneratorUtility.ConvertToRawValue(values[0])!;
            T2 value2 = (T2)DataGeneratorUtility.ConvertToRawValue(values[1])!;
            T3 value3 = (T3)DataGeneratorUtility.ConvertToRawValue(values[2])!;
            T4 value4 = (T4)DataGeneratorUtility.ConvertToRawValue(values[3])!;

            return (value1, value2, value3, value4);
        }

        private static (T1?, T2?, T3?, T4?) ToNullableTuple<T1, T2, T3, T4>(ReadOnlySpan<object?> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            T1? value1 = (T1?)DataGeneratorUtility.ConvertToRawValue(values[0]);
            T2? value2 = (T2?)DataGeneratorUtility.ConvertToRawValue(values[1]);
            T3? value3 = (T3?)DataGeneratorUtility.ConvertToRawValue(values[2]);
            T4? value4 = (T4?)DataGeneratorUtility.ConvertToRawValue(values[3]);

            return (value1, value2, value3, value4);
        }

        private static (T1, T2, T3, T4, T5) ToTuple<T1, T2, T3, T4, T5>(ReadOnlySpan<object> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            T1 value1 = (T1)DataGeneratorUtility.ConvertToRawValue(values[0])!;
            T2 value2 = (T2)DataGeneratorUtility.ConvertToRawValue(values[1])!;
            T3 value3 = (T3)DataGeneratorUtility.ConvertToRawValue(values[2])!;
            T4 value4 = (T4)DataGeneratorUtility.ConvertToRawValue(values[3])!;
            T5 value5 = (T5)DataGeneratorUtility.ConvertToRawValue(values[4])!;

            return (value1, value2, value3, value4, value5);
        }

        private static (T1?, T2?, T3?, T4?, T5?) ToNullableTuple<T1, T2, T3, T4, T5>(ReadOnlySpan<object?> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            T1? value1 = (T1?)DataGeneratorUtility.ConvertToRawValue(values[0]);
            T2? value2 = (T2?)DataGeneratorUtility.ConvertToRawValue(values[1]);
            T3? value3 = (T3?)DataGeneratorUtility.ConvertToRawValue(values[2]);
            T4? value4 = (T4?)DataGeneratorUtility.ConvertToRawValue(values[3]);
            T5? value5 = (T5?)DataGeneratorUtility.ConvertToRawValue(values[4]);

            return (value1, value2, value3, value4, value5);
        }

        private static (T1, T2, T3, T4, T5, T6) ToTuple<T1, T2, T3, T4, T5, T6>(ReadOnlySpan<object> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            T1 value1 = (T1)DataGeneratorUtility.ConvertToRawValue(values[0])!;
            T2 value2 = (T2)DataGeneratorUtility.ConvertToRawValue(values[1])!;
            T3 value3 = (T3)DataGeneratorUtility.ConvertToRawValue(values[2])!;
            T4 value4 = (T4)DataGeneratorUtility.ConvertToRawValue(values[3])!;
            T5 value5 = (T5)DataGeneratorUtility.ConvertToRawValue(values[4])!;
            T6 value6 = (T6)DataGeneratorUtility.ConvertToRawValue(values[5])!;

            return (value1, value2, value3, value4, value5, value6);
        }

        private static (T1?, T2?, T3?, T4?, T5?, T6?) ToNullableTuple<T1, T2, T3, T4, T5, T6>(ReadOnlySpan<object?> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            T1? value1 = (T1?)DataGeneratorUtility.ConvertToRawValue(values[0]);
            T2? value2 = (T2?)DataGeneratorUtility.ConvertToRawValue(values[1]);
            T3? value3 = (T3?)DataGeneratorUtility.ConvertToRawValue(values[2]);
            T4? value4 = (T4?)DataGeneratorUtility.ConvertToRawValue(values[3]);
            T5? value5 = (T5?)DataGeneratorUtility.ConvertToRawValue(values[4]);
            T6? value6 = (T6?)DataGeneratorUtility.ConvertToRawValue(values[5]);

            return (value1, value2, value3, value4, value5, value6);
        }

        private static (T1, T2, T3, T4, T5, T6, T7) ToTuple<T1, T2, T3, T4, T5, T6, T7>(ReadOnlySpan<object> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            T1 value1 = (T1)DataGeneratorUtility.ConvertToRawValue(values[0])!;
            T2 value2 = (T2)DataGeneratorUtility.ConvertToRawValue(values[1])!;
            T3 value3 = (T3)DataGeneratorUtility.ConvertToRawValue(values[2])!;
            T4 value4 = (T4)DataGeneratorUtility.ConvertToRawValue(values[3])!;
            T5 value5 = (T5)DataGeneratorUtility.ConvertToRawValue(values[4])!;
            T6 value6 = (T6)DataGeneratorUtility.ConvertToRawValue(values[5])!;
            T7 value7 = (T7)DataGeneratorUtility.ConvertToRawValue(values[6])!;

            return (value1, value2, value3, value4, value5, value6, value7);
        }

        private static (T1?, T2?, T3?, T4?, T5?, T6?, T7?) ToNullableTuple<T1, T2, T3, T4, T5, T6, T7>(ReadOnlySpan<object?> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            T1? value1 = (T1?)DataGeneratorUtility.ConvertToRawValue(values[0]);
            T2? value2 = (T2?)DataGeneratorUtility.ConvertToRawValue(values[1]);
            T3? value3 = (T3?)DataGeneratorUtility.ConvertToRawValue(values[2]);
            T4? value4 = (T4?)DataGeneratorUtility.ConvertToRawValue(values[3]);
            T5? value5 = (T5?)DataGeneratorUtility.ConvertToRawValue(values[4]);
            T6? value6 = (T6?)DataGeneratorUtility.ConvertToRawValue(values[5]);
            T7? value7 = (T7?)DataGeneratorUtility.ConvertToRawValue(values[6]);

            return (value1, value2, value3, value4, value5, value6, value7);
        }

        private static (T1, T2, T3, T4, T5, T6, T7, T8) ToTuple<T1, T2, T3, T4, T5, T6, T7, T8>(ReadOnlySpan<object> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            T1 value1 = (T1)DataGeneratorUtility.ConvertToRawValue(values[0])!;
            T2 value2 = (T2)DataGeneratorUtility.ConvertToRawValue(values[1])!;
            T3 value3 = (T3)DataGeneratorUtility.ConvertToRawValue(values[2])!;
            T4 value4 = (T4)DataGeneratorUtility.ConvertToRawValue(values[3])!;
            T5 value5 = (T5)DataGeneratorUtility.ConvertToRawValue(values[4])!;
            T6 value6 = (T6)DataGeneratorUtility.ConvertToRawValue(values[5])!;
            T7 value7 = (T7)DataGeneratorUtility.ConvertToRawValue(values[6])!;
            T8 value8 = (T8)DataGeneratorUtility.ConvertToRawValue(values[7])!;

            return (value1, value2, value3, value4, value5, value6, value7, value8);
        }

        private static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?) ToNullableTuple<T1, T2, T3, T4, T5, T6, T7, T8>(ReadOnlySpan<object?> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            T1? value1 = (T1?)DataGeneratorUtility.ConvertToRawValue(values[0]);
            T2? value2 = (T2?)DataGeneratorUtility.ConvertToRawValue(values[1]);
            T3? value3 = (T3?)DataGeneratorUtility.ConvertToRawValue(values[2]);
            T4? value4 = (T4?)DataGeneratorUtility.ConvertToRawValue(values[3]);
            T5? value5 = (T5?)DataGeneratorUtility.ConvertToRawValue(values[4]);
            T6? value6 = (T6?)DataGeneratorUtility.ConvertToRawValue(values[5]);
            T7? value7 = (T7?)DataGeneratorUtility.ConvertToRawValue(values[6]);
            T8? value8 = (T8?)DataGeneratorUtility.ConvertToRawValue(values[7]);

            return (value1, value2, value3, value4, value5, value6, value7, value8);
        }

        private static (T1, T2, T3, T4, T5, T6, T7, T8, T9) ToTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(ReadOnlySpan<object> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
            where T9 : struct
        {
            T1 value1 = (T1)DataGeneratorUtility.ConvertToRawValue(values[0])!;
            T2 value2 = (T2)DataGeneratorUtility.ConvertToRawValue(values[1])!;
            T3 value3 = (T3)DataGeneratorUtility.ConvertToRawValue(values[2])!;
            T4 value4 = (T4)DataGeneratorUtility.ConvertToRawValue(values[3])!;
            T5 value5 = (T5)DataGeneratorUtility.ConvertToRawValue(values[4])!;
            T6 value6 = (T6)DataGeneratorUtility.ConvertToRawValue(values[5])!;
            T7 value7 = (T7)DataGeneratorUtility.ConvertToRawValue(values[6])!;
            T8 value8 = (T8)DataGeneratorUtility.ConvertToRawValue(values[7])!;
            T9 value9 = (T9)DataGeneratorUtility.ConvertToRawValue(values[8])!;

            return (value1, value2, value3, value4, value5, value6, value7, value8, value9);
        }

        private static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?) ToNullableTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(ReadOnlySpan<object?> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
            where T9 : struct
        {
            T1? value1 = (T1?)DataGeneratorUtility.ConvertToRawValue(values[0]);
            T2? value2 = (T2?)DataGeneratorUtility.ConvertToRawValue(values[1]);
            T3? value3 = (T3?)DataGeneratorUtility.ConvertToRawValue(values[2]);
            T4? value4 = (T4?)DataGeneratorUtility.ConvertToRawValue(values[3]);
            T5? value5 = (T5?)DataGeneratorUtility.ConvertToRawValue(values[4]);
            T6? value6 = (T6?)DataGeneratorUtility.ConvertToRawValue(values[5]);
            T7? value7 = (T7?)DataGeneratorUtility.ConvertToRawValue(values[6]);
            T8? value8 = (T8?)DataGeneratorUtility.ConvertToRawValue(values[7]);
            T9? value9 = (T9?)DataGeneratorUtility.ConvertToRawValue(values[8]);

            return (value1, value2, value3, value4, value5, value6, value7, value8, value9);
        }

        #endregion

        #region ToKeyTuple (from string)

        private static (T1?, T2?) ToKeyTuple<T1, T2, TAnyValue>(IDictionary<(T1?, T2?), TAnyValue> _, ReadOnlySpan<string?> values, IStringConverter converter)
            where T1 : struct
            where T2 : struct
        {
            T1? value1 = (T1?)converter.ConvertTo(values[0], typeof(T1))!;
            T2? value2 = (T2?)converter.ConvertTo(values[1], typeof(T2))!;

            return (value1, value2);
        }

        private static (T1?, T2?, T3?) ToKeyTuple<T1, T2, T3, TAnyValue>(IDictionary<(T1?, T2?, T3?), TAnyValue> _, ReadOnlySpan<string?> values, IStringConverter converter)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            T1? value1 = (T1?)converter.ConvertTo(values[0], typeof(T1))!;
            T2? value2 = (T2?)converter.ConvertTo(values[1], typeof(T2))!;
            T3? value3 = (T3?)converter.ConvertTo(values[2], typeof(T3))!;

            return (value1, value2, value3);
        }

        private static (T1?, T2?, T3?, T4?) ToKeyTuple<T1, T2, T3, T4, TAnyValue>(IDictionary<(T1?, T2?, T3?, T4?), TAnyValue> _, ReadOnlySpan<string?> values, IStringConverter converter)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            T1? value1 = (T1?)converter.ConvertTo(values[0], typeof(T1))!;
            T2? value2 = (T2?)converter.ConvertTo(values[1], typeof(T2))!;
            T3? value3 = (T3?)converter.ConvertTo(values[2], typeof(T3))!;
            T4? value4 = (T4?)converter.ConvertTo(values[3], typeof(T4))!;

            return (value1, value2, value3, value4);
        }

        private static (T1?, T2?, T3?, T4?, T5?) ToKeyTuple<T1, T2, T3, T4, T5, TAnyValue>(IDictionary<(T1?, T2?, T3?, T4?, T5?), TAnyValue> _, ReadOnlySpan<string?> values, IStringConverter converter)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            T1? value1 = (T1?)converter.ConvertTo(values[0], typeof(T1))!;
            T2? value2 = (T2?)converter.ConvertTo(values[1], typeof(T2))!;
            T3? value3 = (T3?)converter.ConvertTo(values[2], typeof(T3))!;
            T4? value4 = (T4?)converter.ConvertTo(values[3], typeof(T4))!;
            T5? value5 = (T5?)converter.ConvertTo(values[4], typeof(T5))!;

            return (value1, value2, value3, value4, value5);
        }

        private static (T1?, T2?, T3?, T4?, T5?, T6?) ToKeyTuple<T1, T2, T3, T4, T5, T6, TAnyValue>(IDictionary<(T1?, T2?, T3?, T4?, T5?, T6?), TAnyValue> _, ReadOnlySpan<string?> values, IStringConverter converter)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            T1? value1 = (T1?)converter.ConvertTo(values[0], typeof(T1))!;
            T2? value2 = (T2?)converter.ConvertTo(values[1], typeof(T2))!;
            T3? value3 = (T3?)converter.ConvertTo(values[2], typeof(T3))!;
            T4? value4 = (T4?)converter.ConvertTo(values[3], typeof(T4))!;
            T5? value5 = (T5?)converter.ConvertTo(values[4], typeof(T5))!;
            T6? value6 = (T6?)converter.ConvertTo(values[5], typeof(T6))!;

            return (value1, value2, value3, value4, value5, value6);
        }

        private static (T1?, T2?, T3?, T4?, T5?, T6?, T7?) ToKeyTuple<T1, T2, T3, T4, T5, T6, T7, TAnyValue>(IDictionary<(T1?, T2?, T3?, T4?, T5?, T6?, T7?), TAnyValue> _, ReadOnlySpan<string?> values, IStringConverter converter)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            T1? value1 = (T1?)converter.ConvertTo(values[0], typeof(T1))!;
            T2? value2 = (T2?)converter.ConvertTo(values[1], typeof(T2))!;
            T3? value3 = (T3?)converter.ConvertTo(values[2], typeof(T3))!;
            T4? value4 = (T4?)converter.ConvertTo(values[3], typeof(T4))!;
            T5? value5 = (T5?)converter.ConvertTo(values[4], typeof(T5))!;
            T6? value6 = (T6?)converter.ConvertTo(values[5], typeof(T6))!;
            T7? value7 = (T7?)converter.ConvertTo(values[6], typeof(T7))!;

            return (value1, value2, value3, value4, value5, value6, value7);
        }

        private static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?) ToKeyTuple<T1, T2, T3, T4, T5, T6, T7, T8, TAnyValue>(IDictionary<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?), TAnyValue> _, ReadOnlySpan<string?> values, IStringConverter converter)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            T1? value1 = (T1?)converter.ConvertTo(values[0], typeof(T1))!;
            T2? value2 = (T2?)converter.ConvertTo(values[1], typeof(T2))!;
            T3? value3 = (T3?)converter.ConvertTo(values[2], typeof(T3))!;
            T4? value4 = (T4?)converter.ConvertTo(values[3], typeof(T4))!;
            T5? value5 = (T5?)converter.ConvertTo(values[4], typeof(T5))!;
            T6? value6 = (T6?)converter.ConvertTo(values[5], typeof(T6))!;
            T7? value7 = (T7?)converter.ConvertTo(values[6], typeof(T7))!;
            T8? value8 = (T8?)converter.ConvertTo(values[7], typeof(T8))!;

            return (value1, value2, value3, value4, value5, value6, value7, value8);
        }

        private static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?) ToKeyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, TAnyValue>(IDictionary<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?), TAnyValue> _, ReadOnlySpan<string?> values, IStringConverter converter)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
            where T9 : struct
        {
            T1? value1 = (T1?)converter.ConvertTo(values[0], typeof(T1))!;
            T2? value2 = (T2?)converter.ConvertTo(values[1], typeof(T2))!;
            T3? value3 = (T3?)converter.ConvertTo(values[2], typeof(T3))!;
            T4? value4 = (T4?)converter.ConvertTo(values[3], typeof(T4))!;
            T5? value5 = (T5?)converter.ConvertTo(values[4], typeof(T5))!;
            T6? value6 = (T6?)converter.ConvertTo(values[5], typeof(T6))!;
            T7? value7 = (T7?)converter.ConvertTo(values[6], typeof(T7))!;
            T8? value8 = (T8?)converter.ConvertTo(values[7], typeof(T8))!;
            T9? value9 = (T9?)converter.ConvertTo(values[8], typeof(T9))!;

            return (value1, value2, value3, value4, value5, value6, value7, value8, value9);
        }

        #endregion

        #region ToValueTuple (from string)

        private static (T1?, T2?) ToValueTuple<TAnyKey, T1, T2>(IDictionary<TAnyKey, (T1?, T2?)> _, ReadOnlySpan<string?> values, IStringConverter converter)
            where T1 : struct
            where T2 : struct
        {
            T1? value1 = (T1?)converter.ConvertTo(values[0], typeof(T1));
            T2? value2 = (T2?)converter.ConvertTo(values[1], typeof(T2));

            return (value1, value2);
        }

        private static (T1?, T2?, T3?) ToValueTuple<TAnyKey, T1, T2, T3>(IDictionary<TAnyKey, (T1?, T2?, T3?)> _, ReadOnlySpan<string?> values, IStringConverter converter)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            T1? value1 = (T1?)converter.ConvertTo(values[0], typeof(T1));
            T2? value2 = (T2?)converter.ConvertTo(values[1], typeof(T2));
            T3? value3 = (T3?)converter.ConvertTo(values[2], typeof(T3));

            return (value1, value2, value3);
        }

        private static (T1?, T2?, T3?, T4?) ToValueTuple<TAnyKey, T1, T2, T3, T4>(IDictionary<TAnyKey, (T1?, T2?, T3?, T4?)> _, ReadOnlySpan<string?> values, IStringConverter converter)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            T1? value1 = (T1?)converter.ConvertTo(values[0], typeof(T1));
            T2? value2 = (T2?)converter.ConvertTo(values[1], typeof(T2));
            T3? value3 = (T3?)converter.ConvertTo(values[2], typeof(T3));
            T4? value4 = (T4?)converter.ConvertTo(values[3], typeof(T4));

            return (value1, value2, value3, value4);
        }

        private static (T1?, T2?, T3?, T4?, T5?) ToValueTuple<TAnyKey, T1, T2, T3, T4, T5>(IDictionary<TAnyKey, (T1?, T2?, T3?, T4?, T5?)> _, ReadOnlySpan<string?> values, IStringConverter converter)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            T1? value1 = (T1?)converter.ConvertTo(values[0], typeof(T1));
            T2? value2 = (T2?)converter.ConvertTo(values[1], typeof(T2));
            T3? value3 = (T3?)converter.ConvertTo(values[2], typeof(T3));
            T4? value4 = (T4?)converter.ConvertTo(values[3], typeof(T4));
            T5? value5 = (T5?)converter.ConvertTo(values[4], typeof(T5));

            return (value1, value2, value3, value4, value5);
        }

        private static (T1?, T2?, T3?, T4?, T5?, T6?) ToValueTuple<TAnyKey, T1, T2, T3, T4, T5, T6>(IDictionary<TAnyKey, (T1?, T2?, T3?, T4?, T5?, T6?)> _, ReadOnlySpan<string?> values, IStringConverter converter)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            T1? value1 = (T1?)converter.ConvertTo(values[0], typeof(T1));
            T2? value2 = (T2?)converter.ConvertTo(values[1], typeof(T2));
            T3? value3 = (T3?)converter.ConvertTo(values[2], typeof(T3));
            T4? value4 = (T4?)converter.ConvertTo(values[3], typeof(T4));
            T5? value5 = (T5?)converter.ConvertTo(values[4], typeof(T5));
            T6? value6 = (T6?)converter.ConvertTo(values[5], typeof(T6));

            return (value1, value2, value3, value4, value5, value6);
        }

        private static (T1?, T2?, T3?, T4?, T5?, T6?, T7?) ToValueTuple<TAnyKey, T1, T2, T3, T4, T5, T6, T7>(IDictionary<TAnyKey, (T1?, T2?, T3?, T4?, T5?, T6?, T7?)> _, ReadOnlySpan<string?> values, IStringConverter converter)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            T1? value1 = (T1?)converter.ConvertTo(values[0], typeof(T1));
            T2? value2 = (T2?)converter.ConvertTo(values[1], typeof(T2));
            T3? value3 = (T3?)converter.ConvertTo(values[2], typeof(T3));
            T4? value4 = (T4?)converter.ConvertTo(values[3], typeof(T4));
            T5? value5 = (T5?)converter.ConvertTo(values[4], typeof(T5));
            T6? value6 = (T6?)converter.ConvertTo(values[5], typeof(T6));
            T7? value7 = (T7?)converter.ConvertTo(values[6], typeof(T7));

            return (value1, value2, value3, value4, value5, value6, value7);
        }

        private static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?) ToValueTuple<TAnyKey, T1, T2, T3, T4, T5, T6, T7, T8>(IDictionary<TAnyKey, (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)> _, ReadOnlySpan<string?> values, IStringConverter converter)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            T1? value1 = (T1?)converter.ConvertTo(values[0], typeof(T1));
            T2? value2 = (T2?)converter.ConvertTo(values[1], typeof(T2));
            T3? value3 = (T3?)converter.ConvertTo(values[2], typeof(T3));
            T4? value4 = (T4?)converter.ConvertTo(values[3], typeof(T4));
            T5? value5 = (T5?)converter.ConvertTo(values[4], typeof(T5));
            T6? value6 = (T6?)converter.ConvertTo(values[5], typeof(T6));
            T7? value7 = (T7?)converter.ConvertTo(values[6], typeof(T7));
            T8? value8 = (T8?)converter.ConvertTo(values[7], typeof(T8));

            return (value1, value2, value3, value4, value5, value6, value7, value8);
        }

        private static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?) ToValueTuple<TAnyKey, T1, T2, T3, T4, T5, T6, T7, T8, T9>(IDictionary<TAnyKey, (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)> _, ReadOnlySpan<string?> values, IStringConverter converter)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
            where T9 : struct
        {
            T1? value1 = (T1?)converter.ConvertTo(values[0], typeof(T1));
            T2? value2 = (T2?)converter.ConvertTo(values[1], typeof(T2));
            T3? value3 = (T3?)converter.ConvertTo(values[2], typeof(T3));
            T4? value4 = (T4?)converter.ConvertTo(values[3], typeof(T4));
            T5? value5 = (T5?)converter.ConvertTo(values[4], typeof(T5));
            T6? value6 = (T6?)converter.ConvertTo(values[5], typeof(T6));
            T7? value7 = (T7?)converter.ConvertTo(values[6], typeof(T7));
            T8? value8 = (T8?)converter.ConvertTo(values[7], typeof(T8));
            T9? value9 = (T9?)converter.ConvertTo(values[8], typeof(T9));

            return (value1, value2, value3, value4, value5, value6, value7, value8, value9);
        }

        #endregion

        #region GetValueTypes

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        internal static Type[] GetValueTypes<TAnyKey, TValue1, TValue2>(this IDictionary<TAnyKey, (TValue1, TValue2)> _)
            where TValue1 : struct
            where TValue2 : struct
        {
            return new Type[] {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2))
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        internal static Type[] GetValueTypes<TAnyKey, TValue1, TValue2, TValue3>(this IDictionary<TAnyKey, (TValue1, TValue2, TValue3)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            return new Type[] {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3))
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        internal static Type[] GetValueTypes<TAnyKey, TValue1, TValue2, TValue3, TValue4>(this IDictionary<TAnyKey, (TValue1, TValue2, TValue3, TValue4)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            return new Type[] {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue4))
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        internal static Type[] GetValueTypes<TAnyKey, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<TAnyKey, (TValue1, TValue2, TValue3, TValue4, TValue5)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            return new Type[] {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue4)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue5))
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        internal static Type[] GetValueTypes<TAnyKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<TAnyKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            return new Type[] {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue4)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue5)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue6))
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        internal static Type[] GetValueTypes<TAnyKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<TAnyKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            return new Type[] {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue4)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue5)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue6)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue7))
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        internal static Type[] GetValueTypes<TAnyKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<TAnyKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            return new Type[] {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue4)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue5)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue6)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue7)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue8))
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        internal static Type[] GetValueTypes<TAnyKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<TAnyKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            return new Type[] {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue4)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue5)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue6)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue7)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue8)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue9))
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        internal static Type[] GetValueTypes<TAnyKey, TValue1, TValue2>(this IDictionary<TAnyKey, (TValue1?, TValue2?)> _)
            where TValue1 : struct
            where TValue2 : struct
        {
            return new Type[] {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2))
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        internal static Type[] GetValueTypes<TAnyKey, TValue1, TValue2, TValue3>(this IDictionary<TAnyKey, (TValue1?, TValue2?, TValue3?)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            return new Type[] {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3))
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        internal static Type[] GetValueTypes<TAnyKey, TValue1, TValue2, TValue3, TValue4>(this IDictionary<TAnyKey, (TValue1?, TValue2?, TValue3?, TValue4?)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            return new Type[] {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue4))
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        internal static Type[] GetValueTypes<TAnyKey, TValue1, TValue2, TValue3, TValue4, TValue5>(this IDictionary<TAnyKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            return new Type[] {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue4)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue5))
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        internal static Type[] GetValueTypes<TAnyKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this IDictionary<TAnyKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            return new Type[] {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue4)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue5)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue6))
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        internal static Type[] GetValueTypes<TAnyKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this IDictionary<TAnyKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            return new Type[] {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue4)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue5)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue6)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue7))
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        internal static Type[] GetValueTypes<TAnyKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this IDictionary<TAnyKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            return new Type[] {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue4)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue5)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue6)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue7)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue8))
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        internal static Type[] GetValueTypes<TAnyKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this IDictionary<TAnyKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            return new Type[] { 
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue4)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue5)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue6)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue7)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue8)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue9))
            };
        }

        #endregion

        private static Exception CreateInvalidCastException(Type sourceType, Type destType, Exception innerException)
        {
            throw new Exception($"Could not convert type '{sourceType.Name}' to type '{destType.Name}'.", innerException);
        }

    }

}
