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

namespace mxProject.Tools.DataFountain.Forms.FieldEditors.TupleFields
{

    /// <summary>
    /// Basic implementation of field editor.
    /// </summary>
    internal partial class TupleFieldEditorBase : UserControl, IDataGeneratorTupleFieldEditor
    {
        internal TupleFieldEditorBase() : this(null!)
        {
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="context"></param>
        internal TupleFieldEditorBase(DataFountainContext context)
        {
            InitializeComponent();

            Context = context;
        }

        protected DataFountainContext Context { get; }

        #region start editting

        protected DataGeneratorTupleFieldSettingsState? FieldState { get; private set; }

        /// <summary>
        /// Sets the specified field for editing.
        /// </summary>
        /// <param name="fieldSettings"></param>
        protected virtual void SetFieldSettings(DataGeneratorTupleFieldSettingsState? fieldSettings)
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
        protected virtual DataGeneratorTupleFieldSettingsState GetUpdatedFieldSettings(DataGeneratorTupleFieldSettingsState? currentState)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the edited field as a new instance.
        /// </summary>
        /// <returns></returns>
        protected virtual DataGeneratorTupleFieldSettings GetFieldSettingsAsNew()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDataGeneratorFieldEditor

        /// <inheritdoc/>
        void IDataGeneratorTupleFieldEditor.SetFieldSettings(DataGeneratorTupleFieldSettingsState? settings)
        {
            SetFieldSettings(settings);
        }

        /// <inheritdoc/>
        DataGeneratorTupleFieldSettingsState IDataGeneratorTupleFieldEditor.UpdateFieldSettings()
        {
            return GetUpdatedFieldSettings(FieldState);
        }

        /// <inheritdoc/>
        DataGeneratorTupleFieldSettings IDataGeneratorTupleFieldEditor.GetFieldSettingsAsNew()
        {
            return GetFieldSettingsAsNew();
        }

        /// <inheritdoc/>
        bool IDataGeneratorTupleFieldEditor.Validate(out string? invalidMessage, out Control? invalidControl)
        {
            return ValidateInputValues(out invalidMessage, out invalidControl);
        }

        #endregion

    }
}
