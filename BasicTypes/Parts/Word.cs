using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using BasicTypes.Exceptions;
using BasicTypes.Extensions;
using BasicTypes.Knowledge;
using BasicTypes.MoreTypes;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
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
    [DataContract]
    [KnownType(typeof(Enumeration))]
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
    public partial class Word : IFormattable, ICopySelf<Word>,IParse<Word> 
        //IConvertible (Basic types, like double, int, date, etc)
    {
        static Word()
        {
            AutoMapper.Mapper.CreateMap<Word, Word>();
        }
        internal Word()
        {
            //For XML serialization only.
        }

        [DataMember(IsRequired = true)]
        private readonly string word;

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        private readonly Dictionary<string, Dictionary<string, string[]>> glossMap;

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

            //Add semantic info
            if (Words.Dictionary.ContainsKey(word))
            {
                glossMap = Words.Dictionary[word].GlossMap;
            }
            //Validate

            this.word = word;
        }

        public Word(string word, Dictionary<string, Dictionary<string, string[]>> glossMap)
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
                return Words.Dictionary.Any(x => x.Value.Text == word);
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

        static public implicit operator string(Word word)
        {
            return word.ToString("g");
        }

        static public implicit operator Word(string value)
        {
            return Word.Parse(value);
        }


        public string Text { get { return word; } }

        [XmlIgnore] //XMLSerializer
        [ScriptIgnore]
        public Dictionary<string, Dictionary<string, string[]>> GlossMap { get { return glossMap; } }

        //[XmlIgnore] 
        //public Dictionary<string, string> GlossMapJavaScriptSerializer {
        //    get
        //    {
        //        if (glossMap == null) return null;
        //        //https://stackoverflow.com/questions/3685732/c-sharp-serialize-dictionaryulong-ulong-to-json
        //        return glossMap.ToDictionary(item => item.Key.ToString(), item => (item.Value??"").ToString());
        //    } 
        //}

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
            if (format == null || format == "g" || format == "G")
                return Text;

            CultureInfo ci = Thread.CurrentThread.CurrentCulture;

            if (ci.TwoLetterISOLanguageName == "tp") //Can only happen if we can install a custom culture. Not worth the effort.
            {
                return Text;
            }
            else if (ci.TwoLetterISOLanguageName == "en")
            {
                string language = ci.TwoLetterISOLanguageName;
                switch (format)
                {
                    case "n":
                        return TryGloss(language, PartOfSpeech.Noun.DisplayName);
                    case "vi":
                        return TryGloss(language, PartOfSpeech.VerbIntransitive.DisplayName);
                    case "vt":
                        return TryGloss(language, PartOfSpeech.VerbTransitive.DisplayName);
                    case "adj":
                        return TryGloss(language, PartOfSpeech.Adjective.DisplayName);
                    case "adv":
                        return TryGloss(language, PartOfSpeech.Adverb.DisplayName);
                    case "int":
                        return TryGloss(language, PartOfSpeech.Interjection.DisplayName);
                    default:
                        throw new FormatException("Unrecognized format " + format);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Can't translate to " + ci.ThreeLetterISOLanguageName);
            }

        }

        private string TryGloss(string language, string pos)
        {
            if (glossMap == null)
            {
                return "[missing map for " + Text + "]";
            }
            if (glossMap.ContainsKey(pos))
            {
                return glossMap[language][pos][0];//TODO: Pick at random.
            }
            return Text;
        }

        public static bool IsWord(string word)
        {
            foreach (Word x in Words.Dictionary.Values)
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

        bool IParse<Word>.TryParse(string value, out Word result)
        {
            return TryParse(value,out result);
        }

        Word IParse<Word>.Parse(string value)
        {
            return Parse(value);
        }

        public static bool TryParse(string value, out Word result)
        {
            try
            {
                result = new Word(value);
                return true;
            }
            catch (Exception)
            {
                result = null;
                return false;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public Word ShallowCopy()
        {
            return this.MemberwiseClone() as Word;
        }


        public Word DeepCopy()
        {
//           return  AutoMapper.Mapper.Map(this, new Word());   
            BinaryFormatterCopier<Word> copier = new BinaryFormatterCopier<Word>();
            return copier.Copy(this);
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
