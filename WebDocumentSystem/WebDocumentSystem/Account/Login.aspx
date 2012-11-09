<%@ Page MasterPageFile="~/Site.master" Inherits="System.Web.UI.Page"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<%@ Register TagPrefix="tp_login" TagName="tn_login" Src="~/Account/USR_login1.ascx" %>
<asp:Content ID="Nav" ContentPlaceHolderID="MainNav" runat="server">
<h3>Login</h3>
<a class="info" href="Register.aspx">New user? Register here</a>
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" Runat="Server">
<form runat="server">
<tp_login:tn_login ID="MainContent" runat="server"> </tp_login:tn_login>
</form>
</asp:Content>


