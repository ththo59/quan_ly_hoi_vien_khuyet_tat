using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace DauThau.Class
{
    class ReportHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_loaiBaoCao"></param>
        /// <returns></returns>
        public static string getTitleFooter(LoaiBaoCao _loaiBaoCao){
            string str = "select * from SystemConfig  where SystemConfig_Parameter like '%{0}%' and SystemConfig_Type = '{1}'";
            str = string.Format(str, _loaiBaoCao.GetNameExtension(), loaiCauHinh.Type_Report.GetNameExtension());
            DataTable dt = FunctionHelper.LoadDM(str);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["SystemConfig_Description"] + string.Empty;
            }
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_loaiBaoCao"></param>
        /// <returns></returns>
        public static string getValueFooter(LoaiBaoCao _loaiBaoCao)
        {
            string str = "select * from SystemConfig  where SystemConfig_Parameter like '%{0}%' and SystemConfig_Type = '{1}'";
            str = string.Format(str, _loaiBaoCao.GetNameExtension(), loaiCauHinh.Type_Report.GetNameExtension());
            DataTable dt = FunctionHelper.LoadDM(str);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["SystemConfig_Value"] + string.Empty;
            }
            return string.Empty;
        }
    }
}
