using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;

namespace BasicTypes
{
    
    [Serializable]
    public class TpDate:Token
    {
        public TpDate(string word):base(word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentException("Null or blank date");
            }
            
            //Is it really a date?

            this.word = word;
        }
    }
}
