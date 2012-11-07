using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDocumentSystem.Models;

namespace WebDocumentSystem.Account
{
    [AttributeUsage(AttributeTargets.All)]
    public class AuthenticatedUser : System.Attribute
    {
        public string Get()
        {
            return HttpContext.Current.User.Identity.Name;            

        }

        public static bool isSuperUser()
        {
            var username = HttpContext.Current.User.Identity.Name;
            using (var ctx = new WebDocEntities())
            {
                var user = (from c in ctx.Users
                            where c.Name == username
                            select c).FirstOrDefault();
                if (user != null)
                {
                    if (user.Role == (int)Models.User.Roles.Admin)
                        return true;
                }
            }
            return false;
        }
    }
}