using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using WebDocumentSystem.Models;

namespace WebDocumentSystem.Document
{
    class InvalidDocumentAccess : Exception
    {
        public InvalidDocumentAccess(string message)
            : base(message)
        {
        }
    }
}
