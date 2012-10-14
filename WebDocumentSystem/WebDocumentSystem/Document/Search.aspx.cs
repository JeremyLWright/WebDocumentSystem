﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;

namespace WebDocumentSystem
{
    public partial class SearchResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ctx = new WebDocDBEntities();
            search_term = Request.Form["search_term"];
            
            releventNotes = from d in ctx.DocumentNotes
                         where d.Note.Contains(search_term)
                         select d;
        }

        protected string GetRelatedDocumentName(DocumentNote note)
        {
            var relatedDocument = (from d in ctx.Documents
                                   where d.Id == note.DocumentId
                                   select d).First();
            return relatedDocument.Name;
        }

        protected WebDocDBEntities ctx;
        protected string search_term;
        protected IEnumerable<Models.DocumentNote> releventNotes;
    }
}