using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebDocumentSystem.Models;
using System.Web.Security;
using WebDocumentSystem.BusinessLogic;

namespace SSproject
{
    public partial class USR_login1 : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void validate_login(object sender, EventArgs e)
        {
            string username = txb_usrname.Text;
            string password = txb_password.Text;

            using (var ctx = new WebDocEntities())
            {
                var requestedUser = (from c in ctx.Users
                            where c.Name == username
                            select c).FirstOrDefault();
                if (requestedUser != null)
                {
                    var salt = requestedUser.Salt;
                    var saltedPassword = Encryptor.GenerateSaltedHash(txb_password.Text, salt);
                    if (saltedPassword == requestedUser.Password)
                    {
                        if (requestedUser.AccountRequest.State == (int)AccountRequest.States.Approved)
                        {
                            Session["user"] = requestedUser.Name;
                            Session.Timeout = 20;
                            if (Request.QueryString["ReturnUrl"] == null)
                            {
                                FormsAuthentication.SetAuthCookie(requestedUser.Name, true);
                                Response.Redirect("~/Document/Index.aspx");
                            }
                            else
                            {
                                FormsAuthentication.RedirectFromLoginPage(requestedUser.Name, true);
                            }
                        }
                    }
                }
                lbl_display.Text = lbl_display.Text = "Invalid userid and/or password!! Please enter valid username and password";
                

            }
        }
    }
}