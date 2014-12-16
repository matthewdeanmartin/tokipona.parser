<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logaphones.aspx.cs" Inherits="TokiPona.Logaphones" MasterPageFile="~/Basic.Master"  %>
<% @ OutputCache Duration="600" VaryByParam="none" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
<div style="margin-right:20%;margin-left:20%">
<p>The logotome is the space of all possible words given the phonotactics of a language. When a phonetic inventory is very small, you begin to see two things-- lots of minimal pairs and not many short words.</p>
<p>This page calculates the first 2000 words of the logotome. It is worth nothing that 1/2 of the possible words end with "n", but of toki pona's 125 words, only a few end in n.</p>
</div>
<div style="text-align:center">
<asp:Label ID="OutText" runat="server" />
</div>

</asp:Content>