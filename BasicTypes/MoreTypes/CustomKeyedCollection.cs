using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;
using BasicTypes.Serialization;
using NUnit.Framework;

namespace BasicTypes.MoreTypes
{
    //Okay, not so needed now.
    //Don't use custom objects as keys. Use Proxy class (tree) to serialize XML objects.
    [Serializable]
    public class CustomKeyedCollection : KeyedCollection<string,Word>
    {
        protected override string GetKeyForItem(Word item)
        {
            return item.Text;
        }
    }

    [TestFixture]
    public class CKCTest
    {
        [Test]
        public void Test()
        {
            CustomKeyedCollection m = new CustomKeyedCollection();
            m.Add(new Word("lala"));
            m.Add(new Word("nini"));
            m.Add(Words.nanpa);

            Console.WriteLine("");
            Console.WriteLine("DataContractJsonSerializer (serializes IXmlSerializable as XML strings?!)");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine(m.ToJsonDcJs());
            Assert.NotNull(m.ToJsonDcJs());

            Console.WriteLine("");
            Console.WriteLine("JavaScriptSerializer (doesn't support enumerator keys in dictionaries!)");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine(m.ToJsonJss());
            Assert.NotNull(m.ToJsonJss());

            Console.WriteLine("");
            Console.WriteLine("JSON.NET");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine(m.ToJsonNet());
            Assert.NotNull(m.ToJsonNet());


            //WordXml
            List<WordXml> xmlWords = new List<WordXml>();
            WordXml whut = AutoMapper.Mapper.Map(Words.seme, new WordXml());
            xmlWords.Add(whut);

            Console.WriteLine("");
            Console.WriteLine("SharpSerializer (no privates, no fields)");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine(xmlWords.ToSharpXml()); //Can't deal with private, so hard to serialize immutable!
            Assert.NotNull(xmlWords.ToSharpXml());
            
            Console.WriteLine("");
            Console.WriteLine("XmlSerializer (no privates, no built-in dictionaries)");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine(xmlWords.ToXml()); //Can't deal with dictionaries? Ugh.
            Assert.NotNull(xmlWords.ToXml());

            Console.WriteLine("");
            Console.WriteLine("ToDataContractXml (No esoteric XML stuff)");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine(m.ToDataContractXml().PrintXml()); //Can't deal with dictionaries? Ugh.
            Assert.NotNull(m.ToDataContractXml());


            Console.WriteLine("");
            Console.WriteLine("Binary");
            Console.WriteLine("-------------------------------------------------------------------------");
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, m);
                ms.Position = 0;

                Console.WriteLine(Encoding.Default.GetString((ms.ToArray())));
                ms.Position = 0;
                CustomKeyedCollection result = formatter.Deserialize(ms) as CustomKeyedCollection;
                
                Assert.NotNull(result);
            }
        }
    }
}
