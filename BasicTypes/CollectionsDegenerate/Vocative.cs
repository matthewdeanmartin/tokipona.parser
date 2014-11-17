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
    public class Vocative
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
    }
}
