using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;
using KellermanSoftware.CompareNetObjects;
using NUnit.Framework.Constraints;

namespace BasicTypes
{
    public enum ChainType
    {
        None = 0,
        Subjects = 1, //Chain of en
        NounVerbPhrase =2,//Chain of pi (can be a VP
        Predicates = 3, //Chain of li
        Directs = 4,//Chain of e
        Prepositionals = 5, //Chain lon(*) (phrases split by any prep)
        Fragments =6
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
            if (HeadedPhrases.Length==0) return false;
            return HeadedPhrases.Any(x => x.Contains(word));
        }



        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (subChains != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("[");
                int i = 0;
                foreach (Chain subChain in SubChains)
                {
                    i++;
                    if (i != 1)
                    {
                        sb.Append(" " + Particle.Text + " ");
                    }

                    if (subChain.HeadedPhrases != null)
                    {
                        sb.Append(string.Join(" " + subChain.Particle.Text + " ",
                            subChain.HeadedPhrases.Select(phrase => phrase.ToString(format)).ToArray()).Trim().Replace("  ", " "));
                    }
                    else
                    {
                        int j = 0;
                        foreach (Chain subSub in subChain.SubChains)
                        {
                            //j++;
                            //if (j != 1)
                            //{
                            //    sb.Append(" " + subSub.Particle + " ");
                            //}
                            sb.Append(string.Join(" " + subSub.Particle.Text + " ",
                            subSub.HeadedPhrases.Select(phrase => phrase.ToString(format)).ToArray()).Trim().Replace("  ", " "));

                            //TODO: Do we need recursion for arbitrary depth here?
                        }
                    }


                }
                sb.Append("]");

                if (format == null || format == "g")
                {
                    return sb.ToString().Replace("(", " ").Replace(")", " ").Replace("[", " ").Replace("]", " ");
                }
                else
                    return sb.ToString().Replace("()", " ").Replace("[]", " ");
            }


            if (HeadedPhrases != null)
            {
                return string.Join(" " + particle.Text + " ", HeadedPhrases.Select(phrase => phrase.ToString(format)).ToArray()).Trim().Replace("  ", " ");
            }
            else
            {
                return "[Error NULL HeadedPhrases-- This is a problem because this his leaf data.]";
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
            return ChainTypeConverter.Parse(value);
        }

        public static void TryParse(string value, out Chain result)
        {
            try
            {
                result = ChainTypeConverter.Parse(value);
            }
            catch (Exception)
            {
                result = null;
            }
        }
    }
}
