using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;
using BasicTypes.Diagnostics;
using BasicTypes.Extensions;
using KellermanSoftware.CompareNetObjects;
using NUnit.Framework.Constraints;

namespace BasicTypes
{
    public enum ChainType
    {
        None = 0,
        Subjects = 1, //Chain of en
        NounVerbPhrase = 2,//Chain of pi (can be a VP
        Predicates = 3, //Chain of li
        Directs = 4,//Chain of e
        Prepositionals = 5, //Chain lon(*) (phrases split by any prep)
        Fragments = 6
    }

    //Chains of particles
    [DataContract]
    [Serializable]
    public partial class Chain : IContainsWord, IFormattable
    {
        [DataMember(IsRequired = true)]
        readonly ChainType chainType;
        [DataMember(IsRequired = true)]
        readonly Particle particle;
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        readonly HeadedPhrase[] headedPhrases;
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        readonly Chain[] subChains;

        public Chain(ChainType type, Particle particle, HeadedPhrase[] headedPhrases)
        {
            if (headedPhrases.Length == 0)
            {
                throw new InvalidOperationException("Chain with no headed phrases. This would be a bare particle if written as text");
            }
            this.chainType = type;
            this.particle = particle;
            this.headedPhrases = headedPhrases;
        }

        public Chain(ChainType type, Particle particle, Chain[] subChains)
        {
            if (subChains ==null || subChains.Length == 0)
            {
                throw new InvalidOperationException("Chain with no no subchains. This would be a bare particle if written as text");
            }

            foreach (Chain subChain in subChains)
            {
                bool hasHeadedPhrase = subChain.HeadedPhrases != null && subChain.HeadedPhrases.Length > 0;
                bool hasSubSubChain = subChain.subChains != null && subChain.subChains.Length > 0;
                if (!hasHeadedPhrase && ! hasSubSubChain)
                {
                    throw new InvalidOperationException("Subchain with no subchains or headed phrases. This would be a bare particle if written as text");
                }   
            }
            
            this.chainType = type;
            this.particle = particle;
            this.subChains = subChains;
        }

        public ChainType ChainType { get { return chainType; } }
        public Particle Particle { get { return particle; } }
        public HeadedPhrase[] HeadedPhrases { get { return headedPhrases; } }
        public Chain[] SubChains { get { return subChains; } }

        public bool Contains(Word word)
        {
            if (HeadedPhrases == null) return false;
            if (HeadedPhrases.Length == 0) return false;
            return HeadedPhrases.Any(x => x.Contains(word));
        }



        public string ToString(string format, IFormatProvider formatProvider)
        {
            List<string> sb = ToTokenList(format, formatProvider);

            return sb.SpaceJoin(format);
            
        }

        public List<string> ToTokenList(string format, IFormatProvider formatProvider)
        {
            List<string> sb = new List<string>();

            if (subChains != null)
            {
                ProcessSubChain(format,formatProvider, sb, subChains);
            }
            else if (HeadedPhrases != null)
            {
                sb.AddRange(particle, HeadedPhrases.Select(phrase => phrase.ToString(format, formatProvider)), format, formatProvider);
            }
            else
            {
                throw new InvalidOperationException("No sub chain, no head phrase");
            }
            return sb;
        }

        private void ProcessSubChain(string format, IFormatProvider formatProvider, List<string> sb, Chain[] innerChains)
        {
            int i = 0;
            foreach (Chain subChain in innerChains)
            {
                i++;
                if (particle.MiddleOnly && i != 1)
                {
                    sb.Add(particle.ToString(format,formatProvider));
                }
                if (!particle.MiddleOnly)
                {
                    sb.Add(particle.ToString(format, formatProvider));
                }

                //Tracers.Stringify.TraceInformation("At Leaf " + subChain.HeadedPhrases + "  headed phrases (i.e. no particles)");

                if (subChain.HeadedPhrases != null)
                {
                    //LEAF
                    sb.AddRange(subChain.Particle, subChain.HeadedPhrases.Select(phrase => phrase.ToString(format, formatProvider)), format, formatProvider);
                    //Tracers.Stringify.TraceInformation(sb.SpaceJoin(format) + " ... so far");
                }
                else
                {
                    foreach (Chain inner in subChain.SubChains )
                    {
                        if (inner.headedPhrases != null)
                        {
                            sb.AddRange(inner.Particle, inner.HeadedPhrases.Select(phrase => phrase.ToString(format, formatProvider)),format, formatProvider);
                        }
                        else
                        {
                            ProcessSubChain(format,formatProvider, sb, inner.SubChains);    
                        }
                    }
                }
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

    }
}
