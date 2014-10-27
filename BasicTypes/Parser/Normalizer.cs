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
            Console.WriteLine("Before: " + text);
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }

            if (IsNullWhiteOrPunctuation(text))
            {
                return "";
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

            //Left overs from initial parsing.
            if (normalized.Contains("[NULL]"))
            {
                normalized = normalized.Replace("[NULL]", "");
            }

            string[] preps = new String[] { "kepeken", "tawa", "poka", "sama", "tan", "lon" };
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
                foreach (var predicateSplitter in new string[] { " o " ," li "})
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
                foreach (var predicateSplitter in new string[] { " la "})
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
                        normalized = normalized.Replace(terminalPrep, prep + ", o ");
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

            //la o
            //invisible implicit subject.
            if (normalized.Contains(" la o "))
            {
                normalized = normalized.Replace(" la o ", " la jan Sanwan o ");
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
                        normalized = normalized.Replace(doublePrep,   prep1 + " " + prep2);
                    }
                    doublePrep = "~" + prep2 + " en " + "~" + prep1;
                    if (normalized.Contains(doublePrep))
                    {
                        normalized = normalized.Replace(doublePrep,  prep2 + " " + prep1);
                    }
                }
            }

            normalized = Regex.Replace(normalized, @"^\s+|\s+$", ""); //Remove extraneous whitespace

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
            }

            if (normalized.Contains("sina"))
            {
                normalized = NormalizedSinaLi(normalized);
                normalized = NormalizedSinaLi(normalized, "'");
                normalized = NormalizedSinaLi(normalized, "«");
                normalized = NormalizedSinaLi(normalized, "' ");
                normalized = NormalizedSinaLi(normalized, "« ");
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

            string fakePredicate = " li ijo Nanunanuwakawakawawa.";
            if (!(normalized.Contains(" li ")) && !IsVocative(normalized) && !IsExclamatory(normalized) && !IsFragment(normalized))
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
            //vocatives & exlamations are expected to be fragmentary.

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
            string normalized = value.Trim(new char[] { ' ', '\'', '«','.','!','?',',' });
            return normalized.Contains(" o ") ||
                   normalized.StartsWith("o ") ||
                   normalized.EndsWith(" o") ||
                   normalized=="o";
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
