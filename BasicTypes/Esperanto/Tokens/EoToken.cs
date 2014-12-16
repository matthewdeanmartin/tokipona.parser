using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Esperanto.Tokens
{
    [DataContract]
    [Serializable]
    public class EoToken
    {
        [DataMember]
        private string text;

        public EoToken(String text)
        {
            this.text = text;
        }

        public string Text{get { return text; }}

        public override string ToString()
        {
            return text;
        }
    }
}
