<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="USR_register1.ascx.cs"
    Inherits="SSproject.USR_register1" %>
<%--<%@  Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
  <%--  CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>--%>
  <script language="javascript" type="text/javascript">
      function formValidation() {
          var temp1 = document.getElementById('<%=txb_user_id.ClientID %>');
          var uname = temp1.value;
          var temp2 = document.getElementById('<%=txb_email.ClientID %>');
          var uemail = temp2.value;
          var temp3 = document.getElementById('<%=txb_pwd.ClientID %>');
          var upwd = temp3.value;
          var temp4 = document.getElementById('<%=txb_pwdc.ClientID %>');
          var upwdc = temp4.value;
          var temp5 = document.getElementById('<%=ddl_usrole.ClientID %>');
          var urole = temp5.value;

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

      function validate_passwrd(uname, upwd, upwdc) {
          var invalid = " ";
          if (upwd == "") {
              alert("Error: Password cannot be blank!");
              upwd.focus();
              return false;
          }
          if (document.getElementById('<%=txb_pwd.ClientID %>').value.indexOf(invalid) > -1) {
              alert("Error: No spaces are allowed!");
              upwd.focus();
              return false;
          }

          if (upwd.length < 8) {
              alert("Error: Password must contain at least eight characters!");
              upwd.focus();
              return false;
          }
          if (upwd == uname) {
              alert("Error: Password must be different from Username!");
              upwd.focus();
              return false;
          }
          re = /[0-9]/;
          if (!re.test(upwd)) {
              alert("Error: password must contain at least one number (0-9)!");
              upwd.focus();
              return false;
          }
          re = /[a-z]/;
          if (!re.test(upwd)) {
              alert("Error: password must contain at least one lowercase letter (a-z)!");
              upwd.focus();
              return false;
          }
          re = /[A-Z]/;
          if (!re.test(upwd)) {
              alert("Error: password must contain at least one uppercase letter (A-Z)!");
              upwd.focus();
              return false;
          }
          re = /[!@#$%^&*{}<>|,:;()|.`?~_]/
          // " [] ' \/
          if (!re.test(upwd)) {
              alert("error: password must contain at least one specail character!");
              upwd.pwd1.focus();
              return false;
          }
          if (upwd != upwdc) {
              alert("Error: Passwords mismatch");
              upwd.focus();
              return false;
          }
          return true;
      }


      function validate_uname(uname) {
          if (uname == "") {
              alert("error: username cannot be blank!");
              uname.focus();
              return false;
          }
          re = /^\w+$/;
          if (!re.test(uname)) {
              alert("error: username must contain only letters, numbers and underscores!");
              uname.focus();
              return false;
          }
          return true;
      }

      function validate_email(uemail) {
          if (uemail == "") {
              alert("error: email cannot be blank!");
              uemail.focus();
              return false;
          }
          re = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
          if (!re.test(uemail)) {
              alert("error: email address entered is invalid!");
              uemail.focus();
              return false;
          }
          return true;
      }

      function validate_usr_role(urole) {
          if (urole == "-1") {
              alert("Error: Please select a valid user role!");
              urole.focus();
              return false;
          }
          else {
              return true;
          }
      }
    </script>
    <asp:Table  runat="server">
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
        <asp:TableCell ID="TableCell5" runat="server"><asp:Label runat="server" ID=lbl_quest2 Text="Your Own Question"></asp:Label></asp:TableCell>
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
