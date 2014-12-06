using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.CollectionsDiscourse
{
    [DataContract]
    [Serializable]
    public class Utterance
    {
        [DataMember]
        private readonly Speaker speaker;

        [DataMember]
        private readonly Paragraph[] said;

        public Utterance(Speaker speaker, Paragraph[] said)
        {
            this.speaker = speaker;
            this.said = said;
        }
    }
}
