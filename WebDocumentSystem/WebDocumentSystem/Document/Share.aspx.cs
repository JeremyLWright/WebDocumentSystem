using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Account;
using WebDocumentSystem.Models;
using System.Diagnostics;

namespace WebDocumentSystem.Document
{
    public partial class ShareDocument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            documentId = Request.QueryString.GetValue<int>("DocumentId");
            using (var ctx = new WebDocEntities())
            {
                var document = (from c in ctx.Documents
                                where c.Id == documentId
                                select c).First();
                documentName = document.Name;

                var users = (from c in ctx.Users
                             select c);
                foreach(var user in users)
                {
                    listbox_members.Items.Add(new ListItem(user.Name));
                }
                numberUsers = users.Count();

               
            }
            var groups = Enum.GetNames(typeof(Models.User.Groups));
            foreach (var group in groups)
            {
                listbox_groups.Items.Add(new ListItem(group));
            }
            numberGroups = groups.Count();

            var permissions = Enum.GetNames(typeof(Models.Share.PermissionLevel));
            foreach (var permission in permissions)
            {
                DropDownPermissionLevel.Items.Add(new ListItem(permission));
            }
        }

        protected int documentId;
        protected int numberUsers;
        protected int numberGroups;
        protected string documentName;

        protected void btn_done_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Debug.WriteLine("Form Posted.");
                var selected_group = listbox_groups.SelectedValue;
                var selected_user = listbox_members.SelectedValue;
                Debug.WriteLine("Group: " + selected_group);
                Debug.WriteLine("User: " + selected_user);
                using (var ctx = new WebDocEntities())
                {
                    var document = (from c in ctx.Documents
                                    where c.Id == documentId
                                    select c).First();
                    if(DocumentHelper.CanAction(document, Models.Document.DocumentActions.Share))
                    {

                        if (selected_user != "")
                        {
                            var share_doc = new Models.Share();
                            share_doc.Created = DateTime.Now;
                            var user = (from c in ctx.Users
                                        where c.Name == selected_user     
                                        select c).FirstOrDefault();
                            share_doc.Document = document;
                            share_doc.User = user;
                            share_doc.Permission = (int)Enum.Parse(typeof(Share.PermissionLevel), DropDownPermissionLevel.SelectedValue);
                            ctx.Shares.AddObject(share_doc);
                            ctx.SaveChanges();
                        }
                    } else {
                        Response.Redirect("Index.aspx");
                    }


                }
                Response.Redirect("View.aspx?DocumentId=" + documentId);
            }
        }

        protected void btn_leave_folder_Click(object sender, EventArgs e)
        {
            Response.Redirect("View.aspx?DocumentId=" + documentId);
        }
    }
}