using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectCIS.Models;

namespace ProjectCIS
{
    public partial class adminDiscount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
         bool created =  discount.addDiscount(Convert.ToInt32( amountTxt.Text), codeTxt.Text, true);

            if (created == true)
            {
                errorlbl.Text = "Discount created";
            }
            else
            {
                errorlbl.Text = "error creating discount please try again later";
            }
        }
    }
}