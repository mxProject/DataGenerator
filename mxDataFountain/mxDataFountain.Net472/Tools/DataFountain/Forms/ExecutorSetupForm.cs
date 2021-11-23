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
    internal partial class ExecutorSetupForm : Form
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        internal ExecutorSetupForm()
        {
            InitializeComponent();
            InitForm();
            InitAssemblyGrid();
        }

        /// <summary>
        /// Performs initial processing.
        /// </summary>
        private void InitForm()
        {
            this.Load += (sender, e) =>
            {
                if (m_ExecutorSettings != null)
                {
                    SetSetupArgs(m_ExecutorSettings);
                }
            };

            btnSearchFilePath.Click += (sender, e) =>
            {
                if (FormUtility.ShowAssemblyOpenFileDialog("", out string selectedPath) != DialogResult.OK) { return; }

                txtNewAssemblyFilePath.Text = selectedPath;
            };

            btnAddAssembly.Click += (sender, e) =>
            {
                if (string.IsNullOrEmpty(txtNewAssemblyFilePath.Text)) { return; }

                try
                {
                    if (!AddAssembly(txtNewAssemblyFilePath.Text)) { return; }

                    txtNewAssemblyFilePath.Text = null;
                }
                catch (Exception ex)
                {
                    FormUtility.ShowErrorMessageBox(this, ex.Message);
                }
            };

            btnOK.Click += (sender, e) =>
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            btnCancel.Click += (sender, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            this.CancelButton = btnCancel;
        }

        #region ShowDialog

        /// <summary>
        /// Shows as modal dialog.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="executorSettings"></param>
        /// <returns></returns>
        internal DialogResult ShowDialog(IWin32Window owner, ExecutorSettings executorSettings)
        {
            try
            {
                FormUtility.InheritIcon(this, owner);

                m_ExecutorSettings = executorSettings;

                var result = base.ShowDialog(owner);

                if (result == DialogResult.OK)
                {
                    UpdateSetupArgs(executorSettings);
                }

                return result;
            }
            finally
            {
                m_ExecutorSettings = null!;
            }
        }

        private ExecutorSettings m_ExecutorSettings = null!;

        private void SetSetupArgs(ExecutorSettings executorSettings)
        {
            AddAssemblyFiles(executorSettings.AssemblyFiles);
            txtContextActivatorTypeName.Text = executorSettings.DataGeneratorContextActivator;
        }

        private void UpdateSetupArgs(ExecutorSettings executorSettings)
        {
            executorSettings.AssemblyFiles = GetAssemblyFiles();
            executorSettings.DataGeneratorContextActivator = txtContextActivatorTypeName.Text;
        }

        #endregion

        #region assemblies

        private readonly DataTable m_AssemblyGridData = new();

        /// <summary>
        /// Initializes the assembly grid.
        /// </summary>
        private void InitAssemblyGrid()
        {
            m_AssemblyGridData.Columns.Add("AssemblyName", typeof(string));
            m_AssemblyGridData.Columns.Add("FilePath", typeof(string));

            var grid = grdAssemblies;

            grid.CellValueNeeded += (sender, e) =>
            {
                e.Value = m_AssemblyGridData.Rows[e.RowIndex][e.ColumnIndex];
            };

            UserDeleteRowState deletingState = new();

            grid.UserDeletingRow += (sender, e) =>
            {
                deletingState.RowIndex = e.Row.Index;
            };

            grid.UserDeletedRow += (sender, e) =>
            {
                m_AssemblyGridData.Rows.RemoveAt(deletingState.RowIndex);
                grid.RowCount = m_AssemblyGridData.Rows.Count;
            };

            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = true;
            grid.VirtualMode = true;
            grid.RowCount = 0;
        }

        /// <summary>
        /// Adds the specified assembly.
        /// </summary>
        /// <param name="assemblyFile"></param>
        /// <returns></returns>
        private bool AddAssembly(string assemblyFile)
        {
            try
            {
                var asm = AssemblyName.GetAssemblyName(assemblyFile);

                if (asm == null)
                {
                    return false;
                }

                m_AssemblyGridData.Rows.Add(new object[] { asm.FullName, assemblyFile });

                grdAssemblies.RowCount = m_AssemblyGridData.Rows.Count;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Adds the specified assemblies.
        /// </summary>
        /// <param name="assemblyFiles"></param>
        private void AddAssemblyFiles(IEnumerable<string?>? assemblyFiles)
        {
            if (assemblyFiles == null) { return; }

            foreach (var filePath in assemblyFiles)
            {
                if (string.IsNullOrEmpty(filePath)) { continue; }

                var asm = AssemblyName.GetAssemblyName(filePath);

                m_AssemblyGridData.Rows.Add(new object[] { asm.FullName, filePath! });
            }

            grdAssemblies.RowCount = m_AssemblyGridData.Rows.Count;
        }

        /// <summary>
        /// Gets the entered assemblies.
        /// </summary>
        /// <returns></returns>
        private string[] GetAssemblyFiles()
        {
            string[] assemblies = new string[m_AssemblyGridData.Rows.Count];

            for (int r = 0; r < m_AssemblyGridData.Rows.Count; ++r)
            {
                assemblies[r] = m_AssemblyGridData.Rows[r]["FilePath"].ToString();
            }

            return assemblies;
        }

        #endregion

    }
}
