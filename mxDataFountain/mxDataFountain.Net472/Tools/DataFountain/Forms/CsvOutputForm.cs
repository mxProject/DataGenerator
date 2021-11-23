#nullable enable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using mxProject.Devs.DataGeneration;
using mxProject.Tools.DataFountain.Controllers;
using mxProject.Tools.DataFountain.Configurations;

namespace mxProject.Tools.DataFountain.Forms
{

    /// <summary>
    /// CSV file output form.
    /// </summary>
    internal partial class CsvOutputForm : Form
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        internal CsvOutputForm()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// Performs initial processing.
        /// </summary>
        private void Init()
        {
            InitProgress();

            this.btnOK.Click += async (sender, e) =>
            {
                IsRunning = true;
                await OutputCsvAsync(txtFilePath.Text, int.Parse(txtGeneratingCount.Text), CurrentCancellationToken).ConfigureAwait(false);
                IsRunning = false;
            };

            this.btnCancel.Click += (sender, e) =>
            {
                m_CancellationToken?.Cancel();
            };

            this.btnSearchFilePath.Click += (sender, e) =>
            {
                if (FormUtility.ShowCsvSaveFileDialog(txtFilePath.Text, out string? selectedPath) == DialogResult.OK)
                {
                    txtFilePath.Text = selectedPath;
                }
            };

            OnIsRunningChanged();
        }

        #region showdialog

        /// <summary>
        /// Shows as a modal dialog.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="generatorBuilder"></param>
        /// <param name="csvSettings"></param>
        /// <returns></returns>
        internal DialogResult ShowDialog(IWin32Window owner, DataGeneratorBuilder generatorBuilder, Configurations.CsvSettings csvSettings)
        {
            try
            {
                m_DataGeneratorBuilder = generatorBuilder;
                m_CsvSettings = csvSettings;

                return base.ShowDialog(owner);
            }
            catch (Exception ex)
            {
                FormUtility.ShowErrorMessageBox(this, ex.Message);
                return DialogResult.Abort;
            }
            finally
            {
                m_DataGeneratorBuilder = null!;
                m_CsvSettings = null!;
            }
        }

        private DataGeneratorBuilder m_DataGeneratorBuilder = null!;
        private CsvSettings m_CsvSettings = null!;

        #endregion

        #region data generation

        /// <summary>
        /// Generates the specified number of data and displays it in the grid.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="generatingCount"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        private async Task OutputCsvAsync(string filePath, int generatingCount, CancellationToken cancellation = default)
        {
            try
            {
                using IDataReader? reader = await GenerateDataAsync(generatingCount).ConfigureAwait(false);

                if (reader == null)
                {
                    FormUtility.ShowErrorMessageBox(this, "DataReader has not been generated.");
                    return;
                }

                CsvFileWriter csvWriter = new CsvFileWriter(m_CsvSettings);

                await csvWriter.OutputAsync(reader, filePath, x => ShowProgress(x, generatingCount), cancellation).ConfigureAwait(false);

                FormUtility.ShowMessageBox(this, "done.");
            }
            catch (OperationCanceledException)
            {
                FormUtility.ShowMessageBox(this, "File output has been cancelled.");
            }
            catch (Exception ex)
            {
                FormUtility.ShowErrorMessageBox(this, ex.Message);
            }
        }

        /// <summary>
        /// Generates the specified number of data.
        /// </summary>
        /// <param name="generatingCount"></param>
        /// <returns></returns>
        private async Task<IDataReader?> GenerateDataAsync(int generatingCount)
        {
            if (m_DataGeneratorBuilder == null) { return null; }

            return await m_DataGeneratorBuilder.BuildAsDataReaderAsync(generatingCount).ConfigureAwait(false);
        }

        #endregion

        #region cancellation

        /// <summary>
        /// Gets or sets whether it is running.
        /// </summary>
        private bool IsRunning
        {
            get { return m_IsRunning; }
            set
            {
                if (m_IsRunning == value) { return; }
                m_IsRunning = value;
                OnIsRunningChanged();
            }
        }
        private bool m_IsRunning;

        /// <summary>
        /// Executed when the value of <see cref="IsRunning"/> property changes.
        /// </summary>
        private void OnIsRunningChanged()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(OnIsRunningChanged));
                return;
            }

            m_CancellationToken?.Dispose();
            m_CancellationToken = null;

            if (IsRunning)
            {
                m_CancellationToken = new CancellationTokenSource();
            }

            btnOK.Enabled = !IsRunning;
            btnCancel.Enabled = IsRunning;

            this.Cursor = IsRunning ? Cursors.WaitCursor : Cursors.Default;
        }

        /// <summary>
        /// Gets the cancellation token.
        /// </summary>
        private CancellationToken CurrentCancellationToken
        {
            get
            {
                if (m_CancellationToken == null) { return default; }
                return m_CancellationToken.Token;
            }
        }
        private CancellationTokenSource? m_CancellationToken;

        #endregion

        #region progress

        /// <summary>
        /// Performs initial processing related to progress.
        /// </summary>
        private void InitProgress()
        {
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = 100;

            ClearProgress();
        }

        /// <summary>
        /// Clears the progress.
        /// </summary>
        private void ClearProgress()
        {
            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel1.Text = null;
        }

        /// <summary>
        /// Shows progress.
        /// </summary>
        /// <param name="currentCount"></param>
        /// <param name="totalCount"></param>
        private void ShowProgress(int currentCount, int totalCount)
        {
            if (!FormUtility.NeedProgress(currentCount, totalCount)) { return; }

            if (this.InvokeRequired)
            {
                this.Invoke(new Action<int, int>(ShowProgress), currentCount, totalCount);
                return;
            }

            toolStripProgressBar1.Value = (int)Math.Ceiling((double)currentCount / totalCount * 100);
            toolStripStatusLabel1.Text = $"{currentCount} / {totalCount}";
        }

        #endregion

    }

}