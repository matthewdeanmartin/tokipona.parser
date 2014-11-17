using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;

namespace BasicTypes.Collections
{
    //Series of Chains joined by the same particle.
    public class ComplexChain
    {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        private readonly Particle particle;
        
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        private readonly Chain[] subChains; //(x pi y pi z) en A en B 

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        private readonly ComplexChain[] complexChains; //  kepeken (x pi y pi z) en A en B // kepeken

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
            this.particle = particle;
            this.complexChains = complexChains;
            //foreach (Chain subChain in subChains)
            //{
            //    subChain.ParentChain = this;
            //}

        }

        public ComplexChain(Particle particle, Chain[] subChains)
        {
            
            if (subChains ==null || subChains.Length == 0)
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
                ProcessSubChain(format,formatProvider, sb, subChains);
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


        private void ProcessSubChain(string format, IFormatProvider formatProvider, List<string> sb, Chain[] innerChains)
        {
            int i = 0;
            foreach (Chain subChain in innerChains)
            {
                //This seems to work for (..pi...)en(...pi..) phrases
                i++;
                if (particle.MiddleOnly && i != 1)
                {
                    sb.AddIfNotReduplicate(particle.ToString(format, formatProvider));
                }
                if (!particle.MiddleOnly)
                {
                    sb.AddIfNotReduplicate(particle.ToString(format, formatProvider));
                }

                //Tracers.Stringify.TraceInformation("At Leaf " + subChain.HeadedPhrases + "  headed phrases (i.e. no particles)");

                if (subChain.HeadedPhrases != null)
                {
                    //LEAF
                    sb.AddRange(subChain.Particle, subChain.HeadedPhrases.Select(phrase => phrase.ToString(format, formatProvider)), format, formatProvider, subChain.ParentChain != null);
                    //Tracers.Stringify.TraceInformation(sb.SpaceJoin(format) + " ... so far");
                }
                else
                {
                    foreach (Chain inner in subChain.SubChains)
                    {
                        if (inner.headedPhrases != null)
                        {
                            sb.AddRange(inner.Particle, inner.HeadedPhrases.Select(phrase => phrase.ToString(format, formatProvider)), format, formatProvider, inner.ParentChain != null);
                        }
                        else
                        {
                            if (subChain.Particle != null && Particle.CheckIsPreposition(subChain.Particle.Text))
                            {
                                sb.AddIfNotReduplicate(subChain.Particle.Text);
                            }
                            ProcessSubChain(format, formatProvider, sb, inner.SubChains);
                        }
                    }
                }
            }
        }

    }
}
