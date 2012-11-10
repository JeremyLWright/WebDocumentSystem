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

            var group_shared_docs = (from c in ctx.GroupShares
                                     where c.Group == user.Group
                                     orderby c.Created
                                     descending
                                     select c.Document);

            return documents.Union(shared_docs).Union(group_shared_docs).OrderBy(x => x.LastModified);
        }

        public static bool IsSharedDoc(Models.Document doc)
        {
            return (doc.Owner.Name != HttpContext.Current.User.Identity.Name);
        }

        public static Share.PermissionLevel GetPermissionLevel(Models.Document doc)
        {
            var username = HttpContext.Current.User.Identity.Name;
            using (var ctx = new WebDocEntities())
            {
                if(IsSharedDoc(doc))
                {
                    var user = (from c in ctx.Users
                                where c.Name == username
                                select c).First();
                    var sharerecord = (from c in ctx.Shares
                                       where c.Document.Id == doc.Id //Is there a document
                                       && c.User.Id == user.Id       //with this user
                                       select c).FirstOrDefault(); // Get First one
                    var grouprecord = (from c in ctx.GroupShares
                                       where c.Document.Id == doc.Id
                                       && c.Group == user.Group
                                       select c).FirstOrDefault();
                    if (sharerecord != null)
                    {
                        return (Share.PermissionLevel)sharerecord.Permission;
                    }
                    else if (grouprecord != null)
                    {
                        return (Share.PermissionLevel)grouprecord.Permission;
                    }
                    else
                    {
                        throw new InvalidDocumentAccess("User " + HttpContext.Current.User.Identity.Name + " does not have access to " + doc.Id);
                    }
                }
                else
                {
                    return Share.PermissionLevel.FullControl;
                }
            }
        }

        public static bool CanAction(Models.Document doc, Models.Document.DocumentActions desiredAction)
        {
            var allowed = false;

            switch(GetPermissionLevel(doc))
            {
                case Share.PermissionLevel.Download:
                    switch (desiredAction)
                    {
                        case Models.Document.DocumentActions.Lock:
                            allowed = false;
                            break;
                        case Models.Document.DocumentActions.AddNote:
                            allowed = false;
                            break;
                        case Models.Document.DocumentActions.Delete:
                            allowed = false;
                            break;
                        case Models.Document.DocumentActions.Download:
                            allowed = true;
                            break;
                        case Models.Document.DocumentActions.Read:
                            allowed = true;
                            break;
                        case Models.Document.DocumentActions.Share:
                            allowed = false;
                            break;
                        case Models.Document.DocumentActions.Upload_New:
                            allowed = true;
                            break;
                        case Models.Document.DocumentActions.Replace_Revise:
                            allowed = false;
                            break;
                    }
                    break;
                case Share.PermissionLevel.FullControl:
                    allowed = true;
                    break;
                case Share.PermissionLevel.Read:
                    switch (desiredAction)
                    {
                        case Models.Document.DocumentActions.Lock:
                            allowed = false;
                            break;
                        case Models.Document.DocumentActions.AddNote:
                            allowed = false;
                            break;
                        case Models.Document.DocumentActions.Delete:
                            allowed = false;
                            break;
                        case Models.Document.DocumentActions.Download:
                            allowed = true;
                            break;
                        case Models.Document.DocumentActions.Read:
                            allowed = true;
                            break;
                        case Models.Document.DocumentActions.Share:
                            allowed = false;
                            break;
                        case Models.Document.DocumentActions.Upload_New:
                            allowed = false;
                            break;
                        case Models.Document.DocumentActions.Replace_Revise:
                            allowed = false;
                            break;
                    }
                    break;
                case Share.PermissionLevel.Update:
                    switch (desiredAction)
                    {
                        case Models.Document.DocumentActions.Lock:
                            allowed = true;
                            break;
                        case Models.Document.DocumentActions.AddNote:
                            allowed = true;
                            break;
                        case Models.Document.DocumentActions.Delete:
                            allowed = false;
                            break;
                        case Models.Document.DocumentActions.Download:
                            allowed = true;
                            break;
                        case Models.Document.DocumentActions.Read:
                            allowed = true;
                            break;
                        case Models.Document.DocumentActions.Share:
                            allowed = true;
                            break;
                        case Models.Document.DocumentActions.Upload_New:
                            allowed = true;
                            break;
                        case Models.Document.DocumentActions.Replace_Revise:
                            allowed = true;
                            break;
                    }
                    break;
            }

            //If the user has permission, he must ALSO have the lock to perform some actions
            //If we already denied the user, then fine.
            if (allowed == true && doc.IsLocked)
            {
                using(var ctx = new WebDocEntities())
                {
                    var currentUser = (from c in ctx.Users
                                       where c.Name == HttpContext.Current.User.Identity.Name
                                       select c).FirstOrDefault();
                    if (currentUser == null)
                    {
                        allowed = false; //Who is the lock holder?... error but I'm tired now
                    }
                    else if (currentUser.Id != doc.LockHolder) //Am I the lock holder?
                    {
                        allowed = false; //Nope!
                    }
                }
            }



            return allowed;
        }
    }
}