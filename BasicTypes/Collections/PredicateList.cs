using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;

namespace BasicTypes.Collections
{
    public class PredicateList:List<TpPredicate>,IContainsWord,IFormattable, IToString
    {
        public bool Contains(Word word)
        {
            return this.Any(tpPredicate => tpPredicate.Contains(word));
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (this.Count == 0) 
                return "";

            var sb = ToTokenList(format, formatProvider);
            return sb.SpaceJoin(format);
        }

        public List<string> ToTokenList(string format, IFormatProvider formatProvider)
        {
            List<string> sb = new List<string>();
            foreach (TpPredicate tpPredicate in this)
            {
                sb.Add(tpPredicate.Particle.ToString(format, formatProvider));

                //Don't think you can have both
                if (tpPredicate.NominalPredicate != null)
                {
                    sb.AddRange(tpPredicate.NominalPredicate.ToTokenList(format, formatProvider));
                }
                else if (tpPredicate.VerbPhrases != null)
                {
                    sb.AddRange(tpPredicate.VerbPhrases.ToTokenList(format, formatProvider, tpPredicate.Directs!=null));
                }

                //Can have nominal predicate & direct object. (tranformative thingy)
                if (tpPredicate.Directs != null)
                {
                    sb.AddRange(tpPredicate.Directs.ToTokenList(format, formatProvider)); //Chains manage their own particles.
                }
                if (tpPredicate.Prepositionals != null)
                {
                    sb.AddRange(tpPredicate.Prepositionals.ToTokenList(format, formatProvider));
                }
            }
            return sb;
        }

        public string[] SupportedsStringFormats
        {
            get
            {
                return new string[] { "g" };
            }
        }

        public string ToString(string format)
        {
            return this.ToString(format, Config.CurrentDialect);
        }

        public override string ToString()
        {
            return this.ToString(null, Config.CurrentDialect);
        }
    }
}
