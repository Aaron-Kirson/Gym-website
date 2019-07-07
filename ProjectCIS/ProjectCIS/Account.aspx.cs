using ProjectCIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCIS
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["username"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }
        private bool sendEmailViaWebApi()
        {
            customer customerId = customer.GetId(Request.Cookies["username"].Value);
            string email = customerId.email;
            string body = "Your password has been changed, please notify us if you did not do this";
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("fasttrack.gym@gmail.com");
                mail.Subject = "Password change" + " " + DateTime.Now;

                mail.Body = body;

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "Smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential
                     ("fasttrack.gym@gmail.com", "6donkey123"); // ***use valid credentials***
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
        protected void ChangeBtn_Click(object sender, EventArgs e)
        {
            bool c = customer.forgot(Request.Cookies["username"].Value, changeTxtbx.Text);

            //change code to boolen to show if error happens in database
            if (c == true)
            {
                errorlbl.Text = "Password has been changed, Thank you";
                sendEmailViaWebApi();

            }
            else
            {
                errorlbl.Text = "An error has occured";
            }
        }
    }
}