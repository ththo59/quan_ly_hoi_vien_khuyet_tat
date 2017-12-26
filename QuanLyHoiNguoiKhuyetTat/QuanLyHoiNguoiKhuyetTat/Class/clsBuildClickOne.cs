using DauThau.Forms;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;

namespace DauThau.Class
{
    public static class clsBuildClickOne
    {
        public static string getVersion()
        {
            string strVersion = string.Empty;
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                strVersion = "Phiên bản: " + ApplicationDeployment.CurrentDeployment.CurrentVersion + "   ";
                // Kiểm tra phiên bản, nếu phiên bản cũ hơn thì tự update
                ApplicationDeployment updateCheck = ApplicationDeployment.CurrentDeployment;
                UpdateCheckInfo updateInfo = updateCheck.CheckForDetailedUpdate();
                if (updateInfo.UpdateAvailable)
                {
                    var frmUpdate = new frmUpdateVersion();
                    frmUpdate.ApplicationDeployment = updateCheck;
                    frmUpdate.UpdateCheckInfo = updateInfo;
                    frmUpdate.Init();
                    frmUpdate.ShowDialog();
                    System.Windows.Forms.Application.Restart();
                }
            }
            return strVersion;
        }
    }
}
