
namespace mxProject.Tools.DataFountain.Forms.FieldEditors.Fields
{
    partial class RandomFieldEditor
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.txtSelectorExpression = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaximumValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMinimumValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
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
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.txtSelectorExpression);
            this.pnlHeader.Controls.Add(this.label5);
            this.pnlHeader.Controls.Add(this.txtMaximumValue);
            this.pnlHeader.Controls.Add(this.label4);
            this.pnlHeader.Controls.Add(this.txtMinimumValue);
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.cmbValueType);
            this.pnlHeader.Controls.Add(this.txtNullProbability);
            this.pnlHeader.Controls.Add(this.label3);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(369, 220);
            this.pnlHeader.TabIndex = 8;
            // 
            // txtSelectorExpression
            // 
            this.txtSelectorExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectorExpression.Location = new System.Drawing.Point(112, 124);
            this.txtSelectorExpression.Name = "txtSelectorExpression";
            this.txtSelectorExpression.Size = new System.Drawing.Size(244, 20);
            this.txtSelectorExpression.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Selector";
            // 
            // txtMaximumValue
            // 
            this.txtMaximumValue.Location = new System.Drawing.Point(112, 96);
            this.txtMaximumValue.Name = "txtMaximumValue";
            this.txtMaximumValue.Size = new System.Drawing.Size(208, 20);
            this.txtMaximumValue.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "MaximumValue";
            // 
            // txtMinimumValue
            // 
            this.txtMinimumValue.Location = new System.Drawing.Point(112, 68);
            this.txtMinimumValue.Name = "txtMinimumValue";
            this.txtMinimumValue.Size = new System.Drawing.Size(208, 20);
            this.txtMinimumValue.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "MinimumValue";
            // 
            // RandomFieldEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlHeader);
            this.Name = "RandomFieldEditor";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbValueType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNullProbability;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.TextBox txtMaximumValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMinimumValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSelectorExpression;
        private System.Windows.Forms.Label label5;
    }
}
