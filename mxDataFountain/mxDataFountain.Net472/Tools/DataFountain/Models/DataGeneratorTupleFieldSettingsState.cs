#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mxProject.Devs.DataGeneration.Configuration;

namespace mxProject.Tools.DataFountain.Models
{

    internal class DataGeneratorTupleFieldSettingsState : DataGeneratorFieldSettingsStateBase<DataGeneratorTupleFieldSettings>
    {
        internal DataGeneratorTupleFieldSettingsState() : base(null)
        {
        }

        internal DataGeneratorTupleFieldSettingsState(DataGeneratorTupleFieldSettings settings) : base(settings)
        {
        }

        /// <inheritdoc/>
        internal override DataGeneratorFieldKind FieldKind => DataGeneratorFieldKind.TupleField;

        /// <inheritdoc/>
        internal override string[] GetFieldNames()
        {
            if (Settings == null) { return Array.Empty<string>(); }
            return Settings.GetFieldNames().Select(x => string.IsNullOrEmpty(x) ? UndefinedFieldName : x!).ToArray();
        }

        /// <summary>
        /// Gets the data generator field type.
        /// </summary>
        internal DataGeneratorTupleFieldType FieldType
        {
            get { return Settings.GetFieldType(); }
        }

    }

}
