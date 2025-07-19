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
    public class DataGeneratorTupleField<T1, T2> : DataGeneratorTupleFieldBase, IDataGeneratorTupleField<T1, T2>
        where T1 : struct
        where T2 : struct
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="mayBeNull1">A value that indicates whether the first field may return a null value.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="mayBeNull2">A value that indicates whether the second field may return a null value.</param>
        /// <param name="enumerationCreator">The method to generate an enumeration.</param>
        public DataGeneratorTupleField(string fieldName1, bool mayBeNull1, string fieldName2, bool mayBeNull2, TupleEnumerationCreatorAsync<T1, T2> enumerationCreator)
            : base(new[] { fieldName1, fieldName2 }, new[] { typeof(T1), typeof(T2) }, new[] { mayBeNull1, mayBeNull2 })
        {
            m_EnumerationCreator = enumerationCreator;
        }

        private readonly TupleEnumerationCreatorAsync<T1, T2> m_EnumerationCreator;

        /// <inheritdoc/>
        public override async ValueTask<IDataGeneratorTupleFieldEnumeration> CreateEnumerationAsync(int generateCount)
        {
            return await CreateTypedEnumerationAsync(generateCount).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async ValueTask<IDataGeneratorTupleFieldEnumeration<T1, T2>> CreateTypedEnumerationAsync(int generateCount)
        {
            return new DataGeneratorTupleFieldEnumeration<T1, T2>(GetFieldName(0), GetFieldName(1)
                , await m_EnumerationCreator(generateCount).ConfigureAwait(false)
                );
        }
    }

}
