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
    public class DataGeneratorTupleField<T1, T2, T3, T4> : DataGeneratorTupleFieldBase, IDataGeneratorTupleField<T1, T2, T3, T4>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
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
        /// <param name="enumerationCreator">The method to generate an enumeration.</param>
        public DataGeneratorTupleField(string fieldName1, bool mayBeNull1, string fieldName2, bool mayBeNull2, string fieldName3, bool mayBeNull3, string fieldName4, bool mayBeNull4, TupleEnumerationCreator<T1, T2, T3, T4> enumerationCreator)
            : base(new[] { fieldName1, fieldName2, fieldName3, fieldName4 }, new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) }, new[] { mayBeNull1, mayBeNull2, mayBeNull3, mayBeNull4 })
        {
            m_EnumerationCreator = enumerationCreator;
        }

        private readonly TupleEnumerationCreator<T1, T2, T3, T4> m_EnumerationCreator;

        /// <inheritdoc/>
        public override async ValueTask<IDataGeneratorTupleFieldEnumeration> CreateEnumerationAsync(int generateCount)
        {
            return await CreateTypedEnumerationAsync(generateCount).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async ValueTask<IDataGeneratorTupleFieldEnumeration<T1, T2, T3, T4>> CreateTypedEnumerationAsync(int generateCount)
        {
            return new DataGeneratorTupleFieldEnumeration<T1, T2, T3, T4>(GetFieldName(0), GetFieldName(1), GetFieldName(2), GetFieldName(3)
                    , await m_EnumerationCreator(generateCount).ConfigureAwait(false)
                    );
        }

    }
}
