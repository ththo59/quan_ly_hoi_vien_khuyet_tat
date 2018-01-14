using DevExpress.XtraEditors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
