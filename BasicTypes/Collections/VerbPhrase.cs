using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;
using NUnit.Framework;

namespace BasicTypes.Collections
{
    /// <summary>
    /// Anything between li and e.
    /// </summary>
    /// <remarks>
    /// This class might should be implemented as two classes, since the noun-phrase and verb phrase properties are disjoint.
    /// </remarks>
    [Serializable]
    [DataContract]
    public class VerbPhrase : IContainsWord, IFormattable, IToString
    {
        //Modals, pre-verbs, serial verbs
        //jan li wile tawa
        [DataMember]
        private WordSet modals;

        //jan li tawa
        [DataMember]
        private Word headVerb;

        //jan li tawa mute.
        [DataMember]
        private WordSet adverbs; //TODO: extend to include pi chains? li moku pi mute suli.

        //jan li tawa ma Wasinton
        [DataMember]
        private Chain nounComplement;

        public WordSet Modals { get { return modals; } }
        public Word HeadVerb { get { return headVerb; } }
        public WordSet Adverbs { get { return adverbs; } }
        public Chain NounComplement { get { return nounComplement; } }

        //Doesn't deal with adj pi adj adj
        public VerbPhrase(Word headVerb, WordSet modals = null, WordSet adverbs = null)
        {
            if (headVerb == null)
            {
                throw new ArgumentNullException("headVerb");
            }
            if (Particle.NonContentPrticles.Contains(headVerb.Text))
            {
                throw new InvalidOperationException("Head verb can't be a particle.");
            }
            if (modals != null)
            {
                foreach (Word modal in modals)
                {
                    if (modal.Text != "pi" && Particle.NonContentPrticles.Contains(modal.Text))
                    {
                        throw new InvalidOperationException("Modals can't be a particle.");
                    }
                    if (!Token.IsModal(modal))
                    {
                        throw new InvalidOperationException("Modals must be one of these: " + string.Join(",", Token.Modals) + " but got " + modal);
                    }
                }
            }

            if (adverbs != null)
            {
                foreach (Word adverb in adverbs)
                {
                    if (adverb.Text != "pi" && Particle.NonContentPrticles.Contains(adverb.Text))
                    {
                        throw new InvalidOperationException("Adverbs can't be a particle. (maybe we have a nominal predicate here?)");
                    }
                }
            }

            this.headVerb = headVerb; //Any content word.
            this.modals = modals;
            this.adverbs = adverbs;
        }

        public VerbPhrase(Chain nounComplement = null)
        {
            this.nounComplement = nounComplement;
        }

        public bool Contains(Word word)
        {
            if (headVerb != null)
            {
                if (WordByValue.Instance.Equals(word, headVerb)) return true;
            }
            if (modals != null)
            {
                if (modals.Contains(word)) return true;
            }
            if (adverbs != null)
            {
                if (adverbs.Contains(word)) return true;
            }
            if (nounComplement != null)
            {
                if (nounComplement.Contains(word)) return true;
            }
            return false;
        }

        public string ToString(string format)
        {
            return this.ToString(format, Config.CurrentDialect);
        }

        public override string ToString()
        {
            return this.ToString("g", Config.CurrentDialect);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            List<string> sb = ToTokenList(format, formatProvider);

            return sb.SpaceJoin(format);
        }

        public List<string> ToTokenList(string format, IFormatProvider formatProvider, bool isVerbTransitive = false)
        {
            List<string> sb = new List<string>();

            if (nounComplement != null)
            {
                List<string> list = nounComplement.ToTokenList(format, formatProvider);
                if (list.Count > 0)
                {
                    sb.AddIfNeeded("\\", format);
                    sb.AddRange(list);
                    sb.AddIfNeeded("/", format);
                }
            }
            else
            {
                if (modals != null)
                {
                    List<string> list = modals.ToTokenList(format, formatProvider);
                    if (list.Count > 0)
                    {
                        if (format.StartsWith("b"))
                        {
                            sb.Add("\\");
                        }
                        sb.AddRange(list);
                        if (format.StartsWith("b"))
                        {
                            sb.Add("/");
                        }
                    }
                }

                string verbMarker = string.Empty;
                if (format.StartsWith("b"))
                {
                    verbMarker = isVerbTransitive ? "##" : "#";
                }

                sb.Add(verbMarker + headVerb.ToString(format, formatProvider));

                if (adverbs != null)
                {
                    List<string> list = adverbs.ToTokenList(format, formatProvider);
                    if (list.Count > 0)
                    {
                        if (format.StartsWith("b"))
                        {
                            sb.Add("\\");
                        }
                        sb.AddRange(list);
                        if (format.StartsWith("b"))
                        {
                            sb.Add("/");
                        }
                    }

                }
            }

            return sb;
        }

        public string[] SupportedsStringFormats { get; private set; }

    }
}
