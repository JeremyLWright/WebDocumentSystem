using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;

namespace WebDocumentSystem
{
    public partial class CreateMockData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var ctx = new WebDocEntities())
            {
                foreach(var questionText in exampleQuestions)
                {
                    var question = new Models.SecurityQuestions();
                    question.Question = questionText;
                    ctx.SecurityQuestions.AddObject(question);
                }
                ctx.SaveChanges();

                foreach (var roleText in exampleRoles)
                {
                    var Role = new Models.UserType();
                    Role.Type = roleText;
                    ctx.UserTypes.AddObject(Role);
                }
                ctx.SaveChanges();
            }



        }

        string[] exampleQuestions = {"What was your childhood nickname?",
"What street did you live on in third grade?",
"What is the middle name of your oldest child?",
"What is your oldest sibling's middle name?",
"What school did you attend for sixth grade?",
"What is your oldest cousin's first and last name?",
"What was the name of your first stuffed animal?",
"Where were you when you had your first kiss?",
"In what city does your nearest sibling live?",
"What is your maternal grandmother's maiden name?",
"In what city or town was your first job?",
"Where were you when you first heard about 9/11?"};
        string[] exampleRoles = {
                                 "President/CEO/VP",
"Dept Mgr",
"R Employee",
"Temp_User",
"Guest_User",
"Sys_admin",
"new_user"};

    }
}