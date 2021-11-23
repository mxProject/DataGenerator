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
using System.Reflection;

using mxProject.Tools.DataFountain.Configurations;

namespace mxProject.Tools.DataFountain.Forms
{

    /// <summary>
    /// 
    /// </summary>
    internal partial class CsvSettingsForm : Form
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        internal CsvSettingsForm()
        {
            InitializeComponent();
            InitForm();
        }

        /// <summary>
        /// Performs initial processing.
        /// </summary>
        private void InitForm()
        {
            this.Load += (sender, e) =>
            {
                if (m_CsvSettings != null)
                {
                    SetCsvSettings(m_CsvSettings);
                }
            };

            btnOK.Click += (sender, e) =>
            {
                if (!ValidateInputValues(out string? errorMessage, out Control? errorControl))
                {
                    if (!string.IsNullOrEmpty(errorMessage)) { FormUtility.ShowMessageBox(this, errorMessage!); }
                    if (errorControl != null) { FormUtility.SetFocus(errorControl, true); }
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            btnCancel.Click += (sender, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            this.CancelButton = btnCancel;

            txtQuote.MaxLength = 1;
            InitDelimiter();
            InitEncoding();
            InitNewLine();
        }

        #region ShowDialog

        /// <summary>
        /// Shows as modal dialog.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="csvSettings"></param>
        /// <returns></returns>
        internal DialogResult ShowDialog(IWin32Window owner, CsvSettings csvSettings)
        {
            try
            {
                FormUtility.InheritIcon(this, owner);

                m_CsvSettings = csvSettings;

                var result = base.ShowDialog(owner);

                if (result == DialogResult.OK)
                {
                    UpdateCsvSettings(csvSettings);
                }

                return result;
            }
            finally
            {
                m_CsvSettings = null!;
            }
        }

        private CsvSettings m_CsvSettings = null!;

        private void SetCsvSettings(CsvSettings csvSettings)
        {
            SetSelectedDelimiter(csvSettings.Delimiter);
            txtQuote.Text = new string(csvSettings.Quote, 1);
            SetSelectedShouldQuote(csvSettings.ShouldQuote);
            cmbEncoding.Text = csvSettings.Encoding;
            SetSelectedNewLine(csvSettings.NewLine);
            chkWithHeader.Checked = csvSettings.WithHeader;
        }

        private void UpdateCsvSettings(CsvSettings csvSettings)
        {
            static char GetChar(TextBox textBox)
            {
                if (string.IsNullOrEmpty(textBox.Text)) { return '\0'; }

                return textBox.Text[0];
            }

            csvSettings.Delimiter = GetSelectedDelimiter();
            csvSettings.Quote = GetChar(txtQuote);
            csvSettings.ShouldQuote = (GetSelectedShouldQuote() == ShouldQuote.Always);
            csvSettings.Encoding = cmbEncoding.Text;
            csvSettings.NewLine = GetSelectedNewLine();
            csvSettings.WithHeader = chkWithHeader.Checked;
        }

        #endregion

        #region quote

        private enum ShouldQuote
        {
            OnlyWhenNeeded = 0,
            Always = 1
        }

        private ShouldQuote GetSelectedShouldQuote()
        {
            if (rdoShouldQuoteAlways.Checked) { return ShouldQuote.Always; }
            return ShouldQuote.OnlyWhenNeeded;
        }

        private void SetSelectedShouldQuote(bool shouldQuote)
        {
            if (shouldQuote)
            {
                rdoShouldQuoteAlways.Checked = true;
            }
            else
            {
                rdoShouldQuoteOnlyWhenNeeded.Checked = true;
            }
        }

        #endregion

        #region encoding

        private void InitEncoding()
        {
            cmbEncoding.DropDownStyle = ComboBoxStyle.DropDown;
            cmbEncoding.Items.Clear();
            cmbEncoding.Items.AddRange(CsvSettings.GetKnownEncodings().ToArray<object>());
        }

        #endregion

        #region newline

        private readonly Dictionary<string, StringItem> m_NewLineItems = new();

        private void InitNewLine()
        {
            m_NewLineItems.Clear();

            foreach (var value in CsvSettings.GetKnownNewLines())
            {
                m_NewLineItems.Add(value, new StringItem(value));
            }

            cmbNewLine.DropDownStyle = ComboBoxStyle.DropDown;
            cmbNewLine.Items.Clear();

            foreach (var item in m_NewLineItems.Values)
            {
                cmbNewLine.Items.Add(item);
            }
        }

        private string GetSelectedNewLine()
        {
            if (cmbNewLine.SelectedItem is StringItem item)
            {
                return item.Value;
            }
            else
            {
                return cmbNewLine.Text;
            }
        }

        private void SetSelectedNewLine(string? value)
        {
            if (value != null && m_NewLineItems.TryGetValue(value, out var item))
            {
                cmbNewLine.SelectedItem = item;
            }
            else
            {
                cmbNewLine.Text = value;
            }
        }

        #endregion

        #region delimiter

        private readonly Dictionary<char, CharItem> m_DelimiterItems = new();

        private void InitDelimiter()
        {
            m_DelimiterItems.Clear();

            foreach (var value in CsvSettings.GetKnownDelimiters())
            {
                m_DelimiterItems.Add(value, new CharItem(value));
            }

            cmbDelimiter.DropDownStyle = ComboBoxStyle.DropDown;
            cmbDelimiter.Items.Clear();

            foreach (var item in m_DelimiterItems.Values)
            {
                cmbDelimiter.Items.Add(item);
            }
        }

        private char GetSelectedDelimiter()
        {
            if (cmbDelimiter.SelectedItem is CharItem item)
            {
                return item.Value;
            }
            else if (string.IsNullOrEmpty(cmbDelimiter.Text))
            {
                return '\0';
            }
            else
            {
                return cmbNewLine.Text[0];
            }
        }

        private void SetSelectedDelimiter(char value)
        {
            if (m_DelimiterItems.TryGetValue(value, out var item))
            {
                cmbDelimiter.SelectedItem = item;
            }
            else
            {
                cmbDelimiter.Text = new string(value, 1);
            }
        }

        #endregion

        #region validation

        private bool ValidateInputValues(out string? errorMessage, out Control? errorControl)
        {
            Control control;

            // delimiter
            control = cmbDelimiter;

            if (!ValidationUtility.ValidateRequiredText(control.Text, out errorMessage))
            {
                errorControl = control;
                return false;
            }

            // quote
            control = txtQuote;

            if (!ValidationUtility.ValidateRequiredText(control.Text, out errorMessage))
            {
                errorControl = control;
                return false;
            }

            // encoding
            control = cmbEncoding;

            if (!ValidationUtility.ValidateRequiredText(control.Text, out errorMessage))
            {
                errorControl = control;
                return false;
            }

            try
            {
                var _ = Encoding.GetEncoding(control.Text);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                errorControl = control;
                return false;
            }

            // newline
            control = cmbNewLine;

            if (!ValidationUtility.ValidateRequiredText(control.Text, out errorMessage))
            {
                errorControl = control;
                return false;
            }

            errorMessage = null;
            errorControl = null;
            return true;
        }

        #endregion

        private sealed class CharItem
        {
            internal CharItem(char value)
            {
                Value = value;
                DisplayText = ReplaceControlChar(value);
            }

            internal char Value { get; }

            internal string DisplayText { get; }

            public override string ToString()
            {
                return DisplayText;
            }

            internal static string ReplaceControlChar(char c)
            {
                if (c == '\r') { return "{CR}"; }
                if (c == '\n') { return "{LF}"; }
                if (c == '\t') { return "{TAB}"; }

                return new string(c, 1);
            }

            internal static string ReplaceControlChars(string text)
            {
                if (string.IsNullOrEmpty(text)) { return text; }

                StringBuilder sb = new();

                foreach (var c in text)
                {
                    sb.Append(ReplaceControlChar(c));
                }

                return sb.ToString();
            }
        }

        private sealed class StringItem
        {
            internal StringItem(string value)
            {
                Value = value;
                DisplayText = CharItem.ReplaceControlChars(value);
            }

            internal string Value { get; }

            internal string DisplayText { get; }

            public override string ToString()
            {
                return DisplayText;
            }
        }

    }
}
