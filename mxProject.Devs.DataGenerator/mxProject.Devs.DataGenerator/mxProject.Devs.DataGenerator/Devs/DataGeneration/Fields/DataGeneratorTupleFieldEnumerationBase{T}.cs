using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Buffers;
using System.ComponentModel.Design.Serialization;

namespace mxProject.Devs.DataGeneration.Fields
{

    /// <summary>
    /// Basic implementation of a field that generates a tuple of multiple values.
    /// </summary>
    /// <typeparam name="TTuple">The value type to enumerate.</typeparam>
    public abstract class DataGeneratorTupleFieldEnumerationBase<TTuple> : DataGeneratorTupleFieldEnumerationBase
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="fieldNames">The names of the fields.</param>
        /// <param name="valueTypes">The value types of the fields.</param>
        /// <param name="enumeration">Enumeration of field values.</param>
        public DataGeneratorTupleFieldEnumerationBase(string[] fieldNames, Type[] valueTypes, IEnumerable<TTuple> enumeration) : base(fieldNames)
        {
            m_ValueTypes = valueTypes;
            m_Enumeration = enumeration;
            m_Enumerator = m_Enumeration.GetEnumerator();
        }

        private readonly Type[] m_ValueTypes;
        private readonly IEnumerable<TTuple> m_Enumeration;
        private IEnumerator<TTuple> m_Enumerator;

        #region dispose

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            m_Enumerator?.Dispose();

            base.Dispose(disposing);
        }

        #endregion

        #region generation

        private bool m_Eof;

        /// <inheritdoc/>
        public override void Reset()
        {
            m_Enumerator?.Dispose();
            m_Enumerator = m_Enumeration.GetEnumerator();
            m_Eof = false;
        }

        /// <inheritdoc/>
        public override bool GenerateNext()
        {
            if (m_Enumerator.MoveNext())
            {
                return true;
            }
            else
            {
                m_Eof = true;
                return false;
            }
        }

        /// <summary>
        /// Tf this instance is EOF, throw an exception.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// This generator is already EOF. 
        /// </exception>
        private void ThrowExceptionIfEof()
        {
            if (m_Eof)
            {
                throw new InvalidOperationException("This enumerator is already EOF.");
            }
        }

        #endregion

        #region value

        /// <inheritdoc/>
        /// <exception cref="InvalidOperationException">
        /// This enumerator is already EOF.
        /// </exception>
        public TTuple GetTypedValues()
        {
            ThrowExceptionIfEof();
            return m_Enumerator.Current;
        }

        /// <inheritdoc/>
        /// <exception cref="IndexOutOfRangeException">
        /// </exception>
        public override Type GetValueType(int index)
        {
            if (index < 0 || m_ValueTypes.Length <= index)
            {
                throw new IndexOutOfRangeException();
            }

            return m_ValueTypes[index];
        }

        #endregion

    }

}
