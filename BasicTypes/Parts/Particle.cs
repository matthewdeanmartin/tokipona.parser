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
    public class Particle : Token, IFormattable, IToString
    {
        

        [DataMember]
        private readonly bool middleOnly;

        //These can't be content words ever, ever, ever.
        //This compares to kepeken (verb), taso (adj), etc.
        public static string[] NonContentParticles= new string[]
        {
            "la", 
            "li",
            "o", //exclamation
            "pi",
            "e"
        };

        public static string[] SimplePrepositions = new string[]
        {
            "~lon",
            "~kepeken",
            "~tawa",
            "~sike",
            "~poka",
            "~sama"
        };

        public static string[] dictionary = new string[]
        {
            "la", //Sentence conj.

             //"en", //subject chains, but also other things. The only one where it is skipped for 1st.

            //Conj not supported yet... Treat as content word
            //"anu",//Sentence conj. - Joins NPs but also prefixes sentences
            //"taso",//Sentence conj. - 

            "li",
            "o", //overlays li, also exclamation, & vocative
            "pi",
            "e",
            "~lon",
            "~kepeken",
            "~tawa",
            "~sike",
            "~poka",
            "~sama"
        };

        public Particle(string particle, bool iAmAPrepositionChain = false):base(particle, iAmAPrepositionChain)
        {
            if (!iAmAPrepositionChain)
            {
                if (string.IsNullOrWhiteSpace(particle))
                {
                    throw new ArgumentException("Got whitespace particle. What does this mean?");
                }
            }

            particle = ProcessPuncuation(particle);

            //TODO: Validate, particles is a closed class.

            this.word= particle;
            if (particle == "en" || particle == "pi" || particle == " ")
            {
                middleOnly = true;
            }
            else
            {
                middleOnly = false;
            }
        }

        
        public bool MiddleOnly { get { return middleOnly; } }
        public bool PreComma { get { return preComma; }}
        public bool PostComma { get { return postComma; } }

        public override string ToString()
        {

            return ToString("g", Dialect.DialectFactory);
        }

        public string[] SupportedsStringFormats
        {
            get
            {
                return new string[] { "g", "b", "bs" };
            }
        }

        //public string ToString(string format)
        //{
        //    return ToString(format, CultureInfo.CurrentCulture);
        //}

        //Dupe
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
            {
                format = "g";
            }
            Dialect c = formatProvider.GetFormat(typeof(Particle)) as Dialect;

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

            string language;
            if (c.TargetGloss == "thread")
            {
                language = ci.TwoLetterISOLanguageName;
            }
            else
            {
                language = c.TargetGloss;
            }

            if (language == "tp")
            {
                return Text==" "?"":Text; //And maybe POS
            }
            if (includePos)
                return TryGloss(language, format) + "(" + format + ")";
            else
            {
                return TryGloss(language, format);
            }


        }

        //Dupe
        private string TryGloss(string language, string pos)
        {
            if (Text == " ")
            {
                //This is for prepositional chains, which are joined by nothing
                //lon x lon y == chain, sort joined by lon
                //lon x lon y poka a poka b == chain, but these chains aren't anything!
                return " ";
            }
            Word w;


            string normalizeForLookup;
            if (Text.StartsWith("~"))
            {
                normalizeForLookup = Text.Substring(1);
                //pos should be prep!
            }
            else
            {
                normalizeForLookup = Text;
            }

            if (Particle.IsParticle(Text))
            {
                w = Words.Dictionary[normalizeForLookup];
            }
            else
            {
                w = new Word(Text);
            }

            


            var glossMap = Words.Glosses[normalizeForLookup];
            if (glossMap == null)
            {
                return "[missing map for " + Text + "]";
            }
            if (glossMap.ContainsKey(language))
            {
                //Move this code to GlossMap
                if (glossMap[language].ContainsKey(pos))
                {
                    Random r = new Random(DateTime.Now.Millisecond);//TODO: Make this a part of config
                    string[] possibilities = glossMap[language][pos];
                    return possibilities[r.Next(possibilities.Length)];
                }
            }

            if (language == "en")
            {
                switch (Text)
                {
                    case "en":
                        return "and";
                    case "anu":
                        return "or";
                    case "taso":
                        return "but";
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

            foreach (KeyValuePair<string, Dictionary<string, string[]>> pair in glossMap)
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
            if (token == null)
            {
                throw new ArgumentNullException();
            }
            string lookupForm;
            if (token.Contains(",") || token.Contains("»") || token.Contains("«"))
            {
                lookupForm = token.Trim(new char[] {',','»','«', ' '});
            }
            else
            {
                lookupForm = token;
            }
            return dictionary.Contains(lookupForm);
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

        public bool ContainsPreposition(string phrase)
        {
            if (!phrase.Contains(phrase))
            {
                return false;
            }
            string[] parts = phrase.Split(new string[] { " ", Environment.NewLine, ".", "!", "?" }, StringSplitOptions.RemoveEmptyEntries);
            return parts.Contains(word);
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
