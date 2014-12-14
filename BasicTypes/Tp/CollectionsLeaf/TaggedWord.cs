using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;
using BasicTypes.Exceptions;
using BasicTypes.Extensions;
using BasicTypes.Html;

namespace BasicTypes.CollectionsLeaf
{
    /// <summary>
    /// Tag words can create "phrases" that appear anywhere a word can appear and have a scope of as little as one word.
    /// </summary>
    /// <remarks>
    /// These constructions can also have the scope of a phrase, but would be dealt with at the phrase level.
    /// </remarks>
    [DataContract]
    [Serializable]
    public class TaggedWord : Word, IContainsWord, IFormattable, IToString
    {
        public Word head;
        public WordList tags;

        public static string[] TagWords = new string[] {"kin","ala"};
        
        public TaggedWord(Word head, WordList tags)
        {
            if (tags == null || tags.Count == 0)
            {
                throw new TpSyntaxException("A TaggedWord needs at least one tag, or it is just a Word.");
            }
            bool unfamiliarTag = false;
            bool isXalaX = false;
            bool isReduplication= false;
            foreach (Word tag in tags)
            {
                if (tag.Text != head.Text)
                {
                    continue;
                }
                isReduplication = true;
            }
            foreach (Word tag in tags)
            {
                if (!TagWords.Contains(tag.Text))
                {
                    unfamiliarTag = true;
                }
            }
            if (unfamiliarTag)
            {
                if (tags.Count >= 3)
                {
                    if (tags[0].Text == "ala" && tags[2].Text == tags[1].Text)
                    {
                        isXalaX = true;
                    }
                }
            }

            if (!isXalaX && unfamiliarTag && !isReduplication)
            {
                throw new TpSyntaxException("This isn't a known tag word and isn't an X ala X construction");
            }

            //The main thing the base constructor did.
            this.word = head.Text + " " + tags.ToString("g");

            this.head = head;
            this.tags = tags;
        }

        public bool Contains(Word word)
        {
            if (head.Text == word.Text) return true;
            return tags.Contains(word);
        }

        public override string ToString()
        {
            return this.ToString("g", Dialect.LooseyGoosey);
        }

        public override string ToString(string format, IFormatProvider formatProvider)
        {
            Dialect c = formatProvider.GetFormat(typeof(Word)) as Dialect;

            string headString = head.ToString(format, formatProvider);
            List<string> parts = new List<string>(tags.Count);
            foreach (Word tag in tags)
            {
                parts.Add(tag.ToString(format, formatProvider));
            }


            if (format == "html")
            {
                return headString + " " + HtmlTagHelper.SpanWrap("conjunction", string.Join(" ", parts));
            }
            else if (format.StartCheck("b"))
            {
                return headString + " |" + string.Join(" ", parts) + "| ";
            }
            else
            {
                return headString + " " + string.Join(" ", parts);
            }
            
        }

        public string[] SupportedsStringFormats { get; private set; }

        public static bool CheckIsTagWord(string value)
        {
            if (value.ContainsCheck("ala")) return true;
            if (value.ContainsCheck("kin")) return true;
            if (value.ContainsCheck(" "))
            {
                string[] parts= value.Split(new char[] {' '});
                if (parts.Distinct().Count() != parts.Count()) return true;
            }
            return false;
        }
    }
}
