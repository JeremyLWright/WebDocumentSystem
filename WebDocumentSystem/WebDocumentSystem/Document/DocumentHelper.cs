using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDocumentSystem.Models;

namespace WebDocumentSystem.Document
{
    public class DocumentHelper
    {
        public static IQueryable<Models.Document> GetDocumentList()
        {
            WebDocEntities ctx = new WebDocEntities();
            var sessionUser = HttpContext.Current.User.Identity.Name;
            var user = (from c in ctx.Users
                        where c.Name == (sessionUser)
                        select c).FirstOrDefault();

            var documents = (from c in ctx.Documents
                             where c.Owner.Name == user.Name
                             orderby c.LastModified
                             descending
                             select c);
            var shared_docs = (from c in ctx.Shares
                               where c.User.Id == user.Id
                               orderby c.Created
                               descending
                               select c.Document);

            return documents.Union(shared_docs).OrderBy(x => x.LastModified);
        }
    }
}