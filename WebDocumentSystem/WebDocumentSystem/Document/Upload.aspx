<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="WebDocumentSystem.Document.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:TextBox ID="textbox_filename" runat="server"/>
<asp:Button ID="btn_browse" Text="Browse" runat="server"/>
<br />
<asp:CheckBox ID="checkbox_encrypt" runat="server" Text="Encrypt"/>
<br />
<asp:Button ID="btn_upload" runat="server" Text="Upload" />

</asp:Content>
