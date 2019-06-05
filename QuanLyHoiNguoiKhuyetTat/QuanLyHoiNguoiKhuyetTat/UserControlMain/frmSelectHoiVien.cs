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

namespace DauThau.UserControlMain
{
    public partial class frmSelectHoiVien : XtraForm
    {
        public frmSelectHoiVien()
        {
            InitializeComponent();
        }
        public string selectNameList=  string.Empty;
        public string selectIdList = string.Empty;

        public class clsSelectHoiVien
        {
            public Int64 HV_ID { get; set; }
            public Boolean CHON { get; set; }
            public string HV_HO { get; set; }
            public string HV_TEN { get; set; }
            public string HV_GIOI_TINH { get; set; }
            public int? HV_TUOI { get; set; }
            public string HV_THUONGTRU_DIACHI { get; set; }
        }

        public List<clsSelectHoiVien> listHoiVen = new List<clsSelectHoiVien>();
        private void frmSelectHoiVien_Load(object sender, EventArgs e)
        {
            string[] hoivienIdList = selectIdList.Split(new[] { "; " }, StringSplitOptions.None);

            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            QL_HOIVIEN_KTEntities context = new QL_HOIVIEN_KTEntities();
            context.QL_HOIVIEN.Load();
            var data = (from p in context.QL_HOIVIEN
                        select p).ToList();
            foreach (QL_HOIVIEN p in data)
            {
                clsSelectHoiVien item = new clsSelectHoiVien();
                item.CHON = hoivienIdList.Contains(p.HV_ID.ToString());
                item.HV_ID = p.HV_ID;
                item.HV_HO = p.HV_HO;
                item.HV_TEN = p.HV_TEN;
                item.HV_GIOI_TINH = p.HV_GIOI_TINH;
                item.HV_TUOI = p.HV_TUOI;
                item.HV_THUONGTRU_DIACHI = p.HV_THUONGTRU_DIACHI;
                listHoiVen.Add(item);
            }
            gcGrid.DataSource = listHoiVen;
            _wait.Close();
        }

        private void btnControl_btnEventClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnControl_btnEventSelect_Click(object sender, EventArgs e)
        {
            selectNameList = selectIdList = string.Empty;
            foreach (var item in listHoiVen.OrderBy(k=>k.HV_TEN))
            {
                if (item.CHON)
                {
                    if (string.IsNullOrEmpty(selectNameList))
                    {
                        selectNameList =item.HV_HO + " " + item.HV_TEN;
                    }
                    else
                    {
                        selectNameList += "; " + item.HV_HO + " " + item.HV_TEN;
                    }

                    if (string.IsNullOrEmpty(selectIdList))
                    {
                        selectIdList = item.HV_ID.ToString() ;
                    }
                    else
                    {
                        selectIdList += "; " + item.HV_ID.ToString();
                    }
                }
            }
            this.Close();
        }

    }
}
