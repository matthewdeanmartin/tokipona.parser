using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Exceptions;
using BasicTypes.MoreTypes;
using BasicTypes.Parts;
using Microsoft.SqlServer.Server;
using NUnit.Framework;

namespace BasicTypes
{
    [TestFixture]
    public class WordTest
    {
        [Test]
        public void GlossMap_SerializeAll()
        {

            GlossMap m = new GlossMap()
            {
                {"test", new Word("nena")}
            };

            Console.WriteLine(m.ToJsonDcJs());
            Assert.NotNull(m.ToJsonDcJs());

            Console.WriteLine(m.ToSharpXml());
            Assert.NotNull(m.ToSharpXml());

            //Console.WriteLine(m.ToXml()); //Can't deal with dictionaries? Ugh.
            //Assert.NotNull(m.ToXml());
            Console.WriteLine(m.ToJsonJss());
            Assert.NotNull(m.ToJsonJss());

            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, m);
                ms.Position = 0;
                GlossMap result = formatter.Deserialize(ms) as GlossMap;
                Assert.NotNull(result);
            }
        }

        [Test]
        public void CanJsonSerialize()
        {
            Word f = new Word("nimi");
            Assert.NotNull(f.ToJsonDcJs());
        }

        [Test]
        public void CanJsonSerializeJss()
        {
            Word f = new Word("nimi");
            Assert.NotNull(f.ToJsonJss());
        }

        [Test]
        public void CanXmlSerialize()
        {
            Word f = new Word("nimi");
            Assert.NotNull(f.ToXml());
        }

        [Test]
        public void CanBinarySerialize()
        {
            Word f = new Word("nimi");

            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, f);
                ms.Position = 0;
                Word result = formatter.Deserialize(ms) as Word;
                Assert.NotNull(WordByValue.Instance.Equals(result, f));
            }
        }


        [Test]
        public void WrongWord_DetectsInvalidCharacterSet()
        {
            try
            {
                Word f = new Word("asdfghjkl");
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        [Test]
        public void WrongWord_NullNotAllowedInConstructor()
        {
            try
            {
                Word f = new Word(null);
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        [Test]
        public void WrongWord_ThrowsOnPunctuation()
        {
            try
            {
                Word f = new Word("....");
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        [Test]
        public void WrongWord_DetectsInvalidPhonology()
        {
            try
            {
                Word f = new Word("asdfghjkl");
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        [Test]
        public void WrongWord_ValidPhonology()
        {
            try
            {
                Word f = new Word("nonon");
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        [Test]
        public void WrongWord_InvalidPhonology()
        {
            try
            {
                Word f = new Word("nnonon");
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        [Test]
        public void WrongWord_ValidLetterSet()
        {
            try
            {
                Word f = new Word("jklmnpstwaeiou");
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        [Test]
        public void WrongWord_IsNumeric()
        {
            Word f = new Word("1324");
            Assert.IsTrue(f.IsNumeric);
        }

        [Test]
        public void WrongWord_IsProperModifier()
        {
            
                Word f = new Word("Mato");
            Assert.IsTrue(f.IsProperModifier);
        }

        
        [Test]
        public void ImplicitConversions()
        {
            Word s = UseStringAsWord("luka");
            string text = UseWordAsString(Words.luka);
            Assert.AreEqual(s.ToString(), text);
            //Assert.IsFalse(object.ReferenceEquals(s.ToString(), text)); //These aren't copies!
        }

        public Word UseStringAsWord(string test)
        {
            return test;
        }

        public string UseWordAsString(Word test)
        {
            return test;
        }

    }
}
