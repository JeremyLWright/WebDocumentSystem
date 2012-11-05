using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;
using WebDocumentSystem.Account;

namespace WebDocumentSystem.Document
{
    public partial class Documentview : System.Web.UI.Page
    {
        [AuthenticatedUser]
        protected void Page_Load(object sender, EventArgs e)
        {
            var check = new AuthenticatedUser(); //Probably not idiomatic to C#, but I miss Python, why don't attributes work like decorators, I'm sad now.
            safeDocumentId = Encoder.UrlEncode(Request.QueryString["DocumentId"]);
        }
        public string safeDocumentId;
    }
}