using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Collections;

namespace SSproject
{
    public partial class USR_sysadmin : System.Web.UI.UserControl
    {
        static int elements_per_page = 2;
        int pageNo = 1;
        static int number_of_pages = 1;
        DataTable dt_request_list = new DataTable();
        DataAccessor objDB = new DataAccessor();
        DataTable dt_one_page_data = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                pageNo = Int32.Parse(ddl_page_no.SelectedValue);
                reload_data_grid(pageNo);
            }
            reload_data_grid(pageNo);
            
        }
        protected void reload_data_grid(int pageNo)
        {
            number_of_pages = ((dt_request_list.Rows.Count - 1) / elements_per_page) + 1;
            ddl_page_no.Items.Clear();
            ddl_page_no.Items.Add(new ListItem("1", "1"));
            for (int i = 2; i <= number_of_pages; i++)
            {
                ddl_page_no.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddl_page_no.SelectedValue = pageNo.ToString();
            ddl_page_no.AutoPostBack = true;
            //request_id	user_id	password	user_type	name	email	password_streangth	request_type_id	timestamp
            //dt_request_list = objDB.executeQueryReturnDT("select request_type_id,timestamp,request_id,name,email,password_streangth,request_type_id,user_id from user_requests");
            dt_request_list = objDB.executeQueryReturnDT("select * from user_requests");

            //copy the schema of source table
            dt_one_page_data = dt_request_list.Clone();

            int start = (pageNo - 1) * elements_per_page;
            int end = start + elements_per_page;
            for (int i = start; i < end && i < dt_request_list.Rows.Count && i >= 0; i++)
            {
                dt_one_page_data.ImportRow(dt_request_list.Rows[i]);
            }
            DataTable dt_temp = new DataTable();
            DataColumn dc = new DataColumn("dummy");
            dt_temp.Columns.Add(dc);
            for (int j = 0; j < dt_one_page_data.Rows.Count; j++)
            {

                dt_temp.Rows.Add("dummy1");
            }
            grv_main_request.DataSource = dt_temp;
            grv_main_request.DataBind();
            grv_main_request.BorderWidth = 0;
        }
        //belows function will populate each row of grid view used for dispalying products
        protected void grv_request_list_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Visible = false;
            }
            int rowIndex = e.Row.RowIndex;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Table tbl_data = new Table();
                //request_id	user_id	password	user_type	name	email	password_streangth	request_type_id	timestamp
                tbl_data.BorderWidth = 0;
                TableRow tbl_row1 = new TableRow();
                TableCell tbl_row1_tc1 = new TableCell();
                TableCell tbl_row1_tc2 = new TableCell();
                Label lbl_tbl_row1_tc1 = new Label();
                Label lbl_tbl_row1_tc2 = new Label();
                lbl_tbl_row1_tc1.Text = "<b>Name: </b>";
                lbl_tbl_row1_tc2.Text = dt_one_page_data.Rows[rowIndex]["name"].ToString();
                tbl_row1_tc1.Controls.Add(lbl_tbl_row1_tc1);
                tbl_row1_tc2.Controls.Add(lbl_tbl_row1_tc2);
                tbl_row1.Cells.Add(tbl_row1_tc1);
                tbl_row1.Cells.Add(tbl_row1_tc2);
                tbl_data.Rows.Add(tbl_row1);

                TableRow tbl_row2 = new TableRow();
                TableCell tbl_row2_tc1 = new TableCell();
                TableCell tbl_row2_tc2 = new TableCell();
                Label lbl_tbl_row2_tc1 = new Label();
                Label lbl_tbl_row2_tc2 = new Label();
                lbl_tbl_row2_tc1.Text = "<b>User Name: </b>";
                lbl_tbl_row2_tc2.Text = dt_one_page_data.Rows[rowIndex]["user_id"].ToString();
                tbl_row2_tc1.Controls.Add(lbl_tbl_row2_tc1);
                tbl_row2_tc2.Controls.Add(lbl_tbl_row2_tc2);
                tbl_row2.Cells.Add(tbl_row2_tc1);
                tbl_row2.Cells.Add(tbl_row2_tc2);
                tbl_data.Rows.Add(tbl_row2);

                TableRow tbl_row3 = new TableRow();
                TableCell tbl_row3_tc1 = new TableCell();
                TableCell tbl_row3_tc2 = new TableCell();
                Label lbl_tbl_row3_tc1 = new Label();
                Label lbl_tbl_row3_tc2 = new Label();
                lbl_tbl_row3_tc1.Text = "<b>E-Mail: </b>";
                lbl_tbl_row3_tc2.Text = dt_one_page_data.Rows[rowIndex]["email"].ToString();
                tbl_row3_tc1.Controls.Add(lbl_tbl_row3_tc1);
                tbl_row3_tc2.Controls.Add(lbl_tbl_row3_tc2);
                tbl_row3.Cells.Add(tbl_row3_tc1);
                tbl_row3.Cells.Add(tbl_row3_tc2);
                tbl_data.Rows.Add(tbl_row3);

                TableRow tbl_row4 = new TableRow();
                TableCell tbl_row4_tc1 = new TableCell();
                TableCell tbl_row4_tc2 = new TableCell();
                Label lbl_tbl_row4_tc1 = new Label();
                Label lbl_tbl_row4_tc2 = new Label();
                lbl_tbl_row4_tc1.Text = "<b>Password Strenght: </b>";
                lbl_tbl_row4_tc2.Text = dt_one_page_data.Rows[rowIndex]["password_streangth"].ToString() + "/10";
                tbl_row4_tc1.Controls.Add(lbl_tbl_row4_tc1);
                tbl_row4_tc2.Controls.Add(lbl_tbl_row4_tc2);
                tbl_row4.Cells.Add(tbl_row4_tc1);
                tbl_row4.Cells.Add(tbl_row4_tc2);
                tbl_data.Rows.Add(tbl_row4);

                TableRow tbl_row5 = new TableRow();
                TableCell tbl_row5_tc1 = new TableCell();
                TableCell tbl_row5_tc2 = new TableCell();
                Label lbl_tbl_row5_tc1 = new Label();
                //Label lbl_tbl_row5_tc2 = new Label();

                DropDownList ddl_tbl_row5_tc2 = new DropDownList();
                ddl_tbl_row5_tc2.DataSource = objDB.executeQueryReturnDT("select * from user_types");
                ddl_tbl_row5_tc2.DataTextField = "type_name";
                ddl_tbl_row5_tc2.DataValueField = "user_type";
                ddl_tbl_row5_tc2.DataBind();
                ddl_tbl_row5_tc2.SelectedValue = dt_one_page_data.Rows[rowIndex]["user_type"].ToString();
                //request_id
                ddl_tbl_row5_tc2.ID = "icnt-" + "role" + "$" + dt_one_page_data.Rows[rowIndex]["request_id"].ToString();
                ddl_tbl_row5_tc2.Attributes.Add("onchange", "javascript:registerChange(this)");
                lbl_tbl_row5_tc1.Text = "<b>Requested Role: </b>";
                tbl_row5_tc1.Controls.Add(lbl_tbl_row5_tc1);
                tbl_row5_tc2.Controls.Add(ddl_tbl_row5_tc2);
                tbl_row5.Cells.Add(tbl_row5_tc1);
                tbl_row5.Cells.Add(tbl_row5_tc2);
                tbl_data.Rows.Add(tbl_row5);

                TableRow tbl_row6 = new TableRow();
                TableCell tbl_row6_tc1 = new TableCell();
                TableCell tbl_row6_tc2 = new TableCell();
                Label lbl_tbl_row6_tc1 = new Label();
                Label lbl_tbl_row6_tc2 = new Label();
                lbl_tbl_row6_tc1.Text = "<b>Request Type: </b>";
                string request_type = objDB.executeQueryReturnString("select request_type from user_request_types where request_type_id=" + dt_one_page_data.Rows[rowIndex]["request_type_id"].ToString());
                lbl_tbl_row6_tc2.Text = request_type;
                tbl_row6_tc1.Controls.Add(lbl_tbl_row6_tc1);
                tbl_row6_tc2.Controls.Add(lbl_tbl_row6_tc2);
                tbl_row6.Cells.Add(tbl_row6_tc1);
                tbl_row6.Cells.Add(tbl_row6_tc2);
                tbl_data.Rows.Add(tbl_row6);

                TableRow tbl_row7 = new TableRow();
                TableCell tbl_row7_tc1 = new TableCell();
                TableCell tbl_row7_tc2 = new TableCell();
                Label lbl_tbl_row7_tc1 = new Label();

                DropDownList ddl_tbl_row7_tc2 = new DropDownList();
                string query = @"select '0' as id,'<select action>' as action
                                union
                                select '1','Approve'
                                union
                                select '2','Reject'";
                ddl_tbl_row7_tc2.DataSource = objDB.executeQueryReturnDT(query);
                ddl_tbl_row7_tc2.DataTextField = "action";
                ddl_tbl_row7_tc2.DataValueField = "id";
                ddl_tbl_row7_tc2.DataBind();
                ddl_tbl_row7_tc2.SelectedValue = "0";
                ddl_tbl_row7_tc2.ID = "icnt-" + "approve" + "$" + dt_one_page_data.Rows[rowIndex]["request_id"].ToString();
                ddl_tbl_row7_tc2.Attributes.Add("onchange", "javascript:registerChangeApprove(this)");
                lbl_tbl_row7_tc1.Text = "<b>Action: </b>";
                tbl_row7_tc1.Controls.Add(lbl_tbl_row7_tc1);
                tbl_row7_tc2.Controls.Add(ddl_tbl_row7_tc2);
                tbl_row7.Cells.Add(tbl_row7_tc1);
                tbl_row7.Cells.Add(tbl_row7_tc2);
                tbl_data.Rows.Add(tbl_row7);

                e.Row.Cells[0].Controls.Add(tbl_data);

            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            string changed_values = hdf_changed.Value;
            string approved_requests = hdf_changed_approve.Value;

            //|role$1_0$3|role$1_0$5
            Hashtable ht_roles = new Hashtable();
            string[] role = changed_values.Split('|');
            for (int i = 1; i < role.Length; i++)
            {
                string req_id = role[i].Split('$')[1].Split('_')[0];
                string val = role[i].Split('$')[2];
                if (!ht_roles.Contains(req_id))
                {
                    ht_roles.Add(req_id, val);
                }
                else
                {
                    ht_roles[req_id] = val;
                }
            }
            foreach (string key in ht_roles.Keys)
            {
                string role_update_sql = "update user_requests set user_type="+ht_roles[key]+" where request_id="+key;
                objDB.executeQuery(role_update_sql);
                //System.Console.WriteLine(key + " " + ht_roles[key]);
            }
            //|approve$1_0$1|approve$1_0$2|approve$2_1$1|approve$2_1$2|approve$2_1$1
            Hashtable ht_approve = new Hashtable();
            string[] approve = approved_requests.Split('|');
            for (int i = 1; i < approve.Length; i++)
            {
                string req_id = approve[i].Split('$')[1].Split('_')[0];
                string val = approve[i].Split('$')[2];
                if (!ht_approve.Contains(req_id))
                {
                    ht_approve.Add(req_id, val);
                }
                else
                {
                    ht_approve[req_id] = val;
                }
            }
            foreach (string key in ht_approve.Keys)
            {
                string val = ht_approve[key].ToString();
                if (val != "0")
                {
                    if (val == "1")
                    {
                        string sql_insert = @"insert into user_accounts2
                                                select user_id,password,user_type,name,email,question,answer
                                                from user_requests where request_id=" + key;
                        objDB.executeQuery(sql_insert);
                        objDB.executeQuery("delete from user_requests where request_id=" + key);
                    }
                    //System.Console.WriteLine(key + " " + ht_approve[key]);
                }
            }
            reload_data_grid(pageNo);
        }

    }

}