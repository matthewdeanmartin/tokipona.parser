<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GlossAnythingDisplay.aspx.cs" Inherits="TokiPona.GlossAnythingDisplay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div>
    <textarea style="height: 400px; width: 100%"><%= Session["GlossHtml"] %></textarea>
    </div>
    </div>
    </form>
</body>
</html>
