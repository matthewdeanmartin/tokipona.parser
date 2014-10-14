using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Exceptions;
using BasicTypes.Knowledge;
using BasicTypes.MoreTypes;
using Microsoft.SqlServer.Server;
using NUnit.Framework;

namespace BasicTypes
{
    //public enum PartOfSpeech
    //{
    //    None = 0,
    //    Noun = 1,
    //    VerbIntransitive = 2,
    //    VerbTransitive = 3,
    //    Interjection = 4,
    //    Adjective = 5,
    //    Adverb = 6
    //}
    [Serializable]
    public class PartOfSpeech : Enumeration
    {
        public static readonly PartOfSpeech Noun = new PartOfSpeech(1, "Noun");
        public static readonly PartOfSpeech VerbIntransitive = new PartOfSpeech(2, "VerbIntranitive");
        public static readonly PartOfSpeech VerbTransitive = new PartOfSpeech(3, "VerbTransitive");

        public static readonly PartOfSpeech Interjection = new PartOfSpeech(4, "Interjection");
        public static readonly PartOfSpeech Adjective = new PartOfSpeech(5, "Adjective");
        public static readonly PartOfSpeech Adverb = new PartOfSpeech(6, "Adverb");

        private PartOfSpeech() { }
        private PartOfSpeech(int value, string displayName) : base(value, displayName) { }
    }

    public enum ParticleType
    {
        None = 0,
        Conjunction = 1,
        Accusative = 2,
        Genative = 3,
        Vocative = 4,
        Prepositional = 5,
    }

    //Content words-- everything not a Particle
    [DataContract]
    [Serializable]
    public class Word:IFormattable
        //IConvertible (Basic types, like double, int, date, etc)
    {
        internal Word()
        {
            //For XML serialization only.
        }

        [DataMember(IsRequired = true)]
        private readonly string word;

        [DataMember(IsRequired = false,EmitDefaultValue = false)]
        private readonly SerializableDictionary<PartOfSpeech, string> glossMap;

        public Word(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("word", "Can't construct words with null");
            }
            if (word.IndexOfAny(new char[] { '.', ' ', '?', '!' }) != -1)
            {
                throw new InvalidLetterSetException("Words must not have spaces or punctuation, (other than the preposition marker ~)");
            }
            //Validate
            this.word = word;
        }

        public Word(string word,
            SerializableDictionary<PartOfSpeech, string> glossMap)
        {
            if (word == null)
            {
                throw new ArgumentNullException("word", "Can't construct words with null");
            }
            //Validate
            this.word = word;
            this.glossMap = glossMap;
        }

        public bool IsKnown
        {
            get
            {
                return Words.Dictionary.Any(x => x.Text == word);
            }
        }

        public bool IsValidLetterSet
        {
            get
            {
                string lowerWord = word.ToLowerInvariant();
                return lowerWord.All(c => "jklmnpstwaeiou".Contains(c));
            }
        }

        public bool IsValidPhonology
        {
            get
            {
                //Letters
                //CVCVN
                //Invalid syllables.
                string[] matches = ParserUtils.JustTpWords(word);

                if (matches.Length < 1 && !matches.Contains(word))
                {
                    Console.WriteLine(string.Join(", ", matches));
                }
                return matches.Length >= 1 && matches.Contains(word);
                //return lowerWord.All(c => "jklmnpstwaeiou".Contains(c));
            }
        }

        public bool IsNumeric
        {
            get
            {
                return word.All(c => "1234567890-.".Contains(c));
            }
        }

        public bool IsProperModifier
        {
            get
            {
                return word.Substring(0, 1) == word.Substring(0, 1).ToUpperInvariant();
            }
        }
        public string Text { get { return word; } }

        public SerializableDictionary<PartOfSpeech, string> GlossMap { get { return glossMap; } }

        //Lossy, human oriented serialization.
        public override string ToString()
        {
            return this.ToString("g", System.Globalization.CultureInfo.CurrentCulture);
            
        }

        public string ToString(string format)
        {
            return this.ToString(format, System.Globalization.CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            //// Handle null or empty string. 
            if (String.IsNullOrEmpty(format)) format = "g";
            // Remove spaces and convert to uppercase.
            format = format.Trim();
            if (format==null|| format == "g" || format == "G")
                return Text;
            else
                throw new FormatException("Unrecognized format " + format);
        }

        public static bool IsWord(string word)
        {
            foreach (Word x in Words.Dictionary)
            {
                if (x.Text == word)
                    return true;
            }
            return false;
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

        public static Word Parse(string value)
        {
            return new Word(value);
        }

        public static void TryParse(string value, out Word result)
        {
            try
            {
                result = new Word(value);
            }
            catch (Exception)
            {
                result = null;
            }
        }
    }

    public class WordByValue : EqualityComparer<Word>
    {
        private static readonly WordByValue instance = new WordByValue();
        public static WordByValue Instance { get { return instance; } }

        static WordByValue() { }
        private WordByValue() { }

        public override bool Equals(Word x, Word y)
        {
            return StringComparer.InvariantCulture.Equals(x.Text, y.Text);
        }

        public override int GetHashCode(Word obj)
        {
            return StringComparer.InvariantCulture.GetHashCode(obj);
        }
    }
}
