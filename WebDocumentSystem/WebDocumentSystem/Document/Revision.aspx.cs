using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;
using WebDocumentSystem.Account;

namespace WebDocumentSystem.Document
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var check = new AuthenticatedUser(); //Probably not idiomatic to C#, but I miss Python, why don't attributes work like decorators, I'm sad now.
            var version_id = Request.Form["versions"];
            if (version_id == null)
            {
                int.TryParse(Request.QueryString["DocumentId"], out documentId);
            }
            else
            {
                //Process the form and return to the document list
                int.TryParse(Request.Form["DocumentId"], out documentId);
                WebDocEntities ctx = new WebDocEntities();

                Models.Document doc = (from c in ctx.Documents
                                       where c.Id == documentId
                                       select c).First();
                
                doc.Revision = int.Parse(version_id);
                doc.Deleted = false; //If we are reverting a document, we undelete it.
                ctx.SaveChanges();
                Response.Redirect("/Document/Index.aspx");

            }

        }

        protected IQueryable<Models.DocumentData> GetVersions()
        {
            WebDocEntities ctx = new WebDocEntities();
            return from c in ctx.DocumentDatas
                   where c.Document == documentId
                   orderby c.CreatedDate descending 
                   select c;
        }

        protected int documentId;
    }

}