using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace SSproject
{
    public partial class USR_register1 : System.Web.UI.UserControl
    {
        DataAccessor objDB = new DataAccessor();
        protected void Page_Load(object sender, EventArgs e)
        {
            string selectedVal = "-1";
            if (IsPostBack)
            {
                selectedVal = ddl_usrole.SelectedItem.Value;
            }

            ddl_usrole.DataSource = objDB.executeQueryReturnDT("select * from user_types");
            ddl_usrole.Items.Clear();
            ddl_usrole.Items.Add(new ListItem("<Select Option>", "-1"));
            ddl_usrole.DataTextField = "type_name";
            ddl_usrole.DataValueField = "user_type";
            ddl_usrole.DataBind();
            if (IsPostBack)
            {
                ddl_usrole.SelectedItem.Value = selectedVal;
            }


        }
        //checks tha validtaion of user id and other details
        protected void valid_registration(object sender, EventArgs e)
        {
            Boolean isvalidmail = new Boolean();
            Boolean isvaliduid = new Boolean();

            isvalidmail = objDB.getValidcheck(txb_email.Text, "email_id");
            isvaliduid = objDB.getValidcheck(txb_user_id.Text, "user_id");
            lbl_errormail.Text ="";
            lbl_error_user_id.Text = "";
            if (isvalidmail == true)
            {
                lbl_errormail.Text = "Invalid mail id!!!. The Mail Id  is already registered.User another mail id!!!";
            }
            if (isvaliduid)
            {
                lbl_errormail.Text = "";
                lbl_error_user_id.Text = "Invalid user id!!!.The Id  is already registered.User another user id!!!";
            }
            if (!(isvalidmail || isvaliduid))
            {
                onclick_btn_submit();
            }
            else { 

            }
        }
        // the below code will insert the new user into database
        protected void onclick_btn_submit()
        {
            
            string password = txb_pwd.Text.ToString();
            string user_id = txb_user_id.Text.ToString();
            string user_name = txb_name.Text.ToString();
            string user_role = ddl_usrole.SelectedItem.Value;
            string email_id = txb_email.Text.ToString();

            int password_strength = getPaswordStrength(password);

            //request_id	user_id	password	user_type	name	email	password_streangth	request_type_id	timestamp
            //2	mgr_13	password1	2	Jimmy	Jimmy@gmail.com	6	1	2012-10-09 17:33:16.343
            //3	ceo_21	password1	1	Tommy	Tommy@gmail.com	7	1	2012-10-09 17:33:16.383
            //string request_id =objDB.executeQueryReturnString(" select (max(request_id) +1) as val2 from user_requests");\
            string sql = @"insert into user_requests values('"
                + user_id + "','" + password + "'," + user_role + ",'" + user_name + "','" + email_id + "'," + password_strength + ",1,GETDATE() )";
            objDB.executeQuery(sql);
            // string fullname = fname + " " + lname;
            //insert into customer values ('pankaj','Pankaj Khatkar', 'pkhatkar@asu.edu','pankaj')
            //string sql_string = "insert into customer values ('" + uname + "','" + fullname + "','" + email + "','" + password + "')";
            //objDB.executeQuery(sql_string);
            // Response.Redirect("Reg_success.aspx");

        }
        public int getPaswordStrength(string password)
        {
            int score = 4;

            if (password.Length >= 8)
                score++;
            if (password.Length >= 10)
                score++;
            if (password.Length >= 12)
                score++;
            if (password.Length >= 14)
                score++;

            string PatternStr = @"(?:^|\s+)(\w{8})(?<=(.*\d.*\d.*))(?:\s+|$)";
            MatchCollection MatchCol = Regex.Matches(password, PatternStr);

            score = score + MatchCol.Count;

            if (score > 10)
            {
                score = 10;
            }
            return score;
        }
    }
}