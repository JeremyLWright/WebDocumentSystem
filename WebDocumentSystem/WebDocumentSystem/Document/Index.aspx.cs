using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;
using WebDocumentSystem.Document;
using WebDocumentSystem.Account;

namespace WebDocumentSystem
{
    public partial class MainDocumentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var check = new AuthenticatedUser(); //Probably not idiomatic to C#, but I miss Python, why don't attributes work like decorators, I'm sad now.

            pageNumber = 1;
            var pageQuery = Request.QueryString["page"];
            if (pageQuery != null)
                pageNumber = Int32.Parse(pageQuery);
        }

        protected int pageNumber;

    }

    
}