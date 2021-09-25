using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration
{
    internal static class DataGeneratorUtility
    {

        internal static object[] ToObjectArray<T>(T[] values)
        {
            if (values == null) { return null!; }

            object[] objects = new object[values.Length];

            for (int i = 0; i < values.Length; ++i)
            {
                objects[i] = values[i]!;
            }

            return objects;
        }

        internal static TOutput[] ConvertArray<TInput, TOutput>(TInput?[] values, Converter<TInput, TOutput>? converter = null)
        {
            static TOutput DefaultConverter(TInput input)
            {
                if (input == null) { return default!; }
                return (TOutput)(object)input;
            }

            if (values == null) { return null!; }

            TOutput[] output = new TOutput[values.Length];

            for (int i = 0; i < values.Length; ++i)
            {
                if (values[i] != null)
                {
                    output[i] = (converter ?? DefaultConverter)(values[i]!);
                }
            }

            return output;
        }

        /// <summary>
        /// Converts the specified value to a type that enumerates it.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="valueType">The type of the field value.</param>
        /// <param name="context">The context.</param>
        /// <returns>The converted values.</returns>
        internal static IEnumerable<object?> ConvertValues(object?[]? values, Type valueType, DataGeneratorContext context)
        {
            if (values == null) { yield break; }

            static object? Convert(object? value, Type valueType, DataGeneratorContext context)
            {
                if (valueType != typeof(string) && valueType != typeof(StringValue) && value is string s)
                {
                    return context.StringConverter.ConvertTo(s, valueType);
                }
                else
                {
                    return value!;
                }
            }

            for (int i = 0; i < values.Length; ++i)
            {
                yield return Convert(values[i], valueType, context);
            }
        }

        internal static bool EqualValueType(Type valueType, Type type)
        {
            if (valueType == type) { return true; }

            if (valueType == typeof(StringValue) && type == typeof(string)) { return true; }
            if (valueType == typeof(string) && type == typeof(StringValue)) { return true; }

            return false;
        }

        internal static Type GetFieldValueType(Type valueType)
        {
            if (valueType == typeof(string))
            {
                return typeof(StringValue);
            }
            else
            {
                return valueType;
            }
        }

        internal static object? ConvertFromRawValue(object? value)
        {
            if (value is StringValue stringValue)
            {
                return stringValue.Value;
            }
            else
            {
                return value;
            }
        }

        internal static object? ConvertToRawValue(object? value)
        {
            if (value is string stringValue)
            {
                return new StringValue(stringValue);
            }
            else
            {
                return value;
            }
        }

        internal static T CastToRawValue<T>(object? value)
            where T : struct
        {
            if (value == null) { return default!; }

            if (value is T t) { return t; }

            if (typeof(T) == typeof(string))
            {
                return (T)(object)value.ToString()!;
            }
            else if (typeof(T) == typeof(StringValue) || typeof(T) == typeof(StringValue?))
            {
                return (T)(object)new StringValue(value.ToString()!);
            }
            else
            {
                return (T)value;
            }
        }

        internal static T ToEnum<T>(string value) where T : struct, Enum
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return default;
            }

            if (long.TryParse(value, out long longValue))
            {
                return (T)Enum.ToObject(typeof(T), longValue);
            }

            if (Enum.TryParse<T>(value, true, out T enumValue))
            {
                return enumValue;
            }

            throw new InvalidCastException();
        }

        internal static object ToEnum(Type enumType, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return default(Enum)!;
            }

            if (long.TryParse(value, out long longValue))
            {
                return Enum.ToObject(enumType, longValue);
            }

            if (Enum.IsDefined(enumType, value))
            {
                return (Enum)Enum.Parse(enumType, value);
            }

            return Enum.ToObject(enumType, value);
        }

        internal static object[] ToEnumArray(Type enumType, string[] values)
        {
            object[] enums = new object[values.Length];

            for (int i = 0; i < values.Length; ++i)
            {
                enums[i] = ToEnum(enumType, values[i]);
            }

            return enums;
        }

        internal static object?[] ToEnumArrayOrNull(Type enumType, string?[] values)
        {
            object?[] enums = new object?[values.Length];

            for (int i = 0; i < values.Length; ++i)
            {
                if (!string.IsNullOrWhiteSpace(values[i]))
                {
                    enums[i] = ToEnum(enumType, values[i]!);
                }
            }

            return enums;
        }

        internal static T?[] ToEnumArrayOrAllValues<T>(string?[]? values) where T : struct, Enum
        {
            T?[]? enumValues;

            if (values != null)
            {
                enumValues = new T?[values.Length];

                for (int i = 0; i < values.Length; ++i)
                {
                    if (!string.IsNullOrWhiteSpace(values[i]))
                    {
                        enumValues[i] = ToEnum<T>(values[i]!);
                    }
                }
            }
            else
            {
                var array = Enum.GetValues(typeof(T));

                enumValues = new T?[array.Length];

                for (int i = 0; i < array.Length; ++i)
                {
                    enumValues[i] = (T?)array.GetValue(i);
                }
            }

            return enumValues;
        }

        internal static IEnumerable<object?> EnumerateAllEnumValues(Type enumType)
        {
            var array = Enum.GetValues(enumType);

            for (int i = 0; i < array.Length; ++i)
            {
                yield return array.GetValue(i);
            }
        }

    }
}
