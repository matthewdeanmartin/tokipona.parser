using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;
using BasicTypes.NormalizerCode;
using NUnit.Framework;

namespace BasicTypes
{
    [TestFixture]
    public class SentenceTests

    {
        [Test]
        public void BracketVocative()
        {
            string text = "jan Kiwima o!";
            Sentence s = Sentence.Parse(text, Dialect.LooseyGoosey);
            string diagram= s.ToString("b", Dialect.LooseyGoosey);
            Console.WriteLine(diagram);
            Assert.IsFalse(diagram.Contains("[Error"));
        }

        [Test]
        public void ConjunctionTests_Taso_Conclusion()
        {
            string value = "ni li soweli la taso waso li pona.";
            Sentence s = Sentence.Parse(value, Dialect.LooseyGoosey);
            
            Assert.AreEqual("taso", s.Conclusion.Conjunction.Text);
        }

        [Test]
        public void ConjunctionTests_Taso_Precondition()
        {
            string value = "taso ni li soweli la waso li pona.";
            Sentence s = Sentence.Parse(value, Dialect.LooseyGoosey);

            Assert.AreEqual("taso", s.Preconditions[0].Conjunction.Text);
        }

        [Test]
        public void SentenceWithFullSentenceConditional()
        {
            string value = "ni li soweli la waso li pona.";
            Sentence s = Sentence.Parse(value, Dialect.LooseyGoosey);
            Assert.AreEqual(value, s.ToString());
        }


        [Test]
        public void MaximalSentences_Part1()
        {
            string value = "jan li suli la tenpo pi lili mi.";
            Sentence s = Sentence.Parse(value, Dialect.LooseyGoosey);
            Console.WriteLine("Original: " + value);
            Console.WriteLine("ToString: " + s.ToString("g"));
            Console.WriteLine("ToStringb:" + s.ToString("b"));

            Console.WriteLine("ToString: " + s.ToString("g"));

            Assert.AreEqual(value, s.ToString(), s.ToString("b"));
        }

        [Test]
        public void MaximalSentences_Part_Tail()
        {
            string value = "mi mute li lukin e sitelen pona, kepeken ilo-tawa mani li jo e ijo mute, lon ma-suli pi mi mute.";
            Dialect dialect = Dialect.LooseyGoosey;
            Normalizer norm = new Normalizer(dialect);
            string normalized = norm.NormalizeText(value);
            Sentence s = Sentence.Parse(normalized, dialect);
            Console.WriteLine("Original: " + value);
            Console.WriteLine("ToString: " + s.ToString("g", dialect));
            

            Console.WriteLine("ToString: " + s.ToString("g"));

            Assert.AreEqual(value, s.ToString(), s.ToString("b"));
        }

        [Test]
        public void MaximalSentences()
        {
            string value = "jan li suli la tenpo pi lili mi la mi mute li lukin e sitelen pona, kepeken ilo, tawa mani li jo e ijo mute, lon ma suli pi mi mute.";
            Dialect dialect = Dialect.LooseyGoosey;
            Normalizer norm = new Normalizer(dialect);
            dialect.InferCompoundsPrepositionsForeignText = false;
            
            string normalized = norm.NormalizeText(value);
            Sentence s = Sentence.Parse(normalized, dialect);
            Console.WriteLine("Original: " + value);
            Console.WriteLine("ToString: " + s.ToString("g",dialect));
            Assert.AreEqual(value, s.ToString("g", dialect), s.ToString("b", dialect));
        }
        [Test]
        public void LaFragment()
        {
            string value = "tenpo pi lili mi la mi lukin e sitelen pona.";
            Dialect dialect = Dialect.LooseyGoosey;
            //string normalized = Normalizer.NormalizeText(value,dialect);

            Sentence s = Sentence.Parse(value, dialect);
            Console.WriteLine(s.ToString());
            Console.WriteLine(s.ToString("b"));
            Console.WriteLine(s.ToJsonNet());
            Assert.AreEqual(value, s.ToString(), s.ToString("b"));
        }

        
        public void ConstructAndToString()
        {
            string value = "jan li jo e nanpa 555-1234.";
            Sentence s = EstablishAFact();
            Assert.AreEqual(value, s.ToString());
        }

        [Test]
        public void ParseAndToString()
        {
            string value = "jan li jo e nanpa 555-1234.";
            Sentence s = Sentence.Parse(value, Dialect.LooseyGoosey);
            Assert.AreEqual(value, s.ToString());
            Console.WriteLine(s.ToString("b"));
            Console.WriteLine(s.ToString("bs"));
        }

        private static Sentence EstablishAFact()
        {
            Word jan = Words.jan;
            Word nanpa = Words.nanpa;
            Word fiveEtc = new Word("555-1234");

            Particle en = Particles.en;
            Particle e = Particles.e;

            ComplexChain subject = ComplexChain.SinglePiEnChainFactory(new HeadedPhrase(jan));
            VerbPhrase verbs = new VerbPhrase( Words.jo);
            ComplexChain directs = ComplexChain.SingleEPiChainFactory(new HeadedPhrase(nanpa, new WordSet() { fiveEtc }));

            TpPredicate predicate = new TpPredicate(Particles.li, verbs, directs, null);
            Sentence fact = new Sentence(subject, new PredicateList { predicate }, SentenceDiagnostics.NotFromParser);
            return fact;
        }
    }
}
