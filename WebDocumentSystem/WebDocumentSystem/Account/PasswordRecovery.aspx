<%@ Page MasterPageFile="~/Site.master" Inherits="System.Web.UI.Page"%>

<%@ Register TagPrefix="tp_login" TagName="tn_login" Src="~/USR_password_recover.ascx" %>

<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="MainContent">
    <tp_login:tn_login ID="MainContent" runat="server"> </tp_login:tn_login>
</asp:Content>

   
