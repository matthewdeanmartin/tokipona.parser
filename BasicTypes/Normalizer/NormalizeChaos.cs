using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BasicTypes.Parts;

namespace BasicTypes.Parser
{
    /// <summary>
    /// Assumes text is total chaos- mixed tp & foreign languages, HTML, unicode, inconsistent punctuation
    /// </summary>
    public class NormalizeChaos
    {
        public static string Normalize(string sentence)
        {
            string normalized=DetectEntireForeignSentence(sentence);

            if (normalized.Contains(" "))
            {
                bool needFixing = false;
                List<string> normalizedTokens = new List<string>();
                string[] tokens= normalized.Split(new[] {' '});
                foreach (string token in tokens)
                {
                    //Already foreign enough.
                    string unpunctuated =
                        token.Trim(new char[]
                        {
                            '«', '»', '@', '.', '!', ' ', '?', '!', '\n', '\r', ';', ':', '<', '>', '/', '&', '$', '\'',
                            '"'
                        });
                    if(token.StartsWith(@"""") && token.EndsWith(@"""") && !token.Contains(" ")) continue;

                    var justLetters = Regex.Match(unpunctuated
                        
                        , @"\p{L}+");
                    if (justLetters.Success)
                    {
                        if (!Token.CheckIsValidPhonology(justLetters.Value))
                        {
                            needFixing = true;
                            normalizedTokens.Add(@"""" + token + @"""");
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
                if (sentence.Contains(" "))
                {
                    sentence = sentence.Replace(" ", "*");
                }
                if (!sentence.StartsWith(@""""))
                {
                    sentence = @"""" + sentence;
                }
                if (!sentence.EndsWith(@""""))
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
            TokenParserUtils pu = new TokenParserUtils();
            Token[]  tokens= pu.ValidTokens(sentence);
            Word w =new Word();
            int bad = 0;
            foreach (Token token in tokens)
            {
                string[] errors= w.ValidateOnConstruction(token.Text, false);
                if (errors.Length > 0)
                {
                    bad++;
                }
            }
            return (((decimal)tokens.Length - (decimal)bad) / (decimal)tokens.Length);
        }
    }
}
