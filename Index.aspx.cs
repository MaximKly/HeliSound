using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticingDBconnect
{
    public partial class Index : System.Web.UI.Page
    {
        SqlDataAdapter dwas;
        SqlCommand cmd;
        DataSet ds;
        SqlConnection conn;
        string DBstring = ConfigurationManager.ConnectionStrings["PracticingConnectionString"].ConnectionString;
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(DBstring);

            try
            {
                conn.Open();
                cmd = new SqlCommand("INSERT into dbo.Users VALUES(@FirstName, @LastName, @Email)", conn);
                cmd.Parameters.AddWithValue("@FirstName", "Max");
                cmd.Parameters.AddWithValue("@LastName", "Shax");
                cmd.Parameters.AddWithValue("@Email", "maxim-k@rogers.com");
                cmd.ExecuteNonQuery();

            }
            catch{
                Button1.Text = "failed to connect";
            }
            finally
            {
                conn.Close();
            }
        }

        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(DBstring);
            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM dbo.Users", conn);
                dwas = new SqlDataAdapter(cmd);
                ds = new DataSet();              
                dwas.Fill(ds);
                if (ds != null)
                {
                    gvPractice.DataSource = ds;
                    gvPractice.DataBind();
                }
                
                
            }
            catch
            {
                Button1.Text = "failed to connect";
            }
            finally
            {
                conn.Close();
            }



        }
    }
}