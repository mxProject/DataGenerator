
namespace mxProject.Tools.DataFountain.Forms.FieldEditors.Fields
{
    partial class DbQueryFieldEditor
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
            this.dbQueryEditor = new mxProject.Tools.DataFountain.Forms.FieldEditors.DbQueryEditor();
            this.SuspendLayout();
            // 
            // dbQueryEditor
            // 
            this.dbQueryEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbQueryEditor.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dbQueryEditor.Location = new System.Drawing.Point(0, 0);
            this.dbQueryEditor.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.dbQueryEditor.Name = "dbQueryEditor";
            this.dbQueryEditor.Size = new System.Drawing.Size(565, 272);
            this.dbQueryEditor.TabIndex = 0;
            // 
            // DbQueryFieldEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dbQueryEditor);
            this.Name = "DbQueryFieldEditor";
            this.Size = new System.Drawing.Size(565, 272);
            this.ResumeLayout(false);

        }

        #endregion

        private DbQueryEditor dbQueryEditor;
    }
}
