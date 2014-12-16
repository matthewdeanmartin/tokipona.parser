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
    public class EoAffix
    {
        [DataMember]
        private string text;

        [DataMember] 
        private char fromPos;

        [DataMember] 
        private char toPos;

        [DataMember]
        private bool isSuffix;

        public EoAffix(String text, char fromPos, char toPos)
        {
            if (text.StartsWith("-"))
            {
                isSuffix = true;
                text = text.Substring(1);
            }
            this.text = text;
            this.fromPos = fromPos;
            this.toPos = toPos;

        }

        public string Text { get { return text; } }

        public override string ToString()
        {
            return text;
        }
    }

    public class EoAffixes
    {

//-ant (I->A): present active participle. 
//      fali = to fall                     falanta = falling.
//-int (I->A): past active participle. 
//      fali = to fall                     falinta = fallen.
//-ont (I->A): future active participle. 
//      fali = to fall                     falonta = going to fall.
//
//-at (I->A):  present passive participle. 
//      manĝi = to eat                    manĝata = being eaten.
//-it (I->A):  past passive participle. 
//      manĝi = to eat                    manĝita = (having been) eaten.
//-ot (I->A):  future passive participle. 
//      manĝi = to eat,                   manĝota = going to be eaten.
        public static EoAffix ant = new EoAffix("-ant",'i','o');
        public static EoAffix @int = new EoAffix("-int",'i','o');
        public static EoAffix ont = new EoAffix("-ont",'i','o');
        public static EoAffix at = new EoAffix("-at",'i','o');
        public static EoAffix it = new EoAffix("-it",'i','o');
        public static EoAffix ot = new EoAffix("-ot",'i','o');


        
    }
}
