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
    /// <summary>
    /// Standard part of speech categories
    /// </summary>
    [Serializable]
    [DataContract]
    [KnownType(typeof(Enumeration))]
    public class PartOfSpeech : Enumeration
    {
        //noun	adj	vt	vi	adv	prep	pronoun	kama	conditional	interj	conj	particle

        //public static readonly PartOfSpeech Noun = new PartOfSpeech(1, "Noun");
        //public static readonly PartOfSpeech VerbIntransitive = new PartOfSpeech(2, "VerbIntranitive");
        //public static readonly PartOfSpeech VerbTransitive = new PartOfSpeech(3, "VerbTransitive");
        //
        //public static readonly PartOfSpeech Interjection = new PartOfSpeech(4, "Interjection");
        //public static readonly PartOfSpeech Adjective = new PartOfSpeech(5, "Adjective");
        //public static readonly PartOfSpeech Adverb = new PartOfSpeech(6, "Adverb");


        public static readonly PartOfSpeech Noun = new PartOfSpeech(1, "noun");  //Content word
        public static readonly PartOfSpeech VerbIntransitive = new PartOfSpeech(2, "vi");//Content word
        public static readonly PartOfSpeech VerbTransitive = new PartOfSpeech(3, "vt");//Content word

        public static readonly PartOfSpeech Interjection = new PartOfSpeech(4, "interj");//Content word. Degenerate class. Only used in 1 word sentences.
        public static readonly PartOfSpeech Adjective = new PartOfSpeech(5, "adj");//Content word
        public static readonly PartOfSpeech Adverb = new PartOfSpeech(6, "adv");//Content word

        public static readonly PartOfSpeech Preposition = new PartOfSpeech(7, "prep"); //Has specialized class!
        public static readonly PartOfSpeech Pronoun = new PartOfSpeech(8, "pronoun"); //Has specialized class!
        public static readonly PartOfSpeech Kama = new PartOfSpeech(9, "kama");//Meaning when in a verb chain 
        public static readonly PartOfSpeech Conditional = new PartOfSpeech(10, "conditional");//Meaning when "x la"

        public static readonly PartOfSpeech Conjunction = new PartOfSpeech(10, "conj"); //Has specialized class!
        public static readonly PartOfSpeech Particle = new PartOfSpeech(10, "particle"); //Has specialized class!

        private PartOfSpeech() { }
        private PartOfSpeech(int value, string displayName) : base(value, displayName) { }

        static public implicit operator string(PartOfSpeech part)
        {
            return part.DisplayName;
        }

        static public implicit operator int(PartOfSpeech part)
        {
            return part.Value;
        }
    }

    /// <summary>
    /// Maps Particles to more common linguistic jargon
    /// </summary>
    public enum ParticleType
    {
        None = 0,
        Conjunction = 1,
        Accusative = 2,
        Genative = 3,
        Vocative = 4,
        Prepositional = 5,
    }

    /// <summary>
    /// Content words-- everything not a Particle
    /// </summary>
    [DataContract]
    [Serializable]
    public partial class Word : IFormattable, ICopySelf<Word>, IParse<Word>
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

            bool includePos = false;
            if (format.Contains(":"))
            {
                string[] parts=format.Split(new char[] {':'});
                format = parts[0]; 
                includePos= Convert.ToBoolean(parts[1]);
            }
            CultureInfo ci = Thread.CurrentThread.CurrentCulture;

            if (ci.TwoLetterISOLanguageName == "tp") //Can only happen if we can install a custom culture. Not worth the effort.
            {
                return Text;
            }
            else if (ci.TwoLetterISOLanguageName == "en")
            {
                string language = ci.TwoLetterISOLanguageName;
                if (includePos)
                    return TryGloss(language, format) +"("+ format +")";
                else
                {
                    return TryGloss(language, format);
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
            if (glossMap.ContainsKey(language))
            {
                if (glossMap[language].ContainsKey(pos))
                {
                    Random r = new Random(DateTime.Now.Millisecond);//TODO: Make this a part of config
                    string[] possibilities = glossMap[language][pos];
                    return possibilities[r.Next(possibilities.Length)]; 
                }
            }

            foreach (KeyValuePair<string, Dictionary<string, string[]>> pair in glossMap)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in pair.Value)
                {
                    if (item.Value != null && item.Value.Length>0)
                    {
                        sb.Append(item.Key + " : " + string.Join(",", item.Value) +"; ");
                    }
                }
                Console.WriteLine(pair.Key+ " : "+ sb.ToString());
            }

            if (!((Text.ToUpper())[0] == Text[0]))
            {
                return "[Error " + pos + " " + Text  + "]";
            }
            else
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
            return TryParse(value, out result);
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
