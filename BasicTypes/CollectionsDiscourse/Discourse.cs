using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;

namespace BasicTypes.Collections
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
    public class MixedText : Discourse
    {
        //Text follows no rules what so ever.
        public MixedText(Paragraph[] text, string title, Speaker author, string date)
            : base(title, author, date)
        {
        }
    }

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

    [DataContract]
    [Serializable]
    public class Dialog: Discourse
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

    [DataContract]
    [Serializable]
    public class Utterance
    {
        [DataMember]
        private readonly Speaker speaker;

        [DataMember]
        private readonly Paragraph[] said;

        public Utterance(Speaker speaker, Paragraph[] said)
        {
            this.speaker = speaker;
            this.said = said;
        }
    }

    [DataContract]
    [Serializable]
    public class Paragraph:List<Sentence>
    {
        
    }

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
            this.unparsableName= name;
        }
    }

}
