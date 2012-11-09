<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_DocumentList.aspx.cs" Inherits="WebDocumentSystem.Document._DocumentList" %>

<% try { %>
<table class="table table-hover table-condensed">
        <thead>
            <th></th>
            <th>Title</th>
            <th>Owner</th>
            <th>Last Modified</th>
            <th>Status</th>
        </thead>
        <tbody>
        <% 
            //Setup the document paging
            var data = WebDocumentSystem.Document.DocumentHelper.GetDocumentList();
            
                var pageSize = 10;
                var pageQuery = Request.QueryString["page"];
                Int32 pageNumber = 1;
                if (pageQuery != null)
                    pageNumber = Int32.Parse(pageQuery);

                var page_data = WebDocumentSystem.Document.PagingExtensions.Page(data, pageNumber, pageSize); %>

        <% foreach (var document in page_data) %>
        <% { %>
            <tr 
                <%if (document.Deleted) { %>
                    class="muted"
                <%} %>
            
            data-documentId="<%:document.Id %>" onclick="document_row_click(this)">
                <td><%if (document.Deleted)
                      { %>
                        <em>&raquo;Deleted&laquo;</em>
                        <%} %>
                </td>
                <td><a href="View.aspx?DocumentId=<%:document.Id%>"><%: document.Name%></a></td>
                <td><%: document.Owner.Name%></td>
                <td><%: document.LastModified%></td>
                <% if ((bool)document.IsLocked)
                   { %>
                    <td onclick="document_lock_click(this)" data-lock="true"><img alt="Locked" src="../Images/glyphicons_203_lock.png" /></td>
                <% }
                   else
                   { %>
                    <td onclick="document_lock_click(this)" data-lock="false"><img alt="" src="../Images/glyphicons_204_unlock.png" /></td>
                <% }%>
            </tr>
        <% } %>
            
            

        </tbody>
    </table>
    <%
        }
    catch (NullReferenceException)
            {%>
                <p class="text-info">No Documents Available.</p>
          <%  }%>