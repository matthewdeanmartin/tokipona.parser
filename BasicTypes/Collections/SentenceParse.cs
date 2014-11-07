using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;

namespace BasicTypes
{
    public partial class Sentence
    {
        public static Sentence Parse(string value, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("value is null or zero length string");
            }
            return SentenceTypeConverter.Parse(value, formatProvider);
        }

        public static bool TryParse(string value, IFormatProvider formatProvider, out Sentence result)
        {
            try
            {
                result = SentenceTypeConverter.Parse(value, formatProvider);
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
