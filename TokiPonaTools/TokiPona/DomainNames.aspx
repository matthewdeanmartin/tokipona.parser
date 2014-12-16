<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="DomainNames.aspx.cs" Inherits="TokiPona.DomainNames" %>
<%@ OutputCache Duration="3200" VaryByParam="none" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
<div style="margin-right:20%;margin-left:20%">
<table>
<thead>
<tr><th>.Com</th><th>.Org</th><th>.Net</th><th>.Info</th>
</tr>
</thead>
<tbody>
<asp:Literal ID="rows" runat="server"></asp:Literal>
</tbody>
</table>
</div>
</asp:Content>
