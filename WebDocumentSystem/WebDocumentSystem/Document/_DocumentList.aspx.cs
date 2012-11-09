using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;
using WebDocumentSystem.Account;
using WebDocumentSystem.Document;

namespace WebDocumentSystem.Document
{
    public partial class _DocumentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Setup the document paging
            data = WebDocumentSystem.Document.DocumentHelper.GetDocumentList();
            
            var pageSize = 10;
            var pageQuery = Request.QueryString["page"];
            Int32 pageNumber = 1;
            if (pageQuery != null)
                pageNumber = Int32.Parse(pageQuery);

            page_data = WebDocumentSystem.Document.PagingExtensions.Page(data, pageNumber, pageSize);
        }
        protected IQueryable<Models.Document> data;
        protected IQueryable<Models.Document> page_data;
       
    }
}