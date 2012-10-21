using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;
using System.IO;

namespace WebDocumentSystem.Document
{
    public partial class _DocumentDownloader : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            const int blockSize = 4096;
            ctx = new WebDocEntities();
            requestedId = Int32.Parse(Request.QueryString["DocumentId"]);

            var doc = (from d in ctx.Documents
                      where d.Id == requestedId
                      select d).First();

            var data = (from d in ctx.DocumentDatas
                        where d.Id == doc.Revision
                        select d).First();

            using (Stream st = new MemoryStream(data.DocContent))
            {
                byte[] buffer = new byte[blockSize];

                long dataLengthToRead = st.Length;
                Response.ContentType = "text/plain";  //Or other you need
                Response.AddHeader("Content-Disposition", "attachment; filename=\"" + doc.Name + "\"");
                while (dataLengthToRead > 0 && Response.IsClientConnected)
                {
                    Int32 lengthRead = st.Read(buffer, 0, blockSize);
                    Response.OutputStream.Write(buffer, 0, lengthRead);
                    Response.Flush();
                    dataLengthToRead = dataLengthToRead - lengthRead;
                }
                Response.Flush();
                Response.Close();
            }
            Response.End();
        }


        protected WebDocEntities ctx;
        protected int requestedId;
    }
}