using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BasicTypes.Collections;
using BasicTypes.Diagnostics;
using BasicTypes.Dictionary;
using BasicTypes.Exceptions;
using BasicTypes.Extensions;

namespace BasicTypes.NormalizerCode
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
        private Dialect dialect;
        private NormalizeCompoundWords cw;
        public Normalizer(Dialect dialect)
        {
            cw = new NormalizeCompoundWords();
            this.dialect = dialect;
        }
        public  string NormalizeText(string text)//= null
        {
            if (!dialect.InferCompoundsPrepositionsForeignText)
            {
                //HACK: Not the way this should work.
                NormalizeExplicit ex = new NormalizeExplicit(dialect);
                return ex.NormalizeText(text);
            }
            SentenceDiagnostics sd = new SentenceDiagnostics(text,"N/A");

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

            //Process explict Foreign Text (this always happens)
            if (dialect.InferCompoundsPrepositionsForeignText)
            {
                normalized = NormalizationTasks.ApplyNormalization(normalized, "Foreign", NormalizeForeignText.NormalizeImplicit, dialect);
            }

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
            if (dialect.InferNumbers)
            {
                normalized = NormalizationTasks.ApplyNormalization(normalized, "Numbers", NormalizeNumbers.FindNumbers, dialect);
            }





            //Extraneous punctuation-- TODO, expand to most other symbols.
            if (normalized.ContainsCheck("(") || normalized.ContainsCheck(")"))
            {
                normalized = normalized.Replace("(", "");
                normalized = normalized.Replace(")", "");
            }

            //Extraneous commas
            if (normalized.ContainsCheck(","))
            {
                //Benefit of the doubt. if you see , sama, ==> ~sama
                //Otherwise, assume it is garbage.
                foreach (string prep in Particles.Prepositions)
                {
                    if (normalized.ContainsCheck("," + prep))
                    {
                        normalized = normalized.Replace("," + prep, "~" + prep);
                    }
                    if (normalized.ContainsCheck(", " + prep))
                    {
                        normalized = normalized.Replace(", " + prep, " ~" + prep);
                    }
                }
                

                normalized = NormalizationTasks.ApplyNormalization(normalized, "ExtraCommas", NormalizationTasks.ProcessExtraneousCommas);
            }

            //Left overs from initial parsing.
            if (normalized.ContainsCheck("[NULL]"))
            {
#if DEBUG
                throw new InvalidOperationException("Stop adding [NULL] to normalized sentences.");
#else
                normalized = normalized.Replace("[NULL]", "");
#endif

            }
                //Normalize prepositions to ~, so that we don't have tokens with embedded spaces (e.g. foo, kepeken => [foo],[, kepeken])

            if (normalized.ContainsCheck(" "))
            {
                normalized = NormalizationTasks.ApplyNormalization(normalized, "ExtraWhiteSpace", NormalizationTasks.ProcessExtraneousWhiteSpace);
            }



            //Okay, phrases should be recognizable now.
            if (dialect.InferCompoundsPrepositionsForeignText)
            {
                normalized = NormalizationTasks.ApplyNormalization(normalized, "Compounds", cw.ProcessCompoundWords);
            }

            
            if (dialect.InferCompoundsPrepositionsForeignText)
            {
                normalized = NormalizationTasks.MarkImplicitPrepositions(text, normalized);
            }

            //la o
            //invisible implicit subject.
            if (normalized.ContainsCheck(" la o "))
            {
                normalized = normalized.Replace(" la o ", " la jan Sanwan o ");
            }

            normalized =NormalizeMiSina.MiSinaProcessAndUndoOverNormalization(normalized);

            if (normalized.ContainsCheck("~"))
            {
                normalized = NormalizationTasks.ThoseArentPrepositions(normalized);
            }

            normalized = Regex.Replace(normalized, @"^\s+|\s+$", ""); //Remove extraneous whitespace


            //If it is a sentence fragment, I really can't deal with prep phrase that may or may not be in it.
            if (normalized.ContainsCheck("~")
                && !normalized.ContainsCheck(" li ") //full sentence okay
                && !normalized.StartCheck("o ") //imperative okay
                )
            {
                normalized = normalized.Replace("~", ""); //HACK: This may erase ~ added by user at the start?
            }

            normalized = NormalizeMiSina.ProcessMiSinaOvernormalizationWithPrepositions(normalized);


            normalized = NormalizeMiSina.ProcessMiSinaOverNormalizationWithoutPrepositions(text, normalized);

            //One off that comes back?
            foreach (string oneOff in new[] {
                                                         "li ~lon poka e", //place something next to
                                                         "li ~tawa tu e"
                                                    })
            {
                normalized = normalized.Replace(oneOff, oneOff.Replace("~", ""));
            }


            if (normalized.ContainsCheck("'"))
            {
                normalized = NormalizationTasks.ApplyNormalization(normalized, "DirectQuotes", NormalizationTasks.AddDirectedQuotes);
            }

            //Post conditions.
            if (normalized.StartCheck("« »"))
            {
                throw new InvalidOperationException("quote recognition went wrong: " + text);
            }


            //Probably added above by mistake
            normalized = NormalizationTasks.RemoveInternalWhiteSpace(normalized);
            normalized = NormalizationTasks.TimeWhiteSpaceAndSpaceBeforeSentenceTerminators(normalized);

            sd = new SentenceDiagnostics(text, normalized);
            return normalized;
        }

    }
}

