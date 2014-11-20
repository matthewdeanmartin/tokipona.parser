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
    [DataContract]
    [Serializable]
    public class Exclamation
    {
        //Headed phrase can't be headed by a particle, but an exclamation can!
        [DataMember]
        private readonly HeadedPhrase wordSet;
        public Exclamation(HeadedPhrase wordSet)
        {
            if (wordSet == null)
            {
                throw new TpSyntaxException("Arg required");
            }
            this.wordSet = wordSet;
        }

        public HeadedPhrase Phrase { get { return wordSet; } }

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
                    //Ref: http://www2.hawaii.edu/~chin/661F12/Projects/ztomaszewski.pdf
                    // a | a a | a a a | ala | ike | jaki | mu | o | pakala | pona | toki
                      "a",              "ala","ike","jaki","mu","o","pakala","pona","toki"
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
