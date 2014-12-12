using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;

namespace BasicTypes.NormalizerCode
{
    //This should be idempotent. If you normalize it over & over, it should be the same thing.
    //The assumption here is the user has marked *all* numbers, neologism, prepositions appropriate
    public class NormalizeExplicit
    {
        private readonly Dialect dialect;
        public NormalizeExplicit(Dialect dialect)
        {
            this.dialect = dialect;
        }

        public static string NormalizeText(string text, Dialect dialect) //= null
        {
            SentenceDiagnostics sd = new SentenceDiagnostics(text, "N/A");

            //Remove stray punct, but not preposition

            //Remove other cruft (double spaces, etc)
            return "";
        }
    }
}
