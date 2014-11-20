using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;
using BasicTypes.Lorem;

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
    [DataContract]
    [Serializable]
    public class Neologism : Token
    {

        public Neologism(string word)
        {
            CheckIsNeologism(word);

            this.word = word;
        }

        private static void CheckIsNeologism(string word)
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
            foreach (KeyValuePair<string, Word> pair in Words.Dictionary)
            {
                if (Token.AreMinimalPairs(word, pair.Key))
                {
                    throw new InvalidOperationException("Minimal pair, likely mispelling");
                }
            }
        }

        public static Word MakeProperNeologism()
        {
            string word;
            do
            {
                word = GenerateNeologism(true);
            } while (string.IsNullOrWhiteSpace(word) || !Token.CheckIsValidPhonology(word));
            return new Word(word);
        }

        public static Word MakeNeologism()
        {
            string word;
            do
            {
                word = GenerateNeologism(false);
            } while (string.IsNullOrWhiteSpace(word) ||  !Token.CheckIsValidPhonology(word));
            return new Word(word);
        }

        private static Random random = new Random(DateTime.Now.Millisecond);

        private static string GenerateNeologism(bool proper)
        {
            //Syllables
            Dictionary<int, int> odds = new Dictionary<int, int>
            {
                {1, 10},
                {2, 79},
                {3, 10},
                {4, 5},
                {5, 1},
            };
            int last = 0;
            foreach (int key in odds.Keys.Select(x => x).ToArray())
            {
                odds[key] = odds[key] + last;
                last = odds[key];
            }

            int dice = random.Next(0, 101);
            var howMany = odds.Where(x => dice <= x.Value).Select(x => x.Key).First();


            StringBuilder sb = new StringBuilder(howMany*2);
            bool canVowel =true;
            bool canConsonant =true;
            for (int i = 0; i < howMany; i++)
            {
                if (canConsonant && i > 0 && random.Next(0, 100) < 5)
                {
                    sb.Append("n");
                    canVowel = true;
                    canConsonant = true;
                }
                else if (canVowel && random.Next(0, 100) < 5)
                {
                    sb.Append(Token.AlphabetVowels[random.Next(0, 5)]);
                    canVowel = false;
                    canConsonant = true;
                }
                else if(canConsonant)
                {
                    sb.Append(Token.AlphabetConsonants[random.Next(0, 9)]);
                    sb.Append(Token.AlphabetVowels[random.Next(0, 5)]);

                    canVowel = false;
                    canConsonant = true;
                }
            }

            if (sb.Length == 0)
            {
                throw new InvalidOperationException("Failed to generate anything");
            }

            if (proper)
            {   
                if (sb.Length == 1)
                {
                    return sb[0].ToString().ToUpper();
                }
                if (sb.Length == 2)
                {
                    return sb[0].ToString().ToUpper() + sb[1];
                }
                return sb[0].ToString().ToUpper() + sb.ToString(1,sb.Length-1);
            }

            return sb.ToString();
        }
    }
}

