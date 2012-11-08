<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reg_success.aspx.cs" Inherits="WebDocumentSystem.Account.Reg_success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SideBarContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainNav" runat="server">
    <h3>Thank you for registering.</h3>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
<center>
    <p>Please Login when you account is approved.</p>
    <p>
        <a href="Account/Login.aspx" class="btn btn-primary btn-large">Login</a>
    </p>
    </center>
</asp:Content>
