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
    public class Articolo
    {
        public int Id { get; set; }
        public string Descrizione { get; set; }
        public string Dettagli { get; set; }
        public decimal Prezzo { get; set; }
        public string Nome { get; set; }
        public string Immagine { get; set; }


        public Articolo(int id, string nome, string descrizione, string dettagli, decimal prezzo, string immagine)
        {
            Id = id;
            Descrizione = descrizione;
            Dettagli = dettagli;
            Prezzo = prezzo;
            Nome = nome;
            Immagine = immagine;
        }
    }


    public partial class Amministrazione : System.Web.UI.Page
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["ConnessioneDBLocale"].ToString();
        SqlConnection conn = new SqlConnection(connectionString);
        public static List<Articolo> allValues = new List<Articolo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["IsAdmin"] == null || !(bool)Session["IsAdmin"])
                {
                    Response.Redirect("HomePage.aspx");
                }

                allValues.Clear();
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Prodotti", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Articolo articolo = new Articolo(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDecimal(4), reader.GetString(5));
                    allValues.Add(articolo);
                }
            }

            RepeaterBackoffice.DataSource = allValues;
            RepeaterBackoffice.DataBind();

            conn.Close();
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idProdotto = Convert.ToInt32(btn.CommandArgument);
            Response.Write(idProdotto.ToString());
            conn.Open();
            SqlCommand sql = new SqlCommand($"DELETE FROM Prodotti WHERE IdProdotto = {idProdotto}", conn);
            sql.ExecuteNonQuery();
            Response.Redirect(Request.Url.AbsoluteUri);
            conn.Close();
        }

        protected void Mod_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idProdotto = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect($"/BackOfficeDetails.aspx?id={idProdotto}");
        }
    }
}