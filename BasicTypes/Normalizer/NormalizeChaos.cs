using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Parser
{
    /// <summary>
    /// Assumes text is total chaos- mixed tp & foreign languages, HTML, unicode, inconsistent punctuation
    /// </summary>
    public class NormalizeChaos
    {
        public static string Normalize(string sentence)
        {
            decimal percentTokipona = PercentTokiPona(sentence);
            if (percentTokipona < 20)
            {
                return "Hey!";
            }
            else
            {
                return "Ho!";
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
