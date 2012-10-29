using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.Common;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace SSproject
{
    public class DataAccessor
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
        #region Login
        public DataTable getValidLogin(string uname, string pass)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                try
                {
                    SqlCommand comInst = new SqlCommand("select * from user_accounts2 where user_id= @Uname and password=@Password", connect);
                    comInst.Parameters.AddWithValue("Uname", uname);
                    comInst.Parameters.AddWithValue("Password", pass);
                    comInst.CommandType = CommandType.Text;
                    System.Data.DataSet ds = new System.Data.DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comInst);
                    da.Fill(ds);
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        return dt;
                    }
                    else
                    {
                        return dt;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        public DataTable getSysAdminLogin(string uname, string pass)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                try
                {
                    SqlCommand comInst = new SqlCommand("select * from user_accounts where user_id= @Uname and password=@Password and user_type=0", connect);
                    comInst.Parameters.AddWithValue("Uname", uname);
                    comInst.Parameters.AddWithValue("Password", pass);
                    comInst.CommandType = CommandType.Text;
                    System.Data.DataSet ds = new System.Data.DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comInst);
                    da.Fill(ds);
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        return dt;
                    }
                    else
                    {
                        return dt;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        
        public DataTable getUserValidLogin(string OrgID, string uname, string pass)
        {
            uname = "praveenbits.t@gmail.com";
            pass = "praveen";
            OrgID = "tenant_1000";
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                try
                {
                    SqlCommand comInst = new SqlCommand("select OrgID,Name,value1,value2, value3 from data_table where OrgID='" + OrgID + "' and value3='" + uname + "' and value4='" + pass + "'", connect);
                    comInst.CommandType = CommandType.Text;
                    System.Data.DataSet ds = new System.Data.DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comInst);
                    da.Fill(ds);
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        return dt;
                    }
                    else
                    {
                        return dt;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        #endregion
        #region General Methods
        public void executeQuery(string sql_string)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                try
                {
                    SqlCommand comInst = new SqlCommand(sql_string, connect);
                    comInst.CommandType = CommandType.Text;
                    System.Data.DataSet ds = new System.Data.DataSet();
                    comInst.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        public Boolean getValidcheck(string item, string column)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                try
                {
                    SqlCommand comInst = new SqlCommand("select count(*) as numcount from user_accounts2 where " + column + "='" + item + "'", connect);
                    comInst.CommandType = CommandType.Text;
                    System.Data.DataSet ds = new System.Data.DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comInst);
                    da.Fill(ds);
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    if (Convert.ToInt32(dt.Rows[0][0]) >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        public DataSet executeQueryReturnDS(string sql_query)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                try
                {
                    SqlCommand comInst = new SqlCommand(sql_query, connect);
                    comInst.CommandType = CommandType.Text;
                    System.Data.DataSet ds = new System.Data.DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comInst);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        public DataTable executeQueryReturnDT(string sql_query)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                try
                {
                    SqlCommand comInst = new SqlCommand(sql_query, connect);
                    comInst.CommandType = CommandType.Text;
                    System.Data.DataSet ds = new System.Data.DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comInst);
                    da.Fill(ds);
                    return ds.Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        public string executeQueryReturnString(string sql_query)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                try
                {
                    SqlCommand comInst = new SqlCommand(sql_query, connect);
                    comInst.CommandType = CommandType.Text;
                    System.Data.DataSet ds = new System.Data.DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comInst);
                    da.Fill(ds);
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        #endregion
        #region master Item Details
        //Below Code for getting Item Details //
        public string getPrice(string pdt_id)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                try
                {
                    string sql_query = "select sellprice from item where pdt_id='" + pdt_id + "'";

                    SqlCommand comInst = new SqlCommand(sql_query, connect);
                    comInst.CommandType = CommandType.Text;
                    System.Data.DataSet ds = new System.Data.DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comInst);
                    da.Fill(ds);
                    string price = "0";
                    DataTable loc_dt = ds.Tables[0].Copy();
                    if (loc_dt.Rows.Count > 0)
                    {
                        price = loc_dt.Rows[0][0].ToString();
                    }
                    return price;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        public string getShipWeight(string pdt_id)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                try
                {
                    string sql_query = "select shipweight from item where pdt_id='" + pdt_id + "'";

                    SqlCommand comInst = new SqlCommand(sql_query, connect);
                    comInst.CommandType = CommandType.Text;
                    System.Data.DataSet ds = new System.Data.DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comInst);
                    da.Fill(ds);
                    string price = "0";
                    DataTable loc_dt = ds.Tables[0].Copy();
                    if (loc_dt.Rows.Count > 0)
                    {
                        price = loc_dt.Rows[0][0].ToString();
                    }
                    return price;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        public string getImageLink(string pdt_id)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                try
                {
                    string sql_query = "select author_name from author where pdt_id='" + pdt_id + "'";

                    SqlCommand comInst = new SqlCommand(sql_query, connect);
                    comInst.CommandType = CommandType.Text;
                    System.Data.DataSet ds = new System.Data.DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comInst);
                    da.Fill(ds);
                    string image_link = "";
                    DataTable loc_dt = ds.Tables[0].Copy();
                    /*if (loc_dt.Rows.Count > 0)
                    {
                        image_link = loc_dt.Rows[0][0].ToString();
                    }*/
                    if (pdt_id.IndexOf("BK") >= 0)
                    {
                        image_link = "images/Book.jpg";
                    }
                    else
                    {
                        image_link = "images/cd.jpg";
                    }
                    
                    return image_link;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        public string getQtyAvailable(string pdt_id)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                try
                {
                    string sql_query = "select pdt_id,sum(quantity_in_wh) as qty from available where pdt_id='" + pdt_id + "' group by pdt_id";
                    
                    SqlCommand comInst = new SqlCommand(sql_query, connect);
                    comInst.CommandType = CommandType.Text;
                    System.Data.DataSet ds = new System.Data.DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comInst);
                    da.Fill(ds);
                    string qty = "0";
                    DataTable loc_dt = ds.Tables[0].Copy();
                    if (loc_dt.Rows.Count > 0)
                    {
                        qty = loc_dt.Rows[0][1].ToString();
                    }
                    return qty;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        //Above Code for getting Item Details //
        #endregion
        #region Book Details
        //Below Code for getting Book Details //
        public string getBookTitle(string pdt_id)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                try
                {
                    string sql_query = "select title from book where pdt_id='" + pdt_id + "'";

                    SqlCommand comInst = new SqlCommand(sql_query, connect);
                    comInst.CommandType = CommandType.Text;
                    System.Data.DataSet ds = new System.Data.DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comInst);
                    da.Fill(ds);
                    string title = "";
                    DataTable loc_dt = ds.Tables[0].Copy();
                    if (loc_dt.Rows.Count > 0)
                    {
                        title = loc_dt.Rows[0][0].ToString();
                    }
                    return title;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        public string getAuthors(string pdt_id)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                try
                {
                    string sql_query = "select author_name from author where pdt_id='" + pdt_id + "'";
                    
                    SqlCommand comInst = new SqlCommand(sql_query, connect);
                    comInst.CommandType = CommandType.Text;
                    System.Data.DataSet ds = new System.Data.DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comInst);
                    da.Fill(ds);
                    string authors_list="";
                    DataTable loc_dt = ds.Tables[0].Copy();
                    if (loc_dt.Rows.Count > 0)
                    {
                        authors_list = loc_dt.Rows[0][0].ToString();
                    }
                    for (int i = 1; i < loc_dt.Rows.Count; i++)
                    {
                        authors_list = authors_list + ", " + loc_dt.Rows[i][0].ToString();
                    }
                    return authors_list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        public string getISBN(string pdt_id)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                try
                {
                    string sql_query = "select ISBN from book where pdt_id='" + pdt_id + "'";

                    SqlCommand comInst = new SqlCommand(sql_query, connect);
                    comInst.CommandType = CommandType.Text;
                    System.Data.DataSet ds = new System.Data.DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comInst);
                    da.Fill(ds);
                    string authors_list = "";
                    DataTable loc_dt = ds.Tables[0].Copy();
                    if (loc_dt.Rows.Count > 0)
                    {
                        authors_list = loc_dt.Rows[0][0].ToString();
                    }
                    for (int i = 1; i < loc_dt.Rows.Count; i++)
                    {
                        authors_list = authors_list + ", " + loc_dt.Rows[i][0].ToString();
                    }
                    return authors_list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        //Above Code for getting Book Details //
        #endregion
        #region CD Details
        //Below Code for getting CD Details //
        public string getAlbumName(string pdt_id)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                try
                {
                    string sql_query = "select album_name from cd where pdt_id='" + pdt_id + "'";

                    SqlCommand comInst = new SqlCommand(sql_query, connect);
                    comInst.CommandType = CommandType.Text;
                    System.Data.DataSet ds = new System.Data.DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comInst);
                    da.Fill(ds);
                    string authors_list = "";
                    DataTable loc_dt = ds.Tables[0].Copy();
                    if (loc_dt.Rows.Count > 0)
                    {
                        authors_list = loc_dt.Rows[0][0].ToString();
                    }
                    for (int i = 1; i < loc_dt.Rows.Count; i++)
                    {
                        authors_list = authors_list + ", " + loc_dt.Rows[i][0].ToString();
                    }
                    return authors_list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        public string getArtists(string pdt_id)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                try
                {
                    string sql_query = "select artist_name from artist where pdt_id='" + pdt_id + "'";

                    SqlCommand comInst = new SqlCommand(sql_query, connect);
                    comInst.CommandType = CommandType.Text;
                    System.Data.DataSet ds = new System.Data.DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comInst);
                    da.Fill(ds);
                    string artist_list = "";
                    DataTable loc_dt = ds.Tables[0].Copy();
                    if (loc_dt.Rows.Count > 0)
                    {
                        artist_list = loc_dt.Rows[0][0].ToString();
                    }
                    for (int i = 1; i < loc_dt.Rows.Count; i++)
                    {
                        artist_list = artist_list + ", " + loc_dt.Rows[i][0].ToString();
                    }
                    return artist_list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        public string getCDID(string pdt_id)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                try
                {
                    string sql_query = "select cd_id from cd where pdt_id='" + pdt_id + "'";

                    SqlCommand comInst = new SqlCommand(sql_query, connect);
                    comInst.CommandType = CommandType.Text;
                    System.Data.DataSet ds = new System.Data.DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comInst);
                    da.Fill(ds);
                    string cd_id = "";
                    DataTable loc_dt = ds.Tables[0].Copy();
                    if (loc_dt.Rows.Count > 0)
                    {
                        cd_id = loc_dt.Rows[0][0].ToString();
                    }
                    return cd_id;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        #endregion
        public string getShipHours(string ship_method_id)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                try
                {
                    string sql_query = "select duration from shipment_method where ship_method_id='" + ship_method_id + "'";

                    SqlCommand comInst = new SqlCommand(sql_query, connect);
                    comInst.CommandType = CommandType.Text;
                    System.Data.DataSet ds = new System.Data.DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comInst);
                    da.Fill(ds);
                    string price = "0";
                    DataTable loc_dt = ds.Tables[0].Copy();
                    if (loc_dt.Rows.Count > 0)
                    {
                        price = loc_dt.Rows[0][0].ToString();
                    }
                    return price;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        public string getQtyInWh(string pdt_id, string wh_id)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                try
                {
                    string sql_query = "select quantity_in_wh from available where pdt_id='" + pdt_id + "' and wh_id=" + wh_id;

                    SqlCommand comInst = new SqlCommand(sql_query, connect);
                    comInst.CommandType = CommandType.Text;
                    System.Data.DataSet ds = new System.Data.DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comInst);
                    da.Fill(ds);
                    string qty = "0";
                    DataTable loc_dt = ds.Tables[0].Copy();
                    if (loc_dt.Rows.Count > 0)
                    {
                        qty = loc_dt.Rows[0][0].ToString();
                    }
                    return qty;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
        }
    }
}