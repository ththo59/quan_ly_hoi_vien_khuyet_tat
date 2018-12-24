using DauThau.Models;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DauThau.Class
{
    public static class clsExtensionCustom
    {
        /// <summary>
        /// Trả về số phần tử trong lookupedit
        /// </summary>
        /// <param name="lue"></param>
        /// <returns></returns>
        public static int ItemsCount(this LookUpEdit lue)
        {
            int count = (lue.Properties.DataSource as IList).Count;
            return count;
        }

        public static void setDefaultFirstItems(this LookUpEdit lue)
        {
            var list = (lue.Properties.DataSource as IList);
            if(list.Count > 0)
            {
                var item = lue.Properties.GetDataSourceValue(lue.Properties.ValueMember, 0);
                lue.EditValue = item;
            }
        }

        public static Nullable<Int64> Ex_EditValueToInt64(this LookUpEdit lue)
        {
            if(lue.EditValue == null)
            {
                return new Nullable<Int64>();
            }
            return Convert.ToInt64(lue.EditValue);
        }

        public static Nullable<DateTime> Ex_EditValueToDateTime(this DateEdit de)
        {
            if (de.EditValue == null)
            {
                return new Nullable<DateTime>();
            }
            return Convert.ToDateTime(de.EditValue);
        }

        public static void Ex_FormatCustomDateEdit(this DateEdit de)
        {
            de.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            de.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            de.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            de.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            de.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            de.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            de.Properties.Mask.EditMask = "dd/MM/yyyy";
        }

        public static void Ex_FormatCustomSpinEdit(this SpinEdit de)
        {
            de.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            de.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            de.Properties.DisplayFormat.FormatString = "#,#";
            de.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            de.Properties.EditFormat.FormatString = "#,#";
            de.Properties.Mask.EditMask = "n0";
            //de.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            //de.Properties.Mask.EditMask = "#,#";
        }

        #region CheckedListBoxControl

        public static string Ex_GetEditValueToString(this CheckedListBoxControl chkList)
        {
            string list = string.Empty;
            foreach (CheckedListBoxItem item in chkList.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    if (list == string.Empty)
                    {
                        list = item.Value + string.Empty;
                    }
                    else
                    {
                        list += "," + item.Value;
                    }
                }
            }
            return list;
        }

        public static void Ex_SetEditValueToString(this CheckedListBoxControl chkList, string list)
        {
            if (string.IsNullOrEmpty(list))
            {
                chkList.UnCheckAll();
                return;
            }
            String[] listArray = list.Split(',');
            foreach (CheckedListBoxItem item in chkList.Items)
            {
                if (list.Contains(item.Value + string.Empty))
                {
                    item.CheckState = CheckState.Checked;
                }
                else
                {
                    item.CheckState = CheckState.Unchecked;
                }
            }
        }

        public static void Ex_SetDataSource(this CheckedListBoxControl chkList, string table)
        {
            using (var context = new Models.QL_HOIVIEN_KTEntities())
            {
                CategoryEntitiesTable tableEnum = table.Ex_ToEnum<CategoryEntitiesTable>();
                switch (tableEnum)
                {
                    case CategoryEntitiesTable.DM_NOI_O_NHA:
                        var listItem = (from p in context.DM_NOI_O_NHA orderby p.NO_NHA_STT select p).ToArray();
                        foreach (DM_NOI_O_NHA item in listItem)
                        {
                            chkList.Items.Add(item.NO_NHA_ID, item.NO_NHA_TEN);
                        }
                        break;
                    case CategoryEntitiesTable.DM_NOI_O_SONG_VOI:
                        var listItem2 = (from p in context.DM_NOI_O_SONG_VOI orderby p.NOSV_STT select p).ToArray();
                        foreach (DM_NOI_O_SONG_VOI item in listItem2)
                        {
                            chkList.Items.Add(item.NOSV_ID, item.NOSV_TEN);
                        }
                        break;
                    case CategoryEntitiesTable.DM_CHAMSOC_BANTHAN:
                        var listItem3 = (from p in context.DM_CHAMSOC_BANTHAN orderby p.CSBT_STT select p).ToArray();
                        foreach (DM_CHAMSOC_BANTHAN item in listItem3)
                        {
                            chkList.Items.Add(item.CSBT_ID, item.CSBT_TEN);
                        }
                        break;
                    case CategoryEntitiesTable.DM_NHUCAU:
                        var listItem4 = (from p in context.DM_NHUCAU orderby p.NC_STT select p).ToArray();
                        foreach (DM_NHUCAU item in listItem4)
                        {
                            chkList.Items.Add(item.NC_ID, item.NC_TEN);
                        }
                        break;
                    case CategoryEntitiesTable.DM_THANHVIEN_HOI:
                        var listItem5 = (from p in context.DM_THANHVIEN_HOI orderby p.TVH_STT select p).ToArray();
                        foreach (DM_THANHVIEN_HOI item in listItem5)
                        {
                            chkList.Items.Add(item.TVH_ID, item.TVH_TEN);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        public static T Ex_ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static String Ex_ToString(this Enum eff)
        {
            return Enum.GetName(eff.GetType(), eff);
        }

        public static EnumType converToEnum<EnumType>(this String enumValue)
        {
            return (EnumType)Enum.Parse(typeof(EnumType), enumValue);
        }


        public static Nullable<Int32> Ex_EditValueToInt(this SpinEdit se)
        {
            if(se.EditValue == null)
            {
                return new Nullable<Int32>();
            }
            return Convert.ToInt32(se.EditValue);
        }
    }
}
