using System;
using System.Data.Sql;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;

namespace WebDocumentSystem.Document
{
    public partial class DocumentUpload : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ctx = new WebDocEntities();
            var upload = Request.Form["FileUpload_doc"];
            this.btn_upload.Click  += new System.EventHandler(this.btn_upload_Click);
            this.Load += new System.EventHandler(this.Page_Load);
            base.OnInit(e);
            if (upload != null)
            {

            }

        }

        protected void btn_upload_Click(object sender, EventArgs e)
        {
                
                if (FileUpload_doc.PostedFile != null)
                {
                    if (txt_encrypt.Text == "")
                    {
                        byte[] doc = new byte[FileUpload_doc.PostedFile.ContentLength];
                        HttpPostedFile mydoc = FileUpload_doc.PostedFile;
                        mydoc.InputStream.Read(doc, 0, FileUpload_doc.PostedFile.ContentLength);

                        var document = new Models.Document();
                        document.Name = tb_name.Text;

                        var documentData = new Models.DocumentData();

                        document.DocumentDatas.Add(documentData);
                        document.Revision = documentData.Id;
                        documentData.DocContent = doc;

                        ctx.Documents.AddObject(document);
                    }
                    else
                    {
                        //Perform Encryption
                    }
                    ctx.SaveChanges();
                    Response.Redirect("Index.aspx");

                }
                else
                    lbl_msg.Text = "Cannot Upload Document";
                 

        }
        protected WebDocEntities ctx;
    }
}



