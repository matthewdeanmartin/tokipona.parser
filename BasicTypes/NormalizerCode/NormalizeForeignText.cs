using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string normalized = DetectWrongQuotes(sentence);
            normalized = DetectAllCapTokiPonaWords(normalized, dialect);
            normalized = DetectEntireForeignSentence(normalized, dialect);

            normalized = SentenceSplitter.SwapQuoteAndSentenceTerminatorOrder(normalized);

            //TODO: use english spell check to detect words
            
            //Doesn't work!!!
            //normalized = DetectIndividualForeignWords(normalized);

            return normalized;
        }

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
                if (PercentTokiPona(normalized.Trim(new char[]
                {
                    '«', '»', '@', '.', '!', ' ', '?', '!', '\n', '\r', ';', ':', '<', '>', '/', '&', '$', '\'',
                    '"','(',')',
                })) > .80m)
                {
                    return "'" + normalized.Substring(1, normalized.Length - 2) + "'";
                }
            }
            if (normalized.StartCheck(@"""") )
            {
                if (PercentTokiPona(normalized.Trim(new char[]
                {
                    '«', '»', '@', '.', '!', ' ', '?', '!', '\n', '\r', ';', ':', '<', '>', '/', '&', '$', '\'',
                    '"','(',')',
                })) > .80m)
                {
                    return "'" + normalized.Substring(1, normalized.Length - 1);
                }
            }
            if (normalized.EndCheck(@""""))
            {
                if (PercentTokiPona(normalized.Trim(new char[]
                {
                    '«', '»', '@', '.', '!', ' ', '?', '!', '\n', '\r', ';', ':', '<', '>', '/', '&', '$', '\'',
                    '"','(',')',
                })) > .80m)
                {
                    return normalized.Substring(0, normalized.Length - 2) + "'";
                }
            }

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
                if (word == "PANA")
                {
                    int i = 32;
                }
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

            string[] split = normalized.Split(new char[] {' '});

            
            
            for (int index = 0; index < split.Length; index++)
            {
                string word = split[index];

                //if (word.Contains("Liosa"))
                //{
                //    int i = 42;
                //}

                if (word.StartCheck("\"") && word.EndsWith("\""))
                {
                    //it already is fine.
                    continue;
                }
                if (word.ContainsOnlyDigits())
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
            if (rejoin.ContainsCheck("\" \""))
            {
                //"foo" "bar" "baz" etc
                return rejoin.Replace("\" \"", " ");
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
                    string unpunctuated =
                        token.Trim(new char[]
                        {
                            '«', '»', '@', '.', '!', ' ', '?', '!', '\n', '\r', ';', ':', '<', '>', '/', '&', '$', '\'','(',')',
                            '"'
                        });
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
                string unpunctuated =
                        token.Text.Trim(new char[]
                        {
                            '«', '»', '@', '.', '!', ' ', '?', '!', '\n', '\r', ';', ':', '<', '>', '/', '&', '$', '\'','(',')',
                            '"'
                        });

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
