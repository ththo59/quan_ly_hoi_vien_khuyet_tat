namespace DauThau.UserControlCategoryMain
{
    partial class ucUpdateDiemKTTheoSP
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucUpdateDiemKTTheoSP));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnXem = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lueGoiThau = new DevExpress.XtraEditors.LookUpEdit();
            this.lueCongTy = new DevExpress.XtraEditors.LookUpEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcSanPham = new DevExpress.XtraGrid.GridControl();
            this.gvSanPham = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.colTitle = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colDAU_THAU_ID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSP_MA = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSP_TEN = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gcDiemKT = new DevExpress.XtraGrid.GridControl();
            this.gvDiemKT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.bandYCKT = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDAUTHAU_ID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.seDiem = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repUpdateDiemKT = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoiThau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCongTy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDiemKT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDiemKT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repUpdateDiemKT)).BeginInit();
            this.SuspendLayout();
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
            this.groupControl1.Size = new System.Drawing.Size(943, 58);
            this.groupControl1.TabIndex = 25;
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
            this.lueGoiThau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGoiThau.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GOITHAU_ID", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueGoiThau.Properties.DisplayMember = "TEN";
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnLuu);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 465);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(943, 60);
            this.panelControl1.TabIndex = 26;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Image = global::DauThau.Properties.Resources.save;
            this.btnLuu.Location = new System.Drawing.Point(856, 13);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 38);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 58);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcSanPham);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcDiemKT);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(943, 407);
            this.splitContainerControl1.SplitterPosition = 363;
            this.splitContainerControl1.TabIndex = 27;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gcSanPham
            // 
            this.gcSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSanPham.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcSanPham.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcSanPham.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcSanPham.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcSanPham.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcSanPham.EmbeddedNavigator.TextStringFormat = "Dòng {0} / {1}";
            this.gcSanPham.Location = new System.Drawing.Point(0, 0);
            this.gcSanPham.MainView = this.gvSanPham;
            this.gcSanPham.Name = "gcSanPham";
            this.gcSanPham.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.gcSanPham.Size = new System.Drawing.Size(363, 407);
            this.gcSanPham.TabIndex = 25;
            this.gcSanPham.UseEmbeddedNavigator = true;
            this.gcSanPham.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSanPham});
            // 
            // gvSanPham
            // 
            this.gvSanPham.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gvSanPham.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvSanPham.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvSanPham.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvSanPham.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gvSanPham.Appearance.Row.Options.UseFont = true;
            this.gvSanPham.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.colTitle});
            this.gvSanPham.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colDAU_THAU_ID,
            this.colSP_MA,
            this.colSP_TEN});
            this.gvSanPham.GridControl = this.gcSanPham;
            this.gvSanPham.Name = "gvSanPham";
            this.gvSanPham.NewItemRowText = "Nhấp vào đây để thêm dòng dữ liệu mới";
            this.gvSanPham.OptionsView.RowAutoHeight = true;
            this.gvSanPham.OptionsView.ShowGroupPanel = false;
            this.gvSanPham.Click += new System.EventHandler(this.gvSanPham_Click);
            // 
            // colTitle
            // 
            this.colTitle.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colTitle.AppearanceHeader.Options.UseFont = true;
            this.colTitle.AppearanceHeader.Options.UseTextOptions = true;
            this.colTitle.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTitle.Caption = "Sản phẩm";
            this.colTitle.Columns.Add(this.colDAU_THAU_ID);
            this.colTitle.Columns.Add(this.colSP_MA);
            this.colTitle.Columns.Add(this.colSP_TEN);
            this.colTitle.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.colTitle.Name = "colTitle";
            this.colTitle.VisibleIndex = 0;
            this.colTitle.Width = 277;
            // 
            // colDAU_THAU_ID
            // 
            this.colDAU_THAU_ID.Caption = "gridColumn1";
            this.colDAU_THAU_ID.FieldName = "DAUTHAU_ID";
            this.colDAU_THAU_ID.Name = "colDAU_THAU_ID";
            // 
            // colSP_MA
            // 
            this.colSP_MA.Caption = "Mã sản phẩm";
            this.colSP_MA.FieldName = "SP_MA";
            this.colSP_MA.Name = "colSP_MA";
            this.colSP_MA.OptionsColumn.AllowEdit = false;
            this.colSP_MA.Visible = true;
            this.colSP_MA.Width = 91;
            // 
            // colSP_TEN
            // 
            this.colSP_TEN.Caption = "Tên sản phẩm";
            this.colSP_TEN.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colSP_TEN.FieldName = "SP_TEN";
            this.colSP_TEN.Name = "colSP_TEN";
            this.colSP_TEN.OptionsColumn.AllowEdit = false;
            this.colSP_TEN.Visible = true;
            this.colSP_TEN.Width = 186;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // gcDiemKT
            // 
            this.gcDiemKT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDiemKT.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcDiemKT.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcDiemKT.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcDiemKT.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcDiemKT.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcDiemKT.EmbeddedNavigator.TextStringFormat = "Dòng {0} / {1}";
            this.gcDiemKT.Location = new System.Drawing.Point(0, 0);
            this.gcDiemKT.MainView = this.gvDiemKT;
            this.gcDiemKT.Name = "gcDiemKT";
            this.gcDiemKT.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.seDiem,
            this.repUpdateDiemKT});
            this.gcDiemKT.Size = new System.Drawing.Size(575, 407);
            this.gcDiemKT.TabIndex = 26;
            this.gcDiemKT.UseEmbeddedNavigator = true;
            this.gcDiemKT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDiemKT});
            // 
            // gvDiemKT
            // 
            this.gvDiemKT.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gvDiemKT.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvDiemKT.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvDiemKT.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvDiemKT.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gvDiemKT.Appearance.Row.Options.UseFont = true;
            this.gvDiemKT.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.bandYCKT,
            this.gridBand3});
            this.gvDiemKT.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gvDiemKT.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridColumn5,
            this.colDAUTHAU_ID});
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Greater;
            styleFormatCondition1.Value1 = 1;
            this.gvDiemKT.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gvDiemKT.GridControl = this.gcDiemKT;
            this.gvDiemKT.Name = "gvDiemKT";
            this.gvDiemKT.NewItemRowText = "Nhấp vào đây để thêm dòng dữ liệu mới";
            this.gvDiemKT.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvDiemKT.OptionsView.EnableAppearanceEvenRow = true;
            this.gvDiemKT.OptionsView.ShowGroupPanel = false;
            this.gvDiemKT.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDiemKT_CellValueChanged);
            this.gvDiemKT.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvDiemKT_ValidatingEditor);
            // 
            // bandYCKT
            // 
            this.bandYCKT.AppearanceHeader.Options.UseTextOptions = true;
            this.bandYCKT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandYCKT.Caption = "Yêu cầu kỹ thuật";
            this.bandYCKT.MinWidth = 20;
            this.bandYCKT.Name = "bandYCKT";
            this.bandYCKT.VisibleIndex = 0;
            this.bandYCKT.Width = 114;
            // 
            // gridBand3
            // 
            this.gridBand3.Columns.Add(this.gridColumn5);
            this.gridBand3.MinWidth = 20;
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 1;
            this.gridBand3.Width = 97;
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
            // colDAUTHAU_ID
            // 
            this.colDAUTHAU_ID.Caption = "DAUTHAU_ID";
            this.colDAUTHAU_ID.FieldName = "DAUTHAU_ID";
            this.colDAUTHAU_ID.Name = "colDAUTHAU_ID";
            // 
            // seDiem
            // 
            this.seDiem.AutoHeight = false;
            this.seDiem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seDiem.Name = "seDiem";
            // 
            // repUpdateDiemKT
            // 
            this.repUpdateDiemKT.AutoHeight = false;
            this.repUpdateDiemKT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("repUpdateDiemKT.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repUpdateDiemKT.Name = "repUpdateDiemKT";
            this.repUpdateDiemKT.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // ucUpdateDiemKT
            // 
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "ucUpdateDiemKT";
            this.Size = new System.Drawing.Size(943, 525);
            this.Load += new System.EventHandler(this.ucUpdateDiemKT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoiThau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCongTy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDiemKT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDiemKT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repUpdateDiemKT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnXem;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lueGoiThau;
        private DevExpress.XtraEditors.LookUpEdit lueCongTy;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gcSanPham;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gvSanPham;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDAU_THAU_ID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSP_MA;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSP_TEN;
        private DevExpress.XtraGrid.GridControl gcDiemKT;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gvDiemKT;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandYCKT;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDAUTHAU_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit seDiem;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repUpdateDiemKT;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand colTitle;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
    }
}
