<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="USR_password_recover.ascx.cs"
    Inherits="SSproject.USR_password_recover" %>
<html>
<asp:Table runat="server">
    <asp:TableRow runat="server" ID="row_1">
        <asp:TableCell>
            <asp:Label runat="server" ID="lbl_user_id" Text="Please enter UserID"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox runat="server" ID="txb_user_id"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="row_2" runat="server">
        <asp:TableCell>
            <asp:Label ID="lbl1" runat="server" Text="Please answer the question: "></asp:Label></asp:TableCell>
        <asp:TableCell>
            <asp:Label runat="server" ID="lbl_question"></asp:Label></asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" ID="lbl2"></asp:Label></asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell><asp:Label ID="lbl_4" Text="Please Provide the Answer: " runat="server"></asp:Label></asp:TableCell><asp:TableCell>
            <asp:TextBox ID="txb_answer" runat="server"></asp:TextBox></asp:TableCell></asp:TableRow>
            <asp:TableRow><asp:TableCell><asp:Button runat="server" ID=btn_submit Text="Submit"/></asp:TableCell></asp:TableRow>
</asp:Table>
</html>
