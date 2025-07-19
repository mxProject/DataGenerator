using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace mxProject.Devs.DataGeneration
{
    internal static class DelegateExtensions
    {
        internal static EnumerationCreatorAsync ToAsync(this EnumerationCreator func)
        {
            return x => new ValueTask<IEnumerable<object?>>(func(x));
        }

        internal static StringEnumerationCreatorAsync ToAsync(this StringEnumerationCreator func)
        {
            return x => new ValueTask<IEnumerable<string?>>(func(x));
        }

        internal static EnumerationCreatorAsync<T> ToAsync<T>(this EnumerationCreator<T> func)
            where T : struct
        {
            return x => new ValueTask<IEnumerable<T?>>(func(x));
        }

        internal static TupleEnumerationCreatorAsync<T1, T2> ToAsync<T1, T2>(this TupleEnumerationCreator<T1, T2> func)
            where T1 : struct
            where T2 : struct
        {
            return x => new ValueTask<IEnumerable<(T1?, T2?)>>(func(x));
        }

        internal static TupleEnumerationCreatorAsync<T1, T2, T3> ToAsync<T1, T2, T3>(this TupleEnumerationCreator<T1, T2, T3> func)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            return x => new ValueTask<IEnumerable<(T1?, T2?, T3?)>>(func(x));
        }

        internal static TupleEnumerationCreatorAsync<T1, T2, T3, T4> ToAsync<T1, T2, T3, T4>(this TupleEnumerationCreator<T1, T2, T3, T4> func)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            return x => new ValueTask<IEnumerable<(T1?, T2?, T3?, T4?)>>(func(x));
        }

        internal static TupleEnumerationCreatorAsync<T1, T2, T3, T4, T5> ToAsync<T1, T2, T3, T4, T5>(this TupleEnumerationCreator<T1, T2, T3, T4, T5> func)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            return x => new ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?)>>(func(x));
        }

        internal static TupleEnumerationCreatorAsync<T1, T2, T3, T4, T5, T6> ToAsync<T1, T2, T3, T4, T5, T6>(this TupleEnumerationCreator<T1, T2, T3, T4, T5, T6> func)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            return x => new ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)>>(func(x));
        }

        internal static TupleEnumerationCreatorAsync<T1, T2, T3, T4, T5, T6, T7> ToAsync<T1, T2, T3, T4, T5, T6, T7>(this TupleEnumerationCreator<T1, T2, T3, T4, T5, T6, T7> func)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            return x => new ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)>>(func(x));
        }

        internal static TupleEnumerationCreatorAsync<T1, T2, T3, T4, T5, T6, T7, T8> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8>(this TupleEnumerationCreator<T1, T2, T3, T4, T5, T6, T7, T8> func)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            return x => new ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)>>(func(x));
        }

        internal static TupleEnumerationCreatorAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9> ToAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this TupleEnumerationCreator<T1, T2, T3, T4, T5, T6, T7, T8, T9> func)
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
            return x => new ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)>>(func(x));
        }
    }
}
