<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebDocumentSystem.MainDocumentList" %>

<asp:Content ID="ContentJS" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript" src="../Scripts/DocumentHelper.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $('#documentListContainer').load('/Document/_DocumentList.aspx?page=<%=pageNumber %>');
    });
</script>
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
    <div id="documentListContainer">
        <!-- Loaded Via AJAX -->
    </div>

    <ul data-page="<%=pageNumber %>" class="pager">
        <li class="previous">
            <a onclick="document_list_page(this, 'prev')" href="#">&larr; Prev</a>
        </li>
        <li class="next">
            <a onclick="document_list_page(this, 'next')" href="#">Next &rarr;</a>
        </li>
    </ul>
</asp:Content>
