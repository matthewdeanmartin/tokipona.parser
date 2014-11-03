using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Exceptions;

namespace BasicTypes.CollectionsDegenerate
{
    //pona a! o! ike! pakala!
    //I don't think these have any interesting internal grammar.
    public class Exclamation
    {
        [DataMember]
        private readonly WordSet wordSet;
        public Exclamation(WordSet wordSet)
        {
            if (wordSet == null)
            {
                throw new TpSyntaxException("Arg required");
            }
            this.wordSet = wordSet;
        }

        public WordSet Phrase { get { return wordSet; } }

        public List<string> ToTokenList(string format, IFormatProvider formatProvider)
        {
            List<string> sb = new List<string>();
            sb.AddRange(wordSet.ToTokenList(format, formatProvider));
            return sb;
        }

        public static string[] Exclamations
        {
            get
            {
                return new string[]
                {
                    "a","ala","ike","jaki","mu","o","pakala","pona","toki"
                };
            }
        }


        public static bool IsExclamation(string word)
        {
            string token = word.Trim(new char[] { ',', '«', '»','!',' ' });
            return Exclamations.Contains(token.Trim());
        }
    }
}
