using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BasicTypes.MoreTypes;
using Polenter.Serialization;

namespace BasicTypes.Serialization
{
    //F'n proxy for XML
    public class WordXml
    {
        public WordXml()
        {
            AutoMapper.Mapper.CreateMap<WordXml, Word>();
            AutoMapper.Mapper.CreateMap<Word, WordXml>();
        }
        public string Word { get; set; }
    
        [XmlIgnore]
        public Dictionary<string, string> GlossMap{ get; set; }

        [ExcludeFromSerialization] //Sharp serializer treats this as a reference anyhow.
        public DictionaryProxy<string, string> GlossMapXml {
            get { return new DictionaryProxy<string, string>(this.GlossMap); }
            set { GlossMap = value.ToDictionary(); }
        }
    }
}

