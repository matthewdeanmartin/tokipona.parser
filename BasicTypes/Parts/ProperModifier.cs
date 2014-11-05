using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Dictionary;
using BasicTypes.Exceptions;
using BasicTypes.Extensions;

namespace BasicTypes.Parts
{
    public class ProperModifier: Token
    {
        internal ProperModifier()
        {
            //For XML serialization only.
        }

        public ProperModifier(string word):base(word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("word", "Can't construct words with null");
            }
            word = ProcessPuncuation(word);
            //Too many bad modifiers in the wild!
            if (!IsProperModifer(LookupForm(word))) 
            {
                throw new ArgumentNullException("word", "Doesn't meet requirements for proper modifer (upper cased first initial etc) " + word);
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


        //Probably should be an override of an abstract method.
        public string TryGloss(string language, string pos)
        {
            
            Dictionary<string, Dictionary<string, string[]>> glossMap;
            CompoundWords.Glosses.TryGetValue(LookupForm(word), out glossMap);

            if (glossMap == null)
            {
                //TODO: Need a dictionary of proper modifiers.
                return Text;

                //return "[missing map for " + Text + "]";
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
                return "[PM-Error  " + Text + " " + language + "]";//don't have by-POS glossing for comound words. Sort of assumed they are all content words.
            }
            else
                return Text;
        }

        /// <summary>
        /// Weak test, only checks capitalization, not phonotactics.
        /// </summary>
        public static bool IsProperModifer(string text)
        {
            //Degenerate cases.
            if(string.IsNullOrWhiteSpace(text))
                return false;

            if (text[0] == '"')
                return false; //Foreign text

            if (text[0] == '#')
                return false; //Number

            //People make so many mistakes-- this may confuse matters. 
            //Really need a "probably is modifier"
            foreach (char c in text.ToLower())
            {
                if (!"jklmnpstwaeiou".Contains(c))
                {
                    return false; //Foreign text. Really a different thing.
                }
            }

            
            if (text.IsFirstUpperCased())
            {
                return true;
            }
            return false;
        }

        public static bool IsValidProperModifer(string text)
        {
            //Degenerate cases.
            if (string.IsNullOrWhiteSpace(text))
                return false;

            foreach (char c in text)
            {
                if (!"jklmnpstwaeiou".Contains(c))
                {
                    return false; //Foreign text. Really a different thing.
                }    
            }

            //Mato > cap-lower-lower-etc
            for (int index= 0; index < text.Length; index++)
            {
                if (index == 0)
                {
                    if (text[0].ToString() != text[0].ToString().ToUpper())
                    {
                        return false;
                    }
                }
                else
                {
                    if (text[0].ToString() != text[0].ToString().ToLower())
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
