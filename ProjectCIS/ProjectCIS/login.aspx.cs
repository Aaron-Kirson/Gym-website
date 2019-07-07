using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectCIS.Models;
using System.Web.Security;

namespace ProjectCIS
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            if (UserDropList.SelectedValue == "User")
            {
                customer c = customer.login(usernameTxt.Text, passwordtxt.Text);

                if (c != null)
                {
                  
                    Response.Cookies["username"].Value = usernameTxt.Text;
                    Response.Cookies["username"].Expires = DateTime.Now.AddDays(1);

                   
                    Response.Redirect("About.aspx");
                }
                else
                    errorlbl.Text = "username/password is incorrect please retry";
            }

            else if (UserDropList.SelectedValue == "Admin")
            {

                admin d = admin.login(usernameTxt.Text, passwordtxt.Text);

                if (d != null)
                {
                  
                    Response.Cookies["admin"].Value = usernameTxt.Text;
                    Response.Cookies["admin"].Expires = DateTime.Now.AddDays(1);
                    Response.Redirect("control");
                }
                else
                    errorlbl.Text = "username/password is incorrect please retry admin";
            }

        }




        protected void registerbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }
    }
}