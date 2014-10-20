using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicTypes
{
    //la,li,pi,e,preps (preps simplified to either ~prep or lon-prep)
    [DataContract]
    [Serializable]
    public class Particle:IFormattable
    {
        [DataMember]
        private readonly string particle;

        [DataMember]
        private readonly bool middleOnly;

        public  static string[] dictionary = new string[]
        {
            "la", //Sentence conj.

             //"en", //subject chains, but also other things. The only one where it is skipped for 1st.

            //Conj not supported yet... Treat as content word
            //"anu",//Sentence conj. - Joins NPs but also prefixes sentences
            //"taso",//Sentence conj. - 

            "li",
            "o", //overlays li
            "pi",
            "e",
            "~kepeken",
            "~tawa",
            "~sike",
            "~poka"
        };

        public Particle(string particle)
        {
            //TODO: Validate, particles is a closed class.

            this.particle = particle;
            if (particle == "en" || particle == "pi" || particle ==" ")
            {
                middleOnly = true;
            }
            else
            {
                middleOnly = false;
            }
        }

        public string Text { get { return particle; } }
        public bool MiddleOnly { get { return middleOnly; } }

        public override string ToString()
        {
            
            return ToString("g", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        //Dupe
        public string ToString(string format, IFormatProvider formatProvider)
        {
            //// Handle null or empty string. 
            if (String.IsNullOrEmpty(format)) format = "g";
            // Remove spaces and convert to uppercase.
            format = format.Trim();
            if (format == null || format == "g" || format == "G")
                return Text;

            bool includePos = false;
            if (format.Contains(":"))
            {
                string[] parts = format.Split(new char[] { ':' });
                format = parts[0];
                includePos = Convert.ToBoolean(parts[1]);
            }
            CultureInfo ci = Thread.CurrentThread.CurrentCulture;

            if (ci.TwoLetterISOLanguageName == "tp") //Can only happen if we can install a custom culture. Not worth the effort.
            {
                return Text;
            }
            else if (ci.TwoLetterISOLanguageName == "en")
            {
                string language = ci.TwoLetterISOLanguageName;
                if (includePos)
                    return TryGloss(language, format) + "(" + format + ")";
                else
                {
                    return TryGloss(language, format);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Can't translate to " + ci.ThreeLetterISOLanguageName);
            }

        }

        //Dupe
        private string TryGloss(string language, string pos)
        {

            Word w;

            if (Particle.IsParticle(Text))
            {
                w = Words.Dictionary[Text];
            }
            else
            {
                w = new Word(Text);

            }
            
            if (w.GlossMap == null)
            {
                return "[missing map for " + Text + "]";
            }
            if (w.GlossMap.ContainsKey(language))
            {
                if (w.GlossMap[language].ContainsKey(pos))
                {
                    Random r = new Random(DateTime.Now.Millisecond);//TODO: Make this a part of config
                    string[] possibilities = w.GlossMap[language][pos];
                    return possibilities[r.Next(possibilities.Length)];
                }
            }

            if (language == "en")
            {
                switch (Text)
                {
                    case "la":
                        return "then";
                    case "pi":
                        return "of";
                    case "li":
                        return " ";
                    case "e":
                        return " ";
                    case "o":
                        return "Hey!";
                }
            }

            foreach (KeyValuePair<string, Dictionary<string, string[]>> pair in w.GlossMap)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in pair.Value)
                {
                    if (item.Value != null && item.Value.Length > 0)
                    {
                        sb.Append(item.Key + " : " + string.Join(",", item.Value) + "; ");
                    }
                }
                Console.WriteLine(pair.Key + " : " + sb.ToString());
            }

            if (!((Text.ToUpper())[0] == Text[0]))
            {
                return "[Error " + pos + " " + Text + " " + language + "]";
            }
            else
                return Text;
        }

        public static bool IsParticle(string token)
        {
            return dictionary.Contains(token);
        }

        public static bool ContainsProposition(string phrase)
        {

            if (!phrase.Contains(phrase))
            {
                return false;
            }
            string[] parts = phrase.Split(new string[] { " ", Environment.NewLine, ".", "!", "?" }, StringSplitOptions.RemoveEmptyEntries);
            var preps = dictionary.Where(z => z.StartsWith("~"));
            
            foreach (string prep in preps)
            {
                if (parts.Contains(prep))
                {
                    return true;
                }
            }
            return false;
        }

        public  bool ContainsPreposition(string phrase)
        {
            if (!phrase.Contains(phrase))
            {
                return false;
            }
            string[] parts = phrase.Split(new string[] { " ", Environment.NewLine, ".", "!", "?" }, StringSplitOptions.RemoveEmptyEntries);
            return parts.Contains(particle);
        }
    }

    public class ParticleByValue : EqualityComparer<Word>
    {
        public override bool Equals(Word x, Word y)
        {
            return StringComparer.InvariantCulture.Equals(x.Text, y.Text);
        }

        public override int GetHashCode(Word obj)
        {
            return StringComparer.InvariantCulture.GetHashCode(obj);
        }
    }
}
