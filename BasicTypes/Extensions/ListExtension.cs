using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Extensions
{
    public static class ListExtension
    {
        [DebuggerStepThrough]
        public static void AddIfNotReduplicate(this List<string> list, string value)
        {
            if (list.Count >0 &&  list[list.Count - 1] == value)
            {
                return;
                //throw new InvalidOperationException("Reduplicate");
            }
            list.Add(value);
        }

        public static void Format(this List<string> template, Dictionary<string,string> values)
        {
            //Swap {#n} tokens found in list with n#th value in values
            
        }

        //ParseFormat( ni/li/pona/tawa/mi,  {XX}{0}/li/pona{XX}/tawa/{1}{XX}  where XX is extra crap.
        public static void ParseFormat(this List<string> list, List<string> template)
        {
            //Return all the possible matching lists of tokens
            //Can be exact, or match despite extra stuff 
        }

        [DebuggerStepThrough]
        public static void AddIfNeeded(this List<string> list, string marker, string format)
        {
            if (format.StartCheck("b"))
            {
                list.Add(marker);
            }
        }

        [DebuggerStepThrough]
        public static void AddRange(this List<string> list, Particle particle, IEnumerable<string> strings, string format, IFormatProvider formatProvider, bool hasParent)
        {
            int i = 0;
            foreach (string s in strings)
            {
                i++;
                if (particle.MiddleOnly)
                {
                    //more than 1? must join!
                    //0? Well, depends on where we are. If we have a parent, must join
                    if (i > 1 || hasParent)
                    {
                        if (list.Count > 0)
                        {
                            string lastWord = list[list.Count - 1];

                            if (!Token.CheckIsParticle(lastWord) && !Token.CheckIsConjunction(lastWord))
                            {
                                list.AddIfNotReduplicate(particle.ToString(format, formatProvider));
                            }
                        }
                    }
                }
                else
                {
                    if (list.Count > 0)
                    {
                        string lastWord = list[list.Count - 1];
                        if ((!Particle.CheckIsParticle(lastWord) && !Token.CheckIsConjunction(lastWord)))
                        {
                            list.AddIfNotReduplicate(particle.ToString(format, formatProvider));
                        }
                    }
                    else if (list.Count == 0)
                    {
                        list.AddIfNotReduplicate(particle.ToString(format, formatProvider));
                    }
                }
                list.Add(s);
            }
        }

        [DebuggerStepThrough]
        public static string SpaceJoin(this List<string> list, string format)
        {
            if (format == "html")
            {
                //At the moment, HTML generates only HTML
                //Nothing needs to be stripped out.
                return String.Join(" ", list);
            }

            string[] parts = list.Where(x => NeedIt(format, x)).ToArray();
            if (format == "b" || format=="bs")
            {
                StringBuilder sb= new StringBuilder();
                string bracketedWithExtra =String.Join(" ", parts);

                bool togglePipe = true;
                for (int index= 0; index < bracketedWithExtra.Length; index++)
                {
                    char c = bracketedWithExtra[index];
                    if (c != ' ')
                        sb.Append(c);
                    else
                    {
                        if (index == 0) continue; //skip first space e.g. " foo"
                        if(index-1>0 && bracketedWithExtra[index-1]==' ') continue; //skip double, e.g. foo  bar
                        if (index - 1 >= 0 && "<{[(#\\".ContainsCheck(bracketedWithExtra[index - 1])) continue; //previous was opening, e.g. "[ foo"
                        if (index + 1 < bracketedWithExtra.Length && ">}])/".ContainsCheck(bracketedWithExtra[index +1])) continue; //skip if upcoming is closing bracket e.g. foo)

                        //Toggles
                        if (togglePipe && (index - 1 >= 0 && "|".ContainsCheck(bracketedWithExtra[index - 1])))
                        {
                            togglePipe = !togglePipe;
                            continue; 
                        }
                        
                        if (!togglePipe && (index + 1 < bracketedWithExtra.Length && "|".ContainsCheck(bracketedWithExtra[index + 1]))) 
                        {
                            togglePipe = !togglePipe;
                            continue; 
                        }

                        sb.Append(" ");
                    }
                }
                return sb.ToString();
            }
            else
                return String.Join(" ", parts);
        }

        [DebuggerStepThrough]
        public static bool NeedIt(string format, string value)
        {
            
            if (format == null || format == "g" || format == "" || format == "t")
            {
                if (value.Length == 0) return false; //Never need empties

                //To long to be punctuation
                if (value.Length > 1) return true; //Full word at least

                //<> = S
                //{} = Predicate
                //[] = modifiers
                //() = NP/VP

                return !("<>{}[]()#".ContainsCheck(value[0])); //Not a bracket? Keep it.
            }

            if (format == "b" //bracketed
                ||
                format == "bs" //Don't denormalize
                // || "bhhtml"  
                )
            {
                //Keep it all!
                return true;
            }
            
            throw new ArgumentOutOfRangeException("format","Expected format of null, g (general) or b (bracketed), got " + format);
        }
    }
}
