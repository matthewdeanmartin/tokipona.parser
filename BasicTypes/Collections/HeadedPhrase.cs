﻿using System;
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

        [DataMember]
        private readonly WordSet alternativeModifiers; //jan pona anu ike

        [DataMember]
        private readonly WordSet joinedModifiers;  //kili suwi en namako (does it need pi? who knows, we can a parse it)

        //soweli (tan tomo) (sama akesi) pi ma suli en waso pi ma lili (lon ma ni) li 

        [DataMember]
        private readonly PrepositionalPhrase[] prepositionalPhrases;

        public HeadedPhrase(Word head, Word modifier1, Word modifier2 = null, Word modifier3 = null)
        {
            if (new[] {"mi", "sina", "ona"}.Contains(head.Text))
            {
                throw new ArgumentException("mi, sina, ona can only be pronouns, so you must use ComplexPronoun");
            }
            WordSet modifiers = null;
            //if (modifier2 != null || modifier3 != null)
            {
                modifiers = new WordSet();
                //if (modifier1 != null) 
                modifiers.Add(modifier1);
                if (modifier2 != null) modifiers.Add(modifier2);
                if (modifier3 != null) modifiers.Add(modifier3);
            }

            ValidateConstruction(head, modifiers);

            this.head = head;
            this.modifiers = modifiers;
        }


        //Maximal phrase: (subject)
        //jan pona anu ike lon tomo ...li pona tawa mi.
        //kili suwi en namako lon tomo ...li pona tawa mi. 
        //kili suwi en namako anu loje lon tomo .... li pona tawa mi.
        //kili suwi namako anu loje
        public HeadedPhrase(Word head, WordSet modifiers = null, PrepositionalPhrase[] prepositionalPhrases = null, WordSet[] joinedModifiers=null, WordSet[] alernativeModifiers=null)
        {
            //if (new[] { "mi", "sina", "ona" }.Contains(head.Text))
            //{
            //    throw new ArgumentException("mi, sina, ona can only be pronouns, so you must use ComplexPronoun");
            //}
            ValidateConstruction(head, modifiers);

            this.head = head;
            this.modifiers = modifiers;
            this.prepositionalPhrases = prepositionalPhrases;
        }

        private static void ValidateConstruction(Word head, WordSet modifiers)
        {
            if (head == null)
            {
                throw new ArgumentNullException("head", "Can't construct with null");
            }
            //HACK: related to taso in la fragment
            if (!(Exclamation.IsExclamation(head.Text) || head.Text=="taso")&& Token.CheckIsParticle(head.Text))
            {
                throw new TpSyntaxException(
                    "You can't have a headed phrase that is headed by a particle. That would be a chain. " + head.Text + " "+  (modifiers==null?"":modifiers.ToString()));
            }
            if (ProperModifier.IsProperModifer(head.Text))
            {
                throw new TpSyntaxException("Proper modifiers can't be the head of a headed phrase " + head.Text);
            }
            if (modifiers != null)
            {
                foreach (Word word in modifiers)
                {
                    if(word.Text =="en"|| word.Text =="anu" ) continue; //HACK: Deferring dealing with these. 
                    if (word.Text == "taso") continue; //Taso actually is a modifier. Carry on.
                    if (Particle.CheckIsParticle(word.Text))
                    {
                        throw new TpSyntaxException("Particles shouldn't be modifiers: " + word.Text);
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
                //HACK:
                else if (modifiers.Any(x => x.Text == "anu" || x.Text == "en")) //Because we've deferred dealing with conj.
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
            if(modifiers==null || modifiers.Count==0) return false;

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