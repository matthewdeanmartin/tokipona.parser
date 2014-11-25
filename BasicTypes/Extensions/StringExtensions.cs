using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace BasicTypes.Extensions
{
    public static class StringExtensions
    {
        public static bool ContainsCheck(this string value, string middle)
        {
            //http://cc.davelozinski.com/c-sharp/fastest-way-to-check-if-a-string-occurs-within-a-string
            if(((value.Length - value.Replace(middle, String.Empty).Length) / middle.Length)>0)
            {
                return true;
            }
            return false;

        }

        public static bool StartCheck(this string value, string leadToken)
        {
            //Perf trace said this was surprisingly slow.

            //https://stackoverflow.com/questions/484796/more-efficient-way-to-determine-if-a-string-starts-with-a-token-from-a-set-of-to
            return value.StartsWith(leadToken, StringComparison.Ordinal);
        }

        public static bool EndCheck(this string value, string endToken)
        {
            //Perf trace said this was surprisingly slow.

            //https://stackoverflow.com/questions/484796/more-efficient-way-to-determine-if-a-string-starts-with-a-token-from-a-set-of-to
            return value.EndsWith(endToken, StringComparison.Ordinal);
        }

        public static string Remove(this string value, string letters)
        {
            StringBuilder sb = new StringBuilder(value.Length);
            foreach (char c in value)
            {
                if(letters.Contains(c) ) continue;
                sb.Append(c);
            }
            return sb.ToString();
        }
        public static bool ContainsWholeWord(this string value, string word)
        {
            return Regex.IsMatch(value,@"\b" + word + @"\b");
        }
        public static bool ContainsLetter(this string value, string letters)
        {
            return value != null && letters.Any(value.Contains);
        }

        public static bool IsFirstUpperCased(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            if (value.Length == 0) return false;
            string toTest = value.Trim(new[] {'~', '#','\''});
            if (toTest.Length == 0) return false;
            return toTest[0].ToString().ToUpperInvariant() == value[0].ToString();
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
                    value = value.StartCheck(wordWithWhite) ? value.Substring(wordWithWhite.Length) : value;    
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
                if (value.StartCheck(target + white))
                {
                    return true;
                }
                if (value.EndCheck(white + target))
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
