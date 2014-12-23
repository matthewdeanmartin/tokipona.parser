<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="ChatTwitter.aspx.cs" Inherits="TokiPona.ChatTwitter" %>
<%@ Register TagPrefix="uc1" TagName="tour" Src="~/Tour.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
    <div style="margin-left: 15%; margin-right: 15%">
        <uc1:tour runat="server" id="Tour"  />
    </div>

    <br style="clear: both;" />
<div style="margin-left:10%;margin-right:10%">
<table>
<tr>
<td>
<p>Twitter is a promising place to learn foreign languages. Anyone can write 140 characters in a language they're learning.</p>
<p>If you want a realtime, rapid fire conversation on twitter, you will need a few tools and to look at twitter differently:</p>
<h2>The #hashtag is the chat room</h2>
<p>Hashtags signal the world that a bundle of tweets are related somehow, like maybe it is a single group conversation or a virtual chat room.</p>
<p><a href="http://tweetchat.com/room/tokichat">#tokichat</a> is a good hashtag for chatting. The <a href="http://tweetchat.com/room/tokipona">#tokipona</a> hashtag has spam. 
If you don't want to use the tweetchat interface, you can approximate it in any client using a hashtag search. Someday #tokichat will be overrun with spam, too and the community 
will need to move on to a new hashtag.</p>

<h2>Everyone is their own moderator</h2>
<p>In twitter chat, each user is responsible for filtering out obnoxious people or spammers. On tweetchat, this is right in the interface, click the user and select block and they disappear from the chat room--but just for you.</p>

<h2>Where is the chat log?</h2>
<p>Remember, everything on twitter is entirely public. Even though chats persist, Twitter doesn't keep tweets for ever-- it seems that old tweets slowly disappear. 
<a href="http://tweetbackup.com/">TweetBackup</a> can backup just what you said, or anything on a hashtag.</p>


<h2>Are there any downsides?</h2>
<p>Twitter is a type of broadcast-- all your followers can see your twitter chatting. Your twittering will flood your stream and potentially annoy your ordinary followers. 
This another reason why you want to have two twitter accounts, one for toki pona and one for everything else. On the other hand, this isn't that serious of a problem because everyone is twittering and everyone's tweets will 
eventually roll of the bottom of the page.</p>
<!--
I want a beautiful, public, chat log.
https://tokipona.campfirenow.com/  -- up to 4 chatters
-->

</td>
<td valign="top">
Join the chat with this interface optimized for chatting: 
<a href="http://tweetchat.com/room/tokichat">#tokichat</a>
</td>
</tr>

</table>

</div>

</asp:Content>
