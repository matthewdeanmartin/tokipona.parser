using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Exceptions;

namespace BasicTypes.Parts
{
    //Fundamentally not glossable. 
    //If the utterance is foreign, then the intention is that that text stay foreign.
    //To attempt to parse it would be attempting to translate an arbitrary language into tp or english or whatever.
    [Serializable]
    public class ForeignWord: Token
    {
        internal ForeignWord()
        {
            //For XML serialization only.
        }

        [DataMember(IsRequired = true)]
        private readonly string word;

        [DataMember(IsRequired = false,EmitDefaultValue = false)]
        private readonly Dictionary<string, Dictionary<string, string[]>> glossMap;

        public ForeignWord(string word):base(word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("word", "Can't construct words with null");
            }
            if (!word.Contains("*") || word.Contains(" "))
            {
                throw new ArgumentNullException("word", "Normalized foreign words and phrases can have *, but no spaces");
            }
            if (!(word.EndsWith("\"") && word.StartsWith("\"")))
            {
                throw new InvalidLetterSetException("Must be bracketed by double quotes");
            }
            this.word = word;
        }


        //Not sure why this would be useful. 
        public Word[] Parts
        {
            get 
            { 
                return word.Split('*').Select(x=>new Word(x)).ToArray();
            }
        }
    }
}
