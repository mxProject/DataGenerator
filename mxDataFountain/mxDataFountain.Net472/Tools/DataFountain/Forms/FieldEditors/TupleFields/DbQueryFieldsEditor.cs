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
    /// Editor for <see cref="DbQueryFieldSettings"/>.
    /// </summary>
    internal partial class DbQueryFieldsEditor : TupleFieldEditorBase
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="context"></param>
        internal DbQueryFieldsEditor(DataFountainContext context) : base(context)
        {
            InitializeComponent();

            InitValueTypes();
        }

        #region value types

        private enum ValueTypeGridColumn
        {
            FieldName = 0,
        }

        /// <summary>
        /// Initializes value types.
        /// </summary>
        private void InitValueTypes()
        {

            var grid = grdFields;

            grid.UserAddedRow += (sender, e) =>
            {
                string? fieldName = grid[(int)ValueTypeGridColumn.FieldName, e.Row.Index].Value?.ToString();

                m_EdittingState.Fields.Add(fieldName!);
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
                }
            };

            grid.CellValueNeeded += (sender, e) =>
            {
                if (e.RowIndex < m_EdittingState.Fields.Count)
                {
                    switch ((ValueTypeGridColumn)e.ColumnIndex)
                    {
                        case ValueTypeGridColumn.FieldName:
                            e.Value = m_EdittingState.Fields[e.RowIndex];
                            break;
                    }
                }
            };

            grid.CellValuePushed += (sender, e) =>
            {
                if (e.RowIndex < m_EdittingState.Fields.Count)
                {
                    switch ((ValueTypeGridColumn)e.ColumnIndex)
                    {
                        case ValueTypeGridColumn.FieldName:
                            m_EdittingState.Fields[e.RowIndex] = e.Value?.ToString()!;
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

        private DbQueryFieldsSettings? m_OriginalFieldSettings;

        private readonly EdittingState m_EdittingState = new EdittingState();

        private class EdittingState
        {

            internal readonly List<string> Fields = new();

            internal int GetFieldCount()
            {
                return Fields.Count;
            }

            internal string[] GetFields()
            {
                return Fields.ToArray();
            }

            internal DbQuerySettings DbQuery { get; set; } = null!;

            internal void SetDbQuery(DbQuerySettings? dbQuery)
            {
                DbQuery = ((DbQuerySettings)dbQuery?.Clone()!) ?? new DbQuerySettings();
            }

        }

        /// <summary>
        /// Sets the specified field for editing.
        /// </summary>
        /// <param name="fieldSettings"></param>
        protected override void SetFieldSettings(DataGeneratorTupleFieldSettingsState? fieldSettings)
        {
            base.SetFieldSettings(fieldSettings);

            m_OriginalFieldSettings = fieldSettings?.Settings as DbQueryFieldsSettings;
            
            m_EdittingState.Fields.Clear();
            m_EdittingState.Fields.AddRange(m_OriginalFieldSettings?.FieldNames ?? Array.Empty<string>());
            m_EdittingState.SetDbQuery(m_OriginalFieldSettings?.DbQuerySettings);

            grdFields.RowCount = m_EdittingState.GetFieldCount() + 1;
            grdFields.Invalidate();

            dbQueryEditor.SetDbQuerySettings(m_EdittingState.DbQuery);
        }

        #endregion

        #region validation

        /// <inheritdoc/>
        protected override bool ValidateInputValues(out string? invalidMessage, out Control? invalidControl)
        {
            grdFields.ClearCellErrorText();

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

            if (!grid.ValidateColumnValuesIsUnique((int)ValueTypeGridColumn.FieldName, false, out invalidMessage))
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
        protected override DataGeneratorTupleFieldSettingsState GetUpdatedFieldSettings(DataGeneratorTupleFieldSettingsState? currentState)
        {
            DbQueryFieldsSettings fieldSettings = m_OriginalFieldSettings ?? new DbQueryFieldsSettings();

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
            DbQueryFieldsSettings fieldSettings = new();

            UpdateFieldSettings(fieldSettings);

            return fieldSettings;
        }

        /// <summary>
        /// Applies the input value to the specified field.
        /// </summary>
        /// <param name="fieldSettings"></param>
        private void UpdateFieldSettings(DbQueryFieldsSettings fieldSettings)
        {
            fieldSettings.FieldNames = m_EdittingState.GetFields();

            dbQueryEditor.UpdateDbQuerySettings(m_EdittingState.DbQuery);

            fieldSettings.DbQuerySettings = (DbQuerySettings)m_EdittingState.DbQuery.Clone();
        }

        #endregion

    }
}
