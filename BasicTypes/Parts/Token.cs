using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Parser;
using KellermanSoftware.CompareNetObjects;

namespace BasicTypes
{

    //Tokens are string wrappers around something that is a word.
    //You can string heterogenous types of tokens together to create phrases.
    //Maybe a token can be bracketed. Need to think about it.
    //Can work with a string where you don't know what it is yet.
    //Tokens don't have spaces, otherwise it makes it too hard to decide what is an atomic token
    //Can be punctuation.

    //Base class. 
    [DataContract]
    [Serializable]
    public class Token
    {
    
        [DataMember(IsRequired = true)]
        protected string word;

        public string Text { get { return word; } }

        [DataMember]
        protected  bool preComma;

        [DataMember]
        protected bool postComma;

        [DataMember]
        protected bool preQuote;

        [DataMember]
        protected bool postQuote;

        internal Token()
        {
            //For XML serialization only.
        }

        //The specific types have stricter constructors than the parent type.
        //And SO says that that is okay.
        //https://stackoverflow.com/questions/5490824/should-constructors-comply-with-the-liskov-substitution-principle
        public Token(string word, bool iAmAPrepositionChain = false)
        {
            if (!iAmAPrepositionChain)
            {
                if (String.IsNullOrWhiteSpace(word))
                {
                    throw new ArgumentNullException("word", "Token can't be null or white space");
                }
                if (word.Contains(" "))
                {
                    throw new ArgumentNullException("word",
                        "Token can't contain white space-- must use *, - or other punctuation to join words into a single token : " +
                        word);
                }
            }
            if (word.Contains("\n"))
            {
                throw new ArgumentNullException("word", "Token can't contain white space-- must use *, - or other punctuation to join words into a single token : " + word);
            }
            if (word.Contains("\t"))
            {
                throw new ArgumentNullException("word", "Token can't contain white space-- must use *, - or other punctuation to join words into a single token : " + word);
            }
            this.word = word;
        }

        protected string ProcessPuncuation(string token)
        {
            if (token.EndsWith(","))
            {
                postComma = true;
            }
            if (token.StartsWith(","))
            {
                preComma = true;
            }
            if (token.EndsWith("»"))
            {
                postQuote = true;
            }
            if (token.StartsWith("«"))
            {
                preQuote = true;
            }

            token = token.Trim(new char[] { ',', '«', '»' });
            return token;
        }

        //Validates arbitrary Text. 

        public bool IsValidLetterSet
        {
            get
            {
                return ValidateLetterSet(word);
            }
        }

        private static bool ValidateLetterSet(string value)
        {
            string lowerWord = value.ToLowerInvariant();
            return lowerWord.All(c => "jklmnpstwaeiou".Contains(c));
        }

        public  static bool ValidateCompoundWordLetterSet(string value)
        {
            string lowerWord = value.ToLowerInvariant();
            return lowerWord.All(c => "jklmnpstwaeiou-".Contains(c));
        }

        public  string ListInvalidCharacters(string value)
        {
            string lowerWord = value.ToLowerInvariant();

            List<string> wrongOnes = new List<string>();
            foreach (char c in lowerWord)
            {
                if (!"jklmnpstwaeiou".Contains(c))
                {
                    wrongOnes.Add(c.ToString());
                }
            }
            return String.Concat(",", wrongOnes);
        }

        public bool IsValidPhonology
        {
            get
            {
                return CheckIsValidPhonology(word);

                //return lowerWord.All(c => "jklmnpstwaeiou".Contains(c));
            }
        }

        public static bool CheckIsValidPhonology(string value)
        {

            //Letters
            if (!ValidateLetterSet(value))
            {
                return false;
            }

            //Invalid syllables.: "ji", "wu", "wo", "ti", "nm", "nn"
            foreach (string invalid in new string[] {"ji", "wu", "wo", "ti", "nm", "nn"})
            {
                if (value.Contains(invalid))
                {
                    return false;
                }
            }

            //Casing
            //CVCVN
            TokenParserUtils pu = new TokenParserUtils();
            //Full regex.
            string[] matches = pu.JustTpWords(value);

            if (matches.Length < 1 && !matches.Contains(value))
            {
                Console.WriteLine(String.Join(", ", matches));
            }


            return matches.Length >= 1 && matches.Contains(value);
        }

        public bool IsNumeric
        {
            get
            {
                return word.All(c => "1234567890-.#".Contains(c));
            }
        }

        public bool CheckIsCompoundWord(string prospectiveWord)
        {
            if (!prospectiveWord.Contains("-"))
            {
                return false;
            }
            string[] parts= prospectiveWord.Split(new char[] {'-'});
            foreach (string part in parts)
            {
                //HACK: Should have non exception way to do this
                try
                {
                    Word w = new Word(part);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckIsNumber(string value)
        {
            string toCheck = value;
            if (value.StartsWith("#"))
            {
                toCheck =value.Substring(1);
            }

            if (toCheck.All(c => "1234567890-.".Contains(c)))
            {
                return true;
            }

            //Most likely a roman number, eg. nanpa MMLW
            if (toCheck.All(c => "WTLMA".Contains(c)))
            {
                return true;
            }

            return false;
        }

        public bool  IsProperModifier
        {
            get
            {
                return word.Substring(0, 1) == word.Substring(0, 1).ToUpperInvariant();
            }
        }

        public static bool CheckIsConjunction(string prospectiveWord)
        {
            if (prospectiveWord.Length < 2)
            {
                return false;
            }
            
            return Particles.Conjunctions.Contains(prospectiveWord);
        }

        public bool CheckIsPreposition(string prospectiveWord)
        {
            if (prospectiveWord.Length < 2)
            {
                return false;
            }
            if (!prospectiveWord.StartsWith("~"))
            {
                return false;
            }
            string value = prospectiveWord.Substring(1);
            return Particles.Prepositions.Contains(value);
        }

        public bool CheckIsProperModifier(string value)
        {
            //Check the uncommon case 1st.
            //Capitalize first.
            if (value.Substring(0, 1) != value.Substring(0, 1).ToUpperInvariant())
            {
                return false;
            }

            if (value.StartsWith("#") || value.StartsWith("\"") || value.StartsWith("~"))
            {
                //number, foreign text, preposition respectively.
                return false;
            }
            //Must be valid letters.
            if (!ValidateLetterSet(value))
            {
                return false;
            }
            if (!CheckIsValidPhonology(value))
            {
                return false;
            }
            if(value.Length==1) return true;

            if (value.Substring(1).ToLower() != value.Substring(1))
            {
                return false;
            }
            return true;   
        }

        public bool IsKnown
        {
            get
            {
                return Words.Dictionary.Any(x => x.Value.Text == word);
            }
        }


        public bool ContainedBy(string phrase)
        {
            if (!phrase.Contains(phrase))
            {
                return false;
            }
            string[] parts = phrase.Split(new string[] { " ", Environment.NewLine, ".", "!", "?" }, StringSplitOptions.RemoveEmptyEntries);
            return parts.Contains(word);
        }

        //Lossy, human oriented serialization.
        public override string ToString()
        {
            return Text;
        }

        public string ToString(string format)
        {
            return Text;
        }

        //Pretty darn safe. Unlikely tho throw.
        static public implicit operator string(Token word)
        {
            return word.ToString("g");
        }

        //Sort of evil, could throw exception.
        static public implicit operator Token(string value)
        {
            return new Token(value);
        }

        /// <summary>
        /// Anything of the form "{anything}" but without spaces.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsForeign(string s)
        {
            if (s.StartsWith("\"") && s.EndsWith("\"") && !s.Contains(" "))
            {
                return true;
            }
            if(!s.Contains(" ") && s.Contains("*"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string LookupForm(string value)
        {
            return value.Trim(new char[] { ',', '«', '»','!',' ' });
        }

        private static string[] modals = new string[]
        {
            "ken", "kama", "tawa", "awen", "wile", //jan Sonja
            "open","pini", //Community usage
            "seme" //because seme can replace any content word, so this can replace a modal too! Odd but seemingly true.
        };
        public static string[] Modals
        {
            get
            {
                return modals;  
            }
        }

        //poman, stupid, half-stupid, body

        private static string[] pomanNumbers = new string[]
        {
            "W",//1
            "T",//2
            "L",//2
            "M",//20
            "A" //100
        };
        public static string[] PomanNumbers
        {
            get
            {
                return pomanNumbers;
            }
        }

        private static string[] halfStupidNumbers = new string[]
        {
            "ala",//0
            "wan",//1
            "tu",//2
            "luka",//2
            "mute",//20
            "ali", "ale" //100
        };
        public static string[] HalfStupidNumbers
        {
            get
            {
                return halfStupidNumbers;
            }
        }

        private static string[] stupidNumbers = new string[]
        {
            "ala",
            "wan",
            "tu"
        };
        public static string[] StupidNumbers
        {
            get
            {
                return stupidNumbers;
            }
        }

        private static string[] bodyNumbers = new string[]
        {
            "ala",
            "nena", "wan",
            "oko", "tu",
            "kute",
            "uta", 
            "luka",
            "insa",
            "monsi",
            "palisa", "lupa",
            "noka"
            //,"noka-pini"
        };
        public static string[] BodyNumbers
        {
            get
            {
                return bodyNumbers;
            }
        }

        public static bool IsModal(string value)
        {
            return modals.Contains(value);
        }
    }
}
