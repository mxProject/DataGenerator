using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Extension methods for <see cref="ILookup{TKey, TElement}"/>.
    /// </summary>
    internal static class LookupExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="lookup"></param>
        /// <param name="key"></param>
        /// <param name="found"></param>
        /// <returns></returns>
        internal static bool TryFirst<TKey, TElement>(this ILookup<TKey, TElement> lookup, TKey key, out TElement found)
        {
            foreach (var element in lookup[key])
            {
                found = element;
                return true;
            }

            found = default!;
            return false;
        }

    }

}
