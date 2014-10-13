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
    public class SenteneTests
    {
        [Test]
        public void LaFragment()
        {
            string value = "tenpo pi lili mi la mi li lukin e sitelen pona.";
            Sentence s = Sentence.Parse(value);
            Assert.AreEqual(value, s.ToString());
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
            Sentence s = Sentence.Parse(value);
            Assert.AreEqual(value, s.ToString());
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

            TpPredicate predicate = new TpPredicate(verbs, directs, null);
            Sentence fact = new Sentence(subject, new PredicateList { predicate });
            return fact;
        }
    }
}
