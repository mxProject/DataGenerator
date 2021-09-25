using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using mxProject.Devs.DataGeneration.Fields;

namespace mxProject.Devs.DataGeneration.ModelMappings.Fields
{

    /// <summary>
    /// Settings of a field that enumerates Byte sequencial values.
    /// </summary>
    [Obsolete]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class SequenceByteFieldAttribute : SequenceFieldAttribute
    {

        #region ctor

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="increment">The amount of increase in value when creating a new sequence value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public SequenceByteFieldAttribute(byte initialValue = 1, byte maxValue = byte.MaxValue, byte increment = 1, double nullProbability = 0, string? fieldName = null)
            : base(nullProbability, fieldName)
        {
            InitialValue = initialValue;
            MaximumValue = maxValue;
            Increment = increment;
        }

        #endregion

        /// <summary>
        /// Gets the initial value.
        /// </summary>
        public byte InitialValue { get; }

        /// <summary>
        /// Gets the maximum value.
        /// </summary>
        public byte MaximumValue { get; }

        /// <summary>
        /// Gets the amount of increase in value when creating a new sequence value.
        /// </summary>
        public byte Increment { get; }

        #region CreateField

        /// <inheritdoc/>
        public override IDataGeneratorField CreateField(MemberInfo member, DataGeneratorContext context)
        {
            return context.FieldFactory.SequenceByte(FieldName ?? member.Name, InitialValue, MaximumValue, Increment, NullProbability);
        }

        #endregion

    }

}
