<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="Compress.aspx.cs" Inherits="TokiPona.Compress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div style="margin-left:15%;margin-right:15%">
    <asp:TextBox ID="txtInput" runat="server" Rows="10" TextMode="MultiLine" width="100%"></asp:TextBox><br/>
    <asp:Button ID="btnCompress" runat="server" Text="Compress" 
        onclick="btnCompress_Click" />
    <asp:Button ID="Button1" runat="server" Text="Decompress" 
        onclick="Button1_Click" /><br/>
            <p>There are about five different toki pona compressions techniques.  The most efficient replace each word with a single character. Unicode, Hanji and Kanji are examples.  The next most efficient replaces each word with a 2 letter code or replaces each two letters with a single symbol, such as kata kana/hiragana/hangul.</p>
<div runat="server" id="outputSection" visible="false">
    <h3>2 Letter Codes- proposed by <a href="http://forums.tokipona.org/viewtopic.php?f=7&t=1165&start=20&p=5841&view=show#p5841">jan Ante</a></h3>
    <asp:Label ID="txtOutput" runat="server" Text="Label"></asp:Label><br/>
    
    <h3>Japanese Kanji and Hiragana - <a href="http://onclepom.u7n.org/tokiPona/tpTranscriber.php"> Proposed by Erik Olsen, et al.</a></h3>
    <asp:Label ID="txtJapanese" runat="server" Text="Label"></asp:Label><br/>
    <h3>Chinese - <a href="http://forums.tokipona.org/viewtopic.php?f=38&t=1519#p8261">Proposed by jan Josan</a></h3>
    <asp:Label ID="txtChinese" runat="server" Text=""></asp:Label><br/>
    
    <h3>Unicode Dingbats - Proposed by <a href="http://www.theiling.de/schrift/tokipona.html">Henrik Theiling</a></h3>
    <h3>(May not display on all, or most, or even some browsers)</h3>
    <asp:Label ID="txtUnicode" runat="server" Text=""></asp:Label><br/>
</div>        
    
    <h3>Other Resources</h3>
    <p>
    <a href="http://onclepom.u7n.org/tokiPona/tpTranscriber.php">Latin - Japanese</a>
    </p>
  
    <p>
    <a href="http://home.cogeco.ca/~probert3/hiragana.html">Latin - Japanese (Hiragana)</a>
    </p>
    
    
    <p> <a href="http://www.theiling.de/schrift/tokipona.html">Latin - unicode</a></p>
    <p> <a href="http://www.tobareinne.com/misc/llengua/tokipona/hangul-Vkbd.html">Latin - Hangul</a></p>
  <h3>Non compressing Scripts</h3>  
      <p>
    <a href="http://newyork.mashke.org/Conv/">Latin to Cyrillic (not a toki pona specific tool.</a></p>
    <p><a href="http://bknight0.myweb.uga.edu/toki/tengwar/tengwar.html">Tengwar</a> Visually compressed, but still has a squiggle per sound.</p>
</div>    
</asp:Content>
