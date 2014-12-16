<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="Numbers.aspx.cs" Inherits="TokiPona.Numbers" %>
<%@ OutputCache Duration="600" VaryByParam="none" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
<div style="margin-right:20%;margin-left:20%">
<p>There are three official counting systems and probably a dozen community proposals.</p>
<p>In real world languages, there are two number systems- exact and approximate. Even primative people like English speakers often have to resort to approximate number systems, counting "one, a pair, a trio, a few, a bunch, a lot, a whole lot, a crap load."  When you see people note that such and such a society counts "one, two, many" what is being observed is an approximate number system.  When people use an approximate number system with a so-called "five", often five means three to seven. On the other hand exact number systems are not universal, so the toki ponan with an exact numbering system at all, is a rather advanced.</p>
<p><b>Couting with approximates</b>. ala, wan, tu, tu wan, tu tu, tu tu wan.  This system is pretty bizzare. It corresponds to the English, "none, single, few, few single, few few, few few single" and so on.  This system stops working at about six.</p>
<p><b>Couting with approximates and luka</b>. "wan, tu, tu wan, tu tu, luka, luka wan, luka tu, luka tu wan, luka luka".  Again, this is an approximate system that has been forced into exact counting.  This system stops working at about 15.</p>
<p><b>Counting with ale, mute for 100 and 20</b>  This is more of the same, except ale and mute have much more opportunity to be confused with a non-numerical meaning.  The system breaks down at about 350, but is bearable to write if you use Roman style numerals.  All that said, it looks like a Christmas tree if you list them centered.</p>
</div>
<div style="text-align:center">
<img src="img/Toki_pona.png" height="100px" alt="" /><br />
<asp:Label ID="OutText" runat="server" />
</div>
</asp:Content>
