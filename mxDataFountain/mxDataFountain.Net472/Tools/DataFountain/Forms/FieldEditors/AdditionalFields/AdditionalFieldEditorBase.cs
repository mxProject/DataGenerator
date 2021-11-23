#nullable enable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Devs.DataGeneration.Configuration.AdditionalFields;

using mxProject.Tools.DataFountain.Messaging;
using mxProject.Tools.DataFountain.Models;

namespace mxProject.Tools.DataFountain.Forms.FieldEditors.AdditionalFields
{

    /// <summary>
    /// Basic implementation of field editor.
    /// </summary>
    internal partial class AdditionalFieldEditorBase : UserControl, IDataGeneratorAdditionalFieldEditor
    {
        internal AdditionalFieldEditorBase() : this(null!)
        {
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="context"></param>
        internal AdditionalFieldEditorBase(DataFountainContext context)
        {
            InitializeComponent();

            Context = context;
        }

        protected DataFountainContext Context { get; }

        #region start editting

        protected DataGeneratorAdditionalFieldSettingsState? CurrentFieldState { get; private set; }

        /// <summary>
        /// Sets the specified field for editing.
        /// </summary>
        /// <param name="field"></param>
        protected virtual void SetFieldSettings(DataGeneratorAdditionalFieldSettingsState? field)
        {
            CurrentFieldState = field;
        }

        #endregion

        #region validation

        /// <summary>
        /// Validate the input values.
        /// </summary>
        /// <param name="invalidMessage">The message indicating that it is invalid.</param>
        /// <param name="invalidControl">The control with invalid value entered.</param>
        /// <returns></returns>
        protected virtual bool ValidateInputValues(out string? invalidMessage, out Control? invalidControl)
        {
            invalidMessage = null;
            invalidControl = null;
            return true;
        }

        #endregion

        #region end of editting

        /// <summary>
        /// Gets the edited field.
        /// </summary>
        /// <returns></returns>
        protected virtual DataGeneratorAdditionalFieldSettingsState GetUpdatedFieldSettings(DataGeneratorAdditionalFieldSettingsState? currentState)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the edited field as a new instance.
        /// </summary>
        /// <returns></returns>
        protected virtual DataGeneratorAdditionalFieldSettings GetFieldSettingsAsNew()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDataGeneratorFieldEditor

        /// <inheritdoc/>
        void IDataGeneratorAdditionalFieldEditor.SetFieldSettings(DataGeneratorAdditionalFieldSettingsState? settings)
        {
            SetFieldSettings(settings);
        }

        /// <inheritdoc/>
        DataGeneratorAdditionalFieldSettingsState IDataGeneratorAdditionalFieldEditor.UpdateFieldSettings()
        {
            return GetUpdatedFieldSettings(CurrentFieldState);
        }

        /// <inheritdoc/>
        DataGeneratorAdditionalFieldSettings IDataGeneratorAdditionalFieldEditor.GetFieldSettingsAsNew()
        {
            return GetFieldSettingsAsNew();
        }

        /// <inheritdoc/>
        bool IDataGeneratorAdditionalFieldEditor.Validate(out string? invalidMessage, out Control? invalidControl)
        {
            return ValidateInputValues(out invalidMessage, out invalidControl);
        }

        #endregion

    }
}
