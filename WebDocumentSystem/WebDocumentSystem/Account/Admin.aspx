<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebDocumentSystem.Account.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SideBarContent" runat="server">
    <ul>
<% if (request != null)
   { %>
<li>Username: <%=request.User.Name%></li>
<li>Email: <%=request.User.Email%></li>
<li>Role: <%= Enum.GetName(typeof(WebDocumentSystem.Models.User.Roles), request.User.Role)%></li>
<li>Password Score: <%= Enum.GetName(typeof(BusinessObjects.PasswordScore), request.PasswordStrength)%></li>
<% } %>
</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainNav" runat="server">
    <form id="Form1" runat="server" method="post">
<% if (request != null)
   { %>
<table>
    <tr>
        <td>Role:</td>
        <td><asp:DropDownList ID="RoleDropDown" runat="server"></asp:DropDownList></td>
   </tr>

    <tr>
        <td>Group:</td>
        <td><asp:DropDownList ID="GroupDropDown" runat="server"></asp:DropDownList></td>
    </tr>

    <tr>
        <td><asp:Button ID="Button1" runat="server" class="btn btn-large btn-danger" Text="Deny" onclick="Deny_Click" /> </td>
        <td><asp:Button ID="Button2" runat="server" class="btn btn-large btn-primary" Text="Approve" onclick="Approve_Click" /></td>
    </tr>
    </table>
        <asp:HiddenField ID="RequestId" runat="server" />
        <% }
   else
   { %>
        <h3>All accounts approved.</h3>
        <% }%>
</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

</asp:Content>
