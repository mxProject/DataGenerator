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
    /// Editor for <see cref="SequenceFieldSettings"/>.
    /// </summary>
    internal partial class SequenceFieldEditor : FieldEditorBase
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="context"></param>
        internal SequenceFieldEditor(DataFountainContext context) : base(context)
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
            foreach (var type in Context.GetSupportedValueTypes(DataGeneratorFieldType.Sequence))
            {
                cmbValueType.Items.Add(type.FullName);
            }
        }

        #endregion

        #region start editting

        private SequenceFieldSettings? m_OriginalFieldSettings;

        /// <summary>
        /// Sets the specified field for editing.
        /// </summary>
        /// <param name="field"></param>
        protected override void SetFieldSettings(DataGeneratorFieldSettingsState? field)
        {
            base.SetFieldSettings(field);

            m_OriginalFieldSettings = field?.Settings as SequenceFieldSettings;

            if (m_OriginalFieldSettings == null)
            {
                txtNullProbability.Text = null;
                cmbValueType.Text = null;
                txtInitialValue.Text = null;
                txtMaximumValue.Text = null;
                txtIncrement.Text = null;
            }
            else
            {
                txtNullProbability.Text = m_OriginalFieldSettings.NullProbability.ToString();
                cmbValueType.Text = m_OriginalFieldSettings.ValueTypeName;
                txtInitialValue.Text = m_OriginalFieldSettings.InitialValue;
                txtMaximumValue.Text = m_OriginalFieldSettings.MaximumValue;
                txtIncrement.Text = m_OriginalFieldSettings.Increment;
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

            // InitialValue
            control = txtInitialValue;

            if (!ValidationUtility.ValidateRequiredText(control.Text, out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            if (!Context.CurrentExecutor.ValidateAsFieldValue(control.Text, cmbValueType.Text, out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            // MaximumValue
            control = txtMaximumValue;

            if (!ValidationUtility.ValidateRequiredText(control.Text, out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            if (!Context.CurrentExecutor.ValidateAsFieldValue(control.Text, cmbValueType.Text, out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            // Increment
            static bool IsDateTime(string typeName)
            {
                var type = Type.GetType(typeName);

                return (type == typeof(DateTime) || type == typeof(DateTimeOffset));
            }

            control = txtIncrement;

            if (IsDateTime(cmbValueType.Text))
            {
                if (!Context.CurrentExecutor.ValidateAsFieldValue(control.Text, typeof(TimeSpan).FullName, out _))
                {
                    if (!Context.CurrentExecutor.ValidateAsFieldValue(control.Text, typeof(int).FullName, out invalidMessage))
                    {
                        invalidControl = control;
                        return false;
                    }
                }
            }
            else
            {
                if (!Context.CurrentExecutor.ValidateAsFieldValue(control.Text, cmbValueType.Text, out invalidMessage))
                {
                    invalidControl = control;
                    return false;
                }
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
            SequenceFieldSettings fieldSettings = m_OriginalFieldSettings ?? new SequenceFieldSettings();

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
            SequenceFieldSettings fieldSettings = new();

            UpdateFieldSettings(fieldSettings);

            return fieldSettings;
        }

        /// <summary>
        /// Applies the input value to the specified field.
        /// </summary>
        /// <param name="fieldSettings"></param>
        private void UpdateFieldSettings(SequenceFieldSettings fieldSettings)
        {
            fieldSettings.ValueTypeName = cmbValueType.Text;
            fieldSettings.NullProbability = FormUtility.ParseToDouble(txtNullProbability).GetValueOrDefault();
            fieldSettings.InitialValue = txtInitialValue.Text;
            fieldSettings.MaximumValue = txtMaximumValue.Text;
            fieldSettings.Increment = txtIncrement.Text;
        }

        #endregion

    }
}
