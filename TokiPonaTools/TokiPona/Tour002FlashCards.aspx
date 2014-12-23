<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="Tour002FlashCards.aspx.cs" Inherits="TokiPona.Tour002FlashCards" %>
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
        <p>
          Space repetition is the most effective way to learn the vocabulary necessary to read and write any language. The gist of the strategy is
            to review flash cards and categorize them based on if they are easy or hard. Easy cards are reviewed in the future, hard cards are reviewed sooner.
            This sounds easy except the accounting can be a burden and people give up or fall back to less effective flash card review methods.
        </p>
        <h2>ANKI</h2>
        <p>Anki is the best at the moment. Results after a week or two of use are magical. I'm less familiar with the others, but to the extent that they 
            use spaced repetition, you will get good results.
        </p>        
        
        <ul>
            <li><a href="https://ankiweb.net">Anki</a>. After installing (or signing up for the web based version), look for community decks with the keyword toki pona.</li>
            <li><a href="http://www.cram.com/search?query=toki+pona&sm=1">Cram.com</a></li>
            <li><a href="http://www.byki.com/listsearch.plex?search=toki+pona&cid=&x=0&y=0">Byki</a></li>
            <li><a href="http://quizlet.com/subject/toki-pona/">Quizlet</a></li>
            <li><a href="http://www.memrise.com/courses/english/toki-pona/">Memrise</a></li>
        </ul>
        
        <h2>Lesson Plans</h2>
        <p>Toki pona lacks a reference grammar, but it more than makes up for that with <a href="Books.aspx?Tour=True">pedagogical materials</a> .</p>
    </div>
</asp:Content>
