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
    public class Punctuation: IParse<Punctuation>
    {
        [DataMember]
        private readonly string symbol;

        public Punctuation(string symbol)
        {
            symbol = symbol.Trim();
            if (symbol.Length != 1)
            {
                throw new InvalidOperationException("Punctuation must be 1 char long");
            }
            if (!":.?!".Contains(symbol))
            {
                throw new InvalidOperationException("Punctuation must be : or . or ? or !");
            }
            this.symbol = symbol;
        }

        public override string ToString()
        {
            return symbol;
        }

        public static Punctuation Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("value is null or zero length string");
            }
            return new Punctuation(value);
        }

        bool IParse<Punctuation>.TryParse(string value, out Punctuation result)
        {
            return TryParse(value, out result);
        }

        Punctuation IParse<Punctuation>.Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("value is null or zero length string");
            }
            return Parse(value);
        }

        public static bool TryParse(string value, out Punctuation result)
        {
            try
            {
                result = new Punctuation(value);
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
