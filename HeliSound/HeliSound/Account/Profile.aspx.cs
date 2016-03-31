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
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sess = Request.QueryString["Sess"].ToString();
                Determine_Sess(sess);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string fname = txtFirstName.Text.Trim();
            string lname = txtLastName.Text.Trim();
            string street = txtStreetAddress.Text.Trim();
            string apt = txtApt.Text.Trim();
            string city = txtCity.Text.Trim();
            string province = txtProvince.Text.Trim();
            string postalCode = txtPostalCode.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();
            string question = txtQuestion.Text.Trim();
            string answer = txtAnswer.Text.Trim();
                
            Datalayer DL = new Datalayer();
            
            if (btnSave.Text == "Update")
            {
                string sess = Request.QueryString["Sess"].ToString();
                string userID = DL.UserID_By_Session(sess);
                int id = Convert.ToInt32(userID);
                if (DL.User_Update(id, fname, lname, password, question, answer, email, street, apt, city, province, postalCode))
                {
                    lblError.Text = "Account updated";
                    lblError.Visible = true;
                }
                else
                {
                    lblError.Text = "Account cant be updated";
                    lblError.Visible = true;
                }
            }
            else if (btnSave.Text == "Save") 
            {
                if (DL.Users_Insert(fname, lname, password, question, answer, email, street, apt, city, province, postalCode))
                {
                    Response.Redirect("../Account/login.aspx", false);
                }
                else
                {
                    lblError.Text = "Account not created";
                    lblError.Visible = true;
                }
            }
            
           
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(this.Controls);
        }

        private void ClearTextBoxes(ControlCollection cc)
        {
            try
            {
                foreach (Control ctrl in cc)
                {
                    TextBox tb = ctrl as TextBox;
                    if (tb != null)
                        tb.Text = string.Empty;
                    else
                        ClearTextBoxes(ctrl.Controls);
                }
            }
            catch { }
        }

        public void Determine_Sess(string sess)
        {
            if (sess == "0")
            {
                // create new profile
                Label lbluser = (Label)Master.FindControl("lblUser");
                lbluser.Visible = false;
                btnSave.Text = "Save";

            }
            else
            {
                Datalayer DL = new Datalayer();
                DataSet ds = new DataSet();

                string userID = DL.UserID_By_Session(sess);
                string fname = string.Empty;
                string lname = string.Empty;
                string street = string.Empty;
                string apt = string.Empty;
                string city = string.Empty;
                string province = string.Empty;
                string postalCode = string.Empty;
                string email = string.Empty;
                string question = string.Empty;
                string answer = string.Empty;

                ds = DL.User_Load_Information(Convert.ToInt32(userID));
                if (ds != null)
                {
                    fname = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    lname = ds.Tables[0].Rows[0]["LastName"].ToString();
                    street = ds.Tables[0].Rows[0]["StreetAddress"].ToString();
                    apt = ds.Tables[0].Rows[0]["Apartment"].ToString();
                    city = ds.Tables[0].Rows[0]["City"].ToString();
                    province = ds.Tables[0].Rows[0]["Province"].ToString();
                    postalCode = ds.Tables[0].Rows[0]["PostalCode"].ToString();
                    email = ds.Tables[0].Rows[0]["Email"].ToString();
                    question = ds.Tables[0].Rows[0]["SecurityQuestion"].ToString();
                    answer = ds.Tables[0].Rows[0]["Answer"].ToString();
                    try
                    {
                        Label lbluser = (Label)Master.FindControl("lblUser");
                        lbluser.Text = fname + " " + lname;
                        txtFirstName.Text = fname;
                        txtLastName.Text = lname;
                        txtStreetAddress.Text = street;
                        txtApt.Text = apt;
                        txtCity.Text = city;
                        txtProvince.Text = province;
                        txtPostalCode.Text = postalCode;
                        txtEmail.Text = email;
                        txtQuestion.Text = question;
                        txtAnswer.Text = answer;
                    }
                    catch (Exception)
                    {

                    }
                }
                btnSave.Text = "Update";
            }
        }
    }
}