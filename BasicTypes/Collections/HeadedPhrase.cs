using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;
using BasicTypes.Exceptions;
using BasicTypes.Extensions;
using BasicTypes.Parts;

namespace BasicTypes
{
    /// <summary>
    /// Phrase with no particles. Head word is special, subsequent words might not be ordered.
    /// </summary>
    [DataContract]
    [Serializable]
    public class HeadedPhrase : IContainsWord, IFormattable, IToString
    {
        //Pretty little girls school==> a school characterized by pretty, little and girls.
        //i.e. same as girls school & little school & pretty school, etc.

        [DataMember]
        private readonly Word head;
        [DataMember]
        private readonly WordSet modifiers;

        public HeadedPhrase(Word head, WordSet modifiers)
        {
            
            if (head == null)
            {
                throw new ArgumentNullException("head", "Can't construct with null");
            }
            if (Particle.IsParticle(head.Text))
            {
                throw new TpSyntaxException("You can't have a headed phrase that is headed by a particle. That would be a chain. " + head.Text);
            }
            if (ProperModifier.IsProperModifer(head.Text))
            {
                throw new TpSyntaxException("Proper modifiers can't be the head of a headed phrase " + head.Text);
            }
            if (modifiers != null)
            {
                foreach (Word word in modifiers)
                {
                    if (Particle.IsParticle(word.Text))
                    {
                        throw new TpSyntaxException("Particles shouldn't be modifiers");
                    }
                }
            }
            if (modifiers != null && modifiers.Count > 5)
            {
                if (head.Text == "nanpa")
                {
                    //no surprise there
                }
                    //HACK:
                else if (modifiers.Any(x => x.Text == "anu" || x.Text == "en")) //Because we've deferred dealing with conj.
                {

                }
                else
                {
                    throw new InvalidOperationException("Suspiciously long headed phrase " + head + " " + modifiers);
                }
            }

            this.head = head;
            this.modifiers = modifiers;
        }

        //public HeadedPhrase(Word head, WordSet modifiers, HeadedPhrase[] subPhrases)
        //{
        //    if (head == null)
        //    {
        //        throw new ArgumentNullException("head", "Can't construct with null");
        //    }
        //    this.head = head;
        //    this.modifiers = modifiers;
        //}

        
        public Word Head { get { return head; } }
        public WordSet Modifiers { get { return modifiers; } }
        
        public bool Contains(Word word)
        {
            if (WordByValue.Instance.Equals(word, head))
            {
                return true;
            }
            if (modifiers == null) 
                return false;
            return modifiers.Any() && modifiers.Any(modifier => WordByValue.Instance.Equals(word, modifier));
        }

        public override string ToString()
        {
            return this.ToString("g", Config.CurrentDialect);

        }

        public string[] SupportedsStringFormats
        {
            get
            {
                return new string[] { "g" };
            }
        }

        public string ToString(string format)
        {
            if (format == null)
            {
                format = "g";
            }
            return this.ToString(format, Config.CurrentDialect);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
            {
                format = "g";
            }
            var words = ToTokenList(format,formatProvider);
            return words.SpaceJoin(format);
        }

        public List<string> ToTokenList(string format, IFormatProvider formatProvider)
        {
             
            List<string> words = new List<string>();
            

            words.Add(head.ToString(format,formatProvider));
            if (Modifiers != null && Modifiers.Count > 0)
            {
                words.Add("(");
                words.AddRange(modifiers.Select(x => x.ToString(format,formatProvider)));
                words.Add(")");
            }
            return words;
        }

        public bool IsPlural(string value)
        {
            return Modifiers.Contains(Words.mute);
        }

        public static HeadedPhrase Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("value is null or zero length string");
            }
            return HeadedPhraseConverter.Parse(value);
        }

        public static bool TryParse(string value, out HeadedPhrase result)
        {
            try
            {
                result = HeadedPhraseConverter.Parse(value);
                return true;
            }
            catch (Exception)
            {
                result = null;
                return false;
            }
        }
    }
}