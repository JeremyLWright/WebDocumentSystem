<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="WebDocumentSystem.Document.Documentview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript" src="../Scripts/DocumentHelper.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $('#DocumentNotes').load('/Document/_DocumentMetaData.aspx?DocumentId=<%=Request.QueryString["DocumentId"]%>');
    });
</script>
</asp:Content>

<asp:Content ID="ContentNav" ContentPlaceHolderID="MainNav" runat="server">
<input type=checkbox ID="checkbox_lock" text="Lock"/>
<br />

<a class="btn" id="btn_download" href="_DocumentDownloader.aspx?DocumentId=<%=safeDocumentId %>">Download</a>
<a class="btn" id="btn_revisions" href="Revision.aspx?DocumentId=<%=safeDocumentId %>">Revision</a>
<a class="btn" id="btn_update" href="DocumentUpload.aspx?DocumentId=<%=safeDocumentId %>">Update</a>
</asp:Content>

<asp:Content ID="DocumentNotes" ContentPlaceHolderID="SideBarContent" runat="server">
    <ul id="DocumentNotes" class="nav nav-list">
        <li class="nav-header">Document Notes</li>
        <!-- Loaded via AJAX -->
    </ul>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Document History</h3>
    
</asp:Content>
