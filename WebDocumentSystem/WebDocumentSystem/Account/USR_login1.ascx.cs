using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SSproject
{
    public partial class USR_login1 : System.Web.UI.UserControl
    {
        DataAccessor objDB = new DataAccessor();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void validate_login(object sender, EventArgs e)
        {

            string username = txb_usrname.Text;
            string password = txb_password.Text;
            try
            {
                User user = new User(username, password);
                Session["name"] = user.getName();
                if (user.getRole() == "0")
                {
                    Response.Redirect("SysAdmin.aspx");
                }
                else
                {
                    Response.Redirect("DocsPage.aspx");
                }
            }
            catch(Exception exp) {
                lbl_display.Text = lbl_display.Text = "Invalid userid and/or password!! Please enter valid username and password";
            }
        }
    }
}