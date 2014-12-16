<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="DisplayText.aspx.cs" Inherits="TokiPona.DisplayText" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.tokiponatext
{
    /*background-color:#F0FFFF;*/
    background-color:#F6F9F9 ;
}
.content
{
    color:#800000;
}
.function
{
    color:Red;
}
.anaphora
{
    color: Blue;
}
.conjunction
{
    color:Green;
}
.proper
{
    color:Orange;
    font-weight:bold;
}
.prep
{
    color:Red;
    font-weight:bold;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
<div style="margin-left:20%;margin-right:20%">
<div runat="server" id="InstructionPanel">
<p>toki pona sometimes feels like writing code, in part because it for the most part follows an (E)BNF grammar, like all computer programming languages do.  Colorization is a very common way of making code more readable.</p>
<p>This colorization scheme only colorizes the easiest to identify parts of speech. There are too many possibilities to reliably ID nouns, modifiers and verbs. The code behaves strange when it comes to non toki pona text.</p>
<asp:RadioButtonList runat="server" ID="PrepositionStyle" AutoPostBack="true">
<asp:ListItem Selected="True"  Value="dont" Text="Don't color Prepositions" />
<asp:ListItem Selected="False"  Value="do" Text="Color Prepositions" />
</asp:RadioButtonList>
 <asp:DropDownList runat="server" ID="DocumentPicker" 
        AutoPostBack="true">
        </asp:DropDownList>
</div>
<div class="tokiponatext">
<asp:Literal runat="server" ID="CorpusText"></asp:Literal>
</div>
<pre>
<asp:Literal runat="server" ID="Graph"></asp:Literal>
</pre>
</div>
</asp:Content>
