using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using mxProject.Devs.DataGeneration.Fields;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration.Configuration.Fields
{

    /// <summary>
    /// Settings for a field that enumerates string values formatted with a format string. 
    /// </summary>
    public sealed class FormattedStringFieldSettings : CompositeFieldSettingsBase
    {
        /// <summary>
        /// Create a new instance.
        /// </summary>
        public FormattedStringFieldSettings() : base()
        {
        }

        #region properties

        /// <summary>
        /// Gets or sets the composite format string. Field names are not supported. Specify by field index.
        /// </summary>
        [JsonProperty("FormatString", Order = 101)]
        public string? FormatString { get; set; }

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

            if (FormatString == null)
            {
                throw new NullReferenceException("The value of the FormatString property is null.");
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

            return CompositeFieldFactory.CreateFormattedStringField(FieldName!, FormatString!, GetFields(ArgumentFields!, context), context, NullProbability);
        }

    }

}
