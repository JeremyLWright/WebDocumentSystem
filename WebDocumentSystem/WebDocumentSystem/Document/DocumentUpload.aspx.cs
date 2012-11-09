using System;
using System.Data.Sql;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;
using WebDocumentSystem.Account;
using WebDocumentSystem.BusinessLogic;

namespace WebDocumentSystem.Document
{
    public partial class DocumentUpload : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            var check = new AuthenticatedUser(); //Probably not idiomatic to C#, but I miss Python, why don't attributes work like decorators, I'm sad now.

            using (var ctx = new WebDocEntities())
            {

                if (Request.QueryString["DocumentId"] != null)
                {
                    var DocumentId = Request.QueryString.GetValue<int>("DocumentId");
                    var workingDocument = (from c in ctx.Documents
                                           where c.Id == DocumentId
                                           select c).First();
                    documentName = workingDocument.Name;
                    hid_documentId.Value = workingDocument.Id.ToString();
                    UploadReplaceMode = true;
                }
                else
                {
                    UploadReplaceMode = false;
                }

            }
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            this.Load += new System.EventHandler(this.Page_Load);
            base.OnInit(e);
        }

        public void FilenameCheck(Object sender, ServerValidateEventArgs args)
        {
            if (hid_documentId.Value != "")
            {
                using (var ctx = new WebDocEntities())
                {
                    var DocumentId = Convert.ToInt32(hid_documentId.Value);
                    var workingDocument = (from c in ctx.Documents
                                           where c.Id == DocumentId
                                           select c).First();
                    if (FileUpload_doc.FileName != workingDocument.Name)
                    {
                        args.IsValid = false;
                        return;
                    }
                }
            }
            args.IsValid = true;
        }

        protected void btn_upload_Click(object sender, EventArgs e)
        {

            if (FileUpload_doc.PostedFile != null && Page.IsValid)
            {
                using (var ctx = new WebDocEntities())
                {
                    Models.Document workingDocument;

                    if (hid_documentId.Value != "") //Update an existing document
                    {
                        var DocumentId = Int32.Parse(hid_documentId.Value);

                        workingDocument = (from c in ctx.Documents
                                           where c.Id == DocumentId
                                           select c).First();
                    }
                    else //Create a new document
                    {
                        var userName = HttpContext.Current.User.Identity.Name;
                        var currentUser = (from c in ctx.Users
                                           where c.Name == userName
                                           select c).First();
                        workingDocument = new Models.Document();
                        workingDocument.Name = FileUpload_doc.FileName;
                        workingDocument.Owner = currentUser;
                    }


                    byte[] doc = new byte[FileUpload_doc.PostedFile.ContentLength];
                    HttpPostedFile mydoc = FileUpload_doc.PostedFile;
                    mydoc.InputStream.Read(doc, 0, FileUpload_doc.PostedFile.ContentLength);
                    var documentData = new Models.DocumentData();
                    workingDocument.DocumentDatas.Add(documentData);
                    if (txt_encrypt.Text == "")
                    {
                        documentData.DocContent = doc;
                    }
                    else
                    {
                        var password = txt_encrypt.Text;
                        var salt = Encryptor.GetSalt();
                        var encryptedData = Encryptor.Encrypt(password, doc, salt);
                        documentData.Encrypted = true;
                        documentData.Salt = salt;
                        documentData.DocContent = encryptedData;
                    }

                    ctx.SaveChanges(); //Save changes so the data's Id populates
                    workingDocument.Deleted = false; //If we're updating the document, we're undeleting it.
                    workingDocument.Revision = documentData.Id; //Point the document to this version.
                    ctx.SaveChanges();

                    Response.Redirect("Index.aspx");
                }
            }
            else
                lbl_msg.Text = "Cannot Upload Document";
        }

        protected bool UploadReplaceMode;
        protected string documentName;
    }
}



