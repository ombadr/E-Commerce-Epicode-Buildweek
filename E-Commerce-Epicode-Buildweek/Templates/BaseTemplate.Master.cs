using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Epicode_Buildweek
{
    public partial class Template : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {

                    loginLink.Visible = false;
                    logoutLink.Visible = true;
                } else
                {
                    loginLink.Visible = true;
                    logoutLink.Visible = false;
                }
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Clear(); // Clears all session data
            Session.Abandon(); // Abandons the session
            Response.Redirect("Login.aspx"); // Redirects user to the login page
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

    }
}