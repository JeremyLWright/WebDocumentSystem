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
    public partial class _DocumentLock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var check = new AuthenticatedUser(); //Probably not idiomatic to C#, but I miss Python, why don't attributes work like decorators, I'm sad now.
        }

        protected bool AttemptLock(int DocumentId)
        {
            WebDocEntities ctx = new WebDocEntities();
            var document = (from d in ctx.Documents
                            where d.Id == DocumentId
                            select d).First();
            //document..CreatedDate = DateTime.Now;

            if(document.IsLocked == true)
                document.IsLocked = false;
            else
                document.IsLocked = true;
            ctx.SaveChanges();
            return true;

        }
    }
}