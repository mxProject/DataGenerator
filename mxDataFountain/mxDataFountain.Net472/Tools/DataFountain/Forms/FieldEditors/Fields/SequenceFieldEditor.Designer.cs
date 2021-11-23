
namespace mxProject.Tools.DataFountain.Forms.FieldEditors.Fields
{
    partial class SequenceFieldEditor
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
            this.txtIncrement = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaximumValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInitialValue = new System.Windows.Forms.TextBox();
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
            this.pnlHeader.Controls.Add(this.txtIncrement);
            this.pnlHeader.Controls.Add(this.label5);
            this.pnlHeader.Controls.Add(this.txtMaximumValue);
            this.pnlHeader.Controls.Add(this.label4);
            this.pnlHeader.Controls.Add(this.txtInitialValue);
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
            // txtIncrement
            // 
            this.txtIncrement.Location = new System.Drawing.Point(112, 124);
            this.txtIncrement.Name = "txtIncrement";
            this.txtIncrement.Size = new System.Drawing.Size(208, 20);
            this.txtIncrement.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Increment";
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
            // txtInitialValue
            // 
            this.txtInitialValue.Location = new System.Drawing.Point(112, 68);
            this.txtInitialValue.Name = "txtInitialValue";
            this.txtInitialValue.Size = new System.Drawing.Size(208, 20);
            this.txtInitialValue.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "InitialValue";
            // 
            // SequenceFieldEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlHeader);
            this.Name = "SequenceFieldEditor";
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
        private System.Windows.Forms.TextBox txtInitialValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIncrement;
        private System.Windows.Forms.Label label5;
    }
}
