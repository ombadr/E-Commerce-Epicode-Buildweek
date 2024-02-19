using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Epicode_Buildweek
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                EseguiLogin();
            }
        }

        protected void EseguiLogin()
        {
            string email = Request.Form["indirizzoEmail"];
            string password = Request.Form["passwordUtente"];

            string connectionString = ConfigurationManager.ConnectionStrings["ConnessioneDBLocale"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Password FROM Utenti WHERE Email=@Email";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            string passwordHash = reader["Password"].ToString();
                            if(BCrypt.Net.BCrypt.Verify(password, passwordHash))
                            {
                                Response.Redirect("HomePage.aspx");
                            } else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "loginError", "alert('Email o password errata.')", true);

                            }
                        } else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "loginError", "alert('Email o password errata.')", true);

                        }
                    }
                }
            }
        }
    }
}