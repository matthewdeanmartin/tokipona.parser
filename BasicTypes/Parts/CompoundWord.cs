using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Dictionary;
using BasicTypes.Exceptions;
using BasicTypes.Extensions;
using BasicTypes.MoreTypes;

namespace BasicTypes.Parts
{
    //To do realistic parsing, we must break the illusion about how many lexemes we have
    // jan pona != jan-pona.
    // BUT
    // tomo pi telo nasa ==> tomo mute pi telo nasa   (Dear me, it's an infix)
    [Serializable]
    public class CompoundWord : Token
    {
        internal CompoundWord()
        {
            //For XML serialization only.
        }

        public CompoundWord(string word):base(word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("word", "Cannot construct words with null");
            }
            word = ProcessPuncuation(word);
            if (!word.ContainsCheck("-") || word.ContainsCheck(" "))
            {
                throw new ArgumentNullException("word", "Compound words must have dashes, but no spaces");
            }
            if (word.IndexOfAny(new char[] { '.', ' ', '?', '!' }) != -1)
            {
                throw new InvalidLetterSetException("Words must not have spaces or punctuation, (other than the preposition marker ~) : " + word);
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


        //Probably should be an override of an abstract method.
        public string TryGloss(string language, string pos)
        {
           
            Dictionary<string, Dictionary<string, string[]>> glossMap;

            CompoundWords.Glosses.TryGetValue(LookupForm(word), out glossMap);

            if (glossMap == null)
            {
                return "[missing map for " + Text + "]";
            }
            if (glossMap.ContainsKey(language))
            {
                //if (glossMap[language].ContainsKey(pos))
                {
                    Random r = new Random(DateTime.Now.Millisecond);//TODO: Make this a part of config
                    string[] possibilities = glossMap[language][LookupForm(word)];//was [language][pos]
                    return possibilities[r.Next(possibilities.Length)];
                }
            }

            //TraceMissingGloss();

            if (!((Text.ToUpper())[0] == Text[0]))
            {
                return "[CW-Error  " + Text + " " + language + "]";//don't have by-POS glossing for comound words. Sort of assumed they are all content words.
            }
            else
                return Text;
        }

    }
}
