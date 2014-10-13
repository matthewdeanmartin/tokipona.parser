using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Collections
{
    public class PredicateList:List<TpPredicate>,IContainsWord
    {
        public bool Contains(Word word)
        {
            return this.Any(tpPredicate => tpPredicate.Contains(word));
        }

        public override string ToString()
        {
            if (this.Count == 0) return "";

            StringBuilder sb = new StringBuilder();
            foreach (TpPredicate tpPredicate in this)
            {
                sb.Append("li ");
                if (tpPredicate.VerbPhrases != null)
                {
                    sb.Append(tpPredicate.VerbPhrases != null ? tpPredicate.VerbPhrases.ToString() : "");
                }
                if (tpPredicate.Directs != null)
                {
                    sb.Append("e ");
                    sb.Append(tpPredicate.Directs != null ? tpPredicate.Directs.ToString() : "");
                }
                if (tpPredicate.Prepositionals != null)
                {
                    sb.Append(tpPredicate.Prepositionals != null ? tpPredicate.Prepositionals.ToString() : "");
                }
            }
            // "li " + string.Join(" ", this.Select(x => ).ToArray())
            //+" " +
            //string.Join(" ", this.Select(x => x.Directs != null ? x.Directs.ToString() : "").ToArray())
            //+ " " +
            //string.Join(" ", this.Select(x => x.Prepositionals != null ? x.Prepositionals.ToString() : "").ToArray());
            return sb.ToString().Trim();
        }
    }
}
