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
    /// Editor for <see cref="EachFieldSettings"/>.
    /// </summary>
    internal partial class EachFieldEditor : FieldEditorBase
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="context"></param>
        internal EachFieldEditor(DataFountainContext context) : base(context)
        {
            InitializeComponent();

            InitValueTypes();
            InitValueGrid();
        }

        #region value types

        /// <summary>
        /// Initializes value types.
        /// </summary>
        private void InitValueTypes()
        {
            foreach (var type in Context.GetSupportedValueTypes(DataGeneratorFieldType.Each))
            {
                cmbValueType.Items.Add(type.FullName);
            }
        }

        #endregion

        #region values grid

        /// <summary>
        /// Initializes the values grid.
        /// </summary>
        private void InitValueGrid()
        {
            var grid = grdValues;

            UserDeleteRowState detetingState = new();

            grid.UserAddedRow += (sender, e) =>
            {
                m_EdittingState.Values.Add(null);
            };

            grid.UserDeletingRow += (sender, e) =>
            {
                detetingState.RowIndex = e.Row.Index;
            };

            grid.UserDeletedRow += (sender, e) =>
            {
                if (detetingState.RowIndex < m_EdittingState.Values.Count)
                {
                    m_EdittingState.Values.RemoveAt(detetingState.RowIndex);
                }
            };

            grid.CellValueNeeded += (sender, e) =>
            {
                if (e.ColumnIndex == 0 && e.RowIndex < m_EdittingState.Values.Count)
                {
                    e.Value = m_EdittingState.Values[e.RowIndex];
                }
            };

            grid.CellValuePushed += (sender, e) =>
            {
                if (e.ColumnIndex == 0 && e.RowIndex < m_EdittingState.Values.Count)
                {
                    m_EdittingState.Values[e.RowIndex] = e.Value?.ToString();
                }
            };

            grid.AllowUserToAddRows = true;
            grid.AllowUserToDeleteRows = true;
            grid.RowCount = 1;
            grid.VirtualMode = true;
        }

        #endregion

        #region start editting

        private EachFieldSettings? m_OriginalFieldSettings;

        private readonly EdittingState m_EdittingState = new EdittingState();

        private class EdittingState
        {
            internal readonly List<string?> Values = new();

            internal string?[]? GetFieldValues()
            {
                if (Values.Count == 0) { return null; }

                return Values.ToArray();
            }

            internal int GetValueGridRowCount()
            {
                return Values.Count + 1;
            }
        }

        /// <inheritdoc/>
        protected override void SetFieldSettings(DataGeneratorFieldSettingsState? field)
        {
            base.SetFieldSettings(field);

            m_OriginalFieldSettings = field?.Settings as EachFieldSettings;

            m_EdittingState.Values.Clear();

            if (m_OriginalFieldSettings?.Values != null)
            {
                m_EdittingState.Values.AddRange(m_OriginalFieldSettings.Values);
            }

            if (m_OriginalFieldSettings == null)
            {
                txtNullProbability.Text = null;
                cmbValueType.Text = null;
            }
            else
            {
                txtNullProbability.Text = m_OriginalFieldSettings.NullProbability.ToString();
                cmbValueType.Text = m_OriginalFieldSettings.ValueTypeName;
            }

            grdValues.RowCount = m_EdittingState.GetValueGridRowCount();
            grdValues.Invalidate();
        }

        #endregion

        #region validation

        /// <inheritdoc/>
        protected override bool ValidateInputValues(out string? invalidMessage, out Control? invalidControl)
        {
            grdValues.ClearCellErrorText();

            if (!base.ValidateInputValues(out invalidMessage, out invalidControl)) { return false; }

            Control control;
            DataGridView grid;

            // ValueType
            control = cmbValueType;

            if (!Context.CurrentExecutor.ValidateAsValueTypeName(control.Text, out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            bool isEnumType = Context.CurrentExecutor.IsEnumType(control.Text);

            // NullProbability
            control = txtNullProbability;

            if (!ValidationUtility.ValidateAsDoubleText(control.Text, 0, 1, out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            // Values
            control = grdValues;
            grid = grdValues;

            if (!isEnumType && !grid.ValidateEnteredRows(out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            if (!grid.ValidateAsFieldValue(0, cmbValueType.Text, Context.CurrentExecutor, out invalidMessage))
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
            EachFieldSettings fieldSettings = m_OriginalFieldSettings ?? new EachFieldSettings();

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
            EachFieldSettings fieldSettings = new();

            UpdateFieldSettings(fieldSettings);

            return fieldSettings;
        }

        /// <summary>
        /// Applies the input value to the specified field.
        /// </summary>
        /// <param name="fieldSettings"></param>
        private void UpdateFieldSettings(EachFieldSettings fieldSettings)
        {
            fieldSettings.ValueTypeName = cmbValueType.Text;
            fieldSettings.NullProbability = FormUtility.ParseToDouble(txtNullProbability).GetValueOrDefault();
            fieldSettings.Values = m_EdittingState.GetFieldValues();
        }

        #endregion

    }
}
