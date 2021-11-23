
namespace mxProject.Tools.DataFountain.Forms
{
    partial class DataGeneratorEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataGeneratorEditorForm));
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnOutputCsv = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.SplitContainer();
            this.treeFields = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadProjectSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadDataGeneratorSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAsProjectSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAsDataGeneratorSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExecutorSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCsvSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.Panel1.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnOutputCsv);
            this.pnlFooter.Controls.Add(this.btnPreview);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(5, 604);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(974, 52);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnOutputCsv
            // 
            this.btnOutputCsv.Location = new System.Drawing.Point(128, 12);
            this.btnOutputCsv.Name = "btnOutputCsv";
            this.btnOutputCsv.Size = new System.Drawing.Size(103, 29);
            this.btnOutputCsv.TabIndex = 1;
            this.btnOutputCsv.Text = "CSV";
            this.btnOutputCsv.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(12, 12);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(103, 29);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(5, 33);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(974, 11);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlBody
            // 
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(5, 44);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBody.Name = "pnlBody";
            // 
            // pnlBody.Panel1
            // 
            this.pnlBody.Panel1.Controls.Add(this.treeFields);
            this.pnlBody.Size = new System.Drawing.Size(974, 560);
            this.pnlBody.SplitterDistance = 323;
            this.pnlBody.SplitterWidth = 5;
            this.pnlBody.TabIndex = 1;
            // 
            // treeFields
            // 
            this.treeFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFields.Location = new System.Drawing.Point(0, 0);
            this.treeFields.Margin = new System.Windows.Forms.Padding(4);
            this.treeFields.Name = "treeFields";
            this.treeFields.Size = new System.Drawing.Size(323, 560);
            this.treeFields.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuSettings,
            this.mnuVersion});
            this.menuStrip1.Location = new System.Drawing.Point(5, 5);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(974, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewProject,
            this.mnuLoadProjectSettings,
            this.mnuLoadDataGeneratorSettings,
            this.mnuSaveAsProjectSettings,
            this.mnuSaveAsDataGeneratorSettings});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(65, 24);
            this.mnuFile.Text = "File (&F)";
            // 
            // mnuNewProject
            // 
            this.mnuNewProject.Name = "mnuNewProject";
            this.mnuNewProject.Size = new System.Drawing.Size(282, 24);
            this.mnuNewProject.Text = "New Project";
            // 
            // mnuLoadProjectSettings
            // 
            this.mnuLoadProjectSettings.Name = "mnuLoadProjectSettings";
            this.mnuLoadProjectSettings.Size = new System.Drawing.Size(282, 24);
            this.mnuLoadProjectSettings.Text = "Load ProjectSettings";
            // 
            // mnuLoadDataGeneratorSettings
            // 
            this.mnuLoadDataGeneratorSettings.Name = "mnuLoadDataGeneratorSettings";
            this.mnuLoadDataGeneratorSettings.Size = new System.Drawing.Size(282, 24);
            this.mnuLoadDataGeneratorSettings.Text = "Load DataGeneratorSettings";
            // 
            // mnuSaveAsProjectSettings
            // 
            this.mnuSaveAsProjectSettings.Name = "mnuSaveAsProjectSettings";
            this.mnuSaveAsProjectSettings.Size = new System.Drawing.Size(282, 24);
            this.mnuSaveAsProjectSettings.Text = "Save as ProjectSettings";
            // 
            // mnuSaveAsDataGeneratorSettings
            // 
            this.mnuSaveAsDataGeneratorSettings.Name = "mnuSaveAsDataGeneratorSettings";
            this.mnuSaveAsDataGeneratorSettings.Size = new System.Drawing.Size(282, 24);
            this.mnuSaveAsDataGeneratorSettings.Text = "Save as DataGeneratorSettings";
            // 
            // mnuSettings
            // 
            this.mnuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExecutorSetup,
            this.mnuCsvSettings});
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(96, 24);
            this.mnuSettings.Text = "Settings (&S)";
            // 
            // mnuExecutorSetup
            // 
            this.mnuExecutorSetup.Name = "mnuExecutorSetup";
            this.mnuExecutorSetup.Size = new System.Drawing.Size(177, 24);
            this.mnuExecutorSetup.Text = "Executor Setup";
            // 
            // mnuCsvSettings
            // 
            this.mnuCsvSettings.Name = "mnuCsvSettings";
            this.mnuCsvSettings.Size = new System.Drawing.Size(177, 24);
            this.mnuCsvSettings.Text = "Csv Settings";
            // 
            // mnuVersion
            // 
            this.mnuVersion.Name = "mnuVersion";
            this.mnuVersion.Size = new System.Drawing.Size(92, 24);
            this.mnuVersion.Text = "Version (&V)";
            // 
            // DataGeneratorEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DataGeneratorEditorForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mxDataFountain";
            this.pnlFooter.ResumeLayout(false);
            this.pnlBody.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.SplitContainer pnlBody;
        private System.Windows.Forms.TreeView treeFields;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnOutputCsv;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAsProjectSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAsDataGeneratorSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuLoadProjectSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuLoadDataGeneratorSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuVersion;
        private System.Windows.Forms.ToolStripMenuItem mnuNewProject;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuExecutorSetup;
        private System.Windows.Forms.ToolStripMenuItem mnuCsvSettings;
    }
}