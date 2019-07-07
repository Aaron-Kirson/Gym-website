using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCIS
{
    public partial class AdminEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool sendEmailViaWebApi()
        {

            string email = emailTxt.Text;
            string body = bodyTxt.Text;
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("aaronkirson@googlemail.com");
                mail.Subject = subText.Text;

                mail.Body = body;

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "Smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential
                     ("aaronkirson@googlemail.com", "6sunshine123"); // ***use valid credentials***
                smtp.Port = 587;

                //Or your Smtp Email ID and Password
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in sendEmail:" + ex.Message);
                return false;
            }
        }

        protected void sendBtn_Click(object sender, EventArgs e)
        {
           bool itSend = sendEmailViaWebApi();
            if (itSend == true)
            {
                errorlbl.Text = "Email sent to" + " " + emailTxt.Text;
            }
            else
            {
                errorlbl.Text = "Email failed to send due server error please try again later";
            }
        }
    }
}