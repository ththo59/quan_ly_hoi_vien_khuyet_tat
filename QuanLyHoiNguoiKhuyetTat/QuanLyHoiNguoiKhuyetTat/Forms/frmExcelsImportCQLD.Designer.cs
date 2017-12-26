namespace DauThau.Forms
{
    partial class frmExcelsImportCQLD
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
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.lueNgayKeKhai = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.lueQuyCachDongGoi = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.lueGiaKeKhai = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lueThongTinCV_NgayCong = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lueCSNK_KeKhai = new DevExpress.XtraEditors.LookUpEdit();
            this.lueSDK_GPNK = new DevExpress.XtraEditors.LookUpEdit();
            this.lueCoSoSanXuat = new DevExpress.XtraEditors.LookUpEdit();
            this.lueDonViTinh = new DevExpress.XtraEditors.LookUpEdit();
            this.lueTenHoatChat = new DevExpress.XtraEditors.LookUpEdit();
            this.lueHamLuongNongDo = new DevExpress.XtraEditors.LookUpEdit();
            this.lueTenThuoc = new DevExpress.XtraEditors.LookUpEdit();
            this.lueSTT = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.rdMau = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueHamLuong)).BeginInit();
            this.lueHamLuong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueNgayKeKhai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueQuyCachDongGoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGiaKeKhai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueThongTinCV_NgayCong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCSNK_KeKhai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSDK_GPNK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCoSoSanXuat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDonViTinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTenHoatChat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueHamLuongNongDo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTenThuoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSTT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdMau.Properties)).BeginInit();
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
            this.gc.Location = new System.Drawing.Point(0, 243);
            this.gc.MainView = this.gv;
            this.gc.Name = "gc";
            this.gc.Size = new System.Drawing.Size(869, 292);
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
            this.txtPath.Location = new System.Drawing.Point(249, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPath.Properties.Appearance.Options.UseFont = true;
            this.txtPath.Size = new System.Drawing.Size(319, 22);
            this.txtPath.TabIndex = 28;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Location = new System.Drawing.Point(94, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(149, 17);
            this.labelControl1.TabIndex = 29;
            this.labelControl1.Text = "Chọn đường dẫn dữ liệu";
            // 
            // btnPath
            // 
            this.btnPath.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnPath.Appearance.Options.UseFont = true;
            this.btnPath.Location = new System.Drawing.Point(577, 11);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(29, 26);
            this.btnPath.TabIndex = 30;
            this.btnPath.Text = "...";
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // lueHamLuong
            // 
            this.lueHamLuong.Controls.Add(this.rdMau);
            this.lueHamLuong.Controls.Add(this.groupControl1);
            this.lueHamLuong.Controls.Add(this.btnPath);
            this.lueHamLuong.Controls.Add(this.labelControl1);
            this.lueHamLuong.Controls.Add(this.txtPath);
            this.lueHamLuong.Dock = System.Windows.Forms.DockStyle.Top;
            this.lueHamLuong.Location = new System.Drawing.Point(0, 0);
            this.lueHamLuong.Name = "lueHamLuong";
            this.lueHamLuong.Size = new System.Drawing.Size(869, 243);
            this.lueHamLuong.TabIndex = 31;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.labelControl17);
            this.groupControl1.Controls.Add(this.lueNgayKeKhai);
            this.groupControl1.Controls.Add(this.labelControl14);
            this.groupControl1.Controls.Add(this.lueQuyCachDongGoi);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl13);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Controls.Add(this.labelControl11);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.lueGiaKeKhai);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.lueThongTinCV_NgayCong);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.lueCSNK_KeKhai);
            this.groupControl1.Controls.Add(this.lueSDK_GPNK);
            this.groupControl1.Controls.Add(this.lueCoSoSanXuat);
            this.groupControl1.Controls.Add(this.lueDonViTinh);
            this.groupControl1.Controls.Add(this.lueTenHoatChat);
            this.groupControl1.Controls.Add(this.lueHamLuongNongDo);
            this.groupControl1.Controls.Add(this.lueTenThuoc);
            this.groupControl1.Controls.Add(this.lueSTT);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(2, 43);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(865, 198);
            this.groupControl1.TabIndex = 31;
            this.groupControl1.Text = "Các thông số kết nối";
            // 
            // labelControl17
            // 
            this.labelControl17.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl17.Location = new System.Drawing.Point(520, 163);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(84, 18);
            this.labelControl17.TabIndex = 66;
            this.labelControl17.Text = "Ngày kê khai";
            // 
            // lueNgayKeKhai
            // 
            this.lueNgayKeKhai.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueNgayKeKhai.Location = new System.Drawing.Point(610, 162);
            this.lueNgayKeKhai.Name = "lueNgayKeKhai";
            this.lueNgayKeKhai.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueNgayKeKhai.Properties.Appearance.Options.UseFont = true;
            this.lueNgayKeKhai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lueNgayKeKhai.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueNgayKeKhai.Properties.DisplayMember = "TEN";
            this.lueNgayKeKhai.Properties.NullText = "";
            this.lueNgayKeKhai.Properties.ValueMember = "TEN";
            this.lueNgayKeKhai.Size = new System.Drawing.Size(206, 22);
            this.lueNgayKeKhai.TabIndex = 62;
            // 
            // labelControl14
            // 
            this.labelControl14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl14.Location = new System.Drawing.Point(479, 29);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(123, 18);
            this.labelControl14.TabIndex = 58;
            this.labelControl14.Text = "Quy cách đóng gói";
            // 
            // lueQuyCachDongGoi
            // 
            this.lueQuyCachDongGoi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueQuyCachDongGoi.Location = new System.Drawing.Point(608, 27);
            this.lueQuyCachDongGoi.Name = "lueQuyCachDongGoi";
            this.lueQuyCachDongGoi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueQuyCachDongGoi.Properties.Appearance.Options.UseFont = true;
            this.lueQuyCachDongGoi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lueQuyCachDongGoi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueQuyCachDongGoi.Properties.DisplayMember = "TEN";
            this.lueQuyCachDongGoi.Properties.NullText = "";
            this.lueQuyCachDongGoi.Properties.ValueMember = "TEN";
            this.lueQuyCachDongGoi.Size = new System.Drawing.Size(208, 22);
            this.lueQuyCachDongGoi.TabIndex = 57;
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl8.Location = new System.Drawing.Point(45, 85);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(86, 17);
            this.labelControl8.TabIndex = 55;
            this.labelControl8.Text = "Tên hoạt chất";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl6.Location = new System.Drawing.Point(14, 137);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(117, 17);
            this.labelControl6.TabIndex = 54;
            this.labelControl6.Text = "Số đăng ký / GPNK";
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl7.Location = new System.Drawing.Point(63, 111);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(67, 17);
            this.labelControl7.TabIndex = 56;
            this.labelControl7.Text = "Hàm lượng";
            // 
            // labelControl13
            // 
            this.labelControl13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl13.Location = new System.Drawing.Point(534, 137);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(70, 18);
            this.labelControl13.TabIndex = 47;
            this.labelControl13.Text = "Giá kê khai";
            // 
            // labelControl12
            // 
            this.labelControl12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl12.Location = new System.Drawing.Point(399, 110);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(205, 18);
            this.labelControl12.TabIndex = 52;
            this.labelControl12.Text = "Thông tin công văn, ngày công";
            // 
            // labelControl11
            // 
            this.labelControl11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl11.Location = new System.Drawing.Point(444, 85);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(160, 18);
            this.labelControl11.TabIndex = 51;
            this.labelControl11.Text = "Cơ sở nhập khẩu kê khai";
            // 
            // labelControl9
            // 
            this.labelControl9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl9.Location = new System.Drawing.Point(510, 56);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(92, 17);
            this.labelControl9.TabIndex = 50;
            this.labelControl9.Text = "Cơ sở sản xuất";
            // 
            // lueGiaKeKhai
            // 
            this.lueGiaKeKhai.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueGiaKeKhai.Location = new System.Drawing.Point(610, 136);
            this.lueGiaKeKhai.Name = "lueGiaKeKhai";
            this.lueGiaKeKhai.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueGiaKeKhai.Properties.Appearance.Options.UseFont = true;
            this.lueGiaKeKhai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lueGiaKeKhai.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueGiaKeKhai.Properties.DisplayMember = "TEN";
            this.lueGiaKeKhai.Properties.NullText = "";
            this.lueGiaKeKhai.Properties.ValueMember = "TEN";
            this.lueGiaKeKhai.Size = new System.Drawing.Size(206, 22);
            this.lueGiaKeKhai.TabIndex = 45;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl5.Location = new System.Drawing.Point(63, 165);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(67, 17);
            this.labelControl5.TabIndex = 49;
            this.labelControl5.Text = "Đơn vị tính";
            // 
            // lueThongTinCV_NgayCong
            // 
            this.lueThongTinCV_NgayCong.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueThongTinCV_NgayCong.Location = new System.Drawing.Point(610, 109);
            this.lueThongTinCV_NgayCong.Name = "lueThongTinCV_NgayCong";
            this.lueThongTinCV_NgayCong.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueThongTinCV_NgayCong.Properties.Appearance.Options.UseFont = true;
            this.lueThongTinCV_NgayCong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lueThongTinCV_NgayCong.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueThongTinCV_NgayCong.Properties.DisplayMember = "TEN";
            this.lueThongTinCV_NgayCong.Properties.NullText = "";
            this.lueThongTinCV_NgayCong.Properties.ValueMember = "TEN";
            this.lueThongTinCV_NgayCong.Size = new System.Drawing.Size(206, 22);
            this.lueThongTinCV_NgayCong.TabIndex = 44;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl4.Location = new System.Drawing.Point(68, 57);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(63, 17);
            this.labelControl4.TabIndex = 48;
            this.labelControl4.Text = "Tên thuốc";
            // 
            // lueCSNK_KeKhai
            // 
            this.lueCSNK_KeKhai.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueCSNK_KeKhai.Location = new System.Drawing.Point(610, 83);
            this.lueCSNK_KeKhai.Name = "lueCSNK_KeKhai";
            this.lueCSNK_KeKhai.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueCSNK_KeKhai.Properties.Appearance.Options.UseFont = true;
            this.lueCSNK_KeKhai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lueCSNK_KeKhai.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueCSNK_KeKhai.Properties.DisplayMember = "TEN";
            this.lueCSNK_KeKhai.Properties.NullText = "";
            this.lueCSNK_KeKhai.Properties.ValueMember = "TEN";
            this.lueCSNK_KeKhai.Size = new System.Drawing.Size(206, 22);
            this.lueCSNK_KeKhai.TabIndex = 43;
            // 
            // lueSDK_GPNK
            // 
            this.lueSDK_GPNK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueSDK_GPNK.Location = new System.Drawing.Point(136, 136);
            this.lueSDK_GPNK.Name = "lueSDK_GPNK";
            this.lueSDK_GPNK.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueSDK_GPNK.Properties.Appearance.Options.UseFont = true;
            this.lueSDK_GPNK.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSDK_GPNK.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueSDK_GPNK.Properties.DisplayMember = "TEN";
            this.lueSDK_GPNK.Properties.NullText = "";
            this.lueSDK_GPNK.Properties.ValueMember = "TEN";
            this.lueSDK_GPNK.Size = new System.Drawing.Size(227, 22);
            this.lueSDK_GPNK.TabIndex = 42;
            // 
            // lueCoSoSanXuat
            // 
            this.lueCoSoSanXuat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueCoSoSanXuat.Location = new System.Drawing.Point(610, 55);
            this.lueCoSoSanXuat.Name = "lueCoSoSanXuat";
            this.lueCoSoSanXuat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueCoSoSanXuat.Properties.Appearance.Options.UseFont = true;
            this.lueCoSoSanXuat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lueCoSoSanXuat.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueCoSoSanXuat.Properties.DisplayMember = "TEN";
            this.lueCoSoSanXuat.Properties.NullText = "";
            this.lueCoSoSanXuat.Properties.ValueMember = "TEN";
            this.lueCoSoSanXuat.Size = new System.Drawing.Size(206, 22);
            this.lueCoSoSanXuat.TabIndex = 41;
            // 
            // lueDonViTinh
            // 
            this.lueDonViTinh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueDonViTinh.Location = new System.Drawing.Point(136, 163);
            this.lueDonViTinh.Name = "lueDonViTinh";
            this.lueDonViTinh.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueDonViTinh.Properties.Appearance.Options.UseFont = true;
            this.lueDonViTinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDonViTinh.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueDonViTinh.Properties.DisplayMember = "TEN";
            this.lueDonViTinh.Properties.NullText = "";
            this.lueDonViTinh.Properties.ValueMember = "TEN";
            this.lueDonViTinh.Size = new System.Drawing.Size(227, 22);
            this.lueDonViTinh.TabIndex = 40;
            // 
            // lueTenHoatChat
            // 
            this.lueTenHoatChat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueTenHoatChat.Location = new System.Drawing.Point(136, 82);
            this.lueTenHoatChat.Name = "lueTenHoatChat";
            this.lueTenHoatChat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueTenHoatChat.Properties.Appearance.Options.UseFont = true;
            this.lueTenHoatChat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lueTenHoatChat.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueTenHoatChat.Properties.DisplayMember = "TEN";
            this.lueTenHoatChat.Properties.NullText = "";
            this.lueTenHoatChat.Properties.ValueMember = "TEN";
            this.lueTenHoatChat.Size = new System.Drawing.Size(227, 22);
            this.lueTenHoatChat.TabIndex = 39;
            // 
            // lueHamLuongNongDo
            // 
            this.lueHamLuongNongDo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueHamLuongNongDo.Location = new System.Drawing.Point(136, 108);
            this.lueHamLuongNongDo.Name = "lueHamLuongNongDo";
            this.lueHamLuongNongDo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueHamLuongNongDo.Properties.Appearance.Options.UseFont = true;
            this.lueHamLuongNongDo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lueHamLuongNongDo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueHamLuongNongDo.Properties.DisplayMember = "TEN";
            this.lueHamLuongNongDo.Properties.NullText = "";
            this.lueHamLuongNongDo.Properties.ValueMember = "TEN";
            this.lueHamLuongNongDo.Size = new System.Drawing.Size(227, 22);
            this.lueHamLuongNongDo.TabIndex = 38;
            // 
            // lueTenThuoc
            // 
            this.lueTenThuoc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueTenThuoc.Location = new System.Drawing.Point(136, 55);
            this.lueTenThuoc.Name = "lueTenThuoc";
            this.lueTenThuoc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueTenThuoc.Properties.Appearance.Options.UseFont = true;
            this.lueTenThuoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTenThuoc.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueTenThuoc.Properties.DisplayMember = "TEN";
            this.lueTenThuoc.Properties.NullText = "";
            this.lueTenThuoc.Properties.ValueMember = "TEN";
            this.lueTenThuoc.Size = new System.Drawing.Size(227, 22);
            this.lueTenThuoc.TabIndex = 37;
            // 
            // lueSTT
            // 
            this.lueSTT.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueSTT.Location = new System.Drawing.Point(136, 27);
            this.lueSTT.Name = "lueSTT";
            this.lueSTT.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueSTT.Properties.Appearance.Options.UseFont = true;
            this.lueSTT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSTT.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "GOITHAU_ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN", "Gói thầu")});
            this.lueSTT.Properties.DisplayMember = "TEN";
            this.lueSTT.Properties.NullText = "";
            this.lueSTT.Properties.ValueMember = "TEN";
            this.lueSTT.Size = new System.Drawing.Size(227, 22);
            this.lueSTT.TabIndex = 46;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Location = new System.Drawing.Point(106, 30);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 16);
            this.labelControl3.TabIndex = 53;
            this.labelControl3.Text = "STT";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.Image = global::DauThau.Properties.Resources.btndelete;
            this.btnDelete.Location = new System.Drawing.Point(388, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(116, 36);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Xóa dữ liệu cũ";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnDelete);
            this.panelControl2.Controls.Add(this.btnThoat);
            this.panelControl2.Controls.Add(this.btnAccept);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 535);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(869, 51);
            this.panelControl2.TabIndex = 32;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThoat.Image = global::DauThau.Properties.Resources.btnExit;
            this.btnThoat.Location = new System.Drawing.Point(510, 6);
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
            this.btnAccept.Location = new System.Drawing.Point(307, 5);
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
            // rdMau
            // 
            this.rdMau.EditValue = 1;
            this.rdMau.Location = new System.Drawing.Point(624, 11);
            this.rdMau.Name = "rdMau";
            this.rdMau.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Mẫu 1"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Mẫu 2")});
            this.rdMau.Size = new System.Drawing.Size(144, 26);
            this.rdMau.TabIndex = 32;
            // 
            // frmExcelsImportCQLD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 586);
            this.Controls.Add(this.gc);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.lueHamLuong);
            this.Name = "frmExcelsImportCQLD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nạp dữ liệu từ Excels";
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
            ((System.ComponentModel.ISupportInitialize)(this.lueNgayKeKhai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueQuyCachDongGoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGiaKeKhai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueThongTinCV_NgayCong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCSNK_KeKhai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSDK_GPNK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCoSoSanXuat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDonViTinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTenHoatChat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueHamLuongNongDo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTenThuoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSTT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdMau.Properties)).EndInit();
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
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LookUpEdit lueNgayKeKhai;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LookUpEdit lueQuyCachDongGoi;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LookUpEdit lueGiaKeKhai;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit lueThongTinCV_NgayCong;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit lueCSNK_KeKhai;
        private DevExpress.XtraEditors.LookUpEdit lueSDK_GPNK;
        private DevExpress.XtraEditors.LookUpEdit lueCoSoSanXuat;
        private DevExpress.XtraEditors.LookUpEdit lueDonViTinh;
        private DevExpress.XtraEditors.LookUpEdit lueTenHoatChat;
        private DevExpress.XtraEditors.LookUpEdit lueHamLuongNongDo;
        private DevExpress.XtraEditors.LookUpEdit lueTenThuoc;
        private DevExpress.XtraEditors.LookUpEdit lueSTT;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.RadioGroup rdMau;
    }
}