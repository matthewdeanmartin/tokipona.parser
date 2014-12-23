<%@ Page Title="" Language="C#" MasterPageFile="~/Basic.Master" AutoEventWireup="true" CodeBehind="Tour001Why.aspx.cs" Inherits="TokiPona.Tour001Why" %>

<%@ Register Src="~/Tour.ascx" TagPrefix="uc1" TagName="Tour" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
    <div style="margin-left: 15%; margin-right: 15%"><uc1:Tour runat="server" id="Tour" /></div>
    
    <br style="clear:both;"/>
    <div style="margin-left: 15%; margin-right: 15%">
    <br/>
    <p>Evaluating a language is difficult. Most people evaluate a language based on prestige and how many people speak it. Latin and Sanskrit have prestige, but no speakers. People still study it.
        Chinese and English have lots of speakers and in many places are a <i>lingua franca</i>, i.e. the preferred third language for communication when people don't share a common language. It goes without saying
        it is valuable to study those. But without prestige
        or a large speaking population, languages die and attract no learners or users.
    </p>
    <p>No non-natural language<sup><a href="#1">1</a></sup> is a <i>lingua franca</i>, although Esperanto tries and sort of gets close. To motivate yourself to learn a language like toki pona, you got to get <i>lingua franca</i>
        thinking out of your mind. toki pona is not and will never be a language for substantive communication between people who otherwise couldn't communicate.
    </p>
    <p>Each language, especially the non-natural ones, has a sort of internal logic to it. Try it out for what it is without focusing too much on how it is or isn't like some other well known non-natural 
        language. It isn't a movie language, it isn't trying to fool a professional field linguist, it isn't trying to unite a fractured Europe, it isn't trying to make for a more logical way to say 
        something. That would be Klingon, Tolkien's Elvish, Esperanto and Lojban respectively.
    </p>
    
    <h3>Learning Exercise</h3>
    <p>People are reporting being able to write texts and read texts after about 30 hours of study. This is the least expensive language learning experiment I know of. A similar amount of study for something
        prestigious like French would leave you unable to read or say anything at all.</p>
        
    <h3>A "lab" language</h3>
    <p>Often academics will use made up languages that they make up on the spot in experiments with people. <a href="http://scholar.google.com/scholar?hl=en&q=toki+pona&btnG=&as_sdt=1%2C47&as_sdtp=">toki pona has
         served that role and been mentioned before in academia.</a> Admittedly, most reference only list toki pona as an example of an artificial language, a few researchers actually used toki pona substantively. </p>

    <h3>An Exercise in Simplicity</h3>
    <p>The original promotional materials of toki pona mentioned taoism, yoga, zen, simplicity, positivity and so on. That a language can embody these is a sort of Sapir-Whorf theory, which doesn't have
        a lot of support in science. See Guy Deutscher's Through the Language Glass if you are curious about how this might work.</p>
    
        <h3>A Language Creation Exercise</h3>
    <p>The outline of toki pona has stay the same since about two years after it's release to the world. People continue to invent prestige scripts, number systems, and other peripheral things.
        This can be handy if you want to make up a language but don't want to make up the whole thing and would like an--admittedly small--audience for your efforts.
    </p>
        <h3>Whimsical Applications</h3>
        <p>Because of it's characteristics, toki pona could potentially be useful as a medical language (symbol boards for the disabled, or as a way to goose the brain into new growth, say to reverse depression, or as a spare language to stave off Alzheimer's ), 
            an animal language research tool, an alien contact language, since it would be easy to decipher, or who knows. </p>

    <p><a name="1">1</a><b>non-natural language</b>: On the internet, conlang, auxlang, artificial language, and every near synonym have been used to mean highly specific kinds of languages, creating a lexical gap in English.</p>
    </div>
</asp:Content>

