using ProjectCIS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCIS
{
    public partial class SiteMaster : MasterPage
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["username"] == null && Request.Cookies["admin"] == null)
            {
                signout.Visible = false;
                basketId.Visible = false;
            }

            if (Request.Cookies["admin"] == null)
            {
                admin.Visible = false;

            }

            if (Request.Cookies["username"] == null)
            {
                account.Visible = false;
            }


         
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Process.Start("https://twitter.com/FastTrackGymz");
        }
    }
}