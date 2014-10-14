using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;
using BasicTypes.Extensions;

namespace BasicTypes
{
    //Pretty little girls school==> a school characterized by pretty, little and girls.
    //i.e. same as girls school & little school & pretty school, etc.
    [DataContract]
    [Serializable]
    public class HeadedPhrase : IContainsWord, IFormattable
    {
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
            this.head = head;
            this.modifiers = modifiers;
        }

        public HeadedPhrase(Word head, WordSet modifiers, HeadedPhrase[] subPhrases)
        {
            if (head == null)
            {
                throw new ArgumentNullException("head", "Can't construct with null");
            }
            this.head = head;
            this.modifiers = modifiers;
        }

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
            return this.ToString("g", System.Globalization.CultureInfo.CurrentCulture);

        }

        public string ToString(string format)
        {
            return this.ToString(format, System.Globalization.CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            List<string> words = new List<string>();
            words.Add(head.ToString());
            if (Modifiers!=null && Modifiers.Count > 0)
            {
                words.Add("(");
                words.AddRange(modifiers.Select(x=>x.ToString()));
                words.Add(")");

            }
            return words.SpaceJoin(format);
        }

        public bool IsPlura(string value)
        {
            return Modifiers.Contains(Words.mute);
        }

        public static HeadedPhrase Parse(string value)
        {
            return HeadedPhraseConverter.Parse(value);
        }

        public static void TryParse(string value, out HeadedPhrase result)
        {
            try
            {
                result = HeadedPhraseConverter.Parse(value);
            }
            catch (Exception)
            {
                result = null;
            }
        }
    }
}