using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.MoreTypes;

namespace BasicTypes.Parts
{
    [Serializable]
    
    public class GlossMap : Dictionary<string, Word>
    {
        public GlossMap()
        {
            
        }
        protected GlossMap(SerializationInfo info, StreamingContext context)
        {
           
        }

    }
}
