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
        public static string NormalizeText(string text, Config dialect=null)
        {
            if (dialect == null)
            {
                dialect = Config.CurrentDialect;
            }
            string normalized = text;
            //Normalize prepositions to ~, so that we don't have tokens with embedded spaces (e.g. foo, kepeken => [foo],[, kepeken])

            bool hasErrors = DetectErrors(normalized, dialect.ThrowOnSyntaxError);
            if(hasErrors)
            {
                normalized = RepairErrors(normalized);
            }

            bool isPunctuated = false;
            foreach (string prep in new String[] { "kepeken", "tawa", "poka", "sama", "tan", "lon" })
            {
                if (normalized.Contains(prep))
                {
                    isPunctuated = normalized.Contains(", " + prep) || normalized.Contains("," + prep);
                    normalized = Regex.Replace(normalized, "," + prep, " ~" + prep);
                    normalized = Regex.Replace(normalized, ", " + prep, "~" + prep);

                    if (normalized.Contains("~ ~"))
                    {
                        throw new InvalidOperationException(text);
                    }
                }
            }
            if (!isPunctuated && !normalized.Contains("~"))
            {
                foreach (string prep in new String[] { "kepeken", "tawa", "poka", "sama", "tan", "lon" })
                {
                    if (normalized.Contains(prep))
                    {
                        //HACK:Naive repair-- doesn't deal with unusal white space patterns.
                        normalized = Regex.Replace(normalized, " "+ prep, " ~" + prep);
                    }
                }
            }


            normalized = Regex.Replace(normalized, @"^\s+|\s+$", ""); //Remove extraneous whitespace
            
            //TODO: detect start of sentence & replace mi X and sina Y with 

            if (normalized.StartsWith("mi ") && !normalized.StartsWith("mi li "))
            {
                //modified mi is rare.
                bool possibleProunoun = !normalized.StartsWith("mi suli")
                                        && !normalized.StartsWith("mi mute")
                                        && !normalized.StartsWith("mi tu")
                                        && !normalized.StartsWith("mi soweli");
                //mi mute li suli.
                //mi toki.

                //modified mi will force a li.
                if (possibleProunoun && normalized.Contains(" li "))
                {
                    //Skip we probalby have a li already.
                }
                else
                {
                    normalized = "mi li " + normalized.Substring(3);
                }
            }
            if (normalized.StartsWith("sina ") && !normalized.StartsWith("sina li "))
            {
                bool possibleProunoun = !normalized.StartsWith("sina suli")
                                        && !normalized.StartsWith("sina mute")
                                        && !normalized.StartsWith("sina tu")
                                        && !normalized.StartsWith("sina soweli");
                //mi mute li suli.
                //mi toki.

                if (possibleProunoun && normalized.Contains(" li "))
                {
                    //Skip we probalby have a li already.
                }
                else
                {
                    normalized = "sina li " + normalized.Substring(5);
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

            return normalized;
        }

        public static string RepairErrors(string phrase)
        {
            foreach (string s1 in new String[] { "li", "la", "e", "pi" })
            {
                phrase= Regex.Replace(phrase, @"\b" + s1 + " " + s1 + @"\b", "[SYNTAX ERROR: "+ s1 + " " + s1 +"]");
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
            
            foreach (string s1 in new String[] {"li", "la", "e", "pi"})
            {
                Match found = Regex.Match(phrase, @"\b" +s1+" "+s1+@"\b");    
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
            foreach (string s1 in new String[] { "li", "la", "e","pi" })
            {
                foreach (string s2 in new String[] {"li", "la", "e", "pi"})
                {
                    Match found = Regex.Match(phrase, @"\b"+ s1+ " " +s2 + @"\b");
                    if (found.Success)
                    {
                        if (throwOnSyntaxErrors)
                            throw new TpSyntaxException("Illegal series of particles : " + s1+ " " +s2 + " in " + phrase);
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
