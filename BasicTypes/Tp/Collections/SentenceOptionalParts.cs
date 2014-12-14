using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;

namespace BasicTypes
{
    [DataContract]
    [Serializable]
    public class SentenceOptionalParts
    {
        [DataMember]
        public bool IsHortative { get; set; } //o
        [DataMember]
        public Particle Conjunction { get; set; }//anu, taso
        [DataMember]
        public ComplexChain Fragments { get; set; } // x la ni la 
        //Basic Sentence goes here. S+V+PP
        [DataMember]
        public Punctuation Punctuation { get; set; }//.?!

        // part or all of sentence is quoted text. If has quotes, it is part. If no quotes, it is entirely quoted text. jan li "toki! ni li pona tawa mi. mi tawa"
        // yeilds 3 sentences, 2 with quote punctuation, 1 that is a quote but no punctuation.
        [DataMember]
        public Punctuation IsQuotedText { get; set; }

        [DataMember]
        public TagQuestion TagQuestion { get; set; }

        [DataMember]
        public Vocative[] HeadVocatives { get; set; }
    }
}
