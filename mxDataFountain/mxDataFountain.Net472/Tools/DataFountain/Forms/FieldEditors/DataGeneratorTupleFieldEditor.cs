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
using mxProject.Tools.DataFountain.Forms.FieldEditors.TupleFields;

namespace mxProject.Tools.DataFountain.Forms.FieldEditors
{

    /// <summary>
    /// Editor for <see cref="DataGeneratorTupleFieldSettings"/>.
    /// </summary>
    internal partial class DataGeneratorTupleFieldEditor : DataGeneratorFieldEditorBase, IDataGeneratorTupleFieldEditor
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="context"></param>
        internal DataGeneratorTupleFieldEditor(DataFountainContext context) : base(context)
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

                    generatorSettings.TupleFields = new[] { GetFieldSettingsAsNew() };

                    ShowPreview(generatorSettings);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };
        }

        #region field type

        private DataGeneratorFieldTypeSelector<DataGeneratorTupleFieldType, DataGeneratorTupleFieldTypeBehavior, IDataGeneratorTupleFieldEditor> m_FieldTypeSelector = null!;

        /// <summary>
        /// Initializes field types.
        /// </summary>
        private void InitFieldType()
        {
            void OnFieldTypeChanged(DataGeneratorTupleFieldType fieldType)
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

            void OnEditorChanged(IDataGeneratorTupleFieldEditor? editor)
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

            void AddFieldTypeBehavior(DataGeneratorTupleFieldTypeBehavior behavior)
            {
                m_FieldTypeSelector.RegisterFieldType(behavior.FieldType, behavior);
            }

            AddFieldTypeBehavior(new DataGeneratorTupleFieldTypeBehavior(DataGeneratorTupleFieldType.EachTuple, context => new EachTupleFieldEditor(context)));
            AddFieldTypeBehavior(new DataGeneratorTupleFieldTypeBehavior(DataGeneratorTupleFieldType.DbQuery, context => new DbQueryFieldsEditor(context)));

            InitFieldTypeComboBox(cmbFieldType, m_FieldTypeSelector.GetFieldTypes(), item =>
            {
                if (item is DataGeneratorTupleFieldType fieldType)
                {
                    m_FieldTypeSelector.SelectedFieldType = fieldType;
                }
                else
                {
                    m_FieldTypeSelector.SelectedFieldType = DataGeneratorTupleFieldType.Unknown;
                }
            }
            );
        }

        #endregion

        #region field

        private DataGeneratorTupleFieldSettingsState m_FieldState = null!;

        #endregion

        #region start editting

        /// <summary>
        /// Sets the specified field for editing.
        /// </summary>
        /// <param name="fieldState"></param>
        internal void SetFieldSettings(DataGeneratorTupleFieldSettingsState fieldState)
        {
            m_FieldState = fieldState;

            m_FieldTypeSelector.SelectedFieldType = fieldState.FieldType;

            btnRemove.Enabled = !fieldState.IsNewField();

            if (FieldEditorBody is IDataGeneratorTupleFieldEditor editor)
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
            if (FieldEditorBody is IDataGeneratorTupleFieldEditor editor)
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
        private DataGeneratorTupleFieldSettingsState GetUpdatedFieldSettings()
        {
            if (FieldEditorBody is IDataGeneratorTupleFieldEditor editor)
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
        private DataGeneratorTupleFieldSettings GetFieldSettingsAsNew()
        {
            if (FieldEditorBody is IDataGeneratorTupleFieldEditor editor)
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
        private void UpdateFieldSettings(DataGeneratorTupleFieldSettings _)
        {
        }

        #endregion

        #region IDataGeneratorFieldEditor implements

        /// <inheritdoc/>
        void IDataGeneratorTupleFieldEditor.SetFieldSettings(DataGeneratorTupleFieldSettingsState settings)
        {
            SetFieldSettings(settings);
        }

        /// <inheritdoc/>
        DataGeneratorTupleFieldSettingsState IDataGeneratorTupleFieldEditor.UpdateFieldSettings()
        {
            return GetUpdatedFieldSettings();
        }

        /// <inheritdoc/>
        DataGeneratorTupleFieldSettings IDataGeneratorTupleFieldEditor.GetFieldSettingsAsNew()
        {
            return GetFieldSettingsAsNew();
        }

        /// <inheritdoc/>
        bool IDataGeneratorTupleFieldEditor.Validate(out string? invalidMessage, out Control? invalidControl)
        {
            return ValidateInputValues(out invalidMessage, out invalidControl);
        }

        #endregion

    }
}
