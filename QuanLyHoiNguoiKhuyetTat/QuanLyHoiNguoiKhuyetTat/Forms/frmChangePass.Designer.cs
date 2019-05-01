namespace DauThau.Forms
{
    partial class frmChangePass
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassNew = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPassOld = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btDangNhap = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassConfirm = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassNew.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassOld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassConfirm.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl3.Location = new System.Drawing.Point(111, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(167, 24);
            this.labelControl3.TabIndex = 19;
            this.labelControl3.Text = "Thay đổi mật khẩu";
            // 
            // btThoat
            // 
            this.btThoat.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThoat.Appearance.Options.UseFont = true;
            this.btThoat.Image = global::DauThau.Properties.Resources.btnExit;
            this.btThoat.Location = new System.Drawing.Point(265, 140);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(102, 35);
            this.btThoat.TabIndex = 3;
            this.btThoat.Text = "Thoát";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // txtPassNew
            // 
            this.txtPassNew.EditValue = "";
            this.txtPassNew.EnterMoveNextControl = true;
            this.txtPassNew.Location = new System.Drawing.Point(157, 81);
            this.txtPassNew.Name = "txtPassNew";
            this.txtPassNew.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassNew.Properties.Appearance.Options.UseFont = true;
            this.txtPassNew.Properties.PasswordChar = '*';
            this.txtPassNew.Size = new System.Drawing.Size(210, 24);
            this.txtPassNew.TabIndex = 1;
            this.txtPassNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPass_KeyDown);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(17, 89);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(77, 16);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "Mật khẩu mới";
            // 
            // txtPassOld
            // 
            this.txtPassOld.EditValue = "";
            this.txtPassOld.EnterMoveNextControl = true;
            this.txtPassOld.Location = new System.Drawing.Point(157, 52);
            this.txtPassOld.Name = "txtPassOld";
            this.txtPassOld.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassOld.Properties.Appearance.Options.UseFont = true;
            this.txtPassOld.Properties.PasswordChar = '*';
            this.txtPassOld.Size = new System.Drawing.Size(210, 24);
            this.txtPassOld.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(17, 60);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(69, 16);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Mật khẩu cũ";
            // 
            // btDangNhap
            // 
            this.btDangNhap.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDangNhap.Appearance.Options.UseFont = true;
            this.btDangNhap.Image = global::DauThau.Properties.Resources._lock;
            this.btDangNhap.Location = new System.Drawing.Point(157, 140);
            this.btDangNhap.Name = "btDangNhap";
            this.btDangNhap.Size = new System.Drawing.Size(102, 35);
            this.btDangNhap.TabIndex = 2;
            this.btDangNhap.Text = "Cập nhật";
            this.btDangNhap.Click += new System.EventHandler(this.btDangNhap_Click);
            // 
            // txtPassConfirm
            // 
            this.txtPassConfirm.EditValue = "";
            this.txtPassConfirm.EnterMoveNextControl = true;
            this.txtPassConfirm.Location = new System.Drawing.Point(157, 110);
            this.txtPassConfirm.Name = "txtPassConfirm";
            this.txtPassConfirm.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassConfirm.Properties.Appearance.Options.UseFont = true;
            this.txtPassConfirm.Properties.PasswordChar = '*';
            this.txtPassConfirm.Size = new System.Drawing.Size(210, 24);
            this.txtPassConfirm.TabIndex = 20;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(17, 118);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(127, 16);
            this.labelControl4.TabIndex = 21;
            this.labelControl4.Text = "Xác nhận lại mật khẩu";
            // 
            // frmChangePass
            // 
            this.AcceptButton = this.btDangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 187);
            this.ControlBox = false;
            this.Controls.Add(this.txtPassConfirm);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.btDangNhap);
            this.Controls.Add(this.txtPassNew);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtPassOld);
            this.Controls.Add(this.labelControl1);
            this.LookAndFeel.SkinName = "Summer 2008";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmChangePass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi mật khẩu";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPassNew.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassOld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassConfirm.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btThoat;
        private DevExpress.XtraEditors.SimpleButton btDangNhap;
        private DevExpress.XtraEditors.TextEdit txtPassNew;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtPassOld;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPassConfirm;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}