using System;
using BasicTypes.Corpus;
using BasicTypes.Extensions;
using BasicTypes.ParseDiscourse;
using NUnit.Framework;

namespace BasicTypes.NormalizerCode
{
    /// <summary>
    /// Test Normalizer, does not test the Sentence object.
    /// </summary>
    [TestFixture]
    public class NormalizerTests
    {
        [Test]
        public void NormalizationIsIdempotent()
        {
            int i = 0;
            Dialect dialect = Dialect.LooseyGoosey;
            SentenceSplitter ss = new SentenceSplitter(dialect);
            
            CorpusFileReader reader = new CorpusFileReader(true);
            foreach (string s in reader.NextFile())
            {
                string[] sentenceStrings = ss.ParseIntoNonNormalizedSentences(s);
                foreach (string sentence in sentenceStrings)
                {
                    string result1 = Normalizer.NormalizeText(sentence, dialect);
                    string result2 = Normalizer.NormalizeText(result1, dialect);
                    //Assert.AreEqual(result1,result2);
                    if (result1 != result2)
                    {
                        Console.WriteLine("1: " + (result1??"NULL"));
                        Console.WriteLine("2: " + (result2??"NULL"));
                    }
                    i++;
                }
            }
            Console.WriteLine("Sentences normalized: " + i);
        }

        [Test]
        public void ProcessCalmVocative_JustRunIsVocative()
        {

            const string vocative = "jan Oliwa o, o, o.";
            bool isIt = Normalizer.IsVocative(vocative);
            Assert.IsTrue(isIt, "Expected to ID a vocative.");
        }

        [Test]
        public void Nine()
        {
            const string original = "waso li tawa kon li tawa ma luka luka weka wan.";

                Dialect dialect = Dialect.LooseyGoosey;
            dialect.InferCompoundsPrepositionsForeignText = false;
            

            string normalized = Normalizer.NormalizeText(original, dialect);
                        //string result= NormalizeNumbers.FindNumbers(normalized);
                        Assert.AreEqual("waso li tawa kon li ~tawa ma #luka-luka weka #wan.", normalized);
        }

        //mi la jan ni li nasa.
        [Test]
        public void MiLaShouldBeFine()
        {
            const string s = "mi la jan ni li nasa.";
            string normalized = Normalizer.NormalizeText(s, Dialect.LooseyGoosey);
            Assert.AreEqual("mi la jan ni li nasa.", normalized);
        }

        [Test]
        public void DontScrewUpLaCompoundNormalization()
        {
            const string s = "tan ni la soweli lili li tawa poki.";
            string normalized = Normalizer.NormalizeText(s, Dialect.LooseyGoosey);
            Assert.AreEqual("tan ni la soweli-lili li ~tawa poki.",normalized);
        }

        [Test]
        public void NormalizeAllTextFiles()
        {
            int i = 0;
            Dialect dialect = Dialect.LooseyGoosey;
            ParserUtils pu  = new ParserUtils(dialect);
            
            CorpusFileReader reader =new CorpusFileReader();
            SentenceSplitter ss = new SentenceSplitter(dialect);

            foreach (string s in reader.NextFile())
            {
                foreach (string sentence in ss.ParseIntoNonNormalizedSentences(s))
                {
                    string result = Normalizer.NormalizeText(sentence, dialect);
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
            const string s = "taso sina tawa ma Mewika la sina ken kama jo e ijo mute kepeken ona.";

            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.LooseyGoosey);
            Console.WriteLine("Normalized: " + normalized);

            const string expected = "taso sina li ~tawa ma-Mewika la sina li ken kama jo e ijo mute ~kepeken ona.";
            Assert.AreEqual(expected, normalized);
        }

        //

        [Test]
        public void SinaEn()
        {
            const string s = "sina en jan suli li pona kin.";

            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.LooseyGoosey);
            Console.WriteLine("Normalized: " + normalized);

            const string expected = "sina en jan-suli li pona kin.";
            Assert.AreEqual(expected, normalized);
        }

        [Test]
        public void MissingLi2()
        {
            //ni li ijo ike mute! 
            const string s = "tenpo ni la sike mi li tawa kepeken tenpo lili.";
            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.LooseyGoosey);
            Console.WriteLine("Normalized: " + normalized);

            const string expected = "tenpo ni la sike mi li tawa ~kepeken tenpo lili.";
            Assert.AreEqual(expected, normalized);
        
        }

        [Test]
        public void LiTawaEnTan()
        {
            //sina toki e ni: 
            const string s = "nena meli kin li tawa en tan, li kama nena pi suli en kiwen.";
            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.LooseyGoosey);
            Console.WriteLine("Normalized: " + normalized);
            //sina li toki e ni: 
            const string expected = "nena-meli kin li tawa en tan li kama nena pi suli en kiwen.";
            Assert.AreEqual(expected, normalized);
        }

        [Test]
        public void ImperativeAreNotFramgents()
        {
            //sina toki e ni: 
            const string s = "o toki e ni ~tawa jan:'";
            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.LooseyGoosey);
            Console.WriteLine("Normalized: " + normalized);
            //sina li toki e ni: 
            
            Assert.IsFalse(normalized.ContainsCheck("Nanunanuwakawakawawa"));
            normalized = Normalizer.NormalizeText(s, Dialect.LooseyGoosey);
            Assert.IsFalse(normalized.ContainsCheck("Nanunanuwakawakawawa"));
        }

        [Test]
        public void DontSplitMiMute()
        {
            //ken la mi mute li toki ike 
            const string s = "ken la mi mute li toki ike.";

            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.LooseyGoosey);
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
            Dialect d = Dialect.LooseyGoosey;
            d.InferCompoundsPrepositionsForeignText = false;
            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, d);
            Console.WriteLine("Normalized: " + normalized);

            const string expected = "o pali ~sama mije lili pona anu meli lili pona";
            Assert.AreEqual(expected, normalized);
        }

        [Test]
        public void Normalize_IntransitiveVerb()
        {
            Dialect dialect = Dialect.LooseyGoosey;
            string value = Normalizer.NormalizeText("jan li moku, kepeken ilo moku",dialect);
            Console.WriteLine(value);
            Assert.IsTrue(value.ContainsCheck("~"), value);
        }

        [Test]
        public void MiWileENi()
        {
            //sina toki e ni: 
            const string s = "mi wile e ni.";


            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.LooseyGoosey);
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
            string normalized = Normalizer.NormalizeText(s, Dialect.LooseyGoosey);
            Console.WriteLine("Normalized: " + normalized);

            const string expected = "«mi li sona e ni.»";
            Assert.AreEqual(expected,normalized);
        }

        [Test]
        public void LonPokaSentence()
        {
            const string s = "jan Puta li lon poka ma Nepali en Inteja";

            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.LooseyGoosey);
            Console.WriteLine("Normalized: " + normalized);

            const string expected = "jan Puta li ~lon poka ma Nepali en Inteja";
            Assert.AreEqual(expected,normalized);
        }


        [Test]
        public void SomethingLiSama()
        {
            const string s = "ni li sama.";

            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.LooseyGoosey);
            Console.WriteLine("Normalized: " + normalized);

            const string expected = "ni li sama.";
            Assert.AreEqual(expected, normalized);
        }

        [Test]
        public void TawaPiJanPutaLiPona()
        {
            const string s = "tawa pi jan Puta li pona.";

            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.LooseyGoosey);
            Console.WriteLine("Normalized: " + normalized);

            const string expected = "tawa pi jan Puta li pona.";
            Assert.AreEqual(expected, normalized);
        }


        //
        [Test]
        public void SplitSentenceWithColon_Normalized()
        {
            const string s = "sina toki e ni: mi wile e ni.";
            Dialect dialect = Dialect.LooseyGoosey;
            SentenceSplitter ss = new SentenceSplitter(dialect);

            string[] sentences = ss.ParseIntoNonNormalizedSentences(s);

            for (int index = 0; index < sentences.Length; index++)
            {
                sentences[index] = Normalizer.NormalizeText(sentences[index], dialect);
            }

            Assert.AreEqual("sina li toki e ni:", sentences[0]);
            Assert.AreEqual("mi li wile e ni.", sentences[1]);
        }

        
        [Test]
        public void NormalizeIloLukinLi()
        {
            const string s = "ilo lukin li waso tu e len pali e jaki sike.";
            

            Console.WriteLine("Original  : " + s);
            string normalized = Normalizer.NormalizeText(s, Dialect.LooseyGoosey);
            Console.WriteLine("Normalized: " + normalized);

            const string expected = "ilo-lukin li waso #tu e len pali e jaki sike.";
            
            Assert.AreEqual(expected, normalized);
        }
    }
}
