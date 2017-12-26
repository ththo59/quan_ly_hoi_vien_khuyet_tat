using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DauThau.Class
{
    class clsChangeType
    {
        /// <summary>
        /// trả về giá trị kiểu decimal
        /// </summary>
        /// <param name="pstring">chuổi cần chuyển</param>
        /// <returns></returns>
        public static decimal change_decimal(object pstring)
        {
            decimal v_num = 0;
            try
            {
                v_num = decimal.Parse(pstring + string.Empty);
            }
            catch (Exception ex)
            {
                if (ex != null) { }
            }
            return v_num;
        }

        /// <summary>
        ///  trả về số cho 1 chuỗi có kiểm tra chuỗi rỗng
        /// </summary>
        /// <param name="pstring"></param>
        /// <returns></returns>
        public static int change_int(object pstring)
        {
            int v_num = 0;
            try
            {
                Decimal d = 0;
                if (pstring.GetType() == d.GetType())
                {
                    v_num = Decimal.ToInt32((Decimal)pstring);
                }
                else
                {
                    v_num = int.Parse(pstring + string.Empty);
                }
            }
            catch (Exception ex)
            {
                if (ex != null) { }
            }
            return v_num;
        }
        public static Int64 change_int64(object pstring)
        {
            Int64 v_num = 0;
            try
            {
                Decimal d = 0;
                if (pstring.GetType() == d.GetType())
                {
                    v_num = Decimal.ToInt64((Decimal)pstring);
                }
                else
                {
                    v_num = Int64.Parse(pstring + string.Empty);
                }
            }
            catch (Exception ex)
            {
                if (ex != null) { }
            }
            return v_num;
        }

        /// <summary>
        /// Thủ tục trả về bool cho 1 chuỗi có kiểm tra chuỗi rỗng
        /// </summary>
        /// <param name="pstring"></param>
        /// <returns></returns>
        public static bool change_bool(object pstring)
        {
            bool v_bool = false;
            try
            {
                v_bool = bool.Parse(pstring + string.Empty);
            }
            catch { }
            return v_bool;
        }
    }
}
