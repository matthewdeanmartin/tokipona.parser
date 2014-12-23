<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="Tour005Community.aspx.cs" Inherits="TokiPona.Tour005Community" %>
<%@ Register TagPrefix="uc1" TagName="tour" Src="~/Tour.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
     <div style="margin-left: 15%; margin-right: 15%">
        <uc1:tour runat="server" id="Tour" />
    </div>

    <br style="clear: both;" />
    <div style="margin-left: 15%; margin-right: 15%">
        <br />
        <h2>Community</h2>
        <p>This may be the least stable part of the tour. The center of toki pona has moved from mailing list to forums to facebook and will move again, but who knows when.</p>        
        
        <ul>
            <li><a href="Chat.aspx?Tour=true">IRC</a>. Here is an online IRC chat that takes you straight to the toki pona room.</li>
            <li><a href="ChatTwitter.aspx?Tour=true">Twitter</a>. Twitter has some toki pona activity.</li>
            <li>Skype. To set up a skype chat, find the current most active social forum and post that you are looking for someone to chat with on skype.</li>
            <li><a href="Discussion.aspx?Tour=true">Forums, blogs, wikia, etc.</a></li>
        </ul>
    </div>
</asp:Content>
