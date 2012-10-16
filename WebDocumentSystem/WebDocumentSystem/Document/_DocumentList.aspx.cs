using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;

namespace WebDocumentSystem.Document
{
    public partial class _DocumentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected IQueryable<Models.Document> GetDocumentList()
        {
            WebDocDBEntities ctx = new WebDocDBEntities();
            return from c in ctx.Documents orderby c.LastModified descending select c;
        }
    }
}