﻿using System;
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
using BasicTypes.Parts;
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
        private Dialect currentDialect;
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

        //[DataMember(IsRequired = false, EmitDefaultValue = false)]
        //[ScriptIgnore]
        //[IgnoreDataMember]
        //private readonly Dictionary<string, Dictionary<string, string[]>> glossMap;

        public Word(string word, IFormatProvider provider = null)
        {
            ValidateOnConstruction(word);

            

            if (provider == null)
            {
                currentDialect = Config.CurrentDialect;
            }
            else
            {
                currentDialect = provider.GetFormat(typeof(Word)) as Dialect;
            }
            
            //TODO:Add semantic info

            //Validate

            this.word = word;
        }

        private static void ValidateOnConstruction(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("word", "Can't construct words with null");
            }
            
            if (word.IndexOfAny(new char[] {'.', ' ', '?', '!', '\n', '\r'}) != -1
                && !ForeignWord.IsForeign(word)
                )
            {
                throw new InvalidLetterSetException(
                    "Words must not have spaces or punctuation, (other than the preposition marker ~): found: " + word);
            }
            //TODO: How to impelment this rule? Need to rework dictionary, since dictionary stores all words (particles included) as Word
            //if (Particle.IsParticle(word))
            //{
            //    throw new InvalidOperationException("Don't treat particles as words : " + word);
            //}
            //Can be a number, word, compound word or escaped word.
            if (!CheckIsNumber(word) && !Word.ValidateCompoundWordLetterSet(word) && !IsEscaped(word))
            {
                throw new InvalidOperationException("Unescaped, Invalid Characters : " + word + " ==> " +
                                                    ListInvalidCharacters(word));
            }

            if (Words.Dictionary.Count >124)
            {
                //Strictest test.
                Word blah = Words.a;
                Word test;
                if (!Words.Dictionary.TryGetValue(word, out test))
                {
                    Console.WriteLine(word[0].ToString().ToUpper());
                    Console.WriteLine(word[0].ToString());
                    Console.WriteLine(Words.Dictionary.Count);
                    if (word[0].ToString().ToUpper() != word[0].ToString())
                    {
                        throw new InvalidOperationException("This word (" + word + ") isn't in the dictionary and isn't upper cased like a proper modifier. What is wrong.");
                    }
                }

            }
        }

        public static bool IsEscaped(string value)
        {
            //TODO:check for internal "
            return !(value.StartsWith("\"") && value.EndsWith("\""));
        }

        public Word(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("word", "Can't construct words with null");
            }
            ValidateOnConstruction(word);
            //Validate
            this.word = word;
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
            get {
                return ValidateLetterSet(word);
            }
        }

        public static bool ValidateLetterSet(string value)
        {
            string lowerWord = value.ToLowerInvariant();
            return lowerWord.All(c => "jklmnpstwaeiou".Contains(c));
        }

        public static bool ValidateCompoundWordLetterSet(string value)
        {
            string lowerWord = value.ToLowerInvariant();
            return lowerWord.All(c => "jklmnpstwaeiou-".Contains(c));
        }

        public static string ListInvalidCharacters(string value)
        {
            string lowerWord = value.ToLowerInvariant();

            List<string> wrongOnes=new List<string>();
            foreach (char c in lowerWord)
            {
                if (!"jklmnpstwaeiou".Contains(c))
                {
                    wrongOnes.Add(c.ToString());
                }
            }
            return string.Concat(",", wrongOnes);
        }

        public bool IsValidPhonology
        {
            get
            {
                Dialect c = Dialect.DialectFactory;
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
                return word.All(c => "1234567890-.#".Contains(c));
            }
        }

        public static bool CheckIsNumber(string value)
        {
            if (!value.All(c => "1234567890-.#".Contains(c)))
            {
                if (value.Contains("#"))
                {
                    if (value.StartsWith("#"))
                    {
                        return true;
                    }
                    return false;
                }
                return true;
            }
            return false;
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


        //Lossy, human oriented serialization.
        public override string ToString()
        {
            return this.ToString("g", Config.CurrentDialect);

        }

        public string ToString(string format)
        {
            return this.ToString(format, Config.CurrentDialect);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            Dialect c = formatProvider.GetFormat(typeof(Word)) as Dialect;

            //// Handle null or empty string. 
            if (String.IsNullOrEmpty(format)) format = "g";
            // Remove spaces and convert to uppercase.
            format = format.Trim();
            if (format == null || format == "g" || format == "G")
            {
                return Text;
            }


            bool includePos = false;
            if (format.Contains(":"))
            {
                string[] parts = format.Split(new char[] { ':' });
                format = parts[0];
                includePos = Convert.ToBoolean(parts[1]);
            }
            CultureInfo ci = Thread.CurrentThread.CurrentCulture;

            string language;
            if (c.TargetGloss == "thread")
            {
                language = ci.TwoLetterISOLanguageName;
            }
            else
            {
                language = c.TargetGloss;
            }

            if (language == "tp")
            {
                return Text; //And maybe POS
            }

            if (includePos)
                return TryGloss(language, format) + "(" + format + ")";
            else
            {
                return TryGloss(language, format);
            }

        }

        private string TryGloss(string language, string pos)
        {
            Dictionary<string, Dictionary<string, string[]>> glossMap;
            Words.Glosses.TryGetValue(word, out glossMap);

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

            //TraceMissingGloss();

            if (!((Text.ToUpper())[0] == Text[0]))
            {
                return "[Error " + pos + " " + Text + " " + language + "]";
            }
            else
                return Text;
        }

        private void TraceMissingGloss( Dictionary<string, Dictionary<string, string[]>> glossMap)
        {
            foreach (KeyValuePair<string, Dictionary<string, string[]>> pair in glossMap)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in pair.Value)
                {
                    if (item.Value != null && item.Value.Length > 0)
                    {
                        sb.Append(item.Key + " : " + string.Join(",", item.Value) + "; ");
                    }
                }
                Console.WriteLine(pair.Key + " : " + sb);
            }
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
