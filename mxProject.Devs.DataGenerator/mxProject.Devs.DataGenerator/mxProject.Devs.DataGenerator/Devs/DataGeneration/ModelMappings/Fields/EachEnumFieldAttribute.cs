using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq;
using mxProject.Devs.DataGeneration.Fields;

namespace mxProject.Devs.DataGeneration.ModelMappings.Fields
{

    /// <summary>
    /// Settings of a field that enumerates the specified enum values.
    /// </summary>
    [Obsolete]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class EachEnumFieldAttribute : EachFieldAttribute
    {

        #region ctor

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="enumType">The type of the enum type.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public EachEnumFieldAttribute(Type enumType, double nullProbability = 0, string? fieldName = null)
            : base(fieldName, enumType, Array.Empty<object>(), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="enumType">The type of the enum type.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public EachEnumFieldAttribute(Type enumType, string?[] values, double nullProbability = 0, string? fieldName = null)
            : base(fieldName, enumType, values, nullProbability)
        {
        }

        #endregion

        /// <inheritdoc/>
        protected override IEnumerable<object?> ConvertValues(object?[]? values, Type valueType, DataGeneratorContext context)
        {
            if (values == null || values.Length == 0)
            {
                return DataGeneratorUtility.EnumerateAllEnumValues(valueType);
            }
            else
            {
                return base.ConvertValues(values, valueType, context);
            }
        }

    }

}
