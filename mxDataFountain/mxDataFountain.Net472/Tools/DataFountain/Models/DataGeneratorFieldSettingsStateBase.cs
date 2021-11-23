#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Tools.DataFountain.Models
{

    internal abstract class DataGeneratorFieldSettingsStateBase : IDataGeneratorFieldSettingsState
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        protected DataGeneratorFieldSettingsStateBase()
        {
        }

        /// <summary>
        /// Gets the data generator field kind.
        /// </summary>
        internal abstract DataGeneratorFieldKind FieldKind { get; }

        DataGeneratorFieldKind IDataGeneratorFieldSettingsState.FieldKind => FieldKind;

        /// <summary>
        /// Gets the field names.
        /// </summary>
        /// <returns></returns>
        internal abstract string[] GetFieldNames();

        string[] IDataGeneratorFieldSettingsState.GetFieldNames() => GetFieldNames();

        /// <summary>
        /// Field name indicating undefined.
        /// </summary>
        internal static readonly string UndefinedFieldName = "(undefined)";

        /// <summary>
        /// Gets a value that indicates whether this field is a new field.
        /// </summary>
        internal abstract bool IsNewField();

        bool IDataGeneratorFieldSettingsState.IsNewField => IsNewField();

    }

    internal abstract class DataGeneratorFieldSettingsStateBase<T> : DataGeneratorFieldSettingsStateBase
        where T : class
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="settings">The field settings.</param>
        protected DataGeneratorFieldSettingsStateBase(T? settings) : base()
        {
            Settings = settings;
        }

        /// <summary>
        /// Gets the field settings.
        /// </summary>
        internal T? Settings { get; private set; }

        /// <summary>
        /// Sets the field settings.
        /// </summary>
        /// <param name="settings"></param>
        internal void SetSettings(T settings)
        {
            Settings = settings;
        }

        /// <inheritdoc/>
        internal override bool IsNewField()
        {
            return Settings == null;
        }
    }

}
