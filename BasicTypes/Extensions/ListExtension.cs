using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Extensions
{
    public static class ListExtension
    {
        public static void  AddRange(this List<string> list, Particle particle, IEnumerable<string> strings)
        {
            int i = 0;
            foreach (string s in strings)
            {
                i++;
                if (i > 1)
                {
                    list.Add(particle.ToString());
                }
                list.Add(s);
            }
        }
        public static string SpaceJoin(this List<string> list, string format)
        {
            string[] parts = list.Where(x => NeedIt(format, x)).ToArray();
            if (format == "b" || format=="bs")
            {
                StringBuilder sb= new StringBuilder();
                string bracketedWithExtra =String.Join(" ", parts);
                for (int index= 0; index < bracketedWithExtra.Length; index++)
                {
                    char c = bracketedWithExtra[index];
                    if (c != ' ')
                        sb.Append(c);
                    else
                    {
                        if (index == 0) continue; //skip first space e.g. " foo"
                        if(index-1>0 && bracketedWithExtra[index-1]==' ') continue; //skip double, e.g. foo  bar
                        if (index - 1 >= 0 &&  "<{[(".Contains(bracketedWithExtra[index - 1])) continue; //previous was opening, e.g. "[ foo"
                        if (index + 1 < bracketedWithExtra.Length && ">}])".Contains(bracketedWithExtra[index +1])) continue; //skip if upcoming is closing bracket e.g. foo)

                        //if (index - 1 > 0 && "<{[(".Contains(bracketedWithExtra[index - 1])) continue; //previous was opening, e.g. "[ foo"

                        sb.Append(" ");

                    }
                }
                return sb.ToString();
            }
            else
                return String.Join(" ", parts);
        }

        public static bool NeedIt( string format, string value)
        {
            if (format == null || format == "g" || format=="")
            {
                if (value.Length == 0) return false; //Never need empties

                //To long to be punctuation
                if (value.Length > 1) return true; //Full word at least

                //<> = S
                //{} = Predicate
                //[] = modifiers
                //() = NP/VP

                return !("<>{}[]()".Contains(value[0])); //Not a bracket? Keep it.
            }

            if (format == "b" || format == "bs")//bracketed
            {
                //Keep it all!
                return true;
            }
            throw new ArgumentOutOfRangeException("format","Expected format of null, g (general) or b (bracketed), got " + format);
        }
    }
}
