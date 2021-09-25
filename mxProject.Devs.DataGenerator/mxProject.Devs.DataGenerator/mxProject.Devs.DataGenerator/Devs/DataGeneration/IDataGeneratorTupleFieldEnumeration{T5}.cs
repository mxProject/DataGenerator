using System;
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
    public interface IDataGeneratorTupleFieldEnumeration<T1, T2, T3, T4, T5> : IDataGeneratorTupleFieldEnumeration
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {

        /// <summary>
        /// Gets the generated values.
        /// </summary>
        /// <returns></returns>
        (T1?, T2?, T3?, T4?, T5?) GetTypedValues();

    }

}
