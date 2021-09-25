using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using mxProject.Devs.DataGeneration.Fields;

namespace mxProject.Devs.DataGeneration.ModelMappings
{

    /// <summary>
    /// Basic implementation of DataGeneratorField attribute.
    /// </summary>
    [Obsolete]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public abstract class DataGenerationFieldAttribute : Attribute
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        protected DataGenerationFieldAttribute(string? fieldName = null)
        {
            FieldName = fieldName;
        }

        /// <summary>
        /// Gets the field name.
        /// </summary>
        public string? FieldName { get; }

        /// <summary>
        /// Creates an instance of <see cref="IDataGeneratorField"/> interface.
        /// </summary>
        /// <param name="member"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract IDataGeneratorField CreateField(MemberInfo member, DataGeneratorContext context);

    }

}
