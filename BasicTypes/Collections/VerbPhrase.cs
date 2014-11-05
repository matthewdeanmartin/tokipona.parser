using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Collections
{
    [Serializable]
    [DataContract]
    public class VerbPhrase 
    {
        //Modals, pre-verbs, serial verbs
        //jan li wile tawa
        [DataMember]
        private WordSet modals;

        //jan li tawa
        [DataMember]
        private Word headVerb;

        //jan li tawa mute.
        [DataMember]
        private WordSet adverbs; //TODO: extend to include pi chains? li moku pi mute suli.

        //jan li tawa ma Wasinton
        [DataMember]
        private Chain nounComplement;

        public VerbPhrase(Word headVerb, WordSet modals = null, WordSet adverbs = null, Chain nounComplement = null)
        {
            this.headVerb = headVerb;
            this.modals = modals;
            this.adverbs = adverbs;
            this.nounComplement = nounComplement;
        }
    }
}
