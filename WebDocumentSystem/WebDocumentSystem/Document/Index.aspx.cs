using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;

namespace WebDocumentSystem
{
    public partial class MainDocumentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            //textbox_search.Text;
            Response.Redirect("Search.aspx");
        }
        protected IEnumerable<Models.Document> GetDocumentList()
        {
            WebDocDBEntities ctx  = new WebDocDBEntities();
            return from c in ctx.Documents orderby c.LastModified descending select c;
        }
        
    }
}