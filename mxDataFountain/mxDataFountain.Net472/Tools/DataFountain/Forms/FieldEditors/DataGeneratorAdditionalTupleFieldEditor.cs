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
using mxProject.Tools.DataFountain.Messaging;
using mxProject.Tools.DataFountain.Models;
using mxProject.Tools.DataFountain.Forms.FieldEditors.AdditionalTupleFields;

namespace mxProject.Tools.DataFountain.Forms.FieldEditors
{

    /// <summary>
    /// Editor for <see cref="DataGeneratorAdditionalTupleFieldSettings"/>.
    /// </summary>
    internal partial class DataGeneratorAdditionalTupleFieldEditor : DataGeneratorFieldEditorBase, IDataGeneratorAdditionalTupleFieldEditor
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="context"></param>
        internal DataGeneratorAdditionalTupleFieldEditor(DataFountainContext context) : base(context)
        {
            InitializeComponent();

            Init();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Init()
        {
            Init(pnlBody);

            InitFieldType();

            btnApply.Click += (sender, e) =>
            {
                if (!ValidateInputValues()) { return; }

                if (m_FieldState.Settings == null)
                {
                    PublishAddedField(GetUpdatedFieldSettings());
                }
                else
                {
                    PublishUpdatedField(GetUpdatedFieldSettings());
                }
            };

            btnRemove.Click += (sender, e) =>
            {
                if (!ConfirmRemoveField()) { return; }

                PublishRemovedField(m_FieldState);
            };

            btnCancel.Click += (sender, e) =>
            {
                SetFieldSettings(m_FieldState);
            };
        }

        #region field type

        private DataGeneratorFieldTypeSelector<DataGeneratorAdditionalTupleFieldType, DataGeneratorAdditionalTupleFieldTypeBehavior, IDataGeneratorAdditionalTupleFieldEditor> m_FieldTypeSelector = null!;

        /// <summary>
        /// Initializes field types.
        /// </summary>
        private void InitFieldType()
        {
            void OnFieldTypeChanged(DataGeneratorAdditionalTupleFieldType fieldType)
            {
                if (cmbFieldType.Items.Contains(fieldType))
                {
                    cmbFieldType.SelectedItem = fieldType;
                }
                else
                {
                    cmbFieldType.SelectedIndex = -1;
                }
            }

            void OnEditorChanged(IDataGeneratorAdditionalTupleFieldEditor? editor)
            {
                if (editor is UserControl control)
                {
                    FieldEditorBody = control;
                }
                else
                {
                    FieldEditorBody = null;
                }

                editor?.SetFieldSettings(m_FieldState);
            }

            m_FieldTypeSelector = new(Context, OnFieldTypeChanged, OnEditorChanged);

            void AddFieldTypeBehavior(DataGeneratorAdditionalTupleFieldTypeBehavior behavior)
            {
                m_FieldTypeSelector.RegisterFieldType(behavior.FieldType, behavior);
            }

            AddFieldTypeBehavior(new DataGeneratorAdditionalTupleFieldTypeBehavior(DataGeneratorAdditionalTupleFieldType.Join, context => new JoinFieldEditor(context)));
            AddFieldTypeBehavior(new DataGeneratorAdditionalTupleFieldTypeBehavior(DataGeneratorAdditionalTupleFieldType.JoinDbQuery, context => new JoinDbQueryFieldEditor(context)));

            InitFieldTypeComboBox(cmbFieldType, m_FieldTypeSelector.GetFieldTypes(), item =>
            {
                if (item is DataGeneratorAdditionalTupleFieldType fieldType)
                {
                    m_FieldTypeSelector.SelectedFieldType = fieldType;
                }
                else
                {
                    m_FieldTypeSelector.SelectedFieldType = DataGeneratorAdditionalTupleFieldType.Unknown;
                }
            }
            );
        }

        #endregion

        #region field

        private DataGeneratorAdditionalTupleFieldSettingsState m_FieldState = null!;

        #endregion

        #region start editting

        /// <summary>
        /// Sets the specified field for editing.
        /// </summary>
        /// <param name="fieldState"></param>
        internal void SetFieldSettings(DataGeneratorAdditionalTupleFieldSettingsState fieldState)
        {
            m_FieldState = fieldState;

            m_FieldTypeSelector.SelectedFieldType = fieldState.FieldType;

            btnRemove.Enabled = !fieldState.IsNewField();

            if (FieldEditorBody is IDataGeneratorAdditionalTupleFieldEditor editor)
            {
                editor.SetFieldSettings(fieldState);
            }
        }

        #endregion

        #region validation

        /// <inheritdoc/>
        protected override bool ValidateInputValues(out string? invalidMessage, out Control? invalidControl)
        {
            if (!base.ValidateInputValues(out invalidMessage, out invalidControl)) { return false; }

            Control control;

            // FieldType
            control = cmbFieldType;

            if (!ValidationUtility.ValidateRequiredText(control.Text, out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            // Body
            if (FieldEditorBody is IDataGeneratorAdditionalTupleFieldEditor editor)
            {
                if (!editor.Validate(out invalidMessage, out invalidControl)) { return false; }
            }

            invalidMessage = null;
            invalidControl = null;
            return true;
        }

        #endregion

        #region end of editting

        /// <summary>
        /// Gets the edited field.
        /// </summary>
        /// <returns></returns>
        private DataGeneratorAdditionalTupleFieldSettingsState GetUpdatedFieldSettings()
        {
            if (FieldEditorBody is IDataGeneratorAdditionalTupleFieldEditor editor)
            {
                var field = editor.UpdateFieldSettings();

                if (field.Settings != null)
                {
                    UpdateFieldSettings(field.Settings);
                }

                return field;
            }

            if (m_FieldState.Settings != null)
            {
                UpdateFieldSettings(m_FieldState.Settings);
            }

            return m_FieldState;
        }

        /// <summary>
        /// Gets the edited field as a new instance.
        /// </summary>
        /// <returns></returns>
        private DataGeneratorAdditionalTupleFieldSettings GetFieldSettingsAsNew()
        {
            if (FieldEditorBody is IDataGeneratorAdditionalTupleFieldEditor editor)
            {
                var field = editor.GetFieldSettingsAsNew();

                UpdateFieldSettings(field);
                return field;
            }
            else
            {
                return null!;
            }
        }

        /// <summary>
        /// Applies the input value to the specified field.
        /// </summary>
        /// <param name="_"></param>
        private void UpdateFieldSettings(DataGeneratorAdditionalTupleFieldSettings _)
        {
        }

        #endregion

        #region IDataGeneratorFieldEditor implements

        /// <inheritdoc/>
        void IDataGeneratorAdditionalTupleFieldEditor.SetFieldSettings(DataGeneratorAdditionalTupleFieldSettingsState settings)
        {
            SetFieldSettings(settings);
        }

        /// <inheritdoc/>
        DataGeneratorAdditionalTupleFieldSettingsState IDataGeneratorAdditionalTupleFieldEditor.UpdateFieldSettings()
        {
            return GetUpdatedFieldSettings();
        }

        /// <inheritdoc/>
        DataGeneratorAdditionalTupleFieldSettings IDataGeneratorAdditionalTupleFieldEditor.GetFieldSettingsAsNew()
        {
            return GetFieldSettingsAsNew();
        }

        /// <inheritdoc/>
        bool IDataGeneratorAdditionalTupleFieldEditor.Validate(out string? invalidMessage, out Control? invalidControl)
        {
            return ValidateInputValues(out invalidMessage, out invalidControl);
        }

        #endregion

    }
}
