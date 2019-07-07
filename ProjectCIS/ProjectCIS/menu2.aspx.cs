using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectCIS.Models;

namespace ProjectCIS
{
    public partial class menu2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fillProducts();
            
        }


        //code was adpated from tutorial https://www.youtube.com/watch?v=67fW_kNLghc 

        private void fillProducts()
        {
            //get products in DB
            List<product> products = product.Getproduct();
            if (products != null)
            {
                //for each item found creates an image and price to display for the user to press
                foreach (product product in products)
                {
                    Panel productPanel = new Panel();
                    ImageButton imageButton = new ImageButton
                    {
                        ImageUrl = "~/Images/" + product.image,
                        CssClass = "productImage",
                        PostBackUrl = string.Format("~/Products.aspx?id={0}", product.Id)
                    };
                    Label lblName = new Label
                    {
                        Text = product.name,
                        CssClass = "productName"
                    };
                    Label lblPrice = new Label
                    {
                        Text = "£ " + product.price,
                        CssClass = "productPrice"
                    };

                    productPanel.Controls.Add(imageButton);
                    productPanel.Controls.Add(new Literal { Text = "<br/>" });
                    productPanel.Controls.Add(lblName);
                    productPanel.Controls.Add(new Literal { Text = "<br/>" });
                    productPanel.Controls.Add(lblPrice);

                    //Add dynamic controls to static control
                    pnlShop.Controls.Add(productPanel);
                }
            }
            //if no items are found they will show a message stating no products were found 
            else
                pnlShop.Controls.Add(new Literal { Text = "No products found!" });
        }


       

        protected void AdvertisePIC_AdCreated(object sender, AdCreatedEventArgs e)
        {

        }
    }
}