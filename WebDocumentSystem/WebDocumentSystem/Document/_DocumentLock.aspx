<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_DocumentLock.aspx.cs" Inherits="WebDocumentSystem.Document._DocumentLock" %>

<% var documentId =  Int32.Parse(Request.QueryString["DocumentId"]);%>
<% var result = AttemptLock(documentId); %>
<% if (result) %>
<%{ %>OK<% } else {%>NOK<% } %>