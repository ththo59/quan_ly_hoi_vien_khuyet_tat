using System;
using System.ComponentModel;
using System.Deployment.Application;
using System.Windows.Forms;
using DauThau.Class;

namespace DauThau.Forms
{
    public partial class frmUpdateVersion : DevExpress.XtraEditors.XtraForm
    {
        /* -------------------------------- Enums ------------------------------------ */
        #region "Enums"

        #endregion
        /* --------------------------------------------------------------------------- */

        /* --------------------------------- Events ---------------------------------- */
        #region "Events"

        #endregion
        /* --------------------------------------------------------------------------- */

        /* ------------------------------- Variables --------------------------------- */
        #region "Variables"
        private bool _shouldUpdate = false;
        #endregion
        /* --------------------------------------------------------------------------- */

        /* ------------------------------ Properties --------------------------------- */
        #region "Properties"
        public ApplicationDeployment ApplicationDeployment { get; set; }
        public UpdateCheckInfo UpdateCheckInfo { get; set; }
        public bool ShouldUpdate
        {
            get
            {
                return _shouldUpdate;
            }
            set
            {
                _shouldUpdate = value;
                if (_shouldUpdate)
                {
                    this.ApplicationDeployment.UpdateAsync();
                }
            }
        }
        #endregion
        /* --------------------------------------------------------------------------- */

        /* -------------------------------- Methods ---------------------------------- */
        #region "Methods"
        public frmUpdateVersion()
        {
            InitializeComponent();
        }

        public void Init()
        {
            //this.ApplicationDeployment = ApplicationDeployment.CurrentDeployment;
            this.ApplicationDeployment.UpdateProgressChanged += new DeploymentProgressChangedEventHandler(ApplicationDeployment_UpdateProgressChanged);
            this.ApplicationDeployment.UpdateCompleted += new AsyncCompletedEventHandler(ApplicationDeployment_UpdateCompleted);
            this.lblVersionInfo.Text = String.Format("Nâng cấp lên phiên bản: {0}",
                this.UpdateCheckInfo.AvailableVersion.ToString());
            this.pgbUpdate.EditValue = 0;
        }
        #endregion
        /* --------------------------------------------------------------------------- */

        /* --------------------------- Event handlers--------------------------------- */
        #region "Event handlers"
        private void frmUpdateVersion_Load(object sender, EventArgs e)
        {
            this.ApplicationDeployment.UpdateAsync();
        }

        private void ApplicationDeployment_UpdateProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
        {
            if (pgbUpdate.InvokeRequired)
            {
                pgbUpdate.Invoke(new Action(() =>
                {
                    pgbUpdate.EditValue = e.ProgressPercentage;
                }));
                return;
            }

            pgbUpdate.EditValue = e.ProgressPercentage;
        }

        private void ApplicationDeployment_UpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                clsMessage.MessageExclamation("Có lỗi xảy ra trong quá trình nâng cấp. Chương trình sẽ khởi động lại.");
                return;
            }

            clsMessage.MessageInfo("Nâng cấp phiên bản thành công. Chương trình sẽ khởi động lại.");
            //this.Close();
            Application.Restart();
        }

        private void frmUpdateVersion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                e.Handled = true;
            }
        }

        private void frmUpdateVersion_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    e.Cancel = true;
            //}
        }
        #endregion
        /* --------------------------------------------------------------------------- */


    }
}