using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.CollectionsLeaf;
using BasicTypes.Extensions;
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
        protected bool preComma;

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
            if(word==null) throw new ArgumentNullException("word");

            if (word.EndCheck(" ") && word != " ")
            {
                throw new InvalidOperationException("Untrimmed word.");
            }
            if (!iAmAPrepositionChain)
            {
                if (String.IsNullOrWhiteSpace(word))
                {
                    throw new ArgumentNullException("word", "Token cannot be null or white space");
                }
                if (word.ContainsCheck(" ") && !TaggedWord.CheckIsTagWord(word))
                {
                    throw new ArgumentNullException("word",
                        "Token can't contain white space-- must use *, - or other punctuation to join words into a single token : " +
                        word);
                }
            }
            if (word.ContainsCheck("\n"))
            {
                throw new ArgumentNullException("word", "Token cannot contain white space-- must use *, - or other punctuation to join words into a single token : " + word);
            }
            if (word.ContainsCheck("\t"))
            {
                throw new ArgumentNullException("word", "Token cannot contain white space-- must use *, - or other punctuation to join words into a single token : " + word);
            }
            this.word = word;
        }

        protected string ProcessPuncuation(string token)
        {
            if (token.EndCheck(","))
            {
                postComma = true;
            }
            if (token.StartCheck(","))
            {
                preComma = true;
            }
            if (token.EndCheck("»"))
            {
                postQuote = true;
            }
            if (token.StartCheck("«"))
            {
                preQuote = true;
            }

            token = token.Trim(new[] { ',', '«', '»' });
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

        public static string AlphabetVowels
        {
            get { return "aeiou"; }
        }
        public static string AlphabetConsonants
        {
            get { return "jklmnpstw"; }
        }
        public static string Alphabet
        {
            get { return "jklmnpstwaeiou"; }
        }
        public static string AlphabetEitherCase
        {
            get { return "JKLMNPSTWAEIOUjklmnpstwaeiou"; }
        }
        public static string AlphabetUpper
        {
            get { return "JKLMNPSTWAEIOU"; }
        }



        public static bool ValidateLetterSet(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;

            string lowerWord = value.ToLowerInvariant();
            return lowerWord.All(c => "jklmnpstwaeiou".ContainsCheck(c));
        }

        public static bool ValidateCompoundWordLetterSet(string value)
        {
            string lowerWord = value.ToLowerInvariant();
            return lowerWord.All(c => "jklmnpstwaeiou-".ContainsCheck(c));
        }

        public string ListInvalidCharacters(string value)
        {
            string lowerWord = value.ToLowerInvariant();

            List<string> wrongOnes = new List<string>();
            foreach (char c in lowerWord)
            {
                if (!"jklmnpstwaeiou".ContainsCheck(c))
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

                //return lowerWord.All(c => "jklmnpstwaeiou".ContainsCheck(c));
            }
        }

        public bool IsParticle
        {
            get { return CheckIsParticle(word); }
        }

        public static bool CheckIsParticle(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            if (Particles.Prepositions.Contains("~" + value)) return true;

            if (Particles.Conjunctions.Contains(value)) return true;

            if (Particle.NonContentParticles.Contains(value)) return true;
            return false;
        }

        public static bool CheckIsValidPhonology(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            //Letters
            if (!ValidateLetterSet(value))
            {
                return false;
            }

            //Invalid syllables.: "ji", "wu", "wo", "ti", "nm", "nn"
            string toLower = value.ToLower();
            foreach (string invalid in new[] { "ji", "wu", "wo", "ti", "nm", "nn" })
            {
                if (toLower.ContainsCheck(invalid))
                {
                    return false;
                }
            }

            //Casing
            //CVCVN
            TokenParserUtils pu = new TokenParserUtils();
            //Full regex.
            string[] matches = pu.JustTpWords(value);

            //if (matches.Length < 1 && !matches.Contains(value))
            //{
            //    Console.WriteLine(String.Join(", ", matches));
            //}


            return matches.Length >= 1 && matches.Contains(value);
        }

        public bool IsNumeric
        {
            get
            {
                return word.All(c => "1234567890-.#".ContainsCheck(c));
            }
        }

        public bool CheckIsCompoundWord(string prospectiveWord)
        {
            if (!prospectiveWord.ContainsCheck("-"))
            {
                return false;
            }
            string[] parts = prospectiveWord.Split(new[] { '-' });
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
            if (value.StartCheck("#"))
            {
                toCheck = value.Substring(1);
            }

            if (toCheck.All(c => "1234567890-.".ContainsCheck(c)))
            {
                return true;
            }

            //Most likely a roman number, eg. nanpa MMLW
            if (toCheck.All(c => "WTLMA".ContainsCheck(c)))
            {
                return true;
            }
            bool allPartsAreNumbers = true;
            foreach (string part in toCheck.Split(new[] { '-' }))
            {
                if (Token.RealStupidNumbers.Contains(part)) continue;
                if (Token.StupidNumbers.Contains(part)) continue;
                if (Token.HalfStupidNumbers.Contains(part)) continue;
                if (Token.BodyNumbers.Contains(part)) continue;
                allPartsAreNumbers = false;
            }

            if (allPartsAreNumbers) return true;

            return false;
        }

        public bool IsProperModifier
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
            if (!prospectiveWord.StartCheck("~"))
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

            if (value.StartCheck("#") || value.StartCheck("\"") || value.StartCheck("~"))
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
            if (value.Length == 1) return true;

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
            if (!phrase.ContainsCheck(phrase))
            {
                return false;
            }
            string[] parts = phrase.Split(new[] { " ", Environment.NewLine, ".", "!", "?" }, StringSplitOptions.RemoveEmptyEntries);
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
            if (s.StartCheck("\"") && s.EndCheck("\"") && !s.ContainsCheck(" "))
            {
                return true;
            }
            if (!s.ContainsCheck(" ") && s.ContainsCheck("*"))
            {
                return true;
            }
            return false;
        }

        public static string LookupForm(string value)
        {
            return value.Trim(new[] { '~', ',', '«', '»', '!', ' ' });
        }

        private static string[] modals =
        {
            //"kama", "tawa", Category of their own. (modal in jan Sonja v1)
            "ken", "awen", "wile", //jan Sonja v1
            //"lukin", "oko", "sona",//Jan Sonja vPu (are these really serial verbs?) No, they are not. These are noun complements of some head verb.
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

        private static string[] pomanNumbers =
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

        //Overlap with negative, verb "to divide", plural marker, and universal qualifier
        private static string[] halfStupidNumbers =
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


        private static string[] deprecated =
        {
            "pata",
            "kapa", 
            "iki",
            "kan",
            "pasila",
            "kapesi",
            "leko",
            "majuno",
            "tuli",
            "po",
            "kijetesantakalu",
            "ipi",
            "jalan",
//"pu",//Wait and see...
            "apeja",
            "pake"};

        public static string[] Deprecated
        {
            get
            {
                return deprecated;
            }
        }

        private static string[] realStupidNumbers =
        {
            "ala",
            "wan",
            "tu"
            //mute
        };

        //nothing, one, two, many!
        public static string[] RealStupidNumbers
        {
            get
            {
                return realStupidNumbers;
            }
        }

        //Most common.
        // wan, tu, tu wan, tu tu, luka, luka wan, luka tu, luka tu wan, luka luka
        private static string[] stupidNumbers =
        {
            "ala", //Half and half.
            "wan",//Generally a number, rarely verb or other
            "tu"//Generally a number, rarely verb or other
            //"luka" //Get's mixed up with hand.
        };
        public static string[] StupidNumbers
        {
            get
            {
                return stupidNumbers;
            }
        }

        //TODO: make parameter driven
        private static string[] bodyNumbers =
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


        private static string[] semanticallyPlural =
        {
            "mute", //most common
            "kulupu", //can go either way (a pack of wolves), )(two packs)
            "tu" //two
            //other numbers... that's a can of worms.
        };
        public static string[] SemanticallyPlural
        {
            get
            {
                return semanticallyPlural;
            }
        }

        public static bool IsNeologism(string value)
        {
            if (value.StartsWith("+"))
            {
                value = value.Substring(1);
            }

            if (Word.IsWord(value))
            {
                return false;
            }
            if (value.IsFirstUpperCased())
            {
                return false;
            }

            if (!Token.CheckIsValidPhonology(value))
            {
                return false;
            }

            return true;
        }

        public static bool IsModal(string value)
        {
            return modals.Contains(value);
        }

        protected static bool AreMinimalPairs(string word1, string word2)
        {
            if (word1.Length != word2.Length) return false;
            if (word1 == word2) return true;

            int diff = 0;
            for (int i = 0; i < word1.Length; i++)
            {
                //char c = word1[i];
                if (word1[i] == word2[i]) diff++;
                if (diff > 1) return false;
            }
            return true; //differ only by 1 char.
        }
    }
}
