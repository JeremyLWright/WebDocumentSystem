using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDocumentSystem.Document
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DocumentView.aspx");
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {

        }
    }
}