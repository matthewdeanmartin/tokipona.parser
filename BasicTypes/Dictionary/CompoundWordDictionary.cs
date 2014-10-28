using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Parts;
using NUnit.Framework.Constraints;

namespace BasicTypes.Dictionary
{
    public class CompoundWords
    {
        public static Dictionary<string, CompoundWord> Dictionary;
        public static Dictionary<string, Dictionary<string, Dictionary<string, string[]>>> Glosses;

        public static CompoundWord TomoTawaKon;

        static CompoundWords()
        {

            Dictionary = new Dictionary<string, CompoundWord>();

            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] {"airplane"});
                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] {"[aeroplano?]"});
                    glossMap.Add("eo", eo);
                }
                TomoTawaKon = new CompoundWord("tomo-tawa-kon");

                Dictionary.Add("tomo-tawa-kon", TomoTawaKon);
                Glosses.Add("tomo-tawa-kon", glossMap);
            }
        }
    }
}
