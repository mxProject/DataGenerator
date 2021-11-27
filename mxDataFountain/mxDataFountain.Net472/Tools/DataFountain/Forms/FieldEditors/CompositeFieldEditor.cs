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
using mxProject.Tools.DataFountain.Forms.FieldEditors.Fields;

namespace mxProject.Tools.DataFountain.Forms.FieldEditors
{

    /// <summary>
    /// Editor for <see cref="CompositeFieldSettingsBase"/>.
    /// </summary>
    internal partial class CompositeFieldEditor : DataGeneratorFieldEditorBase, IDataGeneratorFieldEditor
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="context"></param>
        internal CompositeFieldEditor(DataFountainContext context) : base(context)
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

            btnPreview.Click += (sender, e) =>
            {
                if (!ValidateInputValues()) { return; }
                if (!ValidateInnerFields(out var invalidMessage))
                {
                    FormUtility.ShowMessageBox(this, invalidMessage!);
                    return;
                }

                try
                {
                    DataGeneratorSettings generatorSettings = new();

                    generatorSettings.Fields = new[] { GetFieldSettingsAsNew() };

                    ShowPreview(generatorSettings);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };
        }

        #region field type

        private DataGeneratorFieldTypeSelector<DataGeneratorFieldType, DataGeneratorFieldTypeBehavior, IDataGeneratorFieldEditor> m_FieldTypeSelector = null!;

        /// <summary>
        /// Initializes field types.
        /// </summary>
        private void InitFieldType()
        {
            void OnFieldTypeChanged(DataGeneratorFieldType fieldType)
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

            void OnEditorChanged(IDataGeneratorFieldEditor? editor)
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

            void AddFieldTypeBehavior(DataGeneratorFieldTypeBehavior behavior)
            {
                m_FieldTypeSelector.RegisterFieldType(behavior.FieldType, behavior);
            }

            AddFieldTypeBehavior(new DataGeneratorFieldTypeBehavior(DataGeneratorFieldType.FormattedString, context => new FormattedStringFieldEditor(context)));
            AddFieldTypeBehavior(new DataGeneratorFieldTypeBehavior(DataGeneratorFieldType.Computing, context => new ComputingFieldEditor(context)));

            InitFieldTypeComboBox(cmbFieldType, m_FieldTypeSelector.GetFieldTypes(), item =>
            {
                if (item is DataGeneratorFieldType fieldType)
                {
                    m_FieldTypeSelector.SelectedFieldType = fieldType;
                }
                else
                {
                    m_FieldTypeSelector.SelectedFieldType = DataGeneratorFieldType.Unknown;
                }
            }
            );
        }

        #endregion

        #region field

        private CompositeFieldSettingsState m_FieldState = null!;

        #endregion

        #region start editting

        /// <summary>
        /// Sets the specified field for editing.
        /// </summary>
        /// <param name="fieldState"></param>
        internal void SetFieldSettings(CompositeFieldSettingsState fieldState)
        {
            m_FieldState = fieldState;
            
            txtFieldName.Text = fieldState.Settings?.FieldName;
            m_FieldTypeSelector.SelectedFieldType = fieldState.FieldType;

            btnRemove.Enabled = !fieldState.IsNewField();

            if (FieldEditorBody is IDataGeneratorFieldEditor editor)
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

            // FieldName
            control = txtFieldName;

            if (!ValidationUtility.ValidateRequiredText(control.Text, out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            // FieldType
            control = cmbFieldType;

            if (!ValidationUtility.ValidateRequiredText(control.Text, out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            // Body
            if (FieldEditorBody is IDataGeneratorFieldEditor editor)
            {
                if (!editor.Validate(out invalidMessage, out invalidControl)) { return false; }
            }

            invalidMessage = null;
            invalidControl = null;
            return true;
        }

        private bool ValidateInnerFields(out string? invalidMessage)
        {
            if (m_FieldState.CompositeField?.ArgumentFields == null || m_FieldState.CompositeField.ArgumentFields.Length == 0)
            {
                invalidMessage = "No argument field is set in the Composite field.";
                return false;
            }

            invalidMessage = null;
            return true;
        }

        #endregion

        #region end of editting

        /// <summary>
        /// Gets the edited field.
        /// </summary>
        /// <returns></returns>
        private DataGeneratorFieldSettingsState GetUpdatedFieldSettings()
        {
            var argumentFields = m_FieldState.CompositeField?.ArgumentFields;

            if (FieldEditorBody is IDataGeneratorFieldEditor editor)
            {
                var fieldState = editor.UpdateFieldSettings();

                if (fieldState.Settings!= null)
                {
                    UpdateFieldSettings(fieldState.Settings, argumentFields);
                }

                return fieldState;
            }

            if (m_FieldState.Settings != null)
            {
                UpdateFieldSettings(m_FieldState.Settings, argumentFields);
            }

            return m_FieldState;
        }

        /// <summary>
        /// Gets the edited field as a new instance.
        /// </summary>
        /// <returns></returns>
        private DataGeneratorFieldSettings GetFieldSettingsAsNew()
        {
            if (FieldEditorBody is IDataGeneratorFieldEditor editor)
            {
                var field = editor.GetFieldSettingsAsNew();

                UpdateFieldSettings(field, m_FieldState.CompositeField?.ArgumentFields?.CreateClones());

                return field!;
            }
            else
            {
                return null!;
            }
        }

        /// <summary>
        /// Applies the input value to the specified field.
        /// </summary>
        /// <param name="field"></param>
        /// <param name="argumentFields"></param>
        private void UpdateFieldSettings(DataGeneratorFieldSettings field, DataGeneratorFieldSettings[]? argumentFields)
        {
            field.FieldName = txtFieldName.Text;

            if (field is CompositeFieldSettingsBase composite)
            {
                composite.ArgumentFields = argumentFields;
            }
        }

        #endregion

        #region IDataGeneratorFieldEditor implements

        /// <inheritdoc/>
        void IDataGeneratorFieldEditor.SetFieldSettings(DataGeneratorFieldSettingsState settings)
        {
            SetFieldSettings((CompositeFieldSettingsState)settings);
        }

        /// <inheritdoc/>
        DataGeneratorFieldSettingsState IDataGeneratorFieldEditor.UpdateFieldSettings()
        {
            return GetUpdatedFieldSettings();
        }

        /// <inheritdoc/>
        DataGeneratorFieldSettings IDataGeneratorFieldEditor.GetFieldSettingsAsNew()
        {
            return GetFieldSettingsAsNew();
        }

        /// <inheritdoc/>
        bool IDataGeneratorFieldEditor.Validate(out string? invalidMessage, out Control? invalidControl)
        {
            return ValidateInputValues(out invalidMessage, out invalidControl);
        }

        #endregion

    }

}
