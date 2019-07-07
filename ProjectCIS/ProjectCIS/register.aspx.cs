using System;
using ProjectCIS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace ProjectCIS
{
    public partial class register : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        //creates discount for user once they register
       public int makeDiscount()
        {
            Random rnd = new Random();
            int discountNum = rnd.Next(100, 999);
           discount.addDiscount(5, discountNum.ToString(), true);
            return discountNum;
        }
        //sends email once they register
        private void sendEmailViaWebApi()
        {

            string email = emailTbx.Text;
            string body = "Thank you for registering to our website! have a £5 discount on any purchases made in store" + " " + "This is your dicount code please keep it safe as you can only use it once: "+ makeDiscount() ;
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("fasttrack.gym@gmail.com");
                mail.Subject = "Thanks for registering";

                mail.Body = body;

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "Smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential
                     ("fasttrack.gym@gmail.com", "6doneky123"); // ***use valid credentials***
                smtp.Port = 587;

                //Or your Smtp Email ID and Password
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in sendEmail:" + ex.Message);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if postcode is blank error will appear
            if (postTxt.Text == "")
            {
                errorLbl.Text = "Please fill in post code";
            }
            else
            {
                //if post code is not blank all the details will be sent to the database
                bool c = customer.register(addressTxt.Text, fnametbx.Text, surnametbx.Text, emailTbx.Text, usernametbx.Text, passwordtbx.Text,
                    NTxtbx.Text, cardTxtbx.Text, Convert.ToInt32(eMonthTbx.SelectedValue), Convert.ToInt32(eYearTbx.Text), 
                    LevelDrop.SelectedValue, goalDrop.SelectedValue, TrainingDrop.SelectedValue, postTxt.Text, GenderDrop.SelectedValue);

                if (c == true)
                {
                    //if it went to database this message will appear and direct the user to the login page 
                    errorLbl.Text = "Register completed! going to login page";

                    sendEmailViaWebApi();

                    Response.AddHeader("REFRESH", "5;URL= login.aspx");

                }

                else
                {
                    //if there is an error this is because the username has already been taken
                    errorLbl.Text = "Username is already taken, please try another one! ";
                }
            }

        }

        
    }
}