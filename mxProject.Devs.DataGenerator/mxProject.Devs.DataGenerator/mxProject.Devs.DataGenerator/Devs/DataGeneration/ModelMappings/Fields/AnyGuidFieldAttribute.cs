using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using mxProject.Devs.DataGeneration.Fields;

namespace mxProject.Devs.DataGeneration.ModelMappings.Fields
{

    /// <summary>
    /// Settings for a field that enumerates one of the specified Guid values.
    /// </summary>
    [Obsolete]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class AnyGuidFieldAttribute : AnyFieldAttribute
    {

        #region ctor

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public AnyGuidFieldAttribute(string?[] values, double nullProbability = 0, string? fieldName = null)
            : base(fieldName, typeof(Guid), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        #endregion

    }

}
