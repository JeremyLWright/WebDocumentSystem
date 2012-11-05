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
    public partial class _DocumentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var check = new AuthenticatedUser(); //Probably not idiomatic to C#, but I miss Python, why don't attributes work like decorators, I'm sad now.
        }

        protected IQueryable<Models.Document> GetDocumentList()
        {
            WebDocEntities ctx = new WebDocEntities();
            var sessionUser = Session["user"];
            var user = (from c in ctx.Users
                        where c.Name == (sessionUser)
                        select c).FirstOrDefault();

            return from c in ctx.Documents 
                   where c.Owner.Name == user.Name
                   orderby c.LastModified 
                   descending select c;
        }
    }
}