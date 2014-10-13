using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BasicTypes
{
    
        public static class ObjectExensionsSerialization
        {
            public static string ToJsonNet(this object o)
            {
                return JsonConvert.SerializeObject(o,Formatting.Indented);
            }

            public static string ToXml<T>(this T o)//where T : new()
                {
                    string retVal;
                    using (var ms = new MemoryStream())
                    {
                        var xs = new XmlSerializer(typeof(T));
                        xs.Serialize(ms, o);
                        ms.Flush();
                        ms.Position = 0;
                        var sr = new StreamReader(ms);
                        retVal = sr.ReadToEnd();
                    }
                    return retVal;
                }

                public static string ToJsonDcJs<T>(this T item, System.Text.Encoding encoding = null, System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = null)
                {
                    encoding = encoding ?? Encoding.Default;
                    serializer = serializer ?? new DataContractJsonSerializer(typeof(T));
                    
                    using (var stream = new System.IO.MemoryStream())
                    {
                        serializer.WriteObject(stream, item);
                        var json = encoding.GetString((stream.ToArray()));

                        return json;
                    }
                }

            public static string ToJsonJss(this object obj)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Serialize(obj);
            }

            public static string ToJsonJss(this object obj, int recursionDepth)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                serializer.RecursionLimit = recursionDepth;
                
                return serializer.Serialize(obj);
            }

            public static T FromJsonJss<T>(this object obj)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Deserialize<T>(obj as string);
            }
        }
    
}
