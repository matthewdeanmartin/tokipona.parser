using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TpLogic
{
    public class Modifier
    {
        public static string Capitalize(string word)
        {
            if (string.IsNullOrEmpty(word)) return "";
            if (word.Length == 0) return "";
            if (word.Length == 1) return word.ToUpper();

            string firstLetter = word.Substring(0, 1).ToUpper();
            return firstLetter + word.Substring(1, word.Length - 1);
        }

           private Lexicon lexicon;
        private string text;

        public Modifier(Lexicon dictionary, string baseText)
        {
            text = baseText;
           lexicon = dictionary;
        }
    
        public string Translate()
        {
            if (lexicon.modifers.ContainsKey(text))
                return lexicon.modifers[text];
            else if (lexicon.unknownPos.ContainsKey(text))
                return lexicon.unknownPos[text];
            else
            {
                //Must be a proper modifier, it isn't tp
                return Modifier.Capitalize(text);
            }
        }
    }

}

