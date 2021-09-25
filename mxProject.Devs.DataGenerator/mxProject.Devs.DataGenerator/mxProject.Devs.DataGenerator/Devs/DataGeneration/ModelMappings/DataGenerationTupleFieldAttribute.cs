using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace mxProject.Devs.DataGeneration.ModelMappings
{

    /// <summary>
    /// Basic implementation of DataGeneratorTupleField attribute.
    /// </summary>
    [Obsolete]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public abstract class DataGenerationTupleFieldAttribute : Attribute
    {

        /// <summary>
        /// Create a new instanse.
        /// </summary>
        /// <param name="tupleId">A value that uniquely identifies a group of tuple fields.</param>
        /// <param name="fieldIndex">The field index.</param>
        protected DataGenerationTupleFieldAttribute(string tupleId, int fieldIndex)
        {
            TupleID = tupleId;
            FieldIndex = fieldIndex;
        }

        /// <summary>
        /// Gets the value that uniquely identifies a group of tuple fields.
        /// </summary>
        public string TupleID { get; }

        /// <summary>
        /// Gets the field index.
        /// </summary>
        public int FieldIndex { get; }

        /// <summary>
        /// Creates an instance of <see cref="IDataGeneratorTupleField"/> interface.
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract IDataGeneratorTupleField CreateTupleField(IDataGeneratorField[] fields, DataGeneratorContext context);

    }

}
