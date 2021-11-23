#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mxProject.Devs.DataGeneration;

namespace mxProject.Tools.DataFountain
{
    internal static class ValidationUtility
    {

        /// <summary>
        /// Validates that the specified text is neither null nor empty.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="invalidMessage"></param>
        /// <returns></returns>
        internal static bool ValidateRequiredText(string? text, out string? invalidMessage)
        {
            if (string.IsNullOrEmpty(text))
            {
                invalidMessage = "The required value has not been set.";
                return false;
            }

            invalidMessage = null;
            return true;
        }

        /// <summary>
        /// Validates that the value in the specified text is valid as a value in the field.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="valueType"></param>
        /// <param name="stringConverter"></param>
        /// <param name="invalidMessage"></param>
        /// <returns></returns>
        internal static bool ValidateAsFieldValue(string text, Type valueType, IStringConverter stringConverter, out string? invalidMessage)
        {

            try
            {
                if (!string.IsNullOrEmpty(text))
                {
                    var _ = stringConverter.ConvertTo(text, valueType);
                }
            }
            catch (Exception ex)
            {
                invalidMessage = ex.Message;
                return false;
            }

            invalidMessage = null;
            return true;

        }

        /// <summary>
        /// Validates that the specified text is valid as an int type value.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <param name="invalidMessage"></param>
        /// <returns></returns>
        internal static bool ValidateAsInt32Text(string text, int? minimum, int? maximum, out string? invalidMessage)
        {
            return ValidateAsComparableTextCore<int>(text, minimum, maximum, out invalidMessage, s =>
            {
                if (int.TryParse(s, out int value))
                {
                    return (true, value);
                }
                else
                {
                    return (false, default);
                }
            });
        }

        /// <summary>
        /// Validates that the specified text is valid as a double type value.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <param name="invalidMessage"></param>
        /// <returns></returns>
        internal static bool ValidateAsDoubleText(string text, double? minimum, double? maximum, out string? invalidMessage)
        {
            return ValidateAsComparableTextCore<double>(text, minimum, maximum, out invalidMessage, s =>
            {
                if (double.TryParse(s, out double value))
                {
                    return (true, value);
                }
                else
                {
                    return (false, default);
                }
            });
        }

        /// <summary>
        /// Validates that the specified text is valid.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="text"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <param name="invalidMessage"></param>
        /// <param name="parser"></param>
        /// <returns></returns>
        private static bool ValidateAsComparableTextCore<T>(string text, T? minimum, T? maximum, out string? invalidMessage, Func<string, (bool, T)> parser)
            where T : struct, IComparable<T>
        {
            if (!string.IsNullOrEmpty(text))
            {
                var result = parser(text);

                if (!result.Item1)
                {
                    invalidMessage = $"The specified value cannot be converted to {typeof(T).Name} type.";
                    return false;
                }

                if (minimum.HasValue && result.Item2.CompareTo(minimum.Value) < 0)
                {
                    invalidMessage = $"The specified value is below {minimum.Value}.";
                    return false;
                }

                if (maximum.HasValue && result.Item2.CompareTo(maximum.Value) > 0)
                {
                    invalidMessage = $"The specified value is above {maximum.Value}.";
                    return false;
                }
            }

            invalidMessage = null;
            return true;
        }

        /// <summary>
        /// Validates that the spedified text is valid as a type name.
        /// </summary>
        /// <param name="valueTypeName"></param>
        /// <param name="invalidMessage"></param>
        /// <returns></returns>
        internal static bool ValidateAsValueTypeName(string valueTypeName, out string? invalidMessage)
        {
            if (string.IsNullOrEmpty(valueTypeName))
            {
                invalidMessage = "No type name is specified.";
                return false;
            }

            Type type = Type.GetType(valueTypeName);

            if (type == null)
            {
                invalidMessage = "The specified type cannot be recognized.";
                return false;
            }

            static bool IsValidType(Type type)
            {
                if (DataFountainContext.GetDefaultValueTypes().Contains(type)) { return true; }
                if (type.IsEnum) { return true; }
                if (type.IsValueType) { return true; }

                return false;
            }

            if (!IsValidType(type))
            {
                invalidMessage = "The specified type is not supported.";
                return false;
            }

            invalidMessage = null;
            return true;
        }

    }

}
