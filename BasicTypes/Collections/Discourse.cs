using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Collections
{
    //[DataContract]
    //[Serializable]
    //public class JoinableSentence
    //{
    //    [DataMember] 
    //    private readonly Sentence mainSentence;
    //    
    //
    //    public Sentence MainSentence {get { return mainSentence; }}
    //    public Particle Conjunction { get { return conjunction; } }
    //
    //    public JoinableSentence(Sentence mainSentence, Particle conjunction)
    //    {
    //        this.mainSentence = mainSentence;
    //        this.conjunction = conjunction;
    //    }
    //}

    [Serializable]
    public class Discourse : List<Sentence>
    {
    }
}
