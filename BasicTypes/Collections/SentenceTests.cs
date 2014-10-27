using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;
using NUnit.Framework;

namespace BasicTypes
{
    [TestFixture]
    public class SentenceTests
    {
        [Test]
        public void SentenceWithFullSentenceConditional()
        {
            string value = "ni li soweli la waso li pona.";
            Sentence s = Sentence.Parse(value, Dialect.DialectFactory);
            Assert.AreEqual(value, s.ToString());
        }


        [Test]
        public void MaximalSentences_Part1()
        {
            string value = "jan li suli la tenpo pi lili mi.";
            Sentence s = Sentence.Parse(value, Dialect.DialectFactory);
            Console.WriteLine("Original: " + value);
            Console.WriteLine("ToString: " + s.ToString("g"));
            Console.WriteLine("ToStringb:" + s.ToString("b"));

            Console.WriteLine("ToString: " + s.ToString("g"));

            Assert.AreEqual(value, s.ToString(), s.ToString("b"));
        }

        [Test]
        public void MaximalSentences_Part_Tail()
        {
            string value = "mi mute li lukin e sitelen pona kepeken ilo tawa mani li jo e ijo mute lon ma suli pi mi mute.";
            Sentence s = Sentence.Parse(value, Dialect.DialectFactory);
            Console.WriteLine("Original: " + value);
            Console.WriteLine("ToString: " + s.ToString("g", Dialect.DialectFactory));
            

            Console.WriteLine("ToString: " + s.ToString("g"));

            Assert.AreEqual(value, s.ToString(), s.ToString("b"));
        }

        [Test]
        public void MaximalSentences()
        {
            string value = "jan li suli la tenpo pi lili mi la mi mute li lukin e sitelen pona kepeken ilo tawa mani li jo e ijo mute lon ma suli pi mi mute.";
            Sentence s = Sentence.Parse(value, Dialect.DialectFactory);
            Console.WriteLine("Original: " + value);
            Console.WriteLine("ToString: " + s.ToString("g",Dialect.DialectFactory));
            
            Console.WriteLine("ToString: " + s.ToString("g"));

            Assert.AreEqual(value, s.ToString(), s.ToString("b"));
        }
        [Test]
        public void LaFragment()
        {
            string value = "tenpo pi lili mi la mi lukin e sitelen pona.";

            Sentence s = Sentence.Parse(value, Dialect.DialectFactory);
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
            Sentence s = Sentence.Parse(value, Dialect.DialectFactory);
            Assert.AreEqual(value, s.ToString());
            Console.WriteLine(s.ToString("b"));
            Console.WriteLine(s.ToString("bs"));
        }

        private static Sentence EstablishAFact()
        {
            Word jan = Words.jan;
            //Particle li = Particles.li;
            Word jo = Words.jo;
            Word nanpa = Words.nanpa;
            Word fiveEtc = new Word("555-1234");

            Particle en = Particles.en;
            Particle e = Particles.e;

            Chain subject = new Chain(ChainType.Subjects, en, new[] { new HeadedPhrase(jan, null) });
            HeadedPhrase verbs = new HeadedPhrase(jo, null);
            Chain directs = new Chain(ChainType.Directs, e, new[] { new HeadedPhrase(nanpa, new WordSet() { fiveEtc }) });

            TpPredicate predicate = new TpPredicate(Particles.li, verbs, directs, null);
            Sentence fact = new Sentence(subject, new PredicateList { predicate });
            return fact;
        }
    }
}
