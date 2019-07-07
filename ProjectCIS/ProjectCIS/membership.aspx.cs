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
    public partial class membership : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorLbl.Text = " ";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            customer Cmember = customer.GetId(Request.Cookies["username"].Value);
            //if the first dropdownlist is chosen this function will perform sending this information to the databse
            if (GymList.SelectedIndex == 0)
            {
                bool c = member.membershipPass("Daypass", Convert.ToInt32(GymList.SelectedValue), (startCal.SelectedDate).ToString(), (startCal.SelectedDate.AddDays(1)).ToString(), true, Cmember.Id);

                if (c == true)
                {
                    errorLbl.Text = "payment has been completed thanks for joining the gym your gym membership will expire on " + startCal.SelectedDate.AddDays(1);


                }
                //if an error occured the user already has a active membership so no payment was taken
                else if (c == false)
                {
                    errorLbl.Text = "membership is currently active on account, no payment was taken";
                }
            }
            //this is if any of the other monnthly memberships are chosen
            else if (GymList.SelectedIndex >= 1)
            {
                bool d = member.membershipPass("monthly", Convert.ToInt32(GymList.SelectedValue), (startCal.SelectedDate).ToString(), (startCal.SelectedDate.AddMonths(1)).ToString(), true, Cmember.Id);
                if (d == true)
                {
                    //sends an email if the membership is complete
                    sendEmailViaWebApi();
                    errorLbl.Text = "payment has been completed thanks for joining the gym your gym membership will expire on " + startCal.SelectedDate.AddMonths(1);
                }
                else
                {
                    errorLbl.Text = "membership is currently active on account";
                }
                }

            else
            {
                errorLbl.Text = "error on system please try again at a later date";
                    
            }
        }
        private bool sendEmailViaWebApi()
        {
            customer customerId = customer.GetId(Request.Cookies["username"].Value);
            string email = customerId.email;
            string body = "Thank you for joining our gym your membership expires on" + " " + startCal.SelectedDate.AddMonths(1) + " " + "if you choose to cancel before then";
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("fasttrack.gym@gmail.com");
                mail.Subject = "e-receipt FastTrack" + " " + DateTime.Now;

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
        protected void GymList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}