using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;
using BasicTypes.Exceptions;

namespace BasicTypes.CollectionsDegenerate
{
    //Well, they aren't sentences. Spelling would be the same structure.
    //wan, tu, mute, mute, mute, mute, mute, mute.
    //wan, tu.
    //wan, tu, mute, mute.
    [DataContract]
    [Serializable]
    public class Counting: IContainsWord, IFormattable, IToString
    {
        //Order is significant. There is no head.
        [DataMember]
        private readonly WordList wordSet;
        public Counting(WordList wordSet)
        {
            if (wordSet == null)
            {
                throw new TpSyntaxException("Arg required");
            }
            this.wordSet = wordSet;
        }

        public WordList Phrase { get { return wordSet; } }

        public List<string> ToTokenList(string format, IFormatProvider formatProvider)
        {
            List<string> sb = new List<string>();
            sb.AddRange(wordSet.ToTokenList(format, formatProvider));
            return sb;
        }

        public bool Contains(Word word)
        {
            if (wordSet != null)
            {
                return wordSet.Contains(word);
            }
            return false;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (wordSet != null)
            {
                return wordSet.ToString(format, formatProvider);
            }
            return "";
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
