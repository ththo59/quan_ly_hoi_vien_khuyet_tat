namespace DauThau.UserControlCategoryMain
{
    partial class ucGiaKeHoach
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lueGoiThau = new DevExpress.XtraEditors.LookUpEdit();
            this.gcGrid = new DevExpress.XtraGrid.GridControl();
            this.gvGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDOT_MA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSP_MA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSP_TEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDVT_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueDVT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSP_HAMLUONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSP_DANGDUNG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGIA_KEHOACH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.seGia = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colSP_GOITHAU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueGridGoiThau = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lueMaSanPham = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lueTenSanPham = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoiThau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGridGoiThau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTenSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 443);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(991, 60);
            this.panelControl1.TabIndex = 22;
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
            this.btnControl.btnSize = new System.Drawing.Size(85, 32);
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
            this.btnControl.Location = new System.Drawing.Point(792, 2);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(197, 56);
            this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
            this.btnControl.TabIndex = 0;
            this.btnControl.btnEventAdd_Click += new System.EventHandler(this.btnControl_btnEventAdd_Click);
            this.btnControl.btnEventModify_Click += new System.EventHandler(this.btnControl_btnEventModify_Click);
            this.btnControl.btnEventDelete_Click += new System.EventHandler(this.btnControl_btnEventDelete_Click);
            this.btnControl.btnEventSave_Click += new System.EventHandler(this.btnControl_btnEventSave_Click);
            this.btnControl.btnEventCancel_Click += new System.EventHandler(this.btnControl_btnEventCancel_Click);
            this.btnControl.btnEventClose_Click += new System.EventHandler(this.btnControl_btnEventClose_Click_1);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.chkAll);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.lueGoiThau);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(991, 56);
            this.groupControl1.TabIndex = 23;
            this.groupControl1.Text = "Lựa chọn";
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(533, 30);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "Hiển thị tất cả gói thầu";
            this.chkAll.Size = new System.Drawing.Size(134, 20);
            this.chkAll.TabIndex = 26;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Location = new System.Drawing.Point(8, 32);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 17);
            this.labelControl2.TabIndex = 25;
            this.labelControl2.Text = "Gói thầu";
            // 
            // lueGoiThau
            // 
            this.lueGoiThau.Location = new System.Drawing.Point(65, 29);
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
            this.lueGoiThau.Size = new System.Drawing.Size(461, 20);
            this.lueGoiThau.TabIndex = 24;
            this.lueGoiThau.EditValueChanged += new System.EventHandler(this.lueGoiThau_EditValueChanged);
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
            this.gcGrid.Location = new System.Drawing.Point(0, 56);
            this.gcGrid.MainView = this.gvGrid;
            this.gcGrid.Name = "gcGrid";
            this.gcGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueDVT,
            this.lueMaSanPham,
            this.lueTenSanPham,
            this.lueGridGoiThau,
            this.seGia});
            this.gcGrid.Size = new System.Drawing.Size(991, 387);
            this.gcGrid.TabIndex = 24;
            this.gcGrid.UseEmbeddedNavigator = true;
            this.gcGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGrid});
            // 
            // gvGrid
            // 
            this.gvGrid.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvGrid.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvGrid.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvGrid.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvGrid.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvGrid.Appearance.Row.Options.UseFont = true;
            this.gvGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gvGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colDOT_MA,
            this.colSP_MA,
            this.colSP_TEN,
            this.colDVT_ID,
            this.colSP_HAMLUONG,
            this.colSP_DANGDUNG,
            this.colGIA_KEHOACH,
            this.colSP_GOITHAU});
            this.gvGrid.GridControl = this.gcGrid;
            this.gvGrid.GroupCount = 1;
            this.gvGrid.Name = "gvGrid";
            this.gvGrid.NewItemRowText = "Nhấp vào đây để thêm dòng dữ liệu mới";
            this.gvGrid.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvGrid.OptionsView.EnableAppearanceEvenRow = true;
            this.gvGrid.OptionsView.ShowGroupPanel = false;
            this.gvGrid.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSP_GOITHAU, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvGrid.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvGrid_InitNewRow);
            this.gvGrid.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvGrid_InvalidRowException);
            this.gvGrid.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvGrid_ValidateRow);
            this.gvGrid.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvGrid_ValidatingEditor);
            this.gvGrid.RowCountChanged += new System.EventHandler(this.gvGrid_RowCountChanged);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colDOT_MA
            // 
            this.colDOT_MA.Caption = "DOT_MA";
            this.colDOT_MA.FieldName = "DOT_MA";
            this.colDOT_MA.Name = "colDOT_MA";
            // 
            // colSP_MA
            // 
            this.colSP_MA.Caption = "Mã sản phẩm";
            this.colSP_MA.FieldName = "SP_MA";
            this.colSP_MA.Name = "colSP_MA";
            this.colSP_MA.OptionsColumn.AllowEdit = false;
            this.colSP_MA.Visible = true;
            this.colSP_MA.VisibleIndex = 0;
            // 
            // colSP_TEN
            // 
            this.colSP_TEN.Caption = "Tên sản phẩm";
            this.colSP_TEN.FieldName = "SP_TEN";
            this.colSP_TEN.Name = "colSP_TEN";
            this.colSP_TEN.OptionsColumn.AllowEdit = false;
            this.colSP_TEN.Visible = true;
            this.colSP_TEN.VisibleIndex = 1;
            // 
            // colDVT_ID
            // 
            this.colDVT_ID.Caption = "Đơn vị tính";
            this.colDVT_ID.ColumnEdit = this.lueDVT;
            this.colDVT_ID.FieldName = "DVT_ID";
            this.colDVT_ID.Name = "colDVT_ID";
            this.colDVT_ID.OptionsColumn.AllowEdit = false;
            this.colDVT_ID.Visible = true;
            this.colDVT_ID.VisibleIndex = 2;
            // 
            // lueDVT
            // 
            this.lueDVT.AutoHeight = false;
            this.lueDVT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDVT.DisplayMember = "TEN";
            this.lueDVT.Name = "lueDVT";
            this.lueDVT.NullText = "";
            this.lueDVT.ValueMember = "DVT_ID";
            // 
            // colSP_HAMLUONG
            // 
            this.colSP_HAMLUONG.Caption = "Hàm lượng";
            this.colSP_HAMLUONG.FieldName = "SP_HAMLUONG";
            this.colSP_HAMLUONG.Name = "colSP_HAMLUONG";
            this.colSP_HAMLUONG.OptionsColumn.AllowEdit = false;
            this.colSP_HAMLUONG.Visible = true;
            this.colSP_HAMLUONG.VisibleIndex = 3;
            // 
            // colSP_DANGDUNG
            // 
            this.colSP_DANGDUNG.Caption = "Dạng dùng";
            this.colSP_DANGDUNG.FieldName = "SP_DANGDUNG";
            this.colSP_DANGDUNG.Name = "colSP_DANGDUNG";
            this.colSP_DANGDUNG.OptionsColumn.AllowEdit = false;
            this.colSP_DANGDUNG.Visible = true;
            this.colSP_DANGDUNG.VisibleIndex = 4;
            // 
            // colGIA_KEHOACH
            // 
            this.colGIA_KEHOACH.Caption = "Giá kế hoạch";
            this.colGIA_KEHOACH.ColumnEdit = this.seGia;
            this.colGIA_KEHOACH.FieldName = "SP_GIAKEHOACH";
            this.colGIA_KEHOACH.Name = "colGIA_KEHOACH";
            this.colGIA_KEHOACH.Visible = true;
            this.colGIA_KEHOACH.VisibleIndex = 5;
            // 
            // seGia
            // 
            this.seGia.AutoHeight = false;
            this.seGia.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seGia.DisplayFormat.FormatString = "###,##0.###";
            this.seGia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seGia.EditFormat.FormatString = "###,##0.###";
            this.seGia.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seGia.Mask.EditMask = "###,##0.###";
            this.seGia.Name = "seGia";
            // 
            // colSP_GOITHAU
            // 
            this.colSP_GOITHAU.Caption = "Gói thầu";
            this.colSP_GOITHAU.ColumnEdit = this.lueGridGoiThau;
            this.colSP_GOITHAU.FieldName = "SP_GOITHAU";
            this.colSP_GOITHAU.Name = "colSP_GOITHAU";
            // 
            // lueGridGoiThau
            // 
            this.lueGridGoiThau.AutoHeight = false;
            this.lueGridGoiThau.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGridGoiThau.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GOITHAU_ID", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueGridGoiThau.DisplayMember = "TEN";
            this.lueGridGoiThau.Name = "lueGridGoiThau";
            this.lueGridGoiThau.ValueMember = "GOITHAU_ID";
            // 
            // lueMaSanPham
            // 
            this.lueMaSanPham.AutoHeight = false;
            this.lueMaSanPham.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMaSanPham.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SP_MA", "Mã sản phẩm"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SP_TEN", "Tên sản phẩm"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DVT_ID", "Name7", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SP_HAMLUONG", "Name11", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SP_DANGDUNG", "Name12", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lueMaSanPham.DisplayMember = "SP_MA";
            this.lueMaSanPham.Name = "lueMaSanPham";
            this.lueMaSanPham.NullText = "";
            this.lueMaSanPham.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueMaSanPham.ValueMember = "SP_MA";
            this.lueMaSanPham.EditValueChanged += new System.EventHandler(this.lueMaSanPham_EditValueChanged);
            // 
            // lueTenSanPham
            // 
            this.lueTenSanPham.AutoHeight = false;
            this.lueTenSanPham.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTenSanPham.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SP_MA", "Mã sản phẩm", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SP_TEN", "Tên sản phẩm"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SP_DANGDUNG", "Name15", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DVT_ID", "Name16", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SP_HAMLUONG", "Name17", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lueTenSanPham.DisplayMember = "SP_TEN";
            this.lueTenSanPham.Name = "lueTenSanPham";
            this.lueTenSanPham.NullText = "";
            this.lueTenSanPham.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueTenSanPham.ValueMember = "SP_MA";
            this.lueTenSanPham.EditValueChanged += new System.EventHandler(this.lueTenSanPham_EditValueChanged);
            // 
            // ucGiaKeHoach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcGrid);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucGiaKeHoach";
            this.Size = new System.Drawing.Size(991, 503);
            this.Load += new System.EventHandler(this.ucGiaKeHoach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoiThau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGridGoiThau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTenSanPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private ControlsLib.ButtonsArray btnControl;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGrid;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colSP_MA;
        private DevExpress.XtraGrid.Columns.GridColumn colSP_TEN;
        private DevExpress.XtraGrid.Columns.GridColumn colDVT_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSP_HAMLUONG;
        private DevExpress.XtraGrid.Columns.GridColumn colSP_DANGDUNG;
        private DevExpress.XtraGrid.Columns.GridColumn colGIA_KEHOACH;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lueGoiThau;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueDVT;
        private DevExpress.XtraGrid.Columns.GridColumn colDOT_MA;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueMaSanPham;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTenSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn colSP_GOITHAU;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueGridGoiThau;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit seGia;
    }
}
