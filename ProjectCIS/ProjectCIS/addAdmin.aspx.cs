using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectCIS.Models;

namespace ProjectCIS
{
    public partial class addAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

      

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            if (usernameTxt.Text == "" || passwordTxt.Text == "")
            {
                errorlbl.Text = "Please fill in all fields";
            }
            else
            {
                bool c = admin.register(usernameTxt.Text, passwordTxt.Text);

                if (c == true)
                {
                    errorlbl.Text = "Register completed!";
                    

                }

                else
                {
                    errorlbl.Text = "Username is already taken, please try another one! ";
                }
            }
        }
    }
}