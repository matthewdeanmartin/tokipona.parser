using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TpLogic
{
    public class PrepositionalPhraseProcessor
    {
        public Collection<PrepositionalPhrase> SplitIntoPrepPhrases(string verbPhrase)
        {
            verbPhrase = verbPhrase.Trim();

            //Fail safe for transitive sentences
            while(verbPhrase.Contains(" e "))
            {
                verbPhrase = verbPhrase.Substring(verbPhrase.LastIndexOf(" e ")+3);
            }

            if (!verbPhrase.StartsWith("li "))
                verbPhrase = "li " + verbPhrase;

            Collection<PrepositionalPhrase> prepPhrases = new Collection<PrepositionalPhrase>();

            if (verbPhrase.Length == 0) return prepPhrases;

            if (!(verbPhrase.Contains(" kepeken ")
                || verbPhrase.Contains(" lon ")
                || verbPhrase.Contains(" poka ")
                || verbPhrase.Contains(" sama ")
                || verbPhrase.Contains(" tan ")
                || verbPhrase.Contains(" tawa ")))
            {
                return prepPhrases;
            }
            
            int offset = 0;
            int lastPhraseLength = 0;
            int lastPrepLenght = 0;
            //int lastCut;// = 0;
            for (int i = 0; i < verbPhrase.Length; i++)
            {
                string currentPrep = "";
                if (verbPhrase.Substring(0,verbPhrase.Length-i).EndsWith(" kepeken "))
                    currentPrep = " kepeken ";
                if (verbPhrase.Substring(0,verbPhrase.Length-i).EndsWith(" lon "))
                    currentPrep = " lon ";
                if (verbPhrase.Substring(0,verbPhrase.Length-i).EndsWith(" poka "))
                    currentPrep = " poka ";
                if (verbPhrase.Substring(0,verbPhrase.Length-i).EndsWith(" tawa "))
                    currentPrep = " tawa ";
                if (verbPhrase.Substring(0,verbPhrase.Length-i).EndsWith(" tan "))
                    currentPrep = " tan ";
                if (verbPhrase.Substring(0,verbPhrase.Length-i).EndsWith(" sama "))
                    currentPrep = " sama ";

                
                if (verbPhrase.Substring(0,verbPhrase.Length-i).EndsWith(currentPrep) && currentPrep!="")
                {
                    string phraseStartingInLi = verbPhrase.Substring(verbPhrase.Length - i);
                    string phrase;
                    if (lastPhraseLength == 0)
                    {
                        phrase = phraseStartingInLi;
                        lastPhraseLength += phrase.Length;
                        lastPrepLenght += currentPrep.Length;
                    }
                    else
                    {
                        phrase = phraseStartingInLi.Substring(0, phraseStartingInLi.Length - (lastPhraseLength + lastPrepLenght));//(
                        lastPhraseLength += phrase.Length ;
                        lastPrepLenght += currentPrep.Length ;
                    }

                    //if(phrase.Contains(currentPrep))
                        //throw new InvalidOperationException("Shouldn't be an li words in this:" + phrase);

                    PrepositionalPhrase s = new PrepositionalPhrase(phrase);
                    switch(currentPrep)
                    {
                        case "kepeken":
                             s.Type = PpType.kepeken;
                            break;
                        case "lon":
                            s.Type = PpType.lon;
                            break;
                        case "poka":
                            s.Type = PpType.poka;
                            break;
                        case "sama":
                            s.Type = PpType.sama;
                            break;
                        case "tan":
                            s.Type = PpType.tan;
                            break;
                        case "tawa":
                            s.Type = PpType.tawa;
                            break;
                    }
                    
                    prepPhrases.Add(s);
                    
                    offset = offset + phrase.Length-currentPrep.Length;
                    //offset = offset - i+5;
                    currentPrep = "";
                }
            }

            return prepPhrases;
    }
    }

    public enum PpType
    {
        None=0,
        kepeken=1,
        lon=2,
        poka=3,
        sama=4,
        tan=5,
        tawa=6
    }

    public class PrepositionalPhrase:Phrase
    {
        public PpType Type { get; set; }

        public PrepositionalPhrase(string subjectText)
        {
            originalText = subjectText;
            text = originalText.Trim(new char[] { '.', '?', ':', '!' });
            while (text.Contains("  "))
                text = text.Replace("  ", " ");
            words = text.Split(new char[] {' '});
        }
    }
}
