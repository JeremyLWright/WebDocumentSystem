using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Data.Objects;
using System.Data;

namespace WebDocumentSystem.Models
{
    public partial class WebDocEntities
    {
        partial void OnContextCreated()
        {
            //this.ObjectMaterialized
            this.SavingChanges += new EventHandler(WebDocEntities_SavingChanges);
        }

        void WebDocEntities_SavingChanges(object sender, EventArgs e)
        {
            IEnumerable<ObjectStateEntry> createdEntities = from ose in this.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified)
                                                             where ose.Entity != null
                                                             select ose;
            foreach(var entity in createdEntities)
            {
                if (entity.Entity is Models.DocumentNote) //Add a created document note
                {
                    Debug.WriteLine("Logging for Document Note");
                    var convertedEntity = (Models.DocumentNote)entity.Entity;
                    var document_message = new Models.DocumentLog();
                    document_message.Date = DateTime.Now;
                    document_message.User = convertedEntity.User;
                    
                    if(entity.State == EntityState.Modified)
                        document_message.Message = "User modifed a document note.";
                    else
                        document_message.Message = "User added a document note.";
                    
                    document_message.Document1 = convertedEntity.Document;
                    convertedEntity.Document.DocumentLogs.Add(document_message);
                }
                else if (entity.Entity is Models.Document)
                {
                    Debug.WriteLine("Logging for Document");
                    var convertedEntity = (Models.Document)entity.Entity;
                    var document_message = new Models.DocumentLog();
                    document_message.Date = DateTime.Now;
                    document_message.User = convertedEntity.Owner;
                    if(entity.State == EntityState.Modified)
                        document_message.Message = "User modified a document.";
                    else
                        document_message.Message = "User added a document.";

                    document_message.Document1 = convertedEntity;
                    convertedEntity.DocumentLogs.Add(document_message);
                }
            }
        }
    }

    public partial class Share
    {
        public enum PermissionLevel
        {
            Read,
            Download,
            Update,
            FullControl
        }
        public Share()
        {
            Created = DateTime.Now;
            Permission = (int)PermissionLevel.Read;
        }
    }

    public partial class Document
    {
        public enum DocumentActions
        {
            AddNote,
            Download,
            Upload_New,
            Read,
            Delete,
            Share,
            Replace_Revise,
            Lock
        }

        public Document()
        {
            LastModified = DateTime.Now;
            Deleted = false;
        }

    }

    public partial class DocumentData
    {
        public DocumentData()
        {
            CreatedDate = DateTime.Now;
            Encrypted = false;
        }
    }

    public partial class DocumentNote
    {
        public DocumentNote()
        {
            CreatedDate = DateTime.Now;
        }
    }

    public partial class UserLog
    {
        public UserLog()
        {
            Date = DateTime.Now;
        }
    }

    public partial class DocumentLog
    {
        public DocumentLog()
        {
            Date = DateTime.Now;
        }
    }

    public partial class AccountRequest
    {
        public AccountRequest()
        {
            Timestamp = DateTime.Now;
            State = (int)States.Pending;
        }

        public enum States
        {
            Pending,
            Approved,
            Revoked
        }
    }

    public partial class User
    {
        public User()
        {
            Role = (int)Roles.NewUser;
        }

        public enum Roles
        {
            CEO,
            Dept_Mgr,
            Employee,
            Temporary,
            Guest,
            Admin,
            NewUser
        }

        public enum Groups
        {
            HR,
            Sales,
            Marketing
        }
    }


}