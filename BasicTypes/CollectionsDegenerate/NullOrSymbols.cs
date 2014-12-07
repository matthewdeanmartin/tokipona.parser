using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicTypes.CollectionsDegenerate
{
    //Crap that appears between legitimage sentences.
    //Why? Because I can either throw errors, or I can accept what ever crap exits and do something with it.
    //I can't track down the original writers of these TP texts and tell them to scrub stray punctuation that confuses the parser
    //and my life isn't long enough for me to do it manually.
    [DataContract]
    [Serializable]
    public class NullOrSymbols
    {
        [DataMember]
        private readonly string text;

        public NullOrSymbols(string text)
        {
            this.text = text;
        }
        public string Text
        {
            get { return text; }
        }
    }
}
