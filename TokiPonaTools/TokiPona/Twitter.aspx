<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="Twitter.aspx.cs" Inherits="TokiPona.Twitter" %>
<%@ OutputCache Duration="600" VaryByParam="none" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
<div style="margin-left:15%;margin-right:15%">

<h2>What is mini-blogging?</h2>
<p>Mini-blogging is any blogging service where you are limited to a sentence of two per post. Twitter, Facebook, Identica and such are all miniblogs. Anyone can write a sentence a day, so why not write a sentence a day in the languages you're studying? Mini-blogging is mostly conversations that evolve rather slowly as compared to chat or IM.</p>
<p> <a href= "http://tokilili.shoutem.com">Toki Lili</a> This is a website separate from Twitter, but works much like it. The difference is 100% of the accounts on toki lili are toki pona users and are unlikely to post messages other than toki pona related messages. It sometimes has spam problems, but the shoutem moderators will deal with it.</p>
<p> <a href= "http://twitter.com/janMato/toki-pona-only">Twitter</a> Twitter just has more people on it on a given day. On the other hand, people tweet in multiple languages on the same account and it is hard to guess if anyone who has used toki pona before will again.</p>

<table>
<tr>
<td valign="top">
<h2>toki lili</h2>
<p>Toki lili's accounts creation system broke as of about mid 2014. It exists but isn't taking new users.</p>
<script type='text/javascript' charset='utf-8' src='http://scripts.hashemian.com/jss/feed.js?print=yes&numlinks=20&summarylen=140&seedate=yes&url=http:%2F%2Ftokilili.shoutem.com%2Fapi%2Ftwitter%2F1.0%2Fstatuses%2Fpublic_timeline.rss'></script>
<p>RSS feed generated using <a href="http://www.hashemian.com/tools/rss-atom-widget.htm">this tool</a>.</p>
</td>
<td valign="top">
<h2>Twitter</h2>
<script src="http://widgets.twimg.com/j/2/widget.js"></script>
<script>
    new TWTR.Widget({
        version: 2,
        type: 'list',
        rpp: 30,
        interval: 6000,
        title: 'People who Tweet (almost) only in Toki Pona',
        subject: 'jan pi toki pona taso',
        width: 'auto',
        height: 600,
        theme: {
            shell: {
                background: '#22e2f0',
                color: '#041a6b'
            },
            tweets: {
                background: '#ffffff',
                color: '#800a22',
                links: '#ad162f'
            }
        },
        features: {
            scrollbar: true,
            loop: false,
            live: true,
            hashtags: true,
            timestamp: true,
            avatars: true,
            behavior: 'all'
        }
    }).render().setList('janMato', 'toki-pona-only').start();
</script>
</td>

</tr>

</table>

</div>
</asp:Content>
