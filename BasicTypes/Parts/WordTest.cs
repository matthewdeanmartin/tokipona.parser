using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Exceptions;
using BasicTypes.MoreTypes;
using Microsoft.SqlServer.Server;
using NUnit.Framework;

namespace BasicTypes
{
    [TestFixture]
    public class WordTest
    {

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
            Word f = new Word(word, new SerializableDictionary<PartOfSpeech, string>());
            Assert.IsTrue(f.Text == word);
        }
    }
}
