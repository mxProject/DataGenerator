using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Exception indicating that the field definition is incorrect.
    /// </summary>
    public class DataGeneratorFieldException : Exception
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="fieldName">The field name.</param>
        /// <param name="innerException">The inner exception.</param>
        public DataGeneratorFieldException(string message, string? fieldName, Exception? innerException = null)
            : base(message, innerException)
        {
            FieldNames = new[] { fieldName };
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="fieldNames">The field names.</param>
        /// <param name="innerException">The inner exception.</param>
        public DataGeneratorFieldException(string message, string?[] fieldNames, Exception? innerException = null)
            : base(message, innerException)
        {
            FieldNames = fieldNames;
        }

        ///// <summary>
        ///// Creates a new instance.
        ///// </summary>
        ///// <param name="info"></param>
        ///// <param name="context"></param>
        //protected DataGeneratorFieldException(SerializationInfo info, StreamingContext context)
        //    : base(info, context)
        //{
        //    FieldNames = null;
        //}

        /// <summary>
        /// Gets the field name.
        /// </summary>
        public string?[]? FieldNames { get; }
    }

}
