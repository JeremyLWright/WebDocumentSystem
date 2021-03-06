﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="WebDocumentSystem.Account.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">

        function resetForm(id) {
            $('#' + id).each(function () {
                this.reset();
            });
        }
      
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SideBarContent" runat="server">
    Please review the User's Guide.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainNav" runat="server">
    <h3>
        New User Registration</h3>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <form id="Form1" runat="server">
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lbl_name" Text="Name" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txb_name" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txb_name" ErrorMessage="Required"
                    runat="server"></asp:RequiredFieldValidator>
                <asp:CustomValidator runat="server" ID="CustomValidator1" ControlToValidate="txb_name"
                    Display="Dynamic" OnServerValidate="UsernameAvailable" ErrorMessage="Pick another Username" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lbl_error_user_id" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lbl_email" Text="Email" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txb_email" runat="server">
                
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txb_email"
                    ErrorMessage="Required" runat="server"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ControlToValidate="txb_email" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txb_pwd"
                    ErrorMessage="Required" runat="server"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lbl_pwdc" Text="Reenter Your Password" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txb_pwdc" runat="server" TextMode="Password">
                </asp:TextBox>
                <asp:CustomValidator runat="server" ID="validator_password" ControlToValidate="txb_pwd"
                    Display="Dynamic" OnServerValidate="PasswordValidate" ErrorMessage="Pick a Stronger Password."></asp:CustomValidator>
                <asp:CompareValidator ID="ProgrammaticID" ControlToValidate="txb_pwd" ControlToCompare="txb_pwdc"
                    Type="String" Operator="Equal" ErrorMessage="Passwords do not match" runat="server"> 
                </asp:CompareValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lbl_usrole" Text="Requested User Role" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddl_usrole" runat="server" AppendDataBoundItems="true">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow1" runat="server">
            <asp:TableCell ID="TableCell1" runat="server">
                <asp:Label runat="server" ID="lbl_quest" Text="Security Question"></asp:Label></asp:TableCell>
            <asp:TableCell ID="TableCell2" runat="server">
                <asp:DropDownList runat="server" ID="ddl_questions" AppendDataBoundItems="true">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow2" runat="server">
            <asp:TableCell ID="TableCell3" runat="server">
                <asp:Label runat="server" ID="lbl_ans1" Text="Answer"></asp:Label></asp:TableCell>
            <asp:TableCell ID="TableCell4" runat="server">
                <asp:TextBox runat="server" ID="txb_ans1"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4" ControlToValidate="txb_ans1" ErrorMessage="Required"
                    runat="server"></asp:RequiredFieldValidator></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LblMsg" runat="server" Text="Enter the captua code here:"></asp:Label>
                <br />
                <asp:Image ID="ImgCaptcha" runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TxtCpatcha" runat="server" Text=""></asp:TextBox>
                <asp:CustomValidator runat="server" ID="CaptuaValidator" ControlToValidate="TxtCpatcha"
                    Display="Dynamic" OnServerValidate="CaptuaValidate" ErrorMessage="Please try again."></asp:CustomValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="TxtCpatcha"
                    ErrorMessage="Required" runat="server"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:LinkButton ID="btnTryNewWords" runat="server" Font-Names="Tahoma" CausesValidation="False"
                    Font-Size="Smaller" OnClick="btnTryNewWords_Click">Can&#39;t read? Refresh Captcha Image</asp:LinkButton>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <button class="btn" onclick="resetForm('Form1');">Reset</button>
            </asp:TableCell>
            <asp:TableCell>
            <asp:Button ID="btn_submit" class="btn btn-primary" runat="server" Text="Submit" OnClick="RegisterSubmit" />
                
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </form>
</asp:Content>
