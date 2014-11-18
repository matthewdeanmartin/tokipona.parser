using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Newtonsoft.Json;

namespace TokiPonaApi.Hal
{
    /// <summary>
    /// Properties are broadly related to the attributes of the html a tag.
    /// </summary>
    [DataContract]
    public class Link
    {
        //[DataMember(Name = "rel", EmitDefaultValue = false)]
        //public string Rel { get; set; }
        [DataMember(Name = "href")]
        public string Href { get; set; }

        //Alternate primary key
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        //If true, URL has {0}, {1} template things.
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "templated", EmitDefaultValue = false)]
        public bool? Templated { get; set; }

        //This URL will soon be discontinued
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "deprecation", EmitDefaultValue = false)]
        public bool? Deprecation { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public bool? Title { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "hreflang", EmitDefaultValue = false)]
        public bool? HrefLang { get; set; }

        //Media-Type (text/html, etc)
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public bool? Type { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "profile", EmitDefaultValue = false)]
        public bool? Profile { get; set; }
    }
}