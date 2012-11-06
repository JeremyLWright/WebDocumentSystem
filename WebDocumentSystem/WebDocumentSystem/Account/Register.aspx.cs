using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;
using BusinessObjects;

namespace WebDocumentSystem.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            var ctx = new WebDocEntities();
            var roles = from c in ctx.UserTypes
                        select c;

            foreach (var role in roles)
            {
                ddl_usrole.Items.Add(new ListItem(role.Type));
            }

            ddl_usrole.DataTextField = "type_name";
            ddl_usrole.DataValueField = "user_type";

            var questions = from c in ctx.SecurityQuestions
                            select c;
            foreach (var question in questions)
            {
                ddl_questions.Items.Add(new ListItem(question.Question));
            }

            ddl_questions.DataTextField = "question";
            ddl_questions.DataValueField = "question_id";
        }

        protected void valid_registration(object sender, EventArgs e)
        {
            Boolean isvalidmail = new Boolean();
            Boolean isvaliduid = new Boolean();

            /* isvalidmail = objDB.getValidcheck(txb_email.Text, "email_id");
             isvaliduid = objDB.getValidcheck(txb_user_id.Text, "user_id");
             */
            lbl_errormail.Text = "";
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
            else
            {

            }
        }

        protected void onclick_btn_submit()
        {

            string password = txb_pwdc.Text.ToString();

            string user_id = txb_user_id.Text.ToString();
            string user_name = txb_name.Text.ToString();
            string user_role = ddl_usrole.SelectedItem.Value;
            string email_id = txb_email.Text.ToString();
            ddl_questions.SelectedValue = ddl_questions.SelectedItem.Value;
            string question = ddl_questions.SelectedItem.Text;
            string ans = txb_ans1.Text;
            if (ddl_questions.SelectedItem.Value == "-1" || string.IsNullOrEmpty(ans) || string.IsNullOrWhiteSpace(ans))
            {
                question = txb_cust_quest.Text;
                ans = txb_cust_ans.Text;
            }

            int password_strength = (int)PasswordAdvisor.CheckStrength(password);

            //request_id	user_id	password	user_type	name	email	password_streangth	request_type_id	timestamp
            //2	mgr_13	password1	2	Jimmy	Jimmy@gmail.com	6	1	2012-10-09 17:33:16.343
            //3	ceo_21	password1	1	Tommy	Tommy@gmail.com	7	1	2012-10-09 17:33:16.383
            //string request_id =objDB.executeQueryReturnString(" select (max(request_id) +1) as val2 from user_requests");
            string sql = @"insert into user_requests values('"
                + user_id + "','" + password + "'," + user_role + ",'" + user_name + "','" + email_id + "'," + password_strength + ",1,GETDATE()" + ",'" + question + "','" + ans + "' )";
            //objDB.executeQuery(sql);
            // string fullname = fname + " " + lname;
            //insert into customer values ('pankaj','Pankaj Khatkar', 'pkhatkar@asu.edu','pankaj')
            //string sql_string = "insert into customer values ('" + uname + "','" + fullname + "','" + email + "','" + password + "')";
            //objDB.executeQuery(sql_string);
            // Response.Redirect("Reg_success.aspx");

        }

        public bool PasswordValidate(Object sender, ServerValidateEventArgs args)
        {
            return false;
        }
    }
}