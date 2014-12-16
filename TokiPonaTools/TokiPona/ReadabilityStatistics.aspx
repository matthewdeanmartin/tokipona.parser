<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="ReadabilityStatistics.aspx.cs" Inherits="TokiPona.ReadeabilityStatistics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
<div style="margin-right:20%;margin-left:20%">
<ul>
<li><a href="ReadabilityStatistics.aspx">Readability scores for any text</a></li>
<li><a href="CorpusReadability.aspx">Readability scores each item in public corpus</a></li>
</ul>
<asp:TextBox ID="txtInput" runat="server" Rows="9" TextMode="MultiLine" width="100%"></asp:TextBox><br/>
    <asp:Button ID="BtnCalculateReability" runat="server" Text="Calculate Readability" 
        onclick="CalculateReability"  /><br />
   Sentences, Words: <asp:Literal ID="txtSentencesWords" runat="server" ></asp:Literal><br/>
   Words per sentence: <asp:Literal ID="txtWordsPerSentence" runat="server" ></asp:Literal><br/>
   Average #Complex NP/Sentences: <asp:Literal ID="txtComplexNps" runat="server" ></asp:Literal><br/>
   Avg #ProperModifiers/Sentence: <asp:Literal ID="txtPercentProperModifiers" runat="server" ></asp:Literal><br/>
   Avg #Function/Sentence: <asp:Literal ID="txtPercentFunctionWords" runat="server" ></asp:Literal><br/>
   Avg #Coordinating Words/Sentence: <asp:Literal ID="txtCoordinatingWords" runat="server" ></asp:Literal><br/>
<br />
 <p>Readability statistics are weighted sums of the following: words per sentence, percent of complex words, percent of multisyllabic words. In tp, nothing inflects, so nothing is complex in the sense of <a href="http://en.wikipedia.org/wiki/Gunning_fog_index">Gunning Fog complexity</a>. But we do have complex noun phrases, which are clearly marked by having "pi" in them. In tp all words are 3 syllable or less, except proper modifiers. Long words are probably over penalized by <a href="http://en.wikipedia.org/wiki/Flesch%E2%80%93Kincaid_readability_test">Fleich-Kinkaid</a> scoring.  kepeken isn't any more complicated than ma and Italija (4 syllables) is just as hard to recognize as Losi (2 syllabes). Proper modifiers should be penalized as being harder though because they are infrequently used and often are a long way from their original form. Also, all base content words are roughtly as frequent as any other, but even the rarest words (like open or maybe the obsolete words like pata) aren't especially difficult.</p>
<p>A toki pona specific measure might be the count of particles (function words) vs other words- la, o, e, li, pi plus the six prepositions. Something that is tp specific that really bumps up reading difficulty is discourse (i.e. long chains of sentences interlocked by "e ni", "ni li", and "ona". mi and sina are less problematic because their referrent is always clear and doesn't refer to something spoken earlier, later or maybe not even specifically mentioned.</p>
<p><b>Note on maximums</b>-- To calculate a true maximum, you'd have to consider all the possible sentences of length X and see which setence type has the most function words, proper modifiers, etc. For example, in a sentence of 3 words, no proper modifiers are possible. In a sentence of 4 words, 1 proper modifier is possible. In a sentence of 15 words, you could have ni li ijo followed by 12 proper modifiers, but that isn't really something you ever expect to see.</p>

</div>
</asp:Content>
