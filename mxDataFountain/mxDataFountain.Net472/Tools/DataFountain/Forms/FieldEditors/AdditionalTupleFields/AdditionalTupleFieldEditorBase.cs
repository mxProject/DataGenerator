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

using mxProject.Devs.DataGeneration;
using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Devs.DataGeneration.Configuration.Fields;

using mxProject.Tools.DataFountain.Messaging;
using mxProject.Tools.DataFountain.Models;

namespace mxProject.Tools.DataFountain.Forms.FieldEditors.AdditionalTupleFields
{

    /// <summary>
    /// Basic implementation of field editor.
    /// </summary>
    internal partial class AdditionalTupleFieldEditorBase : UserControl, IDataGeneratorAdditionalTupleFieldEditor
    {
        internal AdditionalTupleFieldEditorBase() : this(null!)
        {
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="context"></param>
        internal AdditionalTupleFieldEditorBase(DataFountainContext context)
        {
            InitializeComponent();

            Context = context;
        }

        protected DataFountainContext Context { get; }

        #region start editting

        protected DataGeneratorAdditionalTupleFieldSettingsState? FieldState { get; private set; }

        /// <summary>
        /// Sets the specified field for editing.
        /// </summary>
        /// <param name="fieldSettings"></param>
        protected virtual void SetFieldSettings(DataGeneratorAdditionalTupleFieldSettingsState? fieldSettings)
        {
            FieldState = fieldSettings;
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
        /// <param name="currentState"></param>
        /// <returns></returns>
        protected virtual DataGeneratorAdditionalTupleFieldSettingsState GetUpdatedFieldSettings(DataGeneratorAdditionalTupleFieldSettingsState? currentState)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the edited field as a new instance.
        /// </summary>
        /// <returns></returns>
        protected virtual DataGeneratorAdditionalTupleFieldSettings GetFieldSettingsAsNew()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDataGeneratorFieldEditor

        /// <inheritdoc/>
        void IDataGeneratorAdditionalTupleFieldEditor.SetFieldSettings(DataGeneratorAdditionalTupleFieldSettingsState? settings)
        {
            SetFieldSettings(settings);
        }

        /// <inheritdoc/>
        DataGeneratorAdditionalTupleFieldSettingsState IDataGeneratorAdditionalTupleFieldEditor.UpdateFieldSettings()
        {
            return GetUpdatedFieldSettings(FieldState);
        }

        /// <inheritdoc/>
        DataGeneratorAdditionalTupleFieldSettings IDataGeneratorAdditionalTupleFieldEditor.GetFieldSettingsAsNew()
        {
            return GetFieldSettingsAsNew();
        }

        /// <inheritdoc/>
        bool IDataGeneratorAdditionalTupleFieldEditor.Validate(out string? invalidMessage, out Control? invalidControl)
        {
            return ValidateInputValues(out invalidMessage, out invalidControl);
        }

        #endregion

    }
}
