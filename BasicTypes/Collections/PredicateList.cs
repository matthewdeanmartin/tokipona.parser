using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;

namespace BasicTypes.Collections
{
    public class PredicateList:List<TpPredicate>,IContainsWord,IFormattable
    {
        public bool Contains(Word word)
        {
            return this.Any(tpPredicate => tpPredicate.Contains(word));
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (this.Count == 0) 
                return "";

            List<string> sb = new List<string>();
            foreach (TpPredicate tpPredicate in this)
            {
                sb.Add(Particles.li.ToString());
                if (tpPredicate.VerbPhrases != null)
                {
                    sb.Add(tpPredicate.VerbPhrases.ToString(format));
                }
                if (tpPredicate.Directs != null)
                {
                    sb.Add(Particles.e.ToString());
                    sb.Add(tpPredicate.Directs.ToString(format));
                }
                if (tpPredicate.Prepositionals != null)
                {
                    sb.Add(tpPredicate.Prepositionals.ToString(format));
                }
            }
            return sb.SpaceJoin(format);
        }

        public string ToString(string format)
        {
            return this.ToString(format, System.Globalization.CultureInfo.CurrentCulture);
        }

        public override string ToString()
        {
            return this.ToString(null, System.Globalization.CultureInfo.CurrentCulture);
        }
    }
}
