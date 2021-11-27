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
    /// Editor for <see cref="ComputingFieldSettings"/>.
    /// </summary>
    internal partial class ComputingFieldEditor : FieldEditorBase
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="context"></param>
        internal ComputingFieldEditor(DataFountainContext context) : base(context)
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
            foreach (var type in Context.GetSupportedValueTypes(DataGeneratorFieldType.Expression))
            {
                cmbValueType.Items.Add(type.FullName);
            }
        }

        #endregion

        #region start editting

        private ComputingFieldSettings? m_OriginalFieldSettings;

        /// <inheritdoc/>
        protected override void SetFieldSettings(DataGeneratorFieldSettingsState? field)
        {
            base.SetFieldSettings(field);

            m_OriginalFieldSettings = field?.Settings as ComputingFieldSettings;
            
            if (m_OriginalFieldSettings == null)
            {
                txtExpression.Text = null;
                cmbValueType.Text = null;
            }
            else
            {
                txtExpression.Text = m_OriginalFieldSettings.Expression;
                cmbValueType.Text = m_OriginalFieldSettings.ValueTypeName;
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

            // Expression
            control = txtExpression;

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
            ComputingFieldSettings fieldSettings = m_OriginalFieldSettings ?? new ComputingFieldSettings();

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
            ComputingFieldSettings fieldSettings = new();

            UpdateFieldSettings(fieldSettings);

            return fieldSettings;
        }

        /// <summary>
        /// Applies the input value to the specified field.
        /// </summary>
        /// <param name="fieldSettings"></param>
        private void UpdateFieldSettings(ComputingFieldSettings fieldSettings)
        {
            fieldSettings.ValueTypeName = cmbValueType.Text;
            fieldSettings.Expression = txtExpression.Text;
        }

        #endregion

    }
}
