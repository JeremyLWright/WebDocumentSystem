using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;
using WebDocumentSystem.Account;

namespace WebDocumentSystem
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            isSuperUser = AuthenticatedUser.isSuperUser();
        }

        protected bool isSuperUser;
        protected string username;
    }
}
