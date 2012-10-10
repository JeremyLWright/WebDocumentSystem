<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="WebDocumentSystem.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <asp:TextBox ID="textbox_search" runat="server"></asp:TextBox>
    <asp:Button ID="btn_search" runat="server" Text="Search"></asp:Button>
    <br />
     <asp:ListBox ID="listbox_documents" runat="server"></asp:ListBox>
     <br />
     <asp:Button ID="btn_done" runat="server" Text="Done"></asp:Button>
</asp:Content>
