using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Exceptions;
using NUnit.Framework;

namespace BasicTypes.Parts
{
    //All word, particle, compound word, number tests must also pass these tests. (for all valid words, numbers, etc)
    [TestFixture]
    public class TokenTests
    {
        private string phonologicallyValidNonTpWord = "nono";

        [Test]
        public void CanJsonSerialize()
        {
            Token f = new Token(phonologicallyValidNonTpWord);
            Assert.NotNull(f.ToJsonDcJs());
        }

        [Test]
        public void CanJsonSerializeJss()
        {
            Token f = new Token(phonologicallyValidNonTpWord);
            Assert.NotNull(f.ToJsonJss());
        }

        [Test]
        public void CanXmlSerialize()
        {
            Token f = new Token(phonologicallyValidNonTpWord);
            Assert.NotNull(f.ToXml());
        }

        [Test]
        public void CanBinarySerialize()
        {
            Token f = new Token(phonologicallyValidNonTpWord);

            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, f);
                ms.Position = 0;
                Token result = formatter.Deserialize(ms) as Token;
                //TODO Assert
                //Assert.NotNull(WordByValue.Instance.Equals(result, f));
            }
        }


        [Test]
        public void Token_DetectsInvalidCharacterSet()
        {
            Token f = new Token("asdfghjkl");
            Assert.IsFalse(f.IsValidLetterSet);
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void Token_NullNotAllowedInConstructor()
        {
            Token f = new Token(null);
        }


        [Test]
        public void Token_DetectsInvalidPhonology()
        {
            Token f = new Token("asdfghjkl");
            Assert.IsFalse(f.IsValidLetterSet);
        }

        [Test]
        public void Token_ValidPhonology()
        {
            Token f = new Token("nonon");
            Assert.IsTrue(f.IsValidPhonology);
        }

        [Test]
        public void Token_InvalidPhonology()
        {
            Token f = new Token("nnonon");
            Assert.IsFalse(f.IsValidPhonology);
        }

        [Test]
        public void Token_ValidLetterSet()
        {
            Token f = new Token("jklmnpstwaeiou");
            Assert.IsTrue(f.IsValidLetterSet);
        }

        [Test]
        public void Token_IsNumeric()
        {
            Token f = new Token("1324");
            Assert.IsTrue(f.IsNumeric);
        }

        [Test]
        public void Token_IsProperModifier()
        {
            Token f = new Token("Mato");
            Assert.IsTrue(f.IsProperModifier);
        }

        [Test]
        public void Token_IsContainedBy()
        {
            Token f = new Token("Mato");
            Assert.IsTrue(f.ContainedBy("jan Mato"));
        }

        [Test]
        public void Token_ConstructorSetsText()
        {
            string word = "Mato";
            Token f = new Token(word);
            Assert.IsTrue(f.Text == word);
        }

        [Test]
        public void Token_Constructor2SetsText()
        {
            string word = "Mato";
            Token f = new Token(word); //new Dictionary<string, Dictionary<string, string[]>>()
            Assert.IsTrue(f.Text == word);
        }

        [Test]
        public void ImplicitConversions()
        {
            Token s = UseStringAsWord("luka");
            string text = UseWordAsString(s);
            Assert.AreEqual(s.ToString(), text);
            //Assert.IsFalse(object.ReferenceEquals(s.ToString(), text)); //These aren't copies!
        }

        public Token UseStringAsWord(string test)
        {
            return test;
        }

        public string UseWordAsString(Token test)
        {
            return test;
        }

        [Test]
        public void CromulentCompoundWord()
        {
            //CheckIsCompoundWord
            Token t = new Token();
            Assert.IsTrue(t.CheckIsCompoundWord("Nepali-en-Inteja"));
        }

        [Test]
        public void CromulentIsProperModifer()
        {
            //CheckIsCompoundWord
            Token t = new Token();
            Assert.IsTrue(t.CheckIsProperModifier("A"));
        }
        
    }
}
