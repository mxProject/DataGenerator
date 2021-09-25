using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using mxProject.Devs.DataGeneration.Fields;

namespace mxProject.Devs.DataGeneration.ModelMappings.Fields
{

    /// <summary>
    /// Settings of a field that enumerates Int64 random values.
    /// </summary>
    [Obsolete]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class RandomInt64FieldAttribute : RandomFieldAttribute
    {

        #region ctor

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public RandomInt64FieldAttribute(long minValue = long.MinValue, long maxValue = long.MaxValue, double nullProbability = 0, string? fieldName = null)
            : base(nullProbability, fieldName: fieldName)
        {
            MinimumValue = minValue;
            MaximumValue = maxValue;
        }

        #endregion

        /// <summary>
        /// Gets the minimum value.
        /// </summary>
        public long MinimumValue { get; }

        /// <summary>
        /// Gets the maximum value.
        /// </summary>
        public long MaximumValue { get; }


        #region CreateField

        /// <inheritdoc/>
        public override IDataGeneratorField CreateField(MemberInfo member, DataGeneratorContext context)
        {
            var selector = GetSelectorMethod<Func<long, long>>(SelectorDecralingType, SelectorMethodName);
            return context.FieldFactory.RandomInt64(FieldName ?? member.Name, MinimumValue, MaximumValue, selector, NullProbability);
        }

        #endregion

    }

}
