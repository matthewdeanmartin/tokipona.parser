using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace TokiPonaApi.Hal
{
    [DataContract]
    [KnownType(typeof(Hal.Link))]
    [KnownType(typeof(Hal.Link[]))]
    public class HalItemBase
    {
        [DataMember(Name = "_links")]
        //[IgnoreDataMember]
        //[XmlIgnore]
        public Dictionary<string, object> Links { get; set; }

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "_embedded")]
        //[IgnoreDataMember]
        //[XmlIgnore]
        public object EmbeddedValue { get; set; }
    }
}