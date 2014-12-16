<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GlossShowHtml.aspx.cs" Inherits="TokiPona.GlossShowHtml" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Copy and paste to edit your interlinear gloss further. Close this window to get back to where you were.<br />
    <asp:TextBox onclick="this.value=null;" ID="txtHtml" runat="server" Rows="10" TextMode="MultiLine" width="80%"></asp:TextBox>
    </div>
    </form>
</body>
</html>
