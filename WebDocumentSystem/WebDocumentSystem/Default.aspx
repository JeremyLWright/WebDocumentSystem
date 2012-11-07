<%@ Page Title="Welcome to WebDoc" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebDocumentSystem._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="ContentNav" ContentPlaceHolderID="MainNav" runat="server">
<% Session.Abandon(); %>
    <h2>
        Welcome to Group 4's WebDoc
    </h2>
   
</asp:Content>

 <asp:Content ContentPlaceHolderID="SideBarContent" runat="server">
 <ul id="Sponsorship" class="nav nav-list">
        <li class="nav-header">Sponsorship</li>
        <li>WebDoc has been brought to you by the letter <em>P</em> and the number <em>0b10</em>
 </li>
 <li>In coorperation with Lilly, the hungry muppet who lives on a breadline.</li>
    </ul>
 
 </asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<center>
    <p>
        Prepare for a new pleasure in document management.
    </p> 
    <p>
        <a href="Account/Login.aspx" class="btn btn-primary btn-large">Login</a>
    </p>
    </center>
</asp:Content>
