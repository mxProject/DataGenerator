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

namespace mxProject.Tools.DataFountain.Forms.FieldEditors.Fields
{

    /// <summary>
    /// Editor for <see cref="DbQueryFieldSettings"/>.
    /// </summary>
    internal partial class DbQueryFieldEditor : FieldEditorBase
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="context"></param>
        internal DbQueryFieldEditor(DataFountainContext context) : base(context)
        {
            InitializeComponent();
        }

        #region start editting

        private DbQueryFieldSettings? m_OriginalFieldSettings;

        private readonly EdittingState m_EdittingState = new EdittingState();

        private class EdittingState
        {
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
        protected override void SetFieldSettings(DataGeneratorFieldSettingsState? fieldSettings)
        {
            base.SetFieldSettings(fieldSettings);

            m_OriginalFieldSettings = fieldSettings?.Settings as DbQueryFieldSettings;
            
            m_EdittingState.SetDbQuery(m_OriginalFieldSettings?.DbQuerySettings);

            dbQueryEditor.SetDbQuerySettings(m_EdittingState.DbQuery);
        }

        #endregion

        #region validation

        /// <inheritdoc/>
        protected override bool ValidateInputValues(out string? invalidMessage, out Control? invalidControl)
        {
            if (!base.ValidateInputValues(out invalidMessage, out invalidControl)) { return false; }

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
        protected override DataGeneratorFieldSettingsState GetUpdatedFieldSettings(DataGeneratorFieldSettingsState? currentState)
        {
            DbQueryFieldSettings fieldSettings = m_OriginalFieldSettings ?? new DbQueryFieldSettings();

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
            DbQueryFieldSettings fieldSettings = new();

            UpdateFieldSettings(fieldSettings);

            return fieldSettings;
        }

        /// <summary>
        /// Applies the input value to the specified field.
        /// </summary>
        /// <param name="fieldSettings"></param>
        private void UpdateFieldSettings(DbQueryFieldSettings fieldSettings)
        {
            dbQueryEditor.UpdateDbQuerySettings(m_EdittingState.DbQuery);

            fieldSettings.DbQuerySettings = (DbQuerySettings)m_EdittingState.DbQuery.Clone();
        }

        #endregion

    }
}
