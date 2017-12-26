namespace DauThau.UserControlCategoryMain
{
    partial class ucDotDauThau
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
            this.btnControl = new ControlsLib.ButtonsArray();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.gcGrid = new DevExpress.XtraGrid.GridControl();
            this.gvGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDOT_MA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMO_NGAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.deNgay = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colGIA_DANHGIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.seGia = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colKHOA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colDIEN_GIAI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDANGSUDUNG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.repositoryItemImageEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.SpinEditDonGiaBan = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.lueLoaiHang = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.txtMaHang = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.calEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.lueDonViTinh = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.DtNgay = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNgay.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDonGiaBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDonViTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtNgay.VistaTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnControl
            // 
            this.btnControl.btnBackColor = System.Drawing.Color.Transparent;
            this.btnControl.btnSize = new System.Drawing.Size(75, 36);
            this.btnControl.btnStyleGroup = ControlsLib.ButtonsArray.StyleGroupEnum.None;
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
            this.btnControl.Location = new System.Drawing.Point(597, 0);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(255, 60);
            this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
            this.btnControl.TabIndex = 0;
            this.btnControl.btnEventAdd_Click += new System.EventHandler(this.btnControl_btnEventAdd_Click);
            this.btnControl.btnEventModify_Click += new System.EventHandler(this.btnControl_btnEventModify_Click);
            this.btnControl.btnEventDelete_Click += new System.EventHandler(this.btnControl_btnEventDelete_Click);
            this.btnControl.btnEventSave_Click += new System.EventHandler(this.btnControl_btnEventSave_Click);
            this.btnControl.btnEventCancel_Click += new System.EventHandler(this.btnControl_btnEventCancel_Click);
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
            this.deNgay,
            this.seGia});
            this.gcGrid.Size = new System.Drawing.Size(852, 446);
            this.gcGrid.TabIndex = 22;
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
            this.gvGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDOT_MA,
            this.colMO_NGAY,
            this.colGIA_DANHGIA,
            this.colKHOA,
            this.colDIEN_GIAI,
            this.colID,
            this.colDANGSUDUNG});
            this.gvGrid.GridControl = this.gcGrid;
            this.gvGrid.Name = "gvGrid";
            this.gvGrid.NewItemRowText = "Nhấp vào đây để thêm dòng dữ liệu mới";
            this.gvGrid.OptionsView.ShowGroupPanel = false;
            this.gvGrid.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvGrid_InitNewRow);
            this.gvGrid.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvGrid_InvalidRowException);
            this.gvGrid.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvGrid_ValidateRow);
            this.gvGrid.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvGrid_ValidatingEditor);
            // 
            // colDOT_MA
            // 
            this.colDOT_MA.Caption = "Mã đợt đấu thầu";
            this.colDOT_MA.FieldName = "DOT_MA";
            this.colDOT_MA.Name = "colDOT_MA";
            this.colDOT_MA.Visible = true;
            this.colDOT_MA.VisibleIndex = 4;
            // 
            // colMO_NGAY
            // 
            this.colMO_NGAY.Caption = "Ngày mở thầu";
            this.colMO_NGAY.ColumnEdit = this.deNgay;
            this.colMO_NGAY.FieldName = "MO_NGAY";
            this.colMO_NGAY.Name = "colMO_NGAY";
            this.colMO_NGAY.Visible = true;
            this.colMO_NGAY.VisibleIndex = 0;
            // 
            // deNgay
            // 
            this.deNgay.AutoHeight = false;
            this.deNgay.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deNgay.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.deNgay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deNgay.EditFormat.FormatString = "dd/MM/yyyy";
            this.deNgay.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deNgay.Mask.EditMask = "dd/MM/yyyy";
            this.deNgay.Name = "deNgay";
            this.deNgay.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // colGIA_DANHGIA
            // 
            this.colGIA_DANHGIA.Caption = "Điểm kỹ thuật";
            this.colGIA_DANHGIA.ColumnEdit = this.seGia;
            this.colGIA_DANHGIA.FieldName = "GIA_DANHGIA";
            this.colGIA_DANHGIA.Name = "colGIA_DANHGIA";
            // 
            // seGia
            // 
            this.seGia.AutoHeight = false;
            this.seGia.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seGia.DisplayFormat.FormatString = "###,###";
            this.seGia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seGia.EditFormat.FormatString = "###,###";
            this.seGia.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seGia.Name = "seGia";
            // 
            // colKHOA
            // 
            this.colKHOA.Caption = "Khóa dữ liệu";
            this.colKHOA.ColumnEdit = this.chk;
            this.colKHOA.FieldName = "KHOA";
            this.colKHOA.Name = "colKHOA";
            this.colKHOA.Visible = true;
            this.colKHOA.VisibleIndex = 1;
            // 
            // chk
            // 
            this.chk.AutoHeight = false;
            this.chk.Name = "chk";
            this.chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // colDIEN_GIAI
            // 
            this.colDIEN_GIAI.Caption = "Diễn giải";
            this.colDIEN_GIAI.FieldName = "DIEN_GIAI";
            this.colDIEN_GIAI.Name = "colDIEN_GIAI";
            this.colDIEN_GIAI.Visible = true;
            this.colDIEN_GIAI.VisibleIndex = 2;
            // 
            // colID
            // 
            this.colID.Caption = "gridColumn1";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colDANGSUDUNG
            // 
            this.colDANGSUDUNG.Caption = "Đang sử dụng";
            this.colDANGSUDUNG.ColumnEdit = this.chk;
            this.colDANGSUDUNG.FieldName = "DANGSUDUNG";
            this.colDANGSUDUNG.Name = "colDANGSUDUNG";
            this.colDANGSUDUNG.Visible = true;
            this.colDANGSUDUNG.VisibleIndex = 3;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 446);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(852, 60);
            this.panelControl1.TabIndex = 21;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(240, 17);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Mã đợt đấu thầu : tự động sinh mã";
            // 
            // repositoryItemImageEdit2
            // 
            this.repositoryItemImageEdit2.AutoHeight = false;
            this.repositoryItemImageEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit2.Name = "repositoryItemImageEdit2";
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
            this.DtNgay.Name = "DtNgay";
            this.DtNgay.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // ucDotDauThau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcGrid);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucDotDauThau";
            this.Size = new System.Drawing.Size(852, 506);
            this.Load += new System.EventHandler(this.ucDotDauThau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNgay.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDonGiaBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDonViTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtNgay.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtNgay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlsLib.ButtonsArray btnControl;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraGrid.GridControl gcGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGrid;
        private DevExpress.XtraGrid.Columns.GridColumn colDOT_MA;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit seGia;
        private DevExpress.XtraGrid.Columns.GridColumn colMO_NGAY;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit deNgay;
        private DevExpress.XtraGrid.Columns.GridColumn colGIA_DANHGIA;
        private DevExpress.XtraGrid.Columns.GridColumn colKHOA;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit SpinEditDonGiaBan;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueLoaiHang;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtMaHang;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit calEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueDonViTinh;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit DtNgay;
        private DevExpress.XtraGrid.Columns.GridColumn colDIEN_GIAI;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colDANGSUDUNG;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
