namespace DauThau.UserControlCategory
{
    partial class ucDMThanhVienHoi
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
            this.gcGrid = new DevExpress.XtraGrid.GridControl();
            this.gvGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTVH_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTVH_TEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTVH_STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.seSTT = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.btnControl = new ControlsLib.ButtonsArray();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemImageEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.SpinEditDonGiaBan = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.lueLoaiHang = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.txtMaHang = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.calEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.lueDonViTinh = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.DtNgay = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seSTT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDonGiaBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDonViTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtNgay.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
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
            this.seSTT});
            this.gcGrid.Size = new System.Drawing.Size(758, 445);
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
            this.colTVH_ID,
            this.colTVH_TEN,
            this.colTVH_STT});
            this.gvGrid.GridControl = this.gcGrid;
            this.gvGrid.Name = "gvGrid";
            this.gvGrid.NewItemRowText = "Nhấp vào đây để thêm dòng dữ liệu mới";
            this.gvGrid.OptionsView.ShowGroupPanel = false;
            this.gvGrid.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTVH_STT, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvGrid.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvGrid_InvalidRowException);
            this.gvGrid.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvGrid_ValidateRow);
            this.gvGrid.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvGrid_ValidatingEditor);
            // 
            // colTVH_ID
            // 
            this.colTVH_ID.Caption = "TVH_ID";
            this.colTVH_ID.FieldName = "TVH_ID";
            this.colTVH_ID.Name = "colTVH_ID";
            // 
            // colTVH_TEN
            // 
            this.colTVH_TEN.Caption = "Thành viên hội";
            this.colTVH_TEN.FieldName = "TVH_TEN";
            this.colTVH_TEN.Name = "colTVH_TEN";
            this.colTVH_TEN.Visible = true;
            this.colTVH_TEN.VisibleIndex = 0;
            this.colTVH_TEN.Width = 333;
            // 
            // colTVH_STT
            // 
            this.colTVH_STT.Caption = "Số thứ tự";
            this.colTVH_STT.ColumnEdit = this.seSTT;
            this.colTVH_STT.FieldName = "TVH_STT";
            this.colTVH_STT.Name = "colTVH_STT";
            this.colTVH_STT.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.colTVH_STT.Visible = true;
            this.colTVH_STT.VisibleIndex = 1;
            this.colTVH_STT.Width = 72;
            // 
            // seSTT
            // 
            this.seSTT.AutoHeight = false;
            this.seSTT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seSTT.Name = "seSTT";
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
            this.btnControl.ButtonCloseVisible = true;
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
            this.btnControl.Location = new System.Drawing.Point(425, 0);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(333, 60);
            this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
            this.btnControl.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 445);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(758, 60);
            this.panelControl1.TabIndex = 21;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
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
            this.DtNgay.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DtNgay.Name = "DtNgay";
            // 
            // ucDMThanhVienHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcGrid);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucDMThanhVienHoi";
            this.Size = new System.Drawing.Size(758, 505);
            this.Load += new System.EventHandler(this.ucDMThanhVienHoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seSTT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDonGiaBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDonViTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtNgay.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtNgay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGrid;
        private DevExpress.XtraGrid.Columns.GridColumn colTVH_TEN;
        private ControlsLib.ButtonsArray btnControl;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit SpinEditDonGiaBan;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueLoaiHang;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtMaHang;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit calEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueDonViTinh;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit DtNgay;
        private DevExpress.XtraGrid.Columns.GridColumn colTVH_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTVH_STT;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit seSTT;
    }
}
