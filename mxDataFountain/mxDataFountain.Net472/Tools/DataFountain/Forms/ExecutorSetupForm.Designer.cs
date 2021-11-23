
namespace mxProject.Tools.DataFountain.Forms
{
    partial class ExecutorSetupForm
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
            this.btnSearchFilePath = new System.Windows.Forms.Button();
            this.btnAddAssembly = new System.Windows.Forms.Button();
            this.txtNewAssemblyFilePath = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtContextActivatorTypeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grdAssemblies = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.colAssemblyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssemblyFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBody.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAssemblies)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.btnSearchFilePath);
            this.pnlBody.Controls.Add(this.btnAddAssembly);
            this.pnlBody.Controls.Add(this.txtNewAssemblyFilePath);
            this.pnlBody.Controls.Add(this.panel1);
            this.pnlBody.Controls.Add(this.label2);
            this.pnlBody.Controls.Add(this.grdAssemblies);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(686, 364);
            this.pnlBody.TabIndex = 0;
            // 
            // btnSearchFilePath
            // 
            this.btnSearchFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchFilePath.Image = global::mxProject.Properties.Resources.Search;
            this.btnSearchFilePath.Location = new System.Drawing.Point(544, 40);
            this.btnSearchFilePath.Name = "btnSearchFilePath";
            this.btnSearchFilePath.Size = new System.Drawing.Size(40, 24);
            this.btnSearchFilePath.TabIndex = 1;
            this.btnSearchFilePath.UseVisualStyleBackColor = true;
            // 
            // btnAddAssembly
            // 
            this.btnAddAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAssembly.Location = new System.Drawing.Point(594, 32);
            this.btnAddAssembly.Name = "btnAddAssembly";
            this.btnAddAssembly.Size = new System.Drawing.Size(73, 32);
            this.btnAddAssembly.TabIndex = 2;
            this.btnAddAssembly.Text = "Add";
            this.btnAddAssembly.UseVisualStyleBackColor = true;
            // 
            // txtNewAssemblyFilePath
            // 
            this.txtNewAssemblyFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewAssemblyFilePath.Location = new System.Drawing.Point(17, 42);
            this.txtNewAssemblyFilePath.Name = "txtNewAssemblyFilePath";
            this.txtNewAssemblyFilePath.Size = new System.Drawing.Size(523, 22);
            this.txtNewAssemblyFilePath.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtContextActivatorTypeName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 286);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 78);
            this.panel1.TabIndex = 1;
            // 
            // txtContextActivatorTypeName
            // 
            this.txtContextActivatorTypeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContextActivatorTypeName.Location = new System.Drawing.Point(18, 37);
            this.txtContextActivatorTypeName.Name = "txtContextActivatorTypeName";
            this.txtContextActivatorTypeName.Size = new System.Drawing.Size(649, 22);
            this.txtContextActivatorTypeName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "DataGeneratorContextActivator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "ReferenceAssembly";
            // 
            // grdAssemblies
            // 
            this.grdAssemblies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAssemblies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAssemblies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAssemblyName,
            this.colAssemblyFilePath});
            this.grdAssemblies.Location = new System.Drawing.Point(18, 74);
            this.grdAssemblies.Name = "grdAssemblies";
            this.grdAssemblies.RowTemplate.Height = 21;
            this.grdAssemblies.Size = new System.Drawing.Size(650, 198);
            this.grdAssemblies.TabIndex = 3;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnOK);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 364);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(686, 55);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(568, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(452, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(104, 30);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // colAssemblyName
            // 
            this.colAssemblyName.HeaderText = "AssemblyName";
            this.colAssemblyName.Name = "colAssemblyName";
            this.colAssemblyName.Width = 200;
            // 
            // colAssemblyFilePath
            // 
            this.colAssemblyFilePath.HeaderText = "FilePath";
            this.colAssemblyFilePath.Name = "colAssemblyFilePath";
            this.colAssemblyFilePath.Width = 400;
            // 
            // ExecutorSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 419);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "ExecutorSetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExecutorSetup";
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAssemblies)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtContextActivatorTypeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdAssemblies;
        private System.Windows.Forms.Button btnAddAssembly;
        private System.Windows.Forms.TextBox txtNewAssemblyFilePath;
        private System.Windows.Forms.Button btnSearchFilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssemblyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssemblyFilePath;
    }
}