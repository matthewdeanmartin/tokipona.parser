<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="Tour004ReadingWriting.aspx.cs" Inherits="TokiPona.Tour004ReadingWriting" %>
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
        <h2>Reading and Writing Tools</h2>
        <p>These sort of tools are remarkably difficult to write. Ideally, a language learner would have a machine to ask for a translation like google translate, 
            a grammar checker, and a word processor that can detect spelling and other errors.
        </p>        
        
        <ul>
            <li><a href="http://tokipona.net/parser/">Parser</a>.This application will parse your text, colorize it, diagram it, and attempt to provide an English gloss. It can deal with probably 95% of interesting scenarios.</li>
            <li><a href="ReadingHelper.aspx">Reading Helper</a>. This really only helps if you haven't memorized the basic 125 words.</li>
            <li><a href="ClassicWordList.aspx">Word List</a>. My compilation of the basic toki pona words, mostly derived from jan Sonja material.</li>
            <li><a href="http://tpnimi.blogspot.com">tp nimi</a>. jan Kipo's dictionary.</li>
            
        </ul>
    </div>

</asp:Content>
