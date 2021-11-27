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
using mxProject.Devs.DataGeneration.Configuration.Fields;

using mxProject.Tools.DataFountain.Messaging;
using mxProject.Tools.DataFountain.Models;

namespace mxProject.Tools.DataFountain.Forms.FieldEditors.Fields
{

    /// <summary>
    /// Editor for <see cref="FormattedStringFieldSettings"/>.
    /// </summary>
    internal partial class FormattedStringFieldEditor : FieldEditorBase
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="context"></param>
        internal FormattedStringFieldEditor(DataFountainContext context) : base(context)
        {
            InitializeComponent();
        }

        #region start editting

        private FormattedStringFieldSettings? m_OriginalFieldSettings;

        /// <inheritdoc/>
        protected override void SetFieldSettings(DataGeneratorFieldSettingsState? field)
        {
            base.SetFieldSettings(field);

            m_OriginalFieldSettings = field?.Settings as FormattedStringFieldSettings;
            
            if (m_OriginalFieldSettings == null)
            {
                txtFormatString.Text = null;
            }
            else
            {
                txtFormatString.Text = m_OriginalFieldSettings.FormatString;
            }
        }

        #endregion

        #region validation

        /// <inheritdoc/>
        protected override bool ValidateInputValues(out string? invalidMessage, out Control? invalidControl)
        {
            if (!base.ValidateInputValues(out invalidMessage, out invalidControl)) { return false; }

            Control control;

            // Expression
            control = txtFormatString;

            if (!ValidationUtility.ValidateRequiredText(control.Text, out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            invalidMessage = null;
            invalidControl = null;
            return true;
        }

        #endregion

        #region end of editting

        /// <inheritdoc/>
        protected override DataGeneratorFieldSettingsState GetUpdatedFieldSettings(DataGeneratorFieldSettingsState? currentState)
        {
            FormattedStringFieldSettings fieldSettings = m_OriginalFieldSettings ?? new FormattedStringFieldSettings();

            UpdateFieldSettings(fieldSettings);

            if (currentState == null)
            {
                return new CompositeFieldSettingsState(fieldSettings);
            }
            else
            {
                currentState.SetSettings(fieldSettings);
                return currentState;
            }
        }

        /// <inheritdoc/>
        protected override DataGeneratorFieldSettings GetFieldSettingsAsNew()
        {
            FormattedStringFieldSettings fieldSettings = new();

            UpdateFieldSettings(fieldSettings);

            return fieldSettings;
        }

        /// <summary>
        /// Applies the input value to the specified field.
        /// </summary>
        /// <param name="fieldSettings"></param>
        private void UpdateFieldSettings(FormattedStringFieldSettings fieldSettings)
        {
            fieldSettings.FormatString = txtFormatString.Text;
        }

        #endregion

    }
}
