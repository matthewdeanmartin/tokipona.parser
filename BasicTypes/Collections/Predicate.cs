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
    /// <summary>
    /// Stuff after the first li, never itself contains li.
    /// </summary>
    [DataContract]
    [Serializable]
    public class TpPredicate : IContainsWord, IFormattable, IToString
    {
        [DataMember]
        private readonly Particle particle;

        [DataMember]
        private readonly VerbPhrase verbPhrase; 

        [DataMember]
        private readonly Chain directs;
        [DataMember]
        private readonly Chain prepositionals;
        [DataMember]
        private readonly Chain nominalPredicate;

        public TpPredicate(Particle particle, Chain nominalPredicate, Chain directs = null, Chain prepositionals = null)
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

        public TpPredicate(Particle particle, VerbPhrase verbPhrase, Chain directs=null, Chain prepositionals=null)
        {
            if (particle.Text != Particles.o.Text && particle.Text != Particles.li.Text)
            {
                throw new TpSyntaxException("Tp Predicate can only have a Predicate headed by li or o-- got " + particle.Text);
            }
            if (verbPhrase == null && prepositionals == null)
            {
                throw new TpSyntaxException("A verb phrase or prepositional phrase required. (Directs are optional)");
            }
            if (verbPhrase ==null && directs==null && prepositionals ==null)
            {
                throw new TpSyntaxException("Verb, directs and prepositional phrases all null, not good");
            }

            //TODO: Validate. 
            this.particle = particle;//li or o
            this.verbPhrase = verbPhrase; //only pi, en
            if (directs != null && directs.Particle.Text != Particles.e.Text)
            {
                throw new TpSyntaxException("Directs must have e as the particle.");
            }

            this.directs = directs;//only e, pi, en

            if (prepositionals != null && prepositionals.Particle.Text != Particles.Blank)
            {
                throw new TpSyntaxException("Prepositional phrases are strung together by no particular particle.");
            }
            this.prepositionals = prepositionals;//only ~prop, pi, en 
        }

        public Particle Particle { get { return particle; } }
        public VerbPhrase VerbPhrase { get { return verbPhrase; } }
        public Chain Directs { get { return directs; } }
        public Chain Prepositionals { get { return prepositionals; } }
        public Chain NominalPredicate { get { return nominalPredicate; } }

        public bool Contains(Word word)
        {
            List<IContainsWord> chains = new List<IContainsWord>() { verbPhrase, directs, prepositionals };
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
            if (format == null)
            {
                format = "g";
            }
            return this.ToString(format, Config.CurrentDialect);
        }

        public override string ToString()
        {
            return this.ToString("g", Config.CurrentDialect);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
            {
                format = "g";
            }
            //Mixture of adding words, phrases adn brackets. Ugly.
            var sb = ToTokenList(format, formatProvider);
            return sb.SpaceJoin(format);
        }

        public List<string> ToTokenList(string format, IFormatProvider formatProvider)
        {
            List<string> sb = new List<string>();

            sb.AddRange(verbPhrase.ToTokenList(format, formatProvider));

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
            throw new NotImplementedException("Doh! Soon.");
            //return ChainByValue.Instance.Equals(x.Directs, y.Directs)
            //       && ChainByValue.Instance.Equals(x.Prepositionals, y.Prepositionals)
            //       && HeadPhraseByValue.Instance.Equals(x.VerbPhrase, y.VerbPhrase);
        }

        public override int GetHashCode(TpPredicate obj)
        {
            throw new NotImplementedException();
        }
    }
}
