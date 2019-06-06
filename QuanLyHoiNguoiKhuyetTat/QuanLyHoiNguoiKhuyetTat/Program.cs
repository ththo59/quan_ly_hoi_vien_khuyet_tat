using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DauThau.Forms;
using DauThau.Class;

namespace DauThau
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                DevExpress.Skins.SkinManager.EnableFormSkins();
                DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
                DevExpress.UserSkins.BonusSkins.Register();
                //UserLookAndFeel.Default.SetSkinStyle("Summer 2008");
                //UserLookAndFeel.Default.SetSkinStyle("Xmas");
                //Application.Run(new frmCreateKey());
                Application.Run(new frmLogin());
                    //Application.Run(new frmMain());
            }
            catch (Exception ex)
            {
                clsMessage.MessageExclamation("Có lỗi phát sinh:\n" + ex.Message);
            }
        }
    }
}
