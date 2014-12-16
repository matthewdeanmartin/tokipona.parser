<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="LoremIpsum.aspx.cs" Inherits="TokiPona.LoremIpsum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
    <div style="margin-right:20%;margin-left:20%">

<p><a href="http://www.lorem-ipsum.info/_tokipona">This often used lorem ipsum generator</a> creates defective toki pona.</p> 
<p>It includes non toki pona things like "vt" and "vi" which are abbreviation for parts of speech indicators. Also it chooses words without regard for grammar, which is unnecessary. Toki pona only has one sentence pattern and can be obeyed quite easily.</p>
<p>The following generator randomly choose a predicate, VT, or VI sentence and adds conditionas, modifiers, direct objects, etc and restricts most words to their prototypical part of speech locations.</p>
<p>The above mentioned site isn't always up, here is another <a href="http://www.lipsum.com/">lorem ipsum site that generates lorem in several languages other than tp.</a></p>

<asp:Button runat="server" id="Generate" Text="Generate" onclick="Generate_Click"/>
<asp:Label ID="Output" runat="server" />
</div>
</asp:Content>
