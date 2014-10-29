using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Parser;

namespace BasicTypes
{
    public partial class Word: IParse<Word>
    {
        public static Word Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("value is null or zero length string");
            }
            return new Word(value);
        }

        public static Word Parse(string value, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("value is null or zero length string");
            }
            if (provider == null)
            {
                throw new ArgumentNullException("provider", "IFormatProvider can't be null");
            }
            Dialect c = provider.GetFormat(typeof(Punctuation)) as Dialect;

            TokenParserUtils pu = new TokenParserUtils();
            string[] possibleWords = pu.JustTpWords(value);
            return new Word(possibleWords[0], provider);
        }


        public static bool TryParse(string value, out Word result)
        {
            return TryParse(value, Config.CurrentDialect, out result);
        }

        public static bool TryParse(string value, IFormatProvider provider, out Word result)
        {
            

            try
            {
                result = Parse(value, provider);
                return true;
            }
            catch (Exception)
            {
                result = null;
                return false;
            }
        }
        
        //Used by unit test to allow for calling parse on the ToString of each object that support ToString

        bool IParse<Word>.TryParse(string value, out Word result)
        {
            return TryParse(value, out result);
        }

        bool IParse<Word>.TryParse(string value, IFormatProvider provider, out Word result)
        {
            return TryParse(value, provider, out result);
        }

        Word IParse<Word>.Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("value is null or zero length string");
            }
            return Parse(value);
        }
    }
}
