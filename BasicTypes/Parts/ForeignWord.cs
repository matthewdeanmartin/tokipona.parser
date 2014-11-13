using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Exceptions;
using BasicTypes.Transliterate;

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

        [DataMember(IsRequired = false,EmitDefaultValue = false)]
        private readonly Dictionary<string, Dictionary<string, string[]>> glossMap;

        public ForeignWord(string word):base(word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("word", "Can't construct words with null");
            }
            word = ProcessPuncuation(word);
            //!word.Contains("*")  foreign word might have no spaces
            if (word.Contains(" "))
            {
                throw new ArgumentNullException("word", "Normalized foreign words and phrases can have *, but no spaces [" + word + "]");
            }
            if (!(word.EndsWith("\"") && word.StartsWith("\"")))
            {
                throw new InvalidLetterSetException("Must be bracketed by double quotes ["+ word +"]");
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

        public string TryGloss(string language, string pos)
        {
            return "\"" + Text + "\"";
        }

        public string Transliterate(Options options=null)
        {
            if (options == null)
            {
                options = new Options()
                {
                    ConsonantCluster = ClusterPreference.Merge,
                    IsFinalEPronounced = false,
                    NeutralConsonant = "j",
                    NeutralVowel = "o",
                    RLanguage = LanguageForR.English,
                    SorT = "s",
                    VowelCluster = ClusterPreference.Merge
                };
            }
            TransliterateEngine engine = new TransliterateEngine();
            string trace;
            string plain = Text.Replace("*", " ").Replace(@""""," ");
            return engine.Transliterate(plain, out trace, options);
        }
    }
}
