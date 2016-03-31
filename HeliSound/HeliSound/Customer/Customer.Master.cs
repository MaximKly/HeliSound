using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeliSound.Customer
{
    public partial class Customer : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();

        }

        protected void lnkHome_Click(object sender, EventArgs e)
        {
            string sess = Request.QueryString["Sess"].ToString();
            string path = "../Customer/Index.aspx?Sess=";
            path = path + sess;
            Response.Redirect(path, false);
        }

        protected void lnkProfile_Click(object sender, EventArgs e)
        {
            string sess = Request.QueryString["Sess"].ToString();
            string path = "../Account/Profile.aspx?Sess=";
            path = path + sess;
            Response.Redirect(path, false);
        }

        protected void lnkSearch_Click(object sender, EventArgs e)
        {
            string sess = Request.QueryString["Sess"].ToString();
            string path = "../Customer/Search.aspx?Sess=";
            path = path + sess;
            Response.Redirect(path, false);
        }

        protected void lnkSelected_Click(object sender, EventArgs e)
        {
            string sess = Request.QueryString["Sess"].ToString();
            string path = "../Customer/MyCart.aspx?Sess=";
            path = path + sess;
            Response.Redirect(path, false);
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            string sess = Request.QueryString["Sess"].ToString();
            Datalayer DL = new Datalayer();
            if (DL.Logout(sess))
            {

                Response.Redirect("../Default.aspx", false);
            }
            {
                //Contact sysadmin
            }
        }
    }
}