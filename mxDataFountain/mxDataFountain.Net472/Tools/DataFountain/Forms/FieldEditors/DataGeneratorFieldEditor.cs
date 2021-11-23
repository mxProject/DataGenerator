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
using mxProject.Tools.DataFountain.Forms.FieldEditors.Fields;

namespace mxProject.Tools.DataFountain.Forms.FieldEditors
{

    /// <summary>
    /// Editor for <see cref="DataGeneratorFieldSettings"/>.
    /// </summary>
    internal partial class DataGeneratorFieldEditor : DataGeneratorFieldEditorBase, IDataGeneratorFieldEditor
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="context"></param>
        internal DataGeneratorFieldEditor(DataFountainContext context) : base(context)
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

            AddFieldTypeBehavior(new DataGeneratorFieldTypeBehavior(DataGeneratorFieldType.Any, context => new AnyFieldEditor(context)));
            AddFieldTypeBehavior(new DataGeneratorFieldTypeBehavior(DataGeneratorFieldType.Each, context => new EachFieldEditor(context)));
            AddFieldTypeBehavior(new DataGeneratorFieldTypeBehavior(DataGeneratorFieldType.Random, context => new RandomFieldEditor(context)));
            AddFieldTypeBehavior(new DataGeneratorFieldTypeBehavior(DataGeneratorFieldType.Sequence, context => new SequenceFieldEditor(context)));
            AddFieldTypeBehavior(new DataGeneratorFieldTypeBehavior(DataGeneratorFieldType.DbQuery, context => new DbQueryFieldEditor(context)));

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

        private DataGeneratorFieldSettingsState m_FieldState = null!;

        #endregion

        #region start editting

        /// <summary>
        /// Sets the specified field for editing.
        /// </summary>
        /// <param name="fieldState"></param>
        internal void SetFieldSettings(DataGeneratorFieldSettingsState fieldState)
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

        #endregion

        #region end of editting

        /// <summary>
        /// Gets the edited field.
        /// </summary>
        /// <returns></returns>
        private DataGeneratorFieldSettingsState GetUpdatedFieldSettings()
        {
            if (FieldEditorBody is IDataGeneratorFieldEditor editor)
            {
                var fieldState = editor.UpdateFieldSettings();

                if (fieldState.Settings!= null)
                {
                    UpdateFieldSettings(fieldState.Settings);
                }

                return fieldState;
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
        private DataGeneratorFieldSettings GetFieldSettingsAsNew()
        {
            if (FieldEditorBody is IDataGeneratorFieldEditor editor)
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
        /// <param name="field"></param>
        private void UpdateFieldSettings(DataGeneratorFieldSettings field)
        {
            field.FieldName = txtFieldName.Text;
        }

        #endregion

        #region IDataGeneratorFieldEditor implements

        /// <inheritdoc/>
        void IDataGeneratorFieldEditor.SetFieldSettings(DataGeneratorFieldSettingsState settings)
        {
            SetFieldSettings(settings);
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
