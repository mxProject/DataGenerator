#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mxProject.Devs.DataGeneration.Configuration;

namespace mxProject.Tools.DataFountain.Models
{

    internal class DataGeneratorAdditionalFieldSettingsState : DataGeneratorFieldSettingsStateBase<DataGeneratorAdditionalFieldSettings>
    {
        internal DataGeneratorAdditionalFieldSettingsState() : base(null)
        {
        }

        internal DataGeneratorAdditionalFieldSettingsState(DataGeneratorAdditionalFieldSettings settings) : base(settings)
        {
        }

        /// <inheritdoc/>
        internal override DataGeneratorFieldKind FieldKind => DataGeneratorFieldKind.AdditionalField;

        /// <inheritdoc/>
        internal override string[] GetFieldNames()
        {
            if (Settings == null) { return Array.Empty<string>(); }
            return new string[] { string.IsNullOrEmpty(Settings.FieldName) ? UndefinedFieldName : Settings.FieldName! };
        }

        /// <summary>
        /// Gets the data generator field type.
        /// </summary>
        internal DataGeneratorAdditionalFieldType FieldType
        {
            get { return Settings.GetFieldType(); }
        }
    }

}
