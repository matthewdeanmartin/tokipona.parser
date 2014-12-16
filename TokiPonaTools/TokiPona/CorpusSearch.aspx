<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="CorpusSearch.aspx.cs" Inherits="TokiPona.CorpusSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
<p>You can type in a search. If you are looking for a whole word, use \bnimi\b where nimi is any word. If you are a genius you can do regex searches, which allows for searching for things like all instances of a word used as transitive. Search string must be 50 characters or less.</p>
    Search: <asp:TextBox ID="search" runat="server"/>
<br />
<br />
<asp:Button runat="server" ID="searchCommand" onclick="searchCommand_Click" Text="Search"/>
<br />
<br />
<asp:Literal runat="server" ID="Output" />
</asp:Content>
