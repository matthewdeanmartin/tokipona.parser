using System;
using System.Runtime.Serialization;
using System.Text;

namespace BasicTypes.CollectionsDiscourse
{

    [DataContract]
    [Serializable]
    public class Prose : Discourse, IToString, IFormattable
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

        public Paragraph[] Paragraphs
        {
            get { return paragraphs; }
        }

        public override string ToString()
        {
            return ToString("g", Config.CurrentDialect);
        }

        public string ToString(string format)
        {
            if (format == null)
            {
                format = "g";
            }
            return ToString(format, Config.CurrentDialect);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Paragraphs.Length; i++)
            {
                Paragraph paragraph = Paragraphs[i];
                for (int j = 0; j < paragraph.Count; j++)
                {
                    Sentence sentence = paragraph[j];
                    sb.Append(sentence);
                    if(j!=paragraph.Count-1)
                        sb.Append(" ");
                }
                if(i!=Paragraphs.Length-1)
                   sb.AppendLine();
            }
            return sb.ToString();
        }
    }

}
