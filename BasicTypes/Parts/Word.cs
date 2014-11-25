using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
//using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Web.Script.Serialization;
using System.Xml.Serialization;
using BasicTypes.Exceptions;
using BasicTypes.Extensions;
using BasicTypes.Knowledge;
using BasicTypes.MoreTypes;
using BasicTypes.Parts;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using NHunspell;
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

    //kin, ala, x ala x..., x anu seme
    // seems like they can appear after any word
    // jan li moku e kili.
    // jan ala li moku e kili
    // jan li moku ala e kili.
    // jan li moku e kili ala.
    // jan anu seme li moku e kili.
    // jan li moku ala moku e kili.
    // jan ala jan li moku e kili.??
    // jan kin li moku e kili
    // np li vp e do pp1 pp2
    // np (ala) li m (ala m) m2 (ala m2) v (ala v) e np (ala)
    public class Morphology 
    {
        public bool XalaX { get; set; } //for any verb in VP
        public bool Ala { get; set; }
        public bool Kin { get; set; } //like modifier
        //public bool AnuSeme { get; set; } Everyone does this sentence level

    }


    /// <summary>
    /// Content words-- everything not a Particle
    /// </summary>
    [DataContract]
    [Serializable]
    public partial class Word : Token, IFormattable, ICopySelf<Word>
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

        


        //[DataMember(IsRequired = true)]
        //private readonly string word;
        //
        //public string Text { get { return word; } }
        
        //The constructor that a parser uses. e.g. Parse/TryParse
        public Word(string word, IFormatProvider provider = null):base(word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentNullException("word");
            }
            word = ProcessPuncuation(word);

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

        


        public string[] ValidateOnConstruction(string prospectiveWord, bool failFast=true)
        {
            List<string> errors = new List<string>();
            if (prospectiveWord == null)
            {
                throw new ArgumentNullException("prospectiveWord", "Can't construct words with null");
            }

            //HACK: and an ugly one. This brackets potentially entire sentences, sometimes a word. Sort of like compound word.
            if (prospectiveWord.ContainsCheck('«') || prospectiveWord.ContainsCheck('»'))
            {
                prospectiveWord = prospectiveWord.Trim(new char[] {'«', '»'});
            }

            if (prospectiveWord.IndexOfAny(new char[] {'.', ' ', '?', '!', '\n', '\r'}) != -1
                && !IsForeign(prospectiveWord))
            {
                string message =
                    "Words must not have spaces or punctuation, (other than the preposition marker ~): found: " +
                    prospectiveWord;

                if(failFast)
                    throw new InvalidLetterSetException(message);
            }
            //TODO: How to implement this rule? Need to rework dictionary, since dictionary stores all words (particles included) as Word
            //if (Particle.IsParticle(word))
            //{
            //    throw new InvalidOperationException("Don't treat particles as words : " + word);
            //}
            //Can be a number, word, compound word or escaped word.
            
            //if (!CheckIsNumber(prospectiveWord)&& !ValidateCompoundWordLetterSet(prospectiveWord) && !IsEscaped(prospectiveWord))
            //{
            //    throw new InvalidOperationException("Unescaped, Invalid Characters : " + prospectiveWord + " ==> " +
            //                                        ListInvalidCharacters(prospectiveWord));
            //}

            if (Words.Dictionary.Count == 141)//==125
            {
                //Strictest test.
                Word blah = Words.a;
                Word test;
                if (!Words.Dictionary.TryGetValue(LookupForm(prospectiveWord), out test))
                {
                    //Console.WriteLine(prospectiveWord[0].ToString().ToUpper());
                    //Console.WriteLine(prospectiveWord[0].ToString());
                    //Console.WriteLine(Words.Dictionary.Count);

                    if (CheckIsPreposition(prospectiveWord))
                    {
                        //Console.WriteLine("PREPOSITION: " + prospectiveWord);
                    }
                    else if (CheckIsNumber(prospectiveWord))
                    {
                        //Console.WriteLine("NUMBER: " + prospectiveWord);
                    }
                    else if (prospectiveWord.ContainsCheck("-") &&  CheckIsCompoundWord(prospectiveWord))
                    {
                        //Console.WriteLine("COMPOUND: " + prospectiveWord);
                    }
                    else if (CheckIsProperModifier(prospectiveWord))
                    {
                        //Console.WriteLine("PROPER MODIFIER: " + prospectiveWord);
                    }//Escaped foreign
                    else if (IsForeign(prospectiveWord))
                    {
                        //Console.WriteLine("Foreign Text: " + prospectiveWord);
                    }
                    else
                    {
                        //TODO: This is a perf killer.
                        //if (CheckIsEnglish(prospectiveWord))
                        //{
                        //    errors.Add("This is English :" + prospectiveWord);
                        //}
                        
                        string message = "This word -->" + prospectiveWord +
                                         "<--  failed all checks.";
                        errors.Add(message);
                        if (failFast) throw new InvalidOperationException(message);
                    }

                }
            }
            return errors.ToArray();
        }

        private static bool CheckIsEnglish(string prospectiveWord)
        {
            if (!CheckIsValidPhonology(prospectiveWord) && prospectiveWord.Length > 1)
            {
                string path =
                    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

                if (path.ContainsCheck(@"file:\"))
                {
                    path = path.Replace(@"file:\", "");
                }
                using (
                    Hunspell hunspell = new Hunspell(Path.Combine(path, "en_us.aff"), Path.Combine(path, "en_us.dic")))
                {
                    return hunspell.Spell(prospectiveWord);
                    //if (correct)
                    //{
                    //
                    //    errors.Add("This is English: " + prospectiveWord);
                    //    //It's Enlgish.
                    //    //throw new InvalidOperationException();
                    //}
                }
            }
            else
            {
                return false;
            }
        }


        public static bool IsEscaped(string value)
        {
            //TODO:check for internal "
            return !(value.StartCheck("\"") && value.EndCheck("\""));
        }

        public Word(string word): base(word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("word", "Can't construct words with null");
            }
            if (word.EndCheck(" "))
            {
                throw new InvalidOperationException("Untrimmed word.");
            }
            if (word.EndCheck(","))
            {
                postComma = true;
            }
            if (word.StartCheck(","))
            {
                preComma = true;
            }
            word = word.Trim(new char[] { ',' });
            ValidateOnConstruction(word);
            //Validate
            this.word = word;
        }

        static public implicit operator string(Word word)
        {
            return word.ToString("g");
        }

        static public implicit operator Word(string value)
        {
            return Word.Parse(value);
        }



        //Lossy, human oriented serialization.
        public override string ToString()
        {
            return this.ToString("g", Dialect.DialectFactory);

        }

        //public string ToString(string format)
        //{
        //    return this.ToString(format, Config.CurrentDialect);
        //}

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
            if (format.ContainsCheck(":"))
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

        public string TryGloss(string language, string pos)
        {
            //HACK: This is wrong. Should be using Token or some other base class.
            if (word.ContainsCheck("-"))
            {
                CompoundWord cw = new CompoundWord(Text);
                return cw.TryGloss(language, pos);
            }

            int digits;
            bool isNumeric = int.TryParse(word, out digits);
            if (word.StartCheck("#") || isNumeric)
            {
                Number n = new Number(Text);
                return n.TryGloss(language, pos);
            }

            //HACK: This is a proper modifer
            if (LookupForm(word).IsFirstUpperCased())
            {
                if (!ProperModifier.IsProperModifer(LookupForm(word)))
                {
                    ForeignWord fw = new ForeignWord(word);
                    return fw.TryGloss(language, pos);
                }
                ProperModifier cw = new ProperModifier(Text);
                return cw.TryGloss(language, pos);
            }

            Dictionary<string, Dictionary<string, string[]>> glossMap;
            Words.Glosses.TryGetValue(LookupForm(word), out glossMap);

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
