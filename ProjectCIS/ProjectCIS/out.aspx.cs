using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCIS
{
    public partial class _out : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if user is  logged in they will be redirected back to the login removing their saved state
            if (Request.Cookies["username"] !=  null)
            {

                HttpCookie myCookie = new HttpCookie("username");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
                Response.Redirect("login.aspx");
            }
            //if they are an admin they will be redirected to the login page removing their saved state
            else if (Request.Cookies["admin"] != null)
            {
                HttpCookie myCookie2 = new HttpCookie("admin");
                myCookie2.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie2);
                Response.Redirect("login.aspx");

            }
            //if either is not found all they saved states will be removed anyway and redirected to login
            else
            {
                HttpCookie myCookie2 = new HttpCookie("admin");
                myCookie2.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie2);
                HttpCookie myCookie = new HttpCookie("username");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
                Response.Redirect("login.aspx");
            }


            
        }
    }
}