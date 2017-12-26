namespace DauThau.UserControlCategoryMain
{
    partial class ucUpdateDiemKyThuatByExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucUpdateDiemKyThuatByExcel));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.seDiem = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnControl = new ControlsLib.ButtonsArray();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.rdSelect = new DevExpress.XtraEditors.RadioGroup();
            this.btnXem = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lueGoiThau = new DevExpress.XtraEditors.LookUpEdit();
            this.lueCongTy = new DevExpress.XtraEditors.LookUpEdit();
            this.gcGrid = new DevExpress.XtraGrid.GridControl();
            this.gvGrid = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.colGridBandTT = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colGridBand_DAUTHAUID = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colGridBandGOITHAU_ID = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colGoiThauID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colGridBand_SP_MA = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colSP_MA = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colGridBand_TenSP = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colSP_TEN = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colGridBand_TS_DIEM = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.repUpdateDiemKT = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.dsDiemKTExcel1 = new DauThau.DataSets.dsDiemKTExcel();
            ((System.ComponentModel.ISupportInitialize)(this.seDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdSelect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoiThau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCongTy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repUpdateDiemKT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDiemKTExcel1)).BeginInit();
            this.SuspendLayout();
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
            this.panelControl1.Controls.Add(this.btnControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 461);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1161, 60);
            this.panelControl1.TabIndex = 23;
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
            this.btnControl.ButtonReportVisible = true;
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
            this.btnControl.btnEventExcel_Click += new System.EventHandler(this.btnControl_btnEventExcel_Click);
            this.btnControl.btnEventReport_Click += new System.EventHandler(this.btnControl_btnEventReport_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.rdSelect);
            this.groupControl1.Controls.Add(this.btnXem);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.lueGoiThau);
            this.groupControl1.Controls.Add(this.lueCongTy);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1161, 92);
            this.groupControl1.TabIndex = 24;
            this.groupControl1.Text = "Lựa chọn";
            // 
            // rdSelect
            // 
            this.rdSelect.EditValue = ((short)(3));
            this.rdSelect.Location = new System.Drawing.Point(65, 57);
            this.rdSelect.Name = "rdSelect";
            this.rdSelect.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.rdSelect.Properties.Appearance.Options.UseFont = true;
            this.rdSelect.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "Tất cả các gói thầu là thuốc"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Tất cả các gói thầu là VTYT"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(3)), "Theo gói thầu")});
            this.rdSelect.Size = new System.Drawing.Size(776, 27);
            this.rdSelect.TabIndex = 27;
            this.rdSelect.SelectedIndexChanged += new System.EventHandler(this.rdSelect_SelectedIndexChanged);
            // 
            // btnXem
            // 
            this.btnXem.Image = ((System.Drawing.Image)(resources.GetObject("btnXem.Image")));
            this.btnXem.Location = new System.Drawing.Point(847, 26);
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
            this.lueGoiThau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGoiThau.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GOITHAU_ID", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueGoiThau.Properties.DisplayMember = "TEN";
            this.lueGoiThau.Properties.NullText = "Vui lòng chọn gói thầu";
            this.lueGoiThau.Properties.ValueMember = "GOITHAU_ID";
            this.lueGoiThau.Size = new System.Drawing.Size(384, 20);
            this.lueGoiThau.TabIndex = 24;
            this.lueGoiThau.EditValueChanged += new System.EventHandler(this.lueGoiThau_EditValueChanged);
            // 
            // lueCongTy
            // 
            this.lueCongTy.Location = new System.Drawing.Point(65, 30);
            this.lueCongTy.Name = "lueCongTy";
            this.lueCongTy.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lueCongTy.Properties.Appearance.Options.UseFont = true;
            this.lueCongTy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCongTy.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CTY_MA", "Mã công ty"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Tên công ty"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DIACHI", "Địa chỉ")});
            this.lueCongTy.Properties.DisplayMember = "TEN";
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
            this.gcGrid.Location = new System.Drawing.Point(0, 92);
            this.gcGrid.MainView = this.gvGrid;
            this.gcGrid.Name = "gcGrid";
            this.gcGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.seDiem,
            this.repUpdateDiemKT});
            this.gcGrid.Size = new System.Drawing.Size(1161, 369);
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
            this.colGridBandTT,
            this.colGridBand_DAUTHAUID,
            this.colGridBandGOITHAU_ID,
            this.colGridBand_SP_MA,
            this.colGridBand_TenSP,
            this.colGridBand_TS_DIEM});
            this.gvGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gvGrid.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colTT,
            this.colSP_MA,
            this.colSP_TEN,
            this.colID,
            this.colGoiThauID});
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Greater;
            styleFormatCondition1.Value1 = 1;
            this.gvGrid.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gvGrid.GridControl = this.gcGrid;
            this.gvGrid.Name = "gvGrid";
            this.gvGrid.NewItemRowText = "Nhấp vào đây để thêm dòng dữ liệu mới";
            this.gvGrid.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvGrid.OptionsView.EnableAppearanceEvenRow = true;
            this.gvGrid.OptionsView.ShowColumnHeaders = false;
            this.gvGrid.OptionsView.ShowGroupPanel = false;
            this.gvGrid.RowCountChanged += new System.EventHandler(this.gv_RowCountChanged);
            // 
            // colGridBandTT
            // 
            this.colGridBandTT.AppearanceHeader.Options.UseTextOptions = true;
            this.colGridBandTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGridBandTT.Caption = "TT";
            this.colGridBandTT.Columns.Add(this.colTT);
            this.colGridBandTT.MinWidth = 20;
            this.colGridBandTT.Name = "colGridBandTT";
            this.colGridBandTT.VisibleIndex = 0;
            this.colGridBandTT.Width = 32;
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
            // colGridBand_DAUTHAUID
            // 
            this.colGridBand_DAUTHAUID.AppearanceHeader.Options.UseTextOptions = true;
            this.colGridBand_DAUTHAUID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGridBand_DAUTHAUID.Caption = "ID";
            this.colGridBand_DAUTHAUID.Columns.Add(this.colID);
            this.colGridBand_DAUTHAUID.Name = "colGridBand_DAUTHAUID";
            this.colGridBand_DAUTHAUID.VisibleIndex = 1;
            this.colGridBand_DAUTHAUID.Width = 75;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "DAUTHAU_ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.Visible = true;
            // 
            // colGridBandGOITHAU_ID
            // 
            this.colGridBandGOITHAU_ID.AppearanceHeader.Options.UseTextOptions = true;
            this.colGridBandGOITHAU_ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGridBandGOITHAU_ID.Caption = "Gói thầu ID";
            this.colGridBandGOITHAU_ID.Columns.Add(this.colGoiThauID);
            this.colGridBandGOITHAU_ID.Name = "colGridBandGOITHAU_ID";
            this.colGridBandGOITHAU_ID.VisibleIndex = 2;
            this.colGridBandGOITHAU_ID.Width = 75;
            // 
            // colGoiThauID
            // 
            this.colGoiThauID.Caption = "Gói thầu ID";
            this.colGoiThauID.FieldName = "GOITHAU_ID";
            this.colGoiThauID.Name = "colGoiThauID";
            this.colGoiThauID.OptionsColumn.AllowEdit = false;
            this.colGoiThauID.Visible = true;
            // 
            // colGridBand_SP_MA
            // 
            this.colGridBand_SP_MA.AppearanceHeader.Options.UseTextOptions = true;
            this.colGridBand_SP_MA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGridBand_SP_MA.Caption = "Mã SP";
            this.colGridBand_SP_MA.Columns.Add(this.colSP_MA);
            this.colGridBand_SP_MA.Name = "colGridBand_SP_MA";
            this.colGridBand_SP_MA.VisibleIndex = 3;
            this.colGridBand_SP_MA.Width = 114;
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
            // colGridBand_TenSP
            // 
            this.colGridBand_TenSP.AppearanceHeader.Options.UseTextOptions = true;
            this.colGridBand_TenSP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGridBand_TenSP.Caption = "Tên sản phẩm";
            this.colGridBand_TenSP.Columns.Add(this.colSP_TEN);
            this.colGridBand_TenSP.MinWidth = 20;
            this.colGridBand_TenSP.Name = "colGridBand_TenSP";
            this.colGridBand_TenSP.VisibleIndex = 4;
            this.colGridBand_TenSP.Width = 128;
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
            // colGridBand_TS_DIEM
            // 
            this.colGridBand_TS_DIEM.Caption = "Tổng số điểm";
            this.colGridBand_TS_DIEM.MinWidth = 20;
            this.colGridBand_TS_DIEM.Name = "colGridBand_TS_DIEM";
            this.colGridBand_TS_DIEM.Visible = false;
            this.colGridBand_TS_DIEM.VisibleIndex = -1;
            this.colGridBand_TS_DIEM.Width = 97;
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
            // dsDiemKTExcel1
            // 
            this.dsDiemKTExcel1.DataSetName = "dsDiemKTExcel";
            this.dsDiemKTExcel1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucUpdateDiemKyThuatByExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcGrid);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucUpdateDiemKyThuatByExcel";
            this.Size = new System.Drawing.Size(1161, 521);
            this.Load += new System.EventHandler(this.ucSanPhamTheoCty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.seDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdSelect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoiThau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCongTy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repUpdateDiemKT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDiemKTExcel1)).EndInit();
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
        private DevExpress.XtraEditors.SimpleButton btnXem;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit seDiem;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repUpdateDiemKT;
        private DataSets.dsDiemKTExcel dsDiemKTExcel1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colID;
        private DevExpress.XtraEditors.RadioGroup rdSelect;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colGoiThauID;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand colGridBandTT;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand colGridBand_DAUTHAUID;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand colGridBandGOITHAU_ID;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand colGridBand_SP_MA;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand colGridBand_TenSP;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand colGridBand_TS_DIEM;
    }
}
