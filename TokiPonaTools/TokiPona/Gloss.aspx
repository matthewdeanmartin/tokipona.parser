<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="Gloss.aspx.cs" Inherits="TokiPona.Gloss" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
<div style="margin-left:15%;margin-right:15%">
Enter toki pona to gloss<br/>
    <asp:TextBox ID="txtInput" runat="server" Rows="10" TextMode="MultiLine" width="80%"></asp:TextBox><br/>
    <asp:Button ID="btnGloss" runat="server" Text="Gloss" 
        onclick="btnGloss_Click"  />
    <asp:Literal ID="txtOutput" runat="server" ></asp:Literal><br/>
    <a href="GlossShowHtml.aspx" target="_blank">Show HTML for gloss</a>
    <br/>
    
    <p>Glossing is a pain for two reasons: the HTML tables require lots of tags, and most glossing rules are optimized for languages that inflect- not isolating languages. Also, toki pona is highly polysemous, so a decent glosser would have to pick from one of tend possible meaning for each word.</p>
    <p>Another challenge is that glossing rules tend to assume one word has many meanings, while in toki pona, it takes many words to equal one meaning.</p>
    <h3>Other Resources</h3>
    <p><a href="http://inamidst.com/services/tokipana">Word for word glossing/pseudo-translator tp to English</a></p>
    
    
</div>    
</asp:Content>
