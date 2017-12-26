namespace DauThau.UserControlCategoryMain
{
    partial class frmImportDataTaiChinh
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
            this.panelImport = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPath = new DevExpress.XtraEditors.TextEdit();
            this.btnNap = new DevExpress.XtraEditors.SimpleButton();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelImport)).BeginInit();
            this.panelImport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelImport
            // 
            this.panelImport.Controls.Add(this.labelControl2);
            this.panelImport.Controls.Add(this.txtPath);
            this.panelImport.Controls.Add(this.btnNap);
            this.panelImport.Controls.Add(this.btnBrowse);
            this.panelImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImport.Location = new System.Drawing.Point(0, 0);
            this.panelImport.Name = "panelImport";
            this.panelImport.Size = new System.Drawing.Size(614, 62);
            this.panelImport.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Location = new System.Drawing.Point(12, 22);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 17);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Chọn file";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(78, 20);
            this.txtPath.Name = "txtPath";
            this.txtPath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPath.Properties.Appearance.Options.UseFont = true;
            this.txtPath.Size = new System.Drawing.Size(335, 22);
            this.txtPath.TabIndex = 1;
            // 
            // btnNap
            // 
            this.btnNap.Enabled = false;
            this.btnNap.Image = global::DauThau.Properties.Resources.file_import;
            this.btnNap.Location = new System.Drawing.Point(500, 12);
            this.btnNap.Name = "btnNap";
            this.btnNap.Size = new System.Drawing.Size(108, 38);
            this.btnNap.TabIndex = 0;
            this.btnNap.Text = "Nhập dữ liệu";
            this.btnNap.Click += new System.EventHandler(this.btnNap_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Image = global::DauThau.Properties.Resources.Folders;
            this.btnBrowse.Location = new System.Drawing.Point(419, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 38);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // frmImportDataTaiChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 62);
            this.Controls.Add(this.panelImport);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportDataTaiChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nạp dữ liệu điểm tài chính";
            this.Load += new System.EventHandler(this.frmImportData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelImport)).EndInit();
            this.panelImport.ResumeLayout(false);
            this.panelImport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelImport;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtPath;
        private DevExpress.XtraEditors.SimpleButton btnNap;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
    }
}