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

namespace mxProject.Tools.DataFountain.Forms.FieldEditors.TupleFields
{

    /// <summary>
    /// Editor for <see cref="DirectProductFieldSettings"/>.
    /// </summary>
    internal partial class DirectProductFieldEditor : TupleFieldEditorBase
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="context"></param>
        internal DirectProductFieldEditor(DataFountainContext context) : base(context)
        {
            InitializeComponent();

            Init();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Init()
        {
            InitFieldType();

            btnPreview.Click += (sender, e) =>
            {
                if (!ValidateInputValues()) { return; }

                try
                {
                    ShowPreview(GetFieldSettingsAsNew());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };
        }

        #region field type

        /// <summary>
        /// Initializes field types.
        /// </summary>
        private void InitFieldType()
        {

            cmbFieldType.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbFieldType.Items.Clear();
            cmbFieldType.Items.Add(DataGeneratorTupleFieldType.DirectProduct);
            cmbFieldType.SelectedIndex = 0;
            cmbFieldType.Enabled = false;

        }

        #endregion

        #region field

        private DirectProductFieldSettingsState m_FieldState = null!;

        #endregion

        #region start editting

        /// <summary>
        /// Sets the specified field for editing.
        /// </summary>
        /// <param name="fieldState"></param>
        internal void SetDirectProductFieldSettings(DirectProductFieldSettingsState fieldState)
        {
            m_FieldState = fieldState;
        }

        /// <inheritdoc/>
        protected override void SetFieldSettings(DataGeneratorTupleFieldSettingsState? fieldState)
        {
            if (fieldState is DirectProductFieldSettingsState directProduct)
            {
                SetDirectProductFieldSettings(directProduct);
            }
        }

        #endregion

        #region validation

        /// <summary>
        /// Validate the input values.
        /// </summary>
        /// <returns></returns>
        private bool ValidateInputValues()
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

        /// <inheritdoc/>
        protected override bool ValidateInputValues(out string? invalidMessage, out Control? invalidControl)
        {
            if (!base.ValidateInputValues(out invalidMessage, out invalidControl)) { return false; }

            if (m_FieldState.DirectProduct?.Fields == null || m_FieldState.DirectProduct?.Fields.Length == 0)
            {
                invalidMessage = "No field is set in the DirectProduct field.";
                invalidControl = null;
                return false;
            }

            if (m_FieldState.DirectProduct?.Fields.Length == 1)
            {
                invalidMessage = "Set two or more fields in the DirectProduct field.";
                invalidControl = null;
                return false;
            }

            invalidMessage = null;
            invalidControl = null;
            return true;
        }

        #endregion

        #region end of editting

        /// <inheritdoc/>
        protected override DataGeneratorTupleFieldSettings GetFieldSettingsAsNew()
        {
            if (m_FieldState.Settings is DirectProductFieldSettings settings)
            {
                return (DirectProductFieldSettings)settings.Clone();
            }
            else
            {
                return null!;
            }
        }

        #endregion

        #region preview

        /// <summary>
        /// Generates and previews the value of the current field. 
        /// </summary>
        /// <param name="fieldSettings"></param>
        private void ShowPreview(DataGeneratorTupleFieldSettings fieldSettings)
        {
            DataGeneratorSettings generatorSettings = new();

            generatorSettings.TupleFields = new[] { fieldSettings };

            // using DataPreviewForm form = new();

            Context.CurrentExecutor.ShowPreview(generatorSettings.ToJson(), FormUtility.PreviewDateCount);
        }

        #endregion

    }
}
