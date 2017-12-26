namespace DauThau.UserControlCategory
{
    partial class ucSP_Chon
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
            this.colCHON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkChon = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gcGrid = new DevExpress.XtraGrid.GridControl();
            this.gvGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSP_MA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txt = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colSP_TEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSP_DVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueDVT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSP_HAMLUONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSP_DANGDUNG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDAUTHAU_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueDangDung = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lueGoiThau = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDangDung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoiThau)).BeginInit();
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
            this.colCHON.Width = 66;
            // 
            // chkChon
            // 
            this.chkChon.AutoHeight = false;
            this.chkChon.Name = "chkChon";
            this.chkChon.CheckedChanged += new System.EventHandler(this.chkChon_CheckedChanged);
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
            this.lueDVT,
            this.lueDangDung,
            this.txt,
            this.lueGoiThau,
            this.chkChon});
            this.gcGrid.Size = new System.Drawing.Size(717, 516);
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
            this.gvGrid.Appearance.OddRow.BackColor = System.Drawing.Color.LemonChiffon;
            this.gvGrid.Appearance.OddRow.Options.UseBackColor = true;
            this.gvGrid.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gvGrid.Appearance.Row.Options.UseFont = true;
            this.gvGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSP_ID,
            this.colSP_MA,
            this.colSP_TEN,
            this.colSP_DVT,
            this.colSP_HAMLUONG,
            this.colSP_DANGDUNG,
            this.colCHON,
            this.colDAUTHAU_ID});
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colCHON;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = true;
            this.gvGrid.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gvGrid.GridControl = this.gcGrid;
            this.gvGrid.Name = "gvGrid";
            this.gvGrid.NewItemRowText = "Nhấp vào đây để thêm dòng dữ liệu mới";
            this.gvGrid.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvGrid.OptionsView.EnableAppearanceEvenRow = true;
            this.gvGrid.OptionsView.EnableAppearanceOddRow = true;
            this.gvGrid.OptionsView.ShowGroupedColumns = true;
            this.gvGrid.OptionsView.ShowGroupPanel = false;
            this.gvGrid.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvGrid_CellValueChanged);
            this.gvGrid.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvGrid_ValidatingEditor);
            // 
            // colSP_ID
            // 
            this.colSP_ID.Caption = "ID";
            this.colSP_ID.FieldName = "SP_ID";
            this.colSP_ID.Name = "colSP_ID";
            // 
            // colSP_MA
            // 
            this.colSP_MA.Caption = "Mã sản phẩm";
            this.colSP_MA.ColumnEdit = this.txt;
            this.colSP_MA.FieldName = "SP_MA";
            this.colSP_MA.Name = "colSP_MA";
            this.colSP_MA.OptionsColumn.AllowEdit = false;
            this.colSP_MA.Visible = true;
            this.colSP_MA.VisibleIndex = 1;
            this.colSP_MA.Width = 221;
            // 
            // txt
            // 
            this.txt.AutoHeight = false;
            this.txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt.Name = "txt";
            // 
            // colSP_TEN
            // 
            this.colSP_TEN.Caption = "Tên sản phẩm";
            this.colSP_TEN.FieldName = "SP_TEN";
            this.colSP_TEN.Name = "colSP_TEN";
            this.colSP_TEN.OptionsColumn.AllowEdit = false;
            this.colSP_TEN.Visible = true;
            this.colSP_TEN.VisibleIndex = 2;
            this.colSP_TEN.Width = 221;
            // 
            // colSP_DVT
            // 
            this.colSP_DVT.Caption = "Đơn vị tính";
            this.colSP_DVT.ColumnEdit = this.lueDVT;
            this.colSP_DVT.FieldName = "DVT_ID";
            this.colSP_DVT.Name = "colSP_DVT";
            this.colSP_DVT.OptionsColumn.AllowEdit = false;
            this.colSP_DVT.Visible = true;
            this.colSP_DVT.VisibleIndex = 3;
            this.colSP_DVT.Width = 221;
            // 
            // lueDVT
            // 
            this.lueDVT.AutoHeight = false;
            this.lueDVT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDVT.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DVT_ID", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Đơn vị tính")});
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
            this.colSP_HAMLUONG.VisibleIndex = 4;
            this.colSP_HAMLUONG.Width = 221;
            // 
            // colSP_DANGDUNG
            // 
            this.colSP_DANGDUNG.Caption = "Dạng dùng";
            this.colSP_DANGDUNG.FieldName = "SP_DANGDUNG";
            this.colSP_DANGDUNG.Name = "colSP_DANGDUNG";
            this.colSP_DANGDUNG.OptionsColumn.AllowEdit = false;
            this.colSP_DANGDUNG.Visible = true;
            this.colSP_DANGDUNG.VisibleIndex = 5;
            this.colSP_DANGDUNG.Width = 230;
            // 
            // colDAUTHAU_ID
            // 
            this.colDAUTHAU_ID.Caption = "DAUTHAU_ID";
            this.colDAUTHAU_ID.FieldName = "DAUTHAU_ID";
            this.colDAUTHAU_ID.Name = "colDAUTHAU_ID";
            // 
            // lueDangDung
            // 
            this.lueDangDung.AutoHeight = false;
            this.lueDangDung.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDangDung.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DANGDUNG_ID", "Name3", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DANGDUNG_TEN", "Dạng dùng")});
            this.lueDangDung.DisplayMember = "DANGDUNG_TEN";
            this.lueDangDung.Name = "lueDangDung";
            this.lueDangDung.NullText = "";
            this.lueDangDung.ValueMember = "DANGDUNG_ID";
            // 
            // lueGoiThau
            // 
            this.lueGoiThau.AutoHeight = false;
            this.lueGoiThau.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGoiThau.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GOITHAU_TEN", "Gói thầu"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GOITHAU_ID", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lueGoiThau.DisplayMember = "GOITHAU_TEN";
            this.lueGoiThau.Name = "lueGoiThau";
            this.lueGoiThau.ValueMember = "GOITHAU_ID";
            // 
            // ucSP_Chon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcGrid);
            this.Name = "ucSP_Chon";
            this.Size = new System.Drawing.Size(717, 516);
            this.Load += new System.EventHandler(this.ucSP_Chon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDangDung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoiThau)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGrid;
        private DevExpress.XtraGrid.Columns.GridColumn colSP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSP_MA;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txt;
        private DevExpress.XtraGrid.Columns.GridColumn colSP_TEN;
        private DevExpress.XtraGrid.Columns.GridColumn colSP_DVT;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueDVT;
        private DevExpress.XtraGrid.Columns.GridColumn colSP_HAMLUONG;
        private DevExpress.XtraGrid.Columns.GridColumn colSP_DANGDUNG;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueDangDung;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueGoiThau;
        private DevExpress.XtraGrid.Columns.GridColumn colCHON;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkChon;
        private DevExpress.XtraGrid.Columns.GridColumn colDAUTHAU_ID;
    }
}
