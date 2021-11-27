using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using mxProject.Devs.DataGeneration.Fields;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration.Configuration.Fields
{

    /// <summary>
    /// Settings for a field that enumerates the result of a expression text. 
    /// </summary>
    public sealed class ComputingFieldSettings : CompositeFieldSettingsBase
    {
        /// <summary>
        /// Create a new instance.
        /// </summary>
        public ComputingFieldSettings() : base()
        {
        }

        #region properties

        /// <summary>
        /// Gets or sets the value type name.
        /// </summary>
        [JsonProperty("ValueType", Order = 101)]
        public string? ValueTypeName { get; set; }

        /// <summary>
        /// Gets or sets the expression text.
        /// </summary>
        [JsonProperty("Expression", Order = 102)]
        public string? Expression { get; set; }

        #endregion

        #region clone

        /// <inheritdoc/>
        public override object Clone()
        {
            var clone = (FormattedStringFieldSettings)base.Clone();

            return clone;
        }

        #endregion

        /// <inheritdoc/>
        protected override void Assert()
        {
            base.Assert();

            if (ValueTypeName == null)
            {
                throw new NullReferenceException("The value of the ValueTypeName property is null.");
            }

            if (Expression == null)
            {
                throw new NullReferenceException("The value of the Expression property is null.");
            }
        }

        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            static IEnumerable<IDataGeneratorField> GetFields(DataGeneratorFieldSettings[] fields, DataGeneratorContext context)
            {
                foreach (var field in fields)
                {
                    yield return field.CreateField(context);
                }
            }

            var valueType = DataGeneratorUtility.GetFieldValueType(Type.GetType(ValueTypeName));

            return CompositeFieldFactory.CreateComputingField(FieldName!, valueType, Expression!, GetFields(ArgumentFields!, context), context, NullProbability);
        }

    }

}
