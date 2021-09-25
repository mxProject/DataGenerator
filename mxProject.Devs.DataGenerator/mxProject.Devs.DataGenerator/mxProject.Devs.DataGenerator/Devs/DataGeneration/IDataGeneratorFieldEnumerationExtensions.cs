using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration
{

    internal static class IDataGeneratorFieldEnumerationExtensions
    {

        /// <summary>
        /// Enumerates the values of the specified field.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <returns></returns>
        internal static IEnumerable<T?> GenerateValues<T>(this IDataGeneratorFieldEnumeration<T> field) where T : struct
        {
            while (field.GenerateNext())
            {
                yield return field.GetTypedValue();
            }
        }

    }

}
