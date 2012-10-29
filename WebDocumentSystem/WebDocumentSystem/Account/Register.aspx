<%@ Page MasterPageFile="~/Site.master" Inherits="System.Web.UI.Page"%>

<%@ Register TagPrefix="tp_login" TagName="tn_login" Src="~/Account/USR_register1.ascx" %>

<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="MainContent">
<form runat="server">
    <tp_login:tn_login ID="MainContent" runat="server"> </tp_login:tn_login>
    </form>
</asp:Content>

   
