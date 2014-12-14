using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.Parser
{
    /// <summary>
    /// Any Test of a method that is just returning a string array
    /// </summary>
    [TestFixture]
    public class ParserUtilsTestsRegex
    {

        [Test]
        public void GoDawgs()
        {
            //"Go*Dawgs!"
            
            TokenParserUtils tpu = new TokenParserUtils();
            string[] oneForeinString = tpu.JustTpWords("\"Go*Dawgs!\"");
            Assert.AreEqual(1, oneForeinString.Length);

        }

        [Test]
        public void CompoundWordParseSimple()
        {
            TokenParserUtils pu = new TokenParserUtils();
            string[] oneCompound= pu. JustTpWordsNumbersPunctuation("tomo-tawa-kon");
            oneCompound = pu.RemergeCompounds(oneCompound);
            foreach (string s in oneCompound)
            {
                Console.WriteLine(s);
            }
            Assert.AreEqual(1, oneCompound.Length);
            Assert.AreEqual("tomo-tawa-kon", oneCompound[0]);

        }


        //lon-ma-pi-ike-ale

        [Test]
        public void CompoundWordParsePrepPhraseAsCompound()
        {
            TokenParserUtils pu = new TokenParserUtils();
            string[] oneCompound = pu.JustTpWordsNumbersPunctuation("lon-ma-pi-ike-ale");
            oneCompound = pu.RemergeCompounds(oneCompound);
            foreach (string s in oneCompound)
            {
                Console.WriteLine(s);
            }
            Assert.AreEqual(1, oneCompound.Length);
            Assert.AreEqual("lon-ma-pi-ike-ale", oneCompound[0]);

        }


        [Test]
        public void ParseLiAla()
        {
            TokenParserUtils pu = new TokenParserUtils();
            string[] twoWords= pu. JustTpWordsNumbersPunctuation("li ala");
            Assert.AreEqual(2, twoWords.Length);
            Assert.AreEqual("li", twoWords[0]);
            Assert.AreEqual("ala", twoWords[1]);

        }

        [Test]
        public void ParseEachWordInDictionary()
        {
            TokenParserUtils pu = new TokenParserUtils();
            foreach (Word word in Words.Dictionary.Values)
            {
                string[] oneWord = pu.JustTpWords(word.Text);
                Assert.AreEqual(1,oneWord.Length);
                Assert.AreEqual(word.Text,oneWord[0]);
            }
        }

        [Test]
        public void ParseEachWordInDictionary2()
        {
            bool canary = false;
            TokenParserUtils pu = new TokenParserUtils();
            foreach (Word word in Words.Dictionary.Values)
            {
                string[] oneWord = pu.JustTpWordsNumbersPunctuation(word.Text);
                if (oneWord.Length == 0)
                {

                    canary = true;
                    Console.WriteLine(word.Text);
                }
                if (oneWord.Length==1 &&  oneWord[0] != word.Text)
                {
                    canary = true;
                    Console.WriteLine(word.Text);
                }
                //Assert.AreEqual(1, oneWord.Length, word.Text);
                //Assert.AreEqual(word.Text, oneWord[0], word.Text);
            }
            if (canary)
            {
                Assert.Fail("Something failed to parse");
            }
        }

        //[Test]
        //public void SplitEAndPreserve()
        //{
        //    string ePhrase = "li moku e soweli suli mute e wawa e tawa e kala e";
        //    string[] parts = ParserUtils.SplitOnParticlePreserving(Particles.e, ePhrase);
        //    foreach (string part in parts)
        //    {
        //        Console.WriteLine(part);
        //    }
        //}

        [Test]
        public void OneWord()
        {
            TokenParserUtils pu = new TokenParserUtils();
            string[] w = pu.JustTpWords("jan");
            Assert.AreEqual(1, w.Length);
        }

        [Test]
        public void TwoWords()
        {
            TokenParserUtils pu = new TokenParserUtils();
            string[] w = pu.JustTpWords("jan lili");
            Assert.AreEqual(2, w.Length);
        }


        [Test]
        public void ThreWords()
        {
            TokenParserUtils pu = new TokenParserUtils();

            string[] w = pu.JustTpWords("jan lili lon");
            Assert.AreEqual(3, w.Length);
        }

        [Test]
        public void WordsNumbersWithoutDash()
        {
            TokenParserUtils pu = new TokenParserUtils();

            string[] w = pu.JustTpWords("1231231");
            Assert.AreEqual(1, w.Length);
        }

        [Test]
        public void WordsNumbersPunctuationWithoutDash()
        {
            TokenParserUtils pu = new TokenParserUtils();

            string[] w = pu.JustTpWordsNumbersPunctuation("1231231");
            Assert.AreEqual(1, w.Length);
        }

        [Test]
        public void WordsNumbersWithDash()
        {
            TokenParserUtils pu = new TokenParserUtils();

            string[] w = pu.JustTpWords("123-1231");
            foreach (string s in w)
            {
                Console.WriteLine(s);
            }
            Assert.AreEqual(1, w.Length);
        }

        [Test]
        public void WordsNumbersPunctuationWithDash()
        {
            string value = "123-1231";

            TokenParserUtils pu = new TokenParserUtils();

            string[] w = pu.JustTpWordsNumbersPunctuation(value);
            foreach (string s in w)
            {
                Console.WriteLine(s);
            }
            Assert.AreEqual(1, w.Length);
            Assert.AreEqual(value, w[0]);
        }


        [Test]
        public void SplitOnEn()
        {
            string[] values = Splitters.SplitOnEn("jan Mato");
            Assert.AreEqual(1, values.Length);
            Assert.AreEqual("jan Mato", values[0]);
        }


        [Test]
        public void SplitOnEn2()
        {
            string[] values = Splitters.SplitOnEn("jan Mato en jan Wantu");
            Assert.AreEqual(2, values.Length);
            Assert.AreEqual("jan Mato", values[0]);
            Assert.AreEqual("jan Wantu", values[1]);
        }
    }
}
