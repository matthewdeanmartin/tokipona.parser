using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;
using NUnit.Framework.Constraints;
//using Polenter.Serialization.Advanced.Serializing;

namespace BasicTypes.Collections
{
    //Series of Chains joined by the same particle.
    [DataContract]
    [Serializable]
    public class ComplexChain : IContainsWord, IFormattable, IToString
    {
        public static ComplexChain SinglePiEnChainFactory(HeadedPhrase phrase)
        {
            Chain piChain = new Chain(Particles.pi, new HeadedPhrase[] { phrase });
            ComplexChain c = new ComplexChain(Particles.en, new Chain[] { piChain });
            return c;
        }
        public static ComplexChain SinglePiEnChainFactory(HeadedPhrase[] phrases)
        {
            Chain piChain = new Chain(Particles.pi, phrases);
            ComplexChain c = new ComplexChain(Particles.en, new Chain[] { piChain });
            return c;
        }

        /// <summary>
        /// e soweli lili
        /// </summary>
        public static ComplexChain SingleEPiChainFactory(HeadedPhrase phrase)
        {
            Chain piChain = new Chain(Particles.pi, new HeadedPhrase[] { phrase });
            ComplexChain directs = new ComplexChain(Particles.e, new[] { piChain });
            return directs;
        }
        public static ComplexChain SingleEPiChainFactory(HeadedPhrase[] phrases)
        {
            Chain piChain = new Chain(Particles.pi, phrases);
            ComplexChain directs = new ComplexChain(Particles.e, new[] { piChain });
            return directs;
        }



        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        private readonly Particle particle;

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        private readonly Chain[] subChains; //(x pi y pi z) en A en B 

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        private readonly ComplexChain[] complexChains; //  kepeken (x pi y pi z) en A en B // kepeken

        public Particle Particle { get { return particle; } }

        public Chain[] SubChains { get { return subChains; } }

        public ComplexChain[] ComplexChains { get { return complexChains; } }

        private object parentChain;

        public object ParentChain
        {
            get { return parentChain; }
            private set { parentChain = value; }
        }

        public ComplexChain(Particle particle, ComplexChain[] complexChains)
        {
            if (string.IsNullOrWhiteSpace(particle.Text))
            {
                throw new InvalidOperationException("Particle required, blank particles no longer allowed.");
            }
            if (complexChains == null || complexChains.Length == 0)
            {
                throw new InvalidOperationException("complexChains list required else we'd have a bare particle.");
            }
            this.particle = particle;
            this.complexChains = complexChains;
            //foreach (Chain subChain in subChains)
            //{
            //    subChain.ParentChain = this;
            //}

        }

        public ComplexChain(Particle particle, Chain[] subChains)
        {
            if (string.IsNullOrWhiteSpace(particle.Text))
            {
                throw new InvalidOperationException("Particle required, blank particles no longer allowed.");
            }
            if (subChains == null || subChains.Length == 0)
            {
                throw new InvalidOperationException("Chain with no no subchains. This would be a bare particle if written as text");
            }

            this.particle = particle;
            this.subChains = subChains;
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

            if (subChains != null)
            {
                int i = 0;
                if(subChains!=null && subChains.Length>0)
                    sb.AddIfNeeded("(-", format);

                foreach (Chain chain in subChains)
                {
                    //have to check because of e.
                    if (particle.MiddleOnly && i == 0)
                    {

                    }
                    else
                    {
                        sb.Add(particle.ToString(format, formatProvider));
                    }
                    sb.AddRange(chain.ToTokenList(format, formatProvider));
                    i++;
                }
                if (subChains != null && subChains.Length > 0)
                   sb.AddIfNeeded("-)", format);

            }
            if (complexChains != null)
            {
                int i = 0;
                if (complexChains != null && complexChains.Length > 0)
  
                sb.AddIfNeeded("{",format);
                foreach (ComplexChain chain in complexChains)
                {
                    //have to check because of e.
                    if (particle.MiddleOnly && i == 0)
                    {

                    }
                    else
                    {
                        sb.Add(particle.ToString(format, formatProvider));
                    }

                    sb.AddRange(chain.ToTokenList(format, formatProvider));
                    i++;
                }
                if (complexChains != null && complexChains.Length > 0)
  
                sb.AddIfNeeded("}", format);
            }
            //else 
            return sb;
        }


        public string[] SupportedsStringFormats
        {
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

        public bool Contains(Word word)
        {
            if (complexChains != null)
            {
                foreach (ComplexChain complexChain in complexChains)
                {
                    if (complexChain.Contains(word)) return true;
                }
            }

            if (subChains != null)
            {
                foreach (Chain chain in subChains)
                {
                    if (chain.Contains(word)) return true;
                }
            }
            //What about particles?
            return false;
        }

        public static ComplexChain Parse(string value)
        {
            Dialect c = Dialect.LooseyGoosey;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            if (value.ContainsCheck(" e ") || value.StartCheck("e "))
            {
                throw new NotImplementedException();
                //return pu.ProcessEnPiChain(value);
            }

            //other kinds of complex chains

            //pi and en
            return pu.ProcessEnPiChain(value);
        }

    }
}
