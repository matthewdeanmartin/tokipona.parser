<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="SpellWords.aspx.cs" Inherits="TokiPona.SpellWords" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
    Type a word to spell. You get better results with toki pona words (using only tp letters)<br />
<asp:TextBox ID="txtInput" runat="server" Rows="10" width="100%"></asp:TextBox><br/>
    <asp:Button ID="btnSpell" runat="server" Text="Spell" onclick="btnSpell_Click" 
        Width="43px"  />
    <p>There are several spelling proposals. The incomplete official one uses Greek names and proper modifiers, e.g sitelen Alepa.  To be really nitpicky, it should be "sitelen Alepa pi toki Elena" Using proper modifiers to name things is back door vocabulary growth.  Letter names that are descriptive of the sound (kon for h) or shape (sike for o) can get very, very long. The military alphabet relies assigning each letter an essentially arbitrarily picked word that won't easily be confused with any other assigned letter name.</p>
    <h3>Military/Radio Alphabet. Suitable for use on noisy radios</h3>
    <asp:Label ID="txtMilitary" runat="server" Text="Label"></asp:Label><br/>
    <h3>Proper Modifiers: Greek Letter Names</h3>
    <asp:Label ID="txtGreek" runat="server" Text="Label"></asp:Label><br/>
    <h3>Proper Modifiers: English Letter Names</h3>
    <asp:Label ID="txtEnglish" runat="server" Text="Label"></asp:Label><br/>
</asp:Content>
