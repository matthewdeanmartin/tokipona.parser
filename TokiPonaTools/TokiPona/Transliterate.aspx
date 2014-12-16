<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Transliterate.aspx.cs" Inherits="TokiPona.TransliteratePage" MasterPageFile="~/Basic.Master" %>
<asp:Content ID="cph" ContentPlaceHolderID="cphBody" runat="server">
<div style="margin-left:15%;margin-right:15%">
<p>This is the proper modifier transliterator, aka "Your name in toki pona"</p>
<p>This algorithm was written in 2007 and updated in 2010. It has been tested on a bunch of country names.</p>
<p>Transliterations are predictable except the following cases:</p>
<ul>
<li>If r's become l, w, or k. The machine can't predict for you.</li>
<li>Do you prefer to split consonant clusters or merge them-- and what neutral vowel to use (a,e,i are common,but o is common for nouns).</li>
<li>Do you prefer to split vowel clusters or merge them-- the neutral consonant is y or w</li>
<li>Is th "s" or "t"</li>
<li>When the English spelling is crazy-- for example, is that final e silent or not</li>
<li>When the source word is a not an English word--Calais--or when the toki pona rules call for the way it is said abroad, e.g. Rome vs Roma for the capital of Italy.</li>
</ul>
    To Transliterate : <asp:TextBox runat="server" ID="ToTransliterate" /><br />
    <asp:Button runat="server" ID="DoTransliteration" Text="Transliterate" />
    
    <asp:Label runat="server" ID="TokiPonaOutput" />
    
    <h3>Notes.</h3>
    <p>Transliteration really depends on the IPA of what you are saying. This transliterator works by transliterating the letters as they are spelled out.  So if you spell phonetically, you will get a better result.</p>
  <p>Known bugs- it still has a problem with occasional vowel and consonant clusters that just aren't legal in toki pona.</p>
</div>

</asp:Content>
