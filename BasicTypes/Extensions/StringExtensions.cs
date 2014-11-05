using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BasicTypes.Extensions
{
    public static class StringExtensions
    {

        public static bool IsFirstUpperCased(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            if (value.Length == 0) return false;
            return value[0].ToString().ToUpperInvariant() == value[0].ToString();
        }

        public static string RemoveLeadingWholeWord(this string value, string word)
        {
            if (!value.Contains(word)) return value;//short circuit

            //TODO: Maybe use regex instead?
            foreach (var white in new String[]{" ","\n"})
            {
                if (value.Contains(white))
                {
                    string wordWithWhite = word + white;
                    value = value.StartsWith(wordWithWhite) ? value.Substring(wordWithWhite.Length) : value;    
                }
            }
            return value;
        }

        public static bool StartsOrContainsOrEnds(this string value,string target)
        {
            if (value == target)
            {
                return true;
            }
            foreach (var white in new string[] {" ","\n" })
            {
                if (value.StartsWith(target + white))
                {
                    return true;
                }
                if (value.EndsWith(white + target))
                {
                    return true;
                }
                if (value.Contains(white + target + white))
                {
                    return true;
                }    
            }
            
            return false;
        }

        //http://stackoverflow.com/questions/2961656/generic-tryparse
        public static T Convert<T>(this string input)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter != null)
            {
                //Cast ConvertFromString(string text) : object to (T)
                return (T)converter.ConvertFromString(input);
            }
            return default(T);
        }

        public static String PrintXml(this String xml)
        {
            String result = "";

            MemoryStream mStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
            XmlDocument document = new XmlDocument();

            try
            {
                // Load the XmlDocument with the XML.
                document.LoadXml(xml);

                writer.Formatting = Formatting.Indented;

                // Write the XML into a formatting XmlTextWriter
                document.WriteContentTo(writer);
                writer.Flush();
                mStream.Flush();

                // Have to rewind the MemoryStream in order to read
                // its contents.
                mStream.Position = 0;

                // Read MemoryStream contents into a StreamReader.
                StreamReader sReader = new StreamReader(mStream);

                // Extract the text from the StreamReader.
                String formattedXml = sReader.ReadToEnd();

                result = formattedXml;
            }
            catch (XmlException)
            {
            }

            mStream.Close();
            writer.Close();

            return result;
        }

    }
}
