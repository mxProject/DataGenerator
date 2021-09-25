using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using mxProject.Devs.DataGeneration.Fields;

namespace mxProject.Devs.DataGeneration.ModelMappings.Fields
{

    /// <summary>
    /// Settings of a field that enumerates DateTime sequencial values at monthly intervals.
    /// </summary>
    [Obsolete]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class SequenceDateMonthFieldAttribute : SequenceFieldAttribute
    {

        #region ctor

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="months">Number of months.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public SequenceDateMonthFieldAttribute(string initialValue, string maxValue, int months, double nullProbability = 0, string? fieldName = null)
            : base(nullProbability, fieldName)
        {
            InitialValue = initialValue;
            MaximumValue = maxValue;
            Months = months;
        }

        #endregion

        /// <summary>
        /// Gets the initial value.
        /// </summary>
        public string InitialValue { get; }

        /// <summary>
        /// Gets the maximum value.
        /// </summary>
        public string MaximumValue { get; }

        /// <summary>
        /// Gets the number of months.
        /// </summary>
        public int Months { get; }

        #region CreateField

        /// <inheritdoc/>
        public override IDataGeneratorField CreateField(MemberInfo member, DataGeneratorContext context)
        {
            DateTime initial = context.StringConverter.ConvertTo<DateTime>(InitialValue);
            DateTime maxValue = context.StringConverter.ConvertTo<DateTime>(MaximumValue);

            return context.FieldFactory.SequenceDateMonth(FieldName ?? member.Name, initial, maxValue, Months, NullProbability);
        }

        #endregion

    }

}
