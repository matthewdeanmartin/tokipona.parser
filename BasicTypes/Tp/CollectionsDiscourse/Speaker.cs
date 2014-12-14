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
    public class Speaker
    {
        [DataMember]
        private Chain name;

        [DataMember]
        private string unparsableName;

        public Speaker(Chain name)
        {
            this.name = name;
        }

        public Speaker(string name)
        {
            this.unparsableName = name;
        }
    }

}
