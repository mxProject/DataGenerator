using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using mxProject.Devs.DataGeneration.Fields;

namespace mxProject.Devs.DataGeneration.ModelMappings.Fields
{

    /// <summary>
    /// Settings of a field that enumerates Boolean random values.
    /// </summary>
    [Obsolete]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class RandomBooleanFieldAttribute : RandomFieldAttribute
    {

        #region ctor

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="trueProbability">Probability of returning true. (between 0 and 1.0)</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public RandomBooleanFieldAttribute(double trueProbability = 0.5, double nullProbability = 0, string? fieldName = null)
            : base(nullProbability, fieldName: fieldName)
        {
            TrueProbability = trueProbability;
        }

        #endregion

        /// <summary>
        /// Gets probability of returning true. (between 0 and 1.0)
        /// </summary>
        public double TrueProbability { get; set; }


        #region CreateField

        /// <inheritdoc/>
        public override IDataGeneratorField CreateField(MemberInfo member, DataGeneratorContext context)
        {
            return context.FieldFactory.RandomBoolean(FieldName ?? member.Name, TrueProbability, NullProbability);
        }

        #endregion

    }

}
