<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="Mutate.aspx.cs" Inherits="TokiPona.Mutate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">

    <div style="margin-left:10%;margin-right:10%">
<p>Diachronic conlangs seem to be trendy. This is a primative sound mutator, but you can tune it if you want. As an added plus, you can see an example of the result with example text of your choice. Someday I'll support multiple mutations, such as reduplication and gemination. Someday.</p>
<table border="0px">
<tr>
<td valign="top">
<table border="0px">
<tr><td>a</td><td><asp:TextBox ID="a" runat="server" Width="75px" /></td></tr>
<tr><td>e</td><td><asp:TextBox ID="e" runat="server" Width="75px" /></td></tr>
<tr><td>i</td><td><asp:TextBox ID="i" runat="server" Width="75px" /></td></tr>
<tr><td>o</td><td><asp:TextBox ID="o" runat="server" Width="75px" /></td></tr>
<tr><td>u</td><td><asp:TextBox ID="u" runat="server" Width="75px" /></td></tr>
</table>
</td>
<td valign="top">
<table border="0px">
<tr><td>j</td><td> <asp:TextBox ID="j" runat="server" Width="75px" /></td></tr>
<tr><td>k</td><td><asp:TextBox ID="k" runat="server" Width="75px" /></td></tr>
<tr><td>l</td><td> <asp:TextBox ID="l" runat="server" Width="75px" /></td></tr>
<tr><td>m</td><td> <asp:TextBox ID="m" runat="server" Width="75px" /></td></tr>
<tr><td>n</td><td> <asp:TextBox ID="n" runat="server" Width="75px" /></td></tr>
<tr><td>p</td><td> <asp:TextBox ID="p" runat="server" Width="75px" /></td></tr>
<tr><td>s</td><td> <asp:TextBox ID="s" runat="server" Width="75px" /></td></tr>
<tr><td>t</td><td> <asp:TextBox ID="t" runat="server" Width="75px" /></td></tr>
<tr><td>w</td><td> <asp:TextBox ID="w" runat="server" Width="75px" /></td></tr>
</table>
</td>
<td valign="top" width="50%"><asp:TextBox ID="txtInput" runat="server" Rows="15" TextMode="MultiLine" width="400px"></asp:TextBox></td>
</tr>
</table>

<asp:Button runat="server" ID="NewMapping" Text="Generate New Mapping" 
        onclick="NewMapping_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button runat="server" ID="Degenerate" Text="Degenerate" onclick="Degenerate_Click" /><br />
<table>
<tr>
<td valign="top" width="20%">
<asp:Label runat="server" id="txtOutput"></asp:Label>
</td>
<td valign="top" width="80%">
<asp:Label runat="server" id="txtSampleText"></asp:Label>
</td>
</tr>
</table>
</div>
</asp:Content>
