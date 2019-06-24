using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DauThau.Class
{
    class clsMail
    {
        public void sendMail(string mailBodyhtml)
        {
            try
            {
                //Note: First go to https://myaccount.google.com/lesssecureapps and make Allow less secure apps true.

                //string mailBodyhtml =
                //"<p>some text here</p>";
                var msg = new MailMessage("ththo59@gmail.com", "thaole.nkt.ninhkieu@gmail.com", "Danh sách hội viên đủ 16 hoặc 60 tuổi", mailBodyhtml);
                //msg.To.Add("to2@gmail.com");
                msg.IsBodyHtml = true;
                var smtpClient = new SmtpClient("smtp.gmail.com", 587); //**if your from email address is "from@hotmail.com" then host should be "smtp.hotmail.com"**
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential("ththo59@gmail.com", "tuathuytholy");
                smtpClient.EnableSsl = true;
                smtpClient.Send(msg);
            }
            catch (Exception ex)
            {
                clsMessage.MessageExclamation("Gởi mail thất bại. Chi tiết lỗi:\n" + ex.Message);
            }
            
        }
    }
}
