using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;

namespace BasicTypes.Collections
{
    //jan (lon ma ni) suli li moku  => :-(
    //jan suli (lon ma ni) lil moku => ah ha! works only for tail.
    //jan suli lon ma ni kepeken len laso li moku ==> should chain
    //jan suli pi (lon ma ni pi kepeken len laso) pona => :-( even with pi, words gotta go first.
    //Either a word or a prepositional phrase, or a en chain.
    [DataContract]
    [Serializable]
    [Obsolete]
    public class ModiferPhrase : IContainsWord, IFormattable, IToString
    {
        [DataMember]
        private readonly PrepositionalPhrase prepositionalPhrase;

        [DataMember]
        private readonly Word word;

        public PrepositionalPhrase PrepositionalPhrase
        {
            get { return prepositionalPhrase; }
        }
        public Word Modifier
        {
            get { return word; }
        }
        public ModiferPhrase(PrepositionalPhrase prepositionalPhrase)
        {
            this.prepositionalPhrase = prepositionalPhrase;
        }

        public ModiferPhrase(Word word)
        {
            this.word = word;
        }

        public List<string> ToTokenList(string format, IFormatProvider formatProvider)
        {
            List<string> sb = new List<string>();
            if (word != null) sb.Add(word.ToString(format, formatProvider));
            if (prepositionalPhrase != null) sb.AddRange(prepositionalPhrase.ToTokenList(format, formatProvider));
            return sb;
        }

        public bool Contains(Word word)
        {
            if (WordByValue.Instance.Equals(word, this.word)) return true;
            return prepositionalPhrase.Contains(word);
        }

        public override string ToString()
        {
            return this.ToString("g", Config.CurrentDialect);

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

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
            {
                format = "g";
            }
            var words = ToTokenList(format, formatProvider);

            return words.SpaceJoin(format);
        }
    }
}
