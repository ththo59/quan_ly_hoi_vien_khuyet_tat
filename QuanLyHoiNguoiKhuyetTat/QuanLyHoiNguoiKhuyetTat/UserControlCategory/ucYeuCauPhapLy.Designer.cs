namespace DauThau.UserControlCategory
{
    partial class ucYeuCauPhapLy
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.buttonsArray1 = new ControlsLib.ButtonsArray();
            this.richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.buttonsArray1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 481);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(803, 60);
            this.panelControl1.TabIndex = 24;
            this.panelControl1.Visible = false;
            // 
            // buttonsArray1
            // 
            this.buttonsArray1.btnBackColor = System.Drawing.Color.Transparent;
            this.buttonsArray1.btnSize = new System.Drawing.Size(75, 36);
            this.buttonsArray1.btnStyleGroup = ControlsLib.ButtonsArray.StyleGroupEnum.None;
            this.buttonsArray1.ButtonAddEnabled = true;
            this.buttonsArray1.ButtonAddVisible = false;
            this.buttonsArray1.ButtonBackgroundImage = null;
            this.buttonsArray1.ButtonCancelEnabled = true;
            this.buttonsArray1.ButtonCloseEnabled = true;
            this.buttonsArray1.ButtonCloseVisible = false;
            this.buttonsArray1.ButtonDeleteEnabled = true;
            this.buttonsArray1.ButtonDeleteVisible = true;
            this.buttonsArray1.ButtonExcelEnabled = true;
            this.buttonsArray1.ButtonExcelVisible = false;
            this.buttonsArray1.ButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.buttonsArray1.ButtonModifyEnabled = true;
            this.buttonsArray1.ButtonModifyText = ControlsLib.ButtonsArray.UpdateEnum.Modify;
            this.buttonsArray1.ButtonModifyVisible = true;
            this.buttonsArray1.ButtonPrintEnabled = true;
            this.buttonsArray1.ButtonPrintVisible = false;
            this.buttonsArray1.ButtonReportEnabled = true;
            this.buttonsArray1.ButtonReportVisible = false;
            this.buttonsArray1.ButtonSaveEnabled = true;
            this.buttonsArray1.ButtonSelectEnabled = true;
            this.buttonsArray1.ButtonSelectVisible = false;
            this.buttonsArray1.ButtonSpacing = 3;
            this.buttonsArray1.ButtonStyle = ControlsLib.ButtonsArray.StyleEnum.Row;
            this.buttonsArray1.ButtonViewEnabled = true;
            this.buttonsArray1.ButtonViewVisible = false;
            this.buttonsArray1.ButtonWordEnabled = true;
            this.buttonsArray1.ButtonWordVisible = false;
            this.buttonsArray1.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonsArray1.FlatStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.buttonsArray1.GroupBoxShow = false;
            this.buttonsArray1.Location = new System.Drawing.Point(626, 0);
            this.buttonsArray1.Name = "buttonsArray1";
            this.buttonsArray1.Size = new System.Drawing.Size(177, 60);
            this.buttonsArray1.Status = ControlsLib.ButtonsArray.StateEnum.View;
            this.buttonsArray1.TabIndex = 0;
            // 
            // richEditControl1
            // 
            this.richEditControl1.Appearance.Text.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richEditControl1.Appearance.Text.Options.UseFont = true;
            this.richEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richEditControl1.Location = new System.Drawing.Point(0, 0);
            this.richEditControl1.Name = "richEditControl1";
            this.richEditControl1.Size = new System.Drawing.Size(803, 481);
            this.richEditControl1.TabIndex = 25;
            this.richEditControl1.Text = "Văn bản yêu cầu pháp lý";
            // 
            // ucYeuCauPhapLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richEditControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucYeuCauPhapLy";
            this.Size = new System.Drawing.Size(803, 541);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private ControlsLib.ButtonsArray buttonsArray1;
        private DevExpress.XtraRichEdit.RichEditControl richEditControl1;
    }
}
