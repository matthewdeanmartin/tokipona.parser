using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using BasicTypes.Extensions;
using BasicTypes.Parts;
// soweli lili en waso suli en kala loje --- headed phrases joined by en
// soweli pi ma suli en waso pi ma lili --- headed phrases joined by pi in turn joined by en 
// soweli pi ma suli ~lon sike pi mi mute ---- headed phrase with prep modifier.


namespace BasicTypes
{
    /// <summary>
    /// Headed phrases joined by one particles. Cannot contain any other chains! (so mostly pi, maybe o)
    /// </summary>
    [DataContract]
    [Serializable]
    public partial class Chain : IContainsWord, IFormattable, IToString
    {
        public static Chain PiChainFactory(HeadedPhrase[] phrases)
        {
            return new Chain(Particles.pi, phrases);
        }
        public static Chain PiChainFactory(HeadedPhrase phrase)
        {
            return new Chain(Particles.pi, new[] { phrase });
        }

        [DataMember(IsRequired = true)]
        readonly Particle particle;
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        readonly HeadedPhrase[] headedPhrases;
        
        private Chain parentChain;

        public Chain(Particle particle, HeadedPhrase[] headedPhrases)
        {
            if (headedPhrases.Length == 0)
            {
                throw new InvalidOperationException("Chain with no headed phrases. This would be a bare particle if written as text");
            }
            this.particle = particle;
            this.headedPhrases = headedPhrases;
        }

        public Particle Particle { get { return particle; } }
        public HeadedPhrase[] HeadedPhrases { get { return headedPhrases; } }
 
        public Chain ParentChain { get { return parentChain; } }

        public bool Contains(Word word)
        {
            if (HeadedPhrases == null) return false;
            if (HeadedPhrases.Length == 0) return false;
            return HeadedPhrases.Any(x => x.Contains(word));
        }



        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
            {
                format = "g";
            }
            List<string> sb = ToTokenList(format, formatProvider);

            return sb.SpaceJoin(format);
            
        }

        public List<string> ToTokenList(string format, IFormatProvider formatProvider)
        {
            List<string> sb = new List<string>();

            if (HeadedPhrases != null)
            {
                sb.AddRange(particle, HeadedPhrases.Select(phrase => phrase.ToString(format, formatProvider)), format, formatProvider,parentChain!=null);
            }
            else
            {
                throw new InvalidOperationException("No head phrases");
            }
            return sb;
        }


        public string[] SupportedsStringFormats {
            get
            {
                return new[] { "g" };
            } 
        }

        public string ToString(string format)
        {
            if (format == null)
            {
                format = "g";
            }
            return ToString(format, Config.CurrentDialect);
        }

        public override string ToString()
        {
            return ToString("g", Config.CurrentDialect);
        }

        public static bool IsPlural(Chain value)
        {
            foreach (string s in Token.SemanticallyPlural)
            {
                //PERF: uh oh.
                if (value.Contains(new Word(s))) return true;
            }
            
            //Other numbers need to detect.
            foreach (HeadedPhrase phrase in value.HeadedPhrases)
            {
                if (Number.IsNumber(phrase)) return true;
            }
            return false;
        }
    }


    //public enum ChainType
    //{
    //    None = 0,
    //    Subjects = 1, //Chain of en
    //    NounVerbPhrase = 2,//Chain of pi (can be a VP
    //    Predicates = 3, //Chain of li
    //    Directs = 4,//Chain of e
    //    MixedPrepositional= 5,
    //    Prepositionals = 6, //Chain lon(*) (phrases split by any prep)
    //    Fragments = 7
    //}

}
