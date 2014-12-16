using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TpLogic
{
    //Li chains. Has a verb(*) + DO (*) + PP (*)
    public class VerbPhraseProcessor
    {
        public Collection<VerbPhrase> SplitIntoVerbPhrases(string fullSentenceText)
        {
            Collection<VerbPhrase> verbPhrases = new Collection<VerbPhrase>();

            if (fullSentenceText.Length == 0) return verbPhrases;

            //upstream will have to deal with sina li, mi li
            if(!fullSentenceText.Contains(" li "))
            {
                return verbPhrases;
            }

            fullSentenceText = fullSentenceText.Trim();

            int offset = fullSentenceText.Length;// text.IndexOf(" li ");
            //bool first;// = true;

            int lastPhraseLength = 0;
            //int lastCut;// = 0;
            for (int i = 0; i < fullSentenceText.Length; i++)
            {
                
                if (fullSentenceText.Substring(0,fullSentenceText.Length-i).EndsWith(" li "))
                {
                    string phraseStartingInLi = fullSentenceText.Substring(fullSentenceText.Length - i);
                    string phrase;
                    if (lastPhraseLength == 0)
                        phrase = phraseStartingInLi;
                    else
                    {
                        phrase = phraseStartingInLi.Substring(0, phraseStartingInLi.Length-lastPhraseLength-3);
                    }

                    if(phrase.Contains(" li "))
                        throw new InvalidOperationException("Shouldn't be an li words in this:" + phrase);

                    VerbPhrase s = new VerbPhrase(phrase);
                    verbPhrases.Add(s);
                    lastPhraseLength += phrase.Length+1;
                    offset = offset + phrase.Length-4;
                    //offset = offset - i+5;
                }
            }

            foreach (VerbPhrase verbPhrase in verbPhrases)
            {
                if(verbPhrase.Words.Contains("e"))
                {
                    verbPhrase.Type = VerbPhraseType.Transitive;
                }
                //Otherwise... I don't know!
            }
            Collection<VerbPhrase> reversed= new Collection<VerbPhrase>();

            foreach (VerbPhrase verbPhrase in verbPhrases.Reverse())
            {
                reversed.Add(verbPhrase);
            }

            return reversed;
        }
    }

    public enum VerbPhraseType
    {
        None = 0, //none
        Predicate = 1, // ... looks just like intransitive.
        Intransitive = 2, //... looks just like predicate :-(
        Transitive = 3 // has 1 or more e phrases
    }

    public class VerbPhrase:Phrase
    {
        public VerbPhraseType Type { get; set; }

        public VerbPhrase(string subjectText)
        {
            originalText = subjectText;
            text = originalText.Trim(new char[] { '.', '?', ':', '!',' ',',' });
            while (text.Contains("  "))
                text = text.Replace("  ", " ");
            words = text.Split(new char[] {' '});
        }

        public string VerbPlusModifiers()
        {
    
            //Everything before the 1st or 1st preposition or e
            return "";
        }
    }
}
