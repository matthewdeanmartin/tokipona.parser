using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;

namespace BasicTypes.Parts
{

    //
    //Not sure how this is to be distinguished from misspellings. (maybe via dialect-- treat new words as neologisms?)
    /// <summary>
    /// A new toki pona word of uncertain meaning.
    /// </summary>
    /// <remarks>
    ///  Glosses to itself in all languages. Can only be a content word. Appears only in strict parsing mode,
    /// in non-strict mode, we can only assume that this is a misspelling, foreign test or an uncapitalized 
    /// </remarks>
    public class Neologism:Token
    {

        public Neologism(string word)
        {
            if (Word.IsWord(word))
            {
                throw new InvalidOperationException("This is real word. Can't be a neologism.");
            }
            if (word.IsFirstUpperCased())
            {
                throw new InvalidOperationException("Uppercased, this acts like a proper modifier.");
            }

            if (Token.CheckIsValidPhonology(word))
            {
                throw new InvalidOperationException("Neologism must be a valid word phonotactically.");
            }
            this.word = word;
        }
    }
}
