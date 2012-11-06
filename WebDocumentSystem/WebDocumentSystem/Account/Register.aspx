<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebDocumentSystem.Account.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script language="javascript" type="text/javascript">

    function formReset() {
        var temp1 = document.getElementById('<%=txb_user_id.ClientID %>');
        temp1.value = "";
        var temp2 = document.getElementById('<%=txb_email.ClientID %>');
        temp2.value = "";
        var temp3 = document.getElementById('<%=txb_pwd.ClientID %>');
        temp3.value = "";
        var temp4 = document.getElementById('<%=txb_pwdc.ClientID %>');
        temp4.value = "";
        var temp5 = document.getElementById('<%=ddl_usrole.ClientID %>');
        temp5.value = "";

        if (validate_uname(uname)) {
            if (validate_email(uemail)) {
                if (validate_passwrd(uname, upwd, upwdc)) {
                    if (validate_usr_role(urole)) {
                    }
                }
            }
        }
        return false;
    }
      
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SideBarContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainNav" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
<form id="Form1" runat="server">
 
    <asp:Table ID="Table1"  runat="server">
     <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lbl_name" Text="Name" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txb_name" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lbl_user_id" Text="User ID" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
            <asp:TextBox ID="txb_user_id" runat="server"></asp:TextBox>
                            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbl_error_user_id" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lbl_email" Text="Enter Your Email ID" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txb_email" runat="server">
                </asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbl_errormail" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lbl_pwd" Text="Enter Your Password" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txb_pwd" runat="server" TextMode="Password">
                </asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lbl_pwdc" Text="Reenter Your Password" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txb_pwdc" runat="server" TextMode="Password">
                </asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                 <asp:Label ID="lbl_usrole" Text="Requested User Role" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddl_usrole"  runat="server" AppendDataBoundItems="true">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
      

  
    <asp:TableRow ID="TableRow1" runat="server">
        <asp:TableCell ID="TableCell1" runat="server"><asp:Label runat="server" ID=lbl_quest Text="Security Question"></asp:Label></asp:TableCell>
        <asp:TableCell ID="TableCell2" runat="server"><asp:DropDownList runat="server" ID=ddl_questions AppendDataBoundItems="true"></asp:DropDownList></asp:TableCell>
        </asp:TableRow>
        

        <asp:TableRow ID="TableRow2" runat="server">
        <asp:TableCell ID="TableCell3" runat="server"><asp:Label runat="server" ID=lbl_ans1 Text="Answer"></asp:Label></asp:TableCell>
        <asp:TableCell ID="TableCell4" runat="server"><asp:TextBox runat="server" ID=txb_ans1 ></asp:TextBox></asp:TableCell>
        </asp:TableRow>



    <asp:TableRow ID="TableRow3" runat="server">
        <asp:TableCell ID="TableCell5" runat="server"><asp:Label runat="server" ID="lbl_quest2" Text="Your Own Question"></asp:Label></asp:TableCell>
        <asp:TableCell ID="TableCell6" runat="server"><asp:TextBox runat="server" ID=txb_cust_quest ></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow4" runat="server">
        <asp:TableCell ID="TableCell7" runat="server"><asp:Label runat="server" ID=lbl_cust_ans Text="Answer"></asp:Label></asp:TableCell>
        <asp:TableCell ID="TableCell8" runat="server"><asp:TextBox runat="server" ID=txb_cust_ans ></asp:TextBox></asp:TableCell>
        </asp:TableRow>
          <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClientClick="javascript:formValidation();" OnClick="valid_registration" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btn_rst" runat="server" Text="Reset" OnClientClick="javascript:formReset();"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </form>

</asp:Content>
