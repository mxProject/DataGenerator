using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Provides the functionality needed to convert string values.
    /// </summary>
    public interface IStringConverter
    {

        /// <summary>
        /// Converts the specified string value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="type">The type of converted value.</param>
        /// <returns>A converted value.</returns>
        object? ConvertTo(string? value, Type type);

        /// <summary>
        /// Converts the specified string value.
        /// </summary>
        /// <typeparam name="T">The type of converted value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>A converted value.</returns>
        T ConvertTo<T>(string? value);

    }

    /// <summary>
    /// Extension methods for <see cref="IStringConverter"/>.
    /// </summary>
    public static class IStringConverterExtensions
    {
        /// <summary>
        /// Converts the specified string value.
        /// </summary>
        /// <param name="converter"></param>
        /// <typeparam name="T">The type of converted value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>A converted value.</returns>
        public static T? ConvertToOrNull<T>(this IStringConverter converter, string? value)
            where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            else
            {
                return converter.ConvertTo<T>(value);
            }
        }
    }

}
