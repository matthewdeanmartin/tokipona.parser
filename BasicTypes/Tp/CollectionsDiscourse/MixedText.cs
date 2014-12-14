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
    public class MixedText : Discourse
    {
        //Text follows no rules what so ever.
        public MixedText(Paragraph[] text, string title, Speaker author, string date)
            : base(title, author, date)
        {
        }
    }
}
