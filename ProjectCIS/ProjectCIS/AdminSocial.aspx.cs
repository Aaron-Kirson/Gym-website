using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectCIS.Models;
using TweetSharp;

namespace ProjectCIS
{
    public partial class AdminSocial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tweetBtn_Click(object sender, EventArgs e)
        {
            //sends an error if one of the fields have not been filled.
            if (uploadimage.FileName == "" && tweetTxt.Text == "")
            {
                errorlbl.Text = "Please fill in one of the fields to send a tweet";
            }
            else
            {


                //code adpted from :http://www.dotnetfunda.com/articles/show/3196/post-message-with-image-on-twitter-using-csharp
                string key = "FYWmYCylYhJeuqdlqi0eG3QXL";
                string secret = "A1XCruZiHPfQaLVnH47lZVjruVc21RhKy1SOyQcesJN0CHH5CE";
                string token = "984811587025457152-n3qeKWXEYmIuuPprZUnPLJyZtux8mlF";
                string tokenSecret = "ma0wQuhTkBy3m353YztfnwpLMp7UfSm97WvJq62DftPxZ";

                string message = tweetTxt.Text.Trim();
                // check if file is there, upload it 
                string imagePath = string.Empty;
                if (uploadimage.HasFile)
                {
                    string fileName = System.IO.Path.GetFileName(uploadimage.FileName);
                    imagePath = Server.MapPath("~/Images/" + fileName);
                    uploadimage.SaveAs(imagePath);
                }

                var service = new TweetSharp.TwitterService(key, secret);
                service.AuthenticateWith(token, tokenSecret);

                // Tweet wtih image if it is attached
                if (imagePath.Length > 0)
                {
                    using (var stream = new FileStream(imagePath, FileMode.Open))
                    {
                        var result = service.SendTweetWithMedia(new SendTweetWithMediaOptions
                        {
                            Status = message,
                            Images = new Dictionary<string, Stream> { { "picture", stream } }
                        });

                    }
                    errorlbl.Text = "Your message has been sent";
                }
                else // just message
                {
                    var result = service.SendTweet(new SendTweetOptions
                    {
                        Status = message
                    });
                    errorlbl.Text = "Your message has been sent";
                }
            }
        }
    }
}
    
