<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Documentview.aspx.cs" Inherits="WebDocumentSystem.Document.Documentview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:CheckBox ID="checkbox_lock" runat="server" Text="Lock"/>
<br />
<asp:Button ID="btn_download" runat="server" Text="Download" />
<asp:Button ID="btn_revisions" runat="server" Text="Revisions" />
<asp:Button ID="btn_update" runat="server" Text="Update" />
<h3>Document History</h3>
<asp:ListBox ID="listbox_history" runat="server" />

</asp:Content>
