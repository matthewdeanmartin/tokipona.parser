using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
//using Should;
using Should;

namespace DataAccess.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this object source)
        {
            return source == null;
        }

    }

    namespace DataAccess.Extensions.Serialization
    {
        public static class ObjectSerializationExtensions
        {
            public static object PropertyValue(this object source, string propertyName)
            {
                if (source == null)
                {
                    throw new ArgumentException("source object is null, can't get the property of that.");
                }
                return source.GetType().GetProperty(propertyName).GetValue(source, null);
            }

            public static bool IsNull(this object source)
            {
                return source == null;
            }

            //public static string ToXmlByContract<T>(this T sourceObject) where T : new()
            //{
            //    DataContractSerializer dcs = new DataContractSerializer(typeof(T));

            //    using (var ms = new MemoryStream())
            //    using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(ms, Encoding.UTF8))
            //    using (var sr = new StreamReader(ms))
            //    {
            //        writer.WriteStartDocument();
            //        dcs.WriteObject(writer, sourceObject);
            //        ms.Flush();
            //        ms.Position = 0;
            //        return sr.ReadToEnd();
            //    }
            //}

            public static string ToXmlByContract<T>(this T sourceObject) where T : new()
            {
                using (MemoryStream memoryStream = new MemoryStream())
                using (StreamReader reader = new StreamReader(memoryStream))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                    serializer.WriteObject(memoryStream, sourceObject);
                    memoryStream.Position = 0;
                    return reader.ReadToEnd();
                }
            }

            public static T DeserializeFromXmlByContract<T>(this string xml)
            {
                using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                {
                    XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(memoryStream, Encoding.UTF8, new XmlDictionaryReaderQuotas(), null);
                    DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                    return (T)serializer.ReadObject(reader);
                }
            }

            public static string ToXml<T>(this T sourceObject) where T : new()
            {
                string retVal;
                using (var ms = new MemoryStream())
                {
                    var xs = new XmlSerializer(typeof(T));
                    xs.Serialize(ms, sourceObject);
                    ms.Flush();
                    ms.Position = 0;
                    using (var sr = new StreamReader(ms))
                    {
                        retVal = sr.ReadToEnd();
                    }
                }
                return retVal;
            }

            public static XDocument ToXDocument<T>(this T sourceObject) where T : new()
            {
                //string retVal;
                using (var ms = new MemoryStream())
                {
                    var xs = new XmlSerializer(typeof(T));
                    xs.Serialize(ms, sourceObject);
                    ms.Flush();
                    ms.Position = 0;
                    using (var sr = new StreamReader(ms))
                    {
                        XDocument x = XDocument.Load(sr);
                        return x;
                    }
                    //retVal = sr.ReadToEnd();
                }
                //return retVal;
            }

            //public static string ToJson(this object obj) {
            //    JavaScriptSerializer serializer = new JavaScriptSerializer();
            //    return serializer.Serialize(obj);
            //}

            //public static string ToJson(this object obj, int recursionDepth) {
            //    JavaScriptSerializer serializer = new JavaScriptSerializer();
            //    serializer.RecursionLimit = recursionDepth;
            //    return serializer.Serialize(obj);
            //}

            //public static T FromJson<T>(this object obj) {
            //    JavaScriptSerializer serializer = new JavaScriptSerializer();
            //    return serializer.Deserialize<T>(obj as string);
            //}

            public static string ToSortedString(this object value)
            {
                value.ShouldNotBeNull();
                const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public;
                SortedDictionary<string, string> values = new SortedDictionary<string, string>();

                PropertyInfo[] properties = value.GetType().GetProperties(bindingFlags);
                foreach (PropertyInfo property in properties)
                {
                    string propertyName = property.Name;
                    object propertyValue = property.GetValue(value, null);
                    string maskedValue = propertyValue == null ? "null" : propertyValue.ToString();

                    values.Add(propertyName, maskedValue);
                }

                StringBuilder sb = new StringBuilder();
                foreach (KeyValuePair<string, string> item in values)
                {
                    sb.AppendFormat("{0}={1}{2}", item.Key, item.Value, Environment.NewLine);
                }

                return sb.ToString();
            }
        }
    }
}