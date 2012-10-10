<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Revision.aspx.cs" Inherits="WebDocumentSystem.Document.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h3>Past Versions of 'Document 1'</h3>
<asp:ListBox ID="listbox_revisions" runat="server" />
<br />
<asp:Button ID="btn_cancel" runat="server" Text="Cancel" 
        onclick="btn_cancel_Click"/>
<asp:Button ID="btn_update" runat="server" Text="Update" 
        onclick="btn_update_Click"/>

</asp:Content>
