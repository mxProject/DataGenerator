#nullable enable

using System;
using System.Collections;
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

namespace mxProject.Tools.DataFountain.Forms.FieldEditors
{

    /// <summary>
    /// Basic implementation of field editor.
    /// </summary>
    internal partial class DataGeneratorFieldEditorBase : UserControl
    {

        internal DataGeneratorFieldEditorBase() : this(null!)
        {
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="context"></param>
        internal DataGeneratorFieldEditorBase(DataFountainContext context)
        {
            InitializeComponent();

            Context = context;
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        internal DataFountainContext Context { get; }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <param name="bodyPanel"></param>
        protected void Init(Panel? bodyPanel)
        {
            BodyPanel = bodyPanel;
        }

        #region field type

        protected void InitFieldTypeComboBox(ComboBox cmbFieldType, IEnumerable fieldTypes, Action<object>? onSelectedItemChanged = null)
        {

            cmbFieldType.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbFieldType.Items.Clear();

            foreach (var fieldType in fieldTypes)
            {
                cmbFieldType.Items.Add(fieldType);
            }

            cmbFieldType.SelectedIndexChanged += (sender, e) =>
            {
                onSelectedItemChanged?.Invoke(cmbFieldType.SelectedItem);
            };

        }

        #endregion

        #region editor

        /// <summary>
        /// Gets the panel for placing the editor body.
        /// </summary>
        protected Panel? BodyPanel { get; private set; }

        /// <summary>
        /// Gets or sets the editor body.
        /// </summary>
        internal UserControl? FieldEditorBody
        {
            get { return m_FieldEditorBody; }
            set
            {
                if (m_FieldEditorBody == value) { return; }

                UserControl? prev = m_FieldEditorBody;

                if (m_FieldEditorBody != null)
                {
                    BodyPanel?.Controls.Remove(m_FieldEditorBody);
                }

                m_FieldEditorBody = value;

                if (m_FieldEditorBody != null)
                {
                    m_FieldEditorBody.Dock = DockStyle.Fill;
                    BodyPanel?.Controls.Add(m_FieldEditorBody);
                }

                prev?.Dispose();
            }
        }
        private UserControl? m_FieldEditorBody;

        #endregion

        #region validation

        /// <summary>
        /// Validate the input values.
        /// </summary>
        /// <returns></returns>
        protected bool ValidateInputValues()
        {
            errorProvider1.Clear();

            if (!ValidateInputValues(out string? message, out Control? control))
            {
                if (!string.IsNullOrEmpty(message)) { MessageBox.Show(message); }

                if (control != null)
                {
                    errorProvider1.SetError(control, message);
                    FormUtility.SetFocus(control, true);
                }

                return false;
            }

            return true;
        }

        /// <summary>
        /// Validate the input values.
        /// </summary>
        /// <param name="invalidMessage">The message indicating that it is invalid.</param>
        /// <param name="invalidControl">The control with invalid value entered.</param>
        /// <returns></returns>
        protected virtual bool ValidateInputValues(out string? invalidMessage, out Control? invalidControl)
        {
            invalidMessage = null;
            invalidControl = null;
            return true;
        }

        /// <summary>
        /// Shows a confirmation message before deleting a field.
        /// </summary>
        /// <returns></returns>
        protected virtual bool ConfirmRemoveField()
        {
            if (!FormUtility.ShowConfirmMessageBox(this, "Are you sure you want to remove this field?")) { return false; }

            return true;
        }

        #endregion

        #region preview

        /// <summary>
        /// Generates and previews the value of the current field. 
        /// </summary>
        /// <param name="generatorSettings"></param>
        protected void ShowPreview(DataGeneratorSettings generatorSettings)
        {
            Context.CurrentExecutor.ShowPreview(generatorSettings.ToJson(), FormUtility.PreviewDateCount);
        }

        #endregion

        #region messaging

        /// <summary>
        /// Publishs that you have added the specified field.
        /// </summary>
        /// <param name="fieldState"></param>
        protected void PublishAddedField(IDataGeneratorFieldSettingsState fieldState)
        {
            Context.FieldEventPublisher.Publish(DataGeneratorFieldEvent.Added, fieldState);
        }

        /// <summary>
        /// Publishs that you have updated the specified field.
        /// </summary>
        /// <param name="fieldState"></param>
        protected void PublishUpdatedField(IDataGeneratorFieldSettingsState fieldState)
        {
            Context.FieldEventPublisher.Publish(DataGeneratorFieldEvent.Updated, fieldState);
        }

        /// <summary>
        /// Publishs that you have removed the specified field.
        /// </summary>
        /// <param name="fieldState"></param>
        protected void PublishRemovedField(IDataGeneratorFieldSettingsState fieldState)
        {
            Context.FieldEventPublisher.Publish(DataGeneratorFieldEvent.Removed, fieldState);
        }

        #endregion

    }

}
