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

using mxProject.Devs.DataGeneration;

namespace mxProject.Tools.DataFountain.Forms
{

    /// <summary>
    /// Data preview form.
    /// </summary>
    internal partial class DataPreviewForm : Form
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        internal DataPreviewForm()
        {
            InitializeComponent();

            Init();
        }

        /// <summary>
        /// Performs initial processing.
        /// </summary>
        private void Init()
        {
            InitDataGrid();
            InitProgress();

            this.Load += (sender, e) =>
            {
                if (m_GeneratingCount.HasValue)
                {
                    txtGeneratingCount.Text = m_GeneratingCount.ToString();
                    btnPreview.PerformClick();
                }
            };

            this.btnPreview.Click += async (sender, e) =>
            {
                IsRunning = true;
                await PreviewDataAsync(int.Parse(txtGeneratingCount.Text), CurrentCancellationToken).ConfigureAwait(false);
                IsRunning = false;
            };

            this.btnCancel.Click += (sender, e) =>
            {
                m_CurrentCancellationToken?.Cancel();
            };
        }

        #region showdialog

        /// <summary>
        /// Shows as a modal dialog.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="generatorBuilder"></param>
        /// <param name="generatingCount"></param>
        /// <returns></returns>
        internal DialogResult ShowDialog(IWin32Window owner, DataGeneratorBuilder generatorBuilder, int? generatingCount)
        {
            try
            {
                m_DataGeneratorBuilder = generatorBuilder;
                m_GeneratingCount = generatingCount;

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
                m_GeneratingCount = null;
            }
        }

        private DataGeneratorBuilder m_DataGeneratorBuilder = null!;
        private int? m_GeneratingCount = null;

        #endregion

        #region grid

        /// <summary>
        /// Initializes the data grid.
        /// </summary>
        private void InitDataGrid()
        {
            gridPreview.CellValueNeeded += (sender, e) =>
            {
                if (GridDataSource == null) { return; }

                if (e.ColumnIndex < 0) { return; }
                if (e.RowIndex < 0 || GridDataSource.Rows.Count <= e.RowIndex) { return; }

                e.Value = GridDataSource.Rows[e.RowIndex][e.ColumnIndex];
            };

            gridPreview.CellPainting += (sender, e) =>
            {
                if (e.ColumnIndex < 0 && e.RowIndex >= 0)
                {
                    e.Paint(e.ClipBounds, DataGridViewPaintParts.All);

                    Rectangle indexRect = e.CellBounds;
                    indexRect.Inflate(-2, -2);

                    TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, indexRect, e.CellStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                    e.Handled = true;
                }
            };

            gridPreview.ReadOnly = true;
            gridPreview.AllowUserToAddRows = false;
            gridPreview.AllowUserToDeleteRows = false;
            gridPreview.VirtualMode = true;
            gridPreview.RowCount = 0;
        }

        /// <summary>
        /// Gets or sets the data source for the data grid.
        /// </summary>
        private DataTable? GridDataSource
        {
            get { return m_GridDataSource; }
            set
            {
                if (m_GridDataSource == value) { return; }

                DataTable? prev = value;

                m_GridDataSource = value;

                if (m_GridDataSource == null)
                {
                    gridPreview.Columns.Clear();
                    gridPreview.RowCount = 0;
                }
                else
                {
                    foreach (DataColumn column in m_GridDataSource.Columns)
                    {
                        gridPreview.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            HeaderText = column.ColumnName,
                            ValueType = column.DataType
                        });
                    }

                    gridPreview.RowCount = m_GridDataSource.Rows.Count;
                }

                prev?.Dispose();
            }
        }
        private DataTable? m_GridDataSource;

        #endregion

        #region data generation

        /// <summary>
        /// Generates the specified number of data and displays it in the grid.
        /// </summary>
        /// <param name="generatingCount"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        private async Task PreviewDataAsync(int generatingCount, CancellationToken cancellation)
        {
            try
            {
                DataTable? table = await GenerateDataAsync(generatingCount, cancellation).ConfigureAwait(false);

                ShowPreviewData(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowPreviewData(DataTable? table)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<DataTable>(ShowPreviewData), table);
                return;
            }

            this.GridDataSource = table;
        }

        /// <summary>
        /// Generates the specified number of data.
        /// </summary>
        /// <param name="generatingCount"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        private async Task<DataTable?> GenerateDataAsync(int generatingCount, CancellationToken cancellation)
        {
            static Type ToGridColumnType(Type valueType)
            {
                if (valueType == typeof(StringValue)) { return typeof(string); }
                return valueType;
            }

            if (m_DataGeneratorBuilder == null) { return null; }

            using var reader = await m_DataGeneratorBuilder.BuildAsDataReaderAsync(generatingCount).ConfigureAwait(false);

            using DataTable table = new();

            for (int i = 0; i < reader.FieldCount; ++i)
            {
                table.Columns.Add(reader.GetName(i), ToGridColumnType(reader.GetFieldType(i)));
            }

            int count = 0;

            while (reader.Read())
            {
                if (cancellation.IsCancellationRequested) { break; }

                object[] values = new object[reader.FieldCount];

                reader.GetValues(values);

                table.Rows.Add(values);

                ++count;

                if (FormUtility.NeedProgress(count, generatingCount))
                {
                    await Task.Delay(1).ConfigureAwait(false);
                    ShowProgress(count, generatingCount);
                }
            }

            return table;
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

            lock (this)
            {
                m_CurrentCancellationToken?.Dispose();
                m_CurrentCancellationToken = null;

                if (IsRunning)
                {
                    m_CurrentCancellationToken = new CancellationTokenSource();
                }
            }

            btnPreview.Enabled = !IsRunning;
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
                if (m_CurrentCancellationToken == null) { return default; }
                return m_CurrentCancellationToken.Token;
            }
        }
        private CancellationTokenSource? m_CurrentCancellationToken;

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
