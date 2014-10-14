using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes
{
    [DataContract]
    [Serializable]
    public class Punctuation
    {
        [DataMember]
        private readonly string symbol;

        public Punctuation(string symbol)
        {
            this.symbol = symbol.Trim();
        }

        public override string ToString()
        {
            return symbol;
        }
    }
}
