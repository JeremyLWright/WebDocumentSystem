using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;
using Microsoft.Security.Application;

namespace WebDocumentSystem.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            var safeUsername = Encoder.HtmlEncode(RegisterUser.UserName);

            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }

            using( var ctx = new WebDocEntities())
            {
                var userEvent = new Models.UserLog();
                var user = (from c in ctx.Users
                           where c.Name == RegisterUser.UserName
                           select c).First();
                userEvent.User = user;
                userEvent.Message = "User Registered.";
                ctx.UserLogs.AddObject(userEvent);
                ctx.SaveChanges();
            }


            Response.Redirect(continueUrl);
        }

    }
}
