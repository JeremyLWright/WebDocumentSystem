<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_DocumentMetaData.aspx.cs" Inherits="WebDocumentSystem.Document._DocumentMetaData" %>
    <%var documentId =  Int32.Parse(Request.QueryString["DocumentId"]);%>
    <li class="nav-header"><%= GetDocumentName(documentId) %>'s Notes</li>
        <% var notes = GetDocumentNotesList(documentId);
               foreach (var note in notes)
               {
                %>
                <li><%= note.Note%></li>
            <% } %>

