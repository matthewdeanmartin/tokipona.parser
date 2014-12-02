using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Html
{
    public class HtmlFormatter
    {
        public string SubThePartsOfSpeech(string sentence)
        {
            sentence=sentence.Replace("(", "<sub>");
            sentence=sentence.Replace(")", "</sub>");
            return sentence;
        }

        public string BoldTheWords(string sentence)
        {
            if (sentence.Contains("CANNOT PARSE"))
            {
                return "<span style=\"color:DarkRed\">" + sentence + "</span>";
            }
            StringBuilder sb = new StringBuilder((int)(sentence.Length * 1.25));

            StringBuilder currentWord = new StringBuilder();
            int putEndTagHere =-2;
            string lowerSentence = sentence.ToLower();
            bool betweenEscapedSeq=false;
            bool bTagIsOpen = false;
            for (int i = 0; i < sentence.Length; i++)
            {
                if (sb.Length > sentence.Length*3)
                {
                    throw new InvalidOperationException("uh oh- is this an infinite loop?" + sb.ToString());
                }
                
                char c = sentence[i];
                char lowerC = lowerSentence[i];
                if (betweenEscapedSeq && c == ';')
                {
                    betweenEscapedSeq = false;
                }
                else if (c == '&')
                {
                    betweenEscapedSeq = true;
                }
                
                if (i == putEndTagHere)
                {
                    putEndTagHere = -2;
                    sb.Append("</b>");
                    bTagIsOpen = false;
                }
                if (!betweenEscapedSeq && Token.Alphabet.Contains(lowerC))
                {
                    if (putEndTagHere == -2)
                    {
                        sb.Append("<b>");
                        bTagIsOpen = true;
                    }
                    sb.Append(c);    
                    for (int j = i; j < sentence.Length; j++)
                    {
                        char lowerJ = sentence[j];
                        if (Token.Alphabet.Contains(lowerJ))
                        {
                            currentWord.Append(sentence[j]);
                        }
                        else
                        {
                            string prospectiveWord= currentWord.ToString();
                            currentWord.Clear();
                            putEndTagHere = j;
                            break;
                        }
                    }
                }
                else
                {
                    //Can't be a word, keep on moving.
                    sb.Append(c);    
                }
                
            }
            if (bTagIsOpen)
            {
                sb.Append("</b>");
            }
            return sb.ToString().Replace("</b> <b>", " ");
        }

        public string BoldTheWords2(string sentence)
        {
            string[] parts = sentence.Split(new char[] {' '});
            StringBuilder sb = new StringBuilder((int)(sentence.Length * 1.25));
            foreach (string part in parts)
            {
                if (Token.CheckIsValidPhonology(part))
                {
                    sb.Append("<b>");
                    sb.Append(part);
                    sb.Append("</b>");
                }
                else
                {
                    sb.Append(part);
                }
                sb.Append(" ");
            }
            return sb.ToString();
        }
    }
}
