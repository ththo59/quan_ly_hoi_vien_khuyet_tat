namespace DauThau.UserControlCategory
{
    partial class ucGoiThau
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colDELETED = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.lueLoaiHang = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.txtMaHang = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.calEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.lueDonViTinh = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.DtNgay = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.SpinEditDonGiaBan = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemImageEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.btnControl = new ControlsLib.ButtonsArray();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkDeleted = new DevExpress.XtraEditors.CheckEdit();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.gcGrid = new DevExpress.XtraGrid.GridControl();
            this.gvGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGOITHAU_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDOT_MA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCHON_HANGSX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBIEUMAU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIEMKT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.seDiemKT = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEN_VIET_TAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIEN_GIAI = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDonViTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtNgay.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDonGiaBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeleted.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seDiemKT)).BeginInit();
            this.SuspendLayout();
            // 
            // colDELETED
            // 
            this.colDELETED.Caption = "Xóa";
            this.colDELETED.ColumnEdit = this.chk;
            this.colDELETED.FieldName = "DELETED";
            this.colDELETED.Name = "colDELETED";
            this.colDELETED.Visible = true;
            this.colDELETED.VisibleIndex = 4;
            // 
            // chk
            // 
            this.chk.AutoHeight = false;
            this.chk.Name = "chk";
            this.chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            this.chk.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.chk_EditValueChanging);
            // 
            // lueLoaiHang
            // 
            this.lueLoaiHang.AutoHeight = false;
            this.lueLoaiHang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lueLoaiHang.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IDLoaiHang", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenLoai", "Loại hàng")});
            this.lueLoaiHang.DisplayMember = "TenLoai";
            this.lueLoaiHang.Name = "lueLoaiHang";
            this.lueLoaiHang.NullText = "";
            this.lueLoaiHang.ValueMember = "IDLoaiHang";
            // 
            // txtMaHang
            // 
            this.txtMaHang.AutoHeight = false;
            this.txtMaHang.Name = "txtMaHang";
            this.txtMaHang.ReadOnly = true;
            // 
            // calEdit
            // 
            this.calEdit.AutoHeight = false;
            this.calEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calEdit.DisplayFormat.FormatString = "###,###.###";
            this.calEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calEdit.EditFormat.FormatString = "###,###.###";
            this.calEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calEdit.Name = "calEdit";
            // 
            // lueDonViTinh
            // 
            this.lueDonViTinh.AutoHeight = false;
            this.lueDonViTinh.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lueDonViTinh.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IDDVT", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TENDVT", "Đơn vị tính")});
            this.lueDonViTinh.DisplayMember = "TENDVT";
            this.lueDonViTinh.Name = "lueDonViTinh";
            this.lueDonViTinh.NullText = "";
            this.lueDonViTinh.ValueMember = "IDDVT";
            // 
            // DtNgay
            // 
            this.DtNgay.AutoHeight = false;
            this.DtNgay.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtNgay.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DtNgay.Name = "DtNgay";
            // 
            // SpinEditDonGiaBan
            // 
            this.SpinEditDonGiaBan.AutoHeight = false;
            this.SpinEditDonGiaBan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditDonGiaBan.DisplayFormat.FormatString = "###,###.###";
            this.SpinEditDonGiaBan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SpinEditDonGiaBan.EditFormat.FormatString = "###,###.###";
            this.SpinEditDonGiaBan.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SpinEditDonGiaBan.Name = "SpinEditDonGiaBan";
            this.SpinEditDonGiaBan.ReadOnly = true;
            // 
            // repositoryItemImageEdit2
            // 
            this.repositoryItemImageEdit2.AutoHeight = false;
            this.repositoryItemImageEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit2.Name = "repositoryItemImageEdit2";
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
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
            this.btnControl.btnSize = new System.Drawing.Size(75, 36);
            this.btnControl.btnStyleGroup = ControlsLib.ButtonsArray.StyleGroupEnum.None;
            this.btnControl.btnViewIndex = 5;
            this.btnControl.btnWordIndex = 7;
            this.btnControl.ButtonAddEnabled = true;
            this.btnControl.ButtonAddVisible = true;
            this.btnControl.ButtonBackgroundImage = null;
            this.btnControl.ButtonCancelEnabled = true;
            this.btnControl.ButtonCloseEnabled = true;
            this.btnControl.ButtonCloseVisible = false;
            this.btnControl.ButtonDeleteEnabled = true;
            this.btnControl.ButtonDeleteVisible = true;
            this.btnControl.ButtonExcelEnabled = true;
            this.btnControl.ButtonExcelVisible = false;
            this.btnControl.ButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.btnControl.ButtonModifyEnabled = true;
            this.btnControl.ButtonModifyText = ControlsLib.ButtonsArray.UpdateEnum.Modify;
            this.btnControl.ButtonModifyVisible = true;
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
            this.btnControl.Location = new System.Drawing.Point(563, 0);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(255, 60);
            this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
            this.btnControl.TabIndex = 0;
            this.btnControl.btnEventAdd_Click += new System.EventHandler(this.btnControl_btnEventAdd_Click);
            this.btnControl.btnEventModify_Click += new System.EventHandler(this.btnControl_btnEventModify_Click);
            this.btnControl.btnEventDelete_Click += new System.EventHandler(this.btnControl_btnEventDelete_Click);
            this.btnControl.btnEventSave_Click += new System.EventHandler(this.btnControl_btnEventSave_Click);
            this.btnControl.btnEventCancel_Click += new System.EventHandler(this.btnControl_btnEventCancel_Click);
            this.btnControl.btnEventClose_Click += new System.EventHandler(this.btnControl_btnEventClose_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.chkDeleted);
            this.panelControl1.Controls.Add(this.btnControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 504);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(818, 60);
            this.panelControl1.TabIndex = 23;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(18, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(336, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Nhấn phím Delete nếu muốn xóa luôn dòng đang chọn";
            // 
            // chkDeleted
            // 
            this.chkDeleted.Location = new System.Drawing.Point(16, 7);
            this.chkDeleted.Name = "chkDeleted";
            this.chkDeleted.Properties.Caption = "Hiển thị các dòng đã xóa";
            this.chkDeleted.Size = new System.Drawing.Size(146, 20);
            this.chkDeleted.TabIndex = 1;
            this.chkDeleted.CheckedChanged += new System.EventHandler(this.chkDeleted_CheckedChanged);
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
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
            this.chk,
            this.seDiemKT});
            this.gcGrid.Size = new System.Drawing.Size(818, 504);
            this.gcGrid.TabIndex = 24;
            this.gcGrid.UseEmbeddedNavigator = true;
            this.gcGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGrid});
            this.gcGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gcGrid_KeyDown);
            // 
            // gvGrid
            // 
            this.gvGrid.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gvGrid.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvGrid.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvGrid.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvGrid.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gvGrid.Appearance.Row.Options.UseFont = true;
            this.gvGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGOITHAU_ID,
            this.colTEN,
            this.colDELETED,
            this.colDOT_MA,
            this.colCHON_HANGSX,
            this.colBIEUMAU,
            this.colDIEMKT,
            this.colSTT,
            this.colTEN_VIET_TAT,
            this.colDIEN_GIAI});
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))));
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colDELETED;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = true;
            this.gvGrid.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gvGrid.GridControl = this.gcGrid;
            this.gvGrid.Name = "gvGrid";
            this.gvGrid.NewItemRowText = "Nhấp vào đây để thêm dòng dữ liệu mới";
            this.gvGrid.OptionsView.EnableAppearanceEvenRow = true;
            this.gvGrid.OptionsView.ShowGroupPanel = false;
            this.gvGrid.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvGrid_InitNewRow);
            this.gvGrid.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvGrid_InvalidRowException);
            this.gvGrid.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvGrid_ValidateRow);
            this.gvGrid.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvGrid_ValidatingEditor);
            // 
            // colGOITHAU_ID
            // 
            this.colGOITHAU_ID.Caption = "gridColumn1";
            this.colGOITHAU_ID.FieldName = "GOITHAU_ID";
            this.colGOITHAU_ID.Name = "colGOITHAU_ID";
            // 
            // colTEN
            // 
            this.colTEN.Caption = "Gói thầu";
            this.colTEN.FieldName = "TEN";
            this.colTEN.Name = "colTEN";
            this.colTEN.Visible = true;
            this.colTEN.VisibleIndex = 1;
            // 
            // colDOT_MA
            // 
            this.colDOT_MA.Caption = "Đợt mã";
            this.colDOT_MA.FieldName = "DOT_MA";
            this.colDOT_MA.Name = "colDOT_MA";
            // 
            // colCHON_HANGSX
            // 
            this.colCHON_HANGSX.Caption = "Cho phép chọn hãng sản xuất";
            this.colCHON_HANGSX.ColumnEdit = this.chk;
            this.colCHON_HANGSX.FieldName = "CHON_HANGSX";
            this.colCHON_HANGSX.Name = "colCHON_HANGSX";
            // 
            // colBIEUMAU
            // 
            this.colBIEUMAU.Caption = "Biểu mẫu";
            this.colBIEUMAU.FieldName = "BIEUMAU";
            this.colBIEUMAU.Name = "colBIEUMAU";
            this.colBIEUMAU.Visible = true;
            this.colBIEUMAU.VisibleIndex = 3;
            // 
            // colDIEMKT
            // 
            this.colDIEMKT.Caption = "Điểm kỹ thuật";
            this.colDIEMKT.ColumnEdit = this.seDiemKT;
            this.colDIEMKT.FieldName = "DIEMKT";
            this.colDIEMKT.Name = "colDIEMKT";
            this.colDIEMKT.Visible = true;
            this.colDIEMKT.VisibleIndex = 2;
            // 
            // seDiemKT
            // 
            this.seDiemKT.AutoHeight = false;
            this.seDiemKT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seDiemKT.Name = "seDiemKT";
            // 
            // colSTT
            // 
            this.colSTT.Caption = "Sắp xếp";
            this.colSTT.FieldName = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 0;
            // 
            // colTEN_VIET_TAT
            // 
            this.colTEN_VIET_TAT.Caption = "Từ viết tắt";
            this.colTEN_VIET_TAT.FieldName = "TEN_VIET_TAT";
            this.colTEN_VIET_TAT.Name = "colTEN_VIET_TAT";
            this.colTEN_VIET_TAT.Visible = true;
            this.colTEN_VIET_TAT.VisibleIndex = 5;
            // 
            // colDIEN_GIAI
            // 
            this.colDIEN_GIAI.Caption = "Diễn giải";
            this.colDIEN_GIAI.FieldName = "DIEN_GIAI";
            this.colDIEN_GIAI.Name = "colDIEN_GIAI";
            this.colDIEN_GIAI.Visible = true;
            this.colDIEN_GIAI.VisibleIndex = 6;
            // 
            // ucGoiThau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcGrid);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucGoiThau";
            this.Size = new System.Drawing.Size(818, 564);
            this.Load += new System.EventHandler(this.ucGoiThau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDonViTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtNgay.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDonGiaBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeleted.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seDiemKT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueLoaiHang;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtMaHang;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit calEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueDonViTinh;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit DtNgay;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit SpinEditDonGiaBan;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private ControlsLib.ButtonsArray btnControl;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraGrid.GridControl gcGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGrid;
        private DevExpress.XtraGrid.Columns.GridColumn colGOITHAU_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTEN;
        private DevExpress.XtraGrid.Columns.GridColumn colDELETED;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk;
        private DevExpress.XtraEditors.CheckEdit chkDeleted;
        private DevExpress.XtraGrid.Columns.GridColumn colDOT_MA;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colCHON_HANGSX;
        private DevExpress.XtraGrid.Columns.GridColumn colBIEUMAU;
        private DevExpress.XtraGrid.Columns.GridColumn colDIEMKT;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit seDiemKT;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colTEN_VIET_TAT;
        private DevExpress.XtraGrid.Columns.GridColumn colDIEN_GIAI;
    }
}
