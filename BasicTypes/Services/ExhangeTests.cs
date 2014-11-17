using System;
using System.Linq;
using BasicTypes.Collections;
using BasicTypes.Services;
using NUnit.Framework;

namespace BasicTypes
{
    [TestFixture]
    public class ExhangeTests
    {
        [Test]
        [Ignore]
        public void  Test()
        {
            Sentence fact = EstablishAFact();
            Console.WriteLine(fact);
            Assert.IsNotEmpty(fact.ToString());
            Assert.IsFalse(fact.Contains(Words.seme));

            Sentence question = CreateQuestion();
            Console.WriteLine(question);
            Assert.IsNotEmpty(question.ToString());
            Assert.IsTrue(question.Contains(Words.seme));

            Exchange e = new Exchange(new[]{fact}, new Sentence[]{question});
            Sentence[] response= e.Response();
            Assert.Greater(response.Count(),0);
            foreach (Sentence sentence in response)
            {
                string readable = sentence.ToString();
                Assert.NotNull(readable);
                Assert.IsNotEmpty(readable);
                Console.WriteLine(readable);
            }
        }

        private static Sentence CreateQuestion()
        {
            Word jan = Words.seme;
            Word nanpa = Words.nanpa;
            Word fiveEtc = new Word("555-1234");

            ComplexChain subject = ComplexChain.SinglePiEnChainFactory(new HeadedPhrase(jan));
            VerbPhrase verbs = new VerbPhrase(Words.jo);
            
            ComplexChain directs = ComplexChain.SingleEPiChainFactory(new HeadedPhrase(nanpa, new WordSet { fiveEtc }));
            TpPredicate predicate = new TpPredicate(Particles.li, verbs, directs);
            Sentence fact = new Sentence(subject, new PredicateList{predicate});
            return fact;
        }

        private static Sentence EstablishAFact()
        {
            Word jan = Words.jan;
            Word nanpa = Words.nanpa;
            Word fiveEtc = new Word("555-1234");

            ComplexChain subject = ComplexChain.SinglePiEnChainFactory(new HeadedPhrase(jan) );
            VerbPhrase verbs = new VerbPhrase(Words.jo);

            ComplexChain directs =ComplexChain.SingleEPiChainFactory( new HeadedPhrase(nanpa, new WordSet { fiveEtc }));

            TpPredicate predicate = new TpPredicate(Particles.li, verbs, directs);
            Sentence fact = new Sentence(subject, new PredicateList { predicate });
            return fact;
        }
    }
}
