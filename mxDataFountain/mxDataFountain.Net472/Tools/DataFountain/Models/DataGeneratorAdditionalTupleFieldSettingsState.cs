#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mxProject.Devs.DataGeneration.Configuration;

namespace mxProject.Tools.DataFountain.Models
{

    internal class DataGeneratorAdditionalTupleFieldSettingsState : DataGeneratorFieldSettingsStateBase<DataGeneratorAdditionalTupleFieldSettings>
    {
        internal DataGeneratorAdditionalTupleFieldSettingsState() : base(null)
        {
        }

        internal DataGeneratorAdditionalTupleFieldSettingsState(DataGeneratorAdditionalTupleFieldSettings settings) : base(settings)
        {
        }

        /// <inheritdoc/>
        internal override DataGeneratorFieldKind FieldKind => DataGeneratorFieldKind.AdditionalTupleField;

        /// <inheritdoc/>
        internal override string[] GetFieldNames()
        {
            if (Settings== null) { return Array.Empty<string>(); }
            return Settings.GetAdditionalFieldNames().Select(x => string.IsNullOrEmpty(x) ? UndefinedFieldName : x!).ToArray();
        }

        /// <summary>
        /// Gets the data generator field type.
        /// </summary>
        internal DataGeneratorAdditionalTupleFieldType FieldType
        {
            get { return Settings.GetFieldType(); }
        }
    }

}
