using System;
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
    public class DataGeneratorTupleField<T1, T2, T3, T4, T5, T6> : DataGeneratorTupleFieldBase, IDataGeneratorTupleField<T1, T2, T3, T4, T5, T6>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
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
        /// <param name="enumerationCreator">The method to generate an enumeration.</param>
        public DataGeneratorTupleField(string fieldName1, bool mayBeNull1, string fieldName2, bool mayBeNull2, string fieldName3, bool mayBeNull3, string fieldName4, bool mayBeNull4, string fieldName5, bool mayBeNull5, string fieldName6, bool mayBeNull6, TupleEnumerationCreatorAsync<T1, T2, T3, T4, T5, T6> enumerationCreator)
            : base(new[] { fieldName1, fieldName2, fieldName3, fieldName4, fieldName5, fieldName6 }, new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) }, new[] { mayBeNull1, mayBeNull2, mayBeNull3, mayBeNull4, mayBeNull4, mayBeNull5, mayBeNull6 })
        {
            m_EnumerationCreator = enumerationCreator;
        }

        private readonly TupleEnumerationCreatorAsync<T1, T2, T3, T4, T5, T6> m_EnumerationCreator;

        /// <inheritdoc/>
        public override async ValueTask<IDataGeneratorTupleFieldEnumeration> CreateEnumerationAsync(int generateCount)
        {
            return await CreateTypedEnumerationAsync(generateCount).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async ValueTask<IDataGeneratorTupleFieldEnumeration<T1, T2, T3, T4, T5, T6>> CreateTypedEnumerationAsync(int generateCount)
        {
            return new DataGeneratorTupleFieldEnumeration<T1, T2, T3, T4, T5, T6>(GetFieldName(0), GetFieldName(1), GetFieldName(2), GetFieldName(3), GetFieldName(4), GetFieldName(5)
                , await m_EnumerationCreator(generateCount).ConfigureAwait(false)
                );
        }

    }

}
