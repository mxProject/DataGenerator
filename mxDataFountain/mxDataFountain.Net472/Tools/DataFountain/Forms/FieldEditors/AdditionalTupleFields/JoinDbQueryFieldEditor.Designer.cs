
namespace mxProject.Tools.DataFountain.Forms.FieldEditors.AdditionalTupleFields
{
    partial class JoinDbQueryFieldEditor
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdKeyFields = new System.Windows.Forms.DataGridView();
            this.colReferenceKeyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdditionalKeyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grdAdditionalFields = new System.Windows.Forms.DataGridView();
            this.colAdditionalFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbQueryEditor = new mxProject.Tools.DataFountain.Forms.FieldEditors.DbQueryEditor();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKeyFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAdditionalFields)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "AdditionalFields";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grdKeyFields);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(603, 513);
            this.splitContainer1.SplitterDistance = 98;
            this.splitContainer1.TabIndex = 0;
            // 
            // grdKeyFields
            // 
            this.grdKeyFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdKeyFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdKeyFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReferenceKeyName,
            this.colAdditionalKeyName});
            this.grdKeyFields.Location = new System.Drawing.Point(112, 12);
            this.grdKeyFields.Name = "grdKeyFields";
            this.grdKeyFields.RowTemplate.Height = 21;
            this.grdKeyFields.Size = new System.Drawing.Size(480, 77);
            this.grdKeyFields.TabIndex = 0;
            // 
            // colReferenceKeyName
            // 
            this.colReferenceKeyName.HeaderText = "ReferenceKeyName";
            this.colReferenceKeyName.Name = "colReferenceKeyName";
            this.colReferenceKeyName.Width = 150;
            // 
            // colAdditionalKeyName
            // 
            this.colAdditionalKeyName.HeaderText = "AdditionalKeyName";
            this.colAdditionalKeyName.Name = "colAdditionalKeyName";
            this.colAdditionalKeyName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAdditionalKeyName.Width = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "KeyFields";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.grdAdditionalFields);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dbQueryEditor);
            this.splitContainer2.Size = new System.Drawing.Size(603, 411);
            this.splitContainer2.SplitterDistance = 235;
            this.splitContainer2.TabIndex = 0;
            // 
            // grdAdditionalFields
            // 
            this.grdAdditionalFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAdditionalFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAdditionalFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAdditionalFieldName});
            this.grdAdditionalFields.Location = new System.Drawing.Point(112, 8);
            this.grdAdditionalFields.Name = "grdAdditionalFields";
            this.grdAdditionalFields.RowTemplate.Height = 21;
            this.grdAdditionalFields.Size = new System.Drawing.Size(480, 214);
            this.grdAdditionalFields.TabIndex = 0;
            // 
            // colAdditionalFieldName
            // 
            this.colAdditionalFieldName.HeaderText = "FieldName";
            this.colAdditionalFieldName.Name = "colAdditionalFieldName";
            this.colAdditionalFieldName.Width = 150;
            // 
            // dbQueryEditor
            // 
            this.dbQueryEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbQueryEditor.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dbQueryEditor.Location = new System.Drawing.Point(0, 0);
            this.dbQueryEditor.Name = "dbQueryEditor";
            this.dbQueryEditor.Size = new System.Drawing.Size(603, 172);
            this.dbQueryEditor.TabIndex = 0;
            // 
            // JoinDbQueryFieldEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "JoinDbQueryFieldEditor";
            this.Size = new System.Drawing.Size(603, 513);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKeyFields)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAdditionalFields)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdAdditionalFields;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView grdKeyFields;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdditionalFieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReferenceKeyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdditionalKeyName;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private DbQueryEditor dbQueryEditor;
    }
}
