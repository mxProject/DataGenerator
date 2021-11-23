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
    /// Editor for <see cref="RandomFieldSettings"/>.
    /// </summary>
    internal partial class RandomFieldEditor : FieldEditorBase
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="context"></param>
        internal RandomFieldEditor(DataFountainContext context) : base(context)
        {
            InitializeComponent();

            InitValueTypes();
        }

        #region value types

        /// <summary>
        /// Initializes value types.
        /// </summary>
        private void InitValueTypes()
        {
            foreach (var type in Context.GetSupportedValueTypes(DataGeneratorFieldType.Random))
            {
                cmbValueType.Items.Add(type.FullName);
            }
        }

        #endregion

        #region start editting

        private RandomFieldSettings? m_OriginalFieldSettings;

        /// <summary>
        /// Sets the specified field for editing.
        /// </summary>
        /// <param name="field"></param>
        protected override void SetFieldSettings(DataGeneratorFieldSettingsState? field)
        {
            base.SetFieldSettings(field);

            m_OriginalFieldSettings = field?.Settings as RandomFieldSettings;

            if (m_OriginalFieldSettings == null)
            {
                txtNullProbability.Text = null;
                cmbValueType.Text = null;
                txtMinimumValue.Text = null;
                txtMaximumValue.Text = null;
                txtSelectorExpression.Text = null;
            }
            else
            {
                txtNullProbability.Text = m_OriginalFieldSettings.NullProbability.ToString();
                cmbValueType.Text = m_OriginalFieldSettings.ValueTypeName;
                txtMinimumValue.Text = m_OriginalFieldSettings.MinimumValue;
                txtMaximumValue.Text = m_OriginalFieldSettings.MaximumValue;
                txtSelectorExpression.Text = m_OriginalFieldSettings.SelectorExpression;
            }
        }

        #endregion

        #region validation

        /// <inheritdoc/>
        protected override bool ValidateInputValues(out string? invalidMessage, out Control? invalidControl)
        {
            if (!base.ValidateInputValues(out invalidMessage, out invalidControl)) { return false; }

            Control control;

            // ValueType
            control = cmbValueType;

            if (!Context.CurrentExecutor.ValidateAsValueTypeName(control.Text, out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            // NullProbability
            control = txtNullProbability;

            if (!ValidationUtility.ValidateAsDoubleText(control.Text, 0, 1, out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            // MinimumValue
            control = txtMinimumValue;

            if (!Context.CurrentExecutor.ValidateAsFieldValue(control.Text, cmbValueType.Text, out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            // MaximumValue
            control = txtMaximumValue;

            if (!Context.CurrentExecutor.ValidateAsFieldValue(control.Text, cmbValueType.Text, out invalidMessage))
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
            RandomFieldSettings fieldSettings = m_OriginalFieldSettings ?? new RandomFieldSettings();

            UpdateFieldSettings(fieldSettings);

            if (currentState == null)
            {
                return new DataGeneratorFieldSettingsState(fieldSettings);
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
            RandomFieldSettings fieldSettings = new();

            UpdateFieldSettings(fieldSettings);

            return fieldSettings;
        }

        /// <summary>
        /// Applies the input value to the specified field.
        /// </summary>
        /// <param name="fieldSettings"></param>
        private void UpdateFieldSettings(RandomFieldSettings fieldSettings)
        {
            fieldSettings.ValueTypeName = cmbValueType.Text;
            fieldSettings.NullProbability = FormUtility.ParseToDouble(txtNullProbability).GetValueOrDefault();
            fieldSettings.MinimumValue = txtMinimumValue.Text;
            fieldSettings.MaximumValue = txtMaximumValue.Text;
            fieldSettings.SelectorExpression = txtSelectorExpression.Text;
        }

        #endregion

    }
}
