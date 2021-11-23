using System;
using System.Collections.Generic;
using System.Text;

using mxProject.Devs.DataGeneration;

namespace ClassLibrary1
{

    internal class CustomStringConverter : IStringConverter
    {

        internal static CustomStringConverter Instance = new CustomStringConverter();

        private readonly DefaultStringConverter m_DefaultConverter = DefaultStringConverter.Instance;

        /// <inheritdoc/>
        public object? ConvertTo(string? value, Type type)
        {
            if (type == typeof(CustomStruct))
            {
                return CustomStruct.Parse(value);
            }

            return m_DefaultConverter.ConvertTo(value, type);
        }

        /// <inheritdoc/>
        public T ConvertTo<T>(string? value)
        {
            if (typeof(T) == typeof(CustomStruct))
            {
                return (T)(object)CustomStruct.Parse(value);
            }

            return m_DefaultConverter.ConvertTo<T>(value);
        }
    }

}
