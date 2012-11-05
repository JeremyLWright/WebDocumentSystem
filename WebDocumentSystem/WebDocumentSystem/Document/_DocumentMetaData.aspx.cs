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
    public partial class _DocumentMetaData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var check = new AuthenticatedUser(); //Probably not idiomatic to C#, but I miss Python, why don't attributes work like decorators, I'm sad now.
        }

        protected string GetDocumentName(int DocumentId)
        {
            WebDocEntities ctx = new WebDocEntities();
            var document = (from d in ctx.Documents
                            where d.Id == DocumentId
                            select d).First();
            return document.Name;
        }

        protected IEnumerable<Models.DocumentNote> GetDocumentNotesList(int DocumentId)
        {
            WebDocEntities ctx = new WebDocEntities();
            //Get the Document
            var document = (from d in ctx.Documents 
                            where d.Id == DocumentId 
                            select d).First();
            IEnumerable<Models.DocumentNote> documentNotes = from n in ctx.DocumentNotes 
                                                             where n.DocumentId == document.Id 
                                                             select n;
            return documentNotes;
        }
    }
}