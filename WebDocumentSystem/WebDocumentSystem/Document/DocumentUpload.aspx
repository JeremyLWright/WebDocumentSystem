﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="DocumentUpload.aspx.cs" Inherits="WebDocumentSystem.Document.DocumentUpload" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
  
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <!--<h1 class="style1">
        <span class="style2">Upload Document</span><br />
    </h1>-->
    <form runat="server" id="UploadDocument" enctype="multipart/form-data" action="DocumentUpload.aspx" class="form" method="post">
            <table>
            <tr>
                <td>
                    Upload Document : 
                </td>
                <td>
                    <asp:FileUpload runat="server" type="file" name="FileUpload_doc" id="FileUpload_doc" />
                </td>
            </tr>
            <tr>
                <td>
                    Enter a name for the document :
                </td>
                <td>
                    <asp:TextBox runat="server" type="text" name="tb_name" id="tb_name"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button class="btn" ID="btn_upload" runat="server" Text="Upload" />
                </td>
                <td>
                <asp:Label ID="lbl_msg" runat="server"></asp:Label>
                </td>
            </tr>
            </table>
    </form>          
</asp:Content>