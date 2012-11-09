<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="USR_login1.ascx.cs" Inherits="SSproject.USR_login1" %>

<asp:Table ID="tbl_login" runat="server">
    <asp:TableHeaderRow>
        <asp:TableCell>
            <asp:Label ID="lbl_reg_success" Text="" runat="server">
            </asp:Label></asp:TableCell></asp:TableHeaderRow>
    <asp:TableRow>
        <asp:TableCell>
        </asp:TableCell>
        <asp:TableCell>
            </asp:TableCell>
        <asp:TableCell ID="lbl_display" runat="server"></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="tr_rw1">
        <asp:TableCell>
            <asp:Label ID="lbl_row1" Text="Username" runat="server"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txb_usrname" runat="server"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="tr_rw2">
        <asp:TableCell>
            <asp:Label ID="lbl_rw2" Text="Password" runat="server"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txb_password" TextMode="password" runat="server">
            </asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="tr_rw3">
        <asp:TableCell>
            <asp:Button ID="btn_submit" class="btn btn-primary" runat="server" Text="Submit" OnClick="validate_login" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>

