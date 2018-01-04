using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DauThau.Models;
using DevExpress.XtraEditors;

namespace DauThau.Class
{
    class FuncCategory
    {
        
        public static void loadDMTinh(LookUpEdit lue, Boolean itemIndexFirst = true)
        {
            using (var context = new QL_HOIVIEN_KTEntities())
            {
                var dmThanhPho = (from p in context.DM_TINH select p).ToList();
                lue.Properties.DataSource = dmThanhPho;
                if (dmThanhPho.Count > 0 && itemIndexFirst)
                {
                    lue.ItemIndex = 0;
                }
            }
        }

        public static void loadDMHuyen(LookUpEdit lue, Int64 idTinh, Boolean itemIndexFirst = true)
        {
            using (var context = new QL_HOIVIEN_KTEntities())
            {
                var dmHuyen = (from p in context.DM_HUYEN where p.TINH_ID == idTinh select p).ToList();
                lue.Properties.DataSource = dmHuyen;
                if (dmHuyen.Count > 0 && itemIndexFirst)
                {
                    lue.ItemIndex = 0;
                }
            }
        }
    }
}
