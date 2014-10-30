using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BasicTypes.Exceptions;

namespace BasicTypes.Parser
{
    /// <summary>
    /// Turns human written text into machine parsable text.
    /// </summary>
    /// <remarks>
    /// Assumes the text is toki pona and correctly punctuated.
    /// 
    /// Detect impossible syntax.
    /// 
    /// Turn ", (prep)" into " ~prep"
    /// 
    /// Detect & hyphenate common compound words.
    /// 
    /// </remarks>
    public class Normalizer
    {
        public static bool IsNullWhiteOrPunctuation(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return true;


            foreach (char c in value)
            {
                if (!"!.', !@#$%^&*())_[]|~`<>?:\n '»".Contains(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static string NormalizeText(string text, Dialect dialect = null)
        {
            //Console.WriteLine("Before: " + text);
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            if (IsNullWhiteOrPunctuation(text))
            {
                return null;
            }

            if (dialect == null)
            {
                dialect = Config.CurrentDialect;
            }
            string normalized = text;
            //Normalize prepositions to ~, so that we don't have tokens with embedded spaces (e.g. foo, kepeken => [foo],[, kepeken])

            bool hasErrors = DetectErrors(normalized, dialect.ThrowOnSyntaxError);
            if (hasErrors)
            {
                normalized = RepairErrors(normalized);
            }

            if (normalized.Contains("\""))
            {
                normalized = ProcessWhiteSpaceInForeignText(normalized);
            }

            //Extraneous punctuation-- TODO, expand to most other symbols.
            if (normalized.Contains("(") || normalized.Contains(")"))
            {
                normalized = normalized.Replace("(","");
                normalized = normalized.Replace(")", "");

            }

            //Left overs from initial parsing.
            if (normalized.Contains("[NULL]"))
            {
                normalized = normalized.Replace("[NULL]", "");
            }

            //Extraneous commas
            foreach (string s in new String[] { ", li ", ", la ", ",la ", " la, ", " la,", ", o ", ",o " })
            {
                if (normalized.Contains(s))
                {
                    normalized = normalized.Replace(s, " " + s.Trim(new char[] { ' ', ',' }) + " ");
                }
            }

            //Line breaks & other white spaces make it harder to find boundaries
            //jan li
            //tawa. ==> jan li tawa.
            normalized = normalized.Replace("\n", " ");


            //Extraneous whitespace
            while (normalized.Contains("  "))
            {
                normalized = normalized.Replace("  ", " ");
            }


            string[] preps = Particles.Prepositions;
            bool isPunctuated = false;
            foreach (string prep in preps)
            {
                if (normalized.Contains(prep))
                {
                    isPunctuated = normalized.Contains(", " + prep) || normalized.Contains("," + prep);
                    normalized = Regex.Replace(normalized, "," + prep, " ~" + prep);
                    normalized = Regex.Replace(normalized, ", " + prep, " ~" + prep);

                    if (normalized.Contains("~ ~"))
                    {
                        throw new InvalidOperationException(text);
                    }
                }
            }
            if (!isPunctuated && !normalized.Contains("~"))
            {
                foreach (string prep in preps)
                {
                    if (normalized.Contains(prep))
                    {
                        //HACK:Naive repair-- doesn't deal with unusal white space patterns.
                        normalized = Regex.Replace(normalized, " " + prep, " ~" + prep);
                    }
                }
            }



            //la o
            //invisible implicit subject.
            if (normalized.Contains(" la o "))
            {
                normalized = normalized.Replace(" la o ", " la jan Sanwan o ");
            }

            

            //TODO: detect start of sentence & replace mi X and sina Y with 

            if (normalized.Contains("mi"))
            {
                if (normalized.Contains("mi wile ala e ma li"))
                {
                    Console.WriteLine("Ok");
                }
                normalized = NormalizedMiLi(normalized);
                normalized = NormalizedMiLi(normalized, "'");
                normalized = NormalizedMiLi(normalized, "«");
                normalized = NormalizedMiLi(normalized, "' ");
                normalized = NormalizedMiLi(normalized, "« ");

                foreach (Word possible in Words.Dictionary.Values)
                {
                    //Need a new concept-- ordinary POS & fallback POS
                    string pronoun = "mi";
                    Dictionary<string, Dictionary<string, string[]>> glosses;
                    if(Words.Glosses.TryGetValue(possible.Text, out glosses))
                    {
                        Dictionary<string, string[]> enGlosses;
                        if (glosses.TryGetValue("en", out enGlosses))
                        {
                            if ((enGlosses.ContainsKey("vt") && enGlosses["vt"].Length > 0) 
                                || 
                                (enGlosses.ContainsKey("vi")  && enGlosses["vi"].Length > 0))
                            {
                                string unLied = " " + pronoun + " " + possible + " ";
                                if (normalized.Contains(unLied))
                                {
                                    normalized = normalized.Replace(unLied, " "+ pronoun +" li " + possible + " ");
                                }
                            }
                        }
                    }
                }
            }

            if (normalized.Contains("sina"))
            {
                normalized = NormalizedSinaLi(normalized);
                normalized = NormalizedSinaLi(normalized, "'");
                normalized = NormalizedSinaLi(normalized, "«");
                normalized = NormalizedSinaLi(normalized, "' ");
                normalized = NormalizedSinaLi(normalized, "« ");


                foreach (Word possible in Words.Dictionary.Values)
                {
                    //Need a new concept-- ordinary POS & fallback POS
                    string pronoun = "sina";
                    Dictionary<string, Dictionary<string, string[]>> glosses;
                    if (Words.Glosses.TryGetValue(possible.Text, out glosses))
                    {
                        Dictionary<string, string[]> enGlosses;
                        if (glosses.TryGetValue("en", out enGlosses))
                        {
                            if ((enGlosses.ContainsKey("vt") && enGlosses["vt"].Length > 0)
                                ||
                                (enGlosses.ContainsKey("vi") && enGlosses["vi"].Length > 0))
                            {
                                string unLied = " " + pronoun + " " + possible + " ";
                                if (normalized.Contains(unLied))
                                {
                                    normalized = normalized.Replace(unLied, " " + pronoun + " li " + possible + " ");
                                }
                            }
                        }
                    }
                }
            }


            if (normalized.Contains("la mi"))
            {
                normalized = Regex.Replace(normalized, @"\bla mi\b", "la mi li"); //normalize contractions

                //If original was, say, "kin la mi li pali", we get a double li li
                if (normalized.Contains(" li li "))
                {
                    //undo doubling.
                    normalized = Regex.Replace(normalized, @"\bli li\b", "li"); //normalize contractions
                }

            }


            if (normalized.Contains("la sina"))
            {
                normalized = Regex.Replace(normalized, @"\bla sina\b", "la sina li"); //normalize contractions

                //If original was, say, "kin la sina li pali", we get a double li li
                if (normalized.Contains(" li li "))
                {
                    //undo doubling.
                    normalized = Regex.Replace(normalized, @"\bli li\b", "li"); //normalize contractions
                }
            }

            if (normalized.Contains("~"))
            {
                normalized = ThoseArentPrepositions(preps, normalized);
            }

            normalized = Regex.Replace(normalized, @"^\s+|\s+$", ""); //Remove extraneous whitespace

            //If it is a sentence fragment, I really can't deal with prep phrase that may or may not be in it.
            if (normalized.Contains("~") && !normalized.Contains(" li "))
            {
                normalized = normalized.Replace("~", ""); //HACK: This may erase ~ added by user at the start?
            }

            string fakePredicate = " li ijo Nanunanuwakawakawawa.";
            //normalized = UseDummyPredicateForObviousFragments(normalized, fakePredicate);
            //vocatives & exclamations are expected to be fragmentary.


            //It's a prep, but missing the li.
            if (normalized.Contains("sina ~tawa"))
            {
                normalized = normalized.Replace("sina ~tawa", " sina li ~tawa");
            }
            if (normalized.Contains("mi ~tawa"))
            {
                normalized = normalized.Replace("mi ~tawa", "mi li ~tawa");
            }

            //Probably added above by mistake
            while (normalized.Contains("  "))
            {
                normalized = normalized.Replace("  ", " ");
            }

            if (normalized.Contains("'"))
            {
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
            }

            if (normalized == fakePredicate)
            {
                throw new InvalidOperationException("started with " + text);
            }
            if (normalized.StartsWith("« »"))
            {
                throw new InvalidOperationException("quote recognition went wrong: "  + text);
            }
            return normalized;
        }

        private static string UseDummyPredicateForObviousFragments(string normalized, string fakePredicate)
        {
            if (!(normalized.Contains(" li ")) && !IsVocative(normalized) && !IsExclamatory(normalized) &&
                !IsFragment(normalized))
            {
                //Add a marker that we can later remove. Allows for parsing NPs, like titles, as if
                //they were sentences.
                if (normalized.EndsWith("."))
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

        private static string ProcessWhiteSpaceInForeignText(string normalized)
        {
            StringBuilder sb = new StringBuilder(normalized.Length);
            bool insideForeignText = false;

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
            }
            if (insideForeignText)
            {
                sb.Append('"');
            }
            return sb.ToString();
        }

        private static string ThoseArentPrepositions(string[] preps, string normalized)
        {
            //I don't even know what that means.
            //This is just so corpus texts can pass. Better solution is to write annoted text in the first place.
            foreach (string  oneOff in new string[] {
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
                                                    })
            {
                normalized = normalized.Replace(oneOff, oneOff.Replace("~",""));
            }
            
            //As in jan sama o!
            //jan ~sama o!
            if (normalized.Contains(" ~sama o "))
            {
                normalized = normalized.Replace(" ~sama o ", " sama o ");
            }
            if (normalized.Contains(" ~sama o, "))
            {
                normalized = normalized.Replace(" ~sama o, ", " sama o, ");
            }
            if (normalized.EndsWith(" ~sama o"))
            {
                normalized = normalized.Replace(" ~sama o", " sama o");
            }
            if (normalized.EndsWith(" ~sama o!"))
            {
                normalized = normalized.Replace(" ~sama o!", " sama o!");
            }
            if (normalized.EndsWith(" ~sama o?"))
            {
                normalized = normalized.Replace(" ~sama o?", " sama o?");
            }
            if (normalized.EndsWith(" ~sama o."))
            {
                normalized = normalized.Replace(" ~sama o.", " sama o.");
            }
            //li kama tawa ==> verb!


            //li ~kepeken e
            foreach (string prep in preps)
            {
                string barePrep = " li ~" + prep + " e ";
                if (normalized.Contains(barePrep))
                {
                    normalized = normalized.Replace(barePrep, barePrep.Replace("~", ""));
                }
            }


            //li ~tawa ala e
            foreach (string prep in preps)
            {
                string barePrep = " li ~" + prep + " ala e ";
                if (normalized.Contains(barePrep))
                {
                    normalized = normalized.Replace(barePrep, barePrep.Replace("~", ""));
                }
            }
            //~tawa e
            foreach (string prep in preps)
            {
                string barePrep = " ~" + prep + " e ";
                if (normalized.Contains(barePrep))
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
                if (normalized.Contains(barePrep))
                {
                    normalized = normalized.Replace(barePrep, barePrep.Replace("~", ""));
                }
            }

            //~tan-  it's a prep but inside a compound phrase, we don't care. It's opaque.
            foreach (string prep in preps)
            {
                string barePrep = "~" + prep + "-";
                if (normalized.Contains(barePrep))
                {
                    normalized = normalized.Replace(barePrep, barePrep.Replace("~", ""));
                }
            }

            //~tawa pi --- not possible.
            foreach (string prep in preps)
            {
                string barePrep = "~" + prep + " pi ";
                if (normalized.Contains(barePrep))
                {
                    normalized = normalized.Replace(barePrep, barePrep.Replace("~", ""));
                }
            }

            //lon ala li pana e lon
            foreach (string prep in preps)
            {
                string initial = "~" + prep + " ";
                if (normalized.StartsWith(initial))
                {
                    normalized = prep + " " + normalized.Substring((prep + " ").Length);
                    //normalized = normalized.Replace(initial, initial.Replace("~", ""));
                }
            }

            //This is so uncommon, that it actually better to assume it isn't a prep.
            foreach (string prep in preps)
            {
                string piHeadedPrep = " pi ~" + prep + " ";
                if (normalized.Contains(piHeadedPrep))
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
                    if (normalized.Contains(terminalPrep))
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
                    if (normalized.Contains(terminalPrep))
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
                    if (normalized.Contains(terminalPrep))
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
                    if (normalized.Contains(terminalPrep))
                    {
                        normalized = normalized.Replace(terminalPrep, prep + predicateSplitter);
                    }
                }
            }


            //e ~sama
            foreach (string prep in preps)
            {
                //e
                foreach (char c in "e")
                {
                    string terminalPrep = " " + c + " ~" + prep;
                    if (normalized.Contains(terminalPrep))
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
                    if (normalized.Contains(doublePrep))
                    {
                        normalized = normalized.Replace(doublePrep, "~" + prep1 + " " + prep2);
                    }
                    doublePrep = "~" + prep2 + " " + "~" + prep1;
                    if (normalized.Contains(doublePrep))
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
                    if (normalized.Contains(doublePrep))
                    {
                        normalized = normalized.Replace(doublePrep, prep1 + " " + prep2);
                    }
                    doublePrep = "~" + prep2 + " en " + "~" + prep1;
                    if (normalized.Contains(doublePrep))
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
                    if (normalized.Contains(doublePrep))
                    {
                        normalized = normalized.Replace(doublePrep, doublePrep.Replace("~", ""));
                    }
                    doublePrep = " li ~" + prep2 + " en " + prep1 + " li ";
                    if (normalized.Contains(doublePrep))
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
                    if (normalized.Contains(doublePrep))
                    {
                        normalized = normalized.Replace(doublePrep, doublePrep.Replace("~", ""));
                    }
                    doublePrep = " li " + prep2 + " en ~" + prep1 + " li ";
                    if (normalized.Contains(doublePrep))
                    {
                        normalized = normalized.Replace(doublePrep, doublePrep.Replace("~", ""));
                    }
                }
            }

            //li ~kepeken ala kepeken e
            foreach (string prep in preps)
            {
                string question = " li ~" + prep + " ala " + prep + " e ";
                if (normalized.Contains(question))
                {
                    normalized = normalized.Replace(question, question.Replace("~", ""));
                }
            }


            return normalized;
        }

        private static string NormalizedSinaLi(string normalized, string punctuation = "")
        {
            if (normalized.StartsWith(punctuation + "sina ") && !normalized.StartsWith(punctuation + "sina li "))
            {
                bool possibleProunoun = !normalized.StartsWith(punctuation + "sina suli")
                                        && !normalized.StartsWith(punctuation + "sina mute")
                                        && !normalized.StartsWith(punctuation + "sina tu")
                                        && !normalized.StartsWith(punctuation + "sina soweli");
                //mi mute li suli.
                //mi toki.

                if (possibleProunoun && normalized.Contains("sina li " + normalized.Substring(5 + punctuation.Length)))
                {
                    //Skip we probalby have a li already.
                }
                else
                {
                    normalized = punctuation + "sina li " + normalized.Substring(5 + punctuation.Length);
                }
            }
            return normalized;
        }

        private static string NormalizedMiLi(string normalized, string punctuation = "")
        {
            if (normalized.StartsWith(punctuation + "mi ") && !normalized.StartsWith(punctuation + "mi li "))
            {
                //modified mi is rare.
                bool possibleProunoun = !normalized.StartsWith(punctuation + "mi suli")
                                        && !normalized.StartsWith(punctuation + "mi mute")
                                        && !normalized.StartsWith(punctuation + "mi tu")
                                        && !normalized.StartsWith(punctuation + "mi soweli");
                //mi mute li suli.
                //mi toki.

                //modified mi will force a li.
                if (possibleProunoun && !normalized.Contains("mi li " + normalized.Substring(3 + punctuation.Length)))
                {
                    //Skip we probalby have a li already.
                }
                //else
                {
                    normalized = punctuation + "mi li " + normalized.Substring(3 + punctuation.Length);
                }
            }
            return normalized;
        }

        private static bool IsFragment(string value)
        {
            string normalized = value.Trim(new char[] { ' ', '\'', '«', '»', '?', '!', '.' });
            return normalized.EndsWith(" la");
        }

        //trying to catch ike a!
        public static bool IsExclamatory(string value)
        {
            string normalized = value.Trim(new char[] { ' ', '\'', '«' });
            return normalized.EndsWith("!");
        }

        //Trying to catch o! jan o! jan o. jan o, o.
        public static bool IsVocative(string value)
        {
            string normalized = value.Trim(new char[] { ' ', '\'', '«', '.', '!', '?', ',' });
            return normalized.Contains(" o ") ||
                   normalized.StartsWith("o ") ||
                   normalized.EndsWith(" o") ||
                   normalized == "o";
        }

        public static string RepairErrors(string phrase)
        {
            foreach (string s1 in new String[] { "li", "la", "e", "pi" })
            {
                phrase = Regex.Replace(phrase, @"\b" + s1 + " " + s1 + @"\b", "[SYNTAX ERROR: " + s1 + " " + s1 + "]");
            }
            foreach (string s1 in new String[] { "li", "la", "e", "pi" })
            {
                foreach (string s2 in new String[] { "li", "la", "e", "pi" })
                {
                    Match found = Regex.Match(phrase, @"\b" + s1 + " " + s2 + @"\b");
                    if (found.Success)
                    {
                        phrase = Regex.Replace(phrase, @"\b" + s1 + " " + s1 + @"\b", "[SYNTAX ERROR: " + s1 + " " + s2 + "]");
                    }
                }
            }

            return phrase;
        }


        public static bool DetectErrors(string phrase, bool throwOnSyntaxErrors = false)
        {

            foreach (string s1 in new String[] { "li", "la", "e", "pi" })
            {
                Match found = Regex.Match(phrase, @"\b" + s1 + " " + s1 + @"\b");
                if (found.Success)
                {
                    if (throwOnSyntaxErrors)
                        throw new DoubleParticleException();
                    else
                    {
                        return true;
                    }
                }
            }
            foreach (string s1 in new String[] { "li", "la", "e", "pi" })
            {
                foreach (string s2 in new String[] { "li", "la", "e", "pi" })
                {
                    Match found = Regex.Match(phrase, @"\b" + s1 + " " + s2 + @"\b");
                    if (found.Success)
                    {
                        if (throwOnSyntaxErrors)
                            throw new TpSyntaxException("Illegal series of particles : " + s1 + " " + s2 + " in " + phrase);
                        else
                        {
                            return true;
                        }
                    }
                }
            }

            return false;

        }
    }
}
