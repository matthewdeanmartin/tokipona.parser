using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Exceptions;

namespace BasicTypes.Collections
{
    //jan o!
    //differs from jan o moku! (o overlays li, at least for 1st verb)
    //differs from o jan li moku. (sentence prefixed by o)
    //differs from o!
    //Supports a maximal form of jan pi ma suli en meli pi ma suli o!
    //But probably should be jan pi ma suli o! meli pi ma suli o!
    [DataContract]
    [Serializable]
    public class Vocative : IContainsWord, IFormattable, IToString
    {
        [DataMember]
        private readonly ComplexChain nominal;
        public Vocative(ComplexChain nominal)
        {
            if (nominal == null)
            {
                throw new TpSyntaxException("Nominal required");
            }
            this.nominal= nominal;
        }

        public ComplexChain Nominal{ get { return nominal; } }

        public List<string> ToTokenList(string format, IFormatProvider formatProvider)
        {
            List<string> sb = new List<string>();
            sb.AddRange(nominal.ToTokenList(format,formatProvider));
            return sb;
        }

        public bool Contains(Word word)
        {
            if (nominal != null)
            {
                return nominal.Contains(word);
            }
            return false;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (nominal != null)
            {
                return nominal.ToString(format, formatProvider);
            }
            return "";
        }

        public string[] SupportedsStringFormats { get; private set; }

        public string ToString(string format)
        {
            if (format == null)
            {
                format = "g";
            }
            return ToString(format, Config.CurrentDialect);
        }

        public override string ToString()
        {
            return ToString("g", Config.CurrentDialect);
        }

    }
}
