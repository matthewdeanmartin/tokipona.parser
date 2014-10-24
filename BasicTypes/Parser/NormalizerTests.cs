using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.Parser
{
    [TestFixture]
    public class NormalizerTests
    {

        [Test]
        public void MiWileENi()
        {
            //sina toki e ni: 
            string s = "mi wile e ni.";


            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Config.CurrentDialect);
            Console.WriteLine("Normalized: " + normalized);
            //sina li toki e ni: 
            string expected = "mi li wile e ni.";
            Assert.AreEqual(expected, normalized);
        }

        [Test]
        public void LonPokaSentence()
        {
            string s = "jan Puta li lon poka ma Nepali en Inteja";

            Console.WriteLine("Original  : " + s);
            string normalized=  Normalizer.NormalizeText(s, Config.CurrentDialect);
            Console.WriteLine("Normalized: " + normalized);

            string expected = "jan Puta li ~lon poka ma Nepali en Inteja";
            Assert.AreEqual(expected,normalized);
        }


        [Test]
        public void SomethingLiSama()
        {
            string s = "ni li sama.";

            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Config.CurrentDialect);
            Console.WriteLine("Normalized: " + normalized);

            string expected = "ni li sama.";
            Assert.AreEqual(expected, normalized);
        }

        [Test]
        public void TawaPiJanPutaLiPona()
        {
            string s = "tawa pi jan Puta li pona.";

            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Config.CurrentDialect);
            Console.WriteLine("Normalized: " + normalized);

            string expected = "tawa pi jan Puta li pona.";
            Assert.AreEqual(expected, normalized);
        }

    }
}
