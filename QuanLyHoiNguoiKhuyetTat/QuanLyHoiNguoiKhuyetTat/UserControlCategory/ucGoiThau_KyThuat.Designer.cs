namespace DauThau.UserControlCategory
{
    partial class ucGoiThau_KyThuat
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
            this.colGOITHAU_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGOITHAU_KYTHUAT_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNHOM_KYTHUAT_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueNhomKT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colNHOM_KYTHUAT_CT_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueNhomKT_CT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDIEM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSORT_NHOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colSORT_CT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCHOPHEP_CHON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lueGoiThau_KT = new DevExpress.XtraEditors.LookUpEdit();
            this.lueLoaiHang = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lueDonViTinh = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnControl = new ControlsLib.ButtonsArray();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtMaHang = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.calEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.DtNgay = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemImageEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.SpinEditDonGiaBan = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colTHUOC_PHAN = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueNhomKT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueNhomKT_CT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoiThau_KT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDonViTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtNgay.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDonGiaBan)).BeginInit();
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
            this.gcGrid.Location = new System.Drawing.Point(0, 52);
            this.gcGrid.MainView = this.gvGrid;
            this.gcGrid.Name = "gcGrid";
            this.gcGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueNhomKT,
            this.lueNhomKT_CT,
            this.repositoryItemSpinEdit2});
            this.gcGrid.Size = new System.Drawing.Size(979, 417);
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
            this.gvGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGOITHAU_ID,
            this.colGOITHAU_KYTHUAT_ID,
            this.colNHOM_KYTHUAT_ID,
            this.colNHOM_KYTHUAT_CT_ID,
            this.colDIEM,
            this.colSORT_NHOM,
            this.colSORT_CT,
            this.colCHOPHEP_CHON,
            this.colTHUOC_PHAN});
            this.gvGrid.GridControl = this.gcGrid;
            this.gvGrid.GroupCount = 1;
            this.gvGrid.GroupFormat = "[#image]{1} {2}";
            this.gvGrid.Name = "gvGrid";
            this.gvGrid.NewItemRowText = "Nhấp vào đây để thêm dòng dữ liệu mới";
            this.gvGrid.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvGrid.OptionsView.ShowGroupedColumns = true;
            this.gvGrid.OptionsView.ShowGroupPanel = false;
            this.gvGrid.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNHOM_KYTHUAT_ID, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvGrid.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvGrid_InitNewRow);
            // 
            // colGOITHAU_ID
            // 
            this.colGOITHAU_ID.Caption = "ID";
            this.colGOITHAU_ID.FieldName = "GOITHAU_ID";
            this.colGOITHAU_ID.Name = "colGOITHAU_ID";
            // 
            // colGOITHAU_KYTHUAT_ID
            // 
            this.colGOITHAU_KYTHUAT_ID.Caption = "GOITHAU_KYTHUAT_ID";
            this.colGOITHAU_KYTHUAT_ID.FieldName = "GOITHAU_KYTHUAT_ID";
            this.colGOITHAU_KYTHUAT_ID.Name = "colGOITHAU_KYTHUAT_ID";
            this.colGOITHAU_KYTHUAT_ID.Width = 93;
            // 
            // colNHOM_KYTHUAT_ID
            // 
            this.colNHOM_KYTHUAT_ID.Caption = "Nhóm kỹ thuật";
            this.colNHOM_KYTHUAT_ID.ColumnEdit = this.lueNhomKT;
            this.colNHOM_KYTHUAT_ID.FieldName = "NHOM_KYTHUAT_ID";
            this.colNHOM_KYTHUAT_ID.Name = "colNHOM_KYTHUAT_ID";
            this.colNHOM_KYTHUAT_ID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colNHOM_KYTHUAT_ID.Visible = true;
            this.colNHOM_KYTHUAT_ID.VisibleIndex = 0;
            // 
            // lueNhomKT
            // 
            this.lueNhomKT.AutoHeight = false;
            this.lueNhomKT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueNhomKT.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NHOM_KYTHUAT_ID", "Name11", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Nhóm kỷ thuật")});
            this.lueNhomKT.DisplayMember = "TEN";
            this.lueNhomKT.Name = "lueNhomKT";
            this.lueNhomKT.NullText = "";
            this.lueNhomKT.ValueMember = "NHOM_KYTHUAT_ID";
            // 
            // colNHOM_KYTHUAT_CT_ID
            // 
            this.colNHOM_KYTHUAT_CT_ID.Caption = "Chi tiết";
            this.colNHOM_KYTHUAT_CT_ID.ColumnEdit = this.lueNhomKT_CT;
            this.colNHOM_KYTHUAT_CT_ID.FieldName = "NHOM_KYTHUAT_CT_ID";
            this.colNHOM_KYTHUAT_CT_ID.Name = "colNHOM_KYTHUAT_CT_ID";
            this.colNHOM_KYTHUAT_CT_ID.Visible = true;
            this.colNHOM_KYTHUAT_CT_ID.VisibleIndex = 1;
            // 
            // lueNhomKT_CT
            // 
            this.lueNhomKT_CT.AutoHeight = false;
            this.lueNhomKT_CT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueNhomKT_CT.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NHOM_KYTHUAT_CT_ID", "Name13", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Kỷ thuật chi tiết")});
            this.lueNhomKT_CT.DisplayMember = "TEN";
            this.lueNhomKT_CT.Name = "lueNhomKT_CT";
            this.lueNhomKT_CT.NullText = "";
            this.lueNhomKT_CT.ValueMember = "NHOM_KYTHUAT_CT_ID";
            // 
            // colDIEM
            // 
            this.colDIEM.Caption = "Điểm";
            this.colDIEM.FieldName = "DIEM";
            this.colDIEM.Name = "colDIEM";
            this.colDIEM.Visible = true;
            this.colDIEM.VisibleIndex = 2;
            // 
            // colSORT_NHOM
            // 
            this.colSORT_NHOM.Caption = "Sắp xếp nhóm";
            this.colSORT_NHOM.ColumnEdit = this.repositoryItemSpinEdit2;
            this.colSORT_NHOM.FieldName = "SORT_NHOM";
            this.colSORT_NHOM.Name = "colSORT_NHOM";
            this.colSORT_NHOM.Visible = true;
            this.colSORT_NHOM.VisibleIndex = 3;
            // 
            // repositoryItemSpinEdit2
            // 
            this.repositoryItemSpinEdit2.AutoHeight = false;
            this.repositoryItemSpinEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit2.Name = "repositoryItemSpinEdit2";
            // 
            // colSORT_CT
            // 
            this.colSORT_CT.Caption = "Sắp xếp chi tiết";
            this.colSORT_CT.ColumnEdit = this.repositoryItemSpinEdit2;
            this.colSORT_CT.FieldName = "SORT_CT";
            this.colSORT_CT.Name = "colSORT_CT";
            this.colSORT_CT.Visible = true;
            this.colSORT_CT.VisibleIndex = 4;
            // 
            // colCHOPHEP_CHON
            // 
            this.colCHOPHEP_CHON.Caption = "Cho phép chọn";
            this.colCHOPHEP_CHON.FieldName = "CHOPHEP_CHON";
            this.colCHOPHEP_CHON.Name = "colCHOPHEP_CHON";
            this.colCHOPHEP_CHON.Visible = true;
            this.colCHOPHEP_CHON.VisibleIndex = 5;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.lueGoiThau_KT);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(979, 52);
            this.groupControl1.TabIndex = 26;
            this.groupControl1.Text = "Lựa chọn";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl1.Location = new System.Drawing.Point(12, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 14);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "Gói thầu";
            // 
            // lueGoiThau_KT
            // 
            this.lueGoiThau_KT.Location = new System.Drawing.Point(61, 25);
            this.lueGoiThau_KT.Name = "lueGoiThau_KT";
            this.lueGoiThau_KT.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lueGoiThau_KT.Properties.Appearance.Options.UseFont = true;
            this.lueGoiThau_KT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGoiThau_KT.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GOITHAU_ID", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueGoiThau_KT.Properties.DisplayMember = "TEN";
            this.lueGoiThau_KT.Properties.NullText = "Vui lòng chọn gói thầu";
            this.lueGoiThau_KT.Properties.ValueMember = "GOITHAU_ID";
            this.lueGoiThau_KT.Size = new System.Drawing.Size(355, 20);
            this.lueGoiThau_KT.TabIndex = 22;
            this.lueGoiThau_KT.EditValueChanged += new System.EventHandler(this.lueGoiThau_KT_EditValueChanged);
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
            this.btnControl.Location = new System.Drawing.Point(724, 0);
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
            this.panelControl1.Controls.Add(this.btnControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 469);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(979, 60);
            this.panelControl1.TabIndex = 24;
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
            // DtNgay
            // 
            this.DtNgay.AutoHeight = false;
            this.DtNgay.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtNgay.Name = "DtNgay";
            this.DtNgay.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
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
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
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
            // colTHUOC_PHAN
            // 
            this.colTHUOC_PHAN.Caption = "Thuộc phần";
            this.colTHUOC_PHAN.FieldName = "THUOC_PHAN";
            this.colTHUOC_PHAN.Name = "colTHUOC_PHAN";
            this.colTHUOC_PHAN.Visible = true;
            this.colTHUOC_PHAN.VisibleIndex = 6;
            // 
            // ucGoiThau_KyThuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcGrid);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucGoiThau_KyThuat";
            this.Size = new System.Drawing.Size(979, 529);
            this.Load += new System.EventHandler(this.ucGoiThau_KyThuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueNhomKT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueNhomKT_CT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoiThau_KT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDonViTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMaHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtNgay.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDonGiaBan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGrid;
        private DevExpress.XtraGrid.Columns.GridColumn colGOITHAU_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colGOITHAU_KYTHUAT_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colNHOM_KYTHUAT_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colNHOM_KYTHUAT_CT_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colDIEM;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lueGoiThau_KT;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueLoaiHang;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueDonViTinh;
        private ControlsLib.ButtonsArray btnControl;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtMaHang;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit calEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit DtNgay;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit SpinEditDonGiaBan;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueNhomKT;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueNhomKT_CT;
        private DevExpress.XtraGrid.Columns.GridColumn colSORT_NHOM;
        private DevExpress.XtraGrid.Columns.GridColumn colSORT_CT;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colCHOPHEP_CHON;
        private DevExpress.XtraGrid.Columns.GridColumn colTHUOC_PHAN;

    }
}
