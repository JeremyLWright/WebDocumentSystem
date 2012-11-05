using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDocumentSystem.Models
{
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