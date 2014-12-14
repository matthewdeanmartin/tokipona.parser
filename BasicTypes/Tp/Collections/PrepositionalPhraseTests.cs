using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.Collections
{

    [TestFixture]
    public class PrepositionalPhraseTests
    {
        [Test]
        public void ParseKepekenIloSuliPiMaSuli()
        {
            const string value = "~kepeken ilo suli pi ma suli";
            PrepositionalPhrase c = PrepositionalPhrase.Parse(value);
            Assert.AreEqual("~kepeken", c.Preposition.ToString());
            Console.WriteLine(c.ToJsonDcJs());
            Assert.AreEqual("~kepeken ilo suli pi ma suli", c.ToString(), c.ToString("b"));
        }



        [Test]
        public void ParseKepekenIlo()
        {
            const string value = "~kepeken ilo";
            PrepositionalPhrase c = PrepositionalPhrase.Parse(value);
            Assert.AreEqual("~kepeken", c.Preposition.ToString());
            Console.WriteLine(c.ToJsonDcJs());
            Assert.AreEqual("~kepeken ilo", c.ToString(), c.ToString("b"));
        }

        [Test]
        public void ParseKepekenIloSuli()
        {
            const string value = "~kepeken ilo suli";
            PrepositionalPhrase c = PrepositionalPhrase.Parse(value);
            Assert.AreEqual("~kepeken", c.Preposition.ToString());
            Console.WriteLine(c.ToJsonDcJs());
            Assert.AreEqual("~kepeken ilo suli", c.ToString(), c.ToString("b"));
        }
    }
}
