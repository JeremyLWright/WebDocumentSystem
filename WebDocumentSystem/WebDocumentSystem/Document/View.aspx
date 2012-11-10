<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="View.aspx.cs" Inherits="WebDocumentSystem.Document.Documentview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../Scripts/DocumentHelper.js"></script>
    <script type="text/javascript">
    var password = "";
    $(document).ready(function () {
        $('#DocumentNotes').load('/Document/_DocumentMetaData.aspx?DocumentId=<%:Request.QueryString["DocumentId"]%>');
        if($("#document-menu").children().length == 0)
        {
            $("#document-menu").append('<a class="btn" href="#">Read Only</a>');
        }

        $("#btn_lock").bind("click", function (evt) {
            $.get("/Document/_DocumentLock.aspx?DocumentId=<%:safeDocumentId %>", function (data) {
                if ($('#btn_lock').html() == "Lock")
                    $('#btn_lock').html("Unlock");
                else
                    $('#btn_lock').html("Lock");
            });
        });

        $('a#btn_download').attr({target: '_blank', 
            href  : '_DocumentDownloader.aspx?DocumentId=<%:safeDocumentId %>&P='});

        <%if(documentEncrypted){ %>
                $('#Modal_encryption').modal();
                $('#modal-password-save').bind("click", 
                    function (evt){ 
                        password=$('#encryption_password').val(); 
                        $('#Modal_encryption').modal('hide'); 
                        $('a#btn_download').attr({target: '_blank', 
                    href  : '_DocumentDownloader.aspx?DocumentId=<%:safeDocumentId %>&P='+password});
                    });

                <%} %>
                
        
    });

    </script>
</asp:Content>
<asp:Content ID="ContentNav" ContentPlaceHolderID="MainNav" runat="server">
    <div class="btn-group" id="document-menu">
        <% if(WebDocumentSystem.Document.DocumentHelper.CanAction(document, WebDocumentSystem.Models.Document.DocumentActions.Lock))
           {%>
                <a class="btn" id="btn_lock" href="#">Lock</a> 
        <%} %>
        <% if (WebDocumentSystem.Document.DocumentHelper.CanAction(document, WebDocumentSystem.Models.Document.DocumentActions.Download))
           {%>
                <a class="btn" id="btn_download" href="#">Download</a>
        <% } %>
        <% if (WebDocumentSystem.Document.DocumentHelper.CanAction(document, WebDocumentSystem.Models.Document.DocumentActions.Replace_Revise))
           {%>
                <a class="btn" id="btn_revisions" href="Revision.aspx?DocumentId=<%:safeDocumentId %>">Revision</a> 
                <a class="btn" id="btn_upload" href="DocumentUpload.aspx?DocumentId=<%:safeDocumentId %>">Update</a>
        <%} %>
        <% if (WebDocumentSystem.Document.DocumentHelper.CanAction(document, WebDocumentSystem.Models.Document.DocumentActions.Share))
           {%>
                <a class="btn" id="btn_share" href="Share.aspx?DocumentId=<%:safeDocumentId %>">Share</a>
        <%} %>
        <% if (WebDocumentSystem.Document.DocumentHelper.CanAction(document, WebDocumentSystem.Models.Document.DocumentActions.Delete))
           { %>
                <a class="btn" id="btn_delete" href="Delete.aspx?DocumentId=<%:safeDocumentId %>">Delete</a>
                <% } %>
    </div>
</asp:Content>
<asp:Content ID="DocumentNotes" ContentPlaceHolderID="SideBarContent" runat="server">
    <!--<ul id="DocumentNotes" class="nav nav-list">-->
    <ul id="DocumentNotes" class="">
        <li class="nav-header">Document Notes</li>
        <!-- Loaded via AJAX -->
    </ul>
    <ul class="nav nav-list">
        <form runat="server">
        <li>
            <asp:TextBox ID="document_message" Rows="8" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="document_message"
                ErrorMessage="Required" runat="server"></asp:RequiredFieldValidator>
        </li>
        <li>
            <% if (permissionLevel == WebDocumentSystem.Models.Share.PermissionLevel.Read)
               { %>
            <asp:Button ID="btn_submit" class="btn disabled" runat="server" Text="Save Note"
                OnClick="AddMessageSubmit" />
            <%}
               else
               { %>
            <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Save Note"
                OnClick="AddMessageSubmit" />
            <% } %>
        </li>
        </form>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>
        Document History</h3>
    <table class="table table-hover table-condensed">
        <thead>
            <th>
            </th>
            <th>
                Date
            </th>
            <th>
                User
            </th>
            <th>
                Event Message
            </th>
        </thead>
        <tbody>
            <% 
                //Setup the document paging
                var data = GetDocumentHistory();
                var pageSize = 10;

                //var page_data = WebDocumentSystem.Document.PagingExtensions.Page(data, pageNumber, pageSize); %>
            <% foreach (var document in data) %>
            <% { %>
            <tr data-documentid="<%:document.Id %>">
                <td>
                </td>
                <td>
                    <%: document.Date %>
                </td>
                <td>
                    <%: document.User.Name %>
                </td>
                <td>
                    <%: document.Message %>
                </td>
            </tr>
            <% } %>
        </tbody>
    </table>
    <div id="Modal_encryption" class="modal hide fade">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                &times;</button>
            <h3>
                Decryption Key</h3>
        </div>
        <div class="modal-body">
            <input type="password" id="encryption_password" />
        </div>
        <div class="modal-footer">
            <a id="modal-password-save" href="#" class="btn btn-primary">Save</a>
        </div>
    </div>
</asp:Content>
