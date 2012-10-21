using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;

namespace WebDocumentSystem.Document
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var version_id = Request.Form["versions"];
            if (version_id == null)
            {
                int.TryParse(Request.QueryString["DocumentId"], out documentId);
            }
            else
            {
                //Process the form and return to the document list
                int.TryParse(Request.Form["DocumentId"], out documentId);
                WebDocDBEntities ctx = new WebDocDBEntities();

                Models.Document doc = (from c in ctx.Documents
                                       where c.Id == documentId
                                       select c).First();
                
                doc.Revision = int.Parse(version_id);
                ctx.SaveChanges();
                Response.Redirect("/Document/Index.aspx");

            }

        }

        protected IQueryable<Models.DocumentData> GetVersions()
        {
            WebDocDBEntities ctx = new WebDocDBEntities();
            return from c in ctx.DocumentDatas
                   where c.Document == documentId
                   orderby c.CreatedDate descending 
                   select c;
        }

        protected int documentId;
    }

}