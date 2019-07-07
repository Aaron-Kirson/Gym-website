using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectCIS.Models;
using System.Net.Mail;

namespace ProjectCIS
{
    public partial class checkOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


           List<Cart> carts = (List<Cart>)Session[Request.Cookies["username"].Value];

            foreach (Cart c in carts)
            {
                bool getStock = product.Getstock(c.productId, c.amount);
            }
            carts = Cart.MarkOrder(carts);         
          

        }
        
       

    }
}