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
    public partial class BackOfficeDetails : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        SqlConnection conn = new SqlConnection(connectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAdmin"] == null || !(bool)Session["IsAdmin"])
            {
                Response.Redirect("HomePage.aspx");
            }
            if (!IsPostBack)
            {

                string idValue = Request.QueryString["id"];
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Prodotto WHERE IdProdotto={idValue}", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    imgurl.Src = reader["Immagine"].ToString();
                    Urltxt.Text = reader["Immagine"].ToString();
                    Nametxt.Text = reader["Nome"].ToString();
                    Desctxt.Text = reader["Descrizione"].ToString();
                    Dettxt.Text = reader["Dettagli"].ToString();
                    Pricetxt.Text = reader["Prezzo"].ToString();
                    Mod.CommandArgument = reader["IdProdotto"].ToString();
                    DelBtn.CommandArgument = reader["IdProdotto"].ToString();
                }

                conn.Close();
            }
        }

        protected void Mod_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idProdotto = Convert.ToInt32(btn.CommandArgument);
            conn.Open();

            SqlCommand sql = new SqlCommand($"UPDATE Prodotto SET Descrizione='{Desctxt.Text}', Immagine='{Urltxt.Text}', Dettagli='{Dettxt.Text}', Prezzo={decimal.Parse(Pricetxt.Text)}, Nome='{Nametxt.Text}' WHERE IdProdotto = {idProdotto}", conn);
            sql.ExecuteNonQuery();
            Response.Redirect("Amministrazione.aspx");
            conn.Close();
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            int idProdotto = Convert.ToInt32(btn.CommandArgument);
            conn.Open();
            SqlCommand sql = new SqlCommand($"DELETE FROM Prodotto WHERE IdProdotto = {idProdotto}", conn);
            sql.ExecuteNonQuery();
            Response.Redirect("Amministrazione.aspx");
            conn.Close();

        }
    }
}