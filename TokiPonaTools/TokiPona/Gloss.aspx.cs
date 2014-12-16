using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TpLogic.Corpus;

namespace TokiPona
{
    public partial class Gloss : System.Web.UI.Page
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
            string toConvert = Server.HtmlEncode(txtInput.Text);

            string[] sentences = toConvert.ToLower().Trim().Split(new char[] { '.', '?', ':' });
            
            StringBuilder sb = new StringBuilder(sentences.Length*50);
            foreach (string sentence in sentences)
            {
                if (sentence.Trim().Length > 0)
                {
                    sb.Append(GlossASentence(sentence));
                }
                
            }
            txtOutput.Text = sb.ToString();
            Session["html"] = sb.ToString();
        }

        private string GlossASentence(string sentence)
        {
            string text = sentence.ToLower().Trim().Replace(",", " ");

            while (text.Contains("  "))
                text = text.Replace("  ", " ");

            if (text.StartsWith(" la mi "))
                text = text.Replace(" la mi ", "la mi li(IMP) ");
            if (text.StartsWith(" la sina "))
                text = text.Replace(" la sina ", "la sina li(IMP) ");

            if (text.StartsWith(" o mi "))
                text = text.Replace(" o mi ", "o mi li(IMP) ");
            if (text.StartsWith(" o sina "))
                text = text.Replace(" o sina ", "o sina li(IMP) ");

            if (text.StartsWith("mi "))
                text = "mi li(IMP) " + text.Substring("li ".Length);
            if (text.StartsWith("sina "))
                text = "sina li(IMP) " + text.Substring("sina ".Length);

            string[] words = text.Split(' ');

            StringBuilder sb = new StringBuilder(words.Length*4);
            sb.Append("<table border='1'><tr>");
            foreach (string word in words)
            {
                sb.Append("<td>");
                if (word != "li(IMP)")
                    sb.Append(word);
                sb.Append("</td>");
            }
            sb.Append("</tr><tr>");

            Dictionary<string, string> basic = TokiPonaLexicon();
            Dictionary<string, string> verb = TokiPonaTransitiveVerbs();
            Dictionary<string, string> nouns = TokiPonaNouns();
            Dictionary<string, string> modifiers = TokiPonaModifers();

            bool foundDo = false;

            string lastPos = "";
            string nextPos = "noun";
            int count = 0;
            for (int index = 0; index < words.Length; index++)
            {
                string word = words[index];
                sb.Append("<td>");

                count++;

                //All sentence start with noun.
                if (count == 1)
                    nextPos = "noun";

                if (lastPos == "noun" && (word != "li" && word != "pi" && word != "la" && word != "e"))
                {
                    if (modifiers.ContainsKey(word))
                    {
                        sb.Append(modifiers[word]);
                        lastPos = "modifier";
                    }
                    else
                    {
                        AppendDefault(sb, word, basic);
                        lastPos = "";
                    }
                }
                else if (lastPos.StartsWith("verb") && NextWordIsDirectObject(index, words))
                {
                    //Transitive verbs
                    if (nouns.ContainsKey(word))
                    {
                        sb.Append(verb[word]);
                        lastPos = "verbt";
                    }
                    else
                    {
                        AppendDefault(sb, word, basic);
                        lastPos = "";
                    }
                }
                else if (nextPos == "verb" && words.Contains("e"))
                {
                    //Transitive verbs
                    if (nouns.ContainsKey(word))
                    {
                        sb.Append(verb[word]);
                        lastPos = "verbt";
                    }
                    else
                    {
                        AppendDefault(sb, word, basic);
                        lastPos = "";
                    }
                }
                else if (nextPos == "noun")
                {
                    //Word following e
                    //1st word in sentence
                    //word after preposition
                    if (nouns.ContainsKey(word))
                    {
                        if(LastWordWasDoMarker(index,words) && word=="mi")
                        {
                            sb.Append("me");
                        }
                        if (LastWordWasDoMarker(index, words) && word == "ona")
                        {
                            sb.Append("it/him/her");
                        }
                        else
                        {
                            sb.Append(nouns[word]);
                        }
                        lastPos = "noun";
                    }
                    else
                    {
                        AppendDefault(sb, word, basic);
                        lastPos = "";
                    }
                }
                else
                {
                    AppendDefault(sb, word, basic);
                    lastPos = "";
                }

                if(word=="e")
                {
                    foundDo = true;
                }

                if (word == "li" || word=="li(IMP)")
                {
                    nextPos = "verb";
                }
                else if (word == "e" || word == "pi" || word=="o")
                {
                    nextPos = "noun";
                }
                //id' the prepositional phrase
                if (foundDo && LastWordWasPreposition(index,words))
                {
                    nextPos = "noun";
                }

                sb.Append("</td>");
            }

            sb.Append("</tr></table>");
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

        private Dictionary<string, string> TokiPonaModifers()
        {
            Dictionary<string, string> basic = new Dictionary<string, string>();
            //basic.Add("a", "ah!");
            basic.Add("akesi", "reptile's, reptile-like");
            basic.Add("ala", "un-");
            basic.Add("alasa", "hunting");
            basic.Add("ale", "all");
            basic.Add("ali", "all");
            basic.Add("anpa", "lower");
            basic.Add("ante", "different");
            basic.Add("anu", "or");
            basic.Add("awen", "fastened, immobile");
            //basic.Add("e", "DO");
            //basic.Add("en", "and");
            basic.Add("esun", "mercantile");
            basic.Add("ijo", "thing's");
            basic.Add("ike", "bad");
            basic.Add("ilo", "tool's");
            basic.Add("insa", "inside's");
            basic.Add("jaki", "disgusting");
            basic.Add("jan", "person's");
            basic.Add("jelo", "yellow");
            basic.Add("jo", "having");
            basic.Add("kala", "fish's, fishlike");
            basic.Add("kalama", "sound's, noisy");
            basic.Add("kama", "becoming");
            basic.Add("kasi", "planting");
            //basic.Add("ken", "can");
            basic.Add("kepeken", "using");
            basic.Add("kili", "fruit's, fruity");
            //basic.Add("kin", "indeed");
            basic.Add("kipisi", "the cut's, cutting");
            basic.Add("kiwen", "rock's, rock-like");
            basic.Add("ko", "sludge's, sludge-like");
            basic.Add("kon", "air's, gassy");
            basic.Add("kule", "color's, colorful");
            basic.Add("kulupu", "community's, communal");
            basic.Add("kute", "listening");
            //basic.Add("la", "if");
            basic.Add("lape", "sleeping, soporific");
            basic.Add("laso", "grue");
            basic.Add("lawa", "head's, leader's, chief/main");
            basic.Add("len", "cloth's, cloth");
            basic.Add("lete", "cold");
            //basic.Add("li", "VERB");
            basic.Add("lili", "small");
            basic.Add("linja", "curvy");
            basic.Add("lipu", "flat");
            basic.Add("loje", "red");
            //basic.Add("lon", "on");
            basic.Add("luka", "hand's");
            basic.Add("lukin", "seeing");
            basic.Add("lupa", "hole's");
            basic.Add("ma", "land's, geographic");
            basic.Add("mama", "parent's, parental");
            basic.Add("mani", "money's, monetary");
            basic.Add("meli", "woman's, feminine");
            basic.Add("mi", "my");
            basic.Add("mije", "man's, manly");
            basic.Add("moku", "eating, edible");
            basic.Add("moli", "dieing, death's");
            basic.Add("monsi", "rear's");
            basic.Add("mu", "'mu's, moo! (?)");
            basic.Add("mun", "moon's, lunar");
            basic.Add("musi", "playing, game's, amusing");
            basic.Add("mute", "many, -s (plural)");
            basic.Add("namako", "extra, spicy");
            basic.Add("nanpa", "number");
            basic.Add("nasa", "strange");
            basic.Add("nasin", "way");
            basic.Add("nena", "bump's");
            basic.Add("ni", "this's");
            basic.Add("nimi", "word's");
            //basic.Add("o", "o!");
            basic.Add("oko", "eye's, visual");
            basic.Add("olin", "loving, love's");
            basic.Add("ona", "it's");
            basic.Add("open", "beginning's");
            basic.Add("pakala", "breaking, mistake's");
            basic.Add("pali", "working, work's");
            basic.Add("palisa", "linear, stick-like");
            basic.Add("pan", "bread's, bread-like");
            basic.Add("pana", "giving, gift's");
            //basic.Add("pi", "of");
            basic.Add("pilin", "feeling, heart's");
            basic.Add("pimeja", "black");
            basic.Add("pini", "end's, final");
            basic.Add("pipi", "insect's, insect=like");
            //basic.Add("poka", "with");
            basic.Add("poki", "box");
            basic.Add("pona", "good");
            basic.Add("pu", "??");
            basic.Add("sama", "same");
            basic.Add("seli", "hot, heat's");
            basic.Add("selo", "skin's");
            basic.Add("seme", "what sort");
            basic.Add("sewi", "high");
            basic.Add("sijelo", "body's, incoporeal");
            basic.Add("sike", "circle's, round");
            basic.Add("sin", "new");
            basic.Add("sina", "your");
            basic.Add("sinpin", "face's, facial");
            basic.Add("sitelen", "picture's, written, drawn");
            basic.Add("sona", "knowing, smart");
            basic.Add("soweli", "animal's, beastly");
            basic.Add("suli", "large, magnitude's");
            basic.Add("suno", "shiny, sun's");
            basic.Add("supa", "surface's");
            basic.Add("suwi", "sweet, candy's");
            //basic.Add("tan", "because");
            basic.Add("taso", "only, just");
            basic.Add("tawa", "moving");
            basic.Add("telo", "water's, wet");
            basic.Add("tenpo", "time's");
            basic.Add("toki", "speaking");
            basic.Add("tomo", "house's, housing (?)");
            basic.Add("tu", "two, PL (dual)");
            basic.Add("unpa", "sexual");
            basic.Add("uta", "hole's");
            basic.Add("utala", "fighting");
            basic.Add("walo", "white");
            basic.Add("wan", "one's, unified");
            basic.Add("waso", "bird's, bird-like");
            basic.Add("wawa", "powerful");
            basic.Add("weka", "removing, falling");
            basic.Add("wile", "wanted");
            return basic;
        }

        private void AppendDefault(StringBuilder sb, string word, Dictionary<string, string> basic)
        {
            if (basic.ContainsKey(word))
            {
                //Default gloss
                sb.Append(basic[word]);
            }
            else
            {
                //Can only be a proper modifer
                sb.Append(Capitalize(word));
            }
        }

        private Dictionary<string, string> TokiPonaTransitiveVerbs()
        {
            Dictionary<string, string> basic = new Dictionary<string, string>();
            //basic.Add("a", "ah!");
            basic.Add("akesi", "makes into a reptile");
            basic.Add("ala", "negates");
            basic.Add("alasa", "hunts");
            //basic.Add("ale", "all");
            //basic.Add("ali", "all");
            basic.Add("anpa", "lowers");
            basic.Add("ante", "changes");
            //basic.Add("anu", "or");
            basic.Add("awen", "stay");
            //basic.Add("e", "DO");
            //basic.Add("en", "and");
            basic.Add("esun", "sells");
            basic.Add("ijo", "objectifies");
            basic.Add("ike", "makes worse");
            basic.Add("ilo", "uses as a tool");
            basic.Add("insa", "places inside");
            basic.Add("jaki", "makes disgusting");
            basic.Add("jan", "humanizes");
            basic.Add("jelo", "makes yellow");
            basic.Add("jo", "have");
            basic.Add("kala", "turns into a fish");
            basic.Add("kalama", "makes a noise");
            basic.Add("kama", "becomes");
            basic.Add("kasi", "plants");
            basic.Add("ken", "enables");
            basic.Add("kepeken", "uses");
            basic.Add("kili", "turns into fruit");
            //basic.Add("kin", "indeed");
            basic.Add("kipisi", "cuts");
            basic.Add("kiwen", "makes into a rock");
            basic.Add("ko", "makes disgusting");
            basic.Add("kon", "turns into air");
            basic.Add("kule", "colors");
            basic.Add("kulupu", "gathers into a group");
            basic.Add("kute", "listens");
            //basic.Add("la", "if");
            basic.Add("lape", "puts to sleep");
            basic.Add("laso", "bluens");
            basic.Add("lawa", "leads");
            basic.Add("len", "clothes");
            basic.Add("lete", "make cold");
            //basic.Add("li", "VERB");
            basic.Add("lili", "shrinks");
            basic.Add("linja", "makes into a curve");
            basic.Add("lipu", "makes into a sheet");
            basic.Add("loje", "makes red");
            basic.Add("lon", "on");
            basic.Add("luka", "hands");
            basic.Add("lukin", "sees");
            basic.Add("lupa", "punches a hole");
            basic.Add("ma", "turns into land");
            basic.Add("mama", "invents");
            basic.Add("mani", "turns into money");
            basic.Add("meli", "makes into a woman");
            basic.Add("mi", "I");
            basic.Add("mije", "makes into a man");
            basic.Add("moku", "eats");
            basic.Add("moli", "dies");
            basic.Add("monsi", "places behind");
            basic.Add("mu", "says moo! to");
            basic.Add("mun", "turns into a moon");
            basic.Add("musi", "plays");
            basic.Add("mute", "multiplies");
            basic.Add("namako", "makes extra");
            basic.Add("nanpa", "counts");
            basic.Add("nasa", "makes strange");
            basic.Add("nasin", "makes into path");
            basic.Add("nena", "turns into bump");
            basic.Add("ni", "this");
            basic.Add("nimi", "names");
            basic.Add("o", "o!");
            basic.Add("oko", "eyes");
            basic.Add("olin", "loves");
            //basic.Add("ona", "it (Error?)");
            basic.Add("open", "starts");
            basic.Add("pakala", "breaks");
            basic.Add("pali", "works");
            basic.Add("palisa", "makes into a stick");
            basic.Add("pan", "makes into bread");
            basic.Add("pana", "gives");
            //basic.Add("pi", "of");
            basic.Add("pilin", "feels");
            basic.Add("pimeja", "blackens");
            basic.Add("pini", "finishes");
            basic.Add("pipi", "turns into an insect");
            //basic.Add("poka", "with");
            basic.Add("poki", "boxes");
            basic.Add("pona", "makes good");
            basic.Add("pu", "??");
            basic.Add("sama", "equals");
            basic.Add("seli", "heats");
            basic.Add("selo", "surrounds");
            basic.Add("seme", "what (toki nasa)");
            basic.Add("sewi", "raises");
            basic.Add("sijelo", "turns into a body");
            basic.Add("sike", "circles");
            basic.Add("sin", "makes new");
            //basic.Add("sina", "you");
            basic.Add("sinpin", "places to the front of");
            basic.Add("sitelen", "makes a picture of");
            basic.Add("sona", "knows");
            basic.Add("soweli", "truns into an animal");
            basic.Add("suli", "grows");
            basic.Add("suno", "enlighten");
            basic.Add("supa", "flattens");
            basic.Add("suwi", "sweet");
            basic.Add("tan", "causes");
            //basic.Add("taso", "but");
            basic.Add("tawa", "moves");
            basic.Add("telo", "washes");
            basic.Add("tenpo", "times (?)");
            basic.Add("toki", "speaks");
            basic.Add("tomo", "makes into houses");
            basic.Add("tu", "doubles/divides (!)");
            basic.Add("unpa", "has sex with");
            basic.Add("uta", "make a hole in");
            basic.Add("utala", "fights");
            basic.Add("walo", "whitens");
            basic.Add("wan", "unifies");
            basic.Add("waso", "turns into a bird");
            basic.Add("wawa", "makes powerful");
            basic.Add("weka", "removes");
            basic.Add("wile", "wants");
            return basic;
        }

        private string Capitalize(string word)
        {
            if (string.IsNullOrEmpty(word)) return "";
            if (word.Length == 0) return "";
            if (word.Length == 1) return word.ToUpper();

            string firstLetter = word.Substring(0, 1).ToUpper();
            return firstLetter + word.Substring(1, word.Length - 1);
        }
    }
}
