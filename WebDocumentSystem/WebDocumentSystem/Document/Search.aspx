<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="WebDocumentSystem.SearchResults" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainNav" runat="server">
   <form id="SearchBox" action="Search.aspx" class="form-search" method="post">
      <input type="text" name="search_term" class="input-medium search-query" placeholder="Search"/> 
      <button id="btn-search" type="submit" class="btn">Search</button>
    </form>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <dl>
    <% foreach ( var note in releventNotes) {%>
        <% var relatedDocument = GetRelatedDocument(note); %>
        <dt><a href="View.aspx?DocumentId=<%: relatedDocument.Id %>"><%: relatedDocument.Name%></a></dt>
        <dd><%= note.Note.Replace(search_term, "<b class=\"text-info\">"+search_term+"</b>") %></dd>
    <% } %>
    <% var docs = GetSearchedDocuments(); %>
    <% foreach ( var doc in docs) {%>
        <dt><a href="View.aspx?DocumentId=<%:doc.Id%>"><%: doc.Name%></a></dt>
        <dd><em>Name Match</em></dd>
    <% } %>
    </dl>

    <a id="btn-done" class="btn" href="Index.aspx">Done</a>
</asp:Content>
