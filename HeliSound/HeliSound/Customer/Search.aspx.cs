using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeliSound.Customer
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Category_Load(dlCategory);
            }

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
        public void Category_Load(DropDownList cat)
        {
            Datalayer DL = new Datalayer(); // create access to the data layer
            DataSet ds = new DataSet(); // the load manufacture from the Data Layer will return a dataset.
            //lblError.Visible = false;
            try
            {
                ds = DL.Category_Load(); // will call the manufactuers load method in the data layer
                if (ds != null) // check to make sure there is data returned from the data layer
                {
                    cat.DataSource = ds;    // assign the data set to the data source property of the drop down list               
                    cat.DataTextField = "Description"; // determine the field to display - has to be a column in the dataset
                    cat.DataValueField = "CategoryID"; // set the field value - has to be a column in the dataset
                    cat.DataBind(); // bind the dataset, text field and value field to the dropdownlist.
                }
                else
                {
                    //lblError.Text = "Could not load Manufactuers"; // if the data set is empty
                    //lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                //lblError.Text = "Failed to load Manufactuers"; // will only happen if there is an error acessing the datalayer
                //lblError.Visible = true;
            }
        }

        protected void dlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cat = dlCategory.SelectedValue.ToString(); // get the value the user selected from the manufactuers drop down list
            Datalayer DL = new Datalayer(); // get access to the data layer
            DataSet ds = new DataSet();
            int x = 0;
            //lblError.Visible = false;
            dlManufacturer.Items.Clear(); // clear all the values in the models drop down list
            dlManufacturer.Items.Add(new ListItem("Select", "-1")); // reload the select option
            lblResult.Visible = false;

            if (cat != "-1")
            {
                ds = DL.Manufacturers_Load_by_Category(Convert.ToInt32(cat));
                if (ds != null)
                {
                    
                    while (x < ds.Tables[0].Rows.Count)
                    {
                        dlManufacturer.Items.Add(new ListItem(ds.Tables[0].Rows[x]["Name"].ToString(), ds.Tables[0].Rows[x]["ManufacturerID"].ToString()));
                        x++;
                    }
                }
                else
                {
                    
                }
            }
            else
            {
                //invalid manufacturer
            }
        }

        protected void dlManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string category = dlCategory.SelectedValue.ToString();
            string manu = dlManufacturer.SelectedValue.ToString();
            Datalayer DL = new Datalayer(); // access to the data layer
            DataSet ds = new DataSet();
            if (manu != "-1" && category != "-1")// make sure both were selected
            {
                ds = DL.Products_Load_by_Manufacter_Category(Convert.ToInt32(manu), Convert.ToInt32(category));
                if (ds != null)
                {
                    gvProducts.DataSource = ds;
                    gvProducts.DataBind();
                }
                else
                {
                    //lblError.Text = "Could not load models";
                    //lblError.Visible = true;
                }
            }
            else
            {
                //lblError.Text = "Check Selection";
                //lblError.Visible = true;
            }

        }

        protected void gvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string manufact = string.Empty;
            string manufactName = string.Empty;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                manufact = e.Row.Cells[1].Text;
                manufactName = Get_Man_Name(Convert.ToInt32(manufact));
                if (manufactName != string.Empty)
                {
                    e.Row.Cells[1].Text = manufactName;
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

        protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Datalayer DL = new Datalayer();
            DataSet ds = new DataSet();

            string productID = string.Empty;
            string category = string.Empty;
            string manufacturer = string.Empty;
            string model = string.Empty;
            string size = string.Empty;
            string watts = string.Empty;
            string description = string.Empty;
            string price = string.Empty;

            GridViewRow row = gvProducts.SelectedRow;
            if (row.RowType == DataControlRowType.DataRow)
            {
               productID = row.Cells[0].Text;
               ds = DL.Products_Load_By_ID(Convert.ToInt32(productID));
               if (ds != null)
               {
                   category = ds.Tables[0].Rows[0]["CategoryID"].ToString();
                   category = DL.Category_Load_by_ID(Convert.ToInt32(category));
                   manufacturer = ds.Tables[0].Rows[0]["ManufacturerID"].ToString();
                   manufacturer = DL.Manufacturer_Load_by_ID(Convert.ToInt32(manufacturer));
                   model = ds.Tables[0].Rows[0]["Model"].ToString();
                   size = ds.Tables[0].Rows[0]["Size"].ToString();
                   watts = ds.Tables[0].Rows[0]["Wattage"].ToString();
                   description = ds.Tables[0].Rows[0]["Descrption"].ToString();
                   price = ds.Tables[0].Rows[0]["Price"].ToString();

                   txtCategory.Text = category;
                   txtManf.Text = manufacturer;
                   txtModel.Text = model;
                   txtDescrption.Text = description;
                   txtPrice.Text = price;
                   
                   if (size != string.Empty)
                   {
                       lblSize.Text = "Size";
                       txtSize.Text = size;
                   }
                   else if (size == string.Empty && watts != string.Empty)
                   {
                       lblSize.Text = "Wattage";
                       txtSize.Text = watts;
                   }
               }
            }
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            Datalayer DL = new Datalayer();
            string sess = Request.QueryString["Sess"].ToString();
            string userID = DL.UserID_By_Session(sess);
            string productID = gvProducts.SelectedRow.Cells[0].Text;

            int uid = Convert.ToInt32(userID);
            int pid = Convert.ToInt32(productID);
            if (DL.Cart_Insert(uid, pid))
            {
                lblResult.Text = "Product inserted in your cart";
                lblResult.Visible = true;
            }
            else
            {
                lblResult.Text = "Product not inserted in your cart";
                lblResult.Visible = true;
            }
        }
    }
}