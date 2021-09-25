using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using mxProject.Devs.DataGeneration.Fields;

namespace mxProject.Devs.DataGeneration.ModelMappings.Fields
{

    /// <summary>
    /// Basic implementation of a field attribute that enumerates sequencial values.
    /// </summary>
    [Obsolete]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public abstract class SequenceFieldAttribute : DataGenerationFieldAttribute
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        protected SequenceFieldAttribute(double nullProbability = 0, string? fieldName = null) : base(fieldName)
        {
            NullProbability = nullProbability;
        }

        /// <summary>
        /// Gets probability of returning null. (between 0 and 1.0)
        /// </summary>
        public double NullProbability { get; }

    }

}
