using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

namespace HeliSound
{
    public class Datalayer
    {
        SqlDataAdapter dwas;
        SqlCommand cmd;
        DataSet ds;
        SqlConnection conn;

        public Datalayer()
        {
            Initialize();
        }

        public void Initialize()
        {
            //connection string from web.config
            string DBstring = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
            //creates the connection
            conn = new SqlConnection(DBstring);
        }

        public bool Users_Insert(string fname, string lname, string password, string question, string answer,
            string email, string street, string apt, string city, string province, string postalCode)
        {
            string encrytpedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password.ToLower(), "SHA1");
            int recAffetct = 0;
            cmd = new SqlCommand("Users_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            // pass parameters
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@password", encrytpedPassword);
            cmd.Parameters.AddWithValue("@question", question);
            cmd.Parameters.AddWithValue("@answer", answer);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@street", street);
            cmd.Parameters.AddWithValue("@apt", apt);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@province", province);
            cmd.Parameters.AddWithValue("@postalcode", postalCode);

            try
            {
                conn.Open();
                cmd.Prepare();
                recAffetct = (int)cmd.ExecuteNonQuery();
                if (recAffetct > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception eX)
            {
                eX.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }

        }

        public bool User_Update(int userid, string fname, string lname, string password, string question, string answer,
            string email, string street, string apt, string city, string province, string postalCode)
        {
            string encrytpedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password.ToLower(), "SHA1");
            int recAffetct = 0;
            cmd = new SqlCommand("Users_Update", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@pswd", encrytpedPassword);
            cmd.Parameters.AddWithValue("@question", question);
            cmd.Parameters.AddWithValue("@answer", answer);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@street", street);
            cmd.Parameters.AddWithValue("@apt", apt);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@province", province);
            cmd.Parameters.AddWithValue("@postalCode", postalCode);


            try
            {
                conn.Open();
                cmd.Prepare();
                recAffetct = (int)cmd.ExecuteNonQuery();
                if (recAffetct == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception eX)
            {
                eX.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public string Verify_Login_User(string login, string password)
        {
            ds = new DataSet();
            string encrytpedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password.ToLower(), "SHA1");
            dwas = new SqlDataAdapter("Users_Verify_Login", conn);
            dwas.SelectCommand.CommandType = CommandType.StoredProcedure;
            dwas.SelectCommand.Parameters.AddWithValue("@email", login);
            dwas.SelectCommand.Parameters.AddWithValue("@pswd", encrytpedPassword);

            try
            {
                dwas.SelectCommand.Prepare();
                dwas.Fill(ds);
                // test to see if the data set is empty
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["UserID"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
            finally
            {
                conn.Close();
            }
        }

        public string Determine_Role(int id)
        {
            ds = new DataSet();
            dwas = new SqlDataAdapter("UserRole_By_ID", conn);
            dwas.SelectCommand.CommandType = CommandType.StoredProcedure;
            dwas.SelectCommand.Parameters.AddWithValue("@userid", id);

            try
            {
                dwas.SelectCommand.Prepare();
                dwas.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["RoleID"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }

            catch (Exception)
            {
                return string.Empty;
            }

            finally
            {
                conn.Close();
            }
        }

        public bool Create_User_Session(int userid, string session)
        {
            cmd = new SqlCommand("UserSession_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@sessionvar", session);
            try
            {
                conn.Open();
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool Verify_Logged_In_Role(int role, string session)
        {
            dwas = new SqlDataAdapter("UserSession_Role_Verify", conn);
            ds = new DataSet();
            dwas.SelectCommand.CommandType = CommandType.StoredProcedure;
            dwas.SelectCommand.Parameters.AddWithValue("@usersession", session);
            dwas.SelectCommand.Parameters.AddWithValue("@role", role);

            try
            {
                dwas.SelectCommand.Prepare();
                dwas.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool Logout(string sess)
        {
            cmd = new SqlCommand("UserSession_Logout", conn);
            DataSet ds = new DataSet();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sessvar", sess);

            try
            {
                conn.Open();
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

        }

        public string UserID_By_Session(string session)
        {
            ds = new DataSet();
            dwas = new SqlDataAdapter("UserID_By_Session", conn);
            dwas.SelectCommand.CommandType = CommandType.StoredProcedure;
            dwas.SelectCommand.Parameters.AddWithValue("@session", session);
            try
            {
                dwas.SelectCommand.Prepare();
                dwas.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["UserID"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
            finally
            {
                conn.Close();
            }
            //string userid = string.Empty;
            //cmd = new SqlCommand("UserID_By_Session", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@session", session);

            //try
            //{
            //    conn.Open();
            //    cmd.Prepare();
            //    userid = (string)cmd.ExecuteScalar();
            //    if (userid.Length > 0)
            //    {
            //        return userid;
            //    }
            //    else
            //    {
            //        return string.Empty;
            //    }
            //}
            //catch (Exception)
            //{
            //    return string.Empty;
            //}
            //finally
            //{
            //    conn.Close();
            //}
        }

        public DataSet User_Load_Information(int id)
        {
            dwas = new SqlDataAdapter("Users_Load_by_ID", conn);
            ds = new DataSet();
            dwas.SelectCommand.CommandType = CommandType.StoredProcedure;
            dwas.SelectCommand.Parameters.AddWithValue("@userid", id);
            try
            {
                dwas.SelectCommand.Prepare();
                dwas.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }

        }

        public DataSet Products_Load_by_Manufacturer(int manufacturer)
        {
            dwas = new SqlDataAdapter("Product_By_ManufacturerID", conn); // stored procedure created in database
            ds = new DataSet();
            dwas.SelectCommand.CommandType = CommandType.StoredProcedure;
            dwas.SelectCommand.Parameters.AddWithValue("@manid", manufacturer); // pass the parameter
            try
            {
                dwas.SelectCommand.Prepare();
                dwas.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataSet Category_Load()
        {
            dwas = new SqlDataAdapter("Category_Load", conn);
            ds = new DataSet();
            dwas.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dwas.SelectCommand.Prepare();
                dwas.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataSet Manufacturers_Load_by_Category(int category)
        {
            dwas = new SqlDataAdapter("Manufacturers_Load_By_Category", conn); // stored procedure created in database
            ds = new DataSet();
            dwas.SelectCommand.CommandType = CommandType.StoredProcedure;
            dwas.SelectCommand.Parameters.AddWithValue("@category", category); // pass the parameter .. miss spelt on purpose
            try
            {
                dwas.SelectCommand.Prepare();
                dwas.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataSet Products_Load_by_Manufacter_Category(int manu, int cat)
        {
            dwas = new SqlDataAdapter("Products_Load_By_Manufacturer_Category", conn); // stored procedure created in database
            ds = new DataSet();
            dwas.SelectCommand.CommandType = CommandType.StoredProcedure;
            dwas.SelectCommand.Parameters.AddWithValue("@manu", manu);
            dwas.SelectCommand.Parameters.AddWithValue("@category", cat);

            try
            {
                dwas.SelectCommand.Prepare();
                dwas.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public string Manufacturer_Load_by_ID(int id)
        {
            string manu = string.Empty;
            cmd = new SqlCommand("Manufacturer_Load_By_ID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                conn.Open();
                cmd.Prepare();
                manu = (string)cmd.ExecuteScalar();
                if (manu.Length > 0)
                {
                    return manu;
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
            finally
            {
                conn.Close();
            }
        }

        public string Category_Load_by_ID(int id)
        {
            string manu = string.Empty;
            cmd = new SqlCommand("Category_Load_By_ID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                conn.Open();
                cmd.Prepare();
                manu = (string)cmd.ExecuteScalar();
                if (manu.Length > 0)
                {
                    return manu;
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
            finally
            {
                conn.Close();
            }
        }

        public DataSet Products_Load_By_ID(int id)
        {
            dwas = new SqlDataAdapter("Products_Load_By_ID", conn); // stored procedure created in database
            ds = new DataSet();
            dwas.SelectCommand.CommandType = CommandType.StoredProcedure;
            dwas.SelectCommand.Parameters.AddWithValue("@id", id); // pass the parameter 
            try
            {
                dwas.SelectCommand.Prepare();
                dwas.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool Cart_Insert(int userID, int productID)
        {
            int recAffetct = 0;
            cmd = new SqlCommand("Cart_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userID);
            cmd.Parameters.AddWithValue("@productid", productID);

            try
            {
                conn.Open();
                cmd.Prepare();
                recAffetct = (int)cmd.ExecuteNonQuery();
                if (recAffetct == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception eX)
            {
                eX.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataSet Cart_Load_Information(int id)
        {
            dwas = new SqlDataAdapter("Cart_Display", conn);
            ds = new DataSet();
            dwas.SelectCommand.CommandType = CommandType.StoredProcedure;
            dwas.SelectCommand.Parameters.AddWithValue("@userid", id);
            try
            {
                dwas.SelectCommand.Prepare();
                dwas.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception eX)
            {
                eX.ToString();
                return null;
            }
            finally
            {
                conn.Close();
            }

        }

        public bool Clear_Cart(int id)
        {
            cmd = new SqlCommand("Clear_Cart", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", id);
            try
            {
                conn.Open();
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception eX)
            {
                eX.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool Cart_Item_Delete(int productID, int userID)
        {
            int recAffetct = 0;
            cmd = new SqlCommand("Delete_Cart_Item", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productid", productID);
            cmd.Parameters.AddWithValue("@userid", userID);

            try
            {
                conn.Open();
                cmd.Prepare();
                recAffetct = (int)cmd.ExecuteNonQuery();
                if (recAffetct == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception eX)
            {
                eX.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool Order_Insert(int customerid, string street, string apt, string city, string province, string postalCode)
        {
            int recAffetct = 0;
            cmd = new SqlCommand("Insert_Order", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            // pass parameters
            cmd.Parameters.AddWithValue("@customerid", customerid);
            cmd.Parameters.AddWithValue("@street", street);
            cmd.Parameters.AddWithValue("@apt", apt);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@province", province);
            cmd.Parameters.AddWithValue("@postalcode", postalCode);
            try
            {
                conn.Open();
                cmd.Prepare();
                recAffetct = (int)cmd.ExecuteNonQuery();
                if (recAffetct > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception eX)
            {
                eX.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool Insert_OrderProduct(int productID, decimal price, int customerid)
        {
            int recAffetct = 0;
            cmd = new SqlCommand("Insert_ProductOrder_with_OrderID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productid", productID);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@customerid", customerid);

            try
            {
                conn.Open();
                cmd.Prepare();
                recAffetct = (int)cmd.ExecuteNonQuery();
                if (recAffetct == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception eX)
            {
                eX.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataSet Customer_Invoice(int id)
        {
            dwas = new SqlDataAdapter("Print_Customer_Invoice", conn);
            ds = new DataSet();
            dwas.SelectCommand.CommandType = CommandType.StoredProcedure;
            dwas.SelectCommand.Parameters.AddWithValue("@userid", id);
            try
            {
                dwas.SelectCommand.Prepare();
                dwas.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception eX)
            {
                eX.ToString();
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        //public bool OrderProduct_Insert(int orderID, int productID, decimal price)
        //{
        //    int recAffetct = 0;
        //    cmd = new SqlCommand("Insert_OrderedProduct", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@orderId", orderID);
        //    cmd.Parameters.AddWithValue("@productid", productID);
        //    cmd.Parameters.AddWithValue("@price", price);

        //    try
        //    {
        //        conn.Open();
        //        cmd.Prepare();
        //        recAffetct = (int)cmd.ExecuteNonQuery();
        //        if (recAffetct == 1)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception eX)
        //    {
        //        eX.ToString();
        //        return false;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //} // first try not used
    }

    
}