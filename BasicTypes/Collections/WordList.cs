using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Collections
{
    /// <summary>
    /// An ordered list of words, numeric modifiers, serial verbs.
    /// </summary>
    [Serializable]
    public class WordList : List<Word>, IContainsWord, IFormattable, IToString
    {
        public WordList():base()
        {
        }
        public WordList(IEnumerable<string> strings)
            : base()
        {
            foreach (string s in strings)
            {
                this.Add(new Word(s));
            }
        }

        public WordList(IEnumerable<Word> strings)
            : base()
        {
            foreach (string s in strings)
            {
                this.Add(s);
            }
        }

        //Same if same jumble of words. E.g. the set of words following a noun.

        public override string ToString()
        {
            return this.ToString("g");
        }

        public static WordSet Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("value is null or zero length string");
            }
            return WordSetTypeConverter.Parse(value);
        }

        public static bool TryParse(string value, out WordSet result)
        {
            try
            {
                result = WordSetTypeConverter.Parse(value);
                return true;
            }
            catch (Exception)
            {
                result = null;
                return false;
            }
        }

        public string[] SupportedsStringFormats
        {
            get
            {
                return new string[] { "g", "b", "bs" };
            }
        }
        public string ToString(string format)
        {
            if (format == null)
            {
                format = "g";
            }
            return ToString(format, Dialect.DialectFactory);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
            {
                format = "g";
            }
            if (this.Count == 0) return "";
            List<string> tokens = ToTokenList(format, formatProvider);
            return string.Join(" ", tokens);
        }

        public List<string> ToTokenList(string format, IFormatProvider formatProvider)
        {
            return  this.Select(x => x.Text).ToList();
        }
    }
    
}
