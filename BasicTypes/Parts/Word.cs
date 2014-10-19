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
    public partial class Word : IFormattable, ICopySelf<Word>
    //IConvertible (Basic types, like double, int, date, etc)
    {
        private Config currentDialect;
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

        public Word(string word, IFormatProvider provider=null)
        {
            if (word == null)
            {
                throw new ArgumentNullException("word", "Can't construct words with null");
            }
            if (word.IndexOfAny(new char[] { '.', ' ', '?', '!' }) != -1)
            {
                throw new InvalidLetterSetException("Words must not have spaces or punctuation, (other than the preposition marker ~)");
            }

            if (provider == null)
            {
                currentDialect = Config.CurrentDialect;
            }
            else
            {
                currentDialect = provider.GetFormat(typeof (Word)) as Config;
            }
            if (Words.Dictionary.ContainsKey(word))
            {
                glossMap = Words.Dictionary[word].GlossMap;
            }

            //TODO:Add semantic info

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
                Config c = Config.MakeDefault;
                c.ThrowOnSyntaxError = false;
                ParserUtils pu = new ParserUtils(c);
                //Letters
                //CVCVN
                //Invalid syllables.
                string[] matches = pu.JustTpWords(word);

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

}
