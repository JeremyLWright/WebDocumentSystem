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

            //Does this user even have permission to lock the document?
            if (DocumentHelper.CanAction(document, Models.Document.DocumentActions.Lock))
            {
                var user = (from u in ctx.Users
                            where u.Name == HttpContext.Current.User.Identity.Name
                            select u).FirstOrDefault();
                if (user != null)
                {
                    if (document.IsLocked == true)
                    {

                        if (document.LockHolder == user.Id) //Document is locked & we own the lock
                        {
                            document.IsLocked = false; //unlock it
                            document.LockHolder = null;
                            ctx.SaveChanges();
                            return true;
                        }
                        else if (document.LockHolder != user.Id) //Document is locked & we do not own the lock
                        {
                            return false;
                        }
                    }
                    else //Document is unlocked
                    {
                        document.IsLocked = true;
                        document.LockHolder = user.Id;
                        ctx.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
            

        }
    }
}