using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BasicTypes.Diagnostics;
using BasicTypes.Extensions;
using BasicTypes.ParseDiscourse;
using BasicTypes.Parser;
using NUnit.Framework.Constraints;
//using Polenter.Serialization.Advanced.Serializing;

namespace BasicTypes.NormalizerCode
{
    /// <summary>
    /// Assumes text is total chaos- mixed tp & foreign languages, HTML, unicode, inconsistent punctuation
    /// </summary>
    /// <remarks>
    /// What is difficult about normalizing foreign text is that foreign text might be an entire sentence, phrase or just a word.
    /// 
    /// If it is just a word, it should be jan "Matthew"
    /// 
    /// If it is an entire segment or paragraph, it should be /// commented. It isn't meaningful to tp parse an English novel. Might as well tp parse tea cups and crumpets.
    /// 
    /// If it is a long phrase, it should be "This*is*Some*Embedded*English"
    /// </remarks>
    public class NormalizeForeignText
    {
        public static string Normalize(string sentence, Dialect dialect)
        {
            if (string.IsNullOrWhiteSpace(sentence))
            {
                throw new ArgumentNullException("sentence","No null or blank sentences");
            }
            if (sentence.EndCheck(" "))
            {
                throw new ArgumentException("Must trim spaces before calling this","sentence");
            }
            char punct=' ';
            if (sentence.EndCheck(".", "!", "?"))
            {
                punct = sentence[sentence.Length - 1];
                sentence = sentence.Substring(0, sentence.Length-1);
            }
            Tracers.Normalize.TraceInformation("Early but after punct removal:" + sentence);
            string normalized = DetectWrongQuotes(sentence);
            Tracers.Normalize.TraceInformation("DetectWrongQuotes:" + normalized);
            normalized = DetectAllCapTokiPonaWords(normalized, dialect);
            Tracers.Normalize.TraceInformation("DetectAllCapTokiPonaWords:" + normalized);
            normalized = DetectEntireForeignSentence(normalized, dialect);
            Tracers.Normalize.TraceInformation("DetectEntireForeignSentence:" + normalized);

            normalized = SentenceSplitter.SwapQuoteAndSentenceTerminatorOrder(normalized);
            Tracers.Normalize.TraceInformation("SwapQuoteAndSentenceTerminatorOrder:" + normalized);

            //TODO: use English spell check to detect words
            
            //Doesn't work!!!
            //normalized = DetectIndividualForeignWords(normalized);
            if (punct != ' ')
            {
                return normalized +punct;
            }
            return normalized ;
        }

        private static readonly char[] ExtraneousPunctuation = new char[]
        {
            '«', '»', '@', '.', '!', ' ', '?', '!', '\n', '\r', ';', ':', '<', '>', '/', '&', '$', '\'',
            '"', '(', ')',
        };

        private static string DetectWrongQuotes(string normalized)
        {
            if (string.IsNullOrWhiteSpace(normalized))
            {
                //degenerate case
                return normalized;
            }
            if (normalized.Length <= 2 && normalized.ContainsCheck(@""""))
            {
                //degenerate
                return normalized;
            }
            if (normalized.StartCheck(@"""") && normalized.EndCheck(@""""))
            {
                if (PercentTokiPona(normalized.Trim(ExtraneousPunctuation)) > .80m)
                {
                    return "'" + normalized.Substring(1, normalized.Length - 2) + "'";
                }
            }
            //This doesn't work. It can't distinguish between:
            // "bla blah. 
            //  bla blah."

            //and 
            // ni li ilo "Jada".

            //if (normalized.StartCheck(@"""") )
            //{
            //    if (PercentTokiPona(normalized.Trim(ExtraneousPunctuation)) > .80m)
            //    {
            //        return "'" + normalized.Substring(1, normalized.Length - 1);
            //    }
            //}
            //if (normalized.EndCheck(@""""))
            //{
            //    if (PercentTokiPona(normalized.Trim(ExtraneousPunctuation)) > .80m)
            //    {
            //        return normalized.Substring(0, normalized.Length - 2) + "'";
            //    }
            //}

            return normalized;
            
        }

        public static string DetectAllCapTokiPonaWords(string normalized, Dialect dialect)
        {
            if (!dialect.InferCompoundsPrepositionsForeignText)
            {
                return normalized;
            }

            if (normalized.ToLowerInvariant() == normalized) return normalized;

            string[] split = normalized.Split(new char[] { ' ' });

            for (int index = 0; index < split.Length; index++)
            {
                string word = split[index];
                if (word.ToUpperInvariant() == word)
                {
                    string test = word.ToLowerInvariant();
                    if (Word.IsWord(test))
                    {
                        split[index] = test;
                    }
                }
            }

            return String.Join(" ", split);
        }

        /// <summary>
        /// Stupidest thing that could possibly work. The goal is to get the 90% of cases and not fail in those cases
        /// than to try to get 100% of the cases and create a hot spot of bug. See alt below.
        /// </summary>
        public static string DetectIndividualForeignWords(string normalized, Dialect dialect)
        {
            if (!dialect.InferCompoundsPrepositionsForeignText)
            {
                return normalized;
            }

            if (normalized.ContainsCheck("\n"))
            {
              normalized=  normalized.Replace("\n", " \n ");
            }
            string[] split = normalized.Split(new char[] {' '});

            
            
            for (int index = 0; index < split.Length; index++)
            {
                string word = split[index];

                if (word.StartCheck("\"") && word.EndsWith("\""))
                {
                    //it already is fine.
                    continue;
                }
                if (word.ContainsOnlyDigitsAndNumberLikeCruft())
                {
                    continue;
                }
                if (word.ContainsOnlyPunctuation())
                {
                    continue;
                }
                //Can't deal with whitespace yet.
                if (word.ContainsCheck("\n"))
                {
                    continue;
                }
                if (word.ContainsCheck("\r"))
                {
                    continue;
                }
                if (word.ContainsCheck("\t"))
                {
                    continue;
                }
                if (word.ContainsOnlyAtoZLetters())
                {
                    //Simple stand alone word that clearly is not toki pona.
                    if (!Token.CheckIsValidPhonology(word))
                    {
                        split[index] = "\"" + word + "\"";
                    }
                }
                else
                {
                    StringBuilder justLetters = new StringBuilder();
                    
                    foreach (char c in word.ToLower())
                    {
                        if ("abcdefghijklmnopqrstuvwxyz".Contains(c))
                        {
                            justLetters.Append(c);
                        }
                    }
                    if (!Token.CheckIsValidPhonology(justLetters.ToString()))
                    {
                        


                        StringBuilder rebuild = new StringBuilder();

                        bool firstQuote = word.StartCheck("\"");
                        bool lastQuote = word.Contains("\"") && !firstQuote;
                        string testWord = word;
                        string testWordLowered = testWord.ToLower();

                        for (int i = 0; i < testWord.Length; i++)
                        {
                            if (!firstQuote && "abcdefghijklmnopqrstuvwxyz".ContainsCheck(testWordLowered[i]))
                            {
                                rebuild.Append("\"" + testWord[i]);
                                firstQuote = true;
                                continue;
                            }
                            if ( testWordLowered.Length<i && firstQuote && !"abcdefghijklmnopqrstuvwxyz".Contains(testWordLowered[i+1]) && !lastQuote)
                            {
                                rebuild.Append(testWord[i] + "\"");
                                lastQuote = true;
                                continue;
                            }
                            rebuild.Append(testWord[i]);
                        }
                        if (firstQuote && !lastQuote)
                        {
                            rebuild.Append("\"");
                        }

                        if (!firstQuote && !lastQuote)
                        {
                            rebuild.Append("\"", 0, 1);//prepend
                            rebuild.Append("\"");
                        }

                        
                        split[index] = rebuild.ToString();
                    }
                    
                }
            }

            string rejoin = String.Join(" ", split);
            if (rejoin.ContainsCheck(" \n "))
            {
                rejoin = rejoin.Replace(" \n ", "\n");
            }

            if (rejoin.ContainsCheck("\" \""))
            {
                //"foo" "bar" "baz" etc
                return rejoin.Replace("\" \"", "*");
            }

            return rejoin;
        }

        /// <summary>
        /// This has one fatal flaw-- it can screw up the punctuation that is between tokens.
        /// </summary>
        public static string DetectIndividualForeignWordsByTokens(string normalized)
        {
            if (normalized.ContainsCheck(" "))
            {
                bool needFixing = false;
                List<string> normalizedTokens = new List<string>();
                string[] tokens = normalized.Split(new[] {' '});
                foreach (string token in tokens)
                {
                    //Already foreign enough.
                    string unpunctuated = token.Trim(ExtraneousPunctuation);
                    if (token.StartCheck(@"""") && token.EndCheck(@"""") && !token.ContainsCheck(" ")) continue;

                    var justLetters = Regex.Match(unpunctuated
                        , @"\p{L}+");
                    if (justLetters.Success)
                    {
                        if (!Token.CheckIsValidPhonology(justLetters.Value))
                        {
                            needFixing = true;
                            normalizedTokens.Add(@"""" + token.Trim()  + @"""");
                        }
                        else
                        {
                            normalizedTokens.Add(token);
                        }
                    }
                }
                if (needFixing)
                {
                    normalized = string.Join(" ", normalizedTokens);
                }
            }
            return normalized;
        }

        public static string DetectEntireForeignSentence(string sentence, Dialect dialect)
        {
            decimal percentTokipona = PercentTokiPona(sentence);
            if (percentTokipona >= 0.20m)
            {
                //Quote on a per word basis.
                return  NormalizeForeignText.DetectIndividualForeignWords(sentence, dialect);
            }

            //Quote the whole thing. 
            if (sentence.ContainsCheck(" "))
            {
                sentence = sentence.Replace(" ", "*");
            }
            if (!sentence.StartCheck(@""""))
            {
                sentence = @"""" + sentence;
            }
            if (!sentence.EndCheck(@"""") && !sentence.EndCheck("\"."))
            {
                sentence = sentence + @"""";
            }
            if (sentence.EndsWith("\".\""))
            {
                throw new InvalidOperationException();
            }
            return sentence;

            //if 25% or less tp, this is mostly foreign text.

            //if 75% or more tp, this is tp text with errors.

            //return "";
        }

        public static decimal PercentTokiPona(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence)) return 1; //Blank is fine!

            TokenParserUtils pu = new TokenParserUtils();
            Token[]  tokens= pu.ValidTokens(sentence);
            Word w =new Word();
            int bad = 0;
            foreach (Token token in tokens)
            {
                string unpunctuated = token.Text.Trim(ExtraneousPunctuation);

                string[] errors= w.ValidateOnConstruction(unpunctuated, false);
                if (errors.Length > 0)
                {
                    bad++;
                }
            }
            if (tokens.Length == 0) return 1;//Must be punctuation, or blank or something.
            return (((decimal)tokens.Length - (decimal)bad) / (decimal)tokens.Length);
        }
    }
}
