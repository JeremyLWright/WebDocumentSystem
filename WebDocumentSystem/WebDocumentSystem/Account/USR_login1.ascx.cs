using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebDocumentSystem.Models;

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
                var user = (from c in ctx.Users
                            where c.Name == txb_usrname.Text && c.Password == txb_password.Text
                            select c).FirstOrDefault();
                if (user != null)
                {
                    Session["user"] = user.Name;
                    Session["lastActionTime"] = DateTime.Now.ToString();

                    if (user.UserType.Type != "Admin")
                    {
                        Response.Redirect("~/Account/SysAdmin.aspx");
                    }
                    else
                    {                       
                        Response.Redirect("~/Document/Index.aspx");
                    }
                }
                else
                {
                    lbl_display.Text = lbl_display.Text = "Invalid userid and/or password!! Please enter valid username and password";
                }

            }
        }
    }
}