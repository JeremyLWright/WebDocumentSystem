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
<asp:CheckBox ID="checkbox_lock" runat="server" Text="Lock"/>
<br />
<asp:Button ID="btn_download" runat="server" Text="Download" />
<asp:Button ID="btn_revisions" runat="server" Text="Revisions" />
<asp:Button ID="btn_update" runat="server" Text="Update" />
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
