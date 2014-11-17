using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KellermanSoftware.CompareNetObjects;

namespace BasicTypes.Collections
{
    public class HeadedPhraseEquivallenceGenerator
    {
        private readonly HeadedPhrase phrase;
        public HeadedPhraseEquivallenceGenerator(HeadedPhrase phrase)
        {
            this.phrase = phrase;
        }

        //Can be combined with li (predicate) or en (subject).
        // kasi suli laso ==> kasi suli en kasi laso
        // kasi suli laso ==> kasi li suli li laso
        // kasi suli laso ==> kasi li suli. kasi li laso
        public Chain ExpandedToChain()
        {
            List<HeadedPhrase> l = new List<HeadedPhrase>();
            foreach (Word modifier in phrase.Modifiers)
            {
                WordSet modifiers= new WordSet();
                modifiers.Add(modifier);
                l.Add(new HeadedPhrase(phrase.Head, modifiers));
            }
            Chain c = new Chain( Particles.en, l.ToArray());
            return c;
        }

        public Sentence ExpandedToSentence(string format)
        {
            throw new NotImplementedException();
        }
    }
}
