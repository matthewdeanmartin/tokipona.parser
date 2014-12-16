<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="Runes.aspx.cs" Inherits="TokiPona.Runes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
@font-face {  
  font-family: Junicode ;  
  src: url( /tp/img/JuniCode-Regular.ttf ) format("truetype");  
}  
 
/* Then use it like you would any other font */  
.runes { 
font-family: Junicode , verdana, helvetica, sans-serif;  
font-size:16pt;
}  
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
    <div style="margin-left:10%;margin-right:10%">
<p>This page uses a 750KB font. So if it is initially slow, that is why. If you enjoy installing TTF fonts, go here to get <a href="http://junicode.sourceforge.net/">Junicode</a>, which is a unicode font for a variety of ancient scripts.</p>
<asp:RadioButtonList runat="server" ID="RuneOptions">
<asp:ListItem Text="Use all of the 24 runes, using some to represent the same sound"  Value="all"/>
<asp:ListItem Text="Favor only 14 letters, snubbing all the gods represented by the other 10 runes"  Value="some" Selected="True" />
</asp:RadioButtonList>
<asp:TextBox ID="txtInput" runat="server" Rows="10" TextMode="MultiLine" width="100%"></asp:TextBox><br/>
    <asp:Button ID="btnConvert" runat="server" Text="Rune me!" onclick="btnConvert_Click" />
    <asp:Label runat="server" ID="error" />
        
        
<table>
<tr>
    <td valign="top" width="75%">
    <div class="runes">
    <asp:Literal ID="txtOutput" runat="server" ></asp:Literal>
    </div>
    </td>
<td valign="top" width="25%">
    <div class="runes">
<pre class="runes">/p/     ᛈ       perþo
/t/     ᛏ       tīwaz
/k/     ᚲ       kaunan
/s/     ᛊ       sōwilō
/m/     ᛗ       mannaz
/n/     ᚾ       naudiz
/l/     ᛚ       laguz
/j/     ᛃ       jēra
/w/     ᚹ       wunjō

/a/     ᚨ       ansuz
/e/     ᛖ       ehwaz
/i/     ᛁ       īsaz
/o/     ᛟ       ōþalan
/u/     ᚢ       ūruz
</pre>
</div>
</td>
</tr>
</table>        

</div>
</asp:Content>
