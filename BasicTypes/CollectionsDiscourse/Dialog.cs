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
    public class Dialog : Discourse
    {
        //(Title)
        //(Author)
        //speaker1: para1, para2,
        //speaker2: para1, para2,
        //(Author)
        [DataMember]
        private readonly Utterance[] dialog;

        public Dialog(Utterance[] dialog, string title, Speaker author, string date)
            : base(title, author, date)
        {
            this.dialog = dialog;
        }
    }
}
