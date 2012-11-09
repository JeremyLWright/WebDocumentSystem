using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;

namespace WebDocumentSystem.Document
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                var documentId = Request.QueryString.GetValue<int>("DocumentId");

                using (var ctx = new WebDocEntities())
                {

                    var document_message = new Models.DocumentLog();
                    document_message.Date = DateTime.Now;
                    document_message.User = (from c in ctx.Users
                                             where c.Name == HttpContext.Current.User.Identity.Name
                                             select c).First();

                    document_message.Message = "Document Deleted";

                    var document = (from c in ctx.Documents
                                    where c.Id == documentId
                                    select c).First();
                    if(DocumentHelper.CanAction(document, Models.Document.DocumentActions.Delete))
                    {
                        document.Deleted = true;
                        document_message.Document1 = document;
                        ctx.DocumentLogs.AddObject(document_message);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Response.Redirect("Index.aspx");
            }
            Response.Redirect("Index.aspx");
        }
    }
}