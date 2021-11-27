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
    /// Editor for <see cref="EachTupleFieldSettings"/>.
    /// </summary>
    internal partial class EachTupleFieldEditor : TupleFieldEditorBase
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="context"></param>
        internal EachTupleFieldEditor(DataFountainContext context) : base(context)
        {
            InitializeComponent();

            InitFields();
            InitValueGrid();
        }

        #region fields

        private enum FieldGridColumn
        {
            FieldName = 0,
            ValueType = 1
        }

        private DataGridViewDropDownComboBoxHelper m_ValueTypeComboBox = null!;

        /// <summary>
        /// Initializes fields.
        /// </summary>
        private void InitFields()
        {

            var grid = grdFields;

            m_ValueTypeComboBox = new DataGridViewDropDownComboBoxHelper(grid, (int)FieldGridColumn.ValueType);
            m_ValueTypeComboBox.AddItemsIfNotExists(Context.GetSupportedValueTypes(DataGeneratorFieldType.Each).Select(x => x.FullName));

            grid.UserAddedRow += (sender, e) =>
            {
                var field = new DataGeneratorFieldInfo()
                {
                    FieldName = grid[(int)FieldGridColumn.FieldName, e.Row.Index].Value?.ToString(),
                    ValueType = grid[(int)FieldGridColumn.ValueType, e.Row.Index].Value?.ToString()
                };

                m_EdittingState.Fields.Add(new EdittingField(field, null));

                if (grdValues.Columns.Count< m_EdittingState.Fields.Count)
                {
                    grdValues.Columns.Add(null, field.FieldName);
                }
            };

            UserDeleteRowState deletingRow = new(); 

            grid.UserDeletingRow += (sender, e) =>
            {
                deletingRow.RowIndex = e.Row.Index;
            };

            grid.UserDeletedRow += (sender, e) =>
            {
                if ( 0 <= deletingRow.RowIndex && deletingRow.RowIndex < m_EdittingState.Fields.Count)
                {
                    m_EdittingState.Fields.RemoveAt(deletingRow.RowIndex);

                    grdValues.Columns.RemoveAt(deletingRow.RowIndex);
                }
            };

            grid.CellValueNeeded += (sender, e) =>
            {
                if (e.RowIndex < m_EdittingState.Fields.Count)
                {
                    switch ((FieldGridColumn)e.ColumnIndex)
                    {
                        case FieldGridColumn.FieldName:
                            e.Value = m_EdittingState.Fields[e.RowIndex].Info.FieldName;
                            break;

                        case FieldGridColumn.ValueType:
                            e.Value = m_EdittingState.Fields[e.RowIndex].Info.ValueType;
                            break;
                    }
                }
            };

            grid.CellValuePushed += (sender, e) =>
            {
                if (e.RowIndex < m_EdittingState.Fields.Count)
                {
                    switch ((FieldGridColumn)e.ColumnIndex)
                    {
                        case FieldGridColumn.FieldName:
                            m_EdittingState.Fields[e.RowIndex].Info.FieldName = e.Value?.ToString();
                            grdValues.Columns[e.RowIndex].HeaderText = e.Value?.ToString() ?? "";
                            break;

                        case FieldGridColumn.ValueType:
                            m_EdittingState.Fields[e.RowIndex].Info.ValueType = e.Value?.ToString();
                            break;
                    }
                }
            };

            grid.AllowUserToAddRows = true;
            grid.AllowUserToDeleteRows = true;
            grid.RowCount = 1;
            grid.VirtualMode = true;

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

            grid.UserDeletingRow += (sender, e) =>
            {
                detetingState.RowIndex = e.Row.Index;
            };

            grid.UserDeletedRow += (sender, e) =>
            {
                foreach (var field in m_EdittingState.Fields)
                {
                    if (detetingState.RowIndex < field.Values.Count)
                    {
                        field.Values.RemoveAt(detetingState.RowIndex);
                    }
                }
            };

            grid.CellValueNeeded += (sender, e) =>
            {
                if (e.ColumnIndex < m_EdittingState.Fields.Count)
                {
                    if (e.RowIndex < m_EdittingState.Fields[e.ColumnIndex].Values.Count)
                    {
                        e.Value = m_EdittingState.Fields[e.ColumnIndex].Values[e.RowIndex];
                    }
                }
            };

            grid.CellValuePushed += (sender, e) =>
            {
                if (e.ColumnIndex < m_EdittingState.Fields.Count)
                {
                    for (int r = m_EdittingState.Fields[e.ColumnIndex].Values.Count; r <= e.RowIndex; ++r)
                    {
                        m_EdittingState.Fields[e.ColumnIndex].Values.Add(null);
                    }
                    m_EdittingState.Fields[e.ColumnIndex].Values[e.RowIndex] = e.Value?.ToString();
                }
            };

            grid.AllowUserToAddRows = true;
            grid.AllowUserToDeleteRows = true;
            grid.RowCount = 1;
            grid.VirtualMode = true;

        }

        #endregion

        #region start editting

        private EachTupleFieldSettings? m_OriginalFieldSettings;

        private readonly EdittingState m_EdittingState = new EdittingState();

        private class EdittingState
        {

            internal readonly List<EdittingField> Fields = new();

            internal int GetFieldCount()
            {
                return Fields.Count;
            }

            internal IEnumerable<string?> GetValueTypes()
            {
                foreach (var field in Fields)
                {
                    yield return field.Info.ValueType;
                }
            }

            internal int GetMaxValueCount()
            {
                int max = 0;

                foreach (var field in Fields)
                {
                    if (max < field.Values.Count)
                    {
                        max = field.Values.Count;
                    }
                }

                return max;
            }

            internal DataGeneratorFieldInfo[] GetFields()
            {
                return Fields.Select(x => x.Info).ToArray();
            }

            internal string?[][]? GetFieldValues()
            {
                if (Fields.Count == 0) { return null; }

                var array = new string?[GetMaxValueCount()][];

                for (int r = 0; r < array.Length; ++r)
                {
                    array[r] = new string?[Fields.Count];

                    for (int f = 0; f < Fields.Count; ++f)
                    {
                        array[r][f] = r < Fields[f].Values.Count ? Fields[f].Values[r] : null;
                    }
                }

                return array;
            }
        }

        private class EdittingField
        {
            internal static List<EdittingField> FromFieldSettings(EachTupleFieldSettings? fieldSettings)
            {

                var fields = new List<EdittingField>();

                if (fieldSettings?.Fields != null)
                {
                    for (int i = 0; i < fieldSettings.Fields.Length; ++i)
                    {
                        List<string?> values = new List<string?>();

                        if (fieldSettings.Values != null)
                        {
                            foreach (var value in fieldSettings.Values)
                            {
                                if (i < value.Length)
                                {
                                    values.Add(value[i]);
                                }
                                else
                                {
                                    values.Add(null);
                                }
                            }
                        }

                        fields.Add(new EdittingField((DataGeneratorFieldInfo)fieldSettings.Fields[i].Clone(), values));
                    }
                }

                return fields;

            }

            internal EdittingField(DataGeneratorFieldInfo info, IEnumerable<string?>? values)
            {
                Info = info;
                Values = new List<string?>(values ?? new string?[] { });
            }

            internal DataGeneratorFieldInfo Info { get; }
            internal List<string?> Values { get; }
        }

        /// <inheritdoc/>
        protected override void SetFieldSettings(DataGeneratorTupleFieldSettingsState? fieldSettings)
        {
            base.SetFieldSettings(fieldSettings);

            m_OriginalFieldSettings = fieldSettings?.Settings as EachTupleFieldSettings;

            m_EdittingState.Fields.Clear();
            m_EdittingState.Fields.AddRange(EdittingField.FromFieldSettings(m_OriginalFieldSettings));

            if (m_OriginalFieldSettings == null)
            {
                txtNullProbability.Text = null;
            }
            else
            {
                txtNullProbability.Text = m_OriginalFieldSettings.NullProbability.ToString();
            }

            m_ValueTypeComboBox.AddItemsIfNotExists(m_EdittingState.GetValueTypes());

            grdValues.Columns.Clear();

            foreach (var field in m_EdittingState.Fields)
            {
                grdValues.Columns.Add(field.Info.FieldName, field.Info.FieldName);
            }

            grdFields.RowCount = m_EdittingState.GetFieldCount() + 1;
            grdFields.Invalidate();

            grdValues.RowCount = m_EdittingState.GetMaxValueCount() + 1;
            grdValues.Invalidate();
        }

        #endregion

        #region validation

        /// <inheritdoc/>
        protected override bool ValidateInputValues(out string? invalidMessage, out Control? invalidControl)
        {
            grdFields.ClearCellErrorText();
            grdValues.ClearCellErrorText();

            if (!base.ValidateInputValues(out invalidMessage, out invalidControl)) { return false; }

            Control control;
            DataGridView grid;

            // Fields
            control = grdFields;
            grid = grdFields;

            grid.ClearCellErrorText();

            if (!grid.ValidateEnteredRows(out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            if (!grid.ValidateColumnValuesIsUnique((int)FieldGridColumn.FieldName, false, out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            if (!grid.ValidateAsFieldValueType((int)FieldGridColumn.ValueType, false, Context.CurrentExecutor, out invalidMessage))
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

            // Values
            control = grdValues;
            grid = grdValues;

            grid.ClearCellErrorText();

            if (!grid.ValidateEnteredRows(out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            for (int c = 0; c < grid.Columns.Count; ++c)
            {
                string? valueType = m_EdittingState.Fields[c].Info.ValueType;

                if (valueType != null)
                {
                    if (!grid.ValidateAsFieldValue(c, valueType, Context.CurrentExecutor, out invalidMessage))
                    {
                        invalidControl = control;
                        return false;
                    }
                }
            }

            invalidMessage = null;
            invalidControl = null;
            return true;
        }

        #endregion

        #region end of editting

        /// <inheritdoc/>
        protected override DataGeneratorTupleFieldSettingsState GetUpdatedFieldSettings(DataGeneratorTupleFieldSettingsState? currentState)
        {
            EachTupleFieldSettings fieldSettings = m_OriginalFieldSettings ?? new EachTupleFieldSettings();

            UpdateFieldSettings(fieldSettings);

            if (currentState == null)
            {
                return new DataGeneratorTupleFieldSettingsState(fieldSettings);
            }
            else
            {
                currentState.SetSettings(fieldSettings);
                return currentState;
            }
        }

        /// <inheritdoc/>
        protected override DataGeneratorTupleFieldSettings GetFieldSettingsAsNew()
        {
            EachTupleFieldSettings fieldSettings = new();

            UpdateFieldSettings(fieldSettings);

            return fieldSettings;
        }

        /// <summary>
        /// Applies the input value to the specified field.
        /// </summary>
        /// <param name="fieldSettings"></param>
        private void UpdateFieldSettings(EachTupleFieldSettings fieldSettings)
        {
            fieldSettings.NullProbability = FormUtility.ParseToDouble(txtNullProbability).GetValueOrDefault();
            fieldSettings.Fields = m_EdittingState.GetFields();
            fieldSettings.Values = m_EdittingState.GetFieldValues();
        }

        #endregion

    }
}
