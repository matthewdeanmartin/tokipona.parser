using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BasicTypes.Collections;
using BasicTypes.Extensions;

namespace BasicTypes.NormalizerCode
{
    //This should be idempotent. If you normalize it over & over, it should be the same thing.
    //The assumption here is the user has marked *all* numbers, neologism, prepositions appropriate
    public class NormalizeExplicit
    {
        private readonly Dialect dialect;
        public NormalizeExplicit(Dialect dialect)
        {
            this.dialect = dialect;
        }

        public string NormalizeText(string text) //= null
        {
            SentenceDiagnostics sd = new SentenceDiagnostics(text, "N/A");

            //Nothing to parse.
            if (string.IsNullOrWhiteSpace(text) || NormalizationTasks.IsNullWhiteOrPunctuation(text))
            {
                return "";
            }
            //Don't normalize a comment.
            if (text.StartCheck("///") && !text.Contains("\n")) return text;

            string normalized = NormalizationTasks.TimeWhiteSpaceAndSpaceBeforeSentenceTerminators(text);
            normalized = NormalizationTasks.RemoveInternalWhiteSpace(normalized);

            //Is this better early or later?
            if (normalized.Contains(@""""""))
            {
                normalized = normalized.Replace(@"""""", @"""");
            }

            //Hide tokens that otherwise have a different meaning.
            if (normalized.ContainsCheck(" li pi "))
            {
                normalized = normalized.Replace(" li pi ", " li XXXXZiXXXX ");
            }


            //  "/\\*.*?\\*/"
            // Things that cross sentences should already be deal with earlier.
            if (normalized.ContainsCheck("/*") && normalized.ContainsCheck("*/"))
            {
                normalized = NormalizationTasks.ApplyNormalization(normalized, "Comments", NormalizationTasks.StripMultilineComments);
            }

            //Process explicit explicit Foreign text. (this always happens)
            if (normalized.ContainsCheck("\""))
            {
                normalized = NormalizationTasks.ApplyNormalization(normalized, "ForeignSpace", NormalizationTasks.ProcessWhiteSpaceInForeignText, dialect);
            }

            //Swap terminators (always happens)
            normalized = NormalizationTasks.ApplyNormalization(normalized, "Foreign", NormalizeForeignText.NormalizeExplicit, dialect);
            

            //Hyphenated words. This could cause a problem for compound words that cross lines.
            if (normalized.ContainsCheck("-\n"))
            {
                normalized = normalized.Replace("-\n", "");
            }

            //can't cope with line breaks.
            if (normalized.ContainsCheck("\n"))
            {
                normalized = normalized.Replace("\n", " ");
            }
            if (normalized.ContainsCheck("\t"))
            {
                normalized = normalized.Replace("\t", " ");
            }

            //must be after - processing
            //Don't infer numbers.

            //Extraneous punctuation-- TODO, expand to most other symbols.
            if (normalized.ContainsCheck("(") || normalized.ContainsCheck(")"))
            {
                normalized = normalized.Replace("(", "");
                normalized = normalized.Replace(")", "");
            }

            //Extraneous commas... not sure, we'd like some to go away, but we want ,lon ,sama etc to stay.
            //if (normalized.ContainsCheck(","))
            //{
            //    normalized = NormalizationTasks.ApplyNormalization(normalized, "ExtraCommas", NormalizationTasks.ProcessExtraneousCommas);
            //}

            //Normalize prepositions to ~, so that we don't have tokens with embedded spaces (e.g. foo, kepeken => [foo],[, kepeken])
            
            if (normalized.ContainsCheck(","))
            {
                foreach (string prep in Particles.Prepositions)
                {
                    if (normalized.ContainsCheck("," + prep))
                    {
                        normalized = normalized.Replace("," + prep,"~" + prep);
                    }
                    if (normalized.ContainsCheck(", " + prep))
                    {
                        normalized = normalized.Replace(", " + prep, "~" + prep);
                    }
                }
            }

            if (normalized.ContainsCheck(" "))
            {
                normalized = NormalizationTasks.ApplyNormalization(normalized, "ExtraWhiteSpace", NormalizationTasks.ProcessExtraneousWhiteSpace);
            }



            //Okay, phrases should be recognizable now.
            //Don't infer compound words

            //if (dialect.InferCompoundsPrepositionsForeignText)
            //{
            //    normalized = NormalizationTasks.MarkImplicitPrepositions(text, normalized);
            //}

            //la o
            //invisible implicit subject.
            if (normalized.ContainsCheck(" la o "))
            {
                normalized = normalized.Replace(" la o ", " la jan Sanwan o ");
            }

            normalized = NormalizeMiSina.MiSinaProcessAndUndoOverNormalization(normalized);

            normalized = Regex.Replace(normalized, @"^\s+|\s+$", ""); //Remove extraneous whitespace

            normalized = NormalizeMiSina.ProcessMiSinaOvernormalizationWithPrepositions(normalized);

            normalized = NormalizeMiSina.ProcessMiSinaOverNormalizationWithoutPrepositions(text, normalized);

            if (normalized.ContainsCheck("'"))
            {
                normalized = NormalizationTasks.ApplyNormalization(normalized, "DirectQuotes", NormalizationTasks.AddDirectedQuotes);
            }

            //Probably added above by mistake
            normalized = NormalizationTasks.RemoveInternalWhiteSpace(normalized);
            normalized = NormalizationTasks.TimeWhiteSpaceAndSpaceBeforeSentenceTerminators(normalized);

            //Post conditions.
            if (normalized.StartCheck("« »"))
            {
                throw new InvalidOperationException("quote recognition went wrong: " + text);
            }

            sd = new SentenceDiagnostics(text, normalized);
            return normalized;
        }
    }
}
