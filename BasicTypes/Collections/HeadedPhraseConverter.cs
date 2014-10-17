using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Collections
{
    public class HeadedPhraseConverter : TypeConverter
    {
        public static T GetDefaultValue<T>(object propertyName)
        {
            var tc = TypeDescriptor.GetConverter(typeof (T));
            return (T) tc.ConvertFrom(propertyName);
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        //public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof (string) || base.CanConvertFrom(context, sourceType);
        }


        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture,
            object value)
        {
            if (value.GetType() == typeof (string))
            {
                return Parse(value);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public static HeadedPhrase Parse(object value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                throw new ArgumentException("value is null or zero length string");
            }
            ParserUtils pu = new ParserUtils(Config.Instance);
            return pu.HeadedPhraseParser(value.ToString());
        }
    }
}
