<%@ Page Language="C#" AutoEventWireup="false"  MasterPageFile="~/Basic.Master"  CodeBehind="CussWords.aspx.cs" Inherits="TokiPona.CussWords" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div style="margin-right:20%;margin-left:20%">

<p>This tests the idea that if you randomly generate words with something close to a languages natural distribution of sounds, you will generate cuss words most frequently.  My non-professional theory is that cuss words are especially representative of the phonotactics of a language. This has special application for toki pona because with only 125 or so words, the cuss words can be discovered long before anyone feels the urge to coin them.</p>
<p>If I run this with really large number of repetitions, "nena" consistently comes out tops, which isn't the official cuss word "pakala". But it is still used in "nena meli sinpin". It isn't surprising "nena" is most common because those letters have the highest odds for their positions. Someday I need to rewrite this with probabilities based on the previous letter, but at the moment, I'm too lazy to calculate out the transition matrix. With a transition matrix, it is much harder to known in advance what the most likely randomly generated cussword is. Or maybe not, math is the forte of the tokiponist.</p>
</div>
<div style="text-align:center;margin-right:30%;margin-left:30%">
        <asp:Button runat="server" ID="BtnCuss" Text="Cuss!"  />
        <br />
        <asp:Label runat="server" ID="TxtOutput" />
        </div>
</asp:Content>