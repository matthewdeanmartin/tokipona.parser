<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="ReadingHelper.aspx.cs" Inherits="TokiPona.ReadingHelper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
<div style="margin-left:15%;margin-right:15%">
<p>This turns all the words of your text into hyperlinks to the improved classic word list. It is link to the single word definition. Someday, if I ever get a phrase dictionary going, I'll link well known phrases as well, e.g. "jan pona".</p>
<p>Is this of any use if you alreay know the 125 words? Mostly just for when you forget that kon also mean "soul" or telo also means "wash"</p>
<p>This technique could be used for any online dictionary. Some day I also plan to do one of these for Icelandic</p>
        <asp:DropDownList runat="server" ID="DocumentPicker" AppendDataBoundItems="true"
        AutoPostBack="true">
        <asp:ListItem Value="Default" Text="Default or User Entered Text" />
        </asp:DropDownList>

    <asp:TextBox ID="txtInput" runat="server" Rows="10" TextMode="MultiLine" width="100%"></asp:TextBox><br/>
    <asp:Button ID="btnGloss" runat="server" Text="Create text with dictionary links on each word" 
        onclick="btnGloss_Click"  />
    <asp:Literal ID="txtOutput" runat="server" ></asp:Literal><br/>

</div>
</asp:Content>
