<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="MinimalPairs.aspx.cs" Inherits="TokiPona.MinimalPairs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
<div style="margin-left:15%;margin-right:15%">
<p>The following minmal pairs detected using <a href="http://billposer.org/Software/minpair.html">MinPair 5.2</a>.  I think the only type of minimal pair it does not catch is Samoan style, where they ignore the consonants and pay attention to only the vowels. So "picnic" would be a Samoan minimal pair with "mini", but not "poknoc". And I may be wrong about Samoan minimal pairs, consider it an urban legend until I find a reference.</p>
<p>It is worth noting that just about all the words have a minimal pair. On one hand this enables poetry, on the otherhand, to this date I still confuse some minimal pairs.</p>

<pre><code>
a e	a	e
a e	ala	ale
a i	ala	ali
a i	la	li
a i	ma	mi
a i	poka	poki
a o	a	o
a o	pana	pona
a u	anpa	unpa
a u	ma	mu
e i	ale	ali
e i	ken	kin
e o	e	o
e o	ken	kon
e o	len	lon
e o	meli	moli
e u	seli	suli
e u	sewi	suwi
i o	kin	kon
i o	seli	selo
i o	sina	sona
i u	mi	mu
j k	jo	ko
j l	ijo	ilo
j p	jan	pan
j s	jelo	selo
j t	jan	tan
j t	jelo	telo
j w	jan	wan
k l	ken	len
k l	kili	lili
k l	kon	lon
k m	kama	mama
k m	kute	mute
k n	poka	pona
k p	luka	lupa
k s	kama	sama
k s	kin	sin
l m	kala	kama
l m	la	ma
l m	li	mi
l n	li	ni
l p	li	pi
l s	lupa	supa
l s	walo	waso
l t	kule	kute
l t	laso	taso
l t	lawa	tawa
l w	laso	waso
l w	lawa	wawa
l w	seli	sewi
l w	suli	suwi
m n	mi	ni
m p	mi	pi
m s	mama	sama
m s	meli	seli
m t	mu	tu
n p	ni	pi
n p	noka	poka
n p	pini	pipi
n t	pana	pata
p s	pona	sona
p t	pan	tan
p t	poki	toki
p w	pan	wan
s t	selo	telo
t w	tan	wan
t w	taso	waso
t w	tawa	wawa
</code>
</pre>
</div>
</asp:Content>
