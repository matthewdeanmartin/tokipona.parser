using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Exceptions;

namespace BasicTypes.Collections
{
    //It is a Pushmi-pullyu, 2 types in one!
    //La fragments.-- 2 sorts... 1 it is the whole sentence. That's it. 
    //2 - it is one of the many fragments tacked on to the front of a sentence to set time, topic, etc.
    //kin la? 
    [DataContract]
    [Serializable]
    public class Fragment : IContainsWord, IFormattable, IToString
    {
        [DataMember]
        private readonly ComplexChain nominal;

        [DataMember]
        private readonly PrepositionalPhrase[] prepositionals;

        public Fragment(PrepositionalPhrase[] prepositionals)
        {
            this.prepositionals = prepositionals;
        }

        public Fragment(ComplexChain nominal)
        {
            if (nominal == null)
            {
                throw new TpSyntaxException("Nominal required");
            }
            this.nominal= nominal;
        }

        public ComplexChain Nominal{ get { return nominal; } }
        public PrepositionalPhrase[] Prepositionals { get { return prepositionals; } }

        public List<string> ToTokenList(string format, IFormatProvider formatProvider)
        {
            List<string> sb = new List<string>();
            if (nominal != null)
            {
                sb.AddRange(nominal.ToTokenList(format, formatProvider));
            }
            else
            {
                foreach (PrepositionalPhrase phrase in Prepositionals)
                {
                    sb.AddRange(phrase.ToTokenList(format, formatProvider));    
                }
            }
            return sb;
        }

        public bool Contains(Word word)
        {
            if (nominal != null)
            {
                return nominal.Contains(word);
            }
            return Prepositionals.Any(phrase => phrase.Contains(word));
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (nominal != null)
            {
                return nominal.ToString(format, formatProvider);
            }
            StringBuilder sb= new StringBuilder();
            foreach (PrepositionalPhrase phrase in Prepositionals)
            {
                sb.Append(phrase.ToString(format, formatProvider));
                sb.Append(" ");
            }
            return sb.ToString();
        }

        public string[] SupportedsStringFormats { get; private set; }

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
    }
}
