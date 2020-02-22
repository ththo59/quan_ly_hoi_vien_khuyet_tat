using DauThau.Models;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Windows.Forms;
using DauThau.Class;

namespace DauThau.UserControlMain
{
    public partial class frmTapHuanChonDanhSach : XtraForm
    {
        private int _loai_id;
        public frmTapHuanChonDanhSach(int loaiId)
        {
            InitializeComponent();
            _loai_id = loaiId;

        }
        public QL_HOATDONG_TAPHUAN_CHITIET rowSelected = new QL_HOATDONG_TAPHUAN_CHITIET();
        public string selectIdList = string.Empty;

        public class clsSelectList
        {
            public Int64 TH_CT_ID { get; set; }
            public Boolean CHON { get; set; }
            public string TH_CT_HO { get; set; }
            public string TH_CT_TEN { get; set; }
            public string TH_CT_GIOITINH { get; set; }
            public string TH_CT_DIACHI { get; set; }
        }

        public List<clsSelectList> listHoiVen = new List<clsSelectList>();
        private void frmTapHuanChonDanhSach_Load(object sender, EventArgs e)
        {
            string[] hoivienIdList = selectIdList.Split(new[] { "; " }, StringSplitOptions.None);

            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            QL_HOIVIEN_KTEntities context = new QL_HOIVIEN_KTEntities();
            context.QL_HOATDONG_TAPHUAN_CHITIET.Load();
            var data = (from p in context.QL_HOATDONG_TAPHUAN_CHITIET
                        select new clsSelectList
                        {
                            TH_CT_ID = p.TH_CT_ID,
                            TH_CT_HO = p.TH_CT_HO,
                            TH_CT_TEN = p.TH_CT_TEN,
                            TH_CT_GIOITINH = p.TH_CT_GIOITINH,
                            TH_CT_DIACHI = p.TH_CT_DIACHI
                        }
                        ).Distinct().ToList();
            gcGrid.DataSource = data;
            _wait.Close();
        }

        private void btnControl_btnEventClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnControl_btnEventSelect_Click(object sender, EventArgs e)
        {
            btnControl.btnSelect.Enabled = false;
            for (int i = 0; i < gvGrid.RowCount; i++)
            {
                if (clsChangeType.change_bool(gvGrid.GetRowCellValue(i, colCHON))) {
                    Int64 id = clsChangeType.change_int64(gvGrid.GetRowCellValue(i, colTH_CT_ID));
                    QL_HOIVIEN_KTEntities context = new QL_HOIVIEN_KTEntities();
                    context.QL_HOATDONG_TAPHUAN_CHITIET.Load();
                    rowSelected = (from p in context.QL_HOATDONG_TAPHUAN_CHITIET where p.TH_CT_ID == id select p).FirstOrDefault();
                    break;
                }
            }
            this.Close();
        }

        private void chkChon_CheckedChanged(object sender, EventArgs e)
        {
            //Bỏ chọn các dòng khác
            int rowFocus = gvGrid.FocusedRowHandle;
            for (int i = 0; i < gvGrid.RowCount; i++)
            {
                if (i == rowFocus)
                {
                    continue;
                }
                gvGrid.SetRowCellValue(i, colCHON, false);
            }
        }
    }
}
