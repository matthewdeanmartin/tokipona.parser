using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;

namespace BasicTypes.Collections
{
    //xxx anu seme?
    //Appears only at end of sentence, I think. Not sure.
    public class TagQuestion : IContainsWord, IFormattable, IToString
    {
        readonly WordList worlList = new WordList(){Words.anu, Words.seme};

        //Kind of degenerate structure.
        public TagQuestion()
        {
            
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
            {
                format = "g";
            }
            List<string> sb = ToTokenList(format, formatProvider);

            return sb.SpaceJoin(format);
        }

        public List<string> ToTokenList(string format, IFormatProvider formatProvider)
        {
            List<string> sb = new List<string>();
            sb.AddRange(worlList.ToTokenList(format,formatProvider));
         
            return sb;
        }


        public string[] SupportedsStringFormats
        {
            get
            {
                return new[] { "g" };
            }
        }

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

        public bool Contains(Word word)
        {
            return worlList.Contains(word);
        }


    }

    }
}
