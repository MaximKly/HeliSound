using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeliSound.Customer
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                    lbluser.Text = fname + " " + lname;
                }
                catch (Exception)
                {

                }
            }

            if (!DL.Verify_Logged_In_Role(1, sess))
            {
                Response.Redirect("../Default.aspx", false);
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            string sess = Request.QueryString["Sess"].ToString();
            Datalayer DL = new Datalayer();
            if (DL.Logout(sess))
            {

                Response.Redirect("/default.aspx", false);
            }
            {
                //Contact sysadmin
            }
        }
    }
}