namespace DauThau.Forms
{
    partial class frmExcelsManagerAdditional
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
            this.components = new System.ComponentModel.Container();
            this.gc = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtPath = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnPath = new DevExpress.XtraEditors.SimpleButton();
            this.lueHamLuong = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lbSPDacBiet = new DevExpress.XtraEditors.LabelControl();
            this.lueSPDacBiet = new DevExpress.XtraEditors.LookUpEdit();
            this.lueMaSP = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lueSoLuong_BH = new DevExpress.XtraEditors.LookUpEdit();
            this.lueThongTu = new DevExpress.XtraEditors.LookUpEdit();
            this.lueSoLuong_CS = new DevExpress.XtraEditors.LookUpEdit();
            this.lueSoLuong_DV = new DevExpress.XtraEditors.LookUpEdit();
            this.lueGiaKH = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueHamLuong)).BeginInit();
            this.lueHamLuong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueSPDacBiet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaSP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSoLuong_BH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueThongTu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSoLuong_CS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSoLuong_DV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGiaKH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gc
            // 
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gc.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gc.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gc.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gc.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gc.EmbeddedNavigator.TextStringFormat = "Dòng {0}/ {1}";
            this.gc.Location = new System.Drawing.Point(0, 164);
            this.gc.MainView = this.gv;
            this.gc.Name = "gc";
            this.gc.Size = new System.Drawing.Size(1088, 274);
            this.gc.TabIndex = 0;
            this.gc.UseEmbeddedNavigator = true;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.GridControl = this.gc;
            this.gv.Name = "gv";
            this.gv.OptionsView.ShowGroupPanel = false;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(357, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPath.Properties.Appearance.Options.UseFont = true;
            this.txtPath.Size = new System.Drawing.Size(425, 22);
            this.txtPath.TabIndex = 28;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Location = new System.Drawing.Point(202, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(149, 17);
            this.labelControl1.TabIndex = 29;
            this.labelControl1.Text = "Chọn đường dẫn dữ liệu";
            // 
            // btnPath
            // 
            this.btnPath.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnPath.Appearance.Options.UseFont = true;
            this.btnPath.Location = new System.Drawing.Point(787, 10);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(29, 26);
            this.btnPath.TabIndex = 30;
            this.btnPath.Text = "...";
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // lueHamLuong
            // 
            this.lueHamLuong.Controls.Add(this.groupControl1);
            this.lueHamLuong.Controls.Add(this.btnPath);
            this.lueHamLuong.Controls.Add(this.labelControl1);
            this.lueHamLuong.Controls.Add(this.txtPath);
            this.lueHamLuong.Dock = System.Windows.Forms.DockStyle.Top;
            this.lueHamLuong.Location = new System.Drawing.Point(0, 0);
            this.lueHamLuong.Name = "lueHamLuong";
            this.lueHamLuong.Size = new System.Drawing.Size(1088, 164);
            this.lueHamLuong.TabIndex = 31;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.lbSPDacBiet);
            this.groupControl1.Controls.Add(this.lueSPDacBiet);
            this.groupControl1.Controls.Add(this.lueMaSP);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.lueSoLuong_BH);
            this.groupControl1.Controls.Add(this.lueThongTu);
            this.groupControl1.Controls.Add(this.lueSoLuong_CS);
            this.groupControl1.Controls.Add(this.lueSoLuong_DV);
            this.groupControl1.Controls.Add(this.lueGiaKH);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(2, 42);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1084, 120);
            this.groupControl1.TabIndex = 31;
            this.groupControl1.Text = "Các thông số kết nối";
            // 
            // lbSPDacBiet
            // 
            this.lbSPDacBiet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbSPDacBiet.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lbSPDacBiet.Location = new System.Drawing.Point(728, 34);
            this.lbSPDacBiet.Name = "lbSPDacBiet";
            this.lbSPDacBiet.Size = new System.Drawing.Size(68, 17);
            this.lbSPDacBiet.TabIndex = 31;
            this.lbSPDacBiet.Text = "SP đặc biệt";
            // 
            // lueSPDacBiet
            // 
            this.lueSPDacBiet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueSPDacBiet.Location = new System.Drawing.Point(818, 31);
            this.lueSPDacBiet.Name = "lueSPDacBiet";
            this.lueSPDacBiet.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueSPDacBiet.Properties.Appearance.Options.UseFont = true;
            this.lueSPDacBiet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lueSPDacBiet.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueSPDacBiet.Properties.DisplayMember = "TEN";
            this.lueSPDacBiet.Properties.NullText = "";
            this.lueSPDacBiet.Properties.ValueMember = "TEN";
            this.lueSPDacBiet.Size = new System.Drawing.Size(238, 22);
            this.lueSPDacBiet.TabIndex = 30;
            this.lueSPDacBiet.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lueSPDacBiet_ButtonClick);
            // 
            // lueMaSP
            // 
            this.lueMaSP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueMaSP.Location = new System.Drawing.Point(134, 28);
            this.lueMaSP.Name = "lueMaSP";
            this.lueMaSP.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueMaSP.Properties.Appearance.Options.UseFont = true;
            this.lueMaSP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMaSP.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueMaSP.Properties.DisplayMember = "TEN";
            this.lueMaSP.Properties.NullText = "";
            this.lueMaSP.Properties.ValueMember = "TEN";
            this.lueMaSP.Size = new System.Drawing.Size(233, 22);
            this.lueMaSP.TabIndex = 28;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Location = new System.Drawing.Point(48, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(81, 17);
            this.labelControl2.TabIndex = 29;
            this.labelControl2.Text = "Mã sản phẩm";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl6.Location = new System.Drawing.Point(384, 87);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(75, 17);
            this.labelControl6.TabIndex = 27;
            this.labelControl6.Text = "Số thông tư";
            // 
            // labelControl12
            // 
            this.labelControl12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl12.Location = new System.Drawing.Point(48, 60);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(80, 18);
            this.labelControl12.TabIndex = 27;
            this.labelControl12.Text = "Số lượng BH";
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl5.Location = new System.Drawing.Point(384, 59);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(76, 17);
            this.labelControl5.TabIndex = 27;
            this.labelControl5.Text = "Số lượng CS";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl4.Location = new System.Drawing.Point(43, 87);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(77, 17);
            this.labelControl4.TabIndex = 27;
            this.labelControl4.Text = "Số lượng DV";
            // 
            // lueSoLuong_BH
            // 
            this.lueSoLuong_BH.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueSoLuong_BH.Location = new System.Drawing.Point(134, 56);
            this.lueSoLuong_BH.Name = "lueSoLuong_BH";
            this.lueSoLuong_BH.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueSoLuong_BH.Properties.Appearance.Options.UseFont = true;
            this.lueSoLuong_BH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lueSoLuong_BH.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueSoLuong_BH.Properties.DisplayMember = "TEN";
            this.lueSoLuong_BH.Properties.NullText = "";
            this.lueSoLuong_BH.Properties.ValueMember = "TEN";
            this.lueSoLuong_BH.Size = new System.Drawing.Size(233, 22);
            this.lueSoLuong_BH.TabIndex = 26;
            this.lueSoLuong_BH.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lueSoLuong_BH_ButtonClick);
            // 
            // lueThongTu
            // 
            this.lueThongTu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueThongTu.Location = new System.Drawing.Point(474, 84);
            this.lueThongTu.Name = "lueThongTu";
            this.lueThongTu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueThongTu.Properties.Appearance.Options.UseFont = true;
            this.lueThongTu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lueThongTu.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueThongTu.Properties.DisplayMember = "TEN";
            this.lueThongTu.Properties.NullText = "";
            this.lueThongTu.Properties.ValueMember = "TEN";
            this.lueThongTu.Size = new System.Drawing.Size(238, 22);
            this.lueThongTu.TabIndex = 26;
            this.lueThongTu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lueThongTu_ButtonClick);
            // 
            // lueSoLuong_CS
            // 
            this.lueSoLuong_CS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueSoLuong_CS.Location = new System.Drawing.Point(474, 56);
            this.lueSoLuong_CS.Name = "lueSoLuong_CS";
            this.lueSoLuong_CS.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueSoLuong_CS.Properties.Appearance.Options.UseFont = true;
            this.lueSoLuong_CS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lueSoLuong_CS.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueSoLuong_CS.Properties.DisplayMember = "TEN";
            this.lueSoLuong_CS.Properties.NullText = "";
            this.lueSoLuong_CS.Properties.ValueMember = "TEN";
            this.lueSoLuong_CS.Size = new System.Drawing.Size(238, 22);
            this.lueSoLuong_CS.TabIndex = 26;
            this.lueSoLuong_CS.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lueSoLuong_CS_ButtonClick);
            // 
            // lueSoLuong_DV
            // 
            this.lueSoLuong_DV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueSoLuong_DV.Location = new System.Drawing.Point(134, 84);
            this.lueSoLuong_DV.Name = "lueSoLuong_DV";
            this.lueSoLuong_DV.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueSoLuong_DV.Properties.Appearance.Options.UseFont = true;
            this.lueSoLuong_DV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lueSoLuong_DV.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueSoLuong_DV.Properties.DisplayMember = "TEN";
            this.lueSoLuong_DV.Properties.NullText = "";
            this.lueSoLuong_DV.Properties.ValueMember = "TEN";
            this.lueSoLuong_DV.Size = new System.Drawing.Size(233, 22);
            this.lueSoLuong_DV.TabIndex = 26;
            this.lueSoLuong_DV.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lueSoLuong_DV_ButtonClick);
            // 
            // lueGiaKH
            // 
            this.lueGiaKH.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueGiaKH.Location = new System.Drawing.Point(474, 31);
            this.lueGiaKH.Name = "lueGiaKH";
            this.lueGiaKH.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueGiaKH.Properties.Appearance.Options.UseFont = true;
            this.lueGiaKH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lueGiaKH.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueGiaKH.Properties.DisplayMember = "TEN";
            this.lueGiaKH.Properties.NullText = "";
            this.lueGiaKH.Properties.ValueMember = "TEN";
            this.lueGiaKH.Size = new System.Drawing.Size(238, 22);
            this.lueGiaKH.TabIndex = 26;
            this.lueGiaKH.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lueGiaKH_ButtonClick);
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Location = new System.Drawing.Point(382, 31);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(78, 17);
            this.labelControl3.TabIndex = 27;
            this.labelControl3.Text = "Giá kế hoạch";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnThoat);
            this.panelControl2.Controls.Add(this.btnAccept);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 438);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1088, 51);
            this.panelControl2.TabIndex = 32;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThoat.Image = global::DauThau.Properties.Resources.btnExit;
            this.btnThoat.Location = new System.Drawing.Point(547, 9);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 37);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAccept.Image = global::DauThau.Properties.Resources.applyimg;
            this.btnAccept.Location = new System.Drawing.Point(466, 9);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 37);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Đồng ý";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // frmExcelsManagerAdditional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 489);
            this.Controls.Add(this.gc);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.lueHamLuong);
            this.Name = "frmExcelsManagerAdditional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nạp dữ liệu bổ sung từ Excels";
            this.Load += new System.EventHandler(this.frmExcelsManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueHamLuong)).EndInit();
            this.lueHamLuong.ResumeLayout(false);
            this.lueHamLuong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueSPDacBiet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaSP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSoLuong_BH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueThongTu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSoLuong_CS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSoLuong_DV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGiaKH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gc;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraEditors.TextEdit txtPath;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnPath;
        private DevExpress.XtraEditors.PanelControl lueHamLuong;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit lueGiaKH;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.LookUpEdit lueSoLuong_CS;
        private DevExpress.XtraEditors.LookUpEdit lueSoLuong_DV;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LookUpEdit lueSoLuong_BH;
        private DevExpress.XtraEditors.LookUpEdit lueThongTu;
        private DevExpress.XtraEditors.LookUpEdit lueMaSP;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lbSPDacBiet;
        private DevExpress.XtraEditors.LookUpEdit lueSPDacBiet;
    }
}