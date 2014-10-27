using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Parser;

namespace BasicTypes.Collections
{
    public class ChainTypeConverter: TypeConverter
    {
        public static T GetDefaultValue<T>(object propertyName)
        {
            var tc = TypeDescriptor.GetConverter(typeof(T));
            return (T)tc.ConvertFrom(propertyName);
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        //public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }


        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value.GetType() == typeof(string))
            {
                return Parse(value);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public static Chain Parse(object value)
        {
            string item = value.ToString(); //unbox
            if (string.IsNullOrEmpty(item))
            {
                throw new ArgumentException("value is null or zero length string");
            }

            Dialect c = Dialect.DialectFactory;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            if (item.Contains("~"))
            {
                string[] parts = Splitters.SplitOnPrepositions(item);
                pu.ProcessPrepositionalPhrases(parts);
            }

            if (item.Contains(" e ") || item.StartsWith("e "))
            {
                throw new NotImplementedException("Need a pi chain processor");
                //string[] parts = Splitters.SplitOnE(item);

                //HeadedPhrase
                //foreach (string part in parts)
                //{

                //}
                //Chain c  = new Chain(ChainType.Directs, Particles.e, pu.HeadedPhraseParser());
                //return c;
            }
            //If subject, then en & pi

            //If pp then 

            return pu.ProcessEnPiChain(item);
        }
    }
}
