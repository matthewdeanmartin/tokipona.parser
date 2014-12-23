<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TokiPona._Default"
    MasterPageFile="~/Basic.Master" %>

<%@ Register Src="~/Tour.ascx" TagPrefix="uc1" TagName="Tour" %>

<asp:Content runat="server" ID="cph" ContentPlaceHolderID="cphBody">

    <div style="margin-left: 15%; margin-right: 15%">
        <uc1:Tour runat="server" ID="Tour" />
    </div>

    <br style="clear: both;" />
    <div style="margin-left: 15%; margin-right: 15%">
        <br />
        <p>
            New? Take the tour. Otherwise, click around to see tools and linguistic experiments I've written using toki pona.
        </p>
    </div>
</asp:Content>
