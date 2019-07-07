using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectCIS.Models;

namespace ProjectCIS
{
    public partial class addMembership : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            bool c = member.addMembership(nameTxt.Text, Convert.ToInt32( pricetxt.Text));

            if (c == true)
            {
                errorlbl.Text = "Item added succussfully";
            }

            else
            {
                errorlbl.Text = "error has occured on server slide please try again later";
            }
        }
    }
}