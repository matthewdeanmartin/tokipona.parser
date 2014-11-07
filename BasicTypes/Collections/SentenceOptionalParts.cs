using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
        public Chain Fragments { get; set; } // x la ni la 
        //Basic Sentence goes here. S+V+PP
        [DataMember]
        public Punctuation Punctuation { get; set; }//.?!
    }
}
