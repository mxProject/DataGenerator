﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Buffers;
using System.Threading.Tasks;

namespace mxProject.Devs.DataGeneration.Fields
{

    /// <summary>
    /// Field that generates a tuple of multiple values.
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
    public class DataGeneratorTupleField<T1, T2, T3, T4, T5, T6, T7, T8, T9> : DataGeneratorTupleFieldBase, IDataGeneratorTupleField<T1, T2, T3, T4, T5, T6, T7, T8, T9>
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
        /// Creates a new instance.
        /// </summary>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="mayBeNull1">A value that indicates whether the first field may return a null value.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="mayBeNull2">A value that indicates whether the second field may return a null value.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="mayBeNull3">A value that indicates whether the third field may return a null value.</param>
        /// <param name="fieldName4">The name of the fourth field.</param>
        /// <param name="mayBeNull4">A value that indicates whether the fourth field may return a null value.</param>
        /// <param name="fieldName5">The name of the fifth field.</param>
        /// <param name="mayBeNull5">A value that indicates whether the fifth field may return a null value.</param>
        /// <param name="fieldName6">The name of the sixth field.</param>
        /// <param name="mayBeNull6">A value that indicates whether the sixth field may return a null value.</param>
        /// <param name="fieldName7">The name of the seventh field.</param>
        /// <param name="mayBeNull7">A value that indicates whether the seventh field may return a null value.</param>
        /// <param name="fieldName8">The name of the eighth field.</param>
        /// <param name="mayBeNull8">A value that indicates whether the eighth field may return a null value.</param>
        /// <param name="fieldName9">The name of the ninth field.</param>
        /// <param name="mayBeNull9">A value that indicates whether the ninth field may return a null value.</param>
        /// <param name="enumerationCreator">The method to generate an enumeration.</param>
        public DataGeneratorTupleField(string fieldName1, bool mayBeNull1, string fieldName2, bool mayBeNull2, string fieldName3, bool mayBeNull3, string fieldName4, bool mayBeNull4, string fieldName5, bool mayBeNull5, string fieldName6, bool mayBeNull6, string fieldName7, bool mayBeNull7, string fieldName8, bool mayBeNull8, string fieldName9, bool mayBeNull9, TupleEnumerationCreator<T1, T2, T3, T4, T5, T6, T7, T8, T9> enumerationCreator)
            : base(new[] { fieldName1, fieldName2, fieldName3, fieldName4, fieldName5, fieldName6, fieldName7, fieldName8, fieldName9 }, new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) }, new[] { mayBeNull1, mayBeNull2, mayBeNull3, mayBeNull4, mayBeNull4, mayBeNull5, mayBeNull6, mayBeNull7, mayBeNull8, mayBeNull9 })
        {
            m_EnumerationCreator = enumerationCreator;
        }

        private readonly TupleEnumerationCreator<T1, T2, T3, T4, T5, T6, T7, T8, T9> m_EnumerationCreator;

        /// <inheritdoc/>
        public override async ValueTask<IDataGeneratorTupleFieldEnumeration> CreateEnumerationAsync(int generateCount)
        {
            return await CreateTypedEnumerationAsync(generateCount).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async ValueTask<IDataGeneratorTupleFieldEnumeration<T1, T2, T3, T4, T5, T6, T7, T8, T9>> CreateTypedEnumerationAsync(int generateCount)
        {
            return new DataGeneratorTupleFieldEnumeration<T1, T2, T3, T4, T5, T6, T7, T8, T9>(GetFieldName(0), GetFieldName(1), GetFieldName(2), GetFieldName(3), GetFieldName(4), GetFieldName(5), GetFieldName(6), GetFieldName(7), GetFieldName(8)
                , await m_EnumerationCreator(generateCount).ConfigureAwait(false)
                );
        }

    }

}
