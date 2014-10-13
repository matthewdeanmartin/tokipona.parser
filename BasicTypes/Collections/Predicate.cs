using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Collections
{
    //Stuff after the 1st li, never itself contains li.
    [DataContract]
    [Serializable]
    public class TpPredicate : IContainsWord
    {
        [DataMember]
        private readonly HeadedPhrase verbPhrases;
        [DataMember]
        private readonly Chain directs;
        [DataMember]
        private readonly Chain prepositionals;

        public TpPredicate(HeadedPhrase verbPhrases, Chain directs, Chain prepositionals)
        {
            //TODO: Validate. 
            this.verbPhrases = verbPhrases; //only pi, en
            this.directs = directs;//only e, pi, en
            this.prepositionals = prepositionals;//only ~prop, pi, en
        }
        public HeadedPhrase VerbPhrases { get { return verbPhrases; } }
        public Chain Directs { get { return directs; } }
        public Chain Prepositionals { get { return prepositionals; } }
        public bool Contains(Word word)
        {
            List<IContainsWord> chains = new List<IContainsWord>() { verbPhrases, directs, prepositionals };
            return chains.Any(x => x != null && x.Contains(word));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(verbPhrases.ToString());

            foreach (Chain chain in new []{directs,Prepositionals})
            {
                if(chain==null)continue;
                sb.Append(" ");
                if (chain.HeadedPhrases.Any())
                {
                    sb.Append(chain.Particle);
                }
                foreach (HeadedPhrase headedPhrase in chain.HeadedPhrases)
                {
                    sb.Append(" ");
                    sb.Append(headedPhrase.Head);
                    
                    sb.Append(" ");
                    sb.Append(headedPhrase.Modifiers);

                    //if (headedPhrase.SubPhrases != null)
                    //{
                    //    foreach (HeadedPhrase subPhrase in headedPhrase.SubPhrases)
                    //    {
                    //        sb.Append(" ");
                    //        sb.Append(subPhrase.Head);

                    //        sb.Append(" ");
                    //        sb.Append(subPhrase.Modifiers);

                    //        //TODO: uhoh needto recurse
                    //    }
                    //}
                    
                }
            }
            return sb.ToString();
        }
    }

    public class TpPredicateByValue : EqualityComparer<TpPredicate>
    {
        private static readonly TpPredicateByValue instance = new TpPredicateByValue();
        public static TpPredicateByValue Instance { get { return instance; } }

        static TpPredicateByValue() { }
        private TpPredicateByValue() { }

        public override bool Equals(TpPredicate x, TpPredicate y)
        {
            return ChainByValue.Instance.Equals(x.Directs, y.Directs)
                   && ChainByValue.Instance.Equals(x.Prepositionals, y.Prepositionals)
                   && HeadPhraseByValue.Instance.Equals(x.VerbPhrases, y.VerbPhrases);
        }

        public override int GetHashCode(TpPredicate obj)
        {
            throw new NotImplementedException();
        }
    }
}
