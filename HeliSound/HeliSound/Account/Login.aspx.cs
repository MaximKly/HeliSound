using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeliSound.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lbluser = (Label)Master.FindControl("lblUser");
            lbluser.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Datalayer DL = new Datalayer();

            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();
            string returnedUSERID = string.Empty;
            string role = string.Empty;
            string sess = Session.SessionID;
            string path = string.Empty;
            DataSet ds = new DataSet();

            returnedUSERID = DL.Verify_Login_User(login, password);
            if (returnedUSERID != string.Empty)
            {
                // create User Session
                if (DL.Create_User_Session(Convert.ToInt32(returnedUSERID),sess))
                {
                    role = DL.Determine_Role((Convert.ToInt32(returnedUSERID)));
                    if (role == "1")
                    {
                        path = "../Customer/Index.aspx?Sess=";
                        path = path + sess;
                        Response.Redirect(path, false);
                    }
                    else if (role == "2")
                    {
                        path = "../Admin/Default.aspx?Sess=";
                        path = path + sess;
                        Response.Redirect(path, false);
                    }
                    else
                    {
                        Response.Redirect("../Account/login.aspx", false);
                    }
                }
                else
                {
                    lblError.Text = "Cant login";
                    lblError.Visible = true;
                    //Response.Redirect("../Account/login.aspx", false);
                }

            }
        }


    }
}