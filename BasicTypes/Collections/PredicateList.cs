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
            if (format == null)
            {
                format = "g";
            }
            if (this.Count == 0) 
                return "";

            var sb = ToTokenList(format, formatProvider);
            return sb.SpaceJoin(format);
        }

        public List<string> ToTokenList(string format, IFormatProvider formatProvider, bool suppressFirstLi=false)
        {
            List<string> sb = new List<string>();
            int i = 0;
            foreach (TpPredicate tpPredicate in this)
            {
                if (i == 0 && suppressFirstLi && tpPredicate.Particle.Text=="li")
                {
                    //skip!
                }
                else
                {
                    sb.Add(tpPredicate.Particle.ToString(format, formatProvider));
                }
                i++;

                //Don't think you can have both
                if (tpPredicate.NominalPredicate != null)
                {
                    sb.AddRange(tpPredicate.NominalPredicate.ToTokenList(format, formatProvider));
                }
                else if (tpPredicate.VerbPhrase != null)
                {
                    //, tpPredicate.Directs!=null
                    sb.AddRange(tpPredicate.VerbPhrase.ToTokenList(format, formatProvider));
                }

                //Can have nominal predicate & direct object. (tranformative thingy)
                if (tpPredicate.Directs != null)
                {
                    sb.AddRange(tpPredicate.Directs.ToTokenList(format, formatProvider)); //Chains manage their own particles.
                }
                if (tpPredicate.Prepositionals != null)
                {
                    foreach (PrepositionalPhrase phrase in tpPredicate.Prepositionals)
                    {
                        sb.AddRange(phrase.ToTokenList(format, formatProvider));    
                    }
                    
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
            if (format == null)
            {
                format = "g";
            }
            return this.ToString(format, Config.CurrentDialect);
        }

        public override string ToString()
        {
            return this.ToString("g", Config.CurrentDialect);
        }
    }
}
