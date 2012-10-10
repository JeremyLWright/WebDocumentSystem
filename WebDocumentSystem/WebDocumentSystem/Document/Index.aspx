<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebDocumentSystem.MainDocumentList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="SideBarContent" runat="server">
    <ul class="nav nav-list">
              <li class="nav-header">Revision Histroy</li>
              <li class="active"><a href="#">Revison 10</a></li>
              <% for (int i = 9; i > 0; i--) %>
			  <% { %>
			        <li><a href="#">Revision <%= i %> </a></li>
			  <% } %>  
            </ul>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="textbox_search" runat="server"></asp:TextBox>
    <asp:Button ID="btn_search" runat="server" Text="Search" 
        onclick="btn_search_Click"></asp:Button>
    <br />
    <asp:Button ID="btn_upload" runat="server" Text="Upload"></asp:Button>
    <asp:Button ID="btn_download" runat="server" Text="Download"></asp:Button>
    <asp:Button ID="btn_delete" runat="server" Text="Delete"></asp:Button>
    <asp:Button ID="btn_share" runat="server" Text="Share"></asp:Button>
    <br />
    <asp:ListBox ID="listbox_documents" runat="server"></asp:ListBox>
    <asp:ListBox ID="listbox_auditlog" runat="server"></asp:ListBox>
</asp:Content>
