﻿namespace DauThau.UserControlCategoryMain
{
    partial class ucBCNhaTaiTroVaMTQ
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
            this.btnControl = new ControlsLib.ButtonsArray();
            this.gcGrid = new DevExpress.XtraGrid.GridControl();
            this.gvGrid = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colSTT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNTT_NGAY = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNTT_TEN = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNTT_TEN_CHUONGTRINH = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNTT_DIACHI = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNTT_SOTIEN = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand12 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNTT_GHICHU = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 471);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(904, 60);
            this.panelControl1.TabIndex = 28;
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
            this.btnControl.ButtonCloseVisible = false;
            this.btnControl.ButtonDeleteEnabled = true;
            this.btnControl.ButtonDeleteVisible = false;
            this.btnControl.ButtonExcelEnabled = true;
            this.btnControl.ButtonExcelVisible = true;
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
            this.btnControl.ButtonSelectVisible = false;
            this.btnControl.ButtonSpacing = 3;
            this.btnControl.ButtonStyle = ControlsLib.ButtonsArray.StyleEnum.Row;
            this.btnControl.ButtonViewEnabled = true;
            this.btnControl.ButtonViewVisible = true;
            this.btnControl.ButtonWordEnabled = true;
            this.btnControl.ButtonWordVisible = false;
            this.btnControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnControl.FlatStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnControl.GroupBoxShow = false;
            this.btnControl.Location = new System.Drawing.Point(725, 2);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(177, 56);
            this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
            this.btnControl.TabIndex = 0;
            this.btnControl.btnEventExcel_Click += new System.EventHandler(this.btnControl_btnEventExcel_Click);
            this.btnControl.btnEventView_Click += new System.EventHandler(this.btnControl_btnEventView_Click);
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
            this.gcGrid.Size = new System.Drawing.Size(904, 471);
            this.gcGrid.TabIndex = 29;
            this.gcGrid.UseEmbeddedNavigator = true;
            this.gcGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGrid});
            // 
            // gvGrid
            // 
            this.gvGrid.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gvGrid.Appearance.BandPanel.Options.UseFont = true;
            this.gvGrid.Appearance.BandPanel.Options.UseTextOptions = true;
            this.gvGrid.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvGrid.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gvGrid.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvGrid.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvGrid.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvGrid.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gvGrid.Appearance.Row.Options.UseFont = true;
            this.gvGrid.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand4,
            this.gridBand5,
            this.gridBand6,
            this.gridBand7,
            this.gridBand8,
            this.gridBand1,
            this.gridBand12});
            this.gvGrid.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colSTT,
            this.colNTT_NGAY,
            this.colNTT_TEN,
            this.colNTT_TEN_CHUONGTRINH,
            this.colNTT_DIACHI,
            this.colNTT_SOTIEN,
            this.colNTT_GHICHU});
            this.gvGrid.GridControl = this.gcGrid;
            this.gvGrid.Name = "gvGrid";
            this.gvGrid.NewItemRowText = "Nhấp vào đây để thêm dòng dữ liệu mới";
            this.gvGrid.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvGrid.OptionsBehavior.Editable = false;
            this.gvGrid.OptionsView.ShowAutoFilterRow = true;
            this.gvGrid.OptionsView.ShowColumnHeaders = false;
            this.gvGrid.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gvGrid.OptionsView.ShowFooter = true;
            this.gvGrid.OptionsView.ShowGroupPanel = false;
            this.gvGrid.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNTT_TEN, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvGrid.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvGrid_CustomUnboundColumnData);
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "STT";
            this.gridBand4.Columns.Add(this.colSTT);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 0;
            this.gridBand4.Width = 60;
            // 
            // colSTT
            // 
            this.colSTT.Caption = "STT";
            this.colSTT.FieldName = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colSTT.Visible = true;
            this.colSTT.Width = 60;
            // 
            // gridBand5
            // 
            this.gridBand5.Caption = "Ngày tháng năm";
            this.gridBand5.Columns.Add(this.colNTT_NGAY);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 1;
            this.gridBand5.Width = 209;
            // 
            // colNTT_NGAY
            // 
            this.colNTT_NGAY.Caption = "Ngày tháng năm";
            this.colNTT_NGAY.FieldName = "NTT_NGAY";
            this.colNTT_NGAY.Name = "colNTT_NGAY";
            this.colNTT_NGAY.Visible = true;
            this.colNTT_NGAY.Width = 209;
            // 
            // gridBand6
            // 
            this.gridBand6.Caption = "Tên nhà tài trợ / MTQ";
            this.gridBand6.Columns.Add(this.colNTT_TEN);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 2;
            this.gridBand6.Width = 273;
            // 
            // colNTT_TEN
            // 
            this.colNTT_TEN.Caption = "Đơn vị/Cá nhân";
            this.colNTT_TEN.FieldName = "NTT_TEN";
            this.colNTT_TEN.Name = "colNTT_TEN";
            this.colNTT_TEN.Visible = true;
            this.colNTT_TEN.Width = 273;
            // 
            // gridBand7
            // 
            this.gridBand7.Caption = "Tên chương trình";
            this.gridBand7.Columns.Add(this.colNTT_TEN_CHUONGTRINH);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.VisibleIndex = 3;
            this.gridBand7.Width = 176;
            // 
            // colNTT_TEN_CHUONGTRINH
            // 
            this.colNTT_TEN_CHUONGTRINH.Caption = "Tên chương trình";
            this.colNTT_TEN_CHUONGTRINH.FieldName = "NTT_TEN_CHUONGTRINH";
            this.colNTT_TEN_CHUONGTRINH.Name = "colNTT_TEN_CHUONGTRINH";
            this.colNTT_TEN_CHUONGTRINH.Visible = true;
            this.colNTT_TEN_CHUONGTRINH.Width = 176;
            // 
            // gridBand8
            // 
            this.gridBand8.Caption = "Địa chỉ";
            this.gridBand8.Columns.Add(this.colNTT_DIACHI);
            this.gridBand8.Name = "gridBand8";
            this.gridBand8.VisibleIndex = 4;
            this.gridBand8.Width = 190;
            // 
            // colNTT_DIACHI
            // 
            this.colNTT_DIACHI.Caption = "Địa chỉ";
            this.colNTT_DIACHI.FieldName = "NTT_DIACHI";
            this.colNTT_DIACHI.Name = "colNTT_DIACHI";
            this.colNTT_DIACHI.Visible = true;
            this.colNTT_DIACHI.Width = 190;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Số tiền";
            this.gridBand1.Columns.Add(this.colNTT_SOTIEN);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 5;
            this.gridBand1.Width = 143;
            // 
            // colNTT_SOTIEN
            // 
            this.colNTT_SOTIEN.Caption = "Số tiền";
            this.colNTT_SOTIEN.DisplayFormat.FormatString = "#,#";
            this.colNTT_SOTIEN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNTT_SOTIEN.FieldName = "NTT_SOTIEN";
            this.colNTT_SOTIEN.Name = "colNTT_SOTIEN";
            this.colNTT_SOTIEN.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NTT_SOTIEN", "Tổng tiền = {0:n0}")});
            this.colNTT_SOTIEN.Visible = true;
            this.colNTT_SOTIEN.Width = 143;
            // 
            // gridBand12
            // 
            this.gridBand12.Caption = "Hiện vật";
            this.gridBand12.Columns.Add(this.colNTT_GHICHU);
            this.gridBand12.Name = "gridBand12";
            this.gridBand12.VisibleIndex = 6;
            this.gridBand12.Width = 229;
            // 
            // colNTT_GHICHU
            // 
            this.colNTT_GHICHU.Caption = "Hiện vật";
            this.colNTT_GHICHU.FieldName = "NTT_GHICHU";
            this.colNTT_GHICHU.Name = "colNTT_GHICHU";
            this.colNTT_GHICHU.Visible = true;
            this.colNTT_GHICHU.Width = 229;
            // 
            // ucBCNhaTaiTroVaMTQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcGrid);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucBCNhaTaiTroVaMTQ";
            this.Size = new System.Drawing.Size(904, 531);
            this.Load += new System.EventHandler(this.ucBCNhaTaiTroVaMTQ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private ControlsLib.ButtonsArray btnControl;
        private DevExpress.XtraGrid.GridControl gcGrid;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gvGrid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNTT_NGAY;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNTT_TEN_CHUONGTRINH;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNTT_DIACHI;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNTT_SOTIEN;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNTT_GHICHU;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNTT_TEN;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSTT;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand8;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand12;
    }
}
