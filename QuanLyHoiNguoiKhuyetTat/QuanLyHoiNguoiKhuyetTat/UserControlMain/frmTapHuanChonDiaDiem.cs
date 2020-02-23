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
    public partial class frmTapHuanChonDiaDiem : XtraForm
    {
        public frmTapHuanChonDiaDiem()
        {
            InitializeComponent();

        }
        public QL_HOATDONG_TAPHUAN_DIADIEM rowSelected = new QL_HOATDONG_TAPHUAN_DIADIEM();
        public string selectIdList = string.Empty;

        public class clsSelectList
        {
            public Int64 TH_DD_ID { get; set; }
            public Boolean CHON { get; set; }
            public string TH_DD_TEN { get; set; }
            public string TH_DD_NGUOI_DAIDIEN { get; set; }
            public string TH_DD_DIACHI { get; set; }
        }

        public List<clsSelectList> listHoiVen = new List<clsSelectList>();
        private void frmTapHuanChonDiaDiem_Load(object sender, EventArgs e)
        {
            string[] hoivienIdList = selectIdList.Split(new[] { "; " }, StringSplitOptions.None);

            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            QL_HOIVIEN_KTEntities context = new QL_HOIVIEN_KTEntities();
            context.QL_HOATDONG_TAPHUAN_DIADIEM.Load();
            var data = (from p in context.QL_HOATDONG_TAPHUAN_DIADIEM
                        group p by new { p.TH_DD_TEN, p.TH_DD_NGUOI_DAIDIEN, p.TH_DD_DIACHI } into g
                        select new clsSelectList
                        {
                            TH_DD_ID = g.Max(k=> k.TH_DD_ID),
                            TH_DD_TEN = g.Key.TH_DD_TEN,
                            TH_DD_NGUOI_DAIDIEN = g.Key.TH_DD_NGUOI_DAIDIEN,
                            TH_DD_DIACHI = g.Key.TH_DD_DIACHI
                        }
                        ).ToList();
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
                    Int64 id = clsChangeType.change_int64(gvGrid.GetRowCellValue(i, colTH_DD_ID));
                    QL_HOIVIEN_KTEntities context = new QL_HOIVIEN_KTEntities();
                    context.QL_HOATDONG_TAPHUAN_DIADIEM.Load();
                    rowSelected = (from p in context.QL_HOATDONG_TAPHUAN_DIADIEM where p.TH_DD_ID == id select p).FirstOrDefault();
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
