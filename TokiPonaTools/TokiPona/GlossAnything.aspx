<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="GlossAnything.aspx.cs" Inherits="TokiPona.GlossAnything" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
        <style>
    /* =Glossing Rules: Word Spacing with list*/

  * html ul { position: relative }
  * html ol { position: relative }
  * html dl { position: relative }

ul.word_spacing_list, ul.word_spacing_list li,  ul.word_spacing_list_top, ul.word_spacing_list_top li{
list-style-type: none;
margin: 0;
}


ul.word_spacing_list_top li, ul.word_spacing_list li{
float: left;
padding-bottom: 5px;
}

li.w20{
width: 20px;
}

li.w30{
width: 30px;
}

li.w40{
width: 40px;
}

li.w50{
width: 50px;
}

li.w60{
width: 60px;
}

li.w70{
width: 70px;
}

li.w80{
width: 80px;
}

li.w90{
width: 90px;
}

li.w100{
width: 100px;
}

li.w130{
width: 130px;
}

ul.word_spacing_list{
clear: left;
}

ul.word_spacing_list_top{
font-style:italic;
font-weight: bold;
font-size: 1.1em;
}

ol ul{
margin: 0px;
padding-left: 10px;
}

ol ul li.normal-list{
list-style-type: disc;
}

ul.word_spacing_list_top, ul.word_spacing_list{
padding: 0 0 0 30px;
}

.trennlinie {border-bottom: 1px solid #D0BA89; width:auto;padding: 0px; margin: 0;}
    
.word_spacing_list_clearing{
clear: left;
padding-left: 27px;
}
</style>
    
    
        <h2>Interlinear Gloss Formating Tool</h2>
    <p>Enter the foreign text, fluid translated text, and a mini-dictionary to get 3 ways to do a interlinear gloss.</p>
    <div>
Text to Gloss: <asp:TextBox runat="server" ID="inputText" width="90%" Text="mi wile moku e telo nasa pi pan pimeja" /><br />
Fluid English: <asp:TextBox runat="server" ID="fluidTranslation" width="90%" Text="I want to drink Guiness beer." /><br />
CSV Dictionary: <asp:TextBox runat="server" ID="dictionaryText" width="50%" TextMode="MultiLine" Rows="5"  >mi,1S
wile,want
moku,eat
e,DO
telo,water
nasa,strange
pi,of
pan,bread
pimeja,black
</asp:TextBox>
<br />
<asp:Button runat="server" ID="GlossAction" Text="Gloss it" />
<p>Don't have a dictionary? Leave the dictionary blank. Click "Gloss it" and I will create a dictionary with everything but the translations. Fill in the translations and paste into the dictionary and repeat to get a gloss.</p>
<p>CSV Dictionary should look like this:</p>
<pre>
telo,water
amuq’-da-č,stay-FUT-NEG
essandu,eat:they:shall
</pre>
<p>Here is more on how to <a href="http://www.eva.mpg.de/lingua/resources/glossing-rules.php">gloss</a>.</p>
<h2>Formatted using &lt;pre&gt;</h2>
<p>Works anywhere that you have fixed width text.</p>
<pre><asp:Label runat="server" ID="glossBox" /></pre>
<asp:Button runat="server" ID="ShowPre" Text="Show HTML" onclick="ShowHtml" />

<h2>Formatted using &lt;table&gt;</h2>
<p>Works even if you don't have access to CSS.</p>
<asp:Label runat="server" ID="nonPreGlossBox" />
<asp:Button runat="server" ID="ShowTable" Text="Show HTML" onclick="ShowHtml"/>
<br />
<br />

<h2>Formatted using &lt;ul&gt;</h2>
<p>Requires a <a href="gloss.css">CSS snippet</a> or it will look like a list of words.</p>
<asp:Label runat="server" id="GlossAsList" />
<asp:Button runat="server" ID="ShowUl" Text="Show HTML" onclick="ShowHtml"/>
<br />
<p>The Glosser does a simple dictionary lookup with the dictionary you provide. The interlinear gloss formatter can't parse words into morphemes. It can't cope with words with multiple meanings either.</p>
</div>


    

</asp:Content>
