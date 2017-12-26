namespace DauThau.Forms
{
    partial class frmImportExport
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
            this.panelExport = new DevExpress.XtraEditors.PanelControl();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.lueExport = new DevExpress.XtraEditors.LookUpEdit();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.panelExport)).BeginInit();
            this.panelExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueExport.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelExport
            // 
            this.panelExport.Controls.Add(this.chkAll);
            this.panelExport.Controls.Add(this.labelControl1);
            this.panelExport.Controls.Add(this.btnExport);
            this.panelExport.Controls.Add(this.lueExport);
            this.panelExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExport.Location = new System.Drawing.Point(0, 0);
            this.panelExport.Name = "panelExport";
            this.panelExport.Size = new System.Drawing.Size(500, 76);
            this.panelExport.TabIndex = 0;
            // 
            // chkAll
            // 
            this.chkAll.EditValue = true;
            this.chkAll.Enabled = false;
            this.chkAll.Location = new System.Drawing.Point(93, 51);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "Chọn tất cả các bảng dữ liệu";
            this.chkAll.Size = new System.Drawing.Size(171, 20);
            this.chkAll.TabIndex = 3;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Location = new System.Drawing.Point(12, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(77, 17);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Chọn dữ liệu";
            // 
            // btnExport
            // 
            this.btnExport.Image = global::DauThau.Properties.Resources.file_export;
            this.btnExport.Location = new System.Drawing.Point(361, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(106, 38);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Xuất dữ liệu";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lueExport
            // 
            this.lueExport.Enabled = false;
            this.lueExport.Location = new System.Drawing.Point(95, 19);
            this.lueExport.Name = "lueExport";
            this.lueExport.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueExport.Properties.Appearance.Options.UseFont = true;
            this.lueExport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueExport.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CAPTION", "Dữ liệu")});
            this.lueExport.Properties.DisplayMember = "CAPTION";
            this.lueExport.Properties.NullText = "Vui lòng chọn dữ liệu";
            this.lueExport.Properties.ValueMember = "NAME";
            this.lueExport.Size = new System.Drawing.Size(260, 22);
            this.lueExport.TabIndex = 0;
            // 
            // frmImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 76);
            this.Controls.Add(this.panelExport);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xuất dữ liệu";
            this.Load += new System.EventHandler(this.frmImportExport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelExport)).EndInit();
            this.panelExport.ResumeLayout(false);
            this.panelExport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueExport.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelExport;
        private DevExpress.XtraEditors.LookUpEdit lueExport;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}