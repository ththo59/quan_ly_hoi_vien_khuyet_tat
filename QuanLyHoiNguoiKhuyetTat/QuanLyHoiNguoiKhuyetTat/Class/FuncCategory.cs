﻿using System;
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
        public class dynamicObject
        {
            public Int64 ID { get; set; }
            public string NAME { get; set; }
        }

        public static List<dynamicObject> loadDMGioiTinh()
        {
            List<dynamicObject> list = new List<dynamicObject>();
            var item = new dynamicObject()
            {
                ID = 1,
                NAME = "Nam"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 0,
                NAME = "Nữ"
            };
            list.Add(item);
            return list;
        }

        public static void loadCategoryByName(CategoryEntitiesTable table, LookUpEdit lue, Boolean itemIndexFirst = true)
        {
            using (var context = new QL_HOIVIEN_KTEntities())
            {
                var listItem = (object)null;
                switch (table)
                {
                    case CategoryEntitiesTable.DM_GIOITINH:
                        listItem = loadDMGioiTinh();
                        break;
                    case CategoryEntitiesTable.DM_NGHE_NGHIEP:
                        listItem = (from p in context.DM_NGHE_NGHIEP orderby p.NN_STT select p).ToList();
                        break;
                    case CategoryEntitiesTable.DM_TINH:
                        listItem = (from p in context.DM_TINH orderby p.TINH_STT select p).ToList();
                        break;
                    case CategoryEntitiesTable.DM_DANTOC:
                        listItem = (from p in context.DM_DANTOC orderby p.DT_STT select p).ToList();
                        break;
                    case CategoryEntitiesTable.DM_TONGIAO:
                        listItem = (from p in context.DM_TONGIAO orderby p.TG_STT select p).ToList();
                        break;
                    case CategoryEntitiesTable.DM_CHUCVU_HOI:
                        listItem = (from p in context.DM_CHUCVU_HOI orderby p.CV_STT select p).ToList();
                        break;
                    case CategoryEntitiesTable.DM_TRINH_DO_CHUYEN_MON:
                        listItem = (from p in context.DM_TRINH_DO_CHUYEN_MON orderby p.CM_STT select p).ToList();
                        break;
                    case CategoryEntitiesTable.DM_TRINH_DO_HOC_VAN:
                        listItem = (from p in context.DM_TRINH_DO_HOC_VAN orderby p.HV_STT select p).ToList();
                        break;
                    case CategoryEntitiesTable.DM_KHUYETTAT_MUCDO:
                        listItem = (from p in context.DM_KHUYETTAT_MUCDO orderby p.MDKT_STT select p).ToList();
                        break;
                    case CategoryEntitiesTable.DM_KHUYETTAT_NGUYENNHAN:
                        listItem = (from p in context.DM_KHUYETTAT_NGUYENNHAN orderby p.NNKT_STT select p).ToList();
                        break;
                    case CategoryEntitiesTable.DM_KHUYETTAT_TINHTRANG:
                        listItem = (from p in context.DM_KHUYETTAT_TINHTRANG orderby p.TTKT_STT select p).ToList();
                        break;
                    case CategoryEntitiesTable.DM_PHUONGTIEN_DILAI:
                        listItem = (from p in context.DM_PHUONGTIEN_DILAI orderby p.PT_STT select p).ToList();
                        break;
                    case CategoryEntitiesTable.DM_TINHTRANG_HONNHAN:
                        listItem = (from p in context.DM_TINHTRANG_HONNHAN orderby p.TTHN_STT select p).ToList();
                        break;
                    default:
                        break;
                }

                if(listItem == null)
                {
                    return;
                }

                lue.Properties.DataSource = listItem;
                if (itemIndexFirst)
                {
                    lue.ItemIndex = 0;
                }
            }
        }


        public static void loadDMHuyen(LookUpEdit lue, string tenTinh, Boolean itemIndexFirst = true)
        {
            using (var context = new QL_HOIVIEN_KTEntities())
            {
                var dmHuyen = (from p in context.DM_HUYEN
                               let tinh = p.DM_TINH
                               orderby p.HUYEN_STT where tinh.TINH_TEN == tenTinh
                               select p).ToList();
                lue.Properties.DataSource = dmHuyen;
                if (dmHuyen.Count > 0 && itemIndexFirst)
                {
                    lue.ItemIndex = 0;
                }
            }
        }

        public static void loadDMXa(LookUpEdit lue, string tenHuyen, Boolean itemIndexFirst = true)
        {
            using (var context = new QL_HOIVIEN_KTEntities())
            {
                var dm = (from p in context.DM_XA
                          let huyen = p.DM_HUYEN
                          orderby p.XA_STT where huyen.HUYEN_TEN == tenHuyen
                          select p).ToList();
                lue.Properties.DataSource = dm;
                if (dm.Count > 0 && itemIndexFirst)
                {
                    lue.ItemIndex = 0;
                }
            }
        }
    }
}
