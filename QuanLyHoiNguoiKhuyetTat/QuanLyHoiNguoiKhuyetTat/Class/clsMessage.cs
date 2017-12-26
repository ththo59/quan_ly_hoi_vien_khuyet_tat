using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace DauThau.Class
{
    class clsMessage
    {
        public static void MessageInfo(string str)
        {
            XtraMessageBox.Show(str, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void MessageWarning(string str)
        {
            XtraMessageBox.Show(str, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void MessageExclamation(string str)
        {
            XtraMessageBox.Show(str, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static DialogResult MessageYesNo(string str)
        {
            return XtraMessageBox.Show(str, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static void MessageError(string str)
        {
            XtraMessageBox.Show(str, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
