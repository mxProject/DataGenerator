﻿using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Provides the functionality needed for fields that generate tuples of multiple values.
    /// </summary>
    /// <typeparam name="T1">The value type of the first field.</typeparam>
    /// <typeparam name="T2">The value type of the second field.</typeparam>
    /// <typeparam name="T3">The value type of the third field.</typeparam>
    /// <typeparam name="T4">The value type of the fourth field.</typeparam>
    /// <typeparam name="T5">The value type of the fifth field.</typeparam>
    /// <typeparam name="T6">The value type of the sixth field.</typeparam>
    /// <typeparam name="T7">The value type of the seventh field.</typeparam>
    /// <typeparam name="T8">The value type of the eighth field.</typeparam>
    /// <typeparam name="T9">The value type of the ninth field.</typeparam>
    public interface IDataGeneratorTupleFieldEnumeration<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IDataGeneratorTupleFieldEnumeration
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

        /// <summary>
        /// Gets the generated values.
        /// </summary>
        /// <returns></returns>
        (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?) GetTypedValues();

    }

}
