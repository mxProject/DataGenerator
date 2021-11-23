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
using mxProject.Devs.DataGeneration.Configuration.AdditionalFields;

using mxProject.Tools.DataFountain.Messaging;
using mxProject.Tools.DataFountain.Models;

namespace mxProject.Tools.DataFountain.Forms.FieldEditors.AdditionalTupleFields
{

    /// <summary>
    /// Editor for <see cref="JoinFieldSettings"/>.
    /// </summary>
    internal partial class JoinFieldEditor : AdditionalTupleFieldEditorBase
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="context"></param>
        internal JoinFieldEditor(DataFountainContext context) : base(context)
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

        private DataGridViewDropDownComboBoxHelper m_KeyValueTypeComboBox = null!;
        private DataGridViewDropDownComboBoxHelper m_AdditionalValueTypeComboBox = null!;

        /// <summary>
        /// Initializes fields.
        /// </summary>
        private void InitFields()
        {
            m_KeyValueTypeComboBox = CreateValueTypeConboBoxHelper(grdKeyFields);
            m_AdditionalValueTypeComboBox = CreateValueTypeConboBoxHelper(grdAdditionalFields);

            InitFields(grdKeyFields, true);
            InitFields(grdAdditionalFields, false);
        }

        /// <summary>
        /// Creates a valueType comboobox helder.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private DataGridViewDropDownComboBoxHelper CreateValueTypeConboBoxHelper(DataGridView grid)
        {
            var helper = new DataGridViewDropDownComboBoxHelper(grid, (int)FieldGridColumn.ValueType);

            helper.AddItemsIfNotExists(Context.GetSupportedValueTypes(DataGeneratorFieldType.Each).Select(x => x.FullName));

            return helper;
        }

        /// <summary>
        /// Initializes value types.
        /// </summary>
        private void InitFields(DataGridView grid, bool isKeyField)
        {

            grid.UserAddedRow += (sender, e) =>
            {
                var field = new DataGeneratorFieldInfo()
                {
                    FieldName = grid[(int)FieldGridColumn.FieldName, e.Row.Index].Value?.ToString(),
                    ValueType = grid[(int)FieldGridColumn.ValueType, e.Row.Index].Value?.ToString()
                };

                int keyCount = m_EdittingState.GetKeyFieldCount();

                if (isKeyField && keyCount != m_EdittingState.GetAllFieldCount())
                {
                    m_EdittingState.Fields.Insert(keyCount, new EdittingField(field, isKeyField));

                    if (grdValues.Columns.Count < m_EdittingState.Fields.Count)
                    {
                        DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn() { HeaderText = field.FieldName };
                        grdValues.Columns.Insert(keyCount, column);
                    }
                }
                else
                {
                    m_EdittingState.Fields.Add(new EdittingField(field, isKeyField));

                    if (grdValues.Columns.Count < m_EdittingState.Fields.Count)
                    {
                        grdValues.Columns.Add(null, field.FieldName);
                    }
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
                if (((DataGridView)sender).NewRowIndex == e.RowIndex) { return; }

                int r = isKeyField ? e.RowIndex : e.RowIndex + m_EdittingState.GetKeyFieldCount();

                if (r < m_EdittingState.Fields.Count)
                {
                    switch ((FieldGridColumn)e.ColumnIndex)
                    {
                        case FieldGridColumn.FieldName:
                            e.Value = m_EdittingState.Fields[r].Info.FieldName;
                            break;

                        case FieldGridColumn.ValueType:
                            e.Value = m_EdittingState.Fields[r].Info.ValueType;
                            break;
                    }
                }
            };

            grid.CellValuePushed += (sender, e) =>
            {
                int r = isKeyField ? e.RowIndex : e.RowIndex + m_EdittingState.GetKeyFieldCount();

                if (r < m_EdittingState.Fields.Count)
                {
                    switch ((FieldGridColumn)e.ColumnIndex)
                    {
                        case FieldGridColumn.FieldName:
                            m_EdittingState.Fields[r].Info.FieldName = e.Value?.ToString();
                            grdValues.Columns[r].HeaderText = e.Value?.ToString() ?? "";
                            break;

                        case FieldGridColumn.ValueType:
                            m_EdittingState.Fields[r].Info.ValueType = e.Value?.ToString();
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

        private JoinFieldSettings? m_OriginalFieldSettings;

        private readonly EdittingState m_EdittingState = new EdittingState();

        private class EdittingState
        {

            internal readonly List<EdittingField> Fields = new();

            internal int GetAllFieldCount()
            {
                return Fields.Count;
            }

            internal int GetKeyFieldCount()
            {
                return Fields.Where(x => x.IsKey).Count();
            }

            internal int GetAdditionalFieldCount()
            {
                return Fields.Where(x => !x.IsKey).Count();
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

            internal DataGeneratorFieldInfo[] GetKeyFields()
            {
                return Fields.Where(x => x.IsKey).Select(x => x.Info).ToArray();
            }

            internal DataGeneratorFieldInfo[] GetAdditionalFields()
            {
                return Fields.Where(x => !x.IsKey).Select(x => x.Info).ToArray();
            }

            internal Dictionary<string?[], string?[]>? GetAdditionalValues()
            {
                if (Fields.Count == 0) { return null; }

                var keyFields = Fields.Where(x => x.IsKey).ToArray();
                var valueFields = Fields.Where(x => !x.IsKey).ToArray();

                Dictionary<string?[], string?[]> dic = new();

                for (int r = 0; r < GetMaxValueCount(); ++r)
                {
                    var keys = new string?[keyFields.Length];

                    for (int i = 0; i < keyFields.Length; ++i)
                    {
                        if (r < keyFields[i].Values.Count)
                        {
                            keys[i] = keyFields[i].Values[r];
                        }
                    }

                    var values = new string?[valueFields.Length];

                    for (int i = 0; i < valueFields.Length; ++i)
                    {
                        if (r < valueFields[i].Values.Count)
                        {
                            values[i] = valueFields[i].Values[r];
                        }
                    }

                    dic.Add(keys, values);
                }

                return dic;
            }
        }

        private class EdittingField
        {
            internal static IEnumerable<EdittingField> FromFieldSettings(JoinFieldSettings? fieldSettings)
            {

                var keyFields = new List<EdittingField>();

                if (fieldSettings?.KeyFields != null)
                {
                    for (int i = 0; i < fieldSettings.KeyFields.Length; ++i)
                    {
                        keyFields.Add(new EdittingField((DataGeneratorFieldInfo)fieldSettings.KeyFields[i].Clone(), true));
                    }
                }

                var additionalFields = new List<EdittingField>();

                if (fieldSettings?.AdditionalFields != null)
                {
                    for (int i = 0; i < fieldSettings.AdditionalFields.Length; ++i)
                    {
                        additionalFields.Add(new EdittingField((DataGeneratorFieldInfo)fieldSettings.AdditionalFields[i].Clone(), false));
                    }
                }

                if (fieldSettings?.AdditionalValues != null)
                {
                    foreach (var pair in fieldSettings.AdditionalValues)
                    {
                        for (int i = 0; i < keyFields.Count; ++i)
                        {
                            if (pair.Key != null && i < pair.Key.Length)
                            {
                                keyFields[i].Values.Add(pair.Key[i]);
                            }
                            else
                            {
                                keyFields[i].Values.Add(null);
                            }
                        }

                        for (int i = 0; i < additionalFields.Count; ++i)
                        {
                            if (pair.Value != null && i < pair.Value.Length)
                            {
                                additionalFields[i].Values.Add(pair.Value[i]);
                            }
                            else
                            {
                                additionalFields[i].Values.Add(null);
                            }
                        }
                    }
                }

                foreach (var field in keyFields)
                {
                    yield return field;
                }

                foreach (var field in additionalFields)
                {
                    yield return field;
                }

            }

            internal EdittingField(DataGeneratorFieldInfo info, bool isKey)
            {
                IsKey = isKey;
                Info = info;
                Values = new List<string?>();
            }

            internal bool IsKey { get; }

            internal DataGeneratorFieldInfo Info { get; }
            internal List<string?> Values { get; }
        }

        /// <inheritdoc/>
        protected override void SetFieldSettings(DataGeneratorAdditionalTupleFieldSettingsState? fieldSettings)
        {
            base.SetFieldSettings(fieldSettings);

            m_OriginalFieldSettings = fieldSettings?.Settings as JoinFieldSettings;

            m_EdittingState.Fields.Clear();
            m_EdittingState.Fields.AddRange(EdittingField.FromFieldSettings(m_OriginalFieldSettings));

            m_KeyValueTypeComboBox.AddItemsIfNotExists(m_EdittingState.GetValueTypes());
            m_AdditionalValueTypeComboBox.AddItemsIfNotExists(m_EdittingState.GetValueTypes());

            grdValues.Columns.Clear();

            foreach (var field in m_EdittingState.Fields)
            {
                grdValues.Columns.Add(field.Info.FieldName, field.Info.FieldName);
            }

            grdKeyFields.RowCount = m_EdittingState.GetKeyFieldCount() + 1;
            grdAdditionalFields.RowCount = m_EdittingState.GetAdditionalFieldCount() + 1;
            grdValues.RowCount = m_EdittingState.GetMaxValueCount() + 1;

        }

        #endregion

        #region validation

        /// <inheritdoc/>
        protected override bool ValidateInputValues(out string? invalidMessage, out Control? invalidControl)
        {
            grdKeyFields.ClearCellErrorText();
            grdAdditionalFields.ClearCellErrorText();
            grdValues.ClearCellErrorText();

            if (!base.ValidateInputValues(out invalidMessage, out invalidControl)) { return false; }

            Control control;
            DataGridView grid;

            // key fields
            control = grdKeyFields;
            grid = grdKeyFields;

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

            // additional fields
            control = grdAdditionalFields;
            grid = grdAdditionalFields;

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
        protected override DataGeneratorAdditionalTupleFieldSettingsState GetUpdatedFieldSettings(DataGeneratorAdditionalTupleFieldSettingsState? currentState)
        {
            JoinFieldSettings fieldSettings = m_OriginalFieldSettings ?? new JoinFieldSettings();

            UpdateFieldSettings(fieldSettings);

            if (currentState == null)
            {
                return new DataGeneratorAdditionalTupleFieldSettingsState(fieldSettings);
            }
            else
            {
                currentState.SetSettings(fieldSettings);
                return currentState;
            }
        }

        /// <inheritdoc/>
        protected override DataGeneratorAdditionalTupleFieldSettings GetFieldSettingsAsNew()
        {
            JoinFieldSettings fieldSettings = new();

            UpdateFieldSettings(fieldSettings);

            return fieldSettings;
        }

        /// <summary>
        /// Applies the input value to the specified field.
        /// </summary>
        /// <param name="fieldSettings"></param>
        private void UpdateFieldSettings(JoinFieldSettings fieldSettings)
        {
            fieldSettings.KeyFields = m_EdittingState.GetKeyFields();
            fieldSettings.AdditionalFields = m_EdittingState.GetAdditionalFields();
            fieldSettings.AdditionalValues = m_EdittingState.GetAdditionalValues();
        }

        #endregion

    }
}
