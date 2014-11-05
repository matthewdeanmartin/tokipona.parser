using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Corpus;
using NUnit.Framework;

namespace BasicTypes.Parser
{
    [TestFixture]
    public class NormalizerTests
    {
        //ko suno linja li lon ale, taso ni li ken kama kiwen kiwen kiwen kiwen li kama sijelo.
        //[Test]
        //public void ProllyAnotherWordBoundaryProblem()
        //{
        //    string s = "ko suno linja li lon ale, taso ni li ken kama kiwen kiwen kiwen kiwen li kama sijelo.";
        //    string normalized = Normalizer.NormalizeText(s, Dialect.DialectFactory);
        //    Assert.AreEqual("ko-suno-linja li ~lon ale, taso ni li ken kama kiwen kiwen kiwen kiwen li kama sijelo.", normalized);
        //}

        [Test]
        public void DontScrewUpLaCompoundNormalization()
        {
            string s="tan ni la soweli lili li tawa poki.";
            string normalized = Normalizer.NormalizeText(s, Dialect.DialectFactory);
            Assert.AreEqual("tan ni la soweli-lili li ~tawa poki.",normalized);
        }

        [Test]
        public void NormalizeAllTextFiles()
        {
            int i = 0;
            ParserUtils pu  = new ParserUtils(Dialect.DialectFactory);
            
            CorpusFileReader reader =new CorpusFileReader();
            foreach (string s in reader.NextFile())
            {
                foreach (string sentence in pu.ParseIntoRawSentences(s))
                {
                    string result = Normalizer.NormalizeText(sentence);
                    decimal percent = NormalizeChaos.PercentTokiPona(result);
                    Console.WriteLine(percent + "%");
                    i++;
                }
            }
            Console.WriteLine("Sentences normalized: " + i);
        }

        //nena meli kin li tawa en tan, li kama nena pi suli en kiwen.

        [Test]
        public void MissingLi()
        {
            string s = "taso sina tawa ma Mewika la sina ken kama jo e ijo mute kepeken ona.";

            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.DialectFactory);
            Console.WriteLine("Normalized: " + normalized);

            const string expected = "taso sina li ~tawa ma Mewika la sina li ken kama jo e ijo mute ~kepeken ona.";
            Assert.AreEqual(expected, normalized);
        }

        [Test]
        public void LiTawaEnTan()
        {
            //sina toki e ni: 
            const string s = "nena meli kin li tawa en tan, li kama nena pi suli en kiwen.";
            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.DialectFactory);
            Console.WriteLine("Normalized: " + normalized);
            //sina li toki e ni: 
            const string expected = "nena meli kin li tawa en tan li kama nena pi suli en kiwen.";
            Assert.AreEqual(expected, normalized);
        }

        [Test]
        public void ImperativeAreNotFramgents()
        {
            //sina toki e ni: 
            const string s = "o toki e ni ~tawa jan:'";
            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.DialectFactory);
            Console.WriteLine("Normalized: " + normalized);
            //sina li toki e ni: 
            
            Assert.IsFalse(normalized.Contains("Nanunanuwakawakawawa"));
            normalized = Normalizer.NormalizeText(s, Dialect.DialectFactory);
            Assert.IsFalse(normalized.Contains("Nanunanuwakawakawawa"));
        }

        [Test]
        public void DontSplitMiMute()
        {
            //ken la mi mute li toki ike 
            const string s = "ken la mi mute li toki ike.";

            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.DialectFactory);
            Console.WriteLine("Normalized: " + normalized);

            const string expected = "ken la mi mute li toki ike.";
            Assert.AreEqual(expected, normalized);
        }

        //"o pali sama mije lili pona anu meli lili pona"
        [Test]
        public void DetectSamaInImperative()
        {
            //ken la mi mute li toki ike 
            const string s = "o pali sama mije lili pona anu meli lili pona";

            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.DialectFactory);
            Console.WriteLine("Normalized: " + normalized);

            const string expected = "o pali ~sama mije lili pona anu meli lili pona";
            Assert.AreEqual(expected, normalized);
        }

        [Test]
        public void Normalize_IntransitiveVerb()
        {
            string value = Normalizer.NormalizeText("jan li moku, kepeken ilo moku");
            Console.WriteLine(value);
            Assert.IsTrue(value.Contains("~"), value);
        }

        [Test]
        public void MiWileENi()
        {
            //sina toki e ni: 
            const string s = "mi wile e ni.";


            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.DialectFactory);
            Console.WriteLine("Normalized: " + normalized);
            //sina li toki e ni: 
            const string expected = "mi li wile e ni.";
            Assert.AreEqual(expected, normalized);
        }

        [Test]
        public void SimpleMiSonaENi()
        {
            const string s = "'mi sona e ni.'";
                Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.DialectFactory);
            Console.WriteLine("Normalized: " + normalized);

            const string expected = "«mi li sona e ni.»";
            Assert.AreEqual(expected,normalized);
        }

        [Test]
        public void LonPokaSentence()
        {
            const string s = "jan Puta li lon poka ma Nepali en Inteja";

            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.DialectFactory);
            Console.WriteLine("Normalized: " + normalized);

            const string expected = "jan Puta li ~lon poka ma Nepali en Inteja";
            Assert.AreEqual(expected,normalized);
        }


        [Test]
        public void SomethingLiSama()
        {
            const string s = "ni li sama.";

            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.DialectFactory);
            Console.WriteLine("Normalized: " + normalized);

            const string expected = "ni li sama.";
            Assert.AreEqual(expected, normalized);
        }

        [Test]
        public void TawaPiJanPutaLiPona()
        {
            const string s = "tawa pi jan Puta li pona.";

            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.DialectFactory);
            Console.WriteLine("Normalized: " + normalized);

            const string expected = "tawa pi jan Puta li pona.";
            Assert.AreEqual(expected, normalized);
        }

    }
}
