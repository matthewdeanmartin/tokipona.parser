using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TpLogic
{
    public class DirectObjectProcessor
    {
        public Collection<DirectObject> SplitIntoDirectObjects(string verbPhrase)
        {
            Collection<DirectObject> directs = new Collection<DirectObject>();

            if (verbPhrase.Length == 0) return directs;
            if (!verbPhrase.Contains(" e ")) return directs;

            verbPhrase = verbPhrase.Trim();

            while(verbPhrase.Contains(" e "))
            {
                directs.Add(new DirectObject(verbPhrase.Substring(verbPhrase.LastIndexOf(" e ") + 3)));
                verbPhrase = verbPhrase.Substring(0, verbPhrase.LastIndexOf(" e "));
            }
            
            Collection<DirectObject> reversed = new Collection<DirectObject>();

            foreach (DirectObject directObject in directs.Reverse())
            {
                reversed.Add(directObject);
            }

            //Remove prep phrases from end.
            if(reversed.Last().Words.Length>=2)
            {
                DirectObject last = reversed.Last();
                string[] possiblePp = last.Modifiers();
                
                PrepositionalPhraseProcessor ppp = new PrepositionalPhraseProcessor();
                Collection<PrepositionalPhrase> pp= ppp.SplitIntoPrepPhrases(last.Text);

            }
            return reversed;
        }

        private NounPhrase ExtractNounPhrase(string text, int i, int offset)
        {
            NounPhrase s = new NounPhrase(text.Substring(offset, i - offset));
            return s;
        }
    }

    public class DirectObject:NounPhrase
    {
        public DirectObject(string subjectText):base(subjectText)
        {
        } 
    }
}
