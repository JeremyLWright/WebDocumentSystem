<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Share.aspx.cs" Inherits="WebDocumentSystem.Document.ShareDocument" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainNav" runat="server">
    <h2>Share Options for '<%: documentName %>'</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<form method="post" runat="server">

<table class="table table-hover table-condensed">
        <thead>
            <th><%: numberUsers %> members</th>
            <th><%: numberGroups %> groups</th>
        </thead>
        <tbody>
            <tr>
                <td><asp:ListBox ID="listbox_members" runat="server"/></td>
                <td><asp:ListBox ID="listbox_groups" runat="server" /></td>
           </tr>
          <tr>
                <td colspan="2"><asp:DropDownList ID="DropDownPermissionLevel" runat="server" /></td>
          </tr>
          <tr>
                <td><asp:Button ID="btn_leave_folder" class="btn" Text="Cancel" runat="server" onclick="btn_leave_folder_Click" /></td>
                <td><asp:Button ID="btn_done" class="btn btn-primary" Text="Share" runat="server" onclick="btn_done_Click" /></td>
          </tr>
        </tbody>
</table>
</form>
</asp:Content>
