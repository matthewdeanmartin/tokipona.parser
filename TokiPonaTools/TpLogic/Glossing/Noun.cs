using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TpLogic
{
    public class Noun
    {
        private Lexicon lexicon;
        private string text;

        public Noun(Lexicon dictionary, string baseText)
        {
            text = baseText;
           lexicon = dictionary;
        }
    
        public string Translate()
        {
            if (lexicon.nouns.ContainsKey(text))
                return lexicon.nouns[text];
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