<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="TokiPona.Chat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
<p>This is IRC. This chat room has been running since 2000. Unless someone saves a chat log, the chat is lost, which is too bad since chat logs represent part of the toki pona corpus, which is incredibly valuable for studying the language. If you do use IRC consider saving the chat logs, after asking permission from the participants of course. Solve the captcha and join. This client gives you a random nickname.</p>
<iframe src="http://webchat.freenode.net?randomnick=1&channels=tokipona&uio=d4" width="100%" height="600"></iframe>
</asp:Content>
