using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BasicTypes.Parser
{
    //Strings to tokens. Nothing involving anything above a token.
    //Tokens promise *only* to be atomic. (ie. smallest unit of syntax)
    public class TokenParserUtils
    {
        public const string ValidTpWordSplitter =
            @"([0-9-]+)" +  //Numbers okay
            @"|(#[0-9-]+)" +  //Pounded numbers better
            @"|[""][a-zA-Z0-9\*\?.!]*[""]" +  //Quoted text joined by * is okay == foreign text
            @"|\b([JKLMNPSTW]?[aeiou][n]?([jklmnpstw][aeiou][n]?-?)*)\b" +  //Capitalized syllable followed by any number of whole syllables with optional n's 
            @"|\b([AEIOU][n]?([jklmnpstw][aeiou][n]?-?)*)\b" +  //Capitalized syllable followed by any number of whole syllables with optional n's 
            @"|\b([aeiou])\b" + //Bare vowel is okay.
            @"|\b(([jklmnpstw]?[aeiou][n]?-?)*)\b" + //Uncapitalized syllables with optional constants or final n's
            @"|\b([aeiou][n]?-?)\b|" + //vowels with optional n's
            @"\b([AEIOU][n]?-?)\b"; //Capital vowels with optional n's

        //Kunpapa

        public Token[] ValidTokens(string value)
        {
            string[] strings = RemergeCompounds(JustTokens(value));
            return Array.ConvertAll(strings, s => new Token(s));
        }

        public Word[] ValidWords(string value)
        {
            string[] strings = RemergeCompounds(JustTokens(value));
            return Array.ConvertAll(strings, s => new Word(s));
        }

        public string[] WordsPunctuationAndCompounds(string value)
        {
            return RemergeCompounds(JustTokens(value));
        }

        
        public string[] JustTokens(string value)
        {
            //http://regexhero.net/tester/

            return value.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                
                   //(from Match s in Regex.Matches(value, @"\w+|[\w\s]*")
                   // where !string.IsNullOrEmpty(s.Value)
                   // select s.Value.Trim()).ToArray();
        }

        //Can double match (word within word) :-(
        public string[] JustTpWords(string value)
        {
            //THIS STRIPS OUT JUNK. That removes too much.

            //Allows:
            // a
            // an
            // A
            // An
            // na
            // nan
            // Na
            // Nan

            //http://regexhero.net/tester/

            return (from Match s in Regex.Matches(value, ValidTpWordSplitter)
                    where !string.IsNullOrEmpty(s.Value)
                    select s.Value).ToArray();
        }

        public string[] RemergeCompounds(string[] words)
        {
            if (!words.Any(x => x.Contains("-")))
            {
                //No compound words here
                return words;
            }
            List<string> merged = new List<string>();
            List<string> compound = new List<string>();
            for (int index = 0; index < words.Length; index++)
            {
                string word = words[index];
                if (word == "-")
                {
                    compound.Add(word);
                    continue;
                }
                if (index + 1 < words.Length && words[index + 1] == "-")
                {
                    compound.Add(word);
                    continue;
                }
                if (index - 1 > 0 && words[index - 1] == "-")
                {
                    compound.Add(word);
                    continue;
                }

                if (compound.Count > 0)
                {
                    merged.Add(string.Join("", compound.ToArray()));
                    compound.Clear();
                }
                else
                {
                    merged.Add(word);
                }
            }
            //Edge case where the whole thing is a compound
            if (compound.Count > 0)
            {
                merged.Add(string.Join("", compound.ToArray()));
                compound.Clear();
            }
            return merged.ToArray();
        }

        //Should return an array of Tokens. Strings have no particular guarantees.
        //Tokens have a stronger guarantee that this is something that could be a
        //valid content word, particle, number, escaped-foreign word, compound word.
        public string[] JustTpWordsNumbersPunctuation(string value)
        {
            //Allows:
            // a
            // an
            // A
            // An
            // na
            // nan
            // Na
            // Nan
            Regex r = new Regex(ValidTpWordSplitter + "|"
                //+ "((" + ValidTpWordSplitter + ")[-])*" //Doesn't match compounds.
                + @"|([?.!'])");
            List<string> list = new List<string>();
            foreach (Match s in r.Matches(value))
            {
                if (!string.IsNullOrEmpty(s.Value))
                {
                    list.Add(s.Value);
                }
            }

            return list.ToArray();
        }

    }
}
