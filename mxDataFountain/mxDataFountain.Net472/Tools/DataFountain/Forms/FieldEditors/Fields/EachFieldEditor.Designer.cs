
namespace mxProject.Tools.DataFountain.Forms.FieldEditors.Fields
{
    partial class EachFieldEditor
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
            this.cmbValueType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNullProbability = new System.Windows.Forms.TextBox();
            this.grdValues = new System.Windows.Forms.DataGridView();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdValues)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ValueType";
            // 
            // cmbValueType
            // 
            this.cmbValueType.FormattingEnabled = true;
            this.cmbValueType.Location = new System.Drawing.Point(112, 9);
            this.cmbValueType.Name = "cmbValueType";
            this.cmbValueType.Size = new System.Drawing.Size(209, 21);
            this.cmbValueType.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "NullProbability";
            // 
            // txtNullProbability
            // 
            this.txtNullProbability.Location = new System.Drawing.Point(112, 39);
            this.txtNullProbability.Name = "txtNullProbability";
            this.txtNullProbability.Size = new System.Drawing.Size(93, 20);
            this.txtNullProbability.TabIndex = 1;
            this.txtNullProbability.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grdValues
            // 
            this.grdValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdValues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colValue});
            this.grdValues.Location = new System.Drawing.Point(112, 9);
            this.grdValues.Name = "grdValues";
            this.grdValues.RowTemplate.Height = 21;
            this.grdValues.Size = new System.Drawing.Size(247, 265);
            this.grdValues.TabIndex = 0;
            // 
            // colValue
            // 
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Values";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.cmbValueType);
            this.pnlHeader.Controls.Add(this.txtNullProbability);
            this.pnlHeader.Controls.Add(this.label3);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(369, 69);
            this.pnlHeader.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdValues);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 286);
            this.panel1.TabIndex = 1;
            // 
            // EachFieldEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlHeader);
            this.Name = "EachFieldEditor";
            ((System.ComponentModel.ISupportInitialize)(this.grdValues)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbValueType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNullProbability;
        private System.Windows.Forms.DataGridView grdValues;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel panel1;
    }
}
