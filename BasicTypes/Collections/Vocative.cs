using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Exceptions;

namespace BasicTypes.Collections
{
    public class Vocative
    {
        [DataMember]
        private readonly Chain nominal;
         public Vocative(Chain nominal)
        {
            if (nominal == null)
            {
                throw new TpSyntaxException("Nominal required");
            }
            this.nominal= nominal;
        }

         public Chain Nominal{ get { return nominal; } }

        public List<string> ToTokenList(string format, IFormatProvider formatProvider)
        {
            List<string> sb = new List<string>();
            sb.AddRange(nominal.ToTokenList(format,formatProvider));
            return sb;
        }
    }
}
