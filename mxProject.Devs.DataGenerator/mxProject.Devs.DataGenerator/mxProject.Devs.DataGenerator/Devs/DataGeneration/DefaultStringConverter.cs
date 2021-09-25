using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Default string converter.
    /// </summary>
    public sealed class DefaultStringConverter : IStringConverter
    {

        /// <summary>
        /// Singleton instance.
        /// </summary>
        public readonly static DefaultStringConverter Instance = new DefaultStringConverter();

        /// <inheritdoc/>
        public object? ConvertTo(string? value, Type type)
        {
            // if (string.IsNullOrWhiteSpace(value)) { return null; }

            if (type == typeof(string)) { return value; }
            if (type == typeof(StringValue)) { return value.ToStringValue(); }

            if (string.IsNullOrWhiteSpace(value)) { return null; }

            var valueType = type.GetUnderlayValueTypeOrSelf();

            if (valueType == typeof(DateTimeOffset))
            {
                return DateTimeOffset.Parse(value);
            }
            else if (valueType == typeof(DateTime))
            {
                return DateTime.Parse(value);
            }
            else if (valueType == typeof(TimeSpan))
            {
                return TimeSpan.Parse(value);
            }
            else if (valueType == typeof(Guid))
            {
                return Guid.Parse(value);
            }
            else if (valueType.IsEnum)
            {
                return DataGeneratorUtility.ToEnum(valueType, value!);
            }

            return System.Convert.ChangeType(value, type);
        }

        /// <inheritdoc/>
        public T ConvertTo<T>(string? value)
        {
            return (T)ConvertTo(value, typeof(T))!;
        }

    }

}
