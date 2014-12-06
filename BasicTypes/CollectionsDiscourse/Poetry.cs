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
    public class Poetry : Discourse
    {
        //(Title)
        //(Author)
        //verse1, verse2 (sentences have internal, significant line breaks)
        //(Author)

        [DataMember]
        private readonly Paragraph[] verses;

        public Poetry(Paragraph[] verses, string title, Speaker author, string date)
            : base(title, author, date)
        {
            this.verses = verses;
        }
    }
}
