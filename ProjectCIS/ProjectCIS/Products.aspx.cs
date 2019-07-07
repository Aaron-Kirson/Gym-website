using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectCIS.Models;


namespace ProjectCIS
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            
            FillPage();
            if (Request.Cookies["username"] == null)
            {
                commentlbl.Visible = false;
                reviewBtn.Visible = false;
                ratingList.Visible = false;
                comTxtbx.Visible = false;
                infolbl.Visible = false;
                ratinglbl.Visible = false;
            }


            
          
        }
        //code was adpated from tutorial https://www.youtube.com/watch?v=67fW_kNLghc  
        private void FillPage()
        {
            //Get selected product data
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                product product = product.GetProductByID(id);

                List<commentCommunicate> c = commentCommunicate.ReviewShake(product.Id);
                double? GetAverage = comment.GetAverageComment(product.Id);



                //Fill page with data
                lblTitle.Text = product.name;
                lblDescription.Text = product.description;
                lblPrice.Text = "Price per unit:<br/>£ " + product.price;
                imgProduct.ImageUrl = "~/Images/" + product.image;
                lblItemNr.Text = product.Id.ToString();
                stockLbl.Text = product.stock.ToString();
                if (GetAverage.Value == 0)
                {
                    Image1.ImageUrl = "/Images/zerostar.png";
                }

               else if (GetAverage.Value == 1)
                {
                    Image1.ImageUrl = "/Images/oneStar.png";
                }
                else if(GetAverage.Value == 2)
                {
                    Image1.ImageUrl = "/Images/twostar.png";
                }
                else if (GetAverage.Value == 3)
                {
                    Image1.ImageUrl = "/Images/threestar.png";
                }
                else if (GetAverage.Value == 4)
                {
                    Image1.ImageUrl = "/Images/fourstar.png";
                }
                else if (GetAverage.Value == 5)
                {
                    Image1.ImageUrl = "/Images/fivestar.png";
                }
                else
                {
                    Image1.ImageUrl = "/Images/zerostar.png";
                }



                //Fill amount list with numbers 1-20
                int[] amount = Enumerable.Range(1, 20).ToArray();
                ddlAmount.DataSource = amount;
                ddlAmount.AppendDataBoundItems = true;
                ddlAmount.DataBind();

                if (c.Count != 0)
                {
                   

                    reviewGrid.DataSource = c;
                    reviewGrid.DataBind();
                    

                }
                else
                {
                    reviewError.Text = "no comments have been left on this product please be the first to review this product";
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //adds the product to the cart if user is logged in
            if (Request.Cookies["username"] != null )
            {

                if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
                {
                    customer customers = customer.GetId(Request.Cookies["username"].Value);
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    int amount = Convert.ToInt32(ddlAmount.SelectedValue);
                    DateTime purchased = DateTime.Now;
                    bool incart = true;
                    int productId = id;
                    int discountVal = 0;
                    product product = product.GetProductByID(id);
                    if (product.stock <= 0)
                    {
                        lblResult.Text = "There is currently no items left in stock, sorry";
                    }
                    else
                    {

                        bool c = Cart.addCart(amount, customers.Id, productId, incart, purchased.ToString(), discountVal);

                        if (c == true)
                        {
                            lblResult.Text = "You item has been added to your basket";


                        }
                        else
                        {
                            lblResult.Text = "your item has not been added due to an error in our server please try again";
                        }
                    }
                }
            }

            else
            {
               //allows pop up to appear allowing user to go to register page and pay for item
                ClientScriptManager CSM = Page.ClientScript;       
                    string strRegister = "<script>if(window.confirm('Please register to website to purchase item, first time registers get £5 off first order')){window.location.href='Register.aspx'}</script>";
                    CSM.RegisterClientScriptBlock(this.GetType(), "Confirm", strRegister, false);
                
            }
        }

        protected void reviewBtn_Click(object sender, EventArgs e)
        {
            if (comTxtbx.Text == "")
            {
                errorLbl.Text = "Please add feedback to submit your review";
            }
            else
            {
                //gets product Id to review that item
                int id = Convert.ToInt32(Request.QueryString["id"]);
                product product = product.GetProductByID(id);
                customer customerid = customer.GetId(Request.Cookies["username"].Value);

                bool d = comment.insertReview(comTxtbx.Text, Convert.ToInt32(ratingList.Text), Request.Cookies["username"].Value, product.Id);

                if (d == true)
                {
                    errorLbl.Text = "Thank you for reviewing this product";


                }
                else
                {
                    errorLbl.Text = "Your review was not submitted due to a system error please try again later";
                }
            }
        }

       
        //makes the review tables spaced out and equal
        protected void reviewGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell myCell in e.Row.Cells)
            {
                myCell.Style.Add("word-break", "break-all");
                myCell.Width = 300;


            }

            //allows stars instead of numbers in the gridview

            Image img = new Image();

            if (e.Row.Cells[2].Text == "1")   
            {

                e.Row.Cells[2].Text = "<img src='Images/oneStar.png' border='0' alt='1 Star'width= '40%' />";

            }

            else if (e.Row.Cells[2].Text == "2")  
            {

                e.Row.Cells[2].Text = "<img src='Images/twostar.png' border='0' alt='2 Star' width= '40%'/>";

            }
            else if (e.Row.Cells[2].Text == "3")   
            {

                e.Row.Cells[2].Text = "<img src='Images/threestar.png' border='0' alt='3 Star' width= '40%' />";

            }

            else if (e.Row.Cells[2].Text == "4")   
            {

                e.Row.Cells[2].Text = "<img src='Images/fourstar.png' border='0' alt='4 Star' width= '40%' />";

            }
            else if (e.Row.Cells[2].Text == "5")   
            {

                e.Row.Cells[2].Text = "<img src='Images/fivestar.png' border='0' alt='5 Star' width= '40%' />";

            }



        }
    }
}