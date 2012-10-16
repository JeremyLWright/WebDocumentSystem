using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;
using WebDocumentSystem.Document;

namespace WebDocumentSystem
{
    public partial class MainDocumentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pageNumber = 1;
            var pageQuery = Request.QueryString["page"];
            if (pageQuery != null)
                pageNumber = Int32.Parse(pageQuery); 
        }

        protected int pageNumber;

    }

    
}