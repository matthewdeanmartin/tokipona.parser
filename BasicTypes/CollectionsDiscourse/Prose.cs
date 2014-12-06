using System;
using System.Runtime.Serialization;

namespace BasicTypes.CollectionsDiscourse
{

    [DataContract]
    [Serializable]
    public class Prose : Discourse
    {
        //(Title)
        //(Author)
        //Metadata (date)
        //para1
        //para2
        //(Author)

        [DataMember]
        private readonly Paragraph[] paragraphs;

        public Prose(Paragraph[] paragraphs, string title, Speaker author, string date)
            : base(title, author, date)
        {
            this.paragraphs = paragraphs;
        }
    }

}
