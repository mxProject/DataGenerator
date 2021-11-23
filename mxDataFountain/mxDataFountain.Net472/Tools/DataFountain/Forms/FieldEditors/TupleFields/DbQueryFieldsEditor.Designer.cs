
namespace mxProject.Tools.DataFountain.Forms.FieldEditors.TupleFields
{
    partial class DbQueryFieldsEditor
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.grdFields = new System.Windows.Forms.DataGridView();
            this.colFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dbQueryEditor = new mxProject.Tools.DataFountain.Forms.FieldEditors.DbQueryEditor();
            ((System.ComponentModel.ISupportInitialize)(this.grdFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fields";
            // 
            // grdFields
            // 
            this.grdFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFieldName});
            this.grdFields.Location = new System.Drawing.Point(148, 14);
            this.grdFields.Name = "grdFields";
            this.grdFields.RowTemplate.Height = 21;
            this.grdFields.Size = new System.Drawing.Size(474, 321);
            this.grdFields.TabIndex = 0;
            // 
            // colFieldName
            // 
            this.colFieldName.HeaderText = "FieldName";
            this.colFieldName.Name = "colFieldName";
            this.colFieldName.Width = 150;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grdFields);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dbQueryEditor);
            this.splitContainer1.Size = new System.Drawing.Size(634, 550);
            this.splitContainer1.SplitterDistance = 348;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 9;
            // 
            // dbQueryEditor
            // 
            this.dbQueryEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbQueryEditor.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dbQueryEditor.Location = new System.Drawing.Point(0, 0);
            this.dbQueryEditor.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.dbQueryEditor.Name = "dbQueryEditor";
            this.dbQueryEditor.Size = new System.Drawing.Size(634, 197);
            this.dbQueryEditor.TabIndex = 0;
            // 
            // DbQueryFieldsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "DbQueryFieldsEditor";
            this.Size = new System.Drawing.Size(634, 550);
            ((System.ComponentModel.ISupportInitialize)(this.grdFields)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdFields;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFieldName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DbQueryEditor dbQueryEditor;
    }
}
