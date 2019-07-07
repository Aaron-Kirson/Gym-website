using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectCIS.Models;

namespace ProjectCIS
{
    public partial class addProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            bool c = product.addProduct(namelbl.Text, Convert.ToInt32 (pricelbl.Text), DescLbl.Text, PictureUpload.PostedFile.FileName);

            if (c == true)
            {
                errorlist.Text = "Item added succussfully";
            }

            else
            {
                errorlist.Text = "error has occured on server slide please try again later";
            }
        }
    }
}