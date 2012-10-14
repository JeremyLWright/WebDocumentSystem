using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;

namespace WebDocumentSystem.Document
{
    public partial class _DocumentLock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected bool AttemptLock(int DocumentId)
        {
            WebDocDBEntities ctx = new WebDocDBEntities();
            var document = (from d in ctx.Documents
                            where d.Id == DocumentId
                            select d).First();
            document.LastModified = DateTime.Now;

            if(document.IsLocked == true)
                document.IsLocked = false;
            else
                document.IsLocked = true;
            ctx.SaveChanges();
            return true;

        }
    }
}