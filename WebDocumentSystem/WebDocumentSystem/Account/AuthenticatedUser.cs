using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDocumentSystem.Account
{
    [AttributeUsage(AttributeTargets.All)]
    public class AuthenticatedUser : System.Attribute
    {
        public AuthenticatedUser()
        {
            if (HttpContext.Current.Session["user"] == null || 
                Convert.ToDateTime(HttpContext.Current.Session["lastActionTime"]) > DateTime.Now.AddMinutes(20))
            {
                ForceLogin();
            }
        }

        public void ForceLogin()
        {
            HttpContext.Current.Response.Redirect("~/Account/Login.aspx");
        }
    }
}