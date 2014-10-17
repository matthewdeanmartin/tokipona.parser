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
        public void SplitEAndPreserve()
        {
            string ePhrase = "li moku e soweli suli mute e wawa e tawa e kala e";
            string[] parts = ParserUtils.SplitOnParticlePreserving(Particles.e, ePhrase);
            foreach (string part in parts)
            {
                Console.WriteLine(part);
            }
        }

        [Test]
        public void OneWord()
        {
            ParserUtils pu = new ParserUtils(Config.Instance);
            string[] w = pu.JustTpWords("jan");
            Assert.AreEqual(1, w.Length);
        }

        [Test]
        public void TwoWords()
        {
            Config c = Config.Default;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            string[] w = pu.JustTpWords("jan lili");
            Assert.AreEqual(2, w.Length);
        }


        [Test]
        public void ThreWords()
        {
            Config c = Config.Default;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            string[] w = pu.JustTpWords("jan lili lon");
            Assert.AreEqual(3, w.Length);
        }

        [Test]
        public void WordsNumbersWithoutDash()
        {
            Config c = Config.Default;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            string[] w = pu.JustTpWords("1231231");
            Assert.AreEqual(1, w.Length);
        }

        [Test]
        public void WordsNumbersPunctuationWithoutDash()
        {
            Config c = Config.Default;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            string[] w = pu.JustTpWordsNumbersPunctuation("1231231");
            Assert.AreEqual(1, w.Length);
        }

        [Test]
        public void WordsNumbersWithDash()
        {
            Config c = Config.Default;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

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

            Config c = Config.Default;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

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
            string[] values = ParserUtils.SplitOnEn("jan Mato");
            Assert.AreEqual(1, values.Length);
            Assert.AreEqual("jan Mato", values[0]);
        }


        [Test]
        public void SplitOnEn2()
        {
            string[] values = ParserUtils.SplitOnEn("jan Mato en jan Wantu");
            Assert.AreEqual(2, values.Length);
            Assert.AreEqual("jan Mato", values[0]);
            Assert.AreEqual("jan Wantu", values[1]);
        }
    }
}
