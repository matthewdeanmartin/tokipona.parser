<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="CorpusReadability.aspx.cs" Inherits="TokiPona.CropusReadability" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="js/jquery-latest.js"></script> 
<script type="text/javascript" src="js/jquery.tablesorter.js"></script> 
<script type="text/javascript">
    $(document).ready(function () {
        $("#scores").tablesorter();
    }
); 
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
<div style="margin-right:20%;margin-left:20%">
<ul>
<li><a href="ReadabilityStatistics.aspx">Readability scores for any text</a></li>
<li><a href="CorpusReadability.aspx">Readability scores each item in public corpus</a></li>
</ul>
<p>This is the five readability scores plus composite score where a composite score over 1 means hard, less than 1 means easy. Click headers to sort. <a href="#explain"> Click for explanation</a></p>

</div>
<br />
<div style="margin-right:5%;margin-left:5%">
<table border="1" id="scores">
<thead>
<tr>
<th>Document</th>
<th>Author</th>
<th>Complex NP %</th>
<th>Coordinating %</th>
<th>Function %</th>
<th>Proper %</th>
<th>Words/Sentence</th>
<th>Combined Scores</th>
</tr>
</thead>
<tbody>
<asp:Literal runat="server" ID="Output" />
</tbody>
</table>
</div>
<div style="margin-right:20%;margin-left:20%">
<a name="explain"/>
<p>A real readability score would get weightings by getting real humans to rank the difficulty of texts and then assigning weights that lead to a total score that has the same rank ordering that a human set down. I'm too lazy to do the math to do that.</p>
<p><b>Note on poetry and songs, dialogs, text with titles, etc.</b>. Poetry and songs get unrealistically high scores because they don't split on tidy sentence boundaries. Anything with fragments, such as titles, names in a dialog will get unnaturally low scores.</p>
<p>Combined score is the sum of each score divided by group average, summed then divided by 5. 
<code>SumOfMetrics(metric(i)/average(group))/CountOfMetrics</code>. If an article had scores fore each metric that happed to be the same as the group average, then the composite score would be 1. So any composite score less than 1 is easy and any thing above 1 is hard and the sort should be rougly correct.
</p>
<p>It is on my to do list to let you choose you own weights and to separate poetry from prose. <!--Instead, you can tune the weightings as you see fit. If a particular metric is irrelevant, then give it a 0 weighting. A hint to those who haven't done this sort of thing before- usually all but 2 or 3 of the metrics will drop out.--></p>
<p>Note on copyright. All items in corpus are taken from public domain or CC sources-- for one, everything on the toki pona forum is CC. If your writings are missing, please contact me and give me permission to post your works in tp, or put that sort of notice on your website. Some items may be translations of copyrighted works, but this may be fair use, since toki pona warps the original so much that it is like saying "Whale beats crazy man" is a derivate work of Moby Dick.</p>
</div>
</asp:Content>
