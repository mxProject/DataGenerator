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
    /// Editor for <see cref="JoinDbQueryFieldSettings"/>.
    /// </summary>
    internal partial class JoinDbQueryFieldEditor : AdditionalTupleFieldEditorBase
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="context"></param>
        internal JoinDbQueryFieldEditor(DataFountainContext context) : base(context)
        {
            InitializeComponent();

            InitKeyFields();
            InitAdditionalFields();
        }

        #region key fields

        private enum KeyFieldGridColumn
        {
            ReferenceKeyName = 0,
            AdditionalKeyName = 1
        }

        /// <summary>
        /// Initializes key fields.
        /// </summary>
        private void InitKeyFields()
        {
            var grid = grdKeyFields;

            grid.UserAddedRow += (sender, e) =>
            {
                var referenceKey = grid[(int)KeyFieldGridColumn.ReferenceKeyName, e.Row.Index].Value?.ToString();
                var additionalKey = grid[(int)KeyFieldGridColumn.AdditionalKeyName, e.Row.Index].Value?.ToString();

                m_EdittingState.KeyFields.Add(new EdittingField(referenceKey, additionalKey));
            };

            UserDeleteRowState deletingRow = new(); 

            grid.UserDeletingRow += (sender, e) =>
            {
                deletingRow.RowIndex = e.Row.Index;
            };

            grid.UserDeletedRow += (sender, e) =>
            {
                if ( 0 <= deletingRow.RowIndex && deletingRow.RowIndex < m_EdittingState.KeyFields.Count)
                {
                    m_EdittingState.KeyFields.RemoveAt(deletingRow.RowIndex);
                }
            };

            grid.CellValueNeeded += (sender, e) =>
            {
                if (((DataGridView)sender).NewRowIndex == e.RowIndex) { return; }

                if (e.RowIndex < m_EdittingState.KeyFields.Count)
                {
                    switch ((KeyFieldGridColumn)e.ColumnIndex)
                    {
                        case KeyFieldGridColumn.ReferenceKeyName:
                            e.Value = m_EdittingState.KeyFields[e.RowIndex].ReferenceKeyName;
                            break;

                        case KeyFieldGridColumn.AdditionalKeyName:
                            e.Value = m_EdittingState.KeyFields[e.RowIndex].AdditionalKeyName;
                            break;
                    }
                }
            };

            grid.CellValuePushed += (sender, e) =>
            {
                if (e.RowIndex < m_EdittingState.KeyFields.Count)
                {
                    switch ((KeyFieldGridColumn)e.ColumnIndex)
                    {
                        case KeyFieldGridColumn.ReferenceKeyName:
                            m_EdittingState.KeyFields[e.RowIndex].ReferenceKeyName = e.Value?.ToString();
                            break;

                        case KeyFieldGridColumn.AdditionalKeyName:
                            m_EdittingState.KeyFields[e.RowIndex].AdditionalKeyName = e.Value?.ToString();
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

        #region additional fields

        private enum AdditionalFieldGridColumn
        {
            FieldName = 0,
        }

        /// <summary>
        /// Initializes additional fields.
        /// </summary>
        private void InitAdditionalFields()
        {
            var grid = grdAdditionalFields;

            grid.UserAddedRow += (sender, e) =>
            {
                m_EdittingState.AdditionalValueFieldNames.Add(null!);
            };

            UserDeleteRowState deletingRow = new();

            grid.UserDeletingRow += (sender, e) =>
            {
                deletingRow.RowIndex = e.Row.Index;
            };

            grid.UserDeletedRow += (sender, e) =>
            {
                if (0 <= deletingRow.RowIndex && deletingRow.RowIndex < m_EdittingState.AdditionalValueFieldNames.Count)
                {
                    m_EdittingState.AdditionalValueFieldNames.RemoveAt(deletingRow.RowIndex);
                }
            };

            grid.CellValueNeeded += (sender, e) =>
            {
                if (((DataGridView)sender).NewRowIndex == e.RowIndex) { return; }

                if (e.RowIndex < m_EdittingState.AdditionalValueFieldNames.Count)
                {
                    switch ((AdditionalFieldGridColumn)e.ColumnIndex)
                    {
                        case AdditionalFieldGridColumn.FieldName:
                            e.Value = m_EdittingState.AdditionalValueFieldNames[e.RowIndex];
                            break;
                    }
                }
            };

            grid.CellValuePushed += (sender, e) =>
            {
                if (e.RowIndex < m_EdittingState.AdditionalValueFieldNames.Count)
                {
                    switch ((AdditionalFieldGridColumn)e.ColumnIndex)
                    {
                        case AdditionalFieldGridColumn.FieldName:
                            m_EdittingState.AdditionalValueFieldNames[e.RowIndex] = e.Value?.ToString()!;
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

        #region start editting

        private JoinDbQueryFieldSettings? m_OriginalFieldSettings;

        private readonly EdittingState m_EdittingState = new EdittingState();

        private class EdittingState
        {

            internal readonly List<EdittingField> KeyFields = new();

            internal readonly List<string> AdditionalValueFieldNames = new();

            internal string[] GetReferenceKeyFieldNames()
            {
                return KeyFields.Select(x => x.ReferenceKeyName ?? "").ToArray();
            }

            internal string[] GetAdditionalKeyFieldNames()
            {
                return KeyFields.Select(x => x.AdditionalKeyName ?? "").ToArray();
            }

            internal DbQuerySettings DbQuery { get; set; } = null!;

            internal void SetDbQuery(DbQuerySettings? dbQuery)
            {
                DbQuery = ((DbQuerySettings)dbQuery?.Clone()!) ?? new DbQuerySettings();
            }
        }

        private class EdittingField
        {
            internal static IEnumerable<EdittingField> FromFieldSettings(JoinDbQueryFieldSettings? fieldSettings)
            {

                var keyFields = new List<EdittingField>();

                static int GetKeyFieldCount(JoinDbQueryFieldSettings? fieldSettings)
                {
                    if (fieldSettings == null) { return 0; }

                    int? referenceKeys = fieldSettings.ReferenceKeyFieldNames?.Length;
                    int? additionalKeys = fieldSettings.AdditionalKeyFieldNames?.Length;

                    return Math.Max(referenceKeys.GetValueOrDefault(), additionalKeys.GetValueOrDefault());
                }

                static string? GetKeyFieldName(string?[]? fieldNames, int index)
                {
                    if (fieldNames == null) { return null; }
                    if (fieldNames.Length <= index) { return null; }
                    return fieldNames[index];
                }

                for (int i = 0; i < GetKeyFieldCount(fieldSettings) ; ++i)
                {
                    keyFields.Add(new EdittingField(GetKeyFieldName(fieldSettings?.ReferenceKeyFieldNames, i), GetKeyFieldName(fieldSettings?.AdditionalKeyFieldNames, i)));
                }

                return keyFields;

            }

            internal EdittingField(string? referenceKeyName, string? additionalKeyName)
            {
                ReferenceKeyName = referenceKeyName;
                AdditionalKeyName = additionalKeyName;
            }

            internal string? ReferenceKeyName { get; set; }
            internal string? AdditionalKeyName { get; set; }

        }

        /// <inheritdoc/>
        protected override void SetFieldSettings(DataGeneratorAdditionalTupleFieldSettingsState? fieldSettings)
        {
            base.SetFieldSettings(fieldSettings);

            m_OriginalFieldSettings = fieldSettings?.Settings as JoinDbQueryFieldSettings;

            m_EdittingState.KeyFields.Clear();
            m_EdittingState.KeyFields.AddRange(EdittingField.FromFieldSettings(m_OriginalFieldSettings));

            m_EdittingState.AdditionalValueFieldNames.Clear();
            m_EdittingState.AdditionalValueFieldNames.AddRange(m_OriginalFieldSettings?.AdditionalValueFieldNames ?? Array.Empty<string>());

            m_EdittingState.SetDbQuery(m_OriginalFieldSettings?.DbQuerySettings);

            grdKeyFields.RowCount = m_EdittingState.KeyFields.Count + 1;
            grdAdditionalFields.RowCount = m_EdittingState.AdditionalValueFieldNames.Count + 1;
            dbQueryEditor.SetDbQuerySettings(m_EdittingState.DbQuery);
        }

        #endregion

        #region validation

        /// <inheritdoc/>
        protected override bool ValidateInputValues(out string? invalidMessage, out Control? invalidControl)
        {
            grdKeyFields.ClearCellErrorText();
            grdAdditionalFields.ClearCellErrorText();

            if (!base.ValidateInputValues(out invalidMessage, out invalidControl)) { return false; }

            Control control;
            DataGridView grid;

            // KeyFields
            control = grdKeyFields;
            grid = grdKeyFields;

            if (!grid.ValidateEnteredRows(out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            if (!grid.ValidateColumnValuesIsUnique((int)KeyFieldGridColumn.ReferenceKeyName, false, out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            if (!grid.ValidateColumnValuesIsUnique((int)KeyFieldGridColumn.AdditionalKeyName, false, out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            // AdditionalFields
            control = grdAdditionalFields;
            grid = grdAdditionalFields;

            if (!grid.ValidateEnteredRows(out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            if (!grid.ValidateColumnValuesIsUnique((int)AdditionalFieldGridColumn.FieldName, false, out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            // dbQuery
            if (!dbQueryEditor.ValidateInputValues(out invalidMessage, out invalidControl))
            {
                return false;
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
            JoinDbQueryFieldSettings fieldSettings = m_OriginalFieldSettings ?? new JoinDbQueryFieldSettings();

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
            JoinDbQueryFieldSettings fieldSettings = new();

            UpdateFieldSettings(fieldSettings);

            return fieldSettings;
        }

        /// <summary>
        /// Applies the input value to the specified field.
        /// </summary>
        /// <param name="fieldSettings"></param>
        private void UpdateFieldSettings(JoinDbQueryFieldSettings fieldSettings)
        {
            dbQueryEditor.UpdateDbQuerySettings(m_EdittingState.DbQuery);

            fieldSettings.ReferenceKeyFieldNames = m_EdittingState.GetReferenceKeyFieldNames();
            fieldSettings.AdditionalKeyFieldNames = m_EdittingState.GetAdditionalKeyFieldNames();
            fieldSettings.AdditionalValueFieldNames = m_EdittingState.AdditionalValueFieldNames.ToArray();
            fieldSettings.DbQuerySettings = (DbQuerySettings)m_EdittingState.DbQuery.Clone();
        }

        #endregion

    }
}
