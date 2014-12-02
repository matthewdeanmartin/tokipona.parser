using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Parser;

namespace BasicTypes
{
    public class WordSetTypeConverter : TypeConverter
    {
        public static T GetDefaultValue<T>(object propertyName)
        {
            var tc = TypeDescriptor.GetConverter(typeof(T));
            return (T)tc.ConvertFrom(propertyName);
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            // If true, then we return, say the dictionary. But AFAIK, this is a VS designer feature.
            return false;
        }

        //public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        //{
        //    StandardValuesCollection svc = new StandardValuesCollection(Words.Dictionary);
        //    return svc;
        //}

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;

            //This seem unlikely to ever be useful. Maybe for numeric types?
            return base.CanConvertFrom(context, sourceType);
        }


        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value.GetType() == typeof(string))
            {
                return Parse(value);
            }

            //Again, when would this ever work? Maybe numerics?
            return base.ConvertFrom(context, culture, value);
        }

        public static WordSet Parse(object value)
        {
            TokenParserUtils pu = new TokenParserUtils();
            Word[] words = pu.ValidWords(value.ToString()); //Can't be particles
            WordSet wordSet = new WordSet(words);
            return wordSet;
        }
    }
}
