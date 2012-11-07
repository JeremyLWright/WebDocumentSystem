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
            Debug.WriteLine("WebDoc Saving Changes.");
            IEnumerable<ObjectStateEntry> createdEntities = from ose in this.ObjectStateManager.GetObjectStateEntries(EntityState.Added)
                                                             where ose.Entity != null
                                                             select ose;
            foreach(var entity in createdEntities)
            {
                if (entity.Entity is Models.DocumentNote) //Add a created document note
                {
                    var convertedEntity = (Models.DocumentNote)entity.Entity;
                    var document_message = new Models.DocumentLog();
                    document_message.Date = DateTime.Now;
                    document_message.User = convertedEntity.User;
                    document_message.Message = "User added a document note.";
                    document_message.Document1 = convertedEntity.Document;
                    convertedEntity.Document.DocumentLogs.Add(document_message);
                }
                
            }
        }
    }

    public partial class Document
    {
        public Document()
        {
            LastModified = DateTime.Now;
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
        }
    }

}