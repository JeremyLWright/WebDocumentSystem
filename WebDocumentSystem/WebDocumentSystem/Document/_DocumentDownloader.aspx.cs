using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;
using System.IO;
using WebDocumentSystem.BusinessLogic;

namespace WebDocumentSystem.Document
{
    public partial class _DocumentDownloader : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            const int blockSize = 4096;
            ctx = new WebDocEntities();
            requestedId = Int32.Parse(Request.QueryString["DocumentId"]);
            var password = Request.QueryString.GetValue<string>("P");
            var doc = (from d in ctx.Documents
                      where d.Id == requestedId
                      select d).First();

            var data = (from d in ctx.DocumentDatas
                        where d.Id == doc.Revision
                        select d).FirstOrDefault();
            if (data != null)
            {
                byte[] buffer = data.DocContent;
                if (data.Encrypted)
                {
                    buffer = Encryptor.Decrypt(password, data.DocContent, data.Salt);
                }
                Response.ContentType = "text/plain";  //Or other you need
                Response.AddHeader("Content-Disposition", "attachment; filename=\"" + doc.Name + "\"");
                Response.BinaryWrite(buffer);
                Response.Flush();
                Response.Close();
                Response.End();
            }
            else
            {
                Response.Redirect("~/Document/Index.aspx"); //This is an error, we couldn't find the document data.
            }
        }


        protected WebDocEntities ctx;
        protected int requestedId;
    }
}