namespace DauThau.UserControlCategoryMain
{
    partial class ucHANGSX_NUOCSX
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colCHON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkChon = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gcGrid = new DevExpress.XtraGrid.GridControl();
            this.gvGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHANGSX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGOITHAU_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueDVT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lueMaSanPham = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lueTenSanPham = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lueGridGoiThau = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.seGia = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.lueGoiThau = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gc = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNUOCSX_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNUOCSX_TEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHANGSX_NUOCSX_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chkChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTenSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGridGoiThau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoiThau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.SuspendLayout();
            // 
            // colCHON
            // 
            this.colCHON.Caption = "Chọn";
            this.colCHON.ColumnEdit = this.chkChon;
            this.colCHON.FieldName = "CHON";
            this.colCHON.Name = "colCHON";
            this.colCHON.Visible = true;
            this.colCHON.VisibleIndex = 0;
            this.colCHON.Width = 103;
            // 
            // chkChon
            // 
            this.chkChon.AutoHeight = false;
            this.chkChon.Name = "chkChon";
            this.chkChon.CheckedChanged += new System.EventHandler(this.chkChon_CheckedChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(415, 507);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Hãng sản xuất";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gcGrid);
            this.layoutControl1.Controls.Add(this.lueGoiThau);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 23);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(411, 482);
            this.layoutControl1.TabIndex = 26;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gcGrid
            // 
            this.gcGrid.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcGrid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcGrid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcGrid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcGrid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcGrid.EmbeddedNavigator.TextStringFormat = "Dòng {0} / {1}";
            this.gcGrid.Location = new System.Drawing.Point(2, 26);
            this.gcGrid.MainView = this.gvGrid;
            this.gcGrid.Name = "gcGrid";
            this.gcGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueDVT,
            this.lueMaSanPham,
            this.lueTenSanPham,
            this.lueGridGoiThau,
            this.seGia});
            this.gcGrid.Size = new System.Drawing.Size(407, 454);
            this.gcGrid.TabIndex = 27;
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
            this.colHANGSX,
            this.colGOITHAU_ID,
            this.colID});
            this.gvGrid.GridControl = this.gcGrid;
            this.gvGrid.Name = "gvGrid";
            this.gvGrid.NewItemRowText = "Nhấp vào đây để thêm dòng dữ liệu mới";
            this.gvGrid.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvGrid.OptionsBehavior.Editable = false;
            this.gvGrid.OptionsView.EnableAppearanceEvenRow = true;
            this.gvGrid.OptionsView.ShowGroupPanel = false;
            this.gvGrid.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvGrid_RowClick);
            // 
            // colHANGSX
            // 
            this.colHANGSX.Caption = "Hãng sản xuất";
            this.colHANGSX.FieldName = "HANGSX";
            this.colHANGSX.Name = "colHANGSX";
            this.colHANGSX.Visible = true;
            this.colHANGSX.VisibleIndex = 0;
            // 
            // colGOITHAU_ID
            // 
            this.colGOITHAU_ID.Caption = "Gói thầu";
            this.colGOITHAU_ID.FieldName = "GOITHAU_ID";
            this.colGOITHAU_ID.Name = "colGOITHAU_ID";
            // 
            // colID
            // 
            this.colID.Caption = "gridColumn1";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
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
            // seGia
            // 
            this.seGia.AutoHeight = false;
            this.seGia.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seGia.DisplayFormat.FormatString = "###,###";
            this.seGia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seGia.EditFormat.FormatString = "###,###";
            this.seGia.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seGia.Mask.EditMask = "n0";
            this.seGia.Name = "seGia";
            // 
            // lueGoiThau
            // 
            this.lueGoiThau.Location = new System.Drawing.Point(52, 2);
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
            this.lueGoiThau.Size = new System.Drawing.Size(357, 20);
            this.lueGoiThau.StyleController = this.layoutControl1;
            this.lueGoiThau.TabIndex = 25;
            this.lueGoiThau.EditValueChanged += new System.EventHandler(this.lueGoiThau_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(411, 482);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.lueGoiThau;
            this.layoutControlItem1.CustomizationFormText = "Gói thầu";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(411, 24);
            this.layoutControlItem1.Text = "Gói thầu";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(46, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gcGrid;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(411, 458);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gc);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(882, 507);
            this.splitContainerControl1.SplitterPosition = 415;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gc
            // 
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gc.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gc.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gc.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gc.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gc.EmbeddedNavigator.TextStringFormat = "Dòng {0} / {1}";
            this.gc.Location = new System.Drawing.Point(0, 0);
            this.gc.MainView = this.gv;
            this.gc.Name = "gc";
            this.gc.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkChon});
            this.gc.Size = new System.Drawing.Size(463, 507);
            this.gc.TabIndex = 27;
            this.gc.UseEmbeddedNavigator = true;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gv.Appearance.HeaderPanel.Options.UseFont = true;
            this.gv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gv.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gv.Appearance.Row.Options.UseFont = true;
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNUOCSX_ID,
            this.colNUOCSX_TEN,
            this.colCHON,
            this.colHANGSX_NUOCSX_ID});
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            styleFormatCondition2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.Appearance.Options.UseFont = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.colCHON;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = true;
            this.gv.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition2});
            this.gv.GridControl = this.gc;
            this.gv.Name = "gv";
            this.gv.NewItemRowText = "Nhấp vào đây để thêm dòng dữ liệu mới";
            this.gv.OptionsBehavior.AutoExpandAllGroups = true;
            this.gv.OptionsView.EnableAppearanceEvenRow = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            // 
            // colNUOCSX_ID
            // 
            this.colNUOCSX_ID.Caption = "NUOCSX_ID";
            this.colNUOCSX_ID.FieldName = "NUOCSX_ID";
            this.colNUOCSX_ID.Name = "colNUOCSX_ID";
            // 
            // colNUOCSX_TEN
            // 
            this.colNUOCSX_TEN.Caption = "Nước sản xuất";
            this.colNUOCSX_TEN.FieldName = "TEN";
            this.colNUOCSX_TEN.Name = "colNUOCSX_TEN";
            this.colNUOCSX_TEN.OptionsColumn.AllowEdit = false;
            this.colNUOCSX_TEN.Visible = true;
            this.colNUOCSX_TEN.VisibleIndex = 1;
            this.colNUOCSX_TEN.Width = 1078;
            // 
            // colHANGSX_NUOCSX_ID
            // 
            this.colHANGSX_NUOCSX_ID.Caption = "HANGSX_NUOCSX_ID";
            this.colHANGSX_NUOCSX_ID.FieldName = "HANGSX_NUOCSX_ID";
            this.colHANGSX_NUOCSX_ID.Name = "colHANGSX_NUOCSX_ID";
            // 
            // ucHANGSX_NUOCSX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "ucHANGSX_NUOCSX";
            this.Size = new System.Drawing.Size(882, 507);
            this.Load += new System.EventHandler(this.ucHANGSX_NUOCSX_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTenSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGridGoiThau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoiThau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LookUpEdit lueGoiThau;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gcGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGrid;
        private DevExpress.XtraGrid.Columns.GridColumn colHANGSX;
        private DevExpress.XtraGrid.Columns.GridColumn colGOITHAU_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueDVT;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueMaSanPham;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTenSanPham;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueGridGoiThau;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit seGia;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gc;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.Columns.GridColumn colNUOCSX_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colNUOCSX_TEN;
        private DevExpress.XtraGrid.Columns.GridColumn colCHON;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkChon;
        private DevExpress.XtraGrid.Columns.GridColumn colHANGSX_NUOCSX_ID;
    }
}
