using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.Esperanto.Tokens
{
    [DataContract]
    [Serializable]
    public class EoRoot
    {
        [DataMember]
        private string text;

        [DataMember]
        private char[] types; //i, a, or o type, or both! or all!

        public EoRoot(String text)
        {
            //Deprecated
            this.text = text;
            //this.types = new char[] { type };
        }

        public EoRoot(String text, char type)
        {
            this.text = text;
            this.types = new char[] {type};
        }
        public EoRoot(String text, char[] types)
        {
            this.text = text;
            this.types = types;
        }

        public string Text{get { return text; }}

        public override string ToString()
        {
            return text;
        }
    }
}
