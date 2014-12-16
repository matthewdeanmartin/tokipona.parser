using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TpLogic.Compress
{
    public class Recode
    {

        public bool EndsWithNonLetter(string input)
        {
            string alphabet = "AEIJKLMNOPSTUWaeijklmnopstuw";

            foreach (char c in input)
            {
                if (!alphabet.Contains(c)) return true;
            }

            return false;
        }

        public string ExpandUnicode(string input)
        {
            return
                ShortenToAnyDictionary(input,
                        ReverseDictionary(UnicodeDictionary()),
                        ModifierStyle.CapitalizeFirst,
                        PunctuationStyle.Western).Trim();
        }

        public string ShortenToUnicode(string input)
        {
            return ShortenToAnyDictionary(input, UnicodeDictionary(), 
                ModifierStyle.CapitalizeFirst,
                PunctuationStyle.Oriental);
        }

        public string ExpandChinese(string input)
        {
            return
                ShortenToAnyDictionary(input, 
                        ReverseDictionary(GetChinese()),
                        ModifierStyle.CapitalizeFirst,
                        PunctuationStyle.Western).Trim();
        }

        public string ShortenToChinese(string input)
        {
            return ShortenToAnyDictionary(input, GetChinese(), 
                ModifierStyle.CapitalizeFirst,
                PunctuationStyle.Oriental);
        }
        public string ExpandJapanese(string input)
        {
            return
                ShortenToAnyDictionary(input,
                        ReverseDictionary(GetJapaneseDictionary()),
                        ModifierStyle.CapitalizeFirst,
                        PunctuationStyle.Western).Trim();
        }

        public string ShortenToJapanese2(string input)
        {
            return ShortenToAnyDictionary(input, GetJapaneseDictionary(), 
                ModifierStyle.CapitalizeFirst,
                PunctuationStyle.Oriental);
        }

        public enum ModifierStyle
        {
            CapitalizeFirst,
            CapitalizeAll,
            DoubleQuote,
            SingleQuote
        }

        public enum PunctuationStyle
        {
            Oriental,
            Western
        }

        public string ShortenToAnyDictionary(string input, 
            Dictionary<string, string> dictionary,
            ModifierStyle how,
            PunctuationStyle punctuate, string formatModifiers=null, string formatModifiersBack=null)
        {
            //Fix for 1 off bug.
            input = input + " ";

            
            StringBuilder sb = new StringBuilder();

            //char[] whiteSpace = new char[] { ' ', '\r', '\n' };
            //char[] punctuation = new char[] { ',', ':', '.', '?' };
            //string[] plaintext = input.Split(whiteSpace);
            int lastStart = 0;
            int currentWordLength = 1;
            for (int i = 0; i < input.Length+1; i++)
            {

                string word;
                if (lastStart + currentWordLength > input.Length)
                {
                    //Not good. Why are we here?
                    word = input.Substring(lastStart);
                }
                else
                {
                    word = input.Substring(lastStart, currentWordLength);
                }

                if (EndsWithNonLetter(word))// && word.Length > 1)
                {
                    string wordPart;
                    string tailPart;

                    if (word.Length == 1)
                    {
                        wordPart = word;
                        tailPart = "";
                    }
                    else
                    {
                        wordPart = word.Substring(0, word.Length - 1);
                        tailPart = word.Substring(word.Length - 1, 1);
                    }

                    if (dictionary.ContainsKey(wordPart))
                    {
                        sb.Append(dictionary[wordPart]);
                        sb.Append(tailPart);
                    }
                    else
                    {
                        if(formatModifiers!=null)
                                sb.Append(formatModifiers);
                        if (how == ModifierStyle.CapitalizeFirst)
                        {
                            sb.Append(UppercaseFirst(wordPart));
                            sb.Append(tailPart);
                        }
                        else if (how == ModifierStyle.CapitalizeAll)
                        {
                            sb.Append(wordPart.ToUpper());
                            sb.Append(tailPart);
                        }
                        if (formatModifiersBack != null)
                            sb.Append(formatModifiersBack);
                    }
                    
                    
                    lastStart = i+1;
                    currentWordLength = 0;
                }

                currentWordLength++;
            }

            if (punctuate==PunctuationStyle.Oriental)
            {
                //English punctuation is invisible in kanji.
                sb.Replace(".", "。");
                sb.Replace(".", "：");
                sb.Replace("!", "！");
                sb.Replace("?", "？");
            }

            return sb.ToString();//.Replace("  "," ");
        }

        //http://dotnetperls.com/uppercase-first-letter
        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1).ToLower();
        }

        //public string ShortToJapanese(string input)
        //{
        //    Dictionary<string, string> dictionary = GetJapaneseDictionary();
        //    StringBuilder sb = new StringBuilder();

        //    char[] whiteSpace = new char[] { ' ', '\r', '\n' };
        //    char[] punctuation = new char[] { ',', ':', '.', '?' };
        //    string[] plaintext = input.Split(whiteSpace);
        //    for (int i = 0; i < plaintext.Length; i++)
        //    {
        //        string[] word = plaintext[i].Split(punctuation);

        //        foreach (string potentialWord in word)
        //        {
        //            if (dictionary.ContainsKey(potentialWord))
        //                sb.Append(dictionary[potentialWord]);
        //            else if (isPunctuation(potentialWord, punctuation))
        //            {
        //                sb.Append(potentialWord);
        //                sb.Append(" ");
        //            }
        //            else
        //                sb.Append("<b> " + potentialWord + " </b>");
        //            sb.Append(" ");
        //        }
        //    }

        //    return sb.ToString() + "<br/>" + sb.ToString().Trim();
        //}

        

        public string Shorten(string input)
        {
            return ShortenToAnyDictionary(input, GetDictionary(), 
                ModifierStyle.CapitalizeAll,
                PunctuationStyle.Western).Trim();

            //Dictionary<string, string> dictionary = GetDictionary();
            //StringBuilder sb = new StringBuilder();

            //char[] whiteSpace = new char[] { ' ', '\r', '\n' };
            //char[] punctuation = new char[] { ',', ':', '.', '?' };
            //string[] plaintext = input.Split(whiteSpace);
            //for (int i = 0; i < plaintext.Length; i++)
            //{
            //    string[] word = plaintext[i].Split(punctuation);

            //    foreach (string potentialWord in word)
            //    {
            //        if (dictionary.ContainsKey(potentialWord))
            //            sb.Append(dictionary[potentialWord]);
            //        else if (isPunctuation(potentialWord, punctuation))
            //        {
            //            sb.Append(potentialWord);
            //            sb.Append(" ");
            //        }
            //        else
            //            sb.Append("<b> " + potentialWord + " </b>");
            //        sb.Append(" ");
            //    }
            //}

            //return sb.ToString() + "<br/><br/>" + sb.ToString().Trim().Replace(" ", "");
        }

        private bool EndWithFormatingPuctuation(string word)
        {
            if (word.Length != 1) return false;
            if (word == "\r") return true;
            if (word == " ") return true;
            if (word == "\n") return true;
            if (word == "\t") return true;
            if (word == ".") return true;
            if (word == "!") return true;
            if (word == "@") return true;
            if (word == "#") return true;
            if (word == "$") return true;
            if (word == "%") return true;
            if (word == "%") return true;
            if (word == "^") return true;
            if (word == "&") return true;
            if (word == "*") return true;
            if (word == "(") return true;
            if (word == ")") return true;
            if (word == ";") return true;
            if (word == ":") return true;
            if (word == "?") return true;
            if (word == ",") return true;
            if (word == "\"") return true;
            if (word == "'") return true;
            if (word == "-") return true;
            if (word == "+") return true;
            return false;

        }

        private bool isPunctuation(string word, char[] punctuation)
        {
            if (word.Length > 1) return false;
            foreach (char c in punctuation)
            {
                if (word == c.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        //This would work better for spaceless.
        public string ExpandTwoLetter(string input)
        {
            Dictionary<string, string> dictionary = ReverseDictionary(GetDictionary());
            StringBuilder sb = new StringBuilder();

            //string[] chunks = input.Split(new char[] { '^', '*', '!', '~', '@' });

            input = input.Replace("^", "|l");//la
            input = input.Replace("*", "|i");//li
            input = input.Replace("!", "|o");//o
            input = input.Replace("~", "|e");//e
            input = input.Replace("@", "|p");//pi

            for (int i = 0; i < input.Length - 1; i = i + 2)
            {
                if (dictionary.ContainsKey(input.Substring(i, 2)))
                {
                    sb.Append(dictionary[input.Substring(i, 2)]);
                }
                else
                {
                    sb.Append(input.Substring(i, 2));
                }

                sb.Append(" ");
            }

            return sb.ToString().Replace("|l", "la").Replace("|i", "li").Replace("|i", "lo").Replace("|e", "e").Replace("|p", "pi").Replace("|o", "o").Trim();
    }

        public string ExpandTwoLetterWithSpaces(string input)
        {
            return ShortenToAnyDictionary(input, ReverseDictionary(GetDictionary()),ModifierStyle.CapitalizeFirst,PunctuationStyle.Western).Trim();
            /*
            Dictionary<string, string> dictionary = ReverseDictionary(GetDictionary());
            StringBuilder sb = new StringBuilder();

            string[] chunks = input.Split(new char[] { '^', '*', '!', '~', '@' }, StringSplitOptions.RemoveEmptyEntries);

            input = input.Replace("^", "|l");//la
            input = input.Replace("*", "|i");//li
            input = input.Replace("!", "|o");//o
            input = input.Replace("~", "|e");//e
            input = input.Replace("@", "|p");//pi

            int i = 0;
                while (i < input.Length - 1)
                {

                    if (input.Substring(i, 1) == input.Substring(i, 1).ToUpper())
                    {
                        sb.Append(input.Substring(i, 1));
                        i++;
                    }
                    else
                    {
                        if (dictionary.ContainsKey(input.Substring(i, 2)))
                        {
                            sb.Append(dictionary[input.Substring(i, 2)]);
                        }
                        else
                        {
                            sb.Append(input.Substring(i, 2));
                        }
                        i = i + 2;
                    }
                    sb.Append(" ");
                }


            return
                sb.ToString().Replace("|l", "la").Replace("|i", "li").Replace("|i", "lo").Replace("|e", "e").Replace(
                    "|p", "pi").Replace("|o", "o").Trim();
             * */
        }

        public static Dictionary<string,string> UnicodeDictionary()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            dictionary.Add("!","\u0021");

            dictionary.Add("(","\u0028");
            dictionary.Add(")","\u0029");
            dictionary.Add(",","\u002C");
            dictionary.Add("-","\u002D");
            dictionary.Add(".","\u002E");
            dictionary.Add(":","\u003A");
            dictionary.Add(";","\u003B");
            dictionary.Add("?","\u003F");
            dictionary.Add("a","\u2364");
            dictionary.Add("akesi","\u2361");
            dictionary.Add("ala","\u2205");
            dictionary.Add("ale","\u25C9");
            dictionary.Add("ali","\u25C9");
            dictionary.Add("anpa","\u2193");
            dictionary.Add("ante","\u238C");
            dictionary.Add("anu","\u2228");
            dictionary.Add("awen","\u2693");
            dictionary.Add("e","\u21B1");
            dictionary.Add("en","\u0026");
            dictionary.Add("ijo","\u269B");
            dictionary.Add("ike","\u2639");
            dictionary.Add("ilo","\u2704");
            dictionary.Add("insa","\u2386");
            dictionary.Add("jaki","\u2623");
            dictionary.Add("jan","\u2D45");
            dictionary.Add("jelo","\u25A5");// ffff00 U+25A0
            dictionary.Add("jo","\u29C8");
            dictionary.Add("kala","\u1619");
            dictionary.Add("kalama","\u266A");
            dictionary.Add("kama","\u29C9");
            dictionary.Add("kasi","\u2698");
            dictionary.Add("ken","\u2713");
            dictionary.Add("kepeken","\u2692");
            dictionary.Add("kili","\u1D25");
            dictionary.Add("kin","\u25C5");
            dictionary.Add("kiwen","\u25CF");
            dictionary.Add("ko","\u25CD");
            dictionary.Add("kon","\u2690");
            dictionary.Add("kule","\u25A7");
            dictionary.Add("kulupu","\u1368");
            dictionary.Add("kute","\u2706");
            dictionary.Add("la","\u228F");
            dictionary.Add("lape","\u2324");
            dictionary.Add("laso","\u25A6");// 00ffff U+25A0
            dictionary.Add("lawa","\u2655");
            dictionary.Add("len","\u265F");
            dictionary.Add("lete","\u2603");
            dictionary.Add("li","\u21B4");
            dictionary.Add("lili","\u25B5");
            dictionary.Add("linja","\u2621");
            dictionary.Add("lipu","\u203F");
            dictionary.Add("loje","\u25A4");// ff0000 U+25A0
            dictionary.Add("lon","\u237E");
            dictionary.Add("luka","\u2308");
            dictionary.Add("lukin","\u2222");
            dictionary.Add("lupa","\u25D8");
            dictionary.Add("ma","\u23DA");
            dictionary.Add("mama","\u261D");
            dictionary.Add("mani","\u00A4");
            dictionary.Add("meli","\u2640");
            dictionary.Add("mi","\u21CA");
            dictionary.Add("mije","\u2642");
            dictionary.Add("moku","\u2615");
            dictionary.Add("moli","\u2620");
            dictionary.Add("monsi","\u21AB");
            dictionary.Add("mu","\u2363");
            dictionary.Add("mun","\u263E");
            dictionary.Add("musi","\u260A");
            dictionary.Add("mute","\u2683");
            dictionary.Add("nanpa","\u22D5");
            dictionary.Add("nasa","\u29BC");
            dictionary.Add("nasin","\u1514");
            dictionary.Add("nena","\u264E");
            dictionary.Add("ni","\u21F2");
            dictionary.Add("nimi","\u229F");
            dictionary.Add("noka","\u230A");
            dictionary.Add("o","\u26A0");
            dictionary.Add("oko","\u2687");
            dictionary.Add("olin","\u2661");
            dictionary.Add("ona","\u21C6");
            dictionary.Add("open","\u237D");
            dictionary.Add("pakala","\u2601");
            dictionary.Add("pali","\u2660");
            dictionary.Add("palisa","\u2215");
            dictionary.Add("pana","\u2709");
            dictionary.Add("pi","\u27C4");
            dictionary.Add("pilin","\u2766");
            dictionary.Add("pimeja","\u25A0");
            dictionary.Add("pini","\u27DF");
            dictionary.Add("pipi","\u2A77");
            dictionary.Add("poka","\u2AD6");
            dictionary.Add("poki","\u26B1");
            dictionary.Add("pona","\u263A");
            dictionary.Add("sama","\u229C");
            dictionary.Add("seli","\u2668");
            dictionary.Add("selo","\u238B");
            dictionary.Add("seme","\u2370");
            dictionary.Add("sewi","\u2191");
            dictionary.Add("sijelo","\u2659");
            dictionary.Add("sike","\u25CB");
            dictionary.Add("sin","\u2672");
            dictionary.Add("sina","\u21C8");
            dictionary.Add("sinpin","\u2338");
            dictionary.Add("sitelen","\u270E");
            dictionary.Add("sona","\u25EC");
            dictionary.Add("soweli","\u12E5");
            dictionary.Add("suli","\u25BD");
            dictionary.Add("suno","\u263C");
            dictionary.Add("supa","\u2013");
            dictionary.Add("suwi","\u2368");
            dictionary.Add("tan","\u21A4");
            dictionary.Add("taso","\u25E6");
            dictionary.Add("tawa","\u21E5");
            dictionary.Add("telo","\u2614");
            dictionary.Add("tenpo","\u231B");
            dictionary.Add("toki","\u1448");
            dictionary.Add("tomo","\u2302");
            dictionary.Add("tu","\u2681");
            dictionary.Add("unpa","\u264B");
            dictionary.Add("uta","\u2365");
            dictionary.Add("utala","\u2694");
            dictionary.Add("walo","\u2610");
            dictionary.Add("wan","\u2680");
            dictionary.Add("waso","\u2362");
            dictionary.Add("wawa","\u21AF");
            dictionary.Add("weka","\u2923");
            dictionary.Add("wile","\u2763");
            dictionary.Add("<<","\u300A");
            dictionary.Add(">>","\u300B");

            return dictionary;
        }

        public static Dictionary<string, string> ReverseDictionary(Dictionary<string, string> toReverse)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> pair in toReverse)
            {
                //We expect some skips due to ali/ale
                if (dictionary.ContainsKey(pair.Value) && pair.Key != "ale" && pair.Key !="ali")
                {
                    throw new InvalidOperationException(pair.Value + ", " + pair.Key + " are already there");
                }

                if (!dictionary.ContainsKey(pair.Value))
                    dictionary.Add(pair.Value, pair.Key);
            }

            return dictionary;
        }

        public static Dictionary<string, string>GetIcelandicRelex()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("a","herna");
            dictionary.Add("akesi","froskur");
            dictionary.Add("ala","ekki");
            dictionary.Add("alasa","veiði");
            dictionary.Add("ale","alla");
            dictionary.Add("ali","allt");
            dictionary.Add("anpa","niður");
            dictionary.Add("ante","öðrum");
            dictionary.Add("anu","eða");
            dictionary.Add("awen","halda");
            dictionary.Add("e","u");
            dictionary.Add("en","og");
            dictionary.Add("esun","verslun");
            dictionary.Add("ijo","hlutur");
            dictionary.Add("ike","slæmt");
            dictionary.Add("ilo","tól");
            dictionary.Add("insa","inni");
            dictionary.Add("jaki","vont");
            dictionary.Add("jan","manna");
            dictionary.Add("jelo","gul");
            dictionary.Add("jo","hef");
            dictionary.Add("kala","fisk");
            dictionary.Add("kalama","hljóð");
            dictionary.Add("kama","koma");
            dictionary.Add("kasi","tre");
            dictionary.Add("ken","get");
            dictionary.Add("kepeken","með");
            dictionary.Add("kipisi","skera");
            dictionary.Add("kili","ávextir");
            dictionary.Add("kin","örugglega");
            dictionary.Add("kiwen","rokk");
            dictionary.Add("ko","muck(?)");
            dictionary.Add("kon","loft");
            dictionary.Add("kule","lit");
            dictionary.Add("kute","eyra");
            dictionary.Add("kulupu","hópur");
            dictionary.Add("la","ef");
            dictionary.Add("lape","sofa");
            dictionary.Add("laso","bláu");
            dictionary.Add("lawa","höfuð");
            dictionary.Add("len","klút");
            dictionary.Add("lete","kalt");
            dictionary.Add("li","er");
            dictionary.Add("lili","litla");
            dictionary.Add("linja","bylgja");
            dictionary.Add("lipu","blað");
            dictionary.Add("loje","rauður");
            dictionary.Add("lon","á");
            dictionary.Add("luka","hönd");
            dictionary.Add("lukin","sjá");
            dictionary.Add("lupa","holu");
            dictionary.Add("ma","landi");
            dictionary.Add("mama","mamma");
            dictionary.Add("mani","peninga");
            dictionary.Add("meli","stelpa");
            dictionary.Add("mi","mig");
            dictionary.Add("mije","maður");
            dictionary.Add("moku","borð");
            dictionary.Add("moli","deyja");
            dictionary.Add("monsi","aftan");
            dictionary.Add("mu","Moo");
            dictionary.Add("mun","tungl");
            dictionary.Add("musi","spila");
            dictionary.Add("mute","margir");
            dictionary.Add("namako","auka");
            dictionary.Add("nanpa","númer");
            dictionary.Add("nasa","brjálað");
            dictionary.Add("nasin","slóð");
            dictionary.Add("nena","högg");
            dictionary.Add("ni","þetta");
            dictionary.Add("nimi","nafn");
            dictionary.Add("noka","fótinn");
            dictionary.Add("o","ó");
            dictionary.Add("oko","auga");
            dictionary.Add("olin","ást");
            dictionary.Add("ona","þeir");
            dictionary.Add("open","opna");
            dictionary.Add("pakala","brot");
            dictionary.Add("pali","vinna");
            dictionary.Add("palisa","stafur");
            dictionary.Add("pan","brauð");
            dictionary.Add("pana","gef");
            dictionary.Add("pata","bróðir");
            dictionary.Add("pi","pá");
            dictionary.Add("pilin","finnst");
            dictionary.Add("pimeja","svart");
            dictionary.Add("pini","lok");
            dictionary.Add("pipi","galla");
            dictionary.Add("poka","með");
            dictionary.Add("poki","kassi");
            dictionary.Add("pona","gott");
            dictionary.Add("sama","sama");
            dictionary.Add("seme","hvað");
            dictionary.Add("seli","heitt");
            dictionary.Add("selo","húð");
            dictionary.Add("sewi","hár");
            dictionary.Add("sike","hring");
            dictionary.Add("sijelo","líkama");
            dictionary.Add("synd","nýtt");
            dictionary.Add("sina","þú");
            dictionary.Add("sinpin","andlit");
            dictionary.Add("sitelen","teikna");
            dictionary.Add("sona","vit");
            dictionary.Add("soweli","dýr");
            dictionary.Add("suli","mikill");
            dictionary.Add("suno","sól");
            dictionary.Add("supa","sófi");
            dictionary.Add("suwi","sætur");
            dictionary.Add("tan","frá");
            dictionary.Add("taso","en");
            dictionary.Add("tawa","fara");
            dictionary.Add("telo","vatn");
            dictionary.Add("tenpo","tíma");
            dictionary.Add("toki","tala");
            dictionary.Add("tomo","herbergi");
            dictionary.Add("tu","tvö");
            dictionary.Add("unpa","ríð");
            dictionary.Add("uta","munni");
            dictionary.Add("utala","berjast");
            dictionary.Add("walo","hvítt");
            dictionary.Add("wan","einn");
            dictionary.Add("waso","fugla");
            dictionary.Add("weka","falla");
            dictionary.Add("wawa","máttur");
            dictionary.Add("wile","vilt");

            return dictionary;
        }

        public static Dictionary<string,string>GetRussianRelex()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("a","ах");
            dictionary.Add("akesi","лягушки");
            dictionary.Add("ala","не");
            dictionary.Add("alasa","охоты");
            dictionary.Add("ale","все");
            dictionary.Add("ali","все");
            dictionary.Add("anpa","вниз");
            dictionary.Add("ante","других");
            dictionary.Add("anu","или");
            dictionary.Add("awen", "держи");
            dictionary.Add("e","а");
            dictionary.Add("en","и");
            dictionary.Add("esun","магазин");
            dictionary.Add("ijo","вещь");
            dictionary.Add("ike","плохо");
            dictionary.Add("ilo","инструмент");
            dictionary.Add("insa","внутри");
            dictionary.Add("jaki", "противен");
            dictionary.Add("jan","человеческого");
            dictionary.Add("jelo","желтый");
            dictionary.Add("jo","есть");
            dictionary.Add("kala","рыбы");
            dictionary.Add("kalama","звука");
            dictionary.Add("kama","приходят");
            dictionary.Add("kasi","трава");
            dictionary.Add("ken","может");
            dictionary.Add("kepeken","с");
            dictionary.Add("kipisi","сократи");
            dictionary.Add("kili","фруктов");
            dictionary.Add("kin", "впрямь");
            dictionary.Add("kiwen","рок");
            dictionary.Add("ko","гадость");
            dictionary.Add("kon","воздуха");
            dictionary.Add("kule","цвета");
            dictionary.Add("kute","уха");
            dictionary.Add("kulupu","группы");
            dictionary.Add("la","если");
            dictionary.Add("lape","сна");
            dictionary.Add("laso","синий");
            dictionary.Add("lawa","голову");
            dictionary.Add("len","ткани");
            dictionary.Add("lete","холодным");
            dictionary.Add("li","ли");
            dictionary.Add("lili","немного");
            dictionary.Add("linja","волны");
            dictionary.Add("lipu","лист");
            dictionary.Add("loje","красный");
            dictionary.Add("lon","на");
            dictionary.Add("luka","стороны");
            dictionary.Add("lukin", "смортри");
            dictionary.Add("luna","отверстие");
            dictionary.Add("ma","землю");
            dictionary.Add("mama","мамой");
            dictionary.Add("mani","деньги");
            dictionary.Add("meli","девушка");
            dictionary.Add("mi","меня");
            dictionary.Add("mije","человек");
            dictionary.Add("moku","есть");
            dictionary.Add("molie","умер");
            dictionary.Add("monsi","задние");
            dictionary.Add("mu","му");
            dictionary.Add("mun","луна");
            dictionary.Add("musi", "игри");
            dictionary.Add("mute","многих");
            dictionary.Add("namako", "лиш");
            dictionary.Add("nanpa","номер");
            dictionary.Add("nasa","сумасшед");
            dictionary.Add("nasin","путь");
            dictionary.Add("nena", "гора");
            dictionary.Add("ni","этом");
            dictionary.Add("nimi","имя");
            dictionary.Add("noka","ногу");
            dictionary.Add("О","О");
            dictionary.Add("oko","глаз");
            dictionary.Add("olin","любви");
            dictionary.Add("ona","они");
            dictionary.Add("open","открытый");
            dictionary.Add("pakala","перерыва");
            dictionary.Add("pali","работы");
            dictionary.Add("palisa","палки");
            dictionary.Add("pan","хлеба");
            dictionary.Add("pana","дать");
            dictionary.Add("pata","брата");
            dictionary.Add("pi", "пы");
            dictionary.Add("pilin","чувствую");
            dictionary.Add("pimeja","черный");
            dictionary.Add("pini","конца");
            dictionary.Add("pipi", "жук");
            dictionary.Add("poka","с");
            dictionary.Add("poki","окне");
            dictionary.Add("pona","хорошее");
            dictionary.Add("sama","же");
            dictionary.Add("seme","что");
            dictionary.Add("seli","горячей");
            dictionary.Add("selo","кожи");
            dictionary.Add("sewi","высокой");
            dictionary.Add("sike","круг");
            dictionary.Add("sijelo","тела");
            dictionary.Add("sin","новых");
            dictionary.Add("sina","вы");
            dictionary.Add("sinpin","лицо");
            dictionary.Add("sitelen","рисования");
            dictionary.Add("sona","знаю");
            dictionary.Add("soweli","зверь");
            dictionary.Add("suli","большой");
            dictionary.Add("suno", "солнца");
            dictionary.Add("supa","диване");
            dictionary.Add("suwi","сладкий");
            dictionary.Add("tan","из");
            dictionary.Add("taso","но");
            dictionary.Add("tawa","идти");
            dictionary.Add("telo","воды");
            dictionary.Add("tenpo","время");
            dictionary.Add("toki","говорят");
            dictionary.Add("tomo","номер");
            dictionary.Add("tu","два");
            dictionary.Add("unpa","ебут");
            dictionary.Add("uta","рот");
            dictionary.Add("utala","борьбе");
            dictionary.Add("walo","белый");
            dictionary.Add("wan","один");
            dictionary.Add("waso","птицы");
            dictionary.Add("weka","падение");
            dictionary.Add("wawa","власти");
            dictionary.Add("wile","хотите");
            return dictionary;
        }

        public static Dictionary<string, string> GetLatinRelex()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("a", "ah");
            dictionary.Add("akesi", "lacerta");
            dictionary.Add("ala", "non");
            dictionary.Add("alasa", "venari");
            dictionary.Add("ale", "omnes");
            dictionary.Add("ali", "omnes");
            dictionary.Add("anpa", "deorsum");
            dictionary.Add("ante", "alia");
            dictionary.Add("anu", "vel");
            dictionary.Add("awen", "custodi");
            dictionary.Add("e", "e");
            dictionary.Add("en", "et");
            dictionary.Add("esun", "copia");
            dictionary.Add("ijo", "res");
            dictionary.Add("ike", "male");
            dictionary.Add("ilo", "instrumentum");
            dictionary.Add("insa", "intra");
            dictionary.Add("jaki", "foeda");
            dictionary.Add("jan", "humana");
            dictionary.Add("jelo", "flava");
            dictionary.Add("jo", "jo"); //??
            dictionary.Add("kala", "pisces");
            dictionary.Add("kalama", "sonus");
            dictionary.Add("kama", "veni");
            dictionary.Add("kasi", "herba");
            dictionary.Add("ken", "possum");
            dictionary.Add("kepeken", "cum");
            dictionary.Add("kipisi", "incide");
            dictionary.Add("kili", "fructus");
            dictionary.Add("kin", "nere");
            dictionary.Add("kiwen", "petra");
            dictionary.Add("ko", "stercus");
            dictionary.Add("kon", "caeli");
            dictionary.Add("kule", "color");
            dictionary.Add("kute", "auris");
            dictionary.Add("kulupu", "classis");
            dictionary.Add("la", "si");
            dictionary.Add("lape", "somno");
            dictionary.Add("laso", "??");//
            dictionary.Add("lawa", "caput");
            dictionary.Add("len", "panni");
            dictionary.Add("lete", "frigida");
            dictionary.Add("li", "est");
            dictionary.Add("lili", "paulo");
            dictionary.Add("linja", "unda");
            dictionary.Add("lipu", "pagina");
            dictionary.Add("loje", "ruber");
            dictionary.Add("lon", "in");
            dictionary.Add("luka", "manu");
            dictionary.Add("lukin", "video");
            dictionary.Add("lupa", "foramen");
            dictionary.Add("ma", "terra");
            dictionary.Add("mama", "mater");
            dictionary.Add("mani", "pecuniam");
            dictionary.Add("meli", "puella");
            dictionary.Add("mi", "mi");
            dictionary.Add("mije", "vir");
            dictionary.Add("moku", "manducare");
            dictionary.Add("moli", "mori");
            dictionary.Add("monsi", "tergo");
            dictionary.Add("mu", "emugio");
            dictionary.Add("mun", "luna");
            dictionary.Add("musi", "ludicrum");
            dictionary.Add("mute", "multa");
            dictionary.Add("namako", "supplementum");
            dictionary.Add("nanpa", "numero");
            dictionary.Add("nasa", "delirus");
            dictionary.Add("nasin", "iter");
            dictionary.Add("nena", "gibba");
            dictionary.Add("ni", "hoc");
            dictionary.Add("nimi", "nomen");
            dictionary.Add("noka", "tibia");
            dictionary.Add("o", "o");
            dictionary.Add("oko", "oculus");
            dictionary.Add("olin", "amor");
            dictionary.Add("ona", "eam");
            dictionary.Add("open", "aperta");
            dictionary.Add("pakala", "frangere");
            dictionary.Add("pali", "opere");
            dictionary.Add("palisa", "lignum");
            dictionary.Add("pan", "panem");
            dictionary.Add("pana", "??");
            dictionary.Add("pata", "frater");
            dictionary.Add("pi", "de");
            dictionary.Add("pilin", "sentio");
            dictionary.Add("pimeja", "nigrum");
            dictionary.Add("pini", "finem");
            dictionary.Add("pipi", "bestiola");
            dictionary.Add("poka", "cum");
            dictionary.Add("poki", "cisti");
            dictionary.Add("pona", "bona");
            dictionary.Add("sama", "idem");
            dictionary.Add("seme", "quod");
            dictionary.Add("seli", "calidus");
            dictionary.Add("selo", "cute");
            dictionary.Add("sewi", "alta");
            dictionary.Add("sike", "circuli");
            dictionary.Add("sijelo", "cropus");
            dictionary.Add("sin", "nova");
            dictionary.Add("sina", "te");
            dictionary.Add("sinpin", "faciem");
            dictionary.Add("sitelen", "tractus");
            dictionary.Add("sona", "scio");
            dictionary.Add("soweli", "bestia");
            dictionary.Add("suli", "magna");
            dictionary.Add("suno", "sol");
            dictionary.Add("supa", "lectus");
            dictionary.Add("suwi", "dulce");
            dictionary.Add("tan", "quia");
            dictionary.Add("taso", "sed");
            dictionary.Add("tawa", "ire");
            dictionary.Add("telo", "aquas");
            dictionary.Add("tenpo", "tempus");
            dictionary.Add("toki", "loqui");
            dictionary.Add("tomo", "locus");
            dictionary.Add("tu", "duo");
            dictionary.Add("unpa", "futuo");
            dictionary.Add("uta", "ore");
            dictionary.Add("utala", "pugna");
            dictionary.Add("walo", "album");
            dictionary.Add("wan", "unum");
            dictionary.Add("waso", "avis");
            dictionary.Add("weka", "gutta");
            dictionary.Add("wawa", "virtus");
            dictionary.Add("wile", "volo");
            return dictionary;
        }

        public static Dictionary<string,string> GetEnglishRelex()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("a","ah");
            dictionary.Add("akesi","frog");
            dictionary.Add("ala","not");
            dictionary.Add("alasa","hunt");
            dictionary.Add("ale","all");
            dictionary.Add("ali","all");
            dictionary.Add("anpa","down");
            dictionary.Add("ante","other");
            dictionary.Add("anu","or");
            dictionary.Add("awen","keep");
            dictionary.Add("e","eh");
            dictionary.Add("en","and");
            dictionary.Add("esun","store");
            dictionary.Add("ijo","thing");
            dictionary.Add("ike","bad");
            dictionary.Add("ilo","tool");
            dictionary.Add("insa","inside");
            dictionary.Add("jaki","yucky");
            dictionary.Add("jan","human");
            dictionary.Add("jelo","yellow");
            dictionary.Add("jo","have");
            dictionary.Add("kala","fish");
            dictionary.Add("kalama","sound");
            dictionary.Add("kama","come");
            dictionary.Add("kasi","plant");
            dictionary.Add("ken","can");
            dictionary.Add("kepeken","with");
            dictionary.Add("kipisi","cut");
            dictionary.Add("kili","fruit");
            dictionary.Add("kin","indeed");
            dictionary.Add("kiwen","rock");
            dictionary.Add("ko","muck");
            dictionary.Add("kon","air");
            dictionary.Add("kule","color");
            dictionary.Add("kute","ear");
            dictionary.Add("kulupu","group");
            dictionary.Add("la","if");
            dictionary.Add("lape","sleep");
            dictionary.Add("laso","blue");
            dictionary.Add("lawa","head");
            dictionary.Add("len","cloth");
            dictionary.Add("lete","cold");
            dictionary.Add("li","is");
            dictionary.Add("lili","little");
            dictionary.Add("linja","wave");
            dictionary.Add("lipu","sheet");
            dictionary.Add("loje","red");
            dictionary.Add("lon","at");
            dictionary.Add("luka","hand");
            dictionary.Add("lukin","see");
            dictionary.Add("lupa","hole");
            dictionary.Add("ma","land");
            dictionary.Add("mama","mom");
            dictionary.Add("mani","money");
            dictionary.Add("meli","girl");
            dictionary.Add("mi","me");
            dictionary.Add("mije","man");
            dictionary.Add("moku","eat");
            dictionary.Add("moli","die");
            dictionary.Add("monsi","rear");
            dictionary.Add("mu","moo");
            dictionary.Add("mun","moon");
            dictionary.Add("musi","play");
            dictionary.Add("mute","many");
            dictionary.Add("namako","extra");
            dictionary.Add("nanpa","number");
            dictionary.Add("nasa","crazy");
            dictionary.Add("nasin","path");
            dictionary.Add("nena","bump");
            dictionary.Add("ni","this");
            dictionary.Add("nimi","name");
            dictionary.Add("noka","leg");
            dictionary.Add("o","oh");
            dictionary.Add("oko","eye");
            dictionary.Add("olin","love");
            dictionary.Add("ona","they");
            dictionary.Add("open","open");
            dictionary.Add("pakala","break");
            dictionary.Add("pali","work");
            dictionary.Add("palisa","stick");
            dictionary.Add("pan","bread");
            dictionary.Add("pana","give");
            dictionary.Add("pata","brother");
            dictionary.Add("pi","of");
            dictionary.Add("pilin","feel");
            dictionary.Add("pimeja","black");
            dictionary.Add("pini","end");
            dictionary.Add("pipi","bug");
            dictionary.Add("poka", "with");
            dictionary.Add("poki", "box");
            dictionary.Add("pona","good");
            dictionary.Add("sama","same");
            dictionary.Add("seme","what");
            dictionary.Add("seli","hot");
            dictionary.Add("selo","skin");
            dictionary.Add("sewi","high");
            dictionary.Add("sike","circle");
            dictionary.Add("sijelo","body");
            dictionary.Add("sin","new");
            dictionary.Add("sina","you");
            dictionary.Add("sinpin","face");
            dictionary.Add("sitelen","drawing");
            dictionary.Add("sona","know");
            dictionary.Add("soweli","beast");
            dictionary.Add("suli","great");
            dictionary.Add("suno","sun");
            dictionary.Add("supa","couch");
            dictionary.Add("suwi","sweet");
            dictionary.Add("tan","from");
            dictionary.Add("taso","but");
            dictionary.Add("tawa","go");
            dictionary.Add("telo","water");
            dictionary.Add("tenpo","time");
            dictionary.Add("toki","speak");
            dictionary.Add("tomo","room");
            dictionary.Add("tu","two");
            dictionary.Add("unpa","fuck");
            dictionary.Add("uta","mouth");
            dictionary.Add("utala","fight");
            dictionary.Add("walo","white");
            dictionary.Add("wan","one");
            dictionary.Add("waso","bird");
            dictionary.Add("weka","drop");
            dictionary.Add("wawa","power");
            dictionary.Add("wile","want");
            return dictionary;
        }

        public static Dictionary<string, string> GetHeiroglyphDictionary()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            //top first (col, row)
            Dictionary<string, string> anyDictionary = GetDictionary();

            foreach(var item in anyDictionary)
            {
                dictionary.Add(item.Key,
                               string.Format("<img src=\"img/t47_nimi_{0}.jpg\"/>", item.Key));
                 
            }

            return dictionary;
        }


        public static Dictionary<string, string> GetDictionary()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            //top first (col, row)
            dictionary.Add("ala", "aa");
            dictionary.Add("kalama", "ka");
            dictionary.Add("lape", "la");
            dictionary.Add("ma", "ma");
            dictionary.Add("poka", "oa");
            dictionary.Add("pali", "pa");
            dictionary.Add("sina", "sa");
            dictionary.Add("tan", "ta");

            dictionary.Add("ken", "ke");
            dictionary.Add("len", "le");
            dictionary.Add("nena", "ne");
            dictionary.Add("selo", "se");

            dictionary.Add("kin", "ki");
            dictionary.Add("lipu", "li");
            dictionary.Add("mi", "mi");
            dictionary.Add("ni", "ni");
            dictionary.Add("poki", "oi");
            dictionary.Add("pini", "pi");
            dictionary.Add("sin", "si");
            dictionary.Add("wile", "wi");

            dictionary.Add("ijo", "ij");
            dictionary.Add("kili", "kj");
            dictionary.Add("linja", "lj");
            dictionary.Add("mije", "mj");
            dictionary.Add("pimeja", "pj");
            dictionary.Add("sijelo", "sj");

            dictionary.Add("akesi", "ak");
            dictionary.Add("ike", "ik");
            dictionary.Add("jaki", "jk");
            dictionary.Add("kepeken", "kk");
            dictionary.Add("luka", "lk");
            dictionary.Add("moku", "mk");
            dictionary.Add("namako", "nk");
            dictionary.Add("pakala", "pk");
            dictionary.Add("sike", "sk");
            dictionary.Add("toki", "tk");
            dictionary.Add("weka", "wk");

            dictionary.Add("ale", "al");
            dictionary.Add("jelo", "jl");
            dictionary.Add("kala", "kl");
            dictionary.Add("lili", "ll");
            dictionary.Add("meli", "ml");
            dictionary.Add("olin", "ol");
            dictionary.Add("pilin", "pl");
            dictionary.Add("seli", "sl");
            dictionary.Add("telo", "tl");
            dictionary.Add("utala", "ul");
            dictionary.Add("walo", "wl");

            dictionary.Add("seme", "em");
            dictionary.Add("kama", "km");
            dictionary.Add("mama", "mm");
            dictionary.Add("nimi", "nm");
            dictionary.Add("pan", "pm");
            dictionary.Add("sama", "sm");
            dictionary.Add("tomo", "tm");

            dictionary.Add("en", "en");
            dictionary.Add("jan", "jn");
            dictionary.Add("kon", "kn");
            dictionary.Add("lon", "ln");
            dictionary.Add("mani", "mn");
            dictionary.Add("nasin", "nn");
            dictionary.Add("ona", "on");
            dictionary.Add("pana", "pn");
            dictionary.Add("suno", "sn");
            dictionary.Add("tenpo", "tn");
            dictionary.Add("unpa", "un");
            dictionary.Add("wan", "wn");

            dictionary.Add("ilo", "io");
            dictionary.Add("jo", "jo");
            dictionary.Add("ko", "ko");
            dictionary.Add("loje", "lo");
            dictionary.Add("moli", "mo");
            dictionary.Add("noka", "no");
            dictionary.Add("oko", "oo");
            dictionary.Add("pona", "po");
            dictionary.Add("sona", "so");

            dictionary.Add("anpa", "ap");
            dictionary.Add("kipisi", "ip");
            dictionary.Add("kulupu", "kp");
            dictionary.Add("lupa", "lp");
            dictionary.Add("nanpa", "np");
            dictionary.Add("open", "op");
            dictionary.Add("pipi", "pp");
            dictionary.Add("sinpin", "sp");
            dictionary.Add("supa", "up");

            dictionary.Add("alasa", "as");
            dictionary.Add("esun", "es");
            dictionary.Add("insa", "is");
            dictionary.Add("kasi", "ks");
            dictionary.Add("laso", "ls");
            dictionary.Add("monsi", "ms");
            dictionary.Add("nasa", "ns");
            dictionary.Add("palisa", "ps");
            dictionary.Add("taso", "ts");
            dictionary.Add("musi", "us");
            dictionary.Add("waso", "ws");

            dictionary.Add("ante", "at");
            dictionary.Add("kute", "kt");
            dictionary.Add("lete", "lt");
            dictionary.Add("mute", "mt");
            dictionary.Add("sitelen", "st");
            dictionary.Add("uta", "ut");

            dictionary.Add("anu", "au");
            dictionary.Add("kule", "ku");
            dictionary.Add("lukin", "lu");
            dictionary.Add("mun", "mu");
            dictionary.Add("pu", "pu");
            dictionary.Add("suli", "su");
            dictionary.Add("tu", "tu");

            dictionary.Add("awen", "aw");
            dictionary.Add("kiwen", "kw");
            dictionary.Add("lawa", "lw");
            dictionary.Add("soweli", "ow");
            dictionary.Add("sewi", "sw");
            dictionary.Add("tawa", "tw");
            dictionary.Add("suwi", "uw");
            dictionary.Add("wawa", "ww");

            dictionary.Add("la", "^");
            dictionary.Add("li", "*");
            dictionary.Add("o", "!");
            dictionary.Add("e", "~");
            dictionary.Add("pi", "@");

            return dictionary;
        }


        public static Dictionary<string, string> GetJapaneseDictionary()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            //top first (col, row)

            AddBackwards(dictionary, "あ", "a");
            AddBackwards(dictionary, "獣", "akesi");
            AddBackwards(dictionary, "無", "ala");
            AddBackwards(dictionary, "探", "alasa");
            AddBackwards(dictionary, "全", "ali");
            AddBackwards(dictionary, "下", "anpa");
            AddBackwards(dictionary, "变", "ante");
            AddBackwards(dictionary, "ぬ", "anu");
            AddBackwards(dictionary, "待", "awen");
            AddBackwards(dictionary, "え", "e");
            AddBackwards(dictionary, "ん", "en");
            AddBackwards(dictionary, "市", "esun");
            AddBackwards(dictionary, "物", "ijo");
            AddBackwards(dictionary, "悪", "ike");
            AddBackwards(dictionary, "具", "ilo");
            AddBackwards(dictionary, "内", "insa");
            AddBackwards(dictionary, "汚", "jaki");
            AddBackwards(dictionary, "人", "jan");
            AddBackwards(dictionary, "黄", "jelo");
            AddBackwards(dictionary, "有", "jo");
            AddBackwards(dictionary, "魚", "kala");
            AddBackwards(dictionary, "音", "kalama");
            AddBackwards(dictionary, "来", "kama");
            AddBackwards(dictionary, "木", "kasi");
            AddBackwards(dictionary, "能", "ken");
            AddBackwards(dictionary, "使", "kepeken");
            AddBackwards(dictionary, "果", "kili");
            AddBackwards(dictionary, "又", "kin");
            AddBackwards(dictionary, "切", "kipisi");
            AddBackwards(dictionary, "石", "kiwen");
            AddBackwards(dictionary, "粉", "ko");
            AddBackwards(dictionary, "空", "kon");
            AddBackwards(dictionary, "色", "kule");
            AddBackwards(dictionary, "聞", "kute");
            AddBackwards(dictionary, "群", "kulupu");
            AddBackwards(dictionary, "ら", "la");
            AddBackwards(dictionary, "眠", "lape");
            AddBackwards(dictionary, "青", "laso");
            AddBackwards(dictionary, "首", "lawa");
            AddBackwards(dictionary, "布", "len");
            AddBackwards(dictionary, "冷", "lete");
            AddBackwards(dictionary, "り", "li");
            AddBackwards(dictionary, "小", "lili");
            AddBackwards(dictionary, "糸", "linja");
            AddBackwards(dictionary, "葉", "lipu");
            AddBackwards(dictionary, "赤", "loje");
            AddBackwards(dictionary, "在", "lon");
            AddBackwards(dictionary, "手", "luka");
            AddBackwards(dictionary, "見", "lukin");
            AddBackwards(dictionary, "穴", "lupa");
            AddBackwards(dictionary, "土", "ma");
            AddBackwards(dictionary, "母", "mama");
            AddBackwards(dictionary, "貝", "mani");
            AddBackwards(dictionary, "女", "meli");
            AddBackwards(dictionary, "私", "mi");
            AddBackwards(dictionary, "男", "mije");
            AddBackwards(dictionary, "食", "moku");
            AddBackwards(dictionary, "死", "moli");
            AddBackwards(dictionary, "後", "monsi");
            AddBackwards(dictionary, "む", "mu");
            AddBackwards(dictionary, "月", "mun");
            AddBackwards(dictionary, "楽", "musi");
            AddBackwards(dictionary, "多", "mute");
            AddBackwards(dictionary, "冗", "namako");
            AddBackwards(dictionary, "番", "nanpa");
            AddBackwards(dictionary, "狂", "nasa");
            AddBackwards(dictionary, "道", "nasin");
            AddBackwards(dictionary, "丘", "nena");
            AddBackwards(dictionary, "此", "ni");
            AddBackwards(dictionary, "称", "nimi");
            AddBackwards(dictionary, "足", "noka");
            AddBackwards(dictionary, "お", "o");
            AddBackwards(dictionary, "目", "oko");
            AddBackwards(dictionary, "愛", "olin");
            AddBackwards(dictionary, "彼", "ona");
            AddBackwards(dictionary, "開", "open");
            AddBackwards(dictionary, "打", "pakala");
            AddBackwards(dictionary, "作", "pali");
            AddBackwards(dictionary, "棒", "palisa");
            AddBackwards(dictionary, "米", "pan");
            AddBackwards(dictionary, "授", "pana");
            AddBackwards(dictionary, "氏", "pata");
            AddBackwards(dictionary, "ぴ", "pi");
            AddBackwards(dictionary, "心", "pilin");
            AddBackwards(dictionary, "黒", "pimeja");
            AddBackwards(dictionary, "終", "pini");
            AddBackwards(dictionary, "虫", "pipi");
            AddBackwards(dictionary, "側", "poka");
            AddBackwards(dictionary, "箱", "poki");
            AddBackwards(dictionary, "良", "pona");
            AddBackwards(dictionary, "同", "sama");
            AddBackwards(dictionary, "何", "seme");
            AddBackwards(dictionary, "火", "seli");
            AddBackwards(dictionary, "皮", "selo");
            AddBackwards(dictionary, "上", "sewi");
            AddBackwards(dictionary, "丸", "sike");
            AddBackwards(dictionary, "体", "sijelo");
            AddBackwards(dictionary, "新", "sin");
            AddBackwards(dictionary, "君", "sina");
            AddBackwards(dictionary, "前", "sinpin");
            AddBackwards(dictionary, "画", "sitelen");
            AddBackwards(dictionary, "知", "sona");
            AddBackwards(dictionary, "猫", "soweli");
            AddBackwards(dictionary, "大", "suli");
            AddBackwards(dictionary, "日", "suno");
            AddBackwards(dictionary, "面", "supa");
            AddBackwards(dictionary, "甜", "suwi");
            AddBackwards(dictionary, "因", "tan");
            AddBackwards(dictionary, "許", "taso");
            AddBackwards(dictionary, "去", "tawa");
            AddBackwards(dictionary, "水", "telo");
            AddBackwards(dictionary, "时", "tenpo");
            AddBackwards(dictionary, "言", "toki");
            AddBackwards(dictionary, "家", "tomo");
            AddBackwards(dictionary, "二", "tu");
            AddBackwards(dictionary, "盛", "unpa");
            AddBackwards(dictionary, "口", "uta");
            AddBackwards(dictionary, "戦", "utala");
            AddBackwards(dictionary, "白", "walo");
            AddBackwards(dictionary, "一", "wan");
            AddBackwards(dictionary, "鳥", "waso");
            AddBackwards(dictionary, "遥", "weka");
            AddBackwards(dictionary, "力", "wawa");
            AddBackwards(dictionary, "要", "wile");

            return dictionary;
        }

        public static Dictionary<string, string> GetChinese()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            dictionary.Add("a", "啊");
            dictionary.Add("akesi", "龟");//[gui1] 
            dictionary.Add("ala", "不");//[bu2] 
            dictionary.Add("ale", "全"); //[quan2]
            dictionary.Add("ali", "全");//[quan2] 
            dictionary.Add("anpa", "下"); //[xia4]
            dictionary.Add("ante", "变");//[bian4] 
            dictionary.Add("anu", "或");//[huo4] 
            dictionary.Add("awen", "守");//[shou3] 
            dictionary.Add("e", "把");//[ba3]<particle used before a noun to show it’s the DO>
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
            dictionary.Add("wile", "要"); //[yao4] 
            return dictionary;
        }

        public static void AddBackwards(Dictionary<string, string> dictionary, string key, string value)
        {
            dictionary.Add(value, key);
        }

    }
}
