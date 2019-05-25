﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DauThau.Class;
using System.Data.SqlClient;
using DevExpress.XtraGrid;
using DauThau.Models;
using System.Linq;
using System.Data.Entity;
using DevExpress.Utils;
using DevExpress.XtraLayout.Utils;
using DauThau.UserControlCategoryMain;
using DauThau.Reports;
using DevExpress.XtraReports.UI;
using DauThau.UserControlMain;
using DauThau.Forms;

namespace DauThau.UserControlCategory
{
    public partial class ucHoatDongTapHuan2 : ucBase
    {
        private Int64 _id_loai;
        public ucHoatDongTapHuan2(Int64 id_loai)
        {
            InitializeComponent();
            _id_loai = id_loai;
        }

        public BindingList<QL_HOATDONG_TAPHUAN_CHITIET> listTapHuanVienChinh = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>();
        public BindingList<QL_HOATDONG_TAPHUAN_CHITIET> listTapHuanVienPhu = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>();
        public BindingList<QL_HOATDONG_TAPHUAN_CHITIET> listNguoiThucHien = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>();
        public BindingList<QL_HOATDONG_TAPHUAN_CHITIET> listPhienDichVien = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>();

        //Lưu ý: khi mở lần đầu tiên idRowSeleted = 0 và lấy dữ liệu dòng đầu tiên (nếu có)
        private Int64 _idRowSelected;
        const Int64 constIdDeleted = -1;

        private void ucHoatDongHoiThaoTapHuan_Load(object sender, EventArgs e)
        {
            registerButtonArray(btnControl);

            deSearchTuNgay.Ex_FormatCustomDateEdit();
            deSearchDenNgay.Ex_FormatCustomDateEdit();
            deTuNgay.Ex_FormatCustomDateEdit();
            deDenNgay.Ex_FormatCustomDateEdit();

            //seThuLaoGV.Ex_FormatCustomSpinEdit();
            //seThuLaoHoTro.Ex_FormatCustomSpinEdit();
            //seSoLuongNguoiThamGia.Ex_FormatCustomSpinEdit();
            //seSoTienMoiNguoi.Ex_FormatCustomSpinEdit();
            //seTongTien.Ex_FormatCustomSpinEdit();

            var current = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var nextMonth = current.AddMonths(1);
            deSearchTuNgay.DateTime = current;
            deSearchDenNgay.DateTime = nextMonth.AddDays(-1);

            lueLoaiTapHuan.Properties.DataSource = FuncCategory.loadDMTapHuan();
            lueLoaiTapHuan.EditValue = _id_loai;

            lueLaHoatDong.Properties.DataSource = FuncCategory.loadHoatDong();
            lueNhaTaiTro.Properties.DataSource = FuncCategory.loadCategoryReturn(CategoryEntitiesTable.DM_NHA_TAI_TRO);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_DONVI_PHUTRACH, lueDonViPhuTrach);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_TINH, lueTinh);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_LOAI_HOATDONG, lueLoaiHoatDong);

            _changeLayout((CategoryTapHuan)_id_loai);

            FormStatus = EnumFormStatus.VIEW;
        }

        #region Variable

        #endregion

        #region Function

        private void _changeLayout(CategoryTapHuan enumLoai)
        {
            switch (enumLoai)
            {
                case CategoryTapHuan.TH_TAPHUAN:
                    //layThongTinGV.Visibility = layGiangVienThuLao.Visibility
                    //    = layThongTinGV_empty.Visibility = layNguoiHoTro_empty.Visibility
                    //    = layNguoiHoTro.Visibility = layHoTroThuLao.Visibility = LayoutVisibility.Always;
                    grpSearchTitle.Text = "Danh sách hoạt động tập huấn";
                    break;
                case CategoryTapHuan.TH_GIAODUC:
                    grpSearchTitle.Text = "Danh sách hoạt động giáo dục";
                    //layThongTinGV.Visibility = layThongTinGV_empty.Visibility = LayoutVisibility.Always;
                    break;
                case CategoryTapHuan.HUONG_DAN_THUC_TAP:
                    grpSearchTitle.Text = "Danh sách hoạt động hướng dẫn thực tập";
                    break;
                case CategoryTapHuan.VAN_DONG_CHINH_SACH:
                    //laySoNguoiThamGia.Visibility = laySoTienTrenNguoi.Visibility = layTongTien.Visibility = LayoutVisibility.Never;
                    //layNguoiHoTro.Visibility = LayoutVisibility.Always;
                    //layNguoiHoTro.Text = "Người thực hiện";
                    //layDiaDiem.Text = "Nơi nhận";
                    grpSearchTitle.Text = "Danh sách hoạt động vận động chính sách";
                    break;
                case CategoryTapHuan.TRUYEN_THONG_PHAP_LY:
                    //layDonViThucHien.Visibility = LayoutVisibility.Always;
                    grpSearchTitle.Text = "Danh sách hoạt động truyền thông pháp lý";
                    break;
                default:
                    break;
            }
        }

        private void _statusAllControl(Boolean readOnly)
        {

            foreach (var items in layoutEdit.Controls)
            {
                BaseEdit item = items as BaseEdit;
                SimpleButton button = items as SimpleButton;
                if (button != null)
                {
                    button.Enabled = !readOnly;
                    continue;
                }
                if (item != null)
                {
                    item.ReadOnly = readOnly;
                    item.EnterMoveNextControl = true;
                }
                else
                {
                    CheckedListBoxControl checkListBox = items as CheckedListBoxControl;
                    if (checkListBox != null)
                    {
                        checkListBox.Enabled = !readOnly;
                    }
                }
            }
            deSearchTuNgay.ReadOnly = deSearchDenNgay.ReadOnly = !readOnly;
            btnSearch.Enabled = readOnly;
            gcGrid.Enabled = readOnly;
            seTongSoNgay.ReadOnly = true;
            //txtDoiTuong.ReadOnly = true;
        }

        private void _clearData()
        {
            foreach (var items in layoutEdit.Controls)
            {
                BaseEdit item = items as BaseEdit;
                if (item != null)
                {
                    item.EditValue = null;
                }
            }
        }

        private void _setFocusedRow()
        {
            for (int i = 0; i < gvGrid.RowCount; i++)
            {
                Int64 id = Convert.ToInt64(gvGrid.GetRowCellValue(i, colTH_ID));
                if (id == _idRowSelected)
                {
                    gvGrid.FocusedRowHandle = i;
                    break;
                }
            }
        }

        private void _loadData()
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            context = new QL_HOIVIEN_KTEntities();
            context.QL_HOATDONG_TAPHUAN.Load();
            var data = (from p in context.QL_HOATDONG_TAPHUAN
                        where deSearchTuNgay.DateTime.Date <= p.TH_THOIGIAN_BATDAU
                             && p.TH_THOIGIAN_BATDAU <= deSearchDenNgay.DateTime.Date
                             && p.TH_LOAI_ID == _id_loai
                        select p).ToList();
            gcGrid.DataSource = data;

            _setFocusedRow();
            _bindingData();

            _wait.Close();
        }

        private string _getMemoText(BindingList<QL_HOATDONG_TAPHUAN_CHITIET> data)
        {
            StringBuilder title = new StringBuilder();
            foreach (var item in data.Where(p=>p.TH_ID != constIdDeleted))
            {
                if (item.TH_CT_DIACHI != "")
                {
                    title.AppendFormat("{0}({1}); ", item.TH_CT_HOTEN, item.TH_CT_DIACHI);
                }else if(item.TH_CT_DONVI != "")
                {
                    title.AppendFormat("{0}({1}); ", item.TH_CT_HOTEN, item.TH_CT_DONVI);
                }
                else
                {
                    title.AppendFormat("{0}; ", item.TH_CT_HOTEN);
                }
                
            }
            return title.ToString();
        }

        private void _setMemoText(QL_HOATDONG_TAPHUAN item, CategoryTapHuanChiTietLoai enumLoai)
        {
            var query = context.QL_HOATDONG_TAPHUAN_CHITIET
                    .Where(p => p.TH_CT_LOAI == (int)enumLoai && p.TH_ID == item.TH_ID).ToList();

            switch (enumLoai)
            {
                case CategoryTapHuanChiTietLoai.NGUOI_THUC_HIEN:
                    listNguoiThucHien = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>(query);
                    memoNguoiThucHien.Text = _getMemoText(listNguoiThucHien);
                    break;
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_CHINH:
                    listTapHuanVienChinh = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>(query);
                    memoTHVChinh.Text = _getMemoText(listTapHuanVienChinh);
                    break;
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_PHU:
                    listTapHuanVienPhu = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>(query);
                    memoTHVPhu.Text = _getMemoText(listTapHuanVienPhu);
                    break;
                case CategoryTapHuanChiTietLoai.PHIEN_DICH_VIEN:
                    listPhienDichVien = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>(query);
                    memoPhienDichVien.Text = _getMemoText(listPhienDichVien);
                    break;
                default:
                    break;
            }
        }

        private void _bindingData()
        {
            _clearData();
            QL_HOATDONG_TAPHUAN item = gvGrid.GetFocusedRow() as QL_HOATDONG_TAPHUAN;
            if (item != null)
            {
                //Thông tin chung
                deTuNgay.EditValue = item.TH_THOIGIAN_BATDAU;
                deDenNgay.EditValue = item.TH_THOIGIAN_KETTHUC;
                seTongSoNgay.EditValue = item.TH_TONGSO_NGAY;
                txtTenChuongTrinh.EditValue = item.TH_TEN;
                lueLaHoatDong.EditValue = item.TH_LA_HOATDONG;
                lueNhaTaiTro.EditValue = item.NTT_ID;
                lueDonViPhuTrach.EditValue = item.TH_DONVI_PHUTRACH;
                lueTinh.EditValue = item.TH_TINH_THUCHIEN;
                txtHoatDongMa.EditValue = item.TH_HOATDONG_MA;
                lueLoaiHoatDong.EditValue = item.TH_HOATDONG_LOAI;

                _setMemoText(item, CategoryTapHuanChiTietLoai.NGUOI_THUC_HIEN);
                _setMemoText(item, CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_CHINH);
                _setMemoText(item, CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_PHU);
                _setMemoText(item, CategoryTapHuanChiTietLoai.PHIEN_DICH_VIEN);

                //Tập huấn viên
                txtLinkTHVHopDong.EditValue = item.TH_LINK_THV_HOPDONG;
                txtLinkTHVBanCamKet.EditValue = item.TH_LINK_THV_BANCAMKET;
                txtLinkTaiLieu.EditValue = item.TH_LINK_TAILIEU;

                //txtDiaDiem.EditValue = item.TH_DIADIEM;
                //txtDonViThucHien.EditValue = item.TH_DONVI_THUCHIEN;
                //seSoLuongNguoiThamGia.EditValue = item.TH_SOLUONG;
                //seSoTienMoiNguoi.EditValue = item.TH_SOTIEN_1NGUOI;
                //seTongTien.EditValue = item.TH_TONGTIEN;

                //txtDoiTuong.EditValue = item.TH_DOITUONG_TEN;
                //txtDoiTuongId.EditValue = item.TH_DOITUONG_ID;
                //txtDoiTuongKhac.EditValue = item.TH_DOITUONG_KHAC;

                //txtNoiDung.EditValue = item.TH_NOIDUNG;
                //txtThongTinGiangVien.EditValue = item.TH_GIANGVIEN;
                //seThuLaoGV.EditValue = item.TH_GIANGVIEN_THULAO;
                //txtThongTinNguoiHoTro.EditValue = item.TH_NGUOI_HOTRO;
                //seThuLaoHoTro.EditValue = item.TH_NGUOI_HOTRO_THULAO;
            }
        }

        private void _setObjectEntities(ref QL_HOATDONG_TAPHUAN item)
        {
            item.TH_LOAI_ID = _id_loai;
            item.TH_THOIGIAN_BATDAU = deTuNgay.Ex_EditValueToDateTime();
            item.TH_THOIGIAN_KETTHUC = deDenNgay.Ex_EditValueToDateTime();
            item.TH_TONGSO_NGAY = seTongSoNgay.Ex_EditValueToInt();

            //Thông tin
            item.TH_TEN = txtTenChuongTrinh.Text ;
            item.TH_LA_HOATDONG = lueLaHoatDong.Text;
            item.NTT_ID = lueNhaTaiTro.Ex_EditValueToInt();
            item.TH_DONVI_PHUTRACH = lueDonViPhuTrach.Text;
            item.TH_TINH_THUCHIEN = lueTinh.Text;
            item.TH_HOATDONG_MA = txtHoatDongMa.Text;
            item.TH_HOATDONG_LOAI = lueLoaiHoatDong.Text;
            item.TH_LINK_THV_HOPDONG = txtLinkTHVHopDong.Text;
            item.TH_LINK_THV_BANCAMKET = txtLinkTHVBanCamKet.Text;
            item.TH_LINK_TAILIEU = txtLinkTaiLieu.Text;

            //item.TH_DIADIEM = txtDiaDiem.Text;
            //item.TH_DONVI_THUCHIEN = txtDonViThucHien.Text;
            //item.TH_SOLUONG = seSoLuongNguoiThamGia.Ex_EditValueToInt();
            //item.TH_SOTIEN_1NGUOI = seSoTienMoiNguoi.Ex_EditValueToInt();
            //item.TH_TONGTIEN = seTongTien.Ex_EditValueToInt();

            //item.TH_DOITUONG_TEN = txtDoiTuong.Text;
            //item.TH_DOITUONG_ID = txtDoiTuongId.Text;
            //item.TH_DOITUONG_KHAC = txtDoiTuongKhac.Text;

            //item.TH_NOIDUNG = txtNoiDung.Text;
            //item.TH_GIANGVIEN = txtThongTinGiangVien.Text;
            //item.TH_GIANGVIEN_THULAO = seThuLaoGV.Ex_EditValueToInt();
            //item.TH_NGUOI_HOTRO = txtThongTinNguoiHoTro.Text;
            //item.TH_NGUOI_HOTRO_THULAO = seThuLaoHoTro.Ex_EditValueToInt();
        }

        private Boolean _validateControl()
        {
            dxErrorProvider.ClearErrors();

            if (txtTenChuongTrinh.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenChuongTrinh, "Vui lòng nhập họ tên");
            }

            if (clsChangeType.change_int(seTongSoNgay.EditValue)  <= 0)
            {
                dxErrorProvider.SetError(deDenNgay, "Từ ngày và đến ngày không phù hợp");
            }

            if (dxErrorProvider.HasErrors)
            {
                clsMessage.MessageWarning("Vui lòng nhập đầy đủ thông tin.");
            }

            return !dxErrorProvider.HasErrors;
        }

        private void _initMemoData()
        {
            listNguoiThucHien = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>();
            listTapHuanVienChinh = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>();
            listTapHuanVienPhu = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>();
            listPhienDichVien = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>();
        }

        private void _updateMemoData(QL_HOIVIEN_KTEntities _context, QL_HOATDONG_TAPHUAN item, BindingList<QL_HOATDONG_TAPHUAN_CHITIET> list_chitiet)
        {
            QL_HOATDONG_TAPHUAN_CHITIET item_chitiet;
            foreach (var person in list_chitiet)
            {
                if (person.TH_ID == null) //add
                {
                    person.QL_HOATDONG_TAPHUAN = item;
                    _context.QL_HOATDONG_TAPHUAN_CHITIET.Add(person);
                }
                else if (person.TH_ID == constIdDeleted) //delete
                {
                    item_chitiet = (from p in _context.QL_HOATDONG_TAPHUAN_CHITIET
                                    where p.TH_CT_ID == person.TH_CT_ID
                                    select p).FirstOrDefault();
                    if (item_chitiet != null)
                    {
                        _context.QL_HOATDONG_TAPHUAN_CHITIET.Remove(item_chitiet);
                    }
                }
                else //modify
                {
                    var chitiet = _context.QL_HOATDONG_TAPHUAN_CHITIET.Where(p => p.TH_CT_ID == person.TH_CT_ID).FirstOrDefault();
                    if (chitiet != null)
                    {
                        _context.Entry(chitiet).CurrentValues.SetValues(person);
                    }
                }
            }
        }

        private void _insertMemoData(QL_HOIVIEN_KTEntities _context, QL_HOATDONG_TAPHUAN item, BindingList<QL_HOATDONG_TAPHUAN_CHITIET> list_chitiet)
        {
            foreach (var row in list_chitiet)
            {
                row.QL_HOATDONG_TAPHUAN = item;
                _context.QL_HOATDONG_TAPHUAN_CHITIET.Add(row);
            }
            _context.QL_HOATDONG_TAPHUAN.Add(item);
        }

        protected override bool SaveData()
        {
            if (_validateControl())
            {
                using (var _context = new QL_HOIVIEN_KTEntities())
                {
                    QL_HOATDONG_TAPHUAN item;
                    switch (_formStatus)
                    {
                        case EnumFormStatus.ADD:

                            item = new QL_HOATDONG_TAPHUAN();
                            _setObjectEntities(ref item);

                            _insertMemoData(_context, item, listNguoiThucHien);
                            _insertMemoData(_context, item, listTapHuanVienChinh);
                            _insertMemoData(_context, item, listTapHuanVienPhu);
                            _insertMemoData(_context, item, listPhienDichVien);

                            _context.SaveChanges();
                            _idRowSelected = item.TH_ID;
                            break;

                        case EnumFormStatus.MODIFY:
                            Int64 id = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colTH_ID));
                            item = (from p in _context.QL_HOATDONG_TAPHUAN where p.TH_ID == id select p).FirstOrDefault<QL_HOATDONG_TAPHUAN>();
                            if (item != null)
                            {
                                _setObjectEntities(ref item);
                            }
                            var entity = _context.QL_HOATDONG_TAPHUAN.Find(id);
                            if(entity != null)
                            {
                                _context.Entry(entity).CurrentValues.SetValues(item);
                            }

                            _updateMemoData(_context, item, listNguoiThucHien);
                            _updateMemoData(_context, item, listTapHuanVienChinh);
                            _updateMemoData(_context, item, listTapHuanVienPhu);
                            _updateMemoData(_context, item, listPhienDichVien);
                            break;
                        default:
                            break;
                    }
                    _context.SaveChanges();
                }
                FormStatus = EnumFormStatus.VIEW;
            }

            return base.SaveData();
        }

        private void _deleteRow()
        {
            QL_HOATDONG_TAPHUAN item = gvGrid.GetFocusedRow() as QL_HOATDONG_TAPHUAN;
            if (item != null)
            {
                if (clsMessage.MessageYesNo(string.Format("Bạn có chắc muốn xóa: {0}", item.TH_TEN)) == DialogResult.Yes)
                {
                    Int64 id = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colTH_ID));
                    QL_HOATDONG_TAPHUAN entities = (from p in context.QL_HOATDONG_TAPHUAN where p.TH_ID == id select p).FirstOrDefault();
                    context.QL_HOATDONG_TAPHUAN.Remove(entities);
                    context.SaveChanges();
                    FormStatus = EnumFormStatus.VIEW;
                }

            }

        }

        private void _print()
        {
            rptBCHoatDongTapHuan rpt = new rptBCHoatDongTapHuan();
            CategoryTapHuan enumLoai = (CategoryTapHuan)_id_loai;
            //switch (enumLoai)
            //{
            //    case CategoryTapHuan.TH_TAPHUAN:
                    var data = (from p in context.QL_HOATDONG_TAPHUAN
                                where deSearchTuNgay.DateTime.Date <= p.TH_THOIGIAN_BATDAU
                                     && p.TH_THOIGIAN_BATDAU <= deSearchDenNgay.DateTime.Date
                                     && p.TH_LOAI_ID == _id_loai
                                select p).ToList();
                    List<clsHoatDongTapHuan> listTapHuan = new List<clsHoatDongTapHuan>();
                    foreach (QL_HOATDONG_TAPHUAN row in data)
                    {
                        clsHoatDongTapHuan item = new clsHoatDongTapHuan();
                        item.TH_TEN = row.TH_TEN;
                        item.TH_THOIGIAN = FunctionHelper.formatFromDateToDate(row.TH_THOIGIAN_BATDAU, row.TH_THOIGIAN_KETTHUC);
                        item.TH_DIADIEM = row.TH_DIADIEM;
                        item.TH_DONVI_THUCHIEN = row.TH_DONVI_THUCHIEN;
                        item.TH_SOLUONG = row.TH_SOLUONG;
                        item.TH_TONGTIEN = row.TH_TONGTIEN??0;
                        item.TH_NOIDUNG = row.TH_NOIDUNG;
                        listTapHuan.Add(item);
                    }
                    DataTable dataTapHuan = FunctionHelper.ConvertToDataTable(listTapHuan);
                    dataTapHuan.TableName = "HoatDongTapHuan";

                    rpt.pLeftHeader.Value = clsParameter.pHospital;
                    rpt.pParentLeftHeader.Value = clsParameter.pParentHospital;
                    rpt.pTitle.Value = lueLoaiTapHuan.Text.ToUpper();
                    rpt.pTuNgayDenNgay.Value = FunctionHelper.formatFromDateToDate(deSearchTuNgay.DateTime, deSearchDenNgay.DateTime);
                    //rpt.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM10);
                    //rpt.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM10);

                    rpt.DataSource = dataTapHuan;
                    rpt.DataMember = "HoatDongTapHuan";
            //        break;
            //    default:
            //        break;
            //}

            frmPrint f = new frmPrint(rpt);
            f.ShowDialog();
        }

        private void _memoButtonClick(CategoryTapHuanChiTietLoai enumLoai)
        {

            frmTapHuanChiTiet frm = new frmTapHuanChiTiet((int)enumLoai);
            switch (enumLoai)
            {
                case CategoryTapHuanChiTietLoai.NGUOI_THUC_HIEN:
                    frm.Text = "Người thực hiện";
                    frm.data = listNguoiThucHien;
                    break;
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_CHINH:
                    frm.Text = "Tập huấn viên chính";
                    frm.data = listTapHuanVienChinh;
                    break;
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_PHU:
                    frm.Text = "Tập huấn viên phụ";
                    frm.data = listTapHuanVienPhu;
                    break;
                case CategoryTapHuanChiTietLoai.PHIEN_DICH_VIEN:
                    frm.Text = "Phiên dịch viên";
                    frm.data = listPhienDichVien;
                    break;
                default:
                    break;
            }

            frm.ShowDialog();

            switch (enumLoai)
            {
                case CategoryTapHuanChiTietLoai.NGUOI_THUC_HIEN:
                    listNguoiThucHien = frm.data;
                    memoNguoiThucHien.Text = _getMemoText(listNguoiThucHien);
                    break;
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_CHINH:
                    listTapHuanVienChinh = frm.data;
                    memoTHVChinh.Text = _getMemoText(listTapHuanVienChinh);
                    break;
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_PHU:
                    listTapHuanVienPhu = frm.data;
                    memoTHVPhu.Text = _getMemoText(listTapHuanVienPhu);
                    break;
                case CategoryTapHuanChiTietLoai.PHIEN_DICH_VIEN:
                    listPhienDichVien = frm.data;
                    memoPhienDichVien.Text = _getMemoText(listPhienDichVien);
                    break;
                default:
                    break;
            }

        }

        #endregion

        #region Status

        protected override EnumFormStatus FormStatus
        {
            get { return _formStatus; }
            set
            {
                _formStatus = value;
                if (_formStatus == EnumFormStatus.ADD)
                {
                    _clearData();
                    _initMemoData();
                    deTuNgay.Focus();
                    _statusAllControl(false);
                }
                else if (_formStatus == EnumFormStatus.MODIFY)
                {
                    deTuNgay.Focus();
                    _statusAllControl(false);
                }
                else if (_formStatus == EnumFormStatus.DELETE)
                {
                    _deleteRow();
                }
                else if (_formStatus == EnumFormStatus.PRINT)
                {
                    _print();
                }
                else if (_formStatus == EnumFormStatus.CLOSE)
                {
                    if (closeTab != null)
                    {
                        closeTab();
                    }
                }
                else
                {
                    _loadData();
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
                    dxErrorProvider.ClearErrors();
                    _statusAllControl(true);
                    btnControl.btnModify.Enabled = btnControl.btnDelete.Enabled = btnControl.btnPrint.Enabled = gvGrid.RowCount > 0;
                    base.permissionAccessButton(btnControl, (Int32)FunctionName.FUNC_NANGCAO_NANGLUC);
                }
            }
        }

        private void _calTongSoNgay()
        {
            if (deTuNgay.EditValue != null && deDenNgay.EditValue != null)
            {
                TimeSpan diff = deDenNgay.DateTime - deTuNgay.DateTime;
                seTongSoNgay.EditValue = diff.Days + 1;
            }
        }

        private void _calTongTien()
        {
            //if(seSoLuongNguoiThamGia.EditValue != null && seSoTienMoiNguoi.EditValue != null)
            //{
            //    seTongTien.EditValue = clsChangeType.change_int64(seSoLuongNguoiThamGia.EditValue) * clsChangeType.change_int64(seSoTienMoiNguoi.EditValue);
            //}
        }

        #endregion

        #region Event Grid

        private void gvGrid_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            _idRowSelected = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colTH_ID));
            _bindingData();
        }

        #endregion

        #region Event button

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _loadData();
            FormStatus = EnumFormStatus.VIEW;
        }

        private void deTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            _calTongSoNgay();
        }

        private void deDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            _calTongSoNgay();
        }

        private void seSoLuongNguoiThamGia_EditValueChanged(object sender, EventArgs e)
        {
            _calTongTien();
        }

        private void seSoTienMoiNguoi_EditValueChanged(object sender, EventArgs e)
        {
            _calTongTien();
        }

        private void btnSelectHoiVien_Click(object sender, EventArgs e)
        {
            frmSelectHoiVien frm = new frmSelectHoiVien();
            //frm.selectNameList = txtDoiTuong.Text;
            //frm.selectIdList = txtDoiTuongId.Text;
            //frm.ShowDialog();

            //txtDoiTuong.Text = frm.selectNameList;
            //txtDoiTuongId.Text = frm.selectIdList;
        }

        private void btnDonViTaiTro_Click(object sender, EventArgs e)
        {
            frmNhaTaiTro frm = new frmNhaTaiTro();
            frm.ShowDialog();
            lueNhaTaiTro.Properties.DataSource = FuncCategory.loadCategoryReturn(CategoryEntitiesTable.DM_NHA_TAI_TRO);
        }

        private void btnTapHuanVienChinh_Click(object sender, EventArgs e)
        {
            _memoButtonClick(CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_CHINH);
        }

        private void btnNguoiThucHien_Click(object sender, EventArgs e)
        {
            _memoButtonClick(CategoryTapHuanChiTietLoai.NGUOI_THUC_HIEN);

        }

        private void btnPhienDichVien_Click(object sender, EventArgs e)
        {
            _memoButtonClick(CategoryTapHuanChiTietLoai.PHIEN_DICH_VIEN);
        }

        private void btnTapHuanVienPhu_Click(object sender, EventArgs e)
        {
            _memoButtonClick(CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_PHU);
        }

        private void btnLinkTHVHopDong_Click(object sender, EventArgs e)
        {
            FunctionHelper.openLink(txtLinkTHVHopDong.Text);
        }

        private void btnLinkTHVBanCamKet_Click(object sender, EventArgs e)
        {
            FunctionHelper.openLink(txtLinkTHVBanCamKet.Text);
        }

        private void btnLinkTaiLieu_Click(object sender, EventArgs e)
        {
            FunctionHelper.openLink(txtLinkTaiLieu.Text);
        }

        #endregion


    }
}
