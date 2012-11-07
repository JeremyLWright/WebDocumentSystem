using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace WebDocumentSystem.Models
{
    public partial class WebDocEntities
    {
        partial void OnContextCreated()
        {
            this.SavingChanges += new EventHandler(WebDocEntities_SavingChanges);
        }

        void WebDocEntities_SavingChanges(object sender, EventArgs e)
        {
            Debug.WriteLine("WebDoc Saving Changes.");
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