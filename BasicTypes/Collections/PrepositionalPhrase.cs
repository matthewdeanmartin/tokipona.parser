using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Exceptions;
using BasicTypes.Extensions;
using BasicTypes.Parser;

namespace BasicTypes.Collections
{
    //A special sort of headed phrase, can act as a modifier.
    [DataContract]
    [Serializable]
    public class PrepositionalPhrase : IContainsWord, IFormattable, IToString
    {
        //preposition
        [DataMember]
        private readonly Word preposition;

        //noun phrase (pi & en)
        [DataMember]
        private readonly ComplexChain complexChain;

        //1 of these per Different preps strung together  //~sama x ~sama x2 ~kepeken y
        public PrepositionalPhrase(Word preposition, ComplexChain complexChain)
        {
            if (Particles.Prepositions.Contains(preposition.Text))
            {
                preposition = new Word("~" + preposition.Text);
            }
            else if (!Particles.Prepositions.Contains(preposition.Text.Remove(0,1)))
            {
                throw new ArgumentException("Invlaid prep: " + preposition.Text);
            }
            if (complexChain == null)
            {
                throw new ArgumentNullException("prepositional phrases can't be a stand alone preposition");
            }
            this.preposition = preposition;
            this.complexChain = complexChain;
        }

        public Word Preposition {
            get { return preposition; }
        }
        public ComplexChain Complement
        {
            get { return complexChain; }
        }
        public static PrepositionalPhrase Parse(object value)
        {
            string item = value.ToString(); //unbox
            if (string.IsNullOrEmpty(item))
            {
                throw new ArgumentException("value is null or zero length string");
            }

            Dialect c = Dialect.DialectFactory;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            if (item.Contains("~"))
            {
                string[] parts = Splitters.SplitOnPrepositions(item);
                List<PrepositionalPhrase> chain = pu.ProcessPrepositionalPhrases(parts);
                if (chain.Count != 1)
                {
                    throw new InvalidOperationException("Tried to parse a single chain, but value contains " +
                                                        chain.Count);
                }
                return chain[0];
            }
            throw new TpParseException("Can't parse this to a prepositional phrase: " + value);
        }

        public List<string> ToTokenList(string format, IFormatProvider formatProvider)
        {
            List<string> sb = new List<string>();

            sb.Add(preposition.ToString(format,formatProvider));

            sb.AddRange(complexChain.ToTokenList(format, formatProvider));

            return sb;
        }

        public bool Contains(Word word)
        {
            if (WordByValue.Instance.Equals(word, preposition))
            {
                return true;
            }
            return complexChain.Contains(word);
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
