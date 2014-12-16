using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TpLogic;
using TpLogic.Corpus;

namespace TokiPona
{
    public partial class Gloss2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.txtInput.Text = SampleText.Anything(); 
                btnGloss_Click(this,new EventArgs());
            }
        }

        private Dictionary<string, string> TokiPonaLexicon()
        {
            Dictionary<string, string> basic = new Dictionary<string, string>();
            basic.Add("a", "ah!");
            basic.Add("akesi", "reptile");
            basic.Add("ala", "not");
            basic.Add("alasa", "hunt");
            basic.Add("ale", "all");
            basic.Add("ali", "all");
            basic.Add("anpa", "lower");
            basic.Add("ante", "different");
            basic.Add("anu", "or");
            basic.Add("awen", "stay");
            basic.Add("e", "DO");
            basic.Add("en", "and");
            basic.Add("esun", "store");
            basic.Add("ijo", "thing");
            basic.Add("ike", "bad");
            basic.Add("ilo", "tool");
            basic.Add("insa", "inside");
            basic.Add("jaki", "disgusting");
            basic.Add("jan", "person");
            basic.Add("jelo", "yellow");
            basic.Add("jo", "have");
            basic.Add("kala", "fish");
            basic.Add("kalama", "sound");
            basic.Add("kama", "become");
            basic.Add("kasi", "plant");
            basic.Add("ken", "can");
            basic.Add("kepeken", "use");
            basic.Add("kili", "fruit");
            basic.Add("kin", "indeed");
            basic.Add("kipisi", "cut");
            basic.Add("kiwen", "rock");
            basic.Add("ko", "sludge");
            basic.Add("kon", "air");
            basic.Add("kule", "color");
            basic.Add("kulupu", "comunity");
            basic.Add("kute", "listen");
            basic.Add("la", "IF");
            basic.Add("lape", "sleep");
            basic.Add("laso", "grue");
            basic.Add("lawa", "lead");
            basic.Add("len", "cloth");
            basic.Add("lete", "cold");
            basic.Add("li", "VERB");
            basic.Add("lili", "small");
            basic.Add("linja", "curve");
            basic.Add("lipu", "sheet");
            basic.Add("loje", "red");
            basic.Add("lon", "on");
            basic.Add("luka", "hand");
            basic.Add("lukin", "see");
            basic.Add("lupa", "hole");
            basic.Add("ma", "land");
            basic.Add("mama", "parent");
            basic.Add("mani", "money");
            basic.Add("meli", "woman");
            basic.Add("mi", "I");
            basic.Add("mije", "man");
            basic.Add("moku", "eat");
            basic.Add("moli", "die");
            basic.Add("monsi", "rear");
            basic.Add("mu", "moo!");
            basic.Add("mun", "moon");
            basic.Add("musi", "play");
            basic.Add("mute", "many");
            basic.Add("namako", "extra");
            basic.Add("nanpa", "number");
            basic.Add("nasa", "strange");
            basic.Add("nasin", "way");
            basic.Add("nena", "bump");
            basic.Add("ni", "this");
            basic.Add("nimi", "word");
            basic.Add("o", "O!");
            basic.Add("oko", "eye");
            basic.Add("olin", "love");
            basic.Add("ona", "it");
            basic.Add("open", "start");
            basic.Add("pakala", "break");
            basic.Add("pali", "work");
            basic.Add("palisa", "line");
            basic.Add("pan", "bread");
            basic.Add("pana", "give");
            basic.Add("pi", "OF");
            basic.Add("pilin", "feel");
            basic.Add("pimeja", "black");
            basic.Add("pini", "finish");
            basic.Add("pipi", "insect");
            basic.Add("poka", "with");
            basic.Add("poki", "box");
            basic.Add("pona", "good");
            basic.Add("pu", "??");
            basic.Add("sama", "same");
            basic.Add("seli", "heat");
            basic.Add("selo", "skin");
            basic.Add("seme", "what");
            basic.Add("sewi", "high");
            basic.Add("sijelo", "body");
            basic.Add("sike", "circle");
            basic.Add("sin", "new");
            basic.Add("sina", "you");
            basic.Add("sinpin", "face");
            basic.Add("sitelen", "picture");
            basic.Add("sona", "know");
            basic.Add("soweli", "animal");
            basic.Add("suli", "large");
            basic.Add("suno", "sun");
            basic.Add("supa", "flat surface");
            basic.Add("suwi", "sweet");
            basic.Add("tan", "because");
            basic.Add("taso", "but");
            basic.Add("tawa", "to");
            basic.Add("telo", "water");
            basic.Add("tenpo", "time");
            basic.Add("toki", "speak");
            basic.Add("tomo", "house");
            basic.Add("tu", "two");
            basic.Add("unpa", "sex");
            basic.Add("uta", "hole");
            basic.Add("utala", "fight");
            basic.Add("walo", "white");
            basic.Add("wan", "one");
            basic.Add("waso", "bird");
            basic.Add("wawa", "power");
            basic.Add("weka", "remove");
            basic.Add("wile", "want");
            return basic;
        }

        private Dictionary<string, string> TokiPonaNouns()
        {
            Dictionary<string, string> basic = new Dictionary<string, string>();
            basic.Add("a", "the word 'a'");
            basic.Add("akesi", "a reptile");
            basic.Add("ala", "nothing");
            basic.Add("alasa", "a hunt");
            basic.Add("ale", "everything");
            basic.Add("ali", "everything");
            basic.Add("anpa", "the lower part");
            basic.Add("ante", "the change");
            //basic.Add("anu", "or");
            basic.Add("awen", "the thing that stays");
            //basic.Add("e", "DO");
            //basic.Add("en", "and");
            basic.Add("esun", "the store");
            basic.Add("ijo", "the thing");
            basic.Add("ike", "the bad thing (?)");
            basic.Add("ilo", "the tool");
            basic.Add("insa", "the inside area");
            basic.Add("jaki", "the disgusting thing (?)");
            basic.Add("jan", "the person");
            basic.Add("jelo", "the yellow thing(?)");
            //basic.Add("jo", "have");
            basic.Add("kala", "the fish");
            basic.Add("kalama", "the sound");
            //basic.Add("kama", "become");
            basic.Add("kasi", "the plant");
            //basic.Add("ken", "can");
            basic.Add("kepeken", "the usage");
            basic.Add("kili", "the fruit");
            //basic.Add("kin", "indeed");
            basic.Add("kipisi", "the cut");
            basic.Add("kiwen", "the rock");
            basic.Add("ko", "the sludge");
            basic.Add("kon", "the air");
            basic.Add("kule", "the color");
            basic.Add("kulupu", "the community");
            basic.Add("kute", "the ear, the listening");
            //basic.Add("la", "if");
            basic.Add("lape", "the sleep");
            basic.Add("laso", "the blue thing (?)");
            basic.Add("lawa", "the leader");
            basic.Add("len", "the clothing");
            basic.Add("lete", "the sleep");
            //basic.Add("li", "VERB");
            basic.Add("lili", "the small one (?)");
            basic.Add("linja", "the curves");
            basic.Add("lipu", "the sheet");
            basic.Add("loje", "the red thing(?)");
            basic.Add("lon", "the truth");
            basic.Add("luka", "the hand");
            basic.Add("lukin", "the sight");
            basic.Add("lupa", "the hole");
            basic.Add("ma", "the land");
            basic.Add("mama", "the parent");
            basic.Add("mani", "the money");
            basic.Add("meli", "the woman");
            basic.Add("mi", "I");
            basic.Add("mije", "the man");
            basic.Add("moku", "the food");
            basic.Add("moli", "the death");
            basic.Add("monsi", "the area to the rear");
            basic.Add("mu", "the sound moo!");
            basic.Add("mun", "the moon");
            basic.Add("musi", "the game");
            basic.Add("mute", "the many (things)");
            basic.Add("namako", "the spice");
            basic.Add("nanpa", "the number");
            basic.Add("nasa", "the strange one (?)");
            basic.Add("nasin", "the way");
            basic.Add("nena", "the bump");
            basic.Add("ni", "this");
            basic.Add("nimi", "the word");
            basic.Add("o", "o!");
            basic.Add("oko", "the eye");
            basic.Add("olin", "the love");
            basic.Add("ona", "it");
            basic.Add("open", "the start");
            basic.Add("pakala", "the mistale");
            basic.Add("pali", "the work");
            basic.Add("palisa", "the stick");
            basic.Add("pan", "the bread");
            basic.Add("pana", "to gift");
            //basic.Add("pi", "of");
            basic.Add("pilin", "the feeling");
            basic.Add("pimeja", "the blackness");
            basic.Add("pini", "the end");
            basic.Add("pipi", "the insect");
            //basic.Add("poka", "with");
            basic.Add("poki", "the box");
            basic.Add("pona", "the good thing (?)");
            //basic.Add("pu", "??");
            basic.Add("sama", "the same thing (?)");
            basic.Add("seli", "the heat");
            basic.Add("selo", "the skin");
            basic.Add("seme", "what");
            basic.Add("sewi", "the high place");
            basic.Add("sijelo", "the body");
            basic.Add("sike", "the circle");
            basic.Add("sin", "the new thing (?)");
            basic.Add("sina", "you");
            basic.Add("sinpin", "the face");
            basic.Add("sitelen", "the picture");
            basic.Add("sona", "knowledge");
            basic.Add("soweli", "the animal");
            basic.Add("suli", "the magnitude");
            basic.Add("suno", "the sun");
            basic.Add("supa", "the flat surface");
            basic.Add("suwi", "the sweet thing (?)");
            basic.Add("tan", "reason");
            //basic.Add("taso", "but");
            basic.Add("tawa", "to");
            basic.Add("telo", "the water");
            basic.Add("tenpo", "the time");
            basic.Add("toki", "the language");
            basic.Add("tomo", "the house");
            basic.Add("tu", "the pair");
            basic.Add("unpa", "sexual activity");
            basic.Add("uta", "the hole");
            basic.Add("utala", "the fight");
            basic.Add("walo", "the whiteness");
            basic.Add("wan", "the single one");
            basic.Add("waso", "the bird");
            basic.Add("wawa", "the power");
            basic.Add("weka", "the removal (?)");
            basic.Add("wile", "the desire");
            return basic;
        }

        protected void btnGloss_Click(object sender, EventArgs e)
        {
            SentenceProcessor sp = new SentenceProcessor();
            string toConvert = Server.HtmlEncode(txtInput.Text);

            Collection<Sentence> sentences = sp.SplitIntoSentences(toConvert.ToLower().Trim());
                        
            StringBuilder sb = new StringBuilder();
            foreach (Sentence sentence in sentences)
            {
                sb.Append(GlossASentence(sentence));
            }
            txtOutput.Text = sb.ToString();
            Session["html"] = sb.ToString();
        }

        private string GlossASentence(Sentence sentence)
        {
            StringBuilder sb = new StringBuilder(sentence.Text.Length);
            sb.Append("<table border='1'><tr>");
            sb.Append("<td colspan='");
            sb.Append(sentence.Words.Length);
            sb.Append("'>");
            sb.Append(sentence.Type.ToString());
            sb.Append("</td>");

            //Splits into SP/SP/SP/VP/VP/VP (large VP's with e's and PP's)
            sb.Append(ProcessStructureRow(sentence));

            sb.Append("<tr>");
            
            VerbPhraseProcessor vpp = new VerbPhraseProcessor();
            SubjectProcessor sp = new SubjectProcessor();
            NounPhraseProcessor npp = new NounPhraseProcessor();
            Lexicon tp = new Lexicon();

            int wordsGlossed = 0;
            foreach (Subject subject in sp.SplitIntoSubjects(sentence.Text))
            {
                foreach(NounPhrase np in npp.SplitIntoNounPhrases(subject.Text))
                {
                    sb.Append("<td>");
                    Noun n = new Noun(tp, np.HeadNoun());
                    sb.Append(n.Translate()); 
                    sb.Append("</td>");
                    
                    foreach (string modifier in np.Modifiers())
                    {
                        sb.Append("<td>");
                        Modifier m = new Modifier(tp, modifier);
                        sb.Append(m.Translate());
                        sb.Append("</td>");
                    }

                    if (np.Type == NpType.Pi)
                        sb.Append("<td>PI</td>");

                    wordsGlossed += np.Words.Length;
                }
                if(subject.Type!=SubjectType.None)
                {
                    sb.Append("<td>");
                    sb.Append(subject.Type);
                    sb.Append("</td>");
                    wordsGlossed += 1;
                }
            }
            ModalProcessor mp = new ModalProcessor(tp);
            PrepositionalPhraseProcessor ppp = new PrepositionalPhraseProcessor();
            DirectObjectProcessor dop = new DirectObjectProcessor();
            foreach (VerbPhrase verbPhrase in vpp.SplitIntoVerbPhrases(sentence.Text))
            {
                foreach (Modal modal in mp.SplitIntoModals(verbPhrase.Text))
                {
                    sb.Append("<td>");
                    sb.Append(modal.Translate());
                    sb.Append("</td>");
                    wordsGlossed += 1;
                }

                //The core verb
                //The verbal compounds or adverbs.
                sb.Append("<td>");
                sb.Append("V/Adv");//place holder
                sb.Append("</td>");
                wordsGlossed += 1;

                foreach (DirectObject directObject in dop.SplitIntoDirectObjects(verbPhrase.Text))
                {
                    sb.Append("<td colspan='");
                    sb.Append(directObject.Words.Length);
                    sb.Append("'>");
                    sb.Append(directObject.Text + " DO");//place holder
                    sb.Append("</td>");
                    wordsGlossed += directObject.Words.Length +1;
                }

                foreach (PrepositionalPhrase prep in ppp.SplitIntoPrepPhrases(verbPhrase.Text))
                {
                    sb.Append("<td colspan='");
                    sb.Append(prep.Words.Length);
                    sb.Append("'>");
                    sb.Append(prep.Text + " PP");//place holder
                    sb.Append("</td>");
                    wordsGlossed += prep.Words.Length;
                }
            }

            //Gap
            if (sentence.Words.Length - wordsGlossed>0)
            {
                sb.Append("<td colspan='");
                sb.Append(sentence.Words.Length - wordsGlossed);
                sb.Append("'>");
                sb.Append(sentence.Words.Length - wordsGlossed);
                sb.Append("</td>");
            }

            sb.Append("</tr>");
                
            sb.Append("</table>");
            return sb.ToString();
        }

        private string ProcessStructureRow(Sentence sentence)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<tr>");
            SubjectProcessor sp = new SubjectProcessor();
            foreach (Subject subject in sp.SplitIntoSubjects(sentence.Text) )
            {
                sb.Append("<td colspan='");
                sb.Append(subject.Words.Length);
                sb.Append("'>");
                sb.Append("Subject<br/>(");
                sb.Append(subject.Text);
                sb.Append(")");
                sb.Append("</td>");
            }
            VerbPhraseProcessor vpp = new VerbPhraseProcessor();
            foreach (VerbPhrase verbPhrase in vpp.SplitIntoVerbPhrases(sentence.Text))
            {
                sb.Append("<td colspan='");
                sb.Append(verbPhrase.Words.Length);
                sb.Append("'>");
                sb.Append("VP<br/>(");
                sb.Append(verbPhrase.Text);
                sb.Append(")");
                sb.Append("</td>");
            }
            sb.Append("</tr>");
            return sb.ToString();
        }

        private bool LastWordWasDoMarker(int index, string[] word)
        {
            if (index == 0) return false;
            if (word.Length < index - 1-1) return false;
            return word[index - 1].ToString() == "e";
        }

        private bool LastWordWasPreposition(int index, string[] word)
        {
            if (index == 0) return false;
            if (word.Length < index-1-1) return false;
            return word[index - 1].ToString() == "lon";
        }

        private bool NextWordIsDirectObject(int index, string[] word)
        {
            if (index + 1 == word.Length) return false;
            if (word.Length < index-1-1) return false;
            return word[index + 1].ToString() == "e";
        }

    }
}
