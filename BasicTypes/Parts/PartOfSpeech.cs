using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.MoreTypes;

namespace BasicTypes
{
    /// <summary>
    /// Standard part of speech categories
    /// </summary>
    [Serializable]
    [DataContract]
    [KnownType(typeof(Enumeration))]
    public class PartOfSpeech : Enumeration
    {
        //noun	adj	vt	vi	adv	prep	pronoun	kama	conditional	interj	conj	particle

        //public static readonly PartOfSpeech Noun = new PartOfSpeech(1, "Noun");
        //public static readonly PartOfSpeech VerbIntransitive = new PartOfSpeech(2, "VerbIntranitive");
        //public static readonly PartOfSpeech VerbTransitive = new PartOfSpeech(3, "VerbTransitive");
        //
        //public static readonly PartOfSpeech Interjection = new PartOfSpeech(4, "Interjection");
        //public static readonly PartOfSpeech Adjective = new PartOfSpeech(5, "Adjective");
        //public static readonly PartOfSpeech Adverb = new PartOfSpeech(6, "Adverb");


        public static readonly PartOfSpeech Noun = new PartOfSpeech(1, "noun");  //Content word
        public static readonly PartOfSpeech VerbIntransitive = new PartOfSpeech(2, "vi");//Content word
        public static readonly PartOfSpeech VerbTransitive = new PartOfSpeech(3, "vt");//Content word

        public static readonly PartOfSpeech Interjection = new PartOfSpeech(4, "interj");//Content word. Degenerate class. Only used in 1 word sentences.
        public static readonly PartOfSpeech Adjective = new PartOfSpeech(5, "adj");//Content word
        public static readonly PartOfSpeech Adverb = new PartOfSpeech(6, "adv");//Content word

        public static readonly PartOfSpeech Preposition = new PartOfSpeech(7, "prep"); //Has specialized class!
        public static readonly PartOfSpeech Pronoun = new PartOfSpeech(8, "pronoun"); //Has specialized class!
        public static readonly PartOfSpeech Kama = new PartOfSpeech(9, "kama");//Meaning when in a verb chain 
        public static readonly PartOfSpeech Conditional = new PartOfSpeech(10, "conditional");//Meaning when "x la"

        public static readonly PartOfSpeech Conjunction = new PartOfSpeech(10, "conj"); //Has specialized class!
        public static readonly PartOfSpeech Particle = new PartOfSpeech(10, "particle"); //Has specialized class!

        private PartOfSpeech() { }
        private PartOfSpeech(int value, string displayName) : base(value, displayName) { }

        static public implicit operator string(PartOfSpeech part)
        {
            return part.DisplayName;
        }

        static public implicit operator int(PartOfSpeech part)
        {
            return part.Value;
        }
    }
}
