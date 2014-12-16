<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sandhi.aspx.cs" Inherits="TokiPona.Sandhi" MasterPageFile="~/Basic.Master"  %>
<%@ OutputCache Duration="600" VaryByParam="none" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
<div style="margin-left:15%;margin-right:15%">
<p>The phonotactics of toki pona make certain sound combinations illegal within a word, for example, aei can't be a word (too many vowels in a row), nor can ipap (can't end in consonant other than n), and none of the following can be substrings of the word: "ji", "wu", "wo", "ti", "nm", "nn"</p>
<p>Sandhi is how these rules play out at word boundaries. Here are all the word pairs that violate one the rules for internal sandhi, mostly vowel-vowel violations, and a few n/n and n/m violations. No word ends in j, w or t, so those violations never happen.</p>
<p>I suspect that if this were a spoken language, people would invent a glottal stop for the vowel/vowel sandhi and assimilate nm/nn into a single m or n sound.</p>
</div>
<div style="text-align:center">
<asp:Label ID="OutText" runat="server" />
</div>
</asp:Content>

