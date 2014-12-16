<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="Relex.aspx.cs" Inherits="TokiPona.Relex" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
<div style="margin-left:15%;margin-right:15%">
<p>The is a recreational relex, not a lojban/loglan style attempt to split the community in two or six. I hope to put a variety of re-lexes here using a variety of other source languages, starting with the tokipona-English-like, Latin-like and Russian-like.</p>
        <p>A relex preserves the grammar of the language, but replaces all the vocabulary. It's legitimate use is to create a conlang with a particular sound, but without investing any time in creating a vocabulary, syntax, discourse, or anything else. This isn't translation folks.</p>
        <p>Pseudo-Latin, pseudo-French sounds more prestigious to the American ear than pseudo-Proto-Polynesian. Another legit usage of this would be to prepare toki pona poems or texts for consumption by an audience that doesn't understand toki pona anyhow.</p>
        <p>These relexes aren't final! So don't start memorizing them yet. I'm certain there are mistakes and bad choices at the moment. In particular, it isn't clear what to do with the endings of Latin or Russian words.  For some freaky output, force the result to follow toki pona phonotactics. That will apply the transliteration engine to the relexed text to make it sound like toki pona again.</p>
        <asp:DropDownList runat="server" ID="DocumentPicker" AppendDataBoundItems="true"
        AutoPostBack="true">
        <asp:ListItem Value="Default" Text="Default or User Entered Text" />
        </asp:DropDownList>
    <asp:TextBox ID="txtInput" runat="server" Rows="7" TextMode="MultiLine" width="100%"></asp:TextBox>
    <br/>
    <asp:RadioButtonList runat="server" ID="phonotactics">
        <asp:ListItem Text="Force toki pona phonotactics" Value="forceTp" ></asp:ListItem>
        <asp:ListItem Text="Keep source langauge phonotactics" Value="keepSource"  Selected="True"></asp:ListItem>
    </asp:RadioButtonList>
    <asp:Button ID="btnCompress" runat="server" Text="Relex me!" 
        onclick="btnCompress_Click" />
    <%--<asp:Button ID="Button1" runat="server" Text="Decompress" 
        onclick="Button1_Click" />--%>
        
        <br/>
        <br />
        Pick at target language <asp:DropDownList runat="server" ID="TargetLanguage" AutoPostBack="true" OnSelectedIndexChanged="TargetLanguage_SelectedIndexChanged">
        <asp:ListItem Selected="true" Text="Latin" Value="Latin" />
        <asp:ListItem Text="English" Value="English" />
        <asp:ListItem Text="Russian" Value="Russian" />
        <asp:ListItem Text="Icelandic" Value="Icelandic" />
        </asp:DropDownList>
<table>
<tr>
<td valign="top">
        <asp:Label ID="txtOutput" runat="server" Text="Label"></asp:Label><br/>
    </td>
<td valign="top">
Relex dictionary:
<code>
<pre>
<asp:PlaceHolder runat="server" id="RelexDictionary" />
</pre>
        </code>
      </td>  
       </tr>
</table>
 </div>
</asp:Content>
