using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TokiPonaApi.Hal
{
    [DataContract]
    [KnownType(typeof(Hal.Link))]
    [KnownType(typeof(Hal.Link[]))]
    //[KnownType(typeof(....))]
    public class HalCollectionBase 
    {
        [DataMember(Name = "_links")]
        public Dictionary<string, object> Links { get; set; }
        [DataMember(Name = "_embedded")]
        public EmbeddedValues EmbeddedValue { get; set; }
    }

    [DataContract]
    [KnownType(typeof(Hal.Link))]
    public class EmbeddedValues
    {
        [DataMember(Name = "values")]
        public object[] Values { get; set; }
    }
}