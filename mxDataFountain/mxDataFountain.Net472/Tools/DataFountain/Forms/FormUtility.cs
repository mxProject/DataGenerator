#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using mxProject.Devs.DataGeneration;

namespace mxProject.Tools.DataFountain.Forms
{

    internal static class FormUtility
    {

        #region const

        internal readonly static int PreviewDateCount = 100;

        internal readonly static int ProgressIntervalCount = 100;

        #endregion

        #region messagebox

        /// <summary>
        /// Shows the specified message.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="message"></param>
        internal static void ShowMessageBox(Form form, string message)
        {
            if (form.InvokeRequired)
            {
                form.Invoke(new Action<Form, string>(ShowMessageBox), form, message);
                return;
            }

            MessageBox.Show(form, message, form.Text);
        }

        /// <summary>
        /// Shows the specified message.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="message"></param>
        internal static void ShowMessageBox(Control control, string message)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action<Control, string>(ShowMessageBox), control, message);
                return;
            }

            ShowMessageBox(control.FindForm(), message);
        }

        /// <summary>
        /// Shows the specified message.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        internal static bool ShowConfirmMessageBox(Form form, string message)
        {
            if (form.InvokeRequired)
            {
                return (bool)form.Invoke(new Func<Form, string, bool>(ShowConfirmMessageBox), form, message);
            }

            return MessageBox.Show(form, message, form.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
        }

        /// <summary>
        /// Shows the specified message.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        internal static bool ShowConfirmMessageBox(Control control, string message)
        {
            if (control.InvokeRequired)
            {
                return (bool)control.Invoke(new Func<Control, string, bool>(ShowConfirmMessageBox), control, message);
            }

            return ShowConfirmMessageBox(control.FindForm(), message);
        }

        /// <summary>
        /// Shows the specified message.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="message"></param>
        internal static void ShowErrorMessageBox(Form form, string message)
        {
            if (form.InvokeRequired)
            {
                form.Invoke(new Action<Form, string>(ShowErrorMessageBox), form, message);
                return;
            }

            MessageBox.Show(form, message, form.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Shows the specified message.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="message"></param>
        internal static void ShowErrorMessageBox(Control control, string message)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action<Control, string>(ShowErrorMessageBox), control, message);
                return;
            }

            ShowErrorMessageBox(control.FindForm(), message);
        }

        #endregion

        #region filedialog

        private readonly static string CsvFileFilter = "csv files|*.csv|tsv files|*.tsv|all files|*.*";
        private readonly static string ProjectFileFilter = "project files|*.dfproj|all files|*.*";
        private readonly static string GeneratorFileFilter = "config files|*.config|json files|*.json|all files|*.*";
        private readonly static string AssemblyFileFilter = "dll files|*.dll|exe files|*.exe|all files|*.*";

        internal static DialogResult ShowCsvSaveFileDialog(string? initialFilePath, out string selectedFilePath)
        {
            return ShowSaveFileDialog(initialFilePath, CsvFileFilter, out selectedFilePath);
        }

        internal static DialogResult ShowProjectSaveFileDialog(string? initialFilePath, out string selectedFilePath)
        {
            return ShowSaveFileDialog(initialFilePath, ProjectFileFilter, out selectedFilePath);
        }

        internal static DialogResult ShowGeneratorSaveFileDialog(string? initialFilePath, out string selectedFilePath)
        {
            return ShowSaveFileDialog(initialFilePath, GeneratorFileFilter, out selectedFilePath);
        }

        internal static DialogResult ShowSaveFileDialog(string? initialFilePath, string filter, out string selectedFilePath)
        {
            using SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = filter,
                RestoreDirectory = true,
                OverwritePrompt = true,
                AddExtension = true,
                SupportMultiDottedExtensions = true,
            };

            if (!string.IsNullOrEmpty(initialFilePath))
            {
                var dir = Path.GetDirectoryName(initialFilePath);
                var file = Path.GetFileName(initialFilePath);

                dialog.FileName = file;
                dialog.InitialDirectory = dir;
            }

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                selectedFilePath = dialog.FileName;
            }
            else
            {
                selectedFilePath = null!;
            }

            return result;
        }

        internal static DialogResult ShowCsvOpenFileDialog(string? initialFilePath, out string selectedFilePath)
        {
            return ShowOpenFileDialog(initialFilePath, CsvFileFilter, out selectedFilePath);
        }

        internal static DialogResult ShowProjectOpenFileDialog(string? initialFilePath, out string selectedFilePath)
        {
            return ShowOpenFileDialog(initialFilePath, ProjectFileFilter, out selectedFilePath);
        }

        internal static DialogResult ShowGeneratorOpenFileDialog(string? initialFilePath, out string selectedFilePath)
        {
            return ShowOpenFileDialog(initialFilePath, GeneratorFileFilter, out selectedFilePath);
        }

        internal static DialogResult ShowAssemblyOpenFileDialog(string? initialFilePath, out string selectedFilePath)
        {
            return ShowOpenFileDialog(initialFilePath, AssemblyFileFilter, out selectedFilePath);
        }

        internal static DialogResult ShowOpenFileDialog(string? initialFilePath, string filter, out string selectedFilePath)
        {
            using OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = filter,
                RestoreDirectory = true,
                SupportMultiDottedExtensions = true,
                Multiselect=false,
            };

            if (!string.IsNullOrEmpty(initialFilePath))
            {
                var dir = Path.GetDirectoryName(initialFilePath);
                var file = Path.GetFileName(initialFilePath);

                dialog.FileName = file;
                dialog.InitialDirectory = dir;
            }

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                selectedFilePath = dialog.FileName;
            }
            else
            {
                selectedFilePath = null!;
            }

            return result;
        }

        #endregion

        #region focus

        /// <summary>
        /// Sets the focus on the specified control.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="selectText"></param>
        /// <returns></returns>
        internal static bool SetFocus(Control control, bool selectText)
        {
            if (control == null) { return false; }

            if (selectText && control is TextBoxBase textBox)
            {
                if (!string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.SelectAll();
                }
            }

            return control.Focus();
        }

        #endregion

        #region get value

        /// <summary>
        /// Converts the text of the specified control to an int value.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        internal static int? ParseToInt32(Control control)
        {
            return ParseTextCore<int>(control, s =>
            {
                if (int.TryParse(s, out int value))
                {
                    return value;
                }
                else
                {
                    return null;
                }
            });
        }

        /// <summary>
        /// Converts the text of the specified control to a double value.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        internal static double? ParseToDouble(Control control)
        {
            return ParseTextCore<double>(control, s =>
            {
                if (double.TryParse(s, out double value))
                {
                    return value;
                }
                else
                {
                    return null;
                }
            });
        }

        /// <summary>
        /// Converts the text of the specified control.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="parser"></param>
        /// <returns></returns>
        private static T? ParseTextCore<T>(Control control, Func<string, T?> parser)
            where T : struct
        {
            if (!string.IsNullOrEmpty(control.Text))
            {
                return parser(control.Text);
            }

            return null;
        }

        #endregion

        #region progress

        internal static bool NeedProgress(int currentCount, int totalCount)
        {
            if (currentCount == 0) { return true; }
            if (currentCount >= totalCount) { return true; }

            int interval = Math.Max(ProgressIntervalCount, totalCount / 10);

            if (interval <= 1) { return true; }

            Math.DivRem(currentCount, interval, out int result);
            if (result != 0) { return false; }

            return true;
        }

        #endregion

        #region icon

        internal static void InheritIcon(Form form, IWin32Window owner)
        {
            if (owner is Form frm)
            {
                form.Icon = frm.Icon;
            }
        }

        #endregion

    }

}
