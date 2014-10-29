using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Exceptions;
using BasicTypes.Extensions;

namespace BasicTypes.Collections
{
    //Stuff after the 1st li, never itself contains li.
    [DataContract]
    [Serializable]
    public class TpPredicate : IContainsWord, IFormattable, IToString
    {
        [DataMember]
        private readonly Particle particle;

        [DataMember]
        private readonly HeadedPhrase verbPhrases;
        [DataMember]
        private readonly Chain directs;
        [DataMember]
        private readonly Chain prepositionals;
        [DataMember]
        private readonly Chain nominalPredicate;
        public TpPredicate(Particle particle, Chain nominalPredicate, Chain directs, Chain prepositionals)
        {
            if (particle.Text != Particles.o.Text && particle.Text != Particles.li.Text)
            {
                throw new TpSyntaxException("Tp Predicate can only have a Predicate headed by li or o-- got " + particle.Text);
            }
            if (nominalPredicate == null && prepositionals == null)
            {
                throw new TpSyntaxException("A nominal predicate phrase or prepositional phrase required. (Directs are optional)");
            }
            if (nominalPredicate == null && directs == null && prepositionals == null)
            {
                throw new TpSyntaxException("Nominal Predicate, directs(transformatives) and prepositional phrases all null, not good");
            }

            //TODO: Validate. 
            this.particle = particle;//li or o
            this.nominalPredicate= nominalPredicate; //only pi, en
            this.directs = directs;//only e, pi, en
            this.prepositionals = prepositionals;//only ~prop, pi, en 
        }

        public TpPredicate(Particle particle,  HeadedPhrase verbPhrases, Chain directs, Chain prepositionals)
        {
            if (particle.Text != Particles.o.Text && particle.Text != Particles.li.Text)
            {
                throw new TpSyntaxException("Tp Predicate can only have a Predicate headed by li or o-- got " + particle.Text);
            }
            if (verbPhrases == null && prepositionals == null)
            {
                throw new TpSyntaxException("A verb phrase or prepositional phrase required. (Directs are optional)");
            }
            if (verbPhrases ==null && directs==null && prepositionals ==null)
            {
                throw new TpSyntaxException("Verb, directs and prepositional phrases all null, not good");
            }

            //TODO: Validate. 
            this.particle = particle;//li or o
            this.verbPhrases = verbPhrases; //only pi, en
            this.directs = directs;//only e, pi, en
            this.prepositionals = prepositionals;//only ~prop, pi, en 
        }

        public Particle Particle { get { return particle; } }
        public HeadedPhrase VerbPhrases { get { return verbPhrases; } }
        public Chain Directs { get { return directs; } }
        public Chain Prepositionals { get { return prepositionals; } }
        public Chain NominalPredicate { get { return nominalPredicate; } }

        public bool Contains(Word word)
        {
            List<IContainsWord> chains = new List<IContainsWord>() { verbPhrases, directs, prepositionals };
            return chains.Any(x => x != null && x.Contains(word));
        }

        public string[] SupportedsStringFormats
        {
            get
            {
                return new string[] { "g" };
            }
        }

        public string ToString(string format)
        {
            return this.ToString(format, Config.CurrentDialect);
        }

        public override string ToString()
        {
            return this.ToString(null, Config.CurrentDialect);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            //Mixture of adding words, phrases adn brackets. Ugly.
            var sb = ToTokenList(format, formatProvider);
            return sb.SpaceJoin(format);
        }

        public List<string> ToTokenList(string format, IFormatProvider formatProvider)
        {
            List<string> sb = new List<string>();

            sb.Add(verbPhrases.Head.ToString());
            sb.AddRange(verbPhrases.Modifiers.Select(x => x.ToString(format, formatProvider)));


            foreach (Chain chain in new[] {directs, Prepositionals})
            {
                if (chain == null) continue;

                if (chain.HeadedPhrases != null)
                {
                    sb.Add("{");
                    if (chain.HeadedPhrases.Any())
                    {
                        sb.Add(chain.Particle.ToString(format, formatProvider));
                    }
                    foreach (HeadedPhrase headedPhrase in chain.HeadedPhrases)
                    {
                        sb.Add(headedPhrase.ToString(format, formatProvider));
                    }
                    sb.Add("}");
                }
            }
            return sb;
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
