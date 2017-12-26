using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraTab;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.Utils;
using DauThau.UserControlCategory;

namespace DauThau.Class
{
    class clsAddTab
    {
        public static void AddTabControl(XtraTabControl tabParent, XtraUserControl ucName, string tabName, string tabCaption, frmMain frmMain = null)
        {
            if (frmMain != null)
            {
                //event close view by delegate
                ucBase uc = (ucBase)ucName;
                uc.closeTab = frmMain.closeTabCurrent;
            }
            //WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            //// Test TabContol exists 
            foreach (XtraTabPage _tab in tabParent.TabPages)
            {
                if (_tab.Name == tabName)
                {
                    tabParent.SelectedTabPage = _tab;
                    return;
                }

            }
            //if (clsParameter._goiThauID <= 0)
            //{
            //    _wait.Close();
            //    XtraMessageBox.Show("Vui lòng chọn gói thầu cần thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (tabParent.TabPages.Count > 0)
            //tabParent.TabPages.RemoveAt(0);
            
            XtraTabPage _tabNew = new XtraTabPage();

            _tabNew.Name = tabName;

            _tabNew.Text = tabCaption;


            _tabNew.Controls.Add(ucName);

            ucName.Dock = DockStyle.Fill;

            _tabNew.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _tabNew.Appearance.HeaderActive.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            tabParent.TabPages.Add(_tabNew);

            tabParent.SelectedTabPage = _tabNew;

            //_wait.Close();
        }
    }
}
