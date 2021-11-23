#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Devs.DataGeneration.Configuration.Fields;

namespace mxProject.Tools.DataFountain.Models
{

    /// <summary>
    /// 
    /// </summary>
    internal class DataGeneratorFieldSettingsState : DataGeneratorFieldSettingsStateBase<DataGeneratorFieldSettings>
    {
        internal DataGeneratorFieldSettingsState() : base(null)
        {
        }

        internal DataGeneratorFieldSettingsState(DataGeneratorFieldSettings settings) : base(settings)
        {
        }

        /// <inheritdoc/>
        internal override DataGeneratorFieldKind FieldKind => DataGeneratorFieldKind.Field;

        /// <inheritdoc/>
        internal override string[] GetFieldNames()
        {
            if (Settings == null) { return Array.Empty<string>(); }
            return new string[] { string.IsNullOrEmpty(Settings.FieldName) ? UndefinedFieldName : Settings.FieldName! };
        }

        /// <summary>
        /// Gets the data generator field type.
        /// </summary>
        internal DataGeneratorFieldType FieldType
        {
            get { return Settings.GetFieldType(); }
        }

    }

}
