using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes
{
    //la,li,pi,e,preps (preps simplified to either ~prep or lon-prep)
    [DataContract]
    [Serializable]
    public class Particle
    {
        [DataMember]
        private readonly string particle;

        [DataMember]
        private readonly bool middleOnly;

        public  static string[] dictionary = new string[]
        {
            "en", //subject chains, but also other things. The only one where it is skipped for 1st.
            "la", //Sentence conj.
            "anu",//Sentence conj.
            "taso",//Sentence conj.
            "li",
            "pi",
            "e",
            "o", //overlays li
            "~kepeken",
            "~tawa",
            "~sike",
            "~poka"
        };

        public Particle(string particle)
        {
            this.particle = particle;
            if (particle == "en" || particle == "pi")
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
