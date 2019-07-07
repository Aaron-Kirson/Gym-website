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
    public partial class basket : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["username"] == null)
            {
                Response.Redirect("login.aspx");
            }
           

            customer customerId = customer.GetId(Request.Cookies["username"].Value);

            GetPurchasesInCart(customerId);

            
            
           
        }

        //code was adpated from tutorial https://www.youtube.com/watch?v=67fW_kNLghc 

        private void ddlAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get ID of product that has had its quantity dropdownlist changed.
            DropDownList selectedList = (DropDownList)sender;
            int cartId = Convert.ToInt32(selectedList.ID);
            int quantity = Convert.ToInt32(selectedList.SelectedValue);

            //Update purchase with new quantity and refresh page
           Cart.UpdateQuantity(cartId, quantity);
            if (quantity == 0)
            {
                bool d = Cart.DeleteCart(cartId);

                if (d == false)
                {
                    errorLbl.Text = "failed to delete item please try again later!";
                }
                else
                {
                    errorLbl.Text = "Item deleted";
                }
            }
            Response.Redirect("~/basket.aspx");

        }

        private void GetPurchasesInCart(customer customerId)
        {



            double subTotal = 0;
            //Get all purchases for current user and display in table
            List<Cart> purchaseList = Cart.getOrders(customerId.Id);
            if (purchaseList.Count == 0)
            {
                
                Response.Redirect("menu2.aspx");
            }
            CreateShopTable(purchaseList, out subTotal);

            //Add totals to page
          
         double totalAmount = subTotal;

           
            litTotalAmount.Text = "£ " + totalAmount;

            
        }

        private void CreateShopTable(IEnumerable<Cart> carts, out double subTotal)
        {
            subTotal = new double();


            foreach (Cart cart in carts)
            {
                //Create HTML elements and fill values with database data

                product product = product.GetProductByID(cart.productId);


                ImageButton btnImage = new ImageButton
                {
                    ImageUrl = string.Format("~/Images/{0}", product.image),
                    PostBackUrl = string.Format("~/Products.aspx?id={0}", product.Id)
                };

             

                //Fill amount list with numbers 0-20
                int[] amount = Enumerable.Range(0, 20).ToArray();
                DropDownList ddlAmount = new DropDownList
                {
                    DataSource = amount,
                    AppendDataBoundItems = true,
                    AutoPostBack = true,
                    ID = cart.id.ToString()
                };
                ddlAmount.DataBind();
                ddlAmount.SelectedValue = cart.amount.ToString();
                ddlAmount.SelectedIndexChanged += ddlAmount_SelectedIndexChanged;

                //Create table to hold basket details
                Table table = new Table { CssClass = "basket" };
                TableRow row1 = new TableRow();
                TableRow row2 = new TableRow();

                TableCell cell1_1 = new TableCell { RowSpan = 2, Width = 50 };
                TableCell cell1_2 = new TableCell
                {
                    Text = string.Format("<h4>{0}</h4><br />{1}<br/>In Stock",
                    product.name, "Item No:" + product.Id),
                    HorizontalAlign = HorizontalAlign.Left,
                    Width = 350,
                };
                TableCell cell1_3 = new TableCell { Text = "Unit Price<hr/>" };
                TableCell cell1_4 = new TableCell { Text = "Quantity<hr/>" };
                TableCell cell1_5 = new TableCell { Text = "Item Total<hr/>" };
                TableCell cell1_6 = new TableCell();

                TableCell cell2_1 = new TableCell();
                TableCell cell2_2 = new TableCell { Text = "£ " + product.price };
                TableCell cell2_3 = new TableCell();
                TableCell cell2_4 = new TableCell { Text = "£ " + Math.Max((cart.amount * product.price), 2) };
                TableCell cell2_5 = new TableCell();



                //Set custom controls
                cell1_1.Controls.Add(btnImage);
                cell2_3.Controls.Add(ddlAmount);

                //Add rows & cells to table
                row1.Cells.Add(cell1_1);
                row1.Cells.Add(cell1_2);
                row1.Cells.Add(cell1_3);
                row1.Cells.Add(cell1_4);
                row1.Cells.Add(cell1_5);
                row1.Cells.Add(cell1_6);

                row2.Cells.Add(cell2_1);
                row2.Cells.Add(cell2_2);
                row2.Cells.Add(cell2_3);
                row2.Cells.Add(cell2_4);
                row2.Cells.Add(cell2_5);
                table.Rows.Add(row1);
                table.Rows.Add(row2);
                pnlShoppingCart.Controls.Add(table);

                //Add total of current purchased item to subtotal
               subTotal +=  (cart.amount * product.price) - cart.discount;
                
            }

            //Add selected objects to Session
           Session[ Request.Cookies["username"].Value] = carts;
        }

        //method to send email to user
        private bool sendEmailViaWebApi()
        {
            customer customerId = customer.GetId(Request.Cookies["username"].Value);
             Cart GetReceipt = Cart.GetReceipt(customerId.Id);
            //this receipt only works with one item in basket 
            if (GetReceipt != null)
            {
                product getProduct = product.GetProductByID(GetReceipt.productId);

                string email = customerId.email;
                string body = "Thank you for purchasing at FastTrack please check out the store soon for exclusive deals!" + " " + "Your items bought: " + getProduct.name + " " + "Quantity: " + GetReceipt.amount + "Total:  £" + (getProduct.price * GetReceipt.amount);
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(email);
                    mail.From = new MailAddress("fasttrack.gym@gmail.com");
                    mail.Subject = "Purchase notification FastTrack" + " " + DateTime.Now;

                    mail.Body = body;

                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "Smtp.gmail.com"; //Or Your SMTP Server Address
                    smtp.Credentials = new System.Net.NetworkCredential
                         ("fasttrack.gym@gmail.com", "6donkey123"); // ***use valid credentials***
                    smtp.Port = 587;

                    //Or your Smtp Email ID and Password
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception in sendEmail:" + ex.Message);
                    return false;
                }

            }
            //if more than one item is in basket this email will send
            else
            {
                string email = customerId.email;
                string body = "Thank you for purchasing at FastTrack please check out the store soon for exclusive deals!";
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(email);
                    mail.From = new MailAddress("fasttrack.gym@gmail.com");
                    mail.Subject = "Purchase notification FastTrack" + " " + DateTime.Now;

                    mail.Body = body;

                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "Smtp.gmail.com"; //Or Your SMTP Server Address
                    smtp.Credentials = new System.Net.NetworkCredential
                         ("fasttrack.gym@gmail.com", "6donkey123"); // ***use valid credentials***
                    smtp.Port = 587;

                    //Or your Smtp Email ID and Password
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception in sendEmail:" + ex.Message);
                    return false;
                }
            }
            
          
        }
        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            if (CWTxtbx.Text == "")
            {
                errorLbl.Text = "Please enter your secruity code for the card you registered with to pay for items";
            }

            else
            {

                bool itSend = sendEmailViaWebApi();
                if (itSend == true)
                {
                    Response.Redirect("checkout");
                }
                else
                {
                    errorLbl.Text = "order failed due to server error please try again later";
                }
               
            }
        }

        protected void CWTxtbx_TextChanged(object sender, EventArgs e)
        {

        }

        protected void discountBtn_Click(object sender, EventArgs e)
        {
               
           discount cheap =  discount.applyDiscount(discountTxt.Text, true);

            if (cheap != null)
            {

                customer customerId = customer.GetId(Request.Cookies["username"].Value);
                bool applied =   Cart.addDiscount(cheap.amount, customerId.Id);
                discountError.Text = "Discount applied wait a few seconds for changes to appear";
                Response.AddHeader("REFRESH", "3;URL= basket.aspx");
            }
            else
            {
               discountError.Text = "Discount code invalid";
            }


        }
    }
}
