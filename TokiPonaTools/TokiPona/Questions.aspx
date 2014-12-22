<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="Questions.aspx.cs" Inherits="TokiPona.Questions" %>
<%@ OutputCache Duration="600" VaryByParam="none" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
<div style="margin-right:20%;margin-left:20%">
<p><a href="http://tokipona.shapado.com/">Toki Pona Shapado</a> is a Q&amp;A site that allows for voting on questions and answers. The various features are optimized to discourage discussion and to encourage asking questions that could have an answer and answering objectively.</p>

<script type='text/javascript' charset='utf-8' src='http://scripts.hashemian.com/jss/feed.js?print=yes&numlinks=20&summarylen=500&seedate=yes&url=http:%2F%2Ftokipona.shapado.com%2Fquestions.atom%3Flang%3Den%26mylangs%3Den'></script>
<p>RSS feed generated using <a href="http://www.hashemian.com/tools/rss-atom-widget.htm">this tool</a>.</p>
</div>

</asp:Content>
