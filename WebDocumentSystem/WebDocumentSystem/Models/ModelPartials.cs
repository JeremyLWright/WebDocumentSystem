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

    public partial class Audit_Log
    {
        public Audit_Log()
        {
            Date = DateTime.Now;
        }
    }
}