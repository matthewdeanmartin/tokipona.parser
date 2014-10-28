using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Exceptions;
using BasicTypes.MoreTypes;

namespace BasicTypes.Parts
{
    //To do realistic parsing, we must break the illusion about how many lexemes we have
    // jan pona != jan-pona.
    // BUT
    // tomo pi telo nasa ==> tomo mute pi telo nasa   (Dear me, it's an infix)
    // 
    public class CompoundWord : Token
    {
        internal CompoundWord()
        {
            //For XML serialization only.
        }

        [DataMember(IsRequired = true)]
        private readonly string word;

        
        public CompoundWord(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("word", "Can't construct words with null");
            }
            if (!word.Contains("-") || word.Contains(" "))
            {
                throw new ArgumentNullException("word", "Compound words must have dashes, but no spaces");
            }
            if (word.IndexOfAny(new char[] { '.', ' ', '?', '!' }) != -1)
            {
                throw new InvalidLetterSetException("Words must not have spaces or punctuation, (other than the preposition marker ~)");
            }

            //Validate

            this.word = word;
        }
        
        public Word[] Parts
        {
            get 
            { 
                return word.Split('-').Select(x=>new Word(x)).ToArray();
            }
        }

    }
}
