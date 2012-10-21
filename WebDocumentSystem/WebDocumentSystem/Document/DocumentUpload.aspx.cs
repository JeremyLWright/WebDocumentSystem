using System;
using System.Data.Sql;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Test
{
    public partial class _Default : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        }

        protected void btn_upload_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload_doc.HasFile)
                {
                    byte[] doc = new byte[FileUpload_doc.PostedFile.ContentLength];
                    HttpPostedFile mydoc = FileUpload_doc.PostedFile;
                    mydoc.InputStream.Read(doc, 0, FileUpload_doc.PostedFile.ContentLength);

                    SqlCommand cmd = new SqlCommand("Insert into docs (document_name, user_id, is_locked, locked_by, document_content) values (@doc_name, @u_id, 1, 0, @doc_content)", con);
                    SqlParameter doc_name = new SqlParameter("@doc_name", SqlDbType.NVarChar);
                    doc_name.Value = tb_name.Text;
                    cmd.Parameters.Add(doc_name);

                    SqlParameter u_id = new SqlParameter("@u_id", SqlDbType.Int);
                    u_id.Value = Convert.ToInt32(tb_userid.Text);
                    cmd.Parameters.Add(u_id);

                    SqlParameter doc_content = new SqlParameter("@doc_content", SqlDbType.VarBinary);
                    doc_content.Value = doc;
                    cmd.Parameters.Add(doc_content);

                    con.Open();
                    lbl_msg.Text = "Document Uploaded";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else
                    lbl_msg.Text = "Cannot Upload Document";
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
    }
}



