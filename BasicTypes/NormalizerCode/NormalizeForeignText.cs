using System.Collections.Generic;
using System.Text.RegularExpressions;
using BasicTypes.Extensions;
using BasicTypes.Parser;

namespace BasicTypes.NormalizerCode
{
    /// <summary>
    /// Assumes text is total chaos- mixed tp & foreign languages, HTML, unicode, inconsistent punctuation
    /// </summary>
    public class NormalizeChaos
    {
        public static string Normalize(string sentence)
        {
            string normalized = DetectWrongQuotes(sentence);
            normalized = DetectEntireForeignSentence(normalized);

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

        private static string DetectIndividualForeignWords(string normalized)
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

        private static string DetectEntireForeignSentence(string sentence)
        {
            decimal percentTokipona = PercentTokiPona(sentence);
            if (percentTokipona < 0.20m)
            {
                if (sentence.ContainsCheck(" "))
                {
                    sentence = sentence.Replace(" ", "*");
                }
                if (!sentence.StartCheck(@""""))
                {
                    sentence = @"""" + sentence;
                }
                if (!sentence.EndCheck(@""""))
                {
                    sentence = sentence + @"""";
                }
                return sentence;
            }
            else
            {
                return sentence;
            }

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
