namespace DauThau.UserControlCategory
{
    partial class ucSP_DanhSach
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
            this.colSP_MA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSP_TEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menoEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colSP_TEN_THUONGMAI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHANGSX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNUOCSX_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueNuocSX = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colNUOCLD_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSP_SODK_VISA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGIA_CHAOTHAU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTONGDIEM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGOITHAU_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueGoiThau = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menoEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueNuocSX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoiThau)).BeginInit();
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
            this.lueGoiThau,
            this.lueNuocSX,
            this.menoEdit});
            this.gcGrid.Size = new System.Drawing.Size(1024, 455);
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
            this.colSP_MA,
            this.colSP_TEN,
            this.colSP_TEN_THUONGMAI,
            this.colHANGSX,
            this.colNUOCSX_ID,
            this.colNUOCLD_ID,
            this.colSP_SODK_VISA,
            this.colGIA_CHAOTHAU,
            this.colTONGDIEM,
            this.colGOITHAU_ID});
            this.gvGrid.GridControl = this.gcGrid;
            this.gvGrid.GroupCount = 1;
            this.gvGrid.GroupFormat = " [#image]{1} {2}";
            this.gvGrid.Name = "gvGrid";
            this.gvGrid.NewItemRowText = "Nhấp vào đây để thêm dòng dữ liệu mới";
            this.gvGrid.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvGrid.OptionsBehavior.Editable = false;
            this.gvGrid.OptionsView.RowAutoHeight = true;
            this.gvGrid.OptionsView.ShowGroupPanel = false;
            this.gvGrid.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colGOITHAU_ID, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colSP_MA
            // 
            this.colSP_MA.Caption = "Mã SP";
            this.colSP_MA.FieldName = "SP_MA";
            this.colSP_MA.Name = "colSP_MA";
            this.colSP_MA.Visible = true;
            this.colSP_MA.VisibleIndex = 0;
            this.colSP_MA.Width = 103;
            // 
            // colSP_TEN
            // 
            this.colSP_TEN.Caption = "Tên hoạt chất";
            this.colSP_TEN.ColumnEdit = this.menoEdit;
            this.colSP_TEN.FieldName = "SP_TEN";
            this.colSP_TEN.Name = "colSP_TEN";
            this.colSP_TEN.Visible = true;
            this.colSP_TEN.VisibleIndex = 1;
            this.colSP_TEN.Width = 266;
            // 
            // menoEdit
            // 
            this.menoEdit.Name = "menoEdit";
            // 
            // colSP_TEN_THUONGMAI
            // 
            this.colSP_TEN_THUONGMAI.Caption = "Tên thương mại";
            this.colSP_TEN_THUONGMAI.ColumnEdit = this.menoEdit;
            this.colSP_TEN_THUONGMAI.FieldName = "SP_TEN_THUONGMAI";
            this.colSP_TEN_THUONGMAI.Name = "colSP_TEN_THUONGMAI";
            this.colSP_TEN_THUONGMAI.Visible = true;
            this.colSP_TEN_THUONGMAI.VisibleIndex = 2;
            this.colSP_TEN_THUONGMAI.Width = 117;
            // 
            // colHANGSX
            // 
            this.colHANGSX.Caption = "Hãng SX";
            this.colHANGSX.FieldName = "HANGSX";
            this.colHANGSX.Name = "colHANGSX";
            this.colHANGSX.Visible = true;
            this.colHANGSX.VisibleIndex = 3;
            this.colHANGSX.Width = 108;
            // 
            // colNUOCSX_ID
            // 
            this.colNUOCSX_ID.Caption = "Nước SX";
            this.colNUOCSX_ID.ColumnEdit = this.lueNuocSX;
            this.colNUOCSX_ID.FieldName = "NUOCSX_ID";
            this.colNUOCSX_ID.Name = "colNUOCSX_ID";
            this.colNUOCSX_ID.Visible = true;
            this.colNUOCSX_ID.VisibleIndex = 4;
            this.colNUOCSX_ID.Width = 108;
            // 
            // lueNuocSX
            // 
            this.lueNuocSX.AutoHeight = false;
            this.lueNuocSX.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueNuocSX.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NUOCSX_ID", "Name3", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Nước")});
            this.lueNuocSX.DisplayMember = "TEN";
            this.lueNuocSX.Name = "lueNuocSX";
            this.lueNuocSX.ValueMember = "NUOCSX_ID";
            // 
            // colNUOCLD_ID
            // 
            this.colNUOCLD_ID.Caption = "Nước LD";
            this.colNUOCLD_ID.ColumnEdit = this.lueNuocSX;
            this.colNUOCLD_ID.FieldName = "NUOCLD_ID";
            this.colNUOCLD_ID.Name = "colNUOCLD_ID";
            this.colNUOCLD_ID.Visible = true;
            this.colNUOCLD_ID.VisibleIndex = 5;
            this.colNUOCLD_ID.Width = 108;
            // 
            // colSP_SODK_VISA
            // 
            this.colSP_SODK_VISA.Caption = "Số ĐK";
            this.colSP_SODK_VISA.FieldName = "SP_SODK_VISA";
            this.colSP_SODK_VISA.Name = "colSP_SODK_VISA";
            this.colSP_SODK_VISA.Visible = true;
            this.colSP_SODK_VISA.VisibleIndex = 6;
            this.colSP_SODK_VISA.Width = 129;
            // 
            // colGIA_CHAOTHAU
            // 
            this.colGIA_CHAOTHAU.Caption = "Giá";
            this.colGIA_CHAOTHAU.FieldName = "GIA_CHAOTHAU";
            this.colGIA_CHAOTHAU.Name = "colGIA_CHAOTHAU";
            this.colGIA_CHAOTHAU.Visible = true;
            this.colGIA_CHAOTHAU.VisibleIndex = 7;
            this.colGIA_CHAOTHAU.Width = 129;
            // 
            // colTONGDIEM
            // 
            this.colTONGDIEM.Caption = "Điểm";
            this.colTONGDIEM.FieldName = "TONGDIEM";
            this.colTONGDIEM.Name = "colTONGDIEM";
            this.colTONGDIEM.Visible = true;
            this.colTONGDIEM.VisibleIndex = 8;
            this.colTONGDIEM.Width = 96;
            // 
            // colGOITHAU_ID
            // 
            this.colGOITHAU_ID.Caption = "Gói thầu";
            this.colGOITHAU_ID.ColumnEdit = this.lueGoiThau;
            this.colGOITHAU_ID.FieldName = "GOITHAU_ID";
            this.colGOITHAU_ID.Name = "colGOITHAU_ID";
            // 
            // lueGoiThau
            // 
            this.lueGoiThau.AutoHeight = false;
            this.lueGoiThau.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGoiThau.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GOITHAU_ID", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueGoiThau.DisplayMember = "TEN";
            this.lueGoiThau.Name = "lueGoiThau";
            this.lueGoiThau.ValueMember = "GOITHAU_ID";
            // 
            // ucSP_DanhSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcGrid);
            this.Name = "ucSP_DanhSach";
            this.Size = new System.Drawing.Size(1024, 455);
            this.Load += new System.EventHandler(this.ucSP_DanhSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menoEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueNuocSX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoiThau)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGrid;
        private DevExpress.XtraGrid.Columns.GridColumn colSP_MA;
        private DevExpress.XtraGrid.Columns.GridColumn colSP_TEN;
        private DevExpress.XtraGrid.Columns.GridColumn colSP_TEN_THUONGMAI;
        private DevExpress.XtraGrid.Columns.GridColumn colHANGSX;
        private DevExpress.XtraGrid.Columns.GridColumn colNUOCSX_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colNUOCLD_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSP_SODK_VISA;
        private DevExpress.XtraGrid.Columns.GridColumn colGIA_CHAOTHAU;
        private DevExpress.XtraGrid.Columns.GridColumn colTONGDIEM;
        private DevExpress.XtraGrid.Columns.GridColumn colGOITHAU_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueNuocSX;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueGoiThau;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit menoEdit;
    }
}
