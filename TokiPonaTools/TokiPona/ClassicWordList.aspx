<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="ClassicWordList.aspx.cs" Inherits="TokiPona.ClassicWordList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
dt[lang=tp]{
    color:#800000;
}

dd[lang=eo]{
    color:#008000;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
<h2>Classic Word List (Improved!)</h2> 
<p>There are three important ways to approach the toki pona lexicon: the classic wordlist, the official wiki, the corpus. The classic list is from about 2007 and had 118 words (as compared to about 125 depending on what you count). The classic word list was complete and had things to say about part of speech that have since become controversial. In about 2009, the official word list changed to a wiki. The wiki version has a main and "talk" section for each word, where the "talk" section indicates ideas in progress.  As of 2010, the wiki hasn't filled in all the meanings, so tokiponists must resort to using the classic list.</p>
<p>Another problem with the classic list is words in one language don't map neatly to words in another. There are <a href="http://dictionary.reference.com/browse/love">28 distinct meanings for love in English</a>, it isn't certain all of them are equal to olin.  jan Sonja speaks French, Esperanto and English. So the translations of those three languages read together probably mirror mostly closely the originally intended meanings, unfortunately, AFAIK, jan Sonja never wrote a canonical French word list.</p> 
<p>In many places you will find word origins for each word. However, these are not so useful for understanding what the word means. In a natural language, words are borrowed and probably borrow some of the original meaning--yes there are many counter examples. My point is, there is no reason to suspect that kala has the same semantic range as fish in Finnish. The word origins are impractical trivia.</p>
<p>In about 2009, jan Kipo proposed a new view of how part of speech works in toki pona-- roughly that each word can be typically one POS, and has a certain pridictable meaning when it is used outside of it's ordinary POS role.</p>
<p>Professional lexicographers determine the meaning of a word by finding example usages.  By 2010 the toki pona corpus was large enough to find dozen of examples of most kinds of usages for each word. Unlike movie languages like Na'vi and Klingon, the canonical corpus isn't so clearly defined in toki pona. Some jan Sonja and jan Pije sentences are questionable and many usages are found only in fan writings.</p>

<%--あ a | 獣 akesi | 無 ala | 探 alasa | 全 ali | 下 anpa | 变 ante | ぬ anu | 待 awen | え e | ん en | 市 esun | 物 ijo | 悪 ike | 具 ilo | 内 insa | 汚 jaki | 人 jan | 黄 jelo | 有 jo | 魚 kala | 音 kalama | 来 kama | 木 kasi | 能 ken | 使 kepeken | 果 kili | 又 kin | 切 kipisi | 石 kiwen | 粉 ko | 空 kon | 色 kule | 聞 kute | 群 kulupu | ら la | 眠 lape | 青 laso | 首 lawa | 布 len | 冷 lete | り li | 小 lili | 糸 linja | 葉 lipu | 赤 loje | 在 lon | 手 luka | 見 lukin | 穴 lupa | 土 ma | 母 mama | 貝 mani | 女 meli | 私 mi | 男 mije | 食 moku | 死 moli | 後 monsi | む mu | 月 mun | 楽 musi | 多 mute | 冗 >namako | 番 nanpa | 狂 nasa | 道 nasin | 丘 nena | 此 ni | 称 nimi | 足 noka | お o | 目 oko | 愛 olin | 彼 ona | 開 open | 打 pakala | 作 pali | 棒 palisa | 米 pan | 授 pana | 氏 pata | ぴ pi | 心 pilin | 黒 pimeja | 終 pini | 虫 pipi | 側 poka | 箱 poki | 良 pona | 同 sama | 何 seme | 火 seli | 皮 selo | 上 sewi | 丸 sike | 体 sijelo | 新 sin | 君 sina | 前 sinpin | 画 sitelen | 知 sona | 猫 soweli | 大 suli | 日 suno | 面 supa | 甜 suwi | 因 tan | 許 taso | 去 tawa | 水 telo | 时 tenpo | 言 toki | 家 tomo | 二 tu | 盛 unpa | 口 uta | 戦 utala | 白 walo | 一 wan | 鳥 waso | 遥 weka | 力 wawa | 要 wile --%>

<%--dictionary.Add("a", "啊");
            dictionary.Add("akesi", "龟");//[gui1] 
            dictionary.Add("ala", "不");//[bu2] 
            dictionary.Add("ale", "全"); //[quan2]
            dictionary.Add("ali", "全");//[quan2] 
            dictionary.Add("anpa", "下"); //[xia4]
            dictionary.Add("ante", "变");//[bian4] 
            dictionary.Add("anu", "或");//[huo4] 
            dictionary.Add("awen", "守");//[shou3] 
            dictionary.Add("e", "把");//[ba3] particle used before a noun to show it’s the DO
            dictionary.Add("en", "又");//[you4] 
            dictionary.Add("ijo", "事");//[shi4] 
            dictionary.Add("ike", "歹");//[dai3] 
            dictionary.Add("ilo", "匕");//[bi3] 
            dictionary.Add("insa", "内");//[nei4] 
            dictionary.Add("jaki", "污 ");//[wu1]<Unicode var. of 汙>
            //dictionary.Add("jaki", "汙>");//[wu1]

            dictionary.Add("jan", "人");//＊[ren2]
            dictionary.Add("jelo", "黄");//[huang2] 
            dictionary.Add("jo", "有");//＊[you3] 
            dictionary.Add("kala", "鱼");//[yu2] 
            dictionary.Add("kalama", "音");//[yin4] 
            dictionary.Add("kama", "到");//[dao4] 
            dictionary.Add("kasi", "木");//[mu4] 
            dictionary.Add("ken", "能");//[neng2] 
            dictionary.Add("kepeken", "用");//[yong4] 
            dictionary.Add("kili", "果");//[guo3] 
            dictionary.Add("kin", "也");//[ye3] 
            dictionary.Add("kiwen", "石");//[shi2] 
            dictionary.Add("ko", "膏");//＊[gao1] 
            dictionary.Add("kon", "气");//＊[qi4]  ［空气的气］
            dictionary.Add("kule", "色");//[se4] 
            dictionary.Add("kute", "耳");//[er3] 
            dictionary.Add("kulupu", "组");//[zu3] 
            dictionary.Add("la", "喇");//[la1] <phonetic character>
            dictionary.Add("lape", "觉");//[jiao] 
            dictionary.Add("laso", "青");//[qing1] 
            dictionary.Add("lawa", "首");//[shou3] 
            dictionary.Add("len", "巾");//[jin1] 
            dictionary.Add("lete", "冰");//[bing1] 
            dictionary.Add("li", "哩");//＊ [li]
            dictionary.Add("lili", "小");//[xiao3] 
            dictionary.Add("linja", "糸");//[mi4] 
            dictionary.Add("lipu", "叶");//[ye4] 
            dictionary.Add("loje", "红");//[hong2] 
            dictionary.Add("lon", "在");//[zai4] 
            dictionary.Add("luka", "手");//[shou3] 
            dictionary.Add("lukin", "看");//[kan4]
            //dictionary.Add("lukin", "见");//[jian4] 

            dictionary.Add("lupa", "孔");//[kong3] 
            dictionary.Add("ma", "土");//[tu3] 
            dictionary.Add("mama", "母");//[mu3] 
            dictionary.Add("mani", "元");//[yuan2]
            //dictionary.Add("mani", "贝");//[bei4]

            dictionary.Add("meli", "女");//[nü3 (nv3)] 
            dictionary.Add("mi", "我");//[wo3] 
            dictionary.Add("mije", "男");//[nan2] 
            dictionary.Add("moku", "菜");//[cai4] 
            dictionary.Add("moli", "死");//[si3] 
            dictionary.Add("monsi", "后");//[hou4] 
            dictionary.Add("mu", "吽");//[ou2,hou2] 
            dictionary.Add("mun", "月");//[yue4] 
            dictionary.Add("musi", "玩");//[wan2] 
            dictionary.Add("mute", "大");//[da] 
            dictionary.Add("nanpa", "个");//[ge4] 
            dictionary.Add("nasa", "怪");//[guai4] 
            dictionary.Add("nasin", "道");//[dao4] 
            dictionary.Add("nena", "山");//[shan1] 
            dictionary.Add("ni", "这");//＊[zhe4] 
            dictionary.Add("nimi", "名");//[ming2] 
            dictionary.Add("noka", "足");//[zu2] 
            dictionary.Add("o", "令");//[ling4] 
            dictionary.Add("oko", "目");//[mu4] 
            dictionary.Add("olin", "爱");//[ai4] 
            dictionary.Add("ona", "他");//[ta1] 
            dictionary.Add("open", "开");//[kai1] 
            dictionary.Add("pakala", "打");//[da3] 
            dictionary.Add("pali", "工");//[gong1] 
            dictionary.Add("palisa", "支 ");//[zhi1] (measure word for rods, pens, guns, etc.)
            dictionary.Add("pan", "米");//[mi3] 
            dictionary.Add("pana", "给");//[gei3] 
            dictionary.Add("pi", "的");//[de] 
            dictionary.Add("pilin", "想");//[xiang3] 
            //dictionary.Add("pilin", "心");//[xin1] 

            dictionary.Add("pimeja", "黑");//[hei1] 
            dictionary.Add("pini", "末");//[mo4]
            dictionary.Add("pipi", "虫");//[chong2]
            dictionary.Add("poka", "旁");//[pang2] 
            dictionary.Add("poki", "包");//[bao1] 
            dictionary.Add("pona", "好"); //[hao3] 
            dictionary.Add("sama", "同"); //[tong2]
            dictionary.Add("seli", "火"); //[huo3] 
            dictionary.Add("selo", "甲"); //[jia3] 
            dictionary.Add("seme", "什"); //＊[she2]（什么的什）
            dictionary.Add("sewi", "上"); //[shang4] 
            dictionary.Add("sijelo", "身"); //[shen1] 
            dictionary.Add("sike", "回");//[hui2] 
            dictionary.Add("sin", "新"); //[xin1]
            dictionary.Add("sina", "你"); //[ni3]
            dictionary.Add("sinpin", "前"); //[qian2]
            dictionary.Add("sitelen", "画"); //[hua4]
            dictionary.Add("sona", "知"); //[zhi1/4]
            //dictionary.Add("soweli", "牛"); //[niu2]
            dictionary.Add("soweli", "马"); //[ma3]

            dictionary.Add("suli", "高");//[gao1] 
            dictionary.Add("suno", "日"); //[ri4] 
            //dictionary.Add("suno","光"); //[guang1]

            dictionary.Add("supa", "张 "); //[zhang1] (measure word for flat objects)
            dictionary.Add("suwi", "甜"); //[tian2] 
            dictionary.Add("tan", "从"); //[cong2] 
            dictionary.Add("taso", "只"); //[zhi3] 
            dictionary.Add("tawa", "去"); //[qu4] 
            dictionary.Add("telo", "水"); //[shui3] 
            dictionary.Add("tenpo", "时"); //[shi2] 
            dictionary.Add("toki", "言"); //[yan2]
            dictionary.Add("tomo", "穴"); //[xue2]
            dictionary.Add("tu", "二"); //[er4]
            dictionary.Add("unpa", "性"); //[xing4]
            dictionary.Add("uta", "口"); //[kou3]
            //dictionary.Add("utala","战");//[zhan4] 
            dictionary.Add("utala", "斗"); //[dou4]

            dictionary.Add("walo", "白"); //[bai2] 
            dictionary.Add("wan", "一"); //[yi1] 
            dictionary.Add("waso", "鸟"); //[niao3] 
            dictionary.Add("wawa", "力"); //[li4] 
            dictionary.Add("weka", "脱"); //[tuo1] 
            dictionary.Add("wile", "要"); //[yao4] --%>

<p><b>Note regarding the Kanji/Hanji/Hiragana</b>: These are not Japanese/Chinese translations, but the single characters per word toki pona script. It is extremely useful if not necesssary for twitter messages. At the moment, there may be 3 or 4 alternatives for the Kanji/Hanji.</p>
<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_a.jpg" /> </td>
<td valign="top">
<dl> 
<dt lang="tp"><a name="a"></a> a あ (jp),  啊(zh) </dt> 
<dd lang="en"><i>interj</i>	ah, ha, uh, oh, ooh, aw, well (emotion word)</dd>   
<dd lang="en"><a href="http://en.tokipona.org/wiki/a">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:a">drafts</a></dd> 
<dd lang="eo"><em>kri</em> ho, ha, uf, nu, oj, a&#365; (emocivorto)</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=a&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=a">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/a/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_akesi.jpg" /> </td>
<td valign="top">
<dl> 
<a name="akesi"></a> 
<dt lang="tp">akesi 獣 (jp), 龟 (zh) gui1</dt> 
<dd lang="en"><i>n</i>	non-cute animal, reptile, amphibian</dd> 

<dd lang="eo"><em>o</em> malkaresinda besto, rampulo, amfibio</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=akesi&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=akesi">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/akesi/">Forvo pronunciation</a></dd>

<dd lang="en"><a href="http://en.tokipona.org/wiki/akesi">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:akesi">drafts</a></dd>

<dd lang="en"><i>noun</i> creeping animal, a scaly or slimy animal that creeps on land</dd>
<dd lang="en"><i>noun</i> reptile, any air-breathing cold-blooded animal that crawls on land and has scales and bones; reptile</dd>
<dd lang="en"><i>noun</i> amphibian, any cold-blooded animal with bones that lives on both land and in water; amphibian</dd>
<dd lang="en"><i>noun</i> large arthropod, a large arthropod that lives on land; scorpion</dd>
<dd lang="en"><i>describer</i> like an <b>akesi</b> in appearance</dd>
<dd lang="en"><i>describer</i>having the characteristics or properties of an <b>akesi</b> </dd>

</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_ala.jpg" /> </td>
<td valign="top">
<dl> 
<a name="ala"></a> 
<dt lang="tp">ala 無 (jp), 不(zh) bu2</dt> 
<dd lang="en"><i>mod</i>	no, not, none, un-</dd> 
<dd lang="en"><i>n</i>	nothing, negation, zero</dd> 
<dd lang="en"><i>interj</i>	no!</dd> 
<dd lang="eo"><em>a </em>ne, neniu<br/>
      <em>o </em>nenio, neado, nul<br/>
      <em>kri </em>ne!</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=ala&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=ala">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/ala/">Forvo pronunciation</a></dd>
<dd lang="en"><a href="http://en.tokipona.org/wiki/ala">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:ala">drafts</a></dd>
<dd lang="en"><i>describer</i> not, not such; no, not</dd>
<dd lang="en"><i>describer</i> no, zero, no quantity of; no, zero</dd>
<dd lang="en"><i>describer</i> un-, opposite of; un-</dd>
<dd lang="en"><i>noun</i> the state, situation or general phenomenon of being <b>ala</b>; absence, emptiness, negation, nothing, zero</dd>
<dd lang="en"><i>interjection</i> a short, sudden or emotional expression of <b>ala</b>; no! </dd> 
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_alasa.jpg" /> </td>
<td valign="top">
<dl> 
<a name="alasa"></a> 
<dt lang="tp">alasa 探 (jp)</dt> 
<dd lang="en">* This wasn't on the classic list.</dd> 
<dd><a href="http://tatoeba.org/eng/sentences/search?query=alasa&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=alasa">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/alasa/">Forvo pronunciation</a></dd>
<dd lang="en"><a href="http://en.tokipona.org/wiki/alasa">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:alasa">drafts</a></dd>
<dd lang="en"><i>transitive verb</i> to gather, to collect food, resources or material needed for daily life and survival; to gather, harvest</dd>
<dd lang="en"><i>transitive verb</i> to hunt, to pursue and kill animals to use as food and clothing; to hunt</dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_ale.jpg" /> </td>
<td valign="top">
<dl> 
<a name="ale"></a> <a name="ali"></a> 
<dt lang="tp">ale, ali, 全 (jp), 全 (zh) quan2</dt> 
<dd lang="en"><i>n</i>	everything, anything, life, the universe</dd> 
<dd lang="en"><i>mod</i>	all, every, complete, whole</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/ale,_ali">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:ale,_ali">drafts</a></dd> 
<dd lang="eo"><em>(amba&#365; varia&#309;oj estas &#285;ustaj)</em><br/>
      <em>o </em>&#265;io, la vivo, la universo<br/>
      <em>a </em> &#265;iu(j), tuta, kompleta </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=ale&from=toki&to=und">Tatoeba corpus (ale)</a></dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=ali&from=toki&to=und">Tatoeba corpus (ali)</a></dd>
<dd><a href="CorpusSearch.aspx?word=ale">tokipona.net corpus (ale)</a></dd>
<dd><a href="CorpusSearch.aspx?word=ali">tokipona.net corpus (ali)</a></dd>
<dd><a href="http://www.forvo.com/word/ale/">Forvo pronunciation (ale)</a></dd>
<dd><a href="http://www.forvo.com/word/ali/">Forvo pronunciation (ali)</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_anpa.jpg" /> </td>
<td valign="top">
<dl> 
<a name="anpa"></a>
<dt lang="tp">anpa 下 (jp), 下(zh) xia4</dt> 
<dd lang="en"><i>n</i>	bottom, lower part, under, below, floor, beneath</dd> 
<dd lang="en"><i>mod</i>	low, lower, bottom, down</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/anpa">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:anpa">drafts</a></dd> 
<dd lang="eo"><em>o</em> malsupro, subo, suba parto, planko<br/>
      <em>a </em>malsupra, suba
      <!-- <br>
<em>vtr </em>malsuprigi, subigi, superi --> 
    </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=anpa&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=anpa">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/anpa/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_ante.jpg" /> </td>
<td valign="top">
<dl> 
<a name="ante"></a>
<dt lang="tp">ante 变 (jp), 变 (zh) bian4</dt> 
<dd lang="en"><i>n</i>	difference</dd> 
<dd lang="en"><i>mod</i>	different</dd> 
<dd lang="en"><i>conj</i>	otherwise, or else</dd> 
<dd lang="en"><i>vt</i>	change, alter, modify</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/ante">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:ante">drafts</a></dd> 
<dd lang="eo"> <em>o</em> diferenco, malsameco<br/>
      <em>a</em> alia, malsama&nbsp;<br/>
      <em>kunt </em>alie, aliokaze<br/>
      <em>vtr </em>&#349;an&#285;i, aliigi </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=ante&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=ante">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/ante/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_anu.jpg" /> </td>
<td valign="top">
<dl> 
<a name="anu"></a>
<dt lang="tp">anu ぬ (jp), 或 (zh) huo4</dt> 
<dd lang="en"><i>conj</i>	or</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/anu">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:anu">drafts</a></dd> 
<dd lang="eo"><em>konj</em> a&#365;</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=anu&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=anu">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/anu/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_awen.jpg" /> </td>
<td valign="top">
<dl> 
<a name="awen"></a>
<dt lang="tp">awen 待 (jp), 守 (zh) shou3</dt> 
<dd lang="en"><i>vi</i>	stay, wait, remain</dd> 
<dd lang="en"><i>vt</i>	keep</dd> 
<dd lang="en"><i>mod</i>	remaining, stationary, permanent, sedentary</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/awen">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:awen">drafts</a></dd> 
<dd lang="eo"><em>vntr</em> resti, atendi, da&#365;ri<br/>
      <em>vtr </em>gardi<br/>
      <em>a </em>restanta, cetera, da&#365;ra </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=awen&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=awen">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/awen/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_e.jpg" /> </td>
<td valign="top">
<dl> 
<a name="e"></a>
<dt lang="tp">e  え(jp), 把 (zh) ba3</dt> 
<dd lang="en"><i>sep</i>	(introduces a direct object)</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/e">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:e">drafts</a></dd> 
<dd lang="eo"><em>div</em> -n (indikas, ke akuzativon sekvas)</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=e&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=e">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/e/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_en.jpg" /> </td>
<td valign="top">
<dl> 
<a name="en"></a>
<dt lang="tp">en ん (jp), 又 (zh) you4</dt> 
<dd lang="en"><i>conj</i>	and (used to coordinate head nouns)</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/en">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:en">drafts</a></dd> 
<dd lang="eo"><i>konj</i> kaj (uzata por kunordigi o-vortojn)
      <!-- <br>
		  <i>prep</i> kun, akompani, inter --> 
    </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=en&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=en">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/en/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_esun.jpg" /> </td>
<td valign="top">
<dl> 
<a name="esun"></a>
<dt lang="tp">esun 市 (jp), </dt> 
<dd lang="en"><i>n</i>	market, shop</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/esun">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:esun">drafts</a></dd> 

<dd><a href="http://tatoeba.org/eng/sentences/search?query=esun&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=esun">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/esun/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_ijo.jpg" /> </td>
<td valign="top">
<dl> 
<a name="ijo"></a>
<dt lang="tp">ijo 物 (jp),事 (zh) shi4</dt> 
<dd lang="en"><i>n</i>	thing, something, stuff, anything, object</dd> 
<dd lang="en"><i>mod</i>	of something</dd> 
<dd lang="en"><i>vt</i>	objectify</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/ijo">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:ijo">drafts</a></dd> 
<dd lang="eo"><i>n</i> a&#309;o, afero, io, objekto<br/>
      <em>a</em> de io, pri io<br/>
      <i>vtr</i> objektigi</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=ijo&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=ijo">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/ijo/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_ike.jpg" /> </td>
<td valign="top">
<dl> 
<a name="ike"></a>
<dt lang="tp">ike 悪, 歹 (zh) dai3</dt> 
<dd lang="en"><i>mod</i>	bad, negative, wrong, evil, overly complex, (figuratively) unhealthy</dd> 
<dd lang="en"><i>interj</i>	oh dear! woe! alas!</dd> 
<dd lang="en"><i>n</i>	negativity, badness, evil</dd> 
<dd lang="en"><i>vt</i>	to make bad, to worsen, to have a negative effect upon</dd> 
<dd lang="en"><i>vi</i>	to be bad, to suck</dd> 
<dd lang="en">[sounds like icky]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/ike">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:ike">drafts</a></dd> 
<dd lang="eo"><i>a</i> malbona, a&#265;a, mal&#285;usta, malica, tro kompleksa, 
      (figure) malsana<br/>
      <i>kri</i> ho ve!<br/>
      <em>o</em> negativeco, malbono, malico<br/>
      <em>vtr</em> malbonigi, noci<br/>
      <em>vntr</em> a&#265;i</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=ike&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=ike">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/ike/">Forvo pronunciation</a></dd>      
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_ilo.jpg" /> </td>
<td valign="top">
<dl>  
<a name="ilo"></a>
<dt lang="tp">ilo 具 (jp), 匕 (zh) bi3</dt> 
<dd lang="en"><i>n</i>	tool, device, machine, thing used for a specific purpose</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/ilo">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:ilo">drafts</a></dd> 
<dd lang="eo"><i>o</i> ilo, ma&#349;ino</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=ilo&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=ilo">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/ilo/">Forvo pronunciation</a></dd>      
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_insa.jpg" /> </td>
<td valign="top">
<dl> 
<a name="insa"></a>
<dt lang="tp">insa 内 (jp), 内 (zh) nei4</dt> 
<dd lang="en"><i>n</i>	inside, inner world, centre, stomach</dd> 
<dd lang="en"><i>mod</i>	inner, internal</dd> 
<dd lang="en">[inside]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/insa">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:insa">drafts</a></dd> 
<dd lang="eo"><i>o</i> eno, interno, interna mondo, centro, ventro<br/>
      <em>a</em> ena, interna</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=insa&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=insa">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/insa/">Forvo pronunciation</a></dd>      
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_jaki.jpg" /> </td>
<td valign="top">
<dl> 
<a name="jaki"></a>
<dt lang="tp">jaki 汚 (jp), 污 (zh) wu1, or 汙</dt> 
<dd lang="en"><i>mod</i>	dirty, gross, filthy</dd> 
<dd lang="en"><i>n</i>	dirt, pollution, garbage, filth</dd> 
<dd lang="en"><i>vt</i>	pollute, dirty</dd> 
<dd lang="en"><i>interj</i>	ew! yuck!</dd> 
<dd lang="en">[yucky]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/jaki">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:jaki">drafts</a></dd> 
<dd lang="eo"><i>a</i> malpura, na&#365;za<br/>
      <i>o</i> malpuro, poluo, rubo<br/>
      <em>vtr</em> malpurigi, polui<br/>
      <i>kri</i> kiom na&#365;ze!</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=jaki&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=jaki">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/jaki/">Forvo pronunciation</a></dd>      
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_jan.jpg" /> </td>
<td valign="top">
<dl> 
<a name="jan"></a>
<dt lang="tp">jan 人 (jp), 人 (zh) ren2</dt> 
<dd lang="en"><i>n</i>	person, people, human, being, somebody, anybody</dd> 
<dd lang="en"><i>mod</i>	human, somebody's, personal, of people</dd> 
<dd lang="en"><i>vt</i>	personify, humanize, personalize</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/jan">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:jan">drafts</a></dd> 
<dd lang="eo"><i>a</i> homo, ulo, persono, esta&#309;o, iu<br/>
      <em>o</em> homa, ies, persona <br/>
      <em>vtr</em> personigi, homigi</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=jan&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=jan">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/jan/">Forvo pronunciation</a></dd>      
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_jelo.jpg" /> </td>
<td valign="top">
<dl> 
<a name="jelo"></a>
<dt lang="tp">jelo 黄 (jp), 黄 (zh) huang2</dt> 
<dd lang="en"><i>mod</i>	yellow, light green</dd> 
<dd lang="en">[yellow]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/jelo">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:jelo">drafts</a></dd> 
<dd lang="eo"><em>a</em> flava, helverda</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=jelo&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=jelo">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/jelo/">Forvo pronunciation</a></dd>      
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_jo.jpg" /> </td>
<td valign="top">
<dl> 
<a name="jo"></a>
<dt lang="tp">jo  有 (jp), 有 (zh) you3</dt> 
<dd lang="en"><i>vt</i>	have, contain</dd> 
<dd lang="en"><i>n</i>	having</dd> 
<dd lang="en"><i>kama</i>	receive, get, take, obtain</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/jo">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:jo">drafts</a></dd> 
<dd lang="eo"><i>vtr</i> havi, enhavi, enteni<br/>
      <em>o</em> havado<br><em>kama</em> ricevi, preni</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=jo&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=jo">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/jo/">Forvo pronunciation</a></dd>            
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_kala.jpg" /> </td>
<td valign="top">
<dl> 
<a name="kala"></a>
<dt lang="tp">kala 魚, 鱼 (zh) yu2</dt> 
<dd lang="en"><i>n</i>	fish, sea creature</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/kala">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:kala">drafts</a></dd> 
<dd lang="eo"><i>o</i> fi&#349;o, marbesto</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=kala&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=kala">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/kala/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_kalama.jpg" /> </td>
<td valign="top">
<dl> 
<a name="kalama"></a>
<dt lang="tp">kalama 音 (jp), 音(zh) yin4</dt> 
<dd lang="en"><i>n</i>	sound, noise, voice</dd> 
<dd lang="en"><i>vi</i>	make noise</dd> 
<dd lang="en"><i>vt</i>	sound, ring, play (an instrument)</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/kalama">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:kalama">drafts</a></dd> 
<dd lang="eo"><i>o</i> sono, bruo, vo&#265;o<br/>
      <em>vntr</em> soni, brui, sonori<br/>
      <em>vtr</em> sonigi, ludi (instrumenton)</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=kalama&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=kalama">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/kalama/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_kama.jpg" /> </td>
<td valign="top">
<dl> 
<a name="kama"></a>
<dt lang="tp">kama 来 (jp), 到 (zh) dao4</dt> 
<dd lang="en"><i>vi</i>	come, become, arrive, happen, pursue actions to arrive to (a certain state), manage to, start to</dd> 
<dd lang="en"><i>n</i>	event, happening, chance, arrival, beginning</dd> 
<dd lang="en"><i>mod</i>	coming, future</dd> 
<dd lang="en"><i>vt</i>	bring about, summon</dd> 
<dd lang="en">[come up]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/kama">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:kama">drafts</a></dd> 
<dd lang="eo"> <i>vntr</i> veni, i&#285;i, aperi, alveni, okazi, agi por 
      veni al (iu stato), sukcesi, ek-<br/>
      <i>o</i> evento, okazo, hazardo, veno, komenco<br/>
      <i>a</i> venanta, estonta<br/>
      <!--            <i>kunt</i> estontece<br/>--> 
      <i>vtr</i> venigi</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=kama&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=kama">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/kama/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_kasi.jpg" /> </td>
<td valign="top">
<dl> 
<a name="kasi"></a>
<dt lang="tp">kasi 木 (jp), 木 (zh) mu4</dt> 
<dd lang="en"><i>n</i>	plant, leaf, herb, tree, wood</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/kasi">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:kasi">drafts</a></dd> 
<dd lang="eo"><i>o</i> planto, folio, herbo, arbo, ligno</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=kasi&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=kasi">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/kasi/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_ken.jpg" /> </td>
<td valign="top">
<dl> 
<a name="ken"></a>
<dt lang="tp">ken 能 (jp), 能 (zh) neng2</dt> 
<dd lang="en"><i>vi</i>	can, is able to, is allowed to, may, is possible</dd> 
<dd lang="en"><i>n</i>	possibility, ability, power to do things, permission</dd> 
<dd lang="en"><i>vt</i>	make possible, enable, allow, permit</dd> 
<dd lang="en"><i>cont</i>	it is possible that</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/ken">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:ken">drafts</a></dd> 
<dd lang="eo"> <em>vntr</em> povi, kapabli, rajti<br/>
      <em>o</em> povo, kapablo, rajto<br/>
      <em>vtr</em> ebligi, rajtigi, permesi<br/>
      <em>kunt</em> eblas, ke</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=ken&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=ken">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/ken/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_kepeken.jpg" /> </td>
<td valign="top">
<dl> 
<a name="kepeken"></a>      
<dt lang="tp">kepeken 使 (jp), 用 (zh) yong4</dt> 
<dd lang="en"><i>vt</i>	use</dd> 
<dd lang="en"><i>prep</i>	with</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/kepeken">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:kepeken">drafts</a></dd> 
<dd lang="eo"><i>vtr</i> uzi<br/>
      <em>prep</em> per</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=kepeken&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=kepeken">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/kepeken/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_kili.jpg" /> </td>
<td valign="top">
<dl> 
<a name="kili"></a>      
<dt lang="tp">kili 果 (jp), 果, (zh) guo3</dt> 
<dd lang="en"><i>n</i>	fruit, pulpy vegetable, mushroom</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/kili">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:kili">drafts</a></dd> 
<dd lang="eo"><em>o</em> frukto, pulpa legomo, fungo</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=kili&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=kili">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/kili/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_kin.jpg" /> </td>
<td valign="top">
<dl> 
<a name="kin"></a>
<dt lang="tp">kin 又 (jp), 也 (zh) ye3</dt> 
<dd lang="en"><i>mod</i>	also, too, even, indeed (emphasizes the word(s) before it)</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/kin">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:kin">drafts</a></dd> 
<dd lang="eo"><em>a </em> anka&#365;, e&#265;, ja (akcentas la vorto(j)n 
      anta&#365; &#285;i)</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=kin&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=kin">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/kin/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_kipisi.jpg" /> </td>
<td valign="top">
<dl> 
<a name="kipisi"></a>
<dt lang="tp">kipisi 切</dt> 
<dd lang="en">* this wasn't in the original classic word list.</dd> 
<dd lang="en">to cut</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/kipisi">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:kipisi">drafts</a></dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=kipisi&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=kipisi">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/kipisi/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_kiwen.jpg" /> </td>
<td valign="top">
<dl> 
<a name="kiwen"></a>
<dt lang="tp">kiwen 石 (jp), 石 (zh) shi2</dt> 
<dd lang="en"><i>mod</i>	hard, solid, stone-like, made of stone or metal</dd> 
<dd lang="en"><i>n</i>	hard thing, rock, stone, metal, mineral, clay</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/kiwen">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:kiwen">drafts</a></dd> 
<dd lang="eo"><em>a</em> malmola, dura, solida, &#349;ton(ec)a, metala 
      <br/>
      <i>o</i> malmola&#309;o, &#349;tono, metalo, mineralo, argilo </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=kiwen&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=kiwen">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/kiwen/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_ko.jpg" /> </td>
<td valign="top">
<dl> 
<a name="ko"></a>
<dt lang="tp">ko 粉 (jp), 膏 (zh) gao1</dt> 
<dd lang="en"><i>n</i>	semi-solid or squishy substance, e.g. paste, powder, gum</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/ko">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:ko">drafts</a></dd> 
<dd lang="eo"><em>o</em> duonsolida a&#365; premebla substanco, ekz. pasto, 
      pulvoro, gumo</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=ko&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=ko">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/ko/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_kon.jpg" /> </td>
<td valign="top">
<dl> 
<a name="kon"></a>
<dt lang="tp">kon 空 (jp), 气 (zh) qi4</dt> 
<dd lang="en"><i>n</i>	air, wind, smell, soul</dd> 
<dd lang="en"><i>mod</i>	air-like, ethereal, gaseous</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/kon">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:kon">drafts</a></dd> 
<dd lang="eo"><i>o</i> aero, vento, odoro, animo
      <!-- , spirito --> 
      <br/>
      <em>a</em> aera, gasa</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=kon&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=kon">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/kon/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_kule.jpg" /> </td>
<td valign="top">
<dl> 
<a name="kule"></a>
<dt lang="tp">kule 色 (jp), 色 (zh) se4</dt> 
<dd lang="en"><i>n</i>	colour, paint</dd> 
<dd lang="en"><i>mod</i>	colourful</dd> 
<dd lang="en"><i>vt</i>	colour, paint</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/kule">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:kule">drafts</a></dd> 
<dd lang="eo"><i>o</i> koloro, farbo<br/>
      <em>a</em> kolora, bunta<br/>
      <em>vtr</em> kolori, farbi</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=kule&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=kule">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/kule/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_kute.jpg" /> </td>
<td valign="top">
<dl> 
<a name="kute"></a>
<dt lang="tp">kute 聞 (jp), 耳 (zh) er3</dt> 
<dd lang="en"><i>vt</i>	listen, hear</dd> 
<dd lang="en"><i>mod</i>	auditory, hearing</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/kute">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:kute">drafts</a></dd> 
<dd lang="eo"><i>vtr</i> a&#365;skulti, a&#365;di<br/>
      <i>a</i> a&#365;da, a&#365;skulta</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=kute&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=kute">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/kute/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_kulupu.jpg" /> </td>
<td valign="top">
<dl> 
<a name="kulupu"></a>
<dt lang="tp">kulupu 群 (jp), 组 (zh) zu3</dt> 
<dd lang="en"><i>n</i>	group, community, society, company, people</dd> 
<dd lang="en"><i>mod</i>	communal, shared, public, of the society</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/kulupu">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:kulupu">drafts</a></dd> 
<dd lang="eo"><i>o</i> grupo, komunumo, socio, firmao, popolo <br/>
      <em>a</em> komuna, publika, socia</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=kulupu&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=kulupu">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/kulupu/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_la.jpg" /> </td>
<td valign="top">
<dl> 
<a name="la"></a>
<dt lang="tp">la ら (jp), 喇 (zh) la1</dt> 
<dd lang="en"><i>sep</i>	(between adverb or phrase of context and sentence)</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/la">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:la">drafts</a></dd> 
<dd lang="eo"><i>div</i> (inter kunteksta adverbo a&#365; esprimo kaj la 
      frazo)</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=la&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=la">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/la/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_lape.jpg" /> </td>
<td valign="top">
<dl> 
<a name="lape"></a>
<dt lang="tp">lape 眠 (jp), 觉 (zh) jiao</dt> 
<dd lang="en"><i>n, vi</i>	sleep, rest</dd> 
<dd lang="en"><i>mod</i>	sleeping, of sleep</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/lape">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:lape">drafts</a></dd> 
<dd lang="eo"><i>o</i> dormo, ripozo<br/>
      <em>vntr</em> dormi, ripozi <em>a</em> dormanta, dorma, ripoza</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=lape&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=lape">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/lape/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_laso.jpg" /> </td>
<td valign="top">
<dl> 
<a name="laso"></a>      
<dt lang="tp">laso 青 (jp), 青 (zh) qing1</dt> 
<dd lang="en"><i>mod</i>	blue, blue-green</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/laso">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:laso">drafts</a></dd> 
<dd lang="eo"><em>a</em> blua, bluverda</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=laso&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=laso">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/laso/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_lawa.jpg" /> </td>
<td valign="top">
<dl> 
<a name="lawa"></a>
<dt lang="tp">lawa 首 (jp), 首 (zh) shou3</dt> 
<dd lang="en"><i>n</i>	head, mind</dd> 
<dd lang="en"><i>mod</i>	main, leading, in charge</dd> 
<dd lang="en"><i>vt</i>	lead, control, rule, steer</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/lawa">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:lawa">drafts</a></dd> 
<dd lang="eo"><i>o</i> kapo, menso<br/>
      <i>a</i> &#265;efa, estra<br/>
      <i>vtr</i> estri, regi</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=lawa&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=lawa">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/lawa/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_len.jpg" /> </td>
<td valign="top">
<dl> 
<a name="len"></a>
<dt lang="tp">len 布 (jp), 巾 (zh) jin1</dt> 
<dd lang="en"><i>n</i>	clothing, cloth, fabric</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/len">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:len">drafts</a></dd> 
<dd lang="eo"><i>o</i> vesto(j), vesta&#309;o, &#349;tofo</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=len&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=len">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/len/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_lete.jpg" /> </td>
<td valign="top">
<dl> 
<a name="lete"></a>
<dt lang="tp">lete 冷 (jp), 冰 (zh) bing1</dt> 
<dd lang="en"><i>n</i>	cold</dd> 
<dd lang="en"><i>mod</i>	cold, uncooked</dd> 
<dd lang="en"><i>vt</i>	cool down, chill</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/lete">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:lete">drafts</a></dd> 
<dd lang="eo"><i>o</i> malvarmo<br/>
      <i>a</i> malvarma, frida, nekuirita<br/>
      <i>vtr</i> malvarmigi</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=lete&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=lete">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/lete/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_li.jpg" /> </td>
<td valign="top">
<dl> 
<a name="li"></a>
<dt lang="tp">li り (jp), 哩 (zh) li</dt> 
<dd lang="en"><i>sep</i>	"(between any subject except mi and sina and its verb; also used to introduce a new verb for the same subject)"</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/li">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:li">drafts</a></dd> 
<dd lang="eo"><i>div</i> (inter iu ajn subjekto, krom <strong>mi</strong> 
      kaj <strong>sina</strong>, kaj ties verbo; anka&#365; uzata por enkonduki 
      novan verbon por la sama subjekto)</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=li&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=li">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/li/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_lili.jpg" /> </td>
<td valign="top">
<dl> 
<a name="lili"></a>
<dt lang="tp">lili 小 (jp), 小 (zh) xiao3</dt> 
<dd lang="en"><i>mod</i>	small, little, young, a bit, short, few, less</dd> 
<dd lang="en"><i>vt</i>	reduce, shorten, shrink, lessen</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/lili">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:lili">drafts</a></dd> 
 <dd lang="eo"><i>a</i> malgranda, eta, juna, iomete, mallonga, malalta, 
      malmulte, malpli<br/>
      <em>vtr</em> malpliigi, mallongigi, malgrandigi</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=lili&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=lili">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/lili/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_linja.jpg" /> </td>
<td valign="top">
<dl> 
<a name="linja"></a>      
<dt lang="tp">linja 糸 (jp), 糸 (zh) mi4</dt> 
<dd lang="en"><i>n</i>	long, very thin, floppy thing, e.g. string, rope, hair, thread, cord, chain</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/linja">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:linja">drafts</a></dd> 
<dd lang="eo"><i>o</i> longa, tre maldika, malfirma objekto, ekz. &#349;nuro, 
      haro(j), &#265;eno</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=linja&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=linja">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/linja/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_lipu.jpg" /> </td>
<td valign="top">
<dl> 
<a name="lipu"></a>      
<dt lang="tp">lipu 葉 (jp), 叶 (zh) ye4</dt> 
<dd lang="en"><i>n</i>	flat and bendable thing, e.g. paper, card, ticket</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/lipu">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:lipu">drafts</a></dd> 
    <dd lang="eo"><i>o</i> plata kaj faldebla objekto, ekz. papero, karto, 
      bileto </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=lipu&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=lipu">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/lipu/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_loje.jpg" /> </td>
<td valign="top">
<dl> 
<a name="loje"></a>
<dt lang="tp">loje 赤 (jp), 红 (zh) hong2</dt> 
<dd lang="en"><i>mod</i>	red</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/loje">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:loje">drafts</a></dd> 
<dd lang="eo"><em>a</em> ru&#285;a</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=loje&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=loje">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/loje/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_lon.jpg" /> </td>
<td valign="top">
<dl> 
<a name="lon"></a>
<dt lang="tp">lon 在 (jp), 在 (zh) zai4</dt> 
<dd lang="en"><i>prep</i>	be (located) in/at/on</dd> 
<dd lang="en"><i>vi</i>	be there, be present, be real/true, exist, be awake</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/lon">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:lon">drafts</a></dd> 
<dd lang="eo"><i>prep</i> esti en/&#265;e/sur/je<br/>
      <i>vntr</i> &#265;eesti, esti tie, veri, ekzisti, esti veka</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=lon&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=lon">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/lon/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_luka.jpg" /> </td>
<td valign="top">
<dl> 
<a name="luka"></a>
<dt lang="tp">luka 手 (jp), 手 (zh) shou3</dt> 
<dd lang="en"><i>n</i>	hand, arm</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/luka">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:luka">drafts</a></dd> 
<dd lang="eo"><i>o</i> mano, brako</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=luka&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=luka">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/luka/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_lukin.jpg" /> </td>
<td valign="top">
<dl> 
<a name="lukin"></a>
<dt lang="tp">lukin 見 (jp), 看 (zh) kan4  (or 见 jian4)</dt> 
<dd lang="en"><i>vt</i>	see, look at, watch, read</dd> 
<dd lang="en"><i>vi</i>	look, watch out, pay attention</dd> 
<dd lang="en"><i>mod</i>	visual(ly)</dd> 
<dd lang="en">[looking]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/lukin">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:lukin">drafts</a></dd> 
<dd lang="eo"><i>vtr</i> vidi, rigardi, spekti, observi, legi<br/>
      <i>vntr</i> rigardi, atenti<br/>
      <i>a</i> vida, vide</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=lukin&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=lukin">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/lukin/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_lupa.jpg" /> </td>
<td valign="top">
<dl> 
<a name="lupa"></a>
<dt lang="tp">lupa 穴 (jp), 孔 (zh) kong3</dt> 
<dd lang="en"><i>n</i>	hole, orifice, window, door</dd> 
<dd lang="en">[sounds like loop]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/lupa">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:lupa">drafts</a></dd> 
<dd lang="eo"><i>o</i> truo, aperturo, orifico, fenestro, pordo</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=lupa&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=lupa">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/lupa/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_ma.jpg" /> </td>
<td valign="top">
<dl> 
<a name="ma"></a>
<dt lang="tp">ma 土 (jp), 土 (zh) tu3</dt> 
<dd lang="en"><i>n</i>	land, earth, country, (outdoor) area</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/ma">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:ma">drafts</a></dd> 
<dd lang="eo"><i>o</i> tero, lando, (ekstera) tereno</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=ma&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=ma">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/ma/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_mama.jpg" /> </td>
<td valign="top">
<dl> 
<a name="mama"></a>
<dt lang="tp">mama 母 (jp), 母 (zh) mu3</dt> 
<dd lang="en"><i>n</i>	parent, mother, father</dd> 
<dd lang="en"><i>mod</i>	of the parent, parental, maternal, fatherly</dd> 
<dd lang="en">[sounds like momma]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/mama">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:mama">drafts</a></dd> 
<dd lang="eo"><i>o</i> patrino, patro<br/>
      <i>a</i> gepatra, patra, patrina</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=mama&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=mama">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/mama/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_mani.jpg" /> </td>
<td valign="top">
<dl> 
<a name="mani"></a>
<dt lang="tp">mani 貝 (jp), 元 (zh) yuan2 (or 贝 bei4)</dt> 
<dd lang="en"><i>n</i>	money, material wealth, currency, dollar, capital</dd> 
<dd lang="en">[money]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/mani">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:mani">drafts</a></dd> 
<dd lang="eo"><i>o</i> mono, materia hava&#309;o, valuto, dolaro, kapitalo</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=mani&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=mani">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/mani/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_meli.jpg" /> </td>
<td valign="top">
<dl> 
<a name="meli"></a>
<dt lang="tp">meli 女 (jp), 女 (zh) nü3/nv3</dt> 
<dd lang="en"><i>n</i>	woman, female, girl, wife, girlfriend</dd> 
<dd lang="en"><i>mod</i>	female, feminine, womanly</dd> 
<dd lang="en">[Mary]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/meli">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:meli">drafts</a></dd> 
<dd lang="eo"><i>o</i> ino, virino, edzino, koramikino, femalo<br/>
      <i>a</i> ina, ineca</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=meli&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=meli">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/meli/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_mi.jpg" /> </td>
<td valign="top">
<dl> 
<a name="mi"></a>
<dt lang="tp">mi 私 (jp), 我 (zh) wo3</dt> 
<dd lang="en"><i>n</i>	I, we</dd> 
<dd lang="en"><i>mod</i>	my, our</dd> 
<dd lang="en">[me]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/mi">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:mi">drafts</a></dd> 
<dd lang="eo"><i>o</i> mi, ni<br/>
      <i>a</i> mia, nia </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=mi&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=mi">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/mi/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_mije.jpg" /> </td>
<td valign="top">
<dl> 
<a name="mije"></a>
<dt lang="tp">mije 男 (jp), 男 (zh) nan2</dt> 
<dd lang="en"><i>n</i>	man, male, boy, husband, boyfriend</dd> 
<dd lang="en"><i>mod</i>	male, masculine, manly</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/mije">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:mije">drafts</a></dd> 
<dd lang="eo"><i>o</i> viro, edzo, masklo<br/>
      <i>a</i> vira, vireca</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=mije&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=mije">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/mije/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_moku.jpg" /> </td>
<td valign="top">
<dl> 
<a name="moku"></a>
<dt lang="tp">moku 食 (jp), 菜 (zh) cai4</dt> 
<dd lang="en"><i>n</i>	food, meal</dd> 
<dd lang="en"><i>vt</i>	eat, drink, swallow, ingest, consume</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/moku">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:moku">drafts</a></dd> 
<dd lang="eo"><i>o</i> man&#285;(a&#309;)o<br/>
      <i>vtr</i> man&#285;i, trinki, gluti, enstomakigi, konsumi</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=moku&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=moku">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/moku/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_moli.jpg" /> </td>
<td valign="top">
<dl> 
<a name="moli"></a>
<dt lang="tp">moli 死 (jp), 死 (zh) si3</dt> 
<dd lang="en"><i>n</i>	death</dd> 
<dd lang="en"><i>vi</i>	die, be dead</dd> 
<dd lang="en"><i>vt</i>	kill</dd> 
<dd lang="en"><i>mod</i>	dead, deadly, fatal</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/moli">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:moli">drafts</a></dd> 
<dd lang="eo"><i>o</i> morto<br/>
      <i>vntr</i> morti, esti morta<br/>
      <i>vtr</i> mortigi<br/>
      <i>a</i> morta, mortiga </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=moli&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=moli">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/moli/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_monsi.jpg" /> </td>
<td valign="top">
<dl> 
<a name="monsi"></a>
<dt lang="tp">monsi 後 (jp), 后 (zh) hou4</dt> 
<dd lang="en"><i>n</i>	back, rear end, butt, behind</dd> 
<dd lang="en"><i>mod</i>	back, rear</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/monsi">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:monsi">drafts</a></dd> 
<dd lang="eo"><i>o</i> dorso, malanta&#365;o, pugo<br/>
      <i>a</i> dorsa, malanta&#365;a</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=monsi&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=monsi">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/monsi/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_mu.jpg" /> </td>
<td valign="top">
<dl> 
<a name="mu"></a>
<dt lang="tp">mu む (jp), 吽 (zh) ou2,hou2</dt> 
<dd lang="en"><i>interj</i>	woof! meow! moo! etc. (cute animal noise)</dd> 
<dd lang="en">[moo]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/mu">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:mu">drafts</a></dd> 
<dd lang="eo"><em>kri</em> blek! &#365;a! mia&#365;! ra! ktp (&#265;arma 
      bestokrio)</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=mu&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=mu">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/mu/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_mun.jpg" /> </td>
<td valign="top">
<dl> 
<a name="mun"></a>
<dt lang="tp">mun 月 (jp), 月 (zh) yue4</dt> 
<dd lang="en"><i>n</i>	moon</dd> 
<dd lang="en"><i>mod</i>	lunar</dd> 
<dd lang="en">[moon]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/mun">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:mun">drafts</a></dd> 
<dd lang="eo"><i>o</i> luno<br/>
      <i>a</i> luna</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=mun&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=mun">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/mun/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_musi.jpg" /> </td>
<td valign="top">
<dl> 
<a name="musi"></a>
<dt lang="tp">musi 楽 (jp), 玩 (zh) wan2</dt> 
<dd lang="en"><i>n</i>	fun, playing, game, recreation, art, entertainment</dd> 
<dd lang="en"><i>mod</i>	artful, fun, recreational</dd> 
<dd lang="en"><i>vi</i>	play, have fun</dd> 
<dd lang="en"><i>vt</i>	amuse, entertain</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/musi">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:musi">drafts</a></dd> 
<dd lang="eo"><i>o</i> amuzo, ludo, dista&#309;o, arto<br/>
      <i>a</i> arta, amuza, distra, luda<br/>
      <i>vntr</i> ludi, amuzi&#285;i <br/>
      <i>vtr</i> amuzi, distri</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=musi&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=musi">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/musi/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_mute.jpg" /> </td>
<td valign="top">
<dl> 
<a name="mute"></a>
<dt lang="tp">mute 多 (jp), 大 (zh) da</dt> 
<dd lang="en"><i>mod</i>	many, very, much, several, a lot, abundant, numerous, more</dd> 
<dd lang="en"><i>n</i>	amount, quantity</dd> 
<dd lang="en"><i>vt</i>	make many or much</dd> 
<dd lang="en">[multi]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/mute">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:mute">drafts</a></dd> 
<dd lang="eo"><i>a</i> multaj, tre, pluraj, multe, pli da<br/>
      <i>o</i> kvanto, multo, kiomo<br/>
      <em>vtr</em> multigi</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=muti&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=muti">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/mute/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_namako.jpg" /> </td>
<td valign="top">
<dl> 
<a name="namako"></a>
<dt lang="tp">namako 冗</dt> 
<dd lang="en">* this word is new</dd> 
<dd lang="en">extra, addtional, spice</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/namako">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:namako">drafts</a></dd> 
<dd><a href="http://tatoeba.org/eng/sentences/search?query=namako&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=namako">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/namako/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_nanpa.jpg" /> </td>
<td valign="top">
<dl> <a name="nanpa"></a>
<dt lang="tp">nanpa 番 (jp), 个 (zh) ge4</dt> 
<dd lang="en"><i>n</i>	number</dd> 
<dd lang="en"><i>oth</i>	-th (ordinal numbers)</dd> 
<dd lang="en">[number]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/nanpa">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:nanpa">drafts</a></dd> 
<dd lang="eo"><i>o</i> numero<br/>
      <i>ali</i> -a (unua, dua, ktp)</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=nanpa&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=nanpa">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/nanpa/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_nasa.jpg" /> </td>
<td valign="top">
<dl> <a name="nasa"></a>
<dt lang="tp">nasa 狂 (jp), 怪 (zh) guai4</dt> 
<dd lang="en"><i>mod</i>	silly, crazy, foolish, drunk, strange, stupid, weird</dd> 
<dd lang="en"><i>vt</i>	drive crazy, make weird</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/nasa">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:nasa">drafts</a></dd> 
<dd lang="eo"><i>a</i> freneza, stulta, ebria, stranga<br/>
      <em>vtr</em> frenezigi, strangigi </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=nasa&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=nasa">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/nasa/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_nasin.jpg" /> </td>
<td valign="top">
<dl> 
<a name="nasin"></a>
<dt lang="tp">nasin  道 (jp), 道 (zh) dao4</dt> 
<dd lang="en"><i>n</i>	way, manner, custom, road, path, doctrine, system, method</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/nasin">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:nasin">drafts</a></dd> 
<dd lang="eo"><i>o</i> maniero, vojo, strato, kutimo, -ismo, sistemo, metodo</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=nasin&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=nasin">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/nasin/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_nena.jpg" /> </td>
<td valign="top">
<dl> 

<a name="nena"></a>
<dt lang="tp">nena 丘 (jp), 山 (zh) shan1</dt> 
<dd lang="en"><i>n</i>	bump, nose, hill, mountain, button</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/nena">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:nena">drafts</a></dd> 
<dd lang="eo"><i>o</i> elstara&#309;o, nazo, mont(et)o, butono </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=nena&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=nena">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/nena/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_ni.jpg" /> </td>
<td valign="top">
<dl> 

<a name="ni"></a>
<dt lang="tp">ni 此 (jp), 这 (zh) zhe4</dt> 
<dd lang="en"><i>mod</i>	this, that</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/ni">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:ni">drafts</a></dd> 
<dd lang="eo"><i>a</i> tiu, &#265;i tiu, &#265;i-, jena</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=ni&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=ni">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/ni/">Forvo pronunciation</a></dd>

</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_nimi.jpg" /> </td>
<td valign="top">
<dl> 
<a name="nimi"></a>
<dt lang="tp">nimi 称 (jp), 名 (zh) ming2</dt> 
<dd lang="en"><i>n</i>	word, name</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/nimi">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:nimi">drafts</a></dd> 
<dd lang="eo"><i>o</i> vorto, nomo </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=nimi&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=nimi">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/nimi/">Forvo pronunciation</a></dd>

</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_noka.jpg" /> </td>
<td valign="top">
<dl> 
<a name="noka"></a>
<dt lang="tp">noka 足 (jp), 足 (zh) zu2</dt> 
<dd lang="en"><i>n</i>	leg, foot</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/noka">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:noka">drafts</a></dd> 
<dd lang="eo"><i>o</i> kruro, gambo, piedo</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=noka&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=noka">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/noka/">Forvo pronunciation</a></dd>

</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_o.jpg" /> </td>
<td valign="top">
<dl> 
<a name="o"></a>
<dt lang="tp">o お (jp), 令 (zh) ling4</dt> 
<dd lang="en"><i>sep</i>	O (vocative or imperative)</dd> 
<dd lang="en"><i>interj</i>	hey! (calling somebody's attention)</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/o">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:o">drafts</a></dd> 
<dd lang="eo"><i>div</i> ho (vokativo a&#365; u-tempo)<br/>
      <i>kri</i> he! (por altiri ies atenton)</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=o&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=o">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/o/">Forvo pronunciation</a></dd>

</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_oko.jpg" /> </td>
<td valign="top">
<dl> 
<a name="oko"></a>
<dt lang="tp">oko 目 (jp), 目 (zh) mu4</dt> 
<dd lang="en"><i>n</i>	eye</dd> 
<dd lang="en">[similar to oculist]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/oko">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:oko">drafts</a></dd> 
<dd lang="eo"><em>o</em> okulo</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=oko&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=o">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/oko/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_olin.jpg" /> </td>
<td valign="top">
<dl> 
<a name="olin"></a>
<dt lang="tp">olin 愛 (jp), 爱 (zh) ai4</dt> 
<dd lang="en"><i>n</i>	love</dd> 
<dd lang="en"><i>mod</i>	love</dd> 
<dd lang="en"><i>vt</i>	to love (a person)</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/olin">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:olin">drafts</a></dd> 
<dd lang="eo"><i>o </i>amo<i><br/>
      a</i> ama<i><br/>
      vtr</i> ami (iun)</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=olin&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=olin">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/olin/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_ona.jpg" /> </td>
<td valign="top">
<dl> 
<a name="ona"></a>
<dt lang="tp">ona 彼 (jp), 他 (zh) ta1</dt> 
<dd lang="en"><i>n</i>	she, he, it, they</dd> 
<dd lang="en"><i>mod</i>	her, his, its, their</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/ona">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:ona">drafts</a></dd> 
<dd lang="eo"><i>o</i> &#349;i, li, &#285;i, ili<br/>
      <i>a</i> &#349;ia, lia, &#285;ia, ilia</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=ona&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=ona">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/ona/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_open.jpg" /> </td>
<td valign="top">
<dl> 
<a name="open"></a>
<dt lang="tp">open  開 (jp), 开 (zh) kai1 </dt> 
<dd lang="en"><i>vt</i>	open, turn on</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/open">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:open">drafts</a></dd> 
<dd lang="eo"><i>vtr</i> malfermi, &#349;alti</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=open&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=open">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/open/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_pakala.jpg" /> </td>
<td valign="top">
<dl> 
<a name="pakala"></a>
<dt lang="tp">pakala 打 (jp), 打 (zh) da3</dt> 
<dd lang="en"><i>n</i>	blunder, accident, mistake, destruction, damage, breaking</dd> 
<dd lang="en"><i>vt</i>	screw up, fuck up, botch, ruin, break, hurt, injure, damage, spoil, ruin</dd> 
<dd lang="en"><i>vi</i>	screw up, fall apart, break</dd> 
<dd lang="en"><i>interj</i>	damn! fuck!</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/pakala">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:pakala">drafts</a></dd> 
 <dd lang="eo"><i>o</i> fu&#349;o, akcidento, katastrofo, detruo, eraro, 
      dama&#285;o, rompo <br/>
      <i>vtr</i> fu&#349;i, rompi, vundi, dama&#285;i<br/>
      <i>vtr</i> fu&#349;i&#285;i, disfali, rompi&#285;i <br/>
      <i>kri</i> fek!</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=pakala&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=pakala">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/pakala/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_pali.jpg" /> </td>
<td valign="top">
<dl> 
<a name="pali"></a>
<dt lang="tp">pali 作 (jp), 工 (zh) gong1</dt> 
<dd lang="en"><i>n</i>	activity, work, deed, project</dd> 
<dd lang="en"><i>mod</i>	active, work-related, operating, working</dd> 
<dd lang="en"><i>vt</i>	do, make, build, create</dd> 
<dd lang="en"><i>vi</i>	act, work, function</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/pali">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:pali">drafts</a></dd> 
<dd lang="eo"><i>o</i> ag(ad)o, laboro, faro, projekto <br/>
      <i>a</i> aga, labora, aktiva, funkcia <br/>
      <i>vtr</i> fari, konstrui, krei <br/>
      <i>vntr</i> agi, labori, funkcii </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=pali&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=pali">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/pali/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_palisa.jpg" /> </td>
<td valign="top">
<dl> 
<a name="palisa"></a>
<dt lang="tp">palisa  棒 (jp), 支 (zh) zhi1</dt> 
<dd lang="en"><i>n</i>	long, mostly hard object, e.g. rod, stick, branch</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/palisa">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:palisa">drafts</a></dd> 
<dd lang="eo"><i>o</i> longa kaj &#265;efe malmola objekto, ekz. stango, 
      bastono, bran&#265;o, vergo </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=palisa&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=palisa">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/palisa/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_pan.jpg" /> </td>
<td valign="top">
<dl> 
<a name="pan"></a>
<dt lang="tp">pan 米 (jp), 米 (zh) mi3</dt> 
<dd lang="en"><i>n</i>	grain, cereal</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/pan">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:pan">drafts</a></dd> 
<dd><a href="http://tatoeba.org/eng/sentences/search?query=pan&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=pan">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/pan/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_pana.jpg" /> </td>
<td valign="top">
<dl> 
<a name="pana"></a>
<dt lang="tp">pana 授 (jp), 给 (zh) gei3</dt> 
<dd lang="en"><i>vt</i>	give, put, send, place, release, emit, cause</dd> 
<dd lang="en"><i>n</i>	giving, transfer, exchange</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/pana">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:pana">drafts</a></dd> 
<dd lang="eo"><i>vtr</i> doni, meti, sendi, eligi, ka&#365;zi <br/>
      <i>o</i> dono, sendado, inter&#349;an&#285;o </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=pana&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=pana">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/pana/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_pata.jpg" /> </td>
<td valign="top">
<dl> 
<a name="pata"></a>
<dt lang="tp">pata 氏 (Obsolete, see end for what this means)</dt> 
<dd lang="en"><i>n</i> brother</dd>
<dd lang="en"><a href="http://en.tokipona.org/wiki/pana">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:pana">drafts</a></dd> 
<dd><a href="http://tatoeba.org/eng/sentences/search?query=pata&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=pata">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/pata/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_pi.jpg" /> </td>
<td valign="top">
<dl> 

<a name="pi"></a>
<dt lang="tp">pi ぴ (jp), 的 (zh) de</dt> 
<dd lang="en"><i>sep</i>	of, belonging to</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/pi">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:pi">drafts</a></dd> 
<dd lang="eo"><i>div</i> de, apartenanta al</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=pi&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=pi">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/pi/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_pilin.jpg" /> </td>
<td valign="top">
<dl> 
<a name="pilin"></a>
<dt lang="tp">pilin 心 (jp), 想 (zh) xiang3 (or 心 xin1)</dt> 
<dd lang="en"><i>n</i>	feelings, emotion, heart</dd> 
<dd lang="en"><i>vi</i>	feel</dd> 
<dd lang="en"><i>vt</i>	feel, think, sense, touch</dd> 
<dd lang="en">[feeling]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/pilin">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:pilin">drafts</a></dd> 
<dd lang="eo"><i>o</i> sentoj, emocio, koro<br/>
      <i>vntr</i> senti sin<br/>
      <i>vtr</i> senti, opinii, pensi, sensi, tu&#349;i, palpi</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=pilin&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=pilin">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/pilin/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_pimeja.jpg" /> </td>
<td valign="top">
<dl> 
<a name="pimeja"></a>
<dt lang="tp">pimeja 黒 (jp), 黑 (zh) hei1</dt> 
<dd lang="en"><i>mod</i>	black, dark</dd> 
<dd lang="en"><i>n</i>	darkness, shadows</dd> 
<dd lang="en"><i>vt</i>	darken</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/pimeja">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:pimeja">drafts</a></dd> 
<dd lang="eo"><i>a</i> nigra, malluma, malhela<br/>
      <i>o</i> mallumo, nigro<br/>
      <em>vtr</em> mallumigi</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=pimeja&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=pimeja">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/pimeja/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_pini.jpg" /> </td>
<td valign="top">
<dl> 

<a name="pini"></a>
<dt lang="tp">pini 終 (jp), 末 (zh) mo4</dt> 
<dd lang="en"><i>n</i>	end, tip</dd> 
<dd lang="en"><i>mod</i>	completed, finished, past, done, ago</dd> 
<dd lang="en"><i>vt</i>	finish, close, end, turn off</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/pini">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:pini">drafts</a></dd> 
 <dd lang="eo"><i>o</i> fino, ekstremo, pinto <br/>
      <i>a</i> fina, finita, pasinta, farita, anta&#365;<br/>
      <i>vtr</i> fini, fermi, mal&#349;alti </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=pini&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=pini">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/pini/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_pipi.jpg" /> </td>
<td valign="top">
<dl> 

<a name="pipi"></a>
<dt lang="tp">pipi 虫 (jp), 虫 (zh) chong2</dt> 
<dd lang="en"><i>n</i>	bug, insect, spider</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/pipi">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:pipi">drafts</a></dd> 
<dd lang="eo"><i>o</i> insekto, araneo</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=pipi&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=pipi">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/pipi/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_poka.jpg" /> </td>
<td valign="top">
<dl> 
<a name="poka"></a>
<dt lang="tp">poka 側 (jp), 旁 (zh) pang2</dt> 
<dd lang="en"><i>n</i>	side, hip, next to</dd> 
<dd lang="en"><i>prep</i>	in the accompaniment of, with</dd> 
<dd lang="en"><i>mod</i>	neighbouring</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/poka">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:poka">drafts</a></dd> 
<dd lang="eo"><i>o</i> flanko, kokso, apudo<br/>     <i>prep</i> en la akompano de, kun<br/>
      <i>a</i> apuda, najbara</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=poka&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=poka">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/poka/">Forvo pronunciation</a></dd>

</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_poki.jpg" /> </td>
<td valign="top">
<dl> 
<a name="poki"></a>
<dt lang="tp">poki 箱 (jp), 包 (zh) bao1</dt> 
<dd lang="en"><i>n</i>	container, box, bowl, cup, glass</dd> 
<dd lang="en">[box]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/poki">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:poki">drafts</a></dd> 
      <dd lang="eo"><i>o</i> ujo, skatolo, bovlo, taso, glaso</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=poki&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=poki">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/poki/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_pona.jpg" /> </td>
<td valign="top">
<dl> 
<a name="pona"></a>
<dt lang="tp">pona 良 (jp), 好 (zh) hao3</dt> 
<dd lang="en"><i>n</i>	good, simplicity, positivity</dd> 
<dd lang="en"><i>mod</i>	good, simple, positive, nice, correct, right</dd> 
<dd lang="en"><i>interj</i>	great! good! thanks! OK! cool! yay!</dd> 
<dd lang="en"><i>vt</i>	improve, fix, repair, make good</dd> 
<dd lang="en">[bonam]</dd> 
<dd lang="eo"><i>o</i> bona, simplo, pozitivo<br/>
      <i>a</i> bona, simpla, pozitiva, afabla, &#285;usta<br/>
      <i>kri</i> bone! bonege! dankon! en ordo!<br/>
      <i>vtr</i> (pli)bonigi, ripari</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=pona&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=pona">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/pona/">Forvo pronunciation</a></dd>
<dd lang="en"><a href="http://en.tokipona.org/wiki/pona">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:pona">drafts</a></dd> 
<dd lang="en"><i>describer<i> beneficial; good</dd>
<dd lang="en"><i>describer<i> benevolent; altruistic, kind, symbiotic</dd>
<dd lang="en"><i>describer<i> helpful; cooperating</dd>
<dd lang="en"><i>describer<i> ideal</dd>
<dd lang="en"><i>describer<i> conducive to overall wellness</dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_sama.jpg" /> </td>
<td valign="top">
<dl> 
<a name="sama"></a>
<dt lang="tp">sama 同 (jp), 同 (zh) tong2</dt> 
<dd lang="en"><i>mod</i>	same, similar, equal, of equal status or position</dd> 
<dd lang="en"><i>prep</i>	like, as, seem</dd> 
<dd lang="eo"><i>a</i> sama, simila, egala, samgrava, samsituacia <br/>
      <i>prep</i> kiel, &#349;ajni</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=sama&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=sama">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/sama/">Forvo pronunciation</a></dd>
<dd lang="en"><a href="http://en.tokipona.org/wiki/sama">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:sama">drafts</a></dd> 
<dd lang="en"><i>adjective</i> filling the same or a similar role; equivalent</dd>
<dd lang="en"><i>adjective</i> self-</dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_seli.jpg" /> </td>
<td valign="top">
<dl> 
<a name="seli"></a>
<dt lang="tp">seli 火 (jp), 火 (zh) huo3</dt> 
<dd lang="en"><i>n</i>	fire, warmth, heat</dd> 
<dd lang="en"><i>mod</i>	hot, warm, cooked</dd> 
<dd lang="en"><i>vt</i>	heat, warm up, cook</dd> 
<dd lang="eo"><i>o</i> fajro, varmo<br/>
      <i>a</i> varma, kuirita <br/>
      <i>vtr</i> varmigi, kuiri</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=seli&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=seli">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/seli/">Forvo pronunciation</a></dd>
<dd lang="en"><a href="http://en.tokipona.org/wiki/seli">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:seli">drafts</a></dd> 
<dd lang="en"><i>noun</i> fire, a force of nature or chemical reaction that releases heat and light, potentially causing destruction; fire, lightning, explosion, exothermic reaction</dd>
<dd lang="en"><i>noun</i> heat source, something that provides heat</dd>
<dd lang="en"><i>noun</i> cooking source, something that provides heat for preparing food</dd>
<dd lang="en"><i>noun</i> light source, something that provides light</dd>
<dd lang="en"><i>transitive verb</i>to use seli on</dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_selo.jpg" /> </td>
<td valign="top">
<dl> 
<a name="selo"></a>
<dt lang="tp">selo 皮 (jp), 甲 (zh) jia3</dt> 
<dd lang="en"><i>n</i>	outside, surface, skin, shell, bark, shape, peel</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/selo">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:selo">drafts</a></dd> 
<dd lang="eo"><i>o</i> ekstero, supra&#309;o, ha&#365;to, &#349;elo, formo</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=selo&from=toki&to=und">Tatoeba corpus</a></dd>   
<dd><a href="CorpusSearch.aspx?word=selo">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/selo/">Forvo pronunciation</a></dd>

</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_seme.jpg" /> </td>
<td valign="top">
<dl> 
<a name="seme"></a>
<dt lang="tp">seme  何 (jp), 什 (zh) she2</dt> 
<dd lang="en"><i>oth</i>	what, which, wh- (question word)</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/seme">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:seme">drafts</a></dd> 
<dd lang="eo"><i>ali</i> ki- (demandovorto)</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=seme&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=seme">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/seme/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_sewi.jpg" /> </td>
<td valign="top">
<dl> 
<a name="sewi"></a>
<dt lang="tp">sewi 上 (jp), 上 (zh) shang4</dt> 
<dd lang="en"><i>n</i>	high, up, above, top, over, on</dd> 
<dd lang="en"><i>mod</i>	superior, elevated, religious, formal</dd> 

<dd lang="eo"><i>o</i> alto, supro, supero, suro <br/>
      <i>a</i> supera, alta, nobla, religia, formala</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=sewi&from=toki&to=und">Tatoeba corpus</a></dd>   
<dd><a href="CorpusSearch.aspx?word=sewi">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/sewi/">Forvo pronunciation</a></dd>
<dd lang="en"><a href="http://en.tokipona.org/wiki/sewi">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:sewi">drafts</a></dd> 

<dd lang="en">awe-inspiring, inspiring a feeling of wonder, respect and fear; venerable, reverend, estimable, honourable, awe-inspiring, humbling, mesmerizing, venerable, reverend, honourable, looked up to in adoration</dd>
<dd lang="en">captivating, causing a hypnotizing effect, able to hold people in an uncontrollable state of admiration; spellbinding, fascinating, mesmerizing, hypnotic, mysteriously impressive, captivating, enchanting</dd>
<dd lang="en">having higher powers or effects</dd>
<dd lang="en">supernatural</dd>
<dd lang="en">interpreted as belonging to a world beyond the ordinary and physical; transcendent, transcending, divine, magical, mysterious, wondrous, miraculous</dd>
<dd lang="en">causing supernormal stimulus</dd>
<dd lang="en">idealized</dd>
<dd lang="en">worshipped</dd>
<dd lang="en">physically deep</dd>
<dd lang="en">figuratively deep</dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_sijelo.jpg" /> </td>
<td valign="top">
<dl> 

<a name="sijelo"></a>
<dt lang="tp">sijelo  体 (jp), 身 (zh) shen1</dt> 
<dd lang="en"><i>n</i>	body, physical state</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/sijelo">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:sijelo">drafts</a></dd> 
<dd lang="eo"><i>o</i> korpo, fizika stato </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=sijelo&from=toki&to=und">Tatoeba corpus</a></dd>   
<dd><a href="CorpusSearch.aspx?word=sijelo">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/sijelo/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_sike.jpg" /> </td>
<td valign="top">
<dl> 
<a name="sike"></a>
<dt lang="tp">sike  丸 (jp), 回 (zh) hui2</dt> 
<dd lang="en"><i>n</i>	circle, wheel, sphere, ball, cycle</dd> 
<dd lang="en"><i>mod</i>	round, cyclical</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/sike">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:sike">drafts</a></dd> 
<dd lang="eo"><i>o</i> rondo, cirklo, rado, sfero, bulo, pilko, ciklo <br/>
      <i>a</i> ronda, cikla</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=sike&from=toki&to=und">Tatoeba corpus</a></dd>   
<dd><a href="CorpusSearch.aspx?word=sike">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/sike/">Forvo pronunciation</a></dd>

</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_sin.jpg" /> </td>
<td valign="top">
<dl> 
<a name="sin"></a>
<dt lang="tp">sin 新 (jp), 新 (zh) xin1</dt> 
<dd lang="en"><i>mod</i>	new, fresh, another, more</dd> 
<dd lang="en"><i>vt</i>	renew, renovate, freshen</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/sin">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:sin">drafts</a></dd> 
 <dd lang="eo"><i>a</i> nova, fre&#349;a, alia, ankor&#365; (da) <br/>
      <em>vtr</em> (re)novigi</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=sin&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=sin">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/sin/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_sina.jpg" /> </td>
<td valign="top">
<dl> 
<a name="sina"></a>
<dt lang="tp">sina 君 (jp), 你 (zh) ni3</dt> 
<dd lang="en"><i>n</i>	you</dd> 
<dd lang="en"><i>mod</i>	your</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/sina">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:sina">drafts</a></dd> 
<dd lang="eo"><i>o</i> vi<br/>
      <i>a</i> via</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=sina&from=toki&to=und">Tatoeba corpus</a></dd>   
<dd><a href="CorpusSearch.aspx?word=sina">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/sina/">Forvo pronunciation</a></dd>

</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_sinpin.jpg" /> </td>
<td valign="top">
<dl> 
<a name="sinpin"></a>
<dt lang="tp">sinpin 前 (jp), 前 (zh) qian2</dt> 
<dd lang="en"><i>n</i>	front, chest, torso, face, wall</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/sinpin">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:sinpin">drafts</a></dd> 
<dd lang="eo"><i>o</i> anta&#365;o, brusto, torso, viza&#285;o, muro </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=sinpin&from=toki&to=und">Tatoeba corpus</a></dd>   
<dd><a href="CorpusSearch.aspx?word=sinpin">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/sina/">Forvo pronunciation</a></dd>

</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_sitelen.jpg" /> </td>
<td valign="top">
<dl> 
<a name="sitelen"></a>
<dt lang="tp">sitelen 画 (jp), 画 (zh) hua4</dt> 
<dd lang="en"><i>n</i>	picture, image</dd> 
<dd lang="en"><i>vt</i>	draw, write</dd> 

<dd lang="eo"><i>o</i> bildo, foto, imago, desegno <br/>
      <i>vtr</i> desegni, skribi </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=sitelen&from=toki&to=und">Tatoeba corpus</a></dd>   
<dd><a href="CorpusSearch.aspx?word=sitelen">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/sitelen/">Forvo pronunciation</a></dd>
<dd lang="en"><a href="http://en.tokipona.org/wiki/sitelen">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:sitelen">drafts</a></dd> 
<dd lang="en"><i>noun</i> representation, a visual or tactile work that serves to show, describe, explain or remind us of something else; representation, model</dd>
<dd lang="en"><i>noun</i> picture, specific lines and shapes marked on a surface; drawing, print, painting, image, sign, sketch, outline, blueprint, etching, picture, <dd lang="en"><i>noun</i> diagram, chart, graph</dd>
<dd lang="en"><i>noun</i> sculpture , an object made into the shape of something; carving, sculpture, figurine, replica</dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_sona.jpg" /> </td>
<td valign="top">
<dl> 
<a name="sona"></a>
<dt lang="tp">sona 知 (jp), 知 (zh) zhi1/4</dt> 
<dd lang="en"><i>n</i>	knowledge, wisdom, intelligence, understanding</dd> 
<dd lang="en"><i>vt</i>	know, understand, know how to</dd> 
<dd lang="en"><i>vi</i>	know, understand</dd> 
<dd lang="en"><i>kama</i>	learn, study</dd> 
<dd lang="eo"><i>o</i> scioj, sa&#285;eco, inteligenteco, kompreno <br/>
      <i>vtr</i> scii, kompreni, koni <br/>
      <i>vntr</i> scii, kompreni<br><em>kama</em> lerni, studi</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=sona&from=toki&to=und">Tatoeba corpus</a></dd>   
<dd><a href="CorpusSearch.aspx?word=sona">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/sona/">Forvo pronunciation</a></dd>
<dd lang="en"><a href="http://en.tokipona.org/wiki/sona">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:sona">drafts</a></dd> 
<dd lang="en">system of knowledge or beliefs</dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_soweli.jpg" /> </td>
<td valign="top">
<dl> 
<a name="soweli"></a>
<dt lang="tp">soweli 猫 (jp), 马 (zh) ma3 (or 牛 niu2)</dt> 
<dd lang="en"><i>n</i>	animal, especially land mammal, lovable animal</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/soweli">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:soweli">drafts</a></dd> 
<dd lang="eo"><i>o</i> besto, precipe tera mambesto, aminda besto</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=soweli&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=soweli">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/soweli/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_suli.jpg" /> </td>
<td valign="top">
<dl> 
<a name="suli"></a>
<dt lang="tp">suli 大 (jp), 高 (zh) gao1</dt> 
<dd lang="en"><i>mod</i>	big, tall, long, adult, important</dd> 
<dd lang="en"><i>vt</i>	enlarge, lengthen</dd> 
<dd lang="en"><i>n</i>	size</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/suli">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:suli">drafts</a></dd> 
    <dd lang="eo"><i>a</i> granda, alta, longa, plena&#285;a, grava<br/>
      <em>vtr</em> grandigi, longigi<br/>
      <em>o</em> grandeco</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=suli&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=suli">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/suli/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_suno.jpg" /> </td>
<td valign="top">
<dl> 
<a name="suno"></a>
<dt lang="tp">suno 日 (jp), 日 (zh) ri4 (or 光 guang1)</dt> 
<dd lang="en"><i>n</i>	sun, light</dd> 
<dd lang="eo"><i>o</i> suno, lumo</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=suno&from=toki&to=und">Tatoeba corpus</a></dd> 
<dd><a href="CorpusSearch.aspx?word=suno">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/suno/">Forvo pronunciation</a></dd>
<dd lang="en"><a href="http://en.tokipona.org/wiki/suno">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:suno">drafts</a></dd> 
<dd lang="en"><i>describer</i> having the qualities or characteristics of suno, shiny</dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_supa.jpg" /> </td>
<td valign="top">
<dl> 
<a name="supa"></a>
<dt lang="tp">supa 面 (jp), 张 (zh) zhang1</dt> 
<dd lang="en"><i>n</i>	horizontal surface, e.g furniture, table, chair, pillow, floor</dd> 
<dd lang="eo"><i>o</i> horizontala supra&#309;o, ekz. meblo, tablo, se&#285;o, 
      kuseno, planko</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=supa&from=toki&to=und">Tatoeba corpus</a></dd>   
<dd><a href="CorpusSearch.aspx?word=supa">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/supa/">Forvo pronunciation</a></dd>
<dd lang="en"><a href="http://en.tokipona.org/wiki/supa">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:supa">drafts</a></dd> 
<dd lang="en"><i>noun</i> supporting platform, surface</dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_suwi.jpg" /> </td>
<td valign="top">
<dl> 
<a name="suwi"></a>
<dt lang="tp">suwi 甜 (jp), 甜 (zh) tian2</dt> 
<dd lang="en"><i>n</i>	candy, sweet food</dd> 
<dd lang="en"><i>mod</i>	sweet, cute</dd> 
<dd lang="en"><i>vt</i>	sweeten</dd> 
<dd lang="en">[sweet]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/suwi">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:suwi">drafts</a></dd> 
<dd lang="eo"><i>o</i> dol&#265;a&#309;o<br/>
      <i>a</i> dol&#265;a, aminda <br/>
      <i>vtr</i> dol&#265;igi</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=suwi&from=toki&to=und">Tatoeba corpus</a></dd>   
<dd><a href="CorpusSearch.aspx?word=suwi">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/suwi/">Forvo pronunciation</a></dd>



</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_tan.jpg" /> </td>
<td valign="top">
<dl> 
<a name="tan"></a>
<dt lang="tp">tan 因 (jp), 从 (zh) cong2</dt> 
<dd lang="en"><i>prep</i>	from, by, because of, since</dd> 
<dd lang="en"><i>n</i>	origin, cause</dd> 
<dd lang="eo"><i>prep</i> de, pro, el <br/>
      <i>o</i> deveno, kialo, origino</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=tan&from=toki&to=und">Tatoeba corpus</a></dd>   
<dd><a href="CorpusSearch.aspx?word=tan">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/tan/">Forvo pronunciation</a></dd>
<dd lang="en"><a href="http://en.tokipona.org/wiki/tan">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:tan">drafts</a></dd> 
<dd lang="en"><i>relation word</i>, origin, indicates the place of origin</dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_taso.jpg" /> </td>
<td valign="top">
<dl> 
<a name="taso"></a>
<dt lang="tp">taso 許 (jp), 只 (zh) zhi3</dt> 
<dd lang="en"><i>mod</i>	only, sole</dd> 
<dd lang="en"><i>conj</i>	but</dd> 
<dd lang="en">[that's all]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/taso">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:taso">drafts</a></dd> 
<dd lang="eo"><i>a</i> nur, nura, sola<br/>
      <i>konj</i> sed</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=taso&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=taso">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/taso/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_tawa.jpg" /> </td>
<td valign="top">
<dl> 
<a name="tawa"></a>
<dt lang="tp">tawa 去 (jp), 去 (zh) qu4 </dt> 
<dd lang="en"><i>prep</i>	to, in order to, towards, for, until</dd> 
<dd lang="en"><i>vi</i>	go to, walk, travel, move, leave</dd> 
<dd lang="en"><i>n</i>	movement, transportation</dd> 
<dd lang="en"><i>mod</i>	moving, mobile</dd> 
<dd lang="en"><i>vt</i>	move, displace</dd> 
<dd lang="en">[towards]</dd> 
<dd lang="eo"><i>prep</i> al, por, &#285;is <br/>
      <i>vntr</i> iri al, voja&#285;i, movi&#285;i, foriri <br/>
      <i>o</i> movo, transportado <br/>
      <i>a</i> mova<br/>
      <i>vtr</i> movi</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=tawa&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=tawa">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/tawa/">Forvo pronunciation</a></dd>
<dd lang="en"><a href="http://en.tokipona.org/wiki/tawa">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:tawa">drafts</a></dd> 
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_telo.jpg" /> </td>
<td valign="top">
<dl> 
<a name="telo"></a>
<dt lang="tp">telo 水 (jp), 水 (zh) shui3</dt> 
<dd lang="en"><i>n</i>	water, liquid, juice, sauce</dd> 
<dd lang="en"><i>vt<a name="taso"></a></i>	water, wash with water</dd> 
<dd lang="eo"><i>o</i> akvo, likva&#309;o, suko, sa&#365;co <br/>
      <i>vtr</i> akvumi, lavi per akvo </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=telo&from=toki&to=und">Tatoeba corpus</a></dd>   
<dd><a href="CorpusSearch.aspx?word=telo">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/telo/">Forvo pronunciation</a></dd>

<dd lang="en"><a href="http://en.tokipona.org/wiki/telo">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:telo">drafts</a></dd>
<dd lang="en"><i>noun</i> liquid, a flowing wet substance; liquid, fluid, water</dd>
<dd lang="en"><i>noun</i> beverage, a liquid for drinking; beverage, drink, water, juice</dd>
<dd lang="en"><i>noun</i> a liquid for washing; water</dd>
<dd lang="en"><i>noun</i> body fluid, a liquid that comes out of the body; blood, milk, saliva, semen, sweat, tears, urine</dd>
<dd lang="en"><i>noun</i> body of water, an area covered with water; bay, strait, sea, lake, river, stream</dd>
<dd lang="en"><i>transitive verb</i> to use <b>telo</b> on; to water, rinse, wash, wet</dd>
<dd lang="en"><i>describer</i> having the characteristics or properties of <b>telo</b>; wet, liquid</dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_tenpo.jpg" /> </td>
<td valign="top">
<dl> 
<a name="tenpo"></a>
<dt lang="tp">tenpo 时 (jp), 时 (zh) shi2</dt> 
<dd lang="en"><i>n</i>	time, period of time, moment, duration, situation</dd> 
<dd lang="eo"><i>o</i> tempo, tempoperiodo, momento, da&#365;ro, situacio</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=tenpo&from=toki&to=und">Tatoeba corpus</a></dd>   
<dd><a href="CorpusSearch.aspx?word=tenpo">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/tenpo/">Forvo pronunciation</a></dd>
<dd lang="en"><a href="http://en.tokipona.org/wiki/tenpo">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:tenpo">drafts</a></dd>
<dd lang="en">moment</dd> 
<dd lang="en">occasion</dd> 
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_toki.jpg" /> </td>
<td valign="top">
<dl> 
<a name="toki"></a>
<dt lang="tp">toki 言 (jp), 言 (zh) yan2</dt> 
<dd lang="en"><i>n</i>	language, talking, speech, communication</dd> 
<dd lang="en"><i>mod</i>	talking, verbal</dd> 
<dd lang="en"><i>vt</i>	say</dd> 
<dd lang="en"><i>vi</i>	talk, chat, communicate</dd> 
<dd lang="en"><i>interj</i>	hello! hi!</dd> 
<dd lang="eo"><i>o</i> lingvo, parolado, komunikado <br/>
      <i>a</i> parola, lingva, komunika<br/>
      <i>vtr</i> diri<br/>
      <i>vntr</i> paroli, babili, komuniki <br/>
      <i>kri</i> saluton!</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=toki&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=toki">tokipona.net corpus</a></dd>

<dd><a href="http://www.forvo.com/word/toki/">Forvo pronunciation</a></dd>

<dd lang="en"><a href="http://en.tokipona.org/wiki/toki">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:toki">drafts</a></dd>
<dd lang="en"><i>transitive verb</i> to give and receive (<b>e</b>: information) (<b>tawa</b>: with); to communicate</dd>
<dd lang="en"><i>transitive verb</i> to put together (<b>e</b>: thoughts or ideas); to think out</dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_tomo.jpg" /> </td>
<td valign="top">
<dl> 
<a name="tomo"></a>
<dt lang="tp">tomo 家 (jp), 穴 (zh) xue2</dt> 
<dd lang="en"><i>n</i>	indoor constructed space, e.g. house, home, room, building</dd> 
<dd lang="en"><i>mod</i>	urban, domestic, household</dd> 
<dd lang="eo"><i>o</i> interna konstruita spaco, ekz. domo, hejmo, &#265;ambro, 
      konstrua&#309;<br/>
      <i>a</i> urba, doma, hejma</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=tomo&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=tomo">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/tomo/">Forvo pronunciation</a></dd>
<dd lang="en"><a href="http://en.tokipona.org/wiki/tomo">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:tomo">drafts</a></dd> 
<dd lang="en">shelter</dd> 
<dd lang="en">building</dd> 
<dd lang="en">home</dd> 
<dd lang="en">room</dd> 
<dd lang="en">designated place</dd> 
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_tu.jpg" /> </td>
<td valign="top">
<dl> 
<a name="tu"></a>
<dt lang="tp">tu 二 (jp), 二 (zh) er4</dt> 
<dd lang="en"><i>mod</i>	two</dd> 
<dd lang="en"><i>n</i>	duo, pair</dd> 
<dd lang="en"><i>vt</i>	double, separate/cut/divide in two</dd> 
<dd lang="en">[two]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/tu">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:tu">drafts</a></dd> 
<dd lang="eo"><i>a</i> du<br/>
      <i>o</i> duo, paro<br/>
      <em>vtr</em> duobligi, duigi, dividi/tran&#265;i en du</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=tu&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=tu">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/tu/">Forvo pronunciation</a></dd>
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_unpa.jpg" /> </td>
<td valign="top">
<dl> 
<a name="unpa"></a>
<dt lang="tp">unpa 盛 (jp), 性 (zh) xing4</dt> 
<dd lang="en"><i>n</i>	sex, sexuality</dd> 
<dd lang="en"><i>mod</i>	erotic, sexual</dd> 
<dd lang="en"><i>vt</i>	have sex with, sleep with, fuck</dd> 
<dd lang="en"><i>vi</i>	have sex</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/unpa">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:unpa">drafts</a></dd> 
<dd lang="eo"><i>o</i> seksumo, amoro, fikado, volupto<br/>
      <i>a</i> erotika, seksuma, amora <br/>
      <i>vtr</i> seksumi kun, amori kun, fiki<br/>
      <i>vntr</i> amori, seksumi</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=unpa&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=unpa">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/unpa/">Forvo pronunciation</a></dd> 
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_uta.jpg" /> </td>
<td valign="top">
<dl> 
<a name="uta"></a>
<dt lang="tp">uta 口 (jp), 口 (zh) kou3</dt> 
<dd lang="en"><i>n</i>	mouth</dd> 
<dd lang="en"><i>mod</i>	oral</dd> 
<dd lang="eo"><i>o</i> bu&#349;o<br/>
      <i>a</i> bu&#349;a</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=uta&from=toki&to=und">Tatoeba corpus</a></dd>   
<dd><a href="CorpusSearch.aspx?word=uta">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/uta/">Forvo pronunciation</a></dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/uta">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:uta">drafts</a></dd> 
<p><span style="font-variant:small-caps;">noun</span> 
</p> 
<ol><li><b>mouth</b><br />the part of the human body that includes the lips and everything inside the mouth and throat; mouth, oral cavity, throat, pharynx, lips
</li><li><b>maw</b><br />a similar part in an animal's body, used for eating, sucking or grooming; beak, bill, rostrum, jaw, proboscis 
</li></ol> 
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_utala.jpg" /> </td>
<td valign="top">
<dl> 
<a name="utala"></a>
<dt lang="tp">utala 戦 (jp), 战 (zh) zhan4 (or 斗 dou4)</dt> 
<dd lang="en"><i>n</i>	conflict, disharmony, competition, fight, war, battle, attack, blow, argument, physical or verbal violence</dd> 
<dd lang="en"><i>vt</i>	hit, strike, attack, compete against</dd> 
<dd lang="eo"><i>a</i> konflikto, malharmonio, konkuro, batalo, milito, 
      atako, disputo, fizika a&#365; verba perforto <br/>
      <i>vtr</i> bati, frapi, ataki, konkuri kun, atenci</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=utala&from=toki&to=und">Tatoeba corpus</a></dd>   
<dd><a href="CorpusSearch.aspx?word=utala">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/utala/">Forvo pronunciation</a></dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/utala">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:utala">drafts</a></dd> 
<dd lang="en">competition</dd> 
<dd lang="en">conflict</dd> 
<dd lang="en">struggle</dd> 
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_walo.jpg" /> </td>
<td valign="top">
<dl> 
<a name="walo"></a>
<dt lang="tp">walo 白 (jp), 白 (zh) bai2</dt> 
<dd lang="en"><i>mod</i>	white, light (colour)</dd> 
<dd lang="en"><i>n</i>	white thing or part, whiteness, lightness</dd> 
<dd lang="en">[sounds like wall, which is often white]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/walo">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:walo">drafts</a></dd> 
<dd lang="eo"><i>a</i> blanka, hela <br/>
      <i>o</i> blanko, blanka&#309;o, blankeco, heleco</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=walo&from=toki&to=und">Tatoeba corpus</a></dd>
<dd><a href="CorpusSearch.aspx?word=walo">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/walo/">Forvo pronunciation</a></dd> 
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_wan.jpg" /> </td>
<td valign="top">
<dl> 
<a name="wan"></a>
<dt lang="tp">wan 一 (jp), 一 (zh) yi1</dt> 
<dd lang="en"><i>mod</i>	one, a</dd> 
<dd lang="en"><i>n</i>	unit, element, particle, part, piece</dd> 
<dd lang="en"><i>vt</i>	unite, make one</dd> 
<dd lang="en">[one]</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/wan">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:wan">drafts</a></dd> 
<dd lang="eo"><i>a</i> unu, iu<br/>
      <i>o</i> unuo, elemento, ero, parto, peco <br/>
      <i>vtr</i> unuigi </dd>   
<dd><a href="http://tatoeba.org/eng/sentences/search?query=wan&from=toki&to=und">Tatoeba corpus</a></dd>   
<dd><a href="CorpusSearch.aspx?word=wan">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/wan/">Forvo pronunciation</a></dd> 
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_waso.jpg" /> </td>
<td valign="top">
<dl> 

<a name="waso"></a>
<dt lang="tp">waso 鳥 (jp), 鸟 (zh) niao3</dt> 
<dd lang="en"><i>n</i>	bird, winged animal</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/waso">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:waso">drafts</a></dd> 
<dd lang="eo"><i>o</i> birdo, flugilhava besto </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=waso&from=toki&to=und">Tatoeba corpus</a></dd>   
<dd><a href="CorpusSearch.aspx?word=waso">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/waso/">Forvo pronunciation</a></dd> 

</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_wawa.jpg" /> </td>
<td valign="top">
<dl> 

<a name="wawa"></a>
<dt lang="tp">wawa 力 (jp), 力 (zh) li4</dt> 
<dd lang="en"><i>n</i>	energy, strength, power</dd> 
<dd lang="en"><i>mod</i>	energetic, strong, fierce, intense, sure, confident</dd> 
<dd lang="en"><i>vt</i>	strengthen, energize, empower</dd> 
    <dd lang="eo"><i>o</i> energio, potenco, forto, vigleco<br/>
      <i>a</i> energia, forta, intensa, potenca, certa, memfida<br/>
      <em>vtr</em> fortigi, vigligi</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=wawa&from=toki&to=und">Tatoeba corpus</a></dd>   
<dd><a href="CorpusSearch.aspx?word=wawa">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/wawa/">Forvo pronunciation</a></dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/wawa">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:wawa">drafts</a>

<ol><li> intense
</li><li> strong
</li><li> fast
</li><li><b>loud</b><br />(of sound) having a high volume or amplitude
</li><li> confident, sure
</li></ol> 
</dd> 
      </dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_weka.jpg" /> </td>
<td valign="top">
<dl> 
<a name="weka"></a>
<dt lang="tp">weka 遥 (jp), 脱 (zh) tuo1</dt> 
<dd lang="en"><i>mod</i>	away, absent, missing</dd> 
<dd lang="en"><i>n</i>	absence</dd> 
<dd lang="en"><i>vt</i>	throw away, remove, get rid of</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/weka">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:weka">drafts</a></dd> 
<dd lang="eo"> <i>a</i> fora, forestanta, mankanta<br/>
      <i>o</i> foresto, manko<br/>
      <i>vtr</i> forigi </dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=weka&from=toki&to=und">Tatoeba corpus</a></dd> 
<dd><a href="CorpusSearch.aspx?word=weka">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/weka/">Forvo pronunciation</a></dd>         
</dl>
</td></tr>
</table>

<table border="0px">
<tr><td  valign="top" width="100px"><img alt="" src="img/t47_nimi_wile.jpg" /> </td>
<td valign="top">
<dl> 
<a name="wile"></a>
<dt lang="tp">wile 要 (jp), 要 (zh) yao4</dt> 
<dd lang="en"><i>vt</i>	to want, need, wish, have to, must, will, should</dd> 
<dd lang="en"><i>n</i>	desire, need, will</dd> 
<dd lang="en"><i>mod</i>	necessary</dd> 
<dd lang="en"><a href="http://en.tokipona.org/wiki/wile">current jan Sonja</a>, <a href="http://en.tokipona.org/wiki/Talk:wile">drafts</a></dd> 
<dd lang="eo"><i>vtr</i> voli, bezoni, deziri, devi, -os<br/>
      <i>o</i> deziro, bezono, devo, volo <br/>
      <i>a</i> necesa, deviga, bezonata</dd>
<dd><a href="http://tatoeba.org/eng/sentences/search?query=wile&from=toki&to=und">Tatoeba corpus</a></dd>         
<dd><a href="CorpusSearch.aspx?word=wile">tokipona.net corpus</a></dd>
<dd><a href="http://www.forvo.com/word/wile/">Forvo pronunciation</a></dd>         
      
</dl>
</td></tr>
</table>

<h3><span class="mw-headline" id="Parts_of_Speech">Parts of Speech</span></h3> 
<ul> 
<li><i>n</i>	head noun</li> 
<li><i>mod</i>	modifier (adjective or adverb)</li> 
<li><i>sep</i>	separator</li> 
<li><i>vt</i>	verb, transitive (normally used with <b>e</b>)</li> 
<li><i>vi</i>	verb, intransitive</li> 
<li><i>inter</i>j	interjection</li> 
<li><i>prep</i>	quasi-preposition</li> 
<li><i>conj</i>	conjuncion</li> 
<li><i>kama</i>	compound verb preceded by <b>kama</b></li> 
<li><i>cont</i>	context word used before <b>la</b></li> 
<li><i>conj</i>	conjuncion</li> 
<li><i>oth</i>	special, other word</li> 
</ul> 

<h3>Parolelementoj</h3> 
<ul>
<li><i>o</i> o-vorto</li>
<li><i>a</i> a-vorto (a&#365; e-vorto)</li>
<li><i>div</i> dividilo</li>
<li><i>vtr</i> verbo transitiva (kutime uzata kun la akuzativan dividilon <strong>e</strong>)
<li><i>vntr</i> verbo netransitiva</li>
<li><i>kri</i> krivorto, interjekcio</li>
<li><i>prep</i> kvaza&#365;prepozicio</li>
<li><i>kama</i> plurvorta verbo kun <strong>kama</strong></li>
<li><i>konj</i> konjunkcio</li>
<li><i>kunt</i> kunteksta indikilo uzata anta&#365;  <strong>la</strong></li>
<li><i>ali</i> speciala, alia vorto</li>
</ul> 

<p>Words are in a variety of status:</p>

<ol>
<li><b>Official</b>- usually refers to base words., e.g. kiwen</li>
<li><b>Unofficial</b>- usually refers to phrases that are being used like &quot;compound 
    words&quot;, e.g. jan pona. Linguists would call these lexemes because they are used like words, require memorization, behave differently (less likely to be split), etc.</li>
<li><b>Obsolete</b>- These words were either never used by the community, or were 
    used for very litle time, e.g. pata. However, since people use toki pona as a natural language,  if you use "pata", you likely would be understood, the same as if you had said "wench" or "knave" in English.</li>
<li><b>Possibly obsolete</b>- These are the words that have been used for years, but may become deprecated. 
    e.g. noka</li>
<li><b>Considered</b>, but never used- words used in polls.</li>
<li><b>Considered in jest</b> - The April fool's day word. e.g. kijetesantakalu</li>
<li><b>Reserved/Potentially new</b>- Some new words are not defined,eg. pu</li>
<li><b>Community innovations</b>- this includes both proper modifiers being used 
        outside of names of unique things and suggestions for new base words and 
        intentional and accidental homonymy, eg. moku Soja, or pan used to mean &quot;life&quot;</li>
</ol>

</asp:Content>