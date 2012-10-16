<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainDocumentList.aspx.cs" Inherits="WebDocumentSystem.MainDocumentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="textbox_search" runat="server"></asp:TextBox>
    <asp:Button ID="btn_search" runat="server" Text="Search"></asp:Button>
    <br />
    <asp:Button ID="btn_upload" runat="server" Text="Upload"></asp:Button>
    <asp:Button ID="btn_download" runat="server" Text="Download"></asp:Button>
    <asp:Button ID="btn_delete" runat="server" Text="Delete"></asp:Button>
    <asp:Button ID="btn_share" runat="server" Text="Share"></asp:Button>
    <br />
    <asp:ListBox ID="listbox_documents" runat="server"></asp:ListBox>
    <asp:ListBox ID="listbox_auditlog" runat="server"></asp:ListBox>
</asp:Content>
