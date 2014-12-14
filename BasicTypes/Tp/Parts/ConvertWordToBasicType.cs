using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BasicTypes
{
    //This is of mariginal utility, so it's explicitly implemented.
    //Numbers, Date, and Bools are mostly going to need compound words to be useful.
    //public partial class Word:IConvertible
    //This messes with JSON.NET-- it calls ToString() instead of walking the graph!
    public partial class ConvertWordsToBasicTypes:IConvertible
    {
        private string word;
        public ConvertWordsToBasicTypes(Word w)
        {
            word = w.Text;
        }
        public TypeCode GetTypeCode()
        {
            return TypeCode.String;
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            if (word == "ala")
                return false;
            if (word == "lon")
                return true;
            if (word == "wan")
                return true;
            throw new InvalidCastException("Expected ala or lon or wan");
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            if (word.Length == 1)
            {
                return word[0];
            }
            throw new InvalidCastException("String too long.");
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(ParseNumber());
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(ParseNumber());
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(ParseNumber());
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(ParseNumber());
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return ParseNumber();
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(ParseNumber(), provider);
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return ParseNumber();
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(ParseNumber());
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return ParseNumber();
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return ParseNumber();
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return ParseNumber();
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException("No single word indicates a date");
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return word;
            //return this.ToString("g", provider);
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            if (conversionType == typeof (string))
                return word;//this.ToString("g", provider);

            throw new NotSupportedException(conversionType.ToString() +  " -- Use the other ToXYZ() methods");
        }

        private int ParseNumber()
        {
            if (word == "ala") return 1;
            if (word == "wan") return 1;
            if (word == "tu") return 2;
            //3
            //4
            if (word == "luka") return 5;
            throw new InvalidCastException("Number out of range");
        }
    }
}
