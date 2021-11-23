
namespace mxProject.Tools.DataFountain.Forms
{
    partial class CsvSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlShouldQuote = new System.Windows.Forms.Panel();
            this.rdoShouldQuoteOnlyWhenNeeded = new System.Windows.Forms.RadioButton();
            this.rdoShouldQuoteAlways = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbNewLine = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEncoding = new System.Windows.Forms.ComboBox();
            this.chkWithHeader = new System.Windows.Forms.CheckBox();
            this.txtQuote = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cmbDelimiter = new System.Windows.Forms.ComboBox();
            this.pnlBody.SuspendLayout();
            this.pnlShouldQuote.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.cmbDelimiter);
            this.pnlBody.Controls.Add(this.pnlShouldQuote);
            this.pnlBody.Controls.Add(this.label4);
            this.pnlBody.Controls.Add(this.cmbNewLine);
            this.pnlBody.Controls.Add(this.label3);
            this.pnlBody.Controls.Add(this.cmbEncoding);
            this.pnlBody.Controls.Add(this.chkWithHeader);
            this.pnlBody.Controls.Add(this.txtQuote);
            this.pnlBody.Controls.Add(this.label2);
            this.pnlBody.Controls.Add(this.label1);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(479, 190);
            this.pnlBody.TabIndex = 0;
            // 
            // pnlShouldQuote
            // 
            this.pnlShouldQuote.Controls.Add(this.rdoShouldQuoteOnlyWhenNeeded);
            this.pnlShouldQuote.Controls.Add(this.rdoShouldQuoteAlways);
            this.pnlShouldQuote.Location = new System.Drawing.Point(196, 40);
            this.pnlShouldQuote.Name = "pnlShouldQuote";
            this.pnlShouldQuote.Size = new System.Drawing.Size(268, 28);
            this.pnlShouldQuote.TabIndex = 2;
            // 
            // rdoShouldQuoteOnlyWhenNeeded
            // 
            this.rdoShouldQuoteOnlyWhenNeeded.AutoSize = true;
            this.rdoShouldQuoteOnlyWhenNeeded.Location = new System.Drawing.Point(4, 4);
            this.rdoShouldQuoteOnlyWhenNeeded.Name = "rdoShouldQuoteOnlyWhenNeeded";
            this.rdoShouldQuoteOnlyWhenNeeded.Size = new System.Drawing.Size(137, 19);
            this.rdoShouldQuoteOnlyWhenNeeded.TabIndex = 8;
            this.rdoShouldQuoteOnlyWhenNeeded.TabStop = true;
            this.rdoShouldQuoteOnlyWhenNeeded.Text = "OnlyWhenNeeded";
            this.rdoShouldQuoteOnlyWhenNeeded.UseVisualStyleBackColor = true;
            // 
            // rdoShouldQuoteAlways
            // 
            this.rdoShouldQuoteAlways.AutoSize = true;
            this.rdoShouldQuoteAlways.Location = new System.Drawing.Point(152, 4);
            this.rdoShouldQuoteAlways.Name = "rdoShouldQuoteAlways";
            this.rdoShouldQuoteAlways.Size = new System.Drawing.Size(68, 19);
            this.rdoShouldQuoteAlways.TabIndex = 9;
            this.rdoShouldQuoteAlways.TabStop = true;
            this.rdoShouldQuoteAlways.Text = "Always";
            this.rdoShouldQuoteAlways.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "NewLine";
            // 
            // cmbNewLine
            // 
            this.cmbNewLine.FormattingEnabled = true;
            this.cmbNewLine.Location = new System.Drawing.Point(100, 72);
            this.cmbNewLine.Name = "cmbNewLine";
            this.cmbNewLine.Size = new System.Drawing.Size(121, 23);
            this.cmbNewLine.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Encoding";
            // 
            // cmbEncoding
            // 
            this.cmbEncoding.FormattingEnabled = true;
            this.cmbEncoding.Location = new System.Drawing.Point(100, 100);
            this.cmbEncoding.Name = "cmbEncoding";
            this.cmbEncoding.Size = new System.Drawing.Size(121, 23);
            this.cmbEncoding.TabIndex = 4;
            // 
            // chkWithHeader
            // 
            this.chkWithHeader.AutoSize = true;
            this.chkWithHeader.Location = new System.Drawing.Point(20, 140);
            this.chkWithHeader.Name = "chkWithHeader";
            this.chkWithHeader.Size = new System.Drawing.Size(98, 19);
            this.chkWithHeader.TabIndex = 5;
            this.chkWithHeader.Text = "WithHeader";
            this.chkWithHeader.UseVisualStyleBackColor = true;
            // 
            // txtQuote
            // 
            this.txtQuote.Location = new System.Drawing.Point(100, 44);
            this.txtQuote.Name = "txtQuote";
            this.txtQuote.Size = new System.Drawing.Size(80, 22);
            this.txtQuote.TabIndex = 1;
            this.txtQuote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quote";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Delimiter";
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnOK);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 190);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(479, 55);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(361, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(245, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(104, 30);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // cmbDelimiter
            // 
            this.cmbDelimiter.FormattingEnabled = true;
            this.cmbDelimiter.Location = new System.Drawing.Point(100, 16);
            this.cmbDelimiter.Name = "cmbDelimiter";
            this.cmbDelimiter.Size = new System.Drawing.Size(121, 23);
            this.cmbDelimiter.TabIndex = 8;
            // 
            // CsvSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 245);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CsvSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CsvSettings";
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlShouldQuote.ResumeLayout(false);
            this.pnlShouldQuote.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEncoding;
        private System.Windows.Forms.CheckBox chkWithHeader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbNewLine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoShouldQuoteOnlyWhenNeeded;
        private System.Windows.Forms.RadioButton rdoShouldQuoteAlways;
        private System.Windows.Forms.Panel pnlShouldQuote;
        private System.Windows.Forms.ComboBox cmbDelimiter;
    }
}