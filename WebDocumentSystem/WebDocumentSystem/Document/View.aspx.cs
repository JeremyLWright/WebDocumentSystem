using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;
using WebDocumentSystem.Account;
using WebDocumentSystem.Models;

namespace WebDocumentSystem.Document
{
    public partial class Documentview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var check = new AuthenticatedUser(); //Probably not idiomatic to C#, but I miss Python, why don't attributes work like decorators, I'm sad now.
            authenticatedUsername = check.Get();
            safeDocumentId = Encoder.UrlEncode(Request.QueryString["DocumentId"]);
            try
            {

                documentId = Request.QueryString.GetValue<int>("DocumentId");
            }
            catch (ArgumentOutOfRangeException)
            {
                Response.Redirect("Index.aspx");
            }
            try
            {
                pageNumber = Request.QueryString.GetValue<int>("page");
            }
            catch (ArgumentOutOfRangeException)
            {
                pageNumber = 1;
            }
            
            using (var ctx = new WebDocEntities())
            {
                
                var document_message = new Models.DocumentLog();
                document_message.Date = DateTime.Now;
                document_message.User = (from c in ctx.Users
                                         where c.Name == authenticatedUsername
                                         select c).First();

                document_message.Message = "Document Viewed";
                document_message.Document1 = (from c in ctx.Documents
                                             where c.Id == documentId
                                             select c).First();
                ctx.DocumentLogs.AddObject(document_message);
                ctx.SaveChanges();
            }
        }

        protected IQueryable<Models.DocumentLog> GetDocumentHistory()
        {
            WebDocEntities ctx = new WebDocEntities();

            return from c in ctx.DocumentLogs
                   where c.Document == documentId
                   orderby c.Date
                   descending
                   select c;
        }

        protected void AddMessageSubmit(Object obj, EventArgs e)
        {
            if(Page.IsValid)
            {
                using (var ctx = new WebDocEntities())
                {
                    var user = (from c in ctx.Users
                               where c.Name == authenticatedUsername
                               select c).First();
                    var document = (from c in ctx.Documents
                                    where c.Id == documentId
                                    select c).First();

                    var note = new Models.DocumentNote();
                    note.Note = document_message.Text;
                    note.User = user;
                    document.DocumentNotes.Add(note);
                    ctx.SaveChanges();
                }
            }
        }
        public string safeDocumentId;
        public string authenticatedUsername;
        protected int documentId;
        protected int pageNumber;
    }
}