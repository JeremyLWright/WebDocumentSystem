<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebDocumentSystem.MainDocumentList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="SideBarContent" runat="server">
    <ul class="nav nav-list">
              <li class="nav-header">Revision Histroy</li>
              <li class="active"><a href="#">Revison 10</a></li>
              <% for (int i = 9; i > 0; i--) %>
			  <% { %>
			        <li><a href="#">Revision <%= i %> </a></li>
			  <% } %>  
            </ul>
</asp:Content>

<asp:Content ID="ContentNav" ContentPlaceHolderID="MainNav" runat="server">
<form id="SearchBox" action="Search.aspx" class="navbar-search pull-left" method="post">
  <input type="text" class="search-query" placeholder="Search"/>
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
            <tr>
                <td><input type="checkbox" /></td>
                <td><a href="View.aspx?Id=<%=document.Id%>"><%= document.Name %></a></td>
                <td>Bucky</td>
                <td><%= DateTime.Now %></td>
                <% if ((bool)document.IsLocked)
                   { %>
                    <td><img alt="Locked" src="../Images/glyphicons_203_lock.png" /></td>
                <% }
                   else
                   { %>
                    <td><img alt="" src="../Images/glyphicons_204_unlock.png" /></td>
                <% }%>
            </tr>
        <% } %>
        </tbody>
    </table>
</asp:Content>
