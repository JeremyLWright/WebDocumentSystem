using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;
using BusinessObjects;
using WebDocumentSystem.BusinessLogic;

namespace WebDocumentSystem.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            var ctx = new WebDocEntities();
            var values = Enum.GetNames(typeof(Models.User.Roles));
            foreach (var role in values)
            {
                ddl_usrole.Items.Add(new ListItem(role));
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

        protected void RegisterSubmit(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string password = txb_pwdc.Text.ToString();

                string user_id = txb_user_id.Text.ToString();
                string user_name = txb_name.Text.ToString();
                string user_role = ddl_usrole.SelectedItem.Value;
                string email_id = txb_email.Text.ToString();
                ddl_questions.SelectedValue = ddl_questions.SelectedItem.Value;
                string question = ddl_questions.SelectedItem.Text;
                string ans = txb_ans1.Text;


                int password_strength = (int)PasswordAdvisor.CheckStrength(password);
                using (var ctx = new WebDocEntities())
                {
                    var values = Enum.GetNames(typeof(Models.User.Roles));
                    var role2 = (from c in values
                                where c == user_role
                                select c).First();

                    var salt = Encryptor.GetSalt();
                    var temp_user = new Models.User();
                    temp_user.Email = email_id;
                    temp_user.Name = user_name;
                    temp_user.SecurityAnswer = ans;
                    temp_user.Password = Encryptor.GenerateSaltedHash(password, salt);
                    temp_user.Salt = salt;
                    temp_user.SecurityQuestion = (from c in ctx.SecurityQuestions where c.Question == question select c).First();
                    temp_user.Role = (int)Enum.Parse(typeof(Models.User.Roles), role2);

                    var request = new AccountRequest();
                    request.PasswordStrength = (int)PasswordAdvisor.CheckStrength(temp_user.Password);
                    temp_user.AccountRequest = request;

                    ctx.Users.AddObject(temp_user);
                    ctx.SaveChanges();
                    Response.Redirect("Reg_success.aspx");
                }
            }
        }

        public void PasswordValidate(Object sender, ServerValidateEventArgs args)
        {
            if (PasswordAdvisor.CheckStrength(args.Value) >= PasswordScore.Medium)
                args.IsValid = true;
            else
                args.IsValid = false;
        }

        public void UsernameAvailable(Object sender, ServerValidateEventArgs args)
        {
            using (var ctx = new WebDocEntities())
            {
                var usernameTaken = (from c in ctx.Users where c.Name == args.Value select c).Any();
                if (usernameTaken)
                    args.IsValid = false;
                else
                    args.IsValid = true;

            }

        }
    }
}