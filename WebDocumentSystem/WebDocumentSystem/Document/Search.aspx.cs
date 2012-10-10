using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDocumentSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.PreviousPage != null)
            {
                TextBox SourceTextBox = (TextBox)Page.PreviousPage.FindControl("textbox_search");
                if (SourceTextBox != null)
                {
                    textbox_search.Text = SourceTextBox.Text;
                }
            }
        }
    }
}