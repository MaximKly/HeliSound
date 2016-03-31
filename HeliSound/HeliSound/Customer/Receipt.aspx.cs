using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeliSound.Customer
{
    public partial class Receipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Print_Receipt();
            Datalayer DL = new Datalayer();
            DataSet ds = new DataSet();

            string sess = Request.QueryString["Sess"].ToString();
            string userID = DL.UserID_By_Session(sess);
            string fname = string.Empty;
            string lname = string.Empty;

            ds = DL.User_Load_Information(Convert.ToInt32(userID));
            if (ds != null)
            {
                fname = ds.Tables[0].Rows[0]["FirstName"].ToString();
                lname = ds.Tables[0].Rows[0]["LastName"].ToString();
                try
                {
                    Label lbluser = (Label)Master.FindControl("lblUser");
                    lbluser.Text = "Thank you for your purchase, " + fname + " " + lname;
                }
                catch (Exception)
                {

                }
            }
        }

        public void Print_Receipt()
        {
            Datalayer DL = new Datalayer();
            DataSet ds = new DataSet();
            string sess = Request.QueryString["Sess"].ToString();
            string userID = DL.UserID_By_Session(sess);
            ds = DL.Customer_Invoice(Convert.ToInt32(userID));
            string sprice = string.Empty;
            decimal tempprice = 0M;
            decimal price = 0M;
            if (ds != null)
            {
                gvReceipt.DataSource = ds;
                gvReceipt.DataBind();

                for (int i = 0; i < gvReceipt.Rows.Count; i++)
                {
                    sprice = gvReceipt.Rows[i].Cells[2].Text;
                    tempprice = Convert.ToDecimal(sprice);
                    price = price + tempprice;
                }
                txtOrderTotal.Text = price.ToString("c");
            }
        }

        protected void gvReceipt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string cat = string.Empty;
            string category = string.Empty;
            Datalayer DL = new Datalayer();

            if (e.Row.RowType == DataControlRowType.DataRow) // check to make sure it is not a header, but actually a data row
            {
                cat = e.Row.Cells[0].Text;
                category = Get_Category(Convert.ToInt32(cat));
                if (category != string.Empty)
                {
                    e.Row.Cells[0].Text = category;
                }
            }
        }
        public string Get_Category(int id)
        {
            string cat = string.Empty;
            Datalayer DL = new Datalayer();
            try
            {
                cat = DL.Category_Load_by_ID(id);
                if (cat != string.Empty)
                {
                    return cat;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return string.Empty;
            }
        }
    }
}