using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;

namespace WebDocumentSystem.Account
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ctx = new WebDocEntities();
            request = (from c in ctx.AccountRequests
                       where c.State == (int)AccountRequest.States.Pending
                            select c).FirstOrDefault();
            if (request != null)
            {

                RequestId.Value = Convert.ToString(request.Id);

                var roles = Enum.GetNames(typeof(Models.User.Roles));
                foreach (var role in roles)
                {
                    RoleDropDown.Items.Add(new ListItem(role));
                }

                var groups = Enum.GetNames(typeof(Models.User.Groups));
                foreach (var group in groups)
                {
                    GroupDropDown.Items.Add(new ListItem(group));
                }
            }
        }

        protected void Approve_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                var ctx = new WebDocEntities();
                int requestedId = Convert.ToInt32(RequestId.Value);
                var request = (from c in ctx.AccountRequests
                               where c.Id == requestedId
                               select c).FirstOrDefault();
                if (request != null)
                {
                    request.State = (int)AccountRequest.States.Approved;
                    request.User.Role = (int)Enum.Parse(typeof(User.Roles), RoleDropDown.SelectedItem.Text);
                    request.User.Group = (int)Enum.Parse(typeof(User.Groups), GroupDropDown.SelectedItem.Text);
                        
                    ctx.SaveChanges();
                }

            }
        }

        protected void Deny_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                var ctx = new WebDocEntities();
                int requestedId = Convert.ToInt32(RequestId.Value);
                var request = (from c in ctx.AccountRequests
                               where c.Id == requestedId
                               select c).FirstOrDefault();
                if (request != null)
                {
                    request.State = (int)AccountRequest.States.Revoked;
                    request.User.Role = (int)Enum.Parse(typeof(User.Roles), RoleDropDown.SelectedItem.Text);
                    request.User.Group = (int)Enum.Parse(typeof(User.Groups), GroupDropDown.SelectedItem.Text);

                    ctx.SaveChanges();
                }
            }
        }
        protected Models.AccountRequest request;
    }
}