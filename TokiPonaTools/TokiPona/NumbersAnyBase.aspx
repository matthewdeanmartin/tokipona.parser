<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="NumbersAnyBase.aspx.cs" Inherits="TokiPona.NumbersAnyBase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
<p>The official word number system is used just as often as the following community proposals, so here they are:</p>

<asp:DropDownList runat="server" ID="BasePicker">
<asp:ListItem Text="Ternary" Value="3"></asp:ListItem>
</asp:DropDownList>
<asp:Literal runat="server" ID="Output" />

</asp:Content>
