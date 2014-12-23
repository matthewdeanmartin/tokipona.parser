<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="TokiPona.Books" %>
<%@ Register TagPrefix="uc1" TagName="tour" Src="~/Tour.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
    <div style="margin-left: 15%; margin-right: 15%">
        <uc1:tour runat="server" id="Tour"  />
    </div>

    <br style="clear: both;" />
<div style="margin-left:20%;margin-right:20%" >
<h3>jan Sonja</h3>
<p>jan Sonja wrote the <a href="http://bknight0.myweb.uga.edu/toki/about/lesson/learn.html"> original toki pona lesson plans about 2000</a>. jan Sonja finally delivered on a 10 year promise to write a book, <a href="http://www.amazon.com/Toki-Pona-Language-Sonja-Lang/dp/0978292308/ref=sr_1_1?ie=UTF8&qid=1419363655&sr=8-1&keywords=toki+pona">Toki Pona, The Language of Good</a>.</p>
<h3>jan Pije</h3>
<p><a href="http://tokipona.net/tp/janpije/lesson/lesson0.html">jan Pije extended the original lessons and has been kind enough to release them to public domain</a>. 
    <a href="http://rowa.giso.de/languages/toki-pona/english/lessons.php">This lesson set on rowa.gisa.de</a> is an older iteration, but is the best formatted for printing (it is about 100 pages).</p>
<h3>jan Mimoku</h3>
<p>jan Mimoku put together a children's book and published it on <a href="http://www.lulu.com/product/file-download/toki-musi-pona/1214209">lulu</a>.</p>
<h3>jan Elisa</h3>
<p>Eliazar Parra Cardenas wrote <a href="http://elzr.com/tokipona/">this color set of lessons first in Spanish</a>. It is also available in <a href="https://aiki.pbworks.com/f/tp+in+76+lessons+English.pdf"> English</a>, translated by Dave Raferty. </p>

<h3>jan Mato</h3>
<b>Wiki Books Reference Grammar</b>
<p>Wikibooks is a place where the "mob" can write books. Someone put up an outline for yet another set of lessons, but I've replaced it with an <a href="http://en.wikibooks.org/wiki/Toki_Pona">outline of a reference grammar</a>, the sort that a field linguist might compile.</p>
<b>A Toki Pona Reader</b>
<p>This is vapor-book jan Mato (that's me) will be publishing any moment now. I plan to find all the public domain and creative commons works and compile them into a single printable document, sorted by difficulty with a glossary of phrases.</p>
</div>
</asp:Content>
