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
        public static string NormalizeText(string text, bool throwOnSyntaxErrors =false)
        {
            string normalized = text;
            //Normalize prepositions to ~, so that we don't have tokens with embedded spaces (e.g. foo, kepeken => [foo],[, kepeken])

            bool hasErrors = DetectErrors(normalized, throwOnSyntaxErrors);
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
                        //Naive repair
                        normalized = Regex.Replace(normalized, prep, " ~" + prep);
                    }
                }
            }


            normalized = Regex.Replace(normalized, @"^\s+|\s+$", ""); //Remove extraneous whitespace
            if (normalized.Contains("la mi"))
            {
                normalized = Regex.Replace(normalized, @"\bla mi\b", "la mi li"); //normalize contractions
            }
            if (normalized.Contains("la sina"))
            {
                normalized = Regex.Replace(normalized, @"\bla sina\b", "la sina li"); //normalize contractions
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
