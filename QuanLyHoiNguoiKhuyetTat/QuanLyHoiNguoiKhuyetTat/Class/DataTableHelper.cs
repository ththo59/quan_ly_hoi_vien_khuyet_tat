using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DauThau.Class
{
    class DataTableHelper
    {
        /// <summary>
        /// Lấy giá trị của cột dữ liệu name trong DataRow
        /// </summary>
        public static string convertRowDataToString(DataRow r, string name)
        {
            string result = string.Empty;
            if (r.Table.Columns.Contains(name))
            {
                result = r[name] + String.Empty;
            }
            return result;
        }
    }
}
