<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="SitelenSuwi.aspx.cs" Inherits="TokiPona.SitelenSuwi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
<div style="margin-left:15%;margin-right:15%">
<h3><a href="http://www.jonathangabel.com/projects/t47/index.html">jan Josan</a>'s sitelen suwi</h3>
<p>sitelen suwi (sweet words) are heiroglyphs. It's a play on the word sitelen sewi which means holy drawings.</p>
<p>I don't actually have the programming skill to generate these correctly. The symbols require filling variable size spaces, some symbols wrap around others. So what you are seeing is just a pale shadow of what sitelen suwi can be when drawn by hand.</p>


  
    <asp:TextBox ID="txtInput" runat="server" Rows="10" TextMode="MultiLine" width="100%"></asp:TextBox><br/>
    <asp:Button ID="btnCompress" runat="server" Text="Make it sweet!" 
        onclick="btnCompress_Click" />

    
    <div runat="server" id="images"  style="width:700px"/>
    

    
    <h3>Other Resources</h3>
    <p>
    <a href="http://www.jonathangabel.com/projects/t47/index.html">jan Josan's original leessons and examples.</a>
    </p>
    
</div>
  


</asp:Content>
