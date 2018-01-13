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

    }
}
