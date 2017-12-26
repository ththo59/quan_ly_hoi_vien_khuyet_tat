namespace DauThau.UserControlCategoryMain
{
    partial class ucSanPhamTheoCty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSanPhamTheoCty));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.colSP_DIEM_BTC = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.seDiem = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkDiemKT_Dat = new DevExpress.XtraEditors.CheckEdit();
            this.btnControl = new ControlsLib.ButtonsArray();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnXem = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lueGoiThau = new DevExpress.XtraEditors.LookUpEdit();
            this.lueCongTy = new DevExpress.XtraEditors.LookUpEdit();
            this.gcGrid = new DevExpress.XtraGrid.GridControl();
            this.gvGrid = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colDAUTHAU_ID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSP_MA = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSP_TEN = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandYCKT = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSP_GHICHU = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colButton = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repUpdateDiemKT = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.dsSanPhamTheoCty1 = new DauThau.DataSets.dsSanPhamTheoCty();
            ((System.ComponentModel.ISupportInitialize)(this.seDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDiemKT_Dat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoiThau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCongTy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repUpdateDiemKT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSanPhamTheoCty1)).BeginInit();
            this.SuspendLayout();
            // 
            // colSP_DIEM_BTC
            // 
            this.colSP_DIEM_BTC.Caption = "Tổ xét thầu";
            this.colSP_DIEM_BTC.ColumnEdit = this.seDiem;
            this.colSP_DIEM_BTC.FieldName = "SP_DIEM_BTC";
            this.colSP_DIEM_BTC.Name = "colSP_DIEM_BTC";
            this.colSP_DIEM_BTC.OptionsColumn.AllowEdit = false;
            this.colSP_DIEM_BTC.Visible = true;
            this.colSP_DIEM_BTC.Width = 100;
            // 
            // seDiem
            // 
            this.seDiem.AutoHeight = false;
            this.seDiem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seDiem.Name = "seDiem";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkDiemKT_Dat);
            this.panelControl1.Controls.Add(this.btnControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 461);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1161, 60);
            this.panelControl1.TabIndex = 23;
            // 
            // chkDiemKT_Dat
            // 
            this.chkDiemKT_Dat.Location = new System.Drawing.Point(14, 6);
            this.chkDiemKT_Dat.Name = "chkDiemKT_Dat";
            this.chkDiemKT_Dat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkDiemKT_Dat.Properties.Appearance.Options.UseFont = true;
            this.chkDiemKT_Dat.Properties.Caption = "Hiển thị các sản phẩm đạt (không bị loại pháp lý, đạt điểm KT)";
            this.chkDiemKT_Dat.Size = new System.Drawing.Size(453, 21);
            this.chkDiemKT_Dat.TabIndex = 1;
            this.chkDiemKT_Dat.CheckedChanged += new System.EventHandler(this.chkDiemKT_Dat_CheckedChanged);
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
            this.btnControl.ButtonExcelVisible = false;
            this.btnControl.ButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.btnControl.ButtonModifyEnabled = true;
            this.btnControl.ButtonModifyText = ControlsLib.ButtonsArray.UpdateEnum.Modify;
            this.btnControl.ButtonModifyVisible = true;
            this.btnControl.ButtonPrintEnabled = true;
            this.btnControl.ButtonPrintVisible = true;
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
            this.btnControl.Location = new System.Drawing.Point(982, 2);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(177, 56);
            this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
            this.btnControl.TabIndex = 0;
            this.btnControl.btnEventModify_Click += new System.EventHandler(this.btnControl_btnEventModify_Click);
            this.btnControl.btnEventSave_Click += new System.EventHandler(this.btnControl_btnEventSave_Click);
            this.btnControl.btnEventCancel_Click += new System.EventHandler(this.btnControl_btnEventCancel_Click);
            this.btnControl.btnEventPrint_Click += new System.EventHandler(this.btnControl_btnEventPrint_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.btnXem);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.lueGoiThau);
            this.groupControl1.Controls.Add(this.lueCongTy);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1161, 58);
            this.groupControl1.TabIndex = 24;
            this.groupControl1.Text = "Lựa chọn";
            // 
            // btnXem
            // 
            this.btnXem.Image = ((System.Drawing.Image)(resources.GetObject("btnXem.Image")));
            this.btnXem.Location = new System.Drawing.Point(784, 26);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(74, 28);
            this.btnXem.TabIndex = 26;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl1.Location = new System.Drawing.Point(406, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 16);
            this.labelControl1.TabIndex = 25;
            this.labelControl1.Text = "Gói thầu";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl2.Location = new System.Drawing.Point(14, 31);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 16);
            this.labelControl2.TabIndex = 25;
            this.labelControl2.Text = "Công ty";
            // 
            // lueGoiThau
            // 
            this.lueGoiThau.Location = new System.Drawing.Point(457, 30);
            this.lueGoiThau.Name = "lueGoiThau";
            this.lueGoiThau.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lueGoiThau.Properties.Appearance.Options.UseFont = true;
            this.lueGoiThau.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lueGoiThau.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lueGoiThau.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.lueGoiThau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGoiThau.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GOITHAU_ID", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueGoiThau.Properties.DisplayMember = "TEN";
            this.lueGoiThau.Properties.DropDownItemHeight = 25;
            this.lueGoiThau.Properties.DropDownRows = 10;
            this.lueGoiThau.Properties.NullText = "Vui lòng chọn gói thầu";
            this.lueGoiThau.Properties.ValueMember = "GOITHAU_ID";
            this.lueGoiThau.Size = new System.Drawing.Size(314, 20);
            this.lueGoiThau.TabIndex = 24;
            this.lueGoiThau.EditValueChanged += new System.EventHandler(this.lueGoiThau_EditValueChanged);
            // 
            // lueCongTy
            // 
            this.lueCongTy.Location = new System.Drawing.Point(65, 30);
            this.lueCongTy.Name = "lueCongTy";
            this.lueCongTy.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lueCongTy.Properties.Appearance.Options.UseFont = true;
            this.lueCongTy.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lueCongTy.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lueCongTy.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.lueCongTy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCongTy.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CTY_MA", "Mã công ty"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Tên công ty", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DIACHI", "Địa chỉ")});
            this.lueCongTy.Properties.DisplayMember = "TEN";
            this.lueCongTy.Properties.DropDownItemHeight = 25;
            this.lueCongTy.Properties.DropDownRows = 10;
            this.lueCongTy.Properties.NullText = "Vui lòng chọn công ty";
            this.lueCongTy.Properties.ValueMember = "CTY_MA";
            this.lueCongTy.Size = new System.Drawing.Size(314, 20);
            this.lueCongTy.TabIndex = 24;
            this.lueCongTy.EditValueChanged += new System.EventHandler(this.lueCongTy_EditValueChanged);
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
            this.gcGrid.Location = new System.Drawing.Point(0, 58);
            this.gcGrid.MainView = this.gvGrid;
            this.gcGrid.Name = "gcGrid";
            this.gcGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.seDiem,
            this.repUpdateDiemKT});
            this.gcGrid.Size = new System.Drawing.Size(1161, 403);
            this.gcGrid.TabIndex = 25;
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
            this.gvGrid.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gvGrid.Appearance.Row.Options.UseFont = true;
            this.gvGrid.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.bandYCKT,
            this.gridBand3});
            this.gvGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gvGrid.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colTT,
            this.colSP_MA,
            this.colSP_TEN,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn6,
            this.colSP_DIEM_BTC,
            this.colSP_GHICHU,
            this.colDAUTHAU_ID,
            this.colButton});
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colSP_DIEM_BTC;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Greater;
            styleFormatCondition1.Value1 = 1;
            this.gvGrid.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gvGrid.GridControl = this.gcGrid;
            this.gvGrid.Name = "gvGrid";
            this.gvGrid.NewItemRowText = "Nhấp vào đây để thêm dòng dữ liệu mới";
            this.gvGrid.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvGrid.OptionsView.EnableAppearanceEvenRow = true;
            this.gvGrid.OptionsView.ShowGroupPanel = false;
            this.gvGrid.RowCountChanged += new System.EventHandler(this.gv_RowCountChanged);
            // 
            // gridBand1
            // 
            this.gridBand1.Columns.Add(this.colDAUTHAU_ID);
            this.gridBand1.Columns.Add(this.colTT);
            this.gridBand1.Columns.Add(this.colSP_MA);
            this.gridBand1.Columns.Add(this.colSP_TEN);
            this.gridBand1.Columns.Add(this.gridColumn1);
            this.gridBand1.Columns.Add(this.gridColumn2);
            this.gridBand1.Columns.Add(this.gridColumn6);
            this.gridBand1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridBand1.MinWidth = 20;
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.RowCount = 2;
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 409;
            // 
            // colDAUTHAU_ID
            // 
            this.colDAUTHAU_ID.Caption = "DAUTHAU_ID";
            this.colDAUTHAU_ID.FieldName = "DAUTHAU_ID";
            this.colDAUTHAU_ID.Name = "colDAUTHAU_ID";
            // 
            // colTT
            // 
            this.colTT.Caption = "TT";
            this.colTT.FieldName = "TT";
            this.colTT.Name = "colTT";
            this.colTT.OptionsColumn.AllowEdit = false;
            this.colTT.Visible = true;
            this.colTT.Width = 32;
            // 
            // colSP_MA
            // 
            this.colSP_MA.Caption = "Mã SP";
            this.colSP_MA.FieldName = "SP_MA";
            this.colSP_MA.Name = "colSP_MA";
            this.colSP_MA.OptionsColumn.AllowEdit = false;
            this.colSP_MA.Visible = true;
            this.colSP_MA.Width = 114;
            // 
            // colSP_TEN
            // 
            this.colSP_TEN.Caption = "Tên SP";
            this.colSP_TEN.FieldName = "SP_TEN";
            this.colSP_TEN.Name = "colSP_TEN";
            this.colSP_TEN.OptionsColumn.AllowEdit = false;
            this.colSP_TEN.Visible = true;
            this.colSP_TEN.Width = 128;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Qui cách yêu cầu";
            this.gridColumn1.FieldName = "SP_QUICACH_YEUCAU";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.Width = 135;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Qui cách đóng gói";
            this.gridColumn2.FieldName = "SP_QUICACH_DONGGOI";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Width = 186;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Đơn giá";
            this.gridColumn6.ColumnEdit = this.seDiem;
            this.gridColumn6.DisplayFormat.FormatString = "###,###";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "GIA_CHAOTHAU";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Width = 88;
            // 
            // bandYCKT
            // 
            this.bandYCKT.AppearanceHeader.Options.UseTextOptions = true;
            this.bandYCKT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandYCKT.Caption = "Yêu cầu kỹ thuật";
            this.bandYCKT.MinWidth = 20;
            this.bandYCKT.Name = "bandYCKT";
            this.bandYCKT.VisibleIndex = 1;
            this.bandYCKT.Width = 114;
            // 
            // gridBand3
            // 
            this.gridBand3.Columns.Add(this.gridColumn5);
            this.gridBand3.Columns.Add(this.colSP_DIEM_BTC);
            this.gridBand3.Columns.Add(this.colSP_GHICHU);
            this.gridBand3.Columns.Add(this.colButton);
            this.gridBand3.MinWidth = 20;
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 379;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "TS Điểm";
            this.gridColumn5.FieldName = "TONG_DIEM_KT";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.Width = 97;
            // 
            // colSP_GHICHU
            // 
            this.colSP_GHICHU.Caption = "Ghi chú";
            this.colSP_GHICHU.FieldName = "SP_GHICHU";
            this.colSP_GHICHU.Name = "colSP_GHICHU";
            this.colSP_GHICHU.OptionsColumn.AllowEdit = false;
            this.colSP_GHICHU.Visible = true;
            this.colSP_GHICHU.Width = 182;
            // 
            // colButton
            // 
            this.colButton.Caption = "Cập nhật điểm kỹ thuật";
            this.colButton.ColumnEdit = this.repUpdateDiemKT;
            this.colButton.Name = "colButton";
            this.colButton.Width = 176;
            // 
            // repUpdateDiemKT
            // 
            this.repUpdateDiemKT.AutoHeight = false;
            this.repUpdateDiemKT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("repUpdateDiemKT.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repUpdateDiemKT.Name = "repUpdateDiemKT";
            this.repUpdateDiemKT.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repUpdateDiemKT.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repUpdateDiemKT_ButtonClick);
            // 
            // dsSanPhamTheoCty1
            // 
            this.dsSanPhamTheoCty1.DataSetName = "dsSanPhamTheoCty";
            this.dsSanPhamTheoCty1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucSanPhamTheoCty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcGrid);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucSanPhamTheoCty";
            this.Size = new System.Drawing.Size(1161, 521);
            this.Load += new System.EventHandler(this.ucSanPhamTheoCty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.seDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkDiemKT_Dat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoiThau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCongTy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repUpdateDiemKT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSanPhamTheoCty1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private ControlsLib.ButtonsArray btnControl;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lueCongTy;
        private DevExpress.XtraGrid.GridControl gcGrid;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lueGoiThau;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gvGrid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTT;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSP_MA;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSP_TEN;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSP_DIEM_BTC;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSP_GHICHU;
        private DevExpress.XtraEditors.SimpleButton btnXem;
        private DataSets.dsSanPhamTheoCty dsSanPhamTheoCty1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDAUTHAU_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit seDiem;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colButton;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repUpdateDiemKT;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandYCKT;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraEditors.CheckEdit chkDiemKT_Dat;
    }
}
