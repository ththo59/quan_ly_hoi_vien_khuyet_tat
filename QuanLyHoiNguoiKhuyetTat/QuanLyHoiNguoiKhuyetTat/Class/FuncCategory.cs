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
            item = new dynamicObject()
            {
                ID = 3,
                NAME = "Khác"
            };

            list.Add(item);
            return list;
        }

        public static List<dynamicObject> loadDMTapHuan()
        {
            List<dynamicObject> list = new List<dynamicObject>();
            var item = new dynamicObject()
            {
                ID = 1,
                NAME = "Tập huấn"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 2,
                NAME = "Giáo dục"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 3,
                NAME = "Hướng dẫn thực tập"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 4,
                NAME = "Vận động chính sách"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 5,
                NAME = "Truyền thông và trợ giúp pháp lý"
            };
            list.Add(item);

            return list;
        }

        public static List<dynamicObject> loadDMHoiThao()
        {
            List<dynamicObject> list = new List<dynamicObject>();
            var item = new dynamicObject()
            {
                ID = 1,
                NAME = "Đại hội"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 2,
                NAME = "Hội nghị"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 3,
                NAME = "Hội thảo"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 4,
                NAME = "Buổi lễ"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 5,
                NAME = "Cuộc họp"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 6,
                NAME = "Truyền thông đại chúng"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 7,
                NAME = "Tổ chức sự kiện"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 8,
                NAME = "Tổ chức văn nghệ"
            };
            list.Add(item);

            return list;
        }

        public static List<dynamicObject> loadDMASXH()
        {
            List<dynamicObject> list = new List<dynamicObject>();
            var item = new dynamicObject()
            {
                ID = 1,
                NAME = "Giải phẫu chỉnh hình"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 2,
                NAME = "Tặng quà"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 3,
                NAME = "Tặng dụng cụ trợ giúp (xe lăn, xe lắc, nạng, nẹp)"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 4,
                NAME = "Học bổng"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 5,
                NAME = "Bảo hiểm y tế"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 6,
                NAME = "Hỗ trợ Hội viên gặp khó khăn và người có bệnh hiểm nghèo"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 7,
                NAME = "Thăm viếng hữu sự"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 8,
                NAME = "Đám cưới"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 9,
                NAME = "Cất nhà"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 10,
                NAME = "Sửa nhà"
            };
            list.Add(item);

            return list;
        }

        public static List<dynamicObject> loadDMHNXH()
        {
            List<dynamicObject> list = new List<dynamicObject>();
            var item = new dynamicObject()
            {
                ID = 1,
                NAME = "Giao lưu"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 2,
                NAME = "Liên hoan"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 3,
                NAME = "Đón khách"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 4,
                NAME = "Tham quan du lịch"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 5,
                NAME = "Văn nghệ"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 6,
                NAME = "Thể thao"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 7,
                NAME = "Lao động công ích"
            };
            list.Add(item);

            return list;
        }

        public static List<dynamicObject> loadDMViecLam()
        {
            List<dynamicObject> list = new List<dynamicObject>();

            var item = new dynamicObject()
            {
                ID = 1,
                NAME = "Giới thiệu việc làm"
            };
            list.Add(item);

            item = new dynamicObject()
            {
                ID = 2,
                NAME = "Giải quyết việc làm"
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
                    case CategoryEntitiesTable.DM_DUNGCU_HOTRO:
                        listItem = (from p in context.DM_DUNGCU_HOTRO orderby p.DCHT_STT select p).ToList();
                        break;
                    case CategoryEntitiesTable.DM_NOI_SINH_SONG:
                        listItem = (from p in context.DM_NOI_SINH_SONG orderby p.NSS_STT select p).ToList();
                        break;
                    case CategoryEntitiesTable.DM_NGOAINGU:
                        listItem = (from p in context.DM_NGOAINGU orderby p.NN_STT select p).ToList();
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
                else
                {
                    lue.EditValue = null;
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
                else
                {
                    lue.EditValue = null;
                }
                
            }
        }
    }
}
