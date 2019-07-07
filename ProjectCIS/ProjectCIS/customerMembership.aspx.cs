using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectCIS.Models;

namespace ProjectCIS
{
    public partial class customerMembership : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            customer cMember = customer.GetId(Request.Cookies["username"].Value);
            
            List<member> bs = member.ShowMembership(cMember.Id);

            if (bs != null)
            {
                MembershipGrid.DataSource = bs;
                MembershipGrid.DataBind();
                errorlbl.Text = "You have an active membership with us please come down and train at our gym! We also have gym products to sell if you need that extra push!";
            }
            else
            {
                errorlbl.Text = "You have no actve membership, please click the join us link to join our gym!";
            }
        }
    }
}