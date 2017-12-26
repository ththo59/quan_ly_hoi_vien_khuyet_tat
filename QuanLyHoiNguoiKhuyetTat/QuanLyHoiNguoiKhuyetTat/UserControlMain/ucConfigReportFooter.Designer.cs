namespace DauThau.UserControlCategoryMain
{
    partial class ucConfigReportFooter
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
            this.components = new System.ComponentModel.Container();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtValue = new DevExpress.XtraEditors.TextEdit();
            this.chkListBieuMau = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtTitle = new DevExpress.XtraEditors.TextEdit();
            this.dsCheckListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCheckList = new DauThau.DataSets.dsCheckList();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnControl = new ControlsLib.ButtonsArray();
            this.gcGrid = new DevExpress.XtraGrid.GridControl();
            this.gvGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSystemConfig_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSystemConfig_Parameter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSystemConfig_Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSystemConfig_Value = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueDVT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lueMaSanPham = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lueTenSanPham = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lueGridGoiThau = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.seGia = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.dsCongTy = new DauThau.DataSets.dsCongTy();
            this.dsCongTyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkListBieuMau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCheckListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCheckList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTenSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGridGoiThau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCongTy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCongTyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.txtValue);
            this.groupControl1.Controls.Add(this.chkListBieuMau);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtTitle);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1026, 281);
            this.groupControl1.TabIndex = 24;
            this.groupControl1.Text = "Lựa chọn";
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(116, 70);
            this.txtValue.Name = "txtValue";
            this.txtValue.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtValue.Properties.Appearance.Options.UseFont = true;
            this.txtValue.Size = new System.Drawing.Size(880, 24);
            this.txtValue.TabIndex = 27;
            // 
            // chkListBieuMau
            // 
            this.chkListBieuMau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkListBieuMau.Location = new System.Drawing.Point(116, 107);
            this.chkListBieuMau.MultiColumn = true;
            this.chkListBieuMau.Name = "chkListBieuMau";
            this.chkListBieuMau.Size = new System.Drawing.Size(880, 168);
            this.chkListBieuMau.TabIndex = 26;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Location = new System.Drawing.Point(43, 73);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(34, 17);
            this.labelControl3.TabIndex = 25;
            this.labelControl3.Text = "Giá trị";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Location = new System.Drawing.Point(43, 43);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 17);
            this.labelControl1.TabIndex = 25;
            this.labelControl1.Text = "Tiêu đề";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Location = new System.Drawing.Point(43, 107);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 17);
            this.labelControl2.TabIndex = 25;
            this.labelControl2.Text = "Biểu mẫu";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(116, 40);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtTitle.Properties.Appearance.Options.UseFont = true;
            this.txtTitle.Size = new System.Drawing.Size(880, 24);
            this.txtTitle.TabIndex = 27;
            // 
            // dsCheckListBindingSource
            // 
            this.dsCheckListBindingSource.DataSource = this.dsCheckList;
            this.dsCheckListBindingSource.Position = 0;
            // 
            // dsCheckList
            // 
            this.dsCheckList.DataSetName = "dsCheckList";
            this.dsCheckList.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 448);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1026, 60);
            this.panelControl1.TabIndex = 25;
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
            this.btnControl.Location = new System.Drawing.Point(769, 2);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(255, 56);
            this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
            this.btnControl.TabIndex = 0;
            this.btnControl.btnEventAdd_Click += new System.EventHandler(this.btnControl_btnEventAdd_Click);
            this.btnControl.btnEventModify_Click += new System.EventHandler(this.btnControl_btnEventModify_Click);
            this.btnControl.btnEventDelete_Click += new System.EventHandler(this.btnControl_btnEventDelete_Click);
            this.btnControl.btnEventSave_Click += new System.EventHandler(this.btnControl_btnEventSave_Click);
            this.btnControl.btnEventCancel_Click += new System.EventHandler(this.btnControl_btnEventCancel_Click);
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
            this.gcGrid.Location = new System.Drawing.Point(0, 281);
            this.gcGrid.MainView = this.gvGrid;
            this.gcGrid.Name = "gcGrid";
            this.gcGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueDVT,
            this.lueMaSanPham,
            this.lueTenSanPham,
            this.lueGridGoiThau,
            this.seGia});
            this.gcGrid.Size = new System.Drawing.Size(1026, 167);
            this.gcGrid.TabIndex = 26;
            this.gcGrid.UseEmbeddedNavigator = true;
            this.gcGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGrid});
            this.gcGrid.Click += new System.EventHandler(this.gcGrid_Click);
            // 
            // gvGrid
            // 
            this.gvGrid.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvGrid.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvGrid.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvGrid.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvGrid.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvGrid.Appearance.Row.Options.UseFont = true;
            this.gvGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSystemConfig_Id,
            this.colSystemConfig_Parameter,
            this.colSystemConfig_Description,
            this.colSystemConfig_Value});
            this.gvGrid.GridControl = this.gcGrid;
            this.gvGrid.Name = "gvGrid";
            this.gvGrid.NewItemRowText = "Nhấp vào đây để thêm dòng dữ liệu mới";
            this.gvGrid.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvGrid.OptionsView.EnableAppearanceEvenRow = true;
            this.gvGrid.OptionsView.ShowGroupPanel = false;
            this.gvGrid.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvGrid_InitNewRow);
            this.gvGrid.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvGrid_FocusedRowChanged);
            this.gvGrid.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvGrid_InvalidRowException);
            this.gvGrid.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvGrid_ValidateRow);
            this.gvGrid.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvGrid_ValidatingEditor);
            // 
            // colSystemConfig_Id
            // 
            this.colSystemConfig_Id.Caption = "ID";
            this.colSystemConfig_Id.FieldName = "SystemConfig_Id";
            this.colSystemConfig_Id.Name = "colSystemConfig_Id";
            this.colSystemConfig_Id.OptionsColumn.AllowEdit = false;
            this.colSystemConfig_Id.Visible = true;
            this.colSystemConfig_Id.VisibleIndex = 0;
            // 
            // colSystemConfig_Parameter
            // 
            this.colSystemConfig_Parameter.Caption = "Biểu mẫu";
            this.colSystemConfig_Parameter.FieldName = "SystemConfig_Parameter";
            this.colSystemConfig_Parameter.Name = "colSystemConfig_Parameter";
            this.colSystemConfig_Parameter.OptionsColumn.AllowEdit = false;
            this.colSystemConfig_Parameter.Visible = true;
            this.colSystemConfig_Parameter.VisibleIndex = 1;
            // 
            // colSystemConfig_Description
            // 
            this.colSystemConfig_Description.Caption = "Tiêu đề";
            this.colSystemConfig_Description.FieldName = "SystemConfig_Description";
            this.colSystemConfig_Description.Name = "colSystemConfig_Description";
            this.colSystemConfig_Description.OptionsColumn.AllowEdit = false;
            this.colSystemConfig_Description.Visible = true;
            this.colSystemConfig_Description.VisibleIndex = 2;
            // 
            // colSystemConfig_Value
            // 
            this.colSystemConfig_Value.Caption = "Giá trị";
            this.colSystemConfig_Value.FieldName = "SystemConfig_Value";
            this.colSystemConfig_Value.Name = "colSystemConfig_Value";
            this.colSystemConfig_Value.OptionsColumn.AllowEdit = false;
            this.colSystemConfig_Value.Visible = true;
            this.colSystemConfig_Value.VisibleIndex = 3;
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
            // dsCongTy
            // 
            this.dsCongTy.DataSetName = "dsCongTy";
            this.dsCongTy.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsCongTyBindingSource
            // 
            this.dsCongTyBindingSource.DataSource = this.dsCongTy;
            this.dsCongTyBindingSource.Position = 0;
            // 
            // ucConfigReportFooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcGrid);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "ucConfigReportFooter";
            this.Size = new System.Drawing.Size(1026, 508);
            this.Load += new System.EventHandler(this.ucHangSX_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkListBieuMau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCheckListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCheckList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTenSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGridGoiThau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCongTy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCongTyBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private ControlsLib.ButtonsArray btnControl;
        private DevExpress.XtraGrid.GridControl gcGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGrid;
        private DevExpress.XtraGrid.Columns.GridColumn colSystemConfig_Id;
        private DevExpress.XtraGrid.Columns.GridColumn colSystemConfig_Parameter;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueDVT;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueMaSanPham;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTenSanPham;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueGridGoiThau;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit seGia;
        private DevExpress.XtraGrid.Columns.GridColumn colSystemConfig_Description;
        private DevExpress.XtraEditors.CheckedListBoxControl chkListBieuMau;
        private DevExpress.XtraGrid.Columns.GridColumn colSystemConfig_Value;
        private DevExpress.XtraEditors.TextEdit txtValue;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.BindingSource dsCongTyBindingSource;
        private DataSets.dsCongTy dsCongTy;
        private System.Windows.Forms.BindingSource dsCheckListBindingSource;
        private DataSets.dsCheckList dsCheckList;
        private DevExpress.XtraEditors.TextEdit txtTitle;
    }
}
