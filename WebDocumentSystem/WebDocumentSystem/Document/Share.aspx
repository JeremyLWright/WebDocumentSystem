<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Share.aspx.cs" Inherits="WebDocumentSystem.Document.ShareDocument" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Share Options for 'Document 1'</h2>
<table>
<tr><td>5 members</td><td>5 departments</td></tr>
<tr><td><asp:ListBox ID="listbox_members" runat="server"/></td><td><asp:ListBox ID="listbox_departments" runat="server" /></td></tr>
<tr><td colspan="2"><asp:Textbox ID="listbox_manual_members" runat="server"/></td></tr>
<tr>
    <td><asp:Button ID="btn_leave_folder" Text="Leave Folder" runat="server" /></td><td><asp:Button ID="btn_done" Text="Done" runat="server" /></td></tr>
</table>
</asp:Content>
