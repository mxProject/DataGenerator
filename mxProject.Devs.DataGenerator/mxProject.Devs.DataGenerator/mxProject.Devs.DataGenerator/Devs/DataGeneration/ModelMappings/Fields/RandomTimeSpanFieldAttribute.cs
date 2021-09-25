using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using mxProject.Devs.DataGeneration.Fields;

namespace mxProject.Devs.DataGeneration.ModelMappings.Fields
{

    /// <summary>
    /// Settings of a field that enumerates TimeSpan random values.
    /// </summary>
    [Obsolete]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class RandomTimeSpanFieldAttribute : RandomFieldAttribute
    {

        #region ctor

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="selectorDecralingType">The type in which the selector method is declared.</param>
        /// <param name="selectorMethodName">The name of the selector method.</param>
        /// <param name="fieldName">The field name.</param>
        public RandomTimeSpanFieldAttribute(string minValue, string maxValue, double nullProbability = 0, Type? selectorDecralingType = null, string? selectorMethodName = null, string? fieldName = null)
            : base(nullProbability, selectorDecralingType, selectorMethodName, fieldName)
        {
            MinimumValue = minValue;
            MaximumValue = maxValue;
        }

        #endregion

        /// <summary>
        /// Gets the minimum value.
        /// </summary>
        public string MinimumValue { get; }

        /// <summary>
        /// Gets the maximum value.
        /// </summary>
        public string MaximumValue { get; }


        #region CreateField

        /// <inheritdoc/>
        public override IDataGeneratorField CreateField(MemberInfo member, DataGeneratorContext context)
        {
            var minValue = context.StringConverter.ConvertTo<TimeSpan>(MinimumValue);
            var maxValue = context.StringConverter.ConvertTo<TimeSpan>(MaximumValue);
            var selector = GetSelectorMethod<Func<TimeSpan, TimeSpan>>(SelectorDecralingType, SelectorMethodName);
            return context.FieldFactory.RandomTimeSpan(FieldName ?? member.Name, minValue, maxValue, selector, NullProbability);
        }

        #endregion

    }

}
