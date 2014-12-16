<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TokiPona._Default" 
 MasterPageFile="~/Basic.Master"
%>
<asp:Content runat="server" ID="cph" ContentPlaceHolderID="cphBody">
<div style="margin-right:30%;margin-left:30%">
<p>This is a custom search engine that restricts itself to a hand selected list of websites known to have toki pona text, or that are mostly toki pona texts.</p>
</div>
<div style="text-align:center;margin-right:30%;margin-left:30%">
    <div id="cse-search-form" style="width: 100%;">Loading</div>
<script src="http://www.google.com/jsapi" type="text/javascript"></script>
<script type="text/javascript">
    google.load('search', '1');
    google.setOnLoadCallback(function() {
        var customSearchControl = new google.search.CustomSearchControl('010530258174171504331:trmsq7cfp8g');
        customSearchControl.setResultSetSize(google.search.Search.FILTERED_CSE_RESULTSET);
        var options = new google.search.DrawOptions();
        options.setSearchFormRoot('cse-search-form');

        options.setAutoComplete(true);
        customSearchControl.draw('cse', options);
    }, true);
</script>
<link rel="stylesheet" href="http://www.google.com/cse/style/look/default.css" type="text/css" />
<style type="text/css">
  .gsc-control-cse {
    font-family: Arial, sans-serif;
    border-color: #336699;
    background-color: #ccffff;
  }
  input.gsc-input {
    border-color: #BCCDF0;
  }
  input.gsc-search-button {
    border-color: #336699;
    background-color: #E9E9E9;
  }
  .gsc-tabHeader.gsc-tabhInactive {
    border-color: #E9E9E9;
    background-color: #E9E9E9;
  }
  .gsc-tabHeader.gsc-tabhActive {
    border-top-color: #FF9900;
    border-left-color: #E9E9E9;
    border-right-color: #E9E9E9;
    background-color: #FFFFFF;
  }
  .gsc-tabsArea {
    border-color: #E9E9E9;
  }
  .gsc-webResult.gsc-result {
    border-color: #FFFFFF;
    background-color: #FFFFFF;
  }
  .gsc-webResult.gsc-result:hover {
    border-color: #FFFFFF;
    background-color: #FFFFFF;
  }
  .gs-webResult.gs-result a.gs-title:link,
  .gs-webResult.gs-result a.gs-title:link b {
    color: #0000CC;
  }
  .gs-webResult.gs-result a.gs-title:visited,
  .gs-webResult.gs-result a.gs-title:visited b {
    color: #663399;
  }
  .gs-webResult.gs-result a.gs-title:hover,
  .gs-webResult.gs-result a.gs-title:hover b {
    color: #0000FF;
  }
  .gs-webResult.gs-result a.gs-title:active,
  .gs-webResult.gs-result a.gs-title:active b {
    color: #0000FF;
  }
  .gsc-cursor-page {
    color: #0000CC;
  }
  a.gsc-trailing-more-results:link {
    color: #0000CC;
  }
  .gs-webResult.gs-result .gs-snippet {
    color: #000000;
  }
  .gs-webResult.gs-result .gs-visibleUrl {
    color: #000099;
  }
  .gs-webResult.gs-result .gs-visibleUrl-short {
    color: #000099;
  }
  .gsc-cursor-box {
    border-color: #FFFFFF;
  }
  .gsc-results .gsc-cursor-page {
    border-color: #E9E9E9;
    background-color: #FFFFFF;
  }
  .gsc-results .gsc-cursor-page.gsc-cursor-current-page {
    border-color: #FF9900;
    background-color: #FFFFFF;
  }
  .gs-promotion.gs-result {
    border-color: #336699;
    background-color: #FFFFFF;
  }
  .gs-promotion.gs-result a.gs-title:link {
    color: #0000CC;
  }
  .gs-promotion.gs-result a.gs-title:visited {
    color: #0000CC;
  }
  .gs-promotion.gs-result a.gs-title:hover {
    color: #0000CC;
  }
  .gs-promotion.gs-result a.gs-title:active {
    color: #0000CC;
  }
  .gs-promotion.gs-result .gs-snippet {
    color: #000000;
  }
  .gs-promotion.gs-result .gs-visibleUrl,
  .gs-promotion.gs-result .gs-visibleUrl-short {
    color: #008000;
  }
</style>
</div>

<div id="cse" style="margin-left:20%;margin-right:20%"></div>



</asp:Content>