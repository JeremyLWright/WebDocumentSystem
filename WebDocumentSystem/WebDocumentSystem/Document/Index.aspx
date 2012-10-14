<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebDocumentSystem.MainDocumentList" %>
<asp:Content ID="ContentJS" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript" src="../Scripts/DocumentHelper.js"></script>
</asp:Content>

<asp:Content ID="DocumentNotes" ContentPlaceHolderID="SideBarContent" runat="server">
    <ul id="DocumentNotes" class="nav nav-list">
        <li class="nav-header">Document Notes</li>
    </ul>
</asp:Content>

<asp:Content ID="ContentNav" ContentPlaceHolderID="MainNav" runat="server">
    <form id="SearchBox" action="Search.aspx" class="form-search" method="post">
      <input type="text" name="search_term" class="input-medium search-query" placeholder="Search"/> 
      <button id="btn-search" type="submit" class="btn">Search</button>
    </form>

    <div class="btn-group">
      <button id="btn-upload" class="btn">Upload</button>
      <button id="btn-download" class="btn">Download</button>
      <button id="btn-delete" class="btn">Delete</button>
      <button id="btn-share" class="btn">Share</button>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table table-hover table-condensed">
        <thead>
            <th></th>
            <th>Title</th>
            <th>Owner</th>
            <th>Last Modified</th>
            <th>Status</th>
        </thead>
        <tbody>
        <% var data = GetDocumentList(); %>
        <% foreach (var document in data) %>
        <% { %>
            <tr data-documentId="<%=document.Id %>" onclick="document_row_click(this)">
                <td><input type="checkbox" /></td>
                <td ><a href="View.aspx?DocumentId=<%=document.Id%>"><%= document.Name %></a></td>
                <td>Bucky</td>
                <td><%= document.LastModified %></td>
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
</asp:Content>
