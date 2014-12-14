using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;

namespace BasicTypes.Collections
{
    /// <summary>
    /// Stuff after the first li, never itself contains li.
    /// </summary>
    [DataContract]
    [Serializable]
    public class PiPredicate : IContainsWord, IFormattable, IToString
    {
        [DataMember]
        private readonly Particle particle;

        [DataMember]
        private readonly ComplexChain nounPhrase;

        public PiPredicate(Particle particle, ComplexChain nounPhrase)
        {
            this.particle = particle;
            this.nounPhrase = nounPhrase;
        }

        public bool Contains(Word word)
        {
            if(word.Text == particle.Text)return true;
            return nounPhrase.Contains(word);
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

            sb.Add(particle.ToString(format, formatProvider));

            foreach (ComplexChain chain in new[] { nounPhrase })
            {
                if (chain == null) continue;
                sb.Add("{");
                sb.AddRange(chain.ToTokenList(format, formatProvider));
                sb.Add("}");
            }

            return sb;
        }
    }
}
