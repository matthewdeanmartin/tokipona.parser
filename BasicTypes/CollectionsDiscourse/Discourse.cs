using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;

namespace BasicTypes.CollectionsDiscourse
{
    [DataContract]
    [Serializable]
    public class Discourse: IContainsWord, IFormattable, IToString
    {
        [DataMember]
        private readonly string title;
        [DataMember]
        private readonly Speaker author;
        [DataMember]
        private readonly string date;

        public Discourse(string title, Speaker author, string date)
        {
            this.title = title;
            this.author = author;
            this.date = date;
        }

        public bool Contains(Word word)
        {
            throw new NotImplementedException();
        }

        public List<string> ToTokenList(string format, IFormatProvider formatProvider)
        {
            List<string> sb = new List<string>();

            return sb;
        }


        public string[] SupportedsStringFormats
        {
            get
            {
                return new[] { "g" };
            }
        }

        public string ToString(string format)
        {
            if (format == null)
            {
                format = "g";
            }
            return ToString(format, Config.CurrentDialect);
        }

        public override string ToString()
        {
            return ToString("g", Config.CurrentDialect);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }
    }


  

    [DataContract]
    [Serializable]
    public class Paragraph:List<Sentence>
    {
        
    }

}
