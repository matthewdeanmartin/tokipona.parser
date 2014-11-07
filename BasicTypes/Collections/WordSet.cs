using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes
{
    /// <summary>
    /// Unordered words.
    /// </summary>
    /// <remarks>
    /// Oh oh, this may be same concept as headed phrase.
    /// </remarks>
    [Serializable]
    public class WordSet : HashSet<Word>, IContainsWord, IFormattable, IToString
    {
        public WordSet():base()
        {
        }
        public WordSet(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public WordSet(IEnumerable<string> strings)
            : base()
        {
            foreach (string s in strings)
            {
                this.Add(new Word(s));
            }
        }

        public WordSet(IEnumerable<Word> strings)
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
            return ToString("g", Dialect.DialectFactory);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
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
