using DevExpress.Utils;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DauThau.Class
{
    class ExportHelper
    {
        public static WaitDialogForm _wait;
        public static void exportWord(Dictionary<string, string> dataPrint, string fileName)
        { 
            Microsoft.Office.Interop.Word.Application objWord = null;
            Microsoft.Office.Interop.Word.Document objDoc = null;
            object oBookMark = null;
            try
            {
                _wait = new WaitDialogForm("Đang xuất dữ liệu...", "Xin vui lòng chờ giây lát");
                object oMissing = System.Reflection.Missing.Value;
                object oFalse = false;

                //init
                object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
                object oTemplate = Application.StartupPath + "\\Template\\" + fileName;

                Object beforeRow = Type.Missing;
                objWord = new Microsoft.Office.Interop.Word.Application();
                objDoc = objWord.Documents.Add(ref oTemplate, ref oMissing, ref oMissing, ref oMissing);
                objWord.Visible = false;


                foreach (KeyValuePair<string, string> pair in dataPrint)
                {
                    objDoc.Bookmarks[pair.Key].Range.Text = pair.Value;
                }

                if (false)
                {
                    objWord.DisplayAlerts = Microsoft.Office.Interop.Word.WdAlertLevel.wdAlertsNone;
                    objWord.Options.PrintBackground = false;
                    PrintDialog printer = new PrintDialog();
                    if (!printer.PrinterSettings.IsValid)
                    {
                        if (printer.ShowDialog() == DialogResult.OK)
                        {
                            objWord.ActivePrinter = printer.PrinterSettings.PrinterName;
                            objWord.PrintOut();
                        }
                    }
                    else
                    {
                        objWord.PrintOut();
                    }
                    objWord.Quit(SaveChanges: false);
                }
                else
                {
                    objWord.Visible = true;
                }

                //objWord.Visible = true;
            }
            catch (Exception ex)
            {
                string exMsg = "Xuất Word không thành công!\n";
                XtraMessageBox.Show(exMsg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsMessage.MessageExclamation(exMsg + ex.Message);
            }
            finally
            {
                if (!_wait.IsDisposed)
                {
                    _wait.Close();
                }
                releaseObject(objDoc);
                releaseObject(objWord);
            }
        }

        public static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                System.Runtime.InteropServices.Marshal.CleanupUnusedObjectsInCurrentContext();
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }

        }
    }
}
