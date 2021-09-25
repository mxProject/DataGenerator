using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1.Extensions
{
    internal static class StringArrayExtensions
    {

        internal static string? ConvertToString(this string?[] values)
        {
            return values[0];
        }

        internal static (string?, string?) ConvertToTuple2(this string?[] values)
        {
            return (values[0], values[1]);
        }

        internal static (string?, string?, string?) ConvertToTuple3(this string?[] values)
        {
            return (values[0], values[1], values[2]);
        }

        internal static (string?, string?, string?, string?) ConvertToTuple4(this string?[] values)
        {
            return (values[0], values[1], values[2], values[3]);
        }

        internal static (string?, string?, string?, string?, string?) ConvertToTuple5(this string?[] values)
        {
            return (values[0], values[1], values[2], values[3], values[4]);
        }

        internal static (string?, string?, string?, string?, string?, string?) ConvertToTuple6(this string?[] values)
        {
            return (values[0], values[1], values[2], values[3], values[4], values[5]);
        }

        internal static (string?, string?, string?, string?, string?, string?, string?) ConvertToTuple7(this string?[] values)
        {
            return (values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
        }

        internal static (string?, string?, string?, string?, string?, string?, string?, string?) ConvertToTuple8(this string?[] values)
        {
            return (values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]);
        }

        internal static (string?, string?, string?, string?, string?, string?, string?, string?, string?) ConvertToTuple9(this string?[] values)
        {
            return (values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8]);
        }

    }

}
