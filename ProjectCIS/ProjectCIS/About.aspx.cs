using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectCIS.Models;
using System.Diagnostics;

namespace ProjectCIS
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["username"] == null )
            {
                FeedbackTxt.Visible = false;
                reviewdrop.Visible = false;
                ratingLbl.Visible = false;
                feedbackLbl.Visible = false;
                submitBtn.Visible = false;
                reviewLbl.Visible = false;
                advertisement.Visible = false;
                advertisement0.Visible = false;
                advertisement1.Visible = false;
                advertisement2.Visible = false;
                clickLbl.Visible = false;   
              

            }
            else 
            {
                ShowAD();
            }

          
        }


        public void ShowAD()
        {
            customer cMember = customer.GetId(Request.Cookies["username"].Value);
           

            if (cMember.goal == "Gain muscle")
            {
                goal ad = goal.getAd("Gain muscle");

                advertisement.ImageUrl = ad.ImageAD1;
                advertisement0.ImageUrl = ad.ImageAD2;
                advertisement1.ImageUrl = ad.ImageAD3;
                advertisement2.ImageUrl = ad.ImageAD4;
                //advertisement3.ImageUrl = "~/Images/wheyAd.png";

                // adText.Text = "Try it out and gain muscle today"; 

            }

            else if (cMember.goal == "Weight loss")
            {
                goal ad = goal.getAd("Weight loss");
                advertisement.ImageUrl = ad.ImageAD1;
                advertisement0.ImageUrl = ad.ImageAD2;
                advertisement1.ImageUrl = ad.ImageAD3;
                advertisement2.ImageUrl = ad.ImageAD4;
                // adText.Text = "Try it out and gain lose today";
            }

            else if (cMember.goal == "General fitness")
            {
                goal ad = goal.getAd("General fitness");
                advertisement.ImageUrl = ad.ImageAD1;
                advertisement0.ImageUrl = ad.ImageAD2;
                advertisement1.ImageUrl = ad.ImageAD3;
                advertisement2.ImageUrl = ad.ImageAD4;
            }

            else if (cMember.goal == "Tone")
            {
                goal ad = goal.getAd("Tone");
                advertisement.ImageUrl = ad.ImageAD1;
                advertisement0.ImageUrl = ad.ImageAD2;
                advertisement1.ImageUrl = ad.ImageAD3;
                advertisement2.ImageUrl = ad.ImageAD4;
            }

            else
            {
                advertisement.Visible = false;
                advertisement0.Visible = false;
                advertisement1.Visible = false;
                advertisement2.Visible = false;
                
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FeedbackTxt.Text == "")
            {
                errorlbl.Text = "Please enter feedback before you can submit your review!";
            }
            else
            {
                customer customerid = customer.GetId(Request.Cookies["username"].Value);

                if (customerid == null)
                {
                    errorlbl.Text = "Please sign in to add a comment";
                }
                else
                {

                    bool d = comment.InsertGymReview(Convert.ToInt32(reviewdrop.SelectedValue), FeedbackTxt.Text, customerid.Id);
                    if (d == true)
                    {
                        errorlbl.Text = "Thank you for your feedback!";

                    }
                    else
                    {
                        errorlbl.Text = "problem with server please try again later";
                    }
                }
            }

        }

       

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            foreach (TableCell myCell in e.Row.Cells)
            {
                myCell.Style.Add("word-break", "break-all");
                myCell.Width = 300;
            }

            Image img = new Image();

            if (e.Row.Cells[2].Text == "1")   // If status ID is 1
            {

                e.Row.Cells[2].Text = "<img src='Images/oneStar.png' border='0' alt='1 Star'width= '40%' />";

            }

           else  if (e.Row.Cells[2].Text == "2")   // If status ID is 1
            {

                e.Row.Cells[2].Text = "<img src='Images/twostar.png' border='0' alt='2 Star' width= '40%'/>";

            }
            else if (e.Row.Cells[2].Text == "3")   // If status ID is 1
            {

                e.Row.Cells[2].Text = "<img src='Images/threestar.png' border='0' alt='3 Star' width= '40%' />";

            }

            else if (e.Row.Cells[2].Text == "4")   // If status ID is 1
            {

                e.Row.Cells[2].Text = "<img src='Images/fourstar.png' border='0' alt='4 Star' width= '40%' />";

            }
            else if (e.Row.Cells[2].Text == "5")   // If status ID is 1
            {

                e.Row.Cells[2].Text = "<img src='Images/fivestar.png' border='0' alt='5 Star' width= '40%' />";

            }

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Process.Start("https://twitter.com/AaronKirson");
        }
    }
}