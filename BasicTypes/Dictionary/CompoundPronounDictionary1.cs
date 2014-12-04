using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Parts;

namespace BasicTypes.Dictionary
{
    public class CompoundPronouns
    {
        

        public static Dictionary<string, CompoundWord> Dictionary;
        public static Dictionary<string, Dictionary<string, Dictionary<string, string[]>>> Glosses;

        public static CompoundWord MiWan;
        public static CompoundWord MiTu;
        public static CompoundWord MiMute;
        public static CompoundWord MiSuli;
        public static CompoundWord MiMeli;
        public static CompoundWord MiMije;
        
        public static CompoundWord SinaWan;
        public static CompoundWord SinaTu;
        public static CompoundWord SinaMute;
        public static CompoundWord SinaSuli;
        public static CompoundWord SinaMeli;
        public static CompoundWord SinaMije;

        public static CompoundWord OnaWan;
        public static CompoundWord OnaTu;
        public static CompoundWord OnaMute;
        public static CompoundWord OnaSuli;
        public static CompoundWord OnaMeli;
        public static CompoundWord OnaMije;

        static CompoundPronouns()
        {
            Dictionary = new Dictionary<string, CompoundWord>(25);
            Glosses = new Dictionary<string, Dictionary<string, Dictionary<string, string[]>>>(25);

            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mi-wan", new[] { "I","me" });
                    glossMap.Add("en", en);
                }
                MiWan= new CompoundWord("mi-wan");

                Dictionary.Add("mi-wan", MiWan);
                Glosses.Add("mi-wan", glossMap);
            }
    
        }
        
    }
}
