using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using mxProject.Devs.DataGeneration.Fields;

namespace mxProject.Devs.DataGeneration.ModelMappings.Fields
{

    /// <summary>
    /// Settings of a field that enumerates UInt32 sequencial values.
    /// </summary>
    [Obsolete]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class SequenceUInt32FieldAttribute : SequenceFieldAttribute
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
        public SequenceUInt32FieldAttribute(uint initialValue = 1, uint maxValue = uint.MaxValue, uint increment = 1, double nullProbability = 0, string? fieldName = null)
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
        public uint InitialValue { get; }

        /// <summary>
        /// Gets the maximum value.
        /// </summary>
        public uint MaximumValue { get; }

        /// <summary>
        /// Gets the amount of increase in value when creating a new sequence value.
        /// </summary>
        public uint Increment { get; }

        #region CreateField

        /// <inheritdoc/>
        public override IDataGeneratorField CreateField(MemberInfo member, DataGeneratorContext context)
        {
            return context.FieldFactory.SequenceUInt32(FieldName ?? member.Name, InitialValue, MaximumValue, Increment, NullProbability);
        }

        #endregion

    }

}
