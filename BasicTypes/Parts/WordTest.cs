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
                {"test", new Word("nini")}
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
            Word f = new Word("asdfghjkl");
            Assert.NotNull(f.ToJsonDcJs());
        }

        [Test]
        public void CanJsonSerializeJss()
        {
            Word f = new Word("asdfghjkl");
            Assert.NotNull(f.ToJsonJss());
        }

        [Test]
        public void CanXmlSerialize()
        {
            Word f = new Word("asdfghjkl");
            Assert.NotNull(f.ToXml());
        }

        [Test]
        public void CanBinarySerialize()
        {
            Word f = new Word("asdfghjkl");

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
        public void WeakWord_DetectsInvalidCharacterSet()
        {
            Word f = new Word("asdfghjkl");
            Assert.IsFalse(f.IsValidLetterSet); 
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WeakWord_NullNotAllowedInConstructor()
        {
            Word f = new Word(null);
        }

        [Test]
        [ExpectedException(typeof(InvalidLetterSetException))]
        public void WeakWord_ThrowsOnPunctuation()
        {
            Word f = new Word("....");
        }

        [Test]
        public void WeakWord_DetectsInvalidPhonology()
        {
            Word f = new Word("asdfghjkl");
            Assert.IsFalse(f.IsValidLetterSet);
        }

        [Test]
        public void WeakWord_ValidPhonology()
        {
            Word f = new Word("nonon");
            Assert.IsTrue(f.IsValidPhonology);
        }

        [Test]
        public void WeakWord_InvalidPhonology()
        {
            Word f = new Word("nnonon");
            Assert.IsFalse(f.IsValidPhonology);
        }

        [Test]
        public void WeakWord_ValidLetterSet()
        {
            Word f = new Word("jklmnpstwaeiou");
            Assert.IsTrue(f.IsValidLetterSet);
        }

        [Test]
        public void WeakWord_IsNumeric()
        {
            Word f = new Word("1324");
            Assert.IsTrue(f.IsNumeric);
        }

        [Test]
        public void WeakWord_IsProperModifier()
        {
            Word f = new Word("Mato");
            Assert.IsTrue(f.IsProperModifier);
        }

        [Test]
        public void WeakWord_IsContainedBy()
        {
            Word f = new Word("Mato");
            Assert.IsTrue(f.ContainedBy("jan Mato"));
        }

        [Test]
        public void WeakWord_ConstructorSetsText()
        {
            string word="Mato";
            Word f = new Word(word);
            Assert.IsTrue(f.Text == word);
        }

        [Test]
        public void WeakWord_Constructor2SetsText()
        {
            string word = "Mato";
            Word f = new Word(word, new Dictionary<string, Dictionary<string, string[]>>());
            Assert.IsTrue(f.Text == word);
        }

        [Test]
        public void ImplicitConversions()
        {
            Word s= UseStringAsWord("luka");
            string text = UseWordAsString(Words.luka);
            Assert.AreEqual(s.ToString(),text);
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
