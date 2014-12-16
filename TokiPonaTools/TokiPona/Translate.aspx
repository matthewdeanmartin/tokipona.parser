<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="false" CodeBehind="Translate.aspx.cs" Inherits="TokiPona.Translate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">

Input : <asp:TextBox runat="server" Rows="25" TextMode="MultiLine" ID="InputText"/>

Translation : <asp:Label runat="server" ID="OutputText" />

<asp:Button runat="server" ID="DoTranslation" Text="Translate" />

</asp:Content>
