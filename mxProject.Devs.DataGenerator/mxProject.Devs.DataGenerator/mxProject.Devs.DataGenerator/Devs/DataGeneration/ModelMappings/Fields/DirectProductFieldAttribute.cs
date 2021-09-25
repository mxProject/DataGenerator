using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using mxProject.Devs.DataGeneration.Fields;

namespace mxProject.Devs.DataGeneration.ModelMappings.Fields
{

    /// <summary>
    /// Indicates that it is part of a field that generates a direct product of multiple values. 
    /// </summary>
    [Obsolete]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class DirectProductFieldAttribute : DataGenerationTupleFieldAttribute
    {

        /// <summary>
        /// Create a new instanse.
        /// </summary>
        /// <param name="tupleId">A value that uniquely identifies a group of tuple fields.</param>
        /// <param name="fieldIndex">The field index.</param>
        public DirectProductFieldAttribute(string tupleId, int fieldIndex) : base(tupleId, fieldIndex)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="IDataGeneratorTupleField"/> interface.
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IDataGeneratorTupleField CreateTupleField(IDataGeneratorField[] fields, DataGeneratorContext context)
        {
            return DirectProductFieldFactory.CreateTupleField(fields, context);
        }

    }

}
