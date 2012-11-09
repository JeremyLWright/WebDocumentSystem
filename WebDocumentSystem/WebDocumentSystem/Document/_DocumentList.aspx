<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_DocumentList.aspx.cs" Inherits="WebDocumentSystem.Document._DocumentList" %>

<% try { %>
<table class="table table-hover table-condensed">
        <thead>
            <th>Title</th>
            <th>Owner</th>
            <th>Last Modified</th>
            <th>Status</th>
            <th>Access</th>
        </thead>
        <tbody>
        <% foreach (var document in page_data) %>
        <% { %>
            <tr 
                <%if (document.Deleted) { %>
                    class="muted"
                <%} %>
            data-documentId="<%:document.Id %>" onclick="document_row_click(this)">
                <td><a href="View.aspx?DocumentId=<%:document.Id%>"><%: document.Name%></a></td>
                <td><%: document.Owner.Name%></td>
                <td><%: document.LastModified%></td>
                <!-- Status -->
                <% if ((bool)document.IsLocked)
                   { %>
                    <td onclick="document_lock_click(this)" data-lock="true"><img alt="Locked" src="../Images/glyphicons_203_lock.png" /></td>
                <% }
                   else
                   { %>
                    <td onclick="document_lock_click(this)" data-lock="false"><img alt="" src="../Images/glyphicons_204_unlock.png" /></td>
                <% }%>
                <!-- Permission -->
                <td>
                <% if (WebDocumentSystem.Document.DocumentHelper.IsSharedDoc(document)) %>
                <% { 
                       var permissionLevel = WebDocumentSystem.Document.DocumentHelper.GetPermissionLevel(document);%>
                       <%: Enum.GetName(typeof(WebDocumentSystem.Models.Share.PermissionLevel), permissionLevel) %>
                       
                 <%} %>
                <% else %>
                <% { %>
                    <span class="text-success">Full</span>
                <% } %>
                <%if (document.Deleted)
                      { %>
                        <em>&raquo;Deleted&laquo;</em>
                        <%} %>
                </td>
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