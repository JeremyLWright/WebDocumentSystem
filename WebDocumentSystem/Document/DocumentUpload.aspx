<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="DocumentUpload.aspx.cs" Inherits="Test._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        .style2
        {
            font-family: Verdana;
        }
        .style3
        {
            width: 100%;
        }
        .style4
        {
            height: 45px;
            text-align: left;
        }
        .style5
        {
            width: 295px;
            text-align: left;
        }
        .style6
        {
            height: 45px;
            width: 295px;
            text-align: left;
        }
        .style7
    {
            width: 309px;
            text-align: left;
        }
    .style8
    {
        height: 45px;
        width: 309px;
            text-align: left;
        }
        .style9
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 class="style1">
        <span class="style2">Upload Document</span><br />
    </h1>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;<table class="style3">
            <tr>
                <td class="style5">
                    User Id :
                </td>
                <td class="style7">
                    <asp:TextBox ID="tb_userid" runat="server" style="text-align: left"></asp:TextBox>
                </td>
                <td class="style9">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    Upload Document : 
                </td>
                <td class="style7">
        <asp:FileUpload ID="FileUpload_doc" runat="server" style="margin-bottom: 0px" />
                </td>
                <td class="style9">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    Enter a name for the document :
                </td>
                <td class="style7">
        <asp:TextBox ID="tb_name" runat="server" Width="217px"></asp:TextBox>
                </td>
                <td class="style9">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="tb_name" 
                        ErrorMessage="Please enter a name for the document" Font-Bold="True" 
                        Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style6">
                </td>
                <td class="style8">
        <asp:Button ID="btn_upload" runat="server" onclick="btn_upload_Click" Text="Upload" 
                        Height="30px" Width="98px" />
                </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
        <asp:Label ID="lbl_msg" runat="server"></asp:Label>
                </td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
