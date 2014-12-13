using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BasicTypes.Diagnostics;
using BasicTypes.Exceptions;
using BasicTypes.Extensions;

namespace BasicTypes.NormalizerCode
{
    
    //Fix 1 issue per method.
    public static class NormalizationTasks
    {

        public static string MarkImplicitPrepositions(string original, string normalized)
        {
            string[] preps = Particles.Prepositions;
            bool isPunctuated = false;
            foreach (string prep in preps)
            {
                if (normalized.ContainsCheck(prep))
                {
                    isPunctuated = normalized.ContainsCheck(", " + prep) || normalized.ContainsCheck("," + prep);
                    normalized = Regex.Replace(normalized, "," + prep, " ~" + prep);
                    normalized = Regex.Replace(normalized, ", " + prep, " ~" + prep);

                    if (normalized.ContainsCheck("~ ~"))
                    {
                        throw new InvalidOperationException(original);
                    }
                }
            }
            if (!isPunctuated && !normalized.ContainsCheck("~"))
            {
                foreach (string prep in preps)
                {
                    if (normalized.ContainsCheck(prep))
                    {
                        //HACK:Naive repair-- doesn't deal with unusal white space patterns.
                        normalized = Regex.Replace(normalized, " " + prep, " ~" + prep);
                    }
                }
            }
            return normalized;
        }

        public static string RemoveInternalWhiteSpace(string normalized)
        {
            while (normalized.ContainsCheck("  "))
            {
                normalized = normalized.Replace("  ", " ");
            }
            return normalized;
        }



        public static string TimeWhiteSpaceAndSpaceBeforeSentenceTerminators(string text)
        {
            
            string normalized = text.Trim(new[] { '\n', '\r', ' ' });

            if (normalized.ContainsCheck(" ."))
            {
                normalized = normalized.Replace(" .", ".");
            }
            if (normalized.ContainsCheck(" ?"))
            {
                normalized = normalized.Replace(" ?", "?");
            }
            if (normalized.ContainsCheck(" !"))
            {
                normalized = normalized.Replace(" !", "!");
            }

            while (normalized.ContainsCheck("??"))
            {
                normalized = normalized.Replace("??", "?");
            }
            while (normalized.ContainsCheck("!!"))
            {
                normalized = normalized.Replace("!!", "!");
            }
            return normalized;
        }

        public static string StripMultilineComments(string arg)
        {
            //https://stackoverflow.com/questions/13014947/regex-to-match-a-c-style-multiline-comment
            return Regex.Replace(arg, "/\\*.*?\\*/", "");
        }



        /// <summary>
        /// So far I've never needed a , to parse (other than explicit preps) . They do get in the way though.
        /// </summary>
        public static string ProcessExtraneousCommas(string normalized)
        {
            foreach (string s in new[] { ", li ", ", la ", ",la ", " la, ", " la,", ", o ", ",o ", " o, ", "taso, ", "anu, " })
            {
                if (normalized.ContainsCheck(s))
                {
                    
                    normalized = normalized.Replace(s, " " + s.Trim(new[] { ' ', ',' }) + " ");
                }
            }
            return normalized;
        }

        public static string ApplyNormalization(string normalized, string what, Func<string, Dialect, string> normalization, Dialect dialect)
        {
            string copy = string.Copy(normalized);
            normalized = normalization.Invoke(normalized, dialect);
            if (copy != normalized)
            {
                Tracers.Normalize.TraceInformation(what + "1:" + copy);
                Tracers.Normalize.TraceInformation(what + "2:" + normalized);
            }
            return normalized;
        }

        public static string ApplyNormalization(string normalized, string what, Func<string, string> normalization)
        {
            string copy = string.Copy(normalized);
            normalized = normalization.Invoke(normalized);
            if (copy != normalized)
            {
                Tracers.Normalize.TraceInformation(what + "1:" + copy);
                Tracers.Normalize.TraceInformation(what + "2:" + normalized);
            }
            return normalized;
        }



        public static string ProcessExtraneousWhiteSpace(string normalized)
        {
            //Line breaks & other white spaces make it harder to find boundaries
            //jan li
            //tawa. ==> jan li tawa.
            normalized = normalized.Replace("\n", " ");


            //Extraneous whitespace
            while (normalized.ContainsCheck("  "))
            {
                normalized = normalized.Replace("  ", " ");
            }
            return normalized;
        }

        public static string AddDirectedQuotes(string normalized)
        {
            //return normalized;
            StringBuilder sb = new StringBuilder();
            bool open = true;
            foreach (char c in normalized)
            {
                if (c == '\'')
                {
                    if (open)
                    {
                        sb.Append("«");
                    }
                    else
                    {
                        sb.Append("»");
                    }
                    open = !open;
                }
                else
                {
                    sb.Append(c);
                }
            }
            normalized = sb.ToString();
            return normalized;
        }

        public static string UseDummyPredicateForObviousFragments(string normalized, string fakePredicate)
        {
            if (!(normalized.ContainsCheck(" li ")) && !IsVocative(normalized) && !IsExclamatory(normalized) &&
                !IsFragment(normalized))
            {
                //Add a marker that we can later remove. Allows for parsing NPs, like titles, as if
                //they were sentences.
                if (normalized.EndCheck("."))
                {
                    normalized = normalized.Substring(0, normalized.Length - 1) + fakePredicate;
                }
                else
                {
                    normalized = normalized + fakePredicate;
                }
            }
            return normalized;
        }

        public static bool IsNullWhiteOrPunctuation(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return true;


            foreach (char c in value)
            {
                if (!"!.', !@#$%^&*())_[]|~`<>?:\n '»".ContainsCheck(c))
                {
                    return false;
                }
            }
            return true;
        }


        public static string ProcessWhiteSpaceInForeignText(string normalized, Dialect dialect)
        {

            StringBuilder sb = new StringBuilder(normalized.Length);
            bool insideForeignText = false;
            StringBuilder possiblyJustTp = new StringBuilder(normalized.Length);
            foreach (char c in normalized)
            {
                if (c == '"')
                {
                    insideForeignText = !insideForeignText;
                }
                if (insideForeignText && c == ' ')
                {
                    sb.Append('*');
                }
                else
                {
                    sb.Append(c);
                }

                if (insideForeignText)
                {
                    possiblyJustTp.Append(c);
                }
            }

            if (insideForeignText)
            {
                sb.Append('"');
            }

            //Two scenarios
            //"toki li pona" li "ni li sina". Embedded text. 
            //mi toki e ni: "ale li pona". Used doulbe quotes instead of single.
            //if (dialect.InferCompoundsPrepositionsForeignText)
            //{
            //    if (NormalizeChaos.PercentTokiPona(possiblyJustTp.ToString()) > 0.90m)
            //    {
            //        return normalized.Replace("\"", "'");
            //    }
            //}

            return sb.ToString();
        }

        private static string[]  oneOffPhrases = new string[] {
                                                        " li ~tawa wawa e", // motion thingy.  Maybe catch with common adverbs?
                                                        " li ~lon wawa e ",// placement thingy. Quickly place something.
                                                        "tenpo ~tawa ali la", //This is just strange.
                                                        "kon ~tawa seli li",// tawa is normal adjective. 
                                                         "kon ~tawa lete li",// tawa is normal adjective. 
                                                         "kon ~tawa telo li",// tawa is normal adjective. 
                                                         "tenpo ~tawa mi", //Time of my leaving
                                                         "li ~tawa anpa ", //Go down.
                                                         "li ~tawa kon ", //fly
                                                         "li ~tawa sewi ", //go up
                                                         "nasin ~sama ala la",//as for different ways... 
                                                         "li ~sama lili e ",//to copy somewhat
                                                         "kon en ~lon en moli", //existence vs in
                                                         "li ~tawa suli e", //move something
                                                         "mi ~lon poka e", //place something next to
                                                         "li ~lon poka e", //place something next to
                                                         "li ~kepeken sin e", //use again
                                                         "li ~tawa jo wawa e", //I don't even know what this means
                                                         "tenpo pi mi ~lon sike", //my life (span)
                                                         "o ~tawa kon e", // moving stuff around.
                                                         "li ~kepeken selo pi len kule ala" //transformative
                                                    };
        public static string ThoseArentPrepositions(string normalized)
        {
            string[] preps = Particles.Prepositions;
            //I don't even know what that means.
            //This is just so corpus texts can pass. Better solution is to write annoted text in the first place.
            foreach (string oneOff in oneOffPhrases)
            {
                normalized = normalized.Replace(oneOff, oneOff.Replace("~", ""));
            }

            //As in jan sama o!
            //jan ~sama o!
            if (normalized.ContainsCheck(" ~sama o "))
            {
                normalized = normalized.Replace(" ~sama o ", " sama o ");
            }
            if (normalized.ContainsCheck(" ~sama o, "))
            {
                normalized = normalized.Replace(" ~sama o, ", " sama o, ");
            }
            if (normalized.EndCheck(" ~sama o"))
            {
                normalized = normalized.Replace(" ~sama o", " sama o");
            }
            if (normalized.EndCheck(" ~sama o!"))
            {
                normalized = normalized.Replace(" ~sama o!", " sama o!");
            }
            if (normalized.EndCheck(" ~sama o?"))
            {
                normalized = normalized.Replace(" ~sama o?", " sama o?");
            }
            if (normalized.EndCheck(" ~sama o."))
            {
                normalized = normalized.Replace(" ~sama o.", " sama o.");
            }
            //li kama tawa ==> verb!


            //li ~kepeken e
            foreach (string prep in preps)
            {
                string barePrep = " li ~" + prep + " e ";
                if (normalized.ContainsCheck(barePrep))
                {
                    normalized = normalized.Replace(barePrep, barePrep.Replace("~", ""));
                }
            }


            //la ~lon 
            foreach (string prep in preps)
            {
                string leadPrep = " la ~" + prep + " ";
                if (normalized.ContainsCheck(leadPrep))
                {
                    normalized = normalized.Replace(leadPrep, leadPrep.Replace("~", ""));
                }
            }


            //li ~tawa ala e
            foreach (string prep in preps)
            {
                string barePrep = " li ~" + prep + " ala e ";
                if (normalized.ContainsCheck(barePrep))
                {
                    normalized = normalized.Replace(barePrep, barePrep.Replace("~", ""));
                }
            }
            //o ~kepeken ala e
            foreach (string prep in preps)
            {
                string barePrep = " o ~" + prep + " ala e ";
                if (normalized.ContainsCheck(barePrep))
                {
                    normalized = normalized.Replace(barePrep, barePrep.Replace("~", ""));
                }
            }
            //~tawa e
            foreach (string prep in preps)
            {
                string barePrep = " ~" + prep + " e ";
                if (normalized.ContainsCheck(barePrep))
                {
                    normalized = normalized.Replace(barePrep, barePrep.Replace("~", ""));
                }
            }
            //li ken ~tawa sike e 
            foreach (string prep in preps)
            {
                //TODO: Add other modals.
                //modal + prep => probably verb.
                string barePrep = " li ken ~" + prep;
                if (normalized.ContainsCheck(barePrep))
                {
                    normalized = normalized.Replace(barePrep, barePrep.Replace("~", ""));
                }
            }

            //~tan-  it's a prep but inside a compound phrase, we don't care. It's opaque.
            foreach (string prep in preps)
            {
                string barePrep = "~" + prep + "-";
                if (normalized.ContainsCheck(barePrep))
                {
                    normalized = normalized.Replace(barePrep, barePrep.Replace("~", ""));
                }
            }

            //~tawa pi --- not possible.
            foreach (string prep in preps)
            {
                string barePrep = "~" + prep + " pi ";
                if (normalized.ContainsCheck(barePrep))
                {
                    normalized = normalized.Replace(barePrep, barePrep.Replace("~", ""));
                }
            }

            //lon ala li pana e lon
            foreach (string prep in preps)
            {
                string initial = "~" + prep + " ";
                if (normalized.StartCheck(initial))
                {
                    normalized = prep + " " + normalized.Substring((prep + " ").Length);
                    //normalized = normalized.Replace(initial, initial.Replace("~", ""));
                }
            }

            //This is so uncommon, that it actually better to assume it isn't a prep.
            foreach (string prep in preps)
            {
                string piHeadedPrep = " pi ~" + prep + " ";
                if (normalized.ContainsCheck(piHeadedPrep))
                {
                    normalized = normalized.Replace(piHeadedPrep, piHeadedPrep.Replace("~", ""));
                }
            }


            //.. li sama.
            foreach (string prep in preps)
            {
                foreach (char c in ":!?.")
                {
                    string terminalPrep = "~" + prep + c;
                    if (normalized.ContainsCheck(terminalPrep))
                    {
                        normalized = normalized.Replace(terminalPrep, prep + c);
                    }
                }
            }

            //variation on terminal prep
            //lon lawa sama o tawa...
            foreach (string prep in preps)
            {
                foreach (var predicateSplitter in new string[] { " o ", " li " })
                {
                    string terminalPrep = "~" + prep + predicateSplitter;
                    if (normalized.ContainsCheck(terminalPrep))
                    {
                        normalized = normalized.Replace(terminalPrep, prep + predicateSplitter);
                    }
                }
            }


            //la terminates
            foreach (string prep in preps)
            {
                foreach (var predicateSplitter in new string[] { " la " })
                {
                    string terminalPrep = "~" + prep + predicateSplitter;
                    if (normalized.ContainsCheck(terminalPrep))
                    {
                        normalized = normalized.Replace(terminalPrep, prep + predicateSplitter);
                    }
                }
            }

            //And again with commas
            foreach (string prep in preps)
            {
                foreach (var predicateSplitter in new string[] { ", o ", ", li " })
                {
                    string terminalPrep = "~" + prep + predicateSplitter;
                    if (normalized.ContainsCheck(terminalPrep))
                    {
                        normalized = normalized.Replace(terminalPrep, prep + predicateSplitter);
                    }
                }
            }

            foreach (string prep in preps)
            {
                foreach (var conjunction in new string[] { "anu ", "taso " })
                {
                    string initialPrep = conjunction + "~" + prep;
                    if (normalized.StartCheck(initialPrep))
                    {
                        normalized = normalized.Replace(initialPrep, initialPrep.Replace("~", ""));
                    }
                }
            }

            foreach (string prep in preps)
            {
                string terminalPrep = "~" + prep;
                if (normalized.EndCheck(terminalPrep))
                {
                    normalized = normalized.Remove(normalized.LastIndexOf(terminalPrep), 1);
                }
            }

            //e ~sama
            foreach (string prep in preps)
            {
                //e
                foreach (char c in "e")
                {
                    string terminalPrep = " " + c + " ~" + prep;
                    if (normalized.ContainsCheck(terminalPrep))
                    {
                        normalized = normalized.Replace(terminalPrep, " e " + prep);
                    }
                }
            }

            //~tawa pi jan Puta li pona

            //lon poka ma ni.
            foreach (string prep1 in preps)
            {
                foreach (string prep2 in preps)
                {
                    string doublePrep = "~" + prep1 + " " + "~" + prep2;
                    if (normalized.ContainsCheck(doublePrep))
                    {
                        normalized = normalized.Replace(doublePrep, "~" + prep1 + " " + prep2);
                    }
                    doublePrep = "~" + prep2 + " " + "~" + prep1;
                    if (normalized.ContainsCheck(doublePrep))
                    {
                        normalized = normalized.Replace(doublePrep, "~" + prep2 + " " + prep1);
                    }
                }
            }


            //This could go many directions.  
            //li tawa en tan (lon ...) -- prep phrase like  *** Prep phrase parser blows chunks on these.
            //li tawa en tan li .... -- verb like
            //li tawa en tan e ... -- verb like *edgy but sort of okay
            //li tawa en tan. ... -- predicate like. ** OK as predicate
            foreach (string prep1 in preps)
            {
                foreach (string prep2 in preps)
                {
                    string doublePrep = "~" + prep1 + " en " + "~" + prep2;
                    if (normalized.ContainsCheck(doublePrep))
                    {
                        normalized = normalized.Replace(doublePrep, prep1 + " " + prep2);
                    }
                    doublePrep = "~" + prep2 + " en " + "~" + prep1;
                    if (normalized.ContainsCheck(doublePrep))
                    {
                        normalized = normalized.Replace(doublePrep, prep2 + " " + prep1);
                    }
                }
            }


            //Can't be prep phrase
            //li ~tawa en tan li 

            foreach (string prep1 in preps)
            {
                foreach (string prep2 in preps)
                {
                    string doublePrep = " li ~" + prep1 + " en " + prep2 + " li ";
                    if (normalized.ContainsCheck(doublePrep))
                    {
                        normalized = normalized.Replace(doublePrep, doublePrep.Replace("~", ""));
                    }
                    doublePrep = " li ~" + prep2 + " en " + prep1 + " li ";
                    if (normalized.ContainsCheck(doublePrep))
                    {
                        normalized = normalized.Replace(doublePrep, doublePrep.Replace("~", ""));
                    }
                }
            }


            //li tawa en ~tan li 
            foreach (string prep1 in preps)
            {
                foreach (string prep2 in preps)
                {
                    string doublePrep = " li " + prep1 + " en ~" + prep2 + " li ";
                    if (normalized.ContainsCheck(doublePrep))
                    {
                        normalized = normalized.Replace(doublePrep, doublePrep.Replace("~", ""));
                    }
                    doublePrep = " li " + prep2 + " en ~" + prep1 + " li ";
                    if (normalized.ContainsCheck(doublePrep))
                    {
                        normalized = normalized.Replace(doublePrep, doublePrep.Replace("~", ""));
                    }
                }
            }

            //li ~kepeken ala kepeken e
            foreach (string prep in preps)
            {
                string question = " li ~" + prep + " ala " + prep + " e ";
                if (normalized.ContainsCheck(question))
                {
                    normalized = normalized.Replace(question, question.Replace("~", ""));
                }
            }


            return normalized;
        }



        private static bool IsFragment(string value)
        {
            string normalized = value.Trim(new char[] { ' ', '\'', '«', '»', '?', '!', '.' });
            return normalized.EndCheck(" la");
        }

        //trying to catch ike a!
        public static bool IsExclamatory(string value)
        {
            string normalized = value.Trim(new char[] { ' ', '\'', '«' });
            return normalized.EndCheck("!");
        }

        //Trying to catch o! jan o! jan o. jan o, o.
        public static bool IsVocative(string value)
        {
            string normalized = value.Trim(new char[] { ' ', '\'', '«', '.', '!', '?', ',' });
            return normalized.ContainsCheck(" o ") ||
                   normalized.StartCheck("o ") ||
                   normalized.EndCheck(" o") ||
                   normalized == "o";
        }

        //public static string RepairErrors(string phrase)
        //{
        //    foreach (string s1 in new String[] { "li", "la", "e", "pi" })
        //    {
        //        phrase = Regex.Replace(phrase, @"\b" + s1 + " " + s1 + @"\b", "[SYNTAX ERROR: " + s1 + " " + s1 + "]");
        //    }
        //    foreach (string s1 in new String[] { "li", "la", "e", "pi" })
        //    {
        //        foreach (string s2 in new String[] { "li", "la", "e", "pi" })
        //        {
        //            Match found = Regex.Match(phrase, @"\b" + s1 + " " + s2 + @"\b");
        //            if (found.Success)
        //            {
        //                phrase = Regex.Replace(phrase, @"\b" + s1 + " " + s1 + @"\b", "[SYNTAX ERROR: " + s1 + " " + s2 + "]");
        //            }
        //        }
        //    }

        //    return phrase;
        //}


        
    }
}
