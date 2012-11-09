<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Revision.aspx.cs" Inherits="WebDocumentSystem.Document.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript" src="../Scripts/DocumentHelper.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#btn-update").click(function () {
            $("#version_form").submit();
        });
    });
</script>
</asp:Content>

<asp:Content ID="DocumentNotes" ContentPlaceHolderID="SideBarContent" runat="server">
    <ul id="DocumentNotes" data-selected-document="0" class="nav nav-list">
        <li class="nav-header">Document Notes</li>
    </ul>
</asp:Content>

<asp:Content ID="ContentNav" ContentPlaceHolderID="MainNav" runat="server">
    <div class="btn-group">
        <button id="btn-update" class="btn">Update</button>
        <button id="btn-cancel" class="btn">Cancel</button>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<form id="version_form" action="Revision.aspx" name="revision" method="post">
<input type="hidden" name="DocumentId" value="<%: documentId %>">
<table class="table table-hover table-condensed">
        <thead>
            <th></th>
            <th></th>
        </thead>
        <tbody>
        <%  var versions = GetVersions();
            int i = versions.Count() ; 
           %>
        <% foreach (var version in versions) %>
        <% { %>
            <tr>
                <td><input name="versions" data-versionId="<%:version.Id %>" type="radio" value="<%:version.Id %>" /></td>
                <td>Version <%:i--%></td>
            </tr>
        <% } %>
         </tbody>
    </table>
    </form>
</asp:Content>
