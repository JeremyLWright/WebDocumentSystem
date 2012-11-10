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
    public partial class SearchResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var check = new AuthenticatedUser(); //Probably not idiomatic to C#, but I miss Python, why don't attributes work like decorators, I'm sad now.
            ctx = new WebDocEntities();
            
            search_term = Server.HtmlEncode(Request.Form["search_term"]);
            var username = HttpContext.Current.User.Identity.Name;
            var user = (from u in ctx.Users
                       where u.Name == username
                       select u).First();
            releventNotes = from d in ctx.DocumentNotes
                         where d.Note.Contains(search_term) 
                               && d.User.Id == user.Id
                         select d;
        }

        protected IQueryable<Models.Document> GetSearchedDocuments()
        {
            var documents = WebDocumentSystem.Document.DocumentHelper.GetDocumentList();
            var searchedDocuments = (from d in documents
                                     where d.Name.Contains(search_term)
                                     select d);
            return searchedDocuments;
        }

        protected Models.Document GetRelatedDocument(DocumentNote note)
        {
            var relatedDocument = (from d in ctx.Documents
                                   where d.Id == note.DocumentId
                                   select d).First();
            
            return relatedDocument;
        }

        protected WebDocEntities ctx;
        protected string search_term;
        protected IEnumerable<Models.DocumentNote> releventNotes;
    }
}