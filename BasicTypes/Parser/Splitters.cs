using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BasicTypes.Exceptions;
using BasicTypes.Extensions;

namespace BasicTypes.Parser
{
    class Splitters
    {
        public static string[] SplitOnE(string value)
        {
            string[] eParts = Regex.Split(value, @"\s(?=\be\b)");

            return eParts;
        }

        //Split on en
        // jan en soweli
        public static string[] SplitOnEn(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Impossible to parse a null or zero length string.");
            }
            //HACK
            if (value.ContainsCheck("-en-") && !value.ContainsCheck(" en "))
            {
                return new string[]{value};
            }
            Regex splitOnEn = new Regex("\\b" + Particles.en.Text + "\\b");
            string[] subjectTokens = splitOnEn.Split(value).Select(x => x.Trim()).ToArray();
            return subjectTokens;
        }

        public static string[] SplitOnPi(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Impossible to parse a null or zero length string.");
            }
            if (value.ContainsCheck("-") &&  value.ContainsCheck("-pi-"))
            {
                value = value.Replace("-pi-", "ZZZZZZZZZZZZ");
            }
            if (value.ContainsCheck("*") && value.ContainsCheck("*pi*"))
            {
                value = value.Replace("*pi*", "VVVVVVVVVVV");
            }
            Regex splitOnPi = new Regex("\\b" + Particles.pi.Text + "\\b");
            string[] piLessTokens = splitOnPi.Split(value).Select(x => x.Trim()).ToArray();
            if (piLessTokens.Any(string.IsNullOrEmpty))
            {
                //if (value.Contains(" pi "))
                //{
                    throw new TpSyntaxException("This implies a phrase like pi pi... source: " + value);
                //}
                //else
                //{
                //    piLessTokens = piLessTokens.Where(!string.IsNullOrEmpty(x))
                //}
            }
            for (int i = 0; i < piLessTokens.Length; i++)
            {
                if (piLessTokens[i].ContainsCheck("ZZZZZZZZZZZZ"))
                {
                    piLessTokens[i]=piLessTokens[i].Replace("ZZZZZZZZZZZZ", "-pi-");
                }
            }
            for (int i = 0; i < piLessTokens.Length; i++)
            {
                if (piLessTokens[i].ContainsCheck("VVVVVVVVVVV"))
                {
                    piLessTokens[i] = piLessTokens[i].Replace("VVVVVVVVVVV", "*pi*");
                }
            }
            return piLessTokens;
        }







        //O overlays li for imperative verbs phrases. So it's the same split
        //Same story as pphrases
        public static string[] SplitOnLiOrO(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Impossible to parse a null or zero length string.");
            }
            string pattern = @"{0}\b";
            string[] verbMarkers = new string[] { "li", "o" };
            //string[] preps = new string[] { "kepeken", "tawa", "poka", "sama", "tan", };
            string parts = string.Join("|", verbMarkers.Select(x => String.Format(pattern, x)));
            //@"\s(?=\bkepeken\b|\bsama\b|\btawa\b|\btawa\b)"

            string[] verbPhraseTokens = Regex.Split(value, @"\s(?=" + parts + ")")
                                             .Select(x => x.Trim())
                                             .Where(x => !string.IsNullOrEmpty(x))
                                             .ToArray();

            if (verbPhraseTokens.Length == 0)
            {
                throw new InvalidOperationException("Whoa, got zero parts for " + value);
            }
            return verbPhraseTokens;
        }

        public static string[] SplitOnLi(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Impossible to parse a null or zero length string.");
            }
            string[] parts = Regex.Split(value, "\\b" + Particles.li.Text + "\\b").Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            //if (parts.Length == 0)
            //{
            //    throw new InvalidOperationException("Parse lost all parts for " + value);
            //}
            return parts;
        }

        public static string[] SplitOnO(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Impossible to parse a null or zero length string.");
            }
            Regex oParts = new Regex("\\b" + Particles.o.Text + "\\b");
            string[] liParts = oParts.Split(value).Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            return liParts;
        }


        /// <summary>
        /// Preserve the la & returns at least 1 part.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string[] SplitOnLa(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Impossible to parse a null or zero length string.");
            }
            //Regex splitOnEn = new Regex("\\b" + Particles.la.Text + "\\b");
            string parts = @"\bla\b";
            string[] tokens = Regex.Split(value, @"\s(?=" + parts + ")").Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            return tokens;
        }

        public static string[] SplitOnPrepositions(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Impossible to parse a null or zero length string.");
            }
            string pattern = @"{0}\b";
            string[] preps = new string[] { "~kepeken", "~tawa", "~poka", "~sama", "~tan", "~lon" };

            string parts = string.Join("|", preps.Select(x => String.Format(pattern, x)));
            //@"\s(?=\bkepeken\b|\bsama\b|\btawa\b|\btawa\b)"
            Regex splitOnEn = new Regex(@"\s(?=" + parts + ")");
            string[] prepTokens = splitOnEn.Split(value).Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            if (prepTokens.Any(x => x.ContainsCheck(" ~")))
            {
                throw new InvalidOperationException("Split failed");
            }
            if (prepTokens.Length == 0)
            {
                throw new InvalidOperationException("Whoa, got zero parts for " + value);
            }
            for (int i = 0; i < prepTokens.Length; i++)
            {
                string prepToken = prepTokens[i];
                //Change mind?
                //HACK: Not sure why this happens
                if (prepToken.ContainsCheck(" e "))
                {
                    prepTokens[i] = prepToken.Replace("~", "");
                }
                //If the phrase is like, "li ~kepeken"  then it is an verb intr.
                //Hard to distinguish from li kepken mute (vi.)
                if (!prepToken.Trim().ContainsCheck(" "))
                {
                    prepTokens[i] = prepToken.Replace("~", "");
                }
            }
            return prepTokens;

        }

        public static string[] SplitOnParticle(Particle particle, string value)
        {
            Regex splitOnParticle = new Regex("\\b" + particle.Text + "\\b");
            string[] tokens = splitOnParticle.Split(value).Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            return tokens;
        }

        //Gah, what a mess.
        [Obsolete]
        public static string[] SplitOnParticlePreserving(Particle particle, string value)
        {
            StringBuilder sb = new StringBuilder();
            List<string> parts = new List<string>();
            for (int i = 0; i < value.Length; i++)
            {
                string possible = value.Substring(i, particle.Text.Length);
                if (particle.Text == possible)
                {
                    if (i < value.Length - 1)
                    {
                        string nextChar = value.Substring(i + 1, 1);
                        string lastChar = " ";
                        if (i - particle.Text.Length >= 0)
                        {
                            lastChar = value.Substring(i - particle.Text.Length, 1);

                        }

                        if (nextChar == " " || IsBoundary(nextChar) && IsBoundary(lastChar))
                        {
                            parts.Add(sb.ToString());
                            sb = new StringBuilder();

                        }
                    }
                    else
                    {
                        parts.Add(sb.ToString());
                        sb = new StringBuilder();
                    }
                }
                sb.Append(value[i]);
            }
            parts.Add(sb.ToString());
            return parts.ToArray();
        }


        private static bool IsBoundary(string boundary)
        {
            Regex matcher = new Regex("[a-zA-Z]");
            Match c = matcher.Match(boundary);

            return !c.Success;

        }
    }
}
