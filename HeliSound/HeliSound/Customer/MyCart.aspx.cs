using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeliSound.Customer
{
    public partial class MyCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Shippping_Address();
            }
            Cart_Load();
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

        public void Cart_Load()
        {
            Datalayer DL = new Datalayer();
            DataSet ds = new DataSet();
            string sess = Request.QueryString["Sess"].ToString();
            string userID = DL.UserID_By_Session(sess);
            ds = DL.Cart_Load_Information(Convert.ToInt32(userID));
            if (ds != null)
            {
                gvMyCart.DataSource = ds;
                gvMyCart.DataBind();
            }
        }

        protected void gvMyCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string cat = string.Empty;
            string category = string.Empty;
            string man = string.Empty;
            string manufacturer = string.Empty;

            if (e.Row.RowType == DataControlRowType.DataRow) // check to make sure it is not a header, but actually a data row
            {
                cat = e.Row.Cells[1].Text;
                man = e.Row.Cells[2].Text;
                category = Get_Category(Convert.ToInt32(cat));
                if (category != string.Empty)
                {
                    e.Row.Cells[1].Text = category;
                }
                manufacturer = Get_Man_Name(Convert.ToInt32(man));
                if (manufacturer != string.Empty)
                {
                    e.Row.Cells[2].Text = manufacturer;
                }
            }
        }

        public string Get_Man_Name(int id)
        {
            string man = string.Empty;
            Datalayer DL = new Datalayer();
            try
            {
                man = DL.Manufacturer_Load_by_ID(id);
                if (man != string.Empty)
                {
                    return man;
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

        protected void btnEmpty_Click(object sender, EventArgs e)
        {
            Datalayer DL = new Datalayer();
            string sess = Request.QueryString["Sess"].ToString();
            string userID = DL.UserID_By_Session(sess);

            if (DL.Clear_Cart(Convert.ToInt32(userID)))
            {
                lblClear.Text = "Cart is empty";
                gvMyCart.Visible = false; // postback no work :(
            }
            else
            {
                lblClear.Text = "Cart is full";
            }
        }

        protected void gvMyCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            Datalayer DL = new Datalayer();

            string productid = string.Empty;
            string sess = Request.QueryString["Sess"].ToString();
            string userID = DL.UserID_By_Session(sess);


            int uid = Convert.ToInt32(userID);
            int pid = 0;


            GridViewRow row = gvMyCart.SelectedRow;

            if (row.RowType == DataControlRowType.DataRow)
            {
                productid = row.Cells[0].Text;
                pid = Convert.ToInt32(productid);

                if (DL.Cart_Item_Delete(pid, uid))
                {
                    Cart_Load();
                }
                else
                {
                    lblClear.Text = "Cant Delete row";
                }
            }
        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            Datalayer DL = new Datalayer();
            DataSet ds = new DataSet();

            string sess = Request.QueryString["Sess"].ToString();
            string userID = DL.UserID_By_Session(sess);
            int uid = Convert.ToInt32(userID);
            string street = txtStreetAddress.Text;
            string apt = txtApt.Text;
            string city = txtCity.Text;
            string province = txtProvince.Text;
            string postalCode = txtPostalCode.Text;
            string productID = string.Empty;
            int pID = 0;
            string sprice = string.Empty;
            decimal price = 0M;

            if (DL.Order_Insert(uid, street, apt, city, province, postalCode))
            {
                for (int i = 0; i < gvMyCart.Rows.Count; i++)
                {
                    productID = gvMyCart.Rows[i].Cells[0].Text;
                    pID = Convert.ToInt32(productID);
                    sprice = gvMyCart.Rows[i].Cells[5].Text;
                    price = Convert.ToDecimal(sprice);
                    DL.Insert_OrderProduct(pID, price, uid);
                }
                string path = "../Customer/Receipt.aspx?Sess=";
                path = path + sess;
                Response.Redirect(path, false);
            }
             
            //ds = DL.User_Load_Information(uid);
            //if (ds != null) 
            //{
            //     street = ds.Tables[0].Rows[0]["StreetAddress"].ToString();
            //     apt = ds.Tables[0].Rows[0]["Apartment"].ToString();
            //     city = ds.Tables[0].Rows[0]["City"].ToString();
            //     province = ds.Tables[0].Rows[0]["Province"].ToString();
            //     postalCode = ds.Tables[0].Rows[0]["PostalCode"].ToString();                 
            //}
        }

        public void Shippping_Address()
        {
            Datalayer DL = new Datalayer();
            DataSet ds = new DataSet();

            string sess = Request.QueryString["Sess"].ToString();
            string userID = DL.UserID_By_Session(sess);
            string street = string.Empty;
            string apt = string.Empty;
            string city = string.Empty;
            string province = string.Empty;
            string postalCode = string.Empty;
            string email = string.Empty;

            ds = DL.User_Load_Information(Convert.ToInt32(userID));
            if (ds != null)
            {
                street = ds.Tables[0].Rows[0]["StreetAddress"].ToString();
                apt = ds.Tables[0].Rows[0]["Apartment"].ToString();
                city = ds.Tables[0].Rows[0]["City"].ToString();
                province = ds.Tables[0].Rows[0]["Province"].ToString();
                postalCode = ds.Tables[0].Rows[0]["PostalCode"].ToString();
                email = ds.Tables[0].Rows[0]["Email"].ToString();
                try
                {
                    txtStreetAddress.Text = street;
                    txtApt.Text = apt;
                    txtCity.Text = city;
                    txtProvince.Text = province;
                    txtPostalCode.Text = postalCode;
                    txtEmail.Text = email;
                }
                catch (Exception)
                {

                }
            }

        }
        //protected void gvMyCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    Datalayer DL = new Datalayer();

        //    string productid = string.Empty;
        //    string sess = Request.QueryString["Sess"].ToString();
        //    string userID = DL.UserID_By_Session(sess);


        //    int uid = Convert.ToInt32(userID);
        //    int pid = 0;


        //    GridViewRow row = gvMyCart.RowDeleting();

        //    if (row.RowType == DataControlRowType.DataRow)
        //    {
        //        productid = row.Cells[0].Text;
        //        pid = Convert.ToInt32(productid);

        //        if (DL.Cart_Item_Delete(pid, uid))
        //        {
        //            Cart_Load();
        //        }
        //        else
        //        {
        //            lblClear.Text = "Cant Delete row";
        //        }
        //    }
        //}
    }
}