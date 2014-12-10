using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;
using BasicTypes.CollectionsDegenerate;
using BasicTypes.Exceptions;
using BasicTypes.Extensions;
using BasicTypes.Html;
using BasicTypes.Parts;

namespace BasicTypes
{
    /// <summary>
    /// Phrase with no particles. Head word is special, subsequent words might not be ordered.
    /// </summary>
    [DataContract]
    [Serializable]
    public class HeadedPhrase : IContainsWord, IFormattable, IToString
    {
        // [head word] - [mods] - (pi) [prep phrases]
        // head word usually noun, sometimes adj, e.g. laso pi pona mute.
        // mods are usually adjectives, can be agents  ilo mi, or nouns for "genative" ilo ma, nation's machinery
        // prep phrases, with our without pi
        // --- noticable in subject slot. 
        // --- (maybe noticable inside an e chain, e.g. e X e Y PP ... But only if 2 e! other wise looks like 1st prep.
        // --- Inside of prep phrases, not at all noticable. [lon ma <--[sama ma mi.]]

        //Pretty little girls school==> a school characterized by pretty, little and girls.
        //i.e. same as girls school & little school & pretty school, etc.
        //kili pi suwi en namako
        //kili lili pi suwi en namako
        //kili lili pi kasi suli pi suwi en namako
        [DataMember]
        private readonly Word head;
        [DataMember]
        private readonly WordSet modifiers;

        //For this to work, need to rework (possibly) the basic token processing algo.
        [DataMember]
        private readonly WordSet alternativeModifiers; //jan pona anu ike
        [DataMember]
        private readonly WordSet joinedModifiers;  //kili suwi en namako (does it need pi? who knows, we can a parse it)

        //soweli (tan tomo) (sama akesi) pi ma suli en waso pi ma lili (lon ma ni) li 

        [DataMember]
        private readonly PrepositionalPhrase[] prepositionalPhrases;

        /// <summary>
        /// Convenience constructor.
        /// </summary>
        public HeadedPhrase(Word head, Word modifier1, Word modifier2 = null, Word modifier3 = null)
        {
            //if (new[] {"mi", "sina", "ona"}.Contains(head.Text))
            //{
            //    throw new ArgumentException("mi, sina, ona can only be pronouns, so you must use ComplexPronoun");
            //}
            WordSet set = new WordSet();
            set.Add(modifier1);
            if (modifier2 != null) set.Add(modifier2);
            if (modifier3 != null) set.Add(modifier3);

            ValidateConstruction(head, set);

            this.head = head;
            this.modifiers = set;
        }


        //Maximal phrase: (subject)
        //jan pona anu ike lon tomo ...li pona tawa mi.
        //kili suwi en namako lon tomo ...li pona tawa mi. 
        //kili suwi en namako anu loje lon tomo .... li pona tawa mi.
        //kili suwi namako anu loje
        public HeadedPhrase(Word head, WordSet modifiers = null, PrepositionalPhrase[] prepositionalPhrases = null, WordSet joinedModifiers = null, WordSet alternativeModifiers = null)
        {
            //if (new[] { "mi", "sina", "ona" }.Contains(head.Text))
            //{
            //    throw new ArgumentException("mi, sina, ona can only be pronouns, so you must use ComplexPronoun");
            //}

            if (modifiers!=null && (modifiers.Contains(Words.kin) || modifiers.Contains(Words.ala)))
            {
                ParserUtils pu = new ParserUtils(Dialect.LooseyGoosey);
                var mergedTail = pu.TurnThisWordsIntoWordsWithTaggedWords(modifiers.ToArray());
                modifiers = new WordSet(mergedTail);
            }

            ValidateConstruction(head, modifiers);

            this.head = head;
            this.modifiers = modifiers;
            this.prepositionalPhrases = prepositionalPhrases;
            this.joinedModifiers = joinedModifiers;
            this.alternativeModifiers = alternativeModifiers;
        }

        private static void ValidateConstruction(Word head, WordSet modifiers)
        {
            if (head == null)
            {
                throw new ArgumentNullException("head", "Cannot construct with null");
            }
            //HACK: related to taso in la fragment, and logical operators not implemented yet.
            if (!(Exclamation.IsExclamation(head.Text) || head.Text == "taso" || head.Text == "anu") && Token.CheckIsParticle(head.Text))
            {
                throw new TpSyntaxException(
                    "You cannot have a headed phrase that is headed by a particle. That would be a chain. " + head.Text + " " + (modifiers == null ? "" : modifiers.ToString()));
            }

            if (head.Text=="o" && modifiers!=null && modifiers.Count>0)
            {
                Console.WriteLine("Warning: We have an o with modifiers. This should be crazy rare." + head.Text + " " + modifiers);
                //Warning: 
            }

            if (ProperModifier.IsProperModifer(head.Text))
            {
                string warning = string.Empty;
                if (Word.IsWord(head.Text.ToLower()))
                {
                    warning = " (This is a valid word, maybe it shouldn't be capitalized?)";
                }
                if (!Number.IsPomanNumber(head.Text))
                {
                    throw new TpSyntaxException("Proper modifiers cannot be the head of a headed phrase " + head.Text + warning);
                }
            }
            if (modifiers != null)
            {
                foreach (Word word in modifiers)
                {
                    if (word.Text == "en" || word.Text == "anu") continue; //HACK: Deferring dealing with these. 
                    if (word.Text == "taso") continue; //Taso actually is a modifier. Carry on.
                    if (Particle.CheckIsParticle(word.Text))
                    {
                        throw new TpSyntaxException("Particles shouldn't be modifiers: " + head.Text + " " + modifiers);
                    }
                }

                if (modifiers.Contains(Words.ona)  )
                {
                    if (modifiers.Contains(Words.mi))
                    {
                        throw new InvalidOperationException("Can't have ona and mi in modifier list." + head.Text + " " + modifiers);
                    }
                    if (modifiers.Contains(Words.sina))
                    {
                        throw new InvalidOperationException("Can't have ona and sina in modifier list." + head.Text + " " + modifiers);
                    }
                }
                if (modifiers.Contains(Words.sina))
                {
                    if (modifiers.Contains(Words.mi))
                    {
                        throw new InvalidOperationException("Can't have sina and mi in modifier list." + head.Text + " " + modifiers);
                    }
                }
            }
            if (modifiers != null && modifiers.Count > 1)
            {
                var query = modifiers.GroupBy(x => x)
                  .Where(g => g.Count() > 1)
                  .Select(y => y.Key)
                  .ToList();
                if (query.Count > 0)
                {
                    throw new InvalidOperationException("Degenerate modifiers-- doubles " + modifiers);
                }
            }
            //5 about never gets false positives.
            if (modifiers != null && modifiers.Count > 3)
            {
                if (head.Text == "nanpa")
                {
                    //no surprise there
                }
                else if( head.Text=="kama" || head.Text=="kama")
                {
                    //Defer kama/tawa, they take unmarked complements, so they make for long verb phrases.
                }
                //HACK:
                else if (modifiers.Any(x => x.Text == "anu" || x.Text == "en" || x.Text == "kama" || x.Text == "tawa")) //Because we've deferred dealing with conj. & serial verbs
                {
                }
                else
                {
                    throw new InvalidOperationException("Suspiciously long headed phrase " + head + " " + modifiers);
                }
            }
        }

        public Word Head { get { return head; } }
        public WordSet Modifiers { get { return modifiers; } }

        public bool Contains(Word word)
        {
            if (WordByValue.Instance.Equals(word, head))
            {
                return true;
            }
            if (modifiers == null)
                return false;
            return modifiers.Any() && modifiers.Any(modifier => WordByValue.Instance.Equals(word, modifier));
        }

        public override string ToString()
        {
            return this.ToString("g", Config.CurrentDialect);

        }

        public string[] SupportedsStringFormats
        {
            get
            {
                return new string[] { "g" };
            }
        }

        public string ToString(string format)
        {
            if (format == null)
            {
                format = "g";
            }
            return this.ToString(format, Config.CurrentDialect);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
            {
                format = "g";
            }
            var words = ToTokenList(format, formatProvider);
            return words.SpaceJoin(format);
        }

        public List<string> ToTokenList(string format, IFormatProvider formatProvider)
        {

            List<string> words = new List<string>();

            if (format == "html" && new String[] { "ona", "mi", "sina" }.Contains(head.Text))
            {
                words.Add(HtmlTagHelper.SpanWrap("anaphora", head.ToString(format, formatProvider)));
            }
            else
            {
                words.Add(head.ToString(format, formatProvider));
            }

            if (Modifiers != null && Modifiers.Count > 0)
            {
                words.AddIfNeeded("(", format);
                words.AddRange(modifiers.Select(x => x.ToString(format, formatProvider)));
                words.AddIfNeeded(")", format);
            }
            if (prepositionalPhrases != null)
            {
                foreach (PrepositionalPhrase phrase in prepositionalPhrases)
                {
                    words.AddIfNeeded("(", format);
                    words.AddRange(phrase.ToTokenList(format, formatProvider));
                    words.AddIfNeeded(")", format);
                }

            }

            return words;
        }

        public bool IsPlural()
        {
            if (modifiers == null || modifiers.Count == 0) return false;

            foreach (string value in Token.SemanticallyPlural)
            {
                foreach (Word modifier in modifiers)
                {
                    if (modifier.Text == value) return true;
                }
            }
            return false;
        }

        public static HeadedPhrase Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("value is null or zero length string");
            }
            return HeadedPhraseConverter.Parse(value);
        }

        public static bool TryParse(string value, out HeadedPhrase result)
        {
            try
            {
                result = HeadedPhraseConverter.Parse(value);
                return true;
            }
            catch (Exception)
            {
                result = null;
                return false;
            }
        }
    }
}