namespace DauThau.UserControlCategoryMain
{
    partial class frmTapHuanExcel
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
            this.gridBand18 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTH_DOITUONG_HOLOT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTH_DOITUONG_TEN = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTH_DOITUONG_CHUCVU = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTH_DOITUONG_DONVI = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTH_DOITUONG_NAM = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTH_DOITUONG_NU = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repMemo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repMemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 432);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(888, 60);
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
            this.btnControl.ButtonViewVisible = false;
            this.btnControl.ButtonWordEnabled = true;
            this.btnControl.ButtonWordVisible = false;
            this.btnControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnControl.FlatStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnControl.GroupBoxShow = false;
            this.btnControl.Location = new System.Drawing.Point(787, 2);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(99, 56);
            this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
            this.btnControl.TabIndex = 0;
            this.btnControl.btnEventExcel_Click += new System.EventHandler(this.btnControl_btnEventExcel_Click);
            this.btnControl.btnEventView_Click += new System.EventHandler(this.btnControl_btnEventView_Click);
            // 
            // gcGrid
            // 
            this.gcGrid.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcGrid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcGrid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcGrid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcGrid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcGrid.EmbeddedNavigator.TextStringFormat = "Dòng {0} / {1}";
            this.gcGrid.Location = new System.Drawing.Point(2, 2);
            this.gcGrid.MainView = this.gvGrid;
            this.gcGrid.Name = "gcGrid";
            this.gcGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repMemo});
            this.gcGrid.Size = new System.Drawing.Size(884, 428);
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
            this.gridBand18,
            this.gridBand5,
            this.gridBand6,
            this.gridBand7,
            this.gridBand8,
            this.gridBand1});
            this.gvGrid.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colSTT,
            this.colTH_DOITUONG_HOLOT,
            this.colTH_DOITUONG_TEN,
            this.colTH_DOITUONG_CHUCVU,
            this.colTH_DOITUONG_DONVI,
            this.colTH_DOITUONG_NAM,
            this.colTH_DOITUONG_NU});
            this.gvGrid.GridControl = this.gcGrid;
            this.gvGrid.Name = "gvGrid";
            this.gvGrid.NewItemRowText = "Nhấp vào đây để thêm dòng dữ liệu mới";
            this.gvGrid.OptionsView.ColumnAutoWidth = true;
            this.gvGrid.OptionsView.ShowAutoFilterRow = true;
            this.gvGrid.OptionsView.ShowColumnHeaders = false;
            this.gvGrid.OptionsView.ShowFooter = true;
            this.gvGrid.OptionsView.ShowGroupPanel = false;
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
            // gridBand18
            // 
            this.gridBand18.Caption = "Họ và chữ lót";
            this.gridBand18.Columns.Add(this.colTH_DOITUONG_HOLOT);
            this.gridBand18.Name = "gridBand18";
            this.gridBand18.VisibleIndex = 1;
            this.gridBand18.Width = 190;
            // 
            // colTH_DOITUONG_HOLOT
            // 
            this.colTH_DOITUONG_HOLOT.Caption = "Họ tên lót";
            this.colTH_DOITUONG_HOLOT.FieldName = "TH_DOITUONG_HOLOT";
            this.colTH_DOITUONG_HOLOT.Name = "colTH_DOITUONG_HOLOT";
            this.colTH_DOITUONG_HOLOT.Visible = true;
            this.colTH_DOITUONG_HOLOT.Width = 190;
            // 
            // gridBand5
            // 
            this.gridBand5.Caption = "Tên";
            this.gridBand5.Columns.Add(this.colTH_DOITUONG_TEN);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 2;
            this.gridBand5.Width = 140;
            // 
            // colTH_DOITUONG_TEN
            // 
            this.colTH_DOITUONG_TEN.Caption = "Tên";
            this.colTH_DOITUONG_TEN.FieldName = "TH_DOITUONG_TEN";
            this.colTH_DOITUONG_TEN.Name = "colTH_DOITUONG_TEN";
            this.colTH_DOITUONG_TEN.Visible = true;
            this.colTH_DOITUONG_TEN.Width = 140;
            // 
            // gridBand6
            // 
            this.gridBand6.Caption = "Chức vụ";
            this.gridBand6.Columns.Add(this.colTH_DOITUONG_CHUCVU);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 3;
            this.gridBand6.Width = 152;
            // 
            // colTH_DOITUONG_CHUCVU
            // 
            this.colTH_DOITUONG_CHUCVU.Caption = "Chức vụ";
            this.colTH_DOITUONG_CHUCVU.FieldName = "TH_DOITUONG_CHUCVU";
            this.colTH_DOITUONG_CHUCVU.Name = "colTH_DOITUONG_CHUCVU";
            this.colTH_DOITUONG_CHUCVU.Visible = true;
            this.colTH_DOITUONG_CHUCVU.Width = 152;
            // 
            // gridBand7
            // 
            this.gridBand7.Caption = "Đơn vị";
            this.gridBand7.Columns.Add(this.colTH_DOITUONG_DONVI);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.VisibleIndex = 4;
            this.gridBand7.Width = 245;
            // 
            // colTH_DOITUONG_DONVI
            // 
            this.colTH_DOITUONG_DONVI.Caption = "Đơn vị";
            this.colTH_DOITUONG_DONVI.FieldName = "TH_DOITUONG_DONVI";
            this.colTH_DOITUONG_DONVI.Name = "colTH_DOITUONG_DONVI";
            this.colTH_DOITUONG_DONVI.Visible = true;
            this.colTH_DOITUONG_DONVI.Width = 245;
            // 
            // gridBand8
            // 
            this.gridBand8.Caption = "Nam";
            this.gridBand8.Columns.Add(this.colTH_DOITUONG_NAM);
            this.gridBand8.Name = "gridBand8";
            this.gridBand8.VisibleIndex = 5;
            this.gridBand8.Width = 67;
            // 
            // colTH_DOITUONG_NAM
            // 
            this.colTH_DOITUONG_NAM.Caption = "Nam";
            this.colTH_DOITUONG_NAM.FieldName = "TH_DOITUONG_NAM";
            this.colTH_DOITUONG_NAM.Name = "colTH_DOITUONG_NAM";
            this.colTH_DOITUONG_NAM.Visible = true;
            this.colTH_DOITUONG_NAM.Width = 67;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Nữ";
            this.gridBand1.Columns.Add(this.colTH_DOITUONG_NU);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 6;
            this.gridBand1.Width = 53;
            // 
            // colTH_DOITUONG_NU
            // 
            this.colTH_DOITUONG_NU.Caption = "Nữ";
            this.colTH_DOITUONG_NU.FieldName = "TH_DOITUONG_NU";
            this.colTH_DOITUONG_NU.Name = "colTH_DOITUONG_NU";
            this.colTH_DOITUONG_NU.Visible = true;
            this.colTH_DOITUONG_NU.Width = 53;
            // 
            // repMemo
            // 
            this.repMemo.Name = "repMemo";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gcGrid);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl1.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(888, 432);
            this.layoutControl1.TabIndex = 30;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Root.AppearanceGroup.Options.UseFont = true;
            this.Root.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11F);
            this.Root.AppearanceItemCaption.Options.UseFont = true;
            this.Root.CustomizationFormText = "Root";
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(888, 432);
            this.Root.Text = "Root";
            this.Root.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gcGrid;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(888, 432);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // frmTapHuanExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 492);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmTapHuanExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ucBCHoatDongTheoDieuKien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repMemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private ControlsLib.ButtonsArray btnControl;
        private DevExpress.XtraGrid.GridControl gcGrid;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gvGrid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTH_DOITUONG_TEN;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTH_DOITUONG_CHUCVU;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTH_DOITUONG_NAM;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTH_DOITUONG_HOLOT;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSTT;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repMemo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTH_DOITUONG_DONVI;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTH_DOITUONG_NU;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand18;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand8;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
    }
}
