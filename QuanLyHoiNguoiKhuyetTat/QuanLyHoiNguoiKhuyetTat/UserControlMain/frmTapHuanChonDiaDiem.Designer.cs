namespace DauThau.UserControlMain
{
    partial class frmTapHuanChonDiaDiem
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colCHON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkChon = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnControl = new ControlsLib.ButtonsArray();
            this.gcGrid = new DevExpress.XtraGrid.GridControl();
            this.gvGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTH_DD_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTH_DD_TEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txt = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colTH_DD_NGUOI_DAIDIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTH_DD_DIACHI = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chkChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt)).BeginInit();
            this.SuspendLayout();
            // 
            // colCHON
            // 
            this.colCHON.Caption = "Chọn";
            this.colCHON.ColumnEdit = this.chkChon;
            this.colCHON.FieldName = "CHON";
            this.colCHON.Name = "colCHON";
            this.colCHON.Visible = true;
            this.colCHON.VisibleIndex = 0;
            this.colCHON.Width = 43;
            // 
            // chkChon
            // 
            this.chkChon.AutoHeight = false;
            this.chkChon.Name = "chkChon";
            this.chkChon.CheckedChanged += new System.EventHandler(this.chkChon_CheckedChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 415);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(794, 60);
            this.panelControl1.TabIndex = 34;
            // 
            // btnControl
            // 
            this.btnControl.btnAddIndex = 0;
            this.btnControl.btnBackColor = System.Drawing.Color.Transparent;
            this.btnControl.btnCloseIndex = 9;
            this.btnControl.btnDeleteIndex = 2;
            this.btnControl.btnExcelIndex = 8;
            this.btnControl.btnModifyIndex = 1;
            this.btnControl.btnPrintIndex = 6;
            this.btnControl.btnReportIndex = 4;
            this.btnControl.btnSelectIndex = 3;
            this.btnControl.btnSize = new System.Drawing.Size(75, 32);
            this.btnControl.btnStyleGroup = ControlsLib.ButtonsArray.StyleGroupEnum.None;
            this.btnControl.btnViewIndex = 5;
            this.btnControl.btnWordIndex = 7;
            this.btnControl.ButtonAddEnabled = true;
            this.btnControl.ButtonAddVisible = false;
            this.btnControl.ButtonBackgroundImage = null;
            this.btnControl.ButtonCancelEnabled = true;
            this.btnControl.ButtonCloseEnabled = true;
            this.btnControl.ButtonCloseVisible = true;
            this.btnControl.ButtonDeleteEnabled = true;
            this.btnControl.ButtonDeleteVisible = false;
            this.btnControl.ButtonExcelEnabled = true;
            this.btnControl.ButtonExcelVisible = false;
            this.btnControl.ButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.btnControl.ButtonModifyEnabled = true;
            this.btnControl.ButtonModifyText = ControlsLib.ButtonsArray.UpdateEnum.Modify;
            this.btnControl.ButtonModifyVisible = false;
            this.btnControl.ButtonPrintEnabled = true;
            this.btnControl.ButtonPrintVisible = false;
            this.btnControl.ButtonReportEnabled = true;
            this.btnControl.ButtonReportVisible = false;
            this.btnControl.ButtonSaveEnabled = true;
            this.btnControl.ButtonSelectEnabled = true;
            this.btnControl.ButtonSelectVisible = true;
            this.btnControl.ButtonSpacing = 3;
            this.btnControl.ButtonStyle = ControlsLib.ButtonsArray.StyleEnum.Row;
            this.btnControl.ButtonViewEnabled = true;
            this.btnControl.ButtonViewVisible = false;
            this.btnControl.ButtonWordEnabled = true;
            this.btnControl.ButtonWordVisible = false;
            this.btnControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnControl.FlatStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnControl.GroupBoxShow = false;
            this.btnControl.Location = new System.Drawing.Point(615, 2);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(177, 56);
            this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
            this.btnControl.TabIndex = 0;
            this.btnControl.btnEventClose_Click += new System.EventHandler(this.btnControl_btnEventClose_Click);
            this.btnControl.btnEventSelect_Click += new System.EventHandler(this.btnControl_btnEventSelect_Click);
            // 
            // gcGrid
            // 
            this.gcGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcGrid.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcGrid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcGrid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcGrid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcGrid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcGrid.EmbeddedNavigator.TextStringFormat = "Dòng {0} / {1}";
            this.gcGrid.Location = new System.Drawing.Point(0, 0);
            this.gcGrid.MainView = this.gvGrid;
            this.gcGrid.Name = "gcGrid";
            this.gcGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.txt,
            this.chkChon});
            this.gcGrid.Size = new System.Drawing.Size(794, 415);
            this.gcGrid.TabIndex = 35;
            this.gcGrid.UseEmbeddedNavigator = true;
            this.gcGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGrid});
            // 
            // gvGrid
            // 
            this.gvGrid.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gvGrid.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvGrid.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvGrid.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvGrid.Appearance.OddRow.BackColor = System.Drawing.Color.LemonChiffon;
            this.gvGrid.Appearance.OddRow.Options.UseBackColor = true;
            this.gvGrid.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gvGrid.Appearance.Row.Options.UseFont = true;
            this.gvGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTH_DD_ID,
            this.colCHON,
            this.colTH_DD_TEN,
            this.colTH_DD_NGUOI_DAIDIEN,
            this.colTH_DD_DIACHI});
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colCHON;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = true;
            this.gvGrid.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gvGrid.GridControl = this.gcGrid;
            this.gvGrid.Name = "gvGrid";
            this.gvGrid.NewItemRowText = "Nhấp vào đây để thêm dòng dữ liệu mới";
            this.gvGrid.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvGrid.OptionsFind.AlwaysVisible = true;
            this.gvGrid.OptionsView.EnableAppearanceEvenRow = true;
            this.gvGrid.OptionsView.EnableAppearanceOddRow = true;
            this.gvGrid.OptionsView.ShowAutoFilterRow = true;
            this.gvGrid.OptionsView.ShowGroupedColumns = true;
            this.gvGrid.OptionsView.ShowGroupPanel = false;
            this.gvGrid.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTH_DD_NGUOI_DAIDIEN, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colTH_DD_ID
            // 
            this.colTH_DD_ID.Caption = "TH_DD_ID";
            this.colTH_DD_ID.FieldName = "TH_DD_ID";
            this.colTH_DD_ID.Name = "colTH_DD_ID";
            // 
            // colTH_DD_TEN
            // 
            this.colTH_DD_TEN.Caption = "Tên";
            this.colTH_DD_TEN.ColumnEdit = this.txt;
            this.colTH_DD_TEN.FieldName = "TH_DD_TEN";
            this.colTH_DD_TEN.Name = "colTH_DD_TEN";
            this.colTH_DD_TEN.OptionsColumn.AllowEdit = false;
            this.colTH_DD_TEN.Visible = true;
            this.colTH_DD_TEN.VisibleIndex = 1;
            this.colTH_DD_TEN.Width = 145;
            // 
            // txt
            // 
            this.txt.AutoHeight = false;
            this.txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt.Name = "txt";
            // 
            // colTH_DD_NGUOI_DAIDIEN
            // 
            this.colTH_DD_NGUOI_DAIDIEN.Caption = "Người đại diện";
            this.colTH_DD_NGUOI_DAIDIEN.FieldName = "TH_DD_NGUOI_DAIDIEN";
            this.colTH_DD_NGUOI_DAIDIEN.Name = "colTH_DD_NGUOI_DAIDIEN";
            this.colTH_DD_NGUOI_DAIDIEN.OptionsColumn.AllowEdit = false;
            this.colTH_DD_NGUOI_DAIDIEN.Visible = true;
            this.colTH_DD_NGUOI_DAIDIEN.VisibleIndex = 2;
            this.colTH_DD_NGUOI_DAIDIEN.Width = 148;
            // 
            // colTH_DD_DIACHI
            // 
            this.colTH_DD_DIACHI.Caption = "Địa chỉ";
            this.colTH_DD_DIACHI.FieldName = "TH_DD_DIACHI";
            this.colTH_DD_DIACHI.Name = "colTH_DD_DIACHI";
            this.colTH_DD_DIACHI.OptionsColumn.AllowEdit = false;
            this.colTH_DD_DIACHI.Visible = true;
            this.colTH_DD_DIACHI.VisibleIndex = 3;
            this.colTH_DD_DIACHI.Width = 76;
            // 
            // frmTapHuanChonDiaDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 475);
            this.Controls.Add(this.gcGrid);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmTapHuanChonDiaDiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn danh sách";
            this.Load += new System.EventHandler(this.frmTapHuanChonDiaDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private ControlsLib.ButtonsArray btnControl;
        private DevExpress.XtraGrid.GridControl gcGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGrid;
        private DevExpress.XtraGrid.Columns.GridColumn colTH_DD_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTH_DD_TEN;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txt;
        private DevExpress.XtraGrid.Columns.GridColumn colTH_DD_DIACHI;
        private DevExpress.XtraGrid.Columns.GridColumn colCHON;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkChon;
        private DevExpress.XtraGrid.Columns.GridColumn colTH_DD_NGUOI_DAIDIEN;
    }
}