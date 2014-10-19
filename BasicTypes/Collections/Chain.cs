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
    public class Chain : IContainsWord, IFormattable
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
            this.chainType = type;
            this.particle = particle;
            this.headedPhrases = headedPhrases;
        }

        public Chain(ChainType type, Particle particle, Chain[] subChains)
        {
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
            if (subChains != null)
            {
                List<string> sb = new List<string>();
                //sb.Add("[");

                //Tracers.Stringify.TraceInformation("We have " + SubChains.Count() + " " + Particle.ToString() + " subChains");
                 
                ProcessSubChain(format, sb, subChains);
                //sb.Add("]");


                return sb.SpaceJoin(format);
            }


            if (HeadedPhrases != null)
            {
                List<string> sb = new List<string>();
                sb.AddRange(particle,HeadedPhrases.Select(phrase => phrase.ToString(format)));
                return sb.SpaceJoin(format);
            }
            else
            {
                return "[Error NULL HeadedPhrases-- This is a problem because this his leaf data.]";
            }
        }

        private void ProcessSubChain(string format,  List<string> sb, Chain[] innerChains)
        {
            int i = 0;
            foreach (Chain subChain in innerChains)
            {
                i++;
                if (particle.MiddleOnly && i != 1)
                {
                    sb.Add(particle.ToString());
                }
                if (!particle.MiddleOnly)
                {
                    sb.Add(particle.ToString());
                }

                //Tracers.Stringify.TraceInformation("At Leaf " + subChain.HeadedPhrases + "  headed phrases (i.e. no particles)");

                if (subChain.HeadedPhrases != null)
                {
                    //LEAF
                    sb.AddRange(subChain.Particle, subChain.HeadedPhrases.Select(phrase => phrase.ToString(format)));
                    //Tracers.Stringify.TraceInformation(sb.SpaceJoin(format) + " ... so far");
                }
                else
                {
                    foreach (Chain inner in subChain.SubChains )
                    {
                        ProcessSubChain(format, sb, subChain.SubChains);    
                    }
                    //int j = 0;


                    //foreach (Chain subSub in subChain.SubChains)
                    //{
                    //    j++;
                    //    if (subSub.Particle.MiddleOnly && j != 1)
                    //    {
                    //        sb.Add(subSub.Particle.ToString());
                    //    }
                    //    if (!subSub.Particle.MiddleOnly)
                    //    {
                    //        sb.Add(subSub.Particle.ToString());
                    //    }

                    //    sb.Add(subChain.particle.ToString()); //li, prep, others lead with particle?
                    //    if (subSub.HeadedPhrases != null)
                    //    {
                    //        sb.AddRange(subSub.Particle,
                    //            subSub.HeadedPhrases.Select(phrase => phrase.ToString(format)));
                    //    }
                    //    else
                    //    {
                    //        foreach (Chain chain in subSub.SubChains)
                    //        {
                    //        }
                    //        //TODO: Do we need recursion for arbitrary depth here?
                    //    }

                    //    //Tracers.Stringify.TraceInformation(sb.SpaceJoin(format) + " .... so far");
                    //}
                }
            }
        }

        public string ToString(string format)
        {
            return this.ToString(format, System.Globalization.CultureInfo.CurrentCulture);
        }

        public override string ToString()
        {
            return this.ToString(null, System.Globalization.CultureInfo.CurrentCulture);
        }

        public static Chain Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("value is null or zero length string");
            }
            return ChainTypeConverter.Parse(value);
        }

        public static bool TryParse(string value, out Chain result)
        {
            try
            {
                result = ChainTypeConverter.Parse(value);
                return true;
            }
            catch (Exception)
            {
                result = null;
                return false;
                
            }
        }
    }
}
