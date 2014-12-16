<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="Tengwar.aspx.cs" Inherits="TokiPona.Tengwar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    
    /* TODO: add eof font for MSIE users http://www.kirsle.net/wizards/ttf2eot.cgi */
@font-face {  
  font-family: TokiTengwar ;  
  src: url( /tp/img/TokiTengwar.ttf ) format("truetype");  
}  
 
/* Then use it like you would any other font */  
.tengwar { 
font-family: TokiTengwar , verdana, helvetica, sans-serif;  
font-size:24pt;
}  

#tengwar { 
font-family: TokiTengwar , verdana, helvetica, sans-serif;  
font-size:24pt;
} 
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
<p>As far as I know,<a href="http://bknight0.myweb.uga.edu/toki/tengwar/tengwar.html">jan Pije is responsible for much of this</a>. The main drawback of this system, at least for keyboard use, is that you have to capitalize certain letters and swap out other letters. The code below does the translation for you. Also, to put this on a website, you'd need the CSS and the font, view source if you feel ambitious.</p>
<asp:DropDownList runat="server" ID="DocumentPicker" AppendDataBoundItems="true"
        AutoPostBack="true">
        <asp:ListItem Value="Default" Text="Default or User Entered Text" />
        </asp:DropDownList>
<asp:TextBox ID="txtInput" runat="server" Rows="10" TextMode="MultiLine" width="80%"></asp:TextBox><br/>
    <asp:Button ID="btnConvert" runat="server" Text="Tengwar me!" onclick="btnConvert_Click" 
        />
        <div class="tengwar" id="tengwar">
    <asp:Literal ID="txtOutput" runat="server" ></asp:Literal>
    </div>
</asp:Content>
