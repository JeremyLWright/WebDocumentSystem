<%@ Page MasterPageFile="~/Site.master" Inherits="System.Web.UI.Page"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<%@ Register TagPrefix="tp_login" TagName="tn_login" Src="~/Account/USR_sysadmin.ascx" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" Runat="Server">
<form runat="server">
<tp_login:tn_login ID="MainContent" runat="server"> </tp_login:tn_login>
</form>
</asp:Content>


